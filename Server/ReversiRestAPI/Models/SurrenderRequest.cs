namespace ReversiRestAPI.Models {
    public class SurrenderRequest {
        public string GameToken { get; set; }
        public string PlayerToken { get; set; }
    }
}
