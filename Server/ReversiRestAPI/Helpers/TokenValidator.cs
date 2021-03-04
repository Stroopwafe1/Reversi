namespace ReversiRestAPI.Helpers {
    public static class TokenValidator {

        public static bool ValidateGameToken(string token) {
            if (string.IsNullOrEmpty(token)) return false;
            if (!token.StartsWith('G')) return false;
            if (token.Split('-').Length != 4) return false;
            return true;
        }

        public static bool ValidatePlayerToken(string token) {
            if (string.IsNullOrEmpty(token)) return false;
            if (!token.StartsWith('P')) return false;
            if (token.Split('-').Length != 4) return false;
            return true;
        }
    }
}
