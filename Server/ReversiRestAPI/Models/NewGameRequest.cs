namespace ReversiRestAPI.Models {
    public class NewGameRequest {

        public string PlayerToken { get; set; }
        public string GameDescription { get; set; }
        public bool PlayerPickedWhite { get; set; }

    }
}
