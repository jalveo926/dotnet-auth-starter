using System.Text.RegularExpressions;

namespace DevBoard.Common.Utilities
{
    public static class ValidationUtils
    {
        // Validate email using regex
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );
        }

        // Validate username: only letters, numbers, and underscores, between 3 and 50 characters
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return Regex.IsMatch(
                username,
                @"^[a-zA-Z0-9_]{3,50}$"
            );
        }

        // Validate password: at least 8 characters, at least one uppercase letter, one lowercase letter, and one number
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8)
                return false;

            if (!Regex.IsMatch(password, @"[A-Z]"))
                return false;

            if (!Regex.IsMatch(password, @"[a-z]"))
                return false;

            if (!Regex.IsMatch(password, @"[0-9]"))
                return false;

            return true;
        }
    }
}
