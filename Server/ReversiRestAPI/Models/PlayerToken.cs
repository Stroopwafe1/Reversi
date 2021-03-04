using ReversiRestAPI.Helpers;
using ReversiRestAPI.Models.Interfaces;
using System;
using System.Text;

namespace ReversiRestAPI.Models {
    public class PlayerToken : IToken {
        public TimeSpan CreatedTimestamp { get; set; }
        public int State { get; set; }
        public static int PlayerTokenCount { get; private set; }
        public string TokenPart { get; set; }
        public string Nonce { get; set; }

        public PlayerToken() {

        }

        public PlayerToken(string username) {
            CreatedTimestamp = DateTime.Now - TokenGenerator.Equinox;
            
            State = PlayerTokenCount + 1;
            PlayerTokenCount++;

            TokenPart = username;

            Nonce = TokenGenerator.GenerateRandomString(8);
        }

        public static PlayerToken ResolveToken(string token) {
            var parts = token.Split('-');
            byte[] time = Convert.FromBase64String(parts[0]);
            string resolvedTime = Encoding.UTF8.GetString(time);
            double milliseconds = double.Parse(resolvedTime);
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);

            int state = int.Parse(parts[1]);

            return new PlayerToken { CreatedTimestamp = timeSpan, State = state, TokenPart = parts[2], Nonce = parts[3] };
        }

        public override string ToString() {
            byte[] blep = Encoding.UTF8.GetBytes(CreatedTimestamp.TotalMilliseconds.ToString());
            string timeEncoded = Convert.ToBase64String(blep);

            return $"P{timeEncoded}-{State:X8}-{TokenPart}-{Nonce}";
        }
    }
}
