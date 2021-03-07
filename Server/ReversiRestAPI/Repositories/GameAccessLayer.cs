using ReversiRestAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ReversiRestAPI.Repositories {
    public class GameAccessLayer : IGameRepository {

        private readonly SqlConnection sqlConnection;
        private readonly Dictionary<string, Game> gameCache;

        public GameAccessLayer() {
            gameCache = new Dictionary<string, Game>();
            sqlConnection = new SqlConnection("Data Source=DESKTOP-G7QC4HC; Initial Catalog=ReversiDbRestApi; Integrated Security=True;");
        }

        public void AddGame(Game game) {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand addCommand = new SqlCommand("INSERT INTO [dbo].[Game] (Token, Description, P1Token, P2Token, Board) VALUES (@Token, @Desc, @P1, @P2, @Board)", sqlConnection);
            
            addCommand.Parameters.Add(new SqlParameter("@Token", game.Token));
            addCommand.Parameters.Add(new SqlParameter("@Desc", game.Description));
            addCommand.Parameters.Add(new SqlParameter("@P1", game.Player1Token));
            addCommand.Parameters.Add(new SqlParameter("@P2", game.Player2Token));
            addCommand.Parameters.Add(new SqlParameter("@Board", game.FENNotation));

            if (game.Player1Token == null)
                addCommand.Parameters["@P1"].Value = DBNull.Value;
            else if (game.Player2Token == null)
                addCommand.Parameters["@P2"].Value = DBNull.Value;

            addCommand.ExecuteNonQuery();

            gameCache.Add(game.Token, game);
            sqlConnection.Close();
        }

        public Game GetGame(string token) {
            //Try to get the game from cache
            if (gameCache.ContainsKey(token))
                return gameCache[token];
            else {
                var gameFound = gameCache.FirstOrDefault(pair => pair.Value.Player1Token == token || pair.Value.Player2Token == token).Value;
                if (gameFound != default(Game))
                    return gameFound;
            }

            //Game wasn't in cache, find in database
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand getGameCommand = new SqlCommand("SELECT * FROM [dbo].[Game] WHERE Token = @token OR P1Token = @token OR P2Token = @token", sqlConnection);

            getGameCommand.Parameters.Add(new SqlParameter("@Token", token));

            var reader = getGameCommand.ExecuteReader();
            Game game = null;

            if (!reader.HasRows) {
                reader.Close();
                sqlConnection.Close();
                return game;
            }

            reader.Read();
            game = new Game();
            int tokenOrdinal = reader.GetOrdinal("Token");
            int descOrdinal = reader.GetOrdinal("Description");
            int p1TokenOrdinal = reader.GetOrdinal("P1Token");
            int p2TokenOrdinal = reader.GetOrdinal("P2Token");
            int boardOrdinal = reader.GetOrdinal("Board");

            game.Token = reader[tokenOrdinal] as string;
            game.Description = reader[descOrdinal] as string;
            game.Player1Token = reader[p1TokenOrdinal] as string;
            game.Player2Token = reader[p2TokenOrdinal] as string;
            game.FENNotation = reader[boardOrdinal] as string;
            game.Board = game.GetBoardFromFEN(game.FENNotation);

            reader.Close();
            sqlConnection.Close();

            return game;
        }

        public List<Game> GetGames() {
            if(sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand getGamesCommand = new SqlCommand("SELECT * FROM [dbo].[Game]", sqlConnection);

            List<Game> games = new List<Game>();

            var reader = getGamesCommand.ExecuteReader();

            if (!reader.HasRows) {
                reader.Close();
                sqlConnection.Close();
                return games;
            }

            while(reader.Read()) {
                Game game = new Game();

                int tokenOrdinal = reader.GetOrdinal("Token");
                int descOrdinal = reader.GetOrdinal("Description");
                int p1TokenOrdinal = reader.GetOrdinal("P1Token");
                int p2TokenOrdinal = reader.GetOrdinal("P2Token");
                int boardOrdinal = reader.GetOrdinal("Board");

                game.Token = reader[tokenOrdinal] as string;
                game.Description = reader[descOrdinal] as string;
                game.Player1Token = reader[p1TokenOrdinal] as string;
                game.Player2Token = reader[p2TokenOrdinal] as string;
                game.FENNotation = reader[boardOrdinal] as string;
                game.Board = game.GetBoardFromFEN(game.FENNotation);

                games.Add(game);
                gameCache.Add(game.Token, game);
            }

            reader.Close();
            sqlConnection.Close();
            return games;
        }
    }
}
