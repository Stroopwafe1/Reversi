namespace ReversiRestAPI.Models {
    public class MoveRequest {

        public string GameToken { get; set; }
        public string PlayerToken { get; set; }
        public Coordinates Coordinates { get; set; }

    }
}
