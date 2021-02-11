namespace ReversiRestAPI {
    public interface IGame {
        int ID { get; set; }
        string Description { get; set; }

        //The unique token of the game
        string Token { get; set; }
        string Player1Token { get; set; }
        string Player2Token { get; set; }
        Colour[,] Board { get; set; }
        Colour Turn { get; set; }
        bool Pass();
        bool GameOver();
        Colour DominantColour();
        bool PossibleMove(int row, int column);
        bool DoMove(int row, int column);
    }
}
