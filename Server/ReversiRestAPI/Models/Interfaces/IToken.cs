using System;

namespace ReversiRestAPI.Models.Interfaces {
    public interface IToken {

        public TimeSpan CreatedTimestamp { get; set; }
        public int State { get; set; }
        public string TokenPart { get; set; }
        public string Nonce { get; set; }
        public string ToString();
    }
}
