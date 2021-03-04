using ReversiRestAPI.Helpers;
using ReversiRestAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestAPI.Repositories {
    public class GameRepository : IGameRepository {

        public List<Game> Games { get; set; }

        public GameRepository() {
            Game game1 = new Game();
            Game game2 = new Game();
            Game game3 = new Game();

            game1.Player1Token = "PNTM5OTg4NjMxNy4xMjk0-00000000-Bobby-83hvfxCs";//TokenGenerator.GeneratePlayerToken(0, "Bobby");
            game1.Description = "Quick game of Reversi, so don't think too long";
            game2.Player1Token = "PNTM5OTg4NjMyMC42MjQy-00000001-Billy-RNtVqdIs";//TokenGenerator.GeneratePlayerToken(1, "Billy");
            game2.Player2Token = "PNTM5OTg4NjMyMC42MzM1-00000002-Jessica-O7QTnVwx";//TokenGenerator.GeneratePlayerToken(2, "Jessica");
            game2.Description = "I'm looking for an advanced opponent";
            game3.Player1Token = "PNTM5OTg4NjMyMC42NzM=-00000003-Monika-oXVleQZI";// TokenGenerator.GeneratePlayerToken(3, "Monika");
            game3.Description = "After this game I want to play a couple more with the same opponent";

            game1.Token = "GNTM5OTg4NjMyMC45MjEy-000001-Bobby.83hvfxCs-fkuJOXXr";//TokenGenerator.GenerateGameToken(0, game1.Player1Token);
            game2.Token = "GNTM5OTg4NjMyMS4wMTI0-000002-Jessica.O7QTnVwx-OV4KT5Ys";//TokenGenerator.GenerateGameToken(1, game2.Player2Token);
            game3.Token = "GNTM5OTg4NjMyMS4wMTg4-000003-Monika.oXVleQZI-F5DR3iZw";//TokenGenerator.GenerateGameToken(2, game3.Player1Token);

            Games = new List<Game> { game1, game2, game3 };
        }

        public void AddGame(Game game) {
            Games.Add(game);
        }

        public Game GetGame(string gameToken) {
            return Games.First(g => g.Token == gameToken);
        }

        public List<Game> GetGames() {
            return Games;
        }
    }
}
