using ReversiRestAPI.Helpers;
using ReversiRestAPI.Models.Interfaces;
using System;
using System.Text;

namespace ReversiRestAPI.Models {
    public class GameToken : IToken {
        public TimeSpan CreatedTimestamp { get; set; }
        public int State { get; set; }
        public static int GameTokenCount { get; private set; }
        public string TokenPart { get; set; }
        public string Nonce { get; set; }

        public GameToken() {

        }

        public GameToken(string playerToken) {
            CreatedTimestamp = DateTime.Now - TokenGenerator.Equinox;

            State = GameTokenCount + 1;
            GameTokenCount++;

            var pTokenParts = playerToken.Split('-');
            TokenPart = pTokenParts[2] + '.' + pTokenParts[3];

            Nonce = TokenGenerator.GenerateRandomString(8);
        }

        public static GameToken ResolveToken(string token) {
            var parts = token.Split('-');
            byte[] time = Convert.FromBase64String(parts[0]);
            string resolvedTime = Encoding.UTF8.GetString(time);
            double milliseconds = double.Parse(resolvedTime);
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);

            int state = int.Parse(parts[1]);

            return new GameToken { CreatedTimestamp = timeSpan, State = state, TokenPart = parts[2], Nonce = parts[3] };
        }

        public override string ToString() {
            byte[] blep = Encoding.UTF8.GetBytes(CreatedTimestamp.TotalMilliseconds.ToString());
            string timeEncoded = Convert.ToBase64String(blep);

            return $"G{timeEncoded}-{State:X6}-{TokenPart}-{Nonce}";
        }
    }
}
