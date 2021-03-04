using System.Collections.Generic;

namespace ReversiRestAPI.Repositories.Interfaces {
    public interface IGameRepository {

        void AddGame(Game game);
        public List<Game> GetGames();

        Game GetGame(string gameToken);
    }
}
