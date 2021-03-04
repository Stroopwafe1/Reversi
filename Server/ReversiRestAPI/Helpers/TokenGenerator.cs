using ReversiRestAPI.Models;
using System;
using System.Text;

namespace ReversiRestAPI.Helpers {
    public static class TokenGenerator {

        public static DateTime Equinox = new DateTime(2021, 1, 1);

        public static string GenerateGameToken(string playerToken) {
            //Structure of a game token
            //G....-....-....-....
            //[0]: Timestamp since equinox
            //[1]: State => Number of games currently going
            //[2]: Player token last bit
            //[3]: Nonce

            GameToken gameToken = new GameToken(playerToken);
            return gameToken.ToString();
        }

        public static string GeneratePlayerToken(string username) {
            //Structure of a player token
            //P....-....-....-....
            //[0]: Timestamp since equinox
            //[1]: State => Number of total players
            //[2]: Username
            //[3]: Nonce

            PlayerToken playerToken = new PlayerToken(username);
            return playerToken.ToString();
        }

        /// <summary>
        /// This will generate a random string with the given length.
        /// </summary>
        /// <param name="length">The length of the string to be generated</param>
        /// <returns>The randomly generated string</returns>
        public static string GenerateRandomString(int length) {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
            for (int i = 0; i < length; i++) {
                stringBuilder.Append(allowedChars[random.Next(allowedChars.Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}
