namespace DevBoard.Common.Errors
{
    public static class ErrorCode
    {
        // Validation
        public const string InvalidUsername = "INVALID_USERNAME";
        public const string InvalidEmail = "INVALID_EMAIL";
        public const string InvalidPassword = "INVALID_PASSWORD";

        // Authentication
        public const string InvalidCredentials = "INVALID_CREDENTIALS";

        // User
        public const string UsernameAlreadyExists = "USERNAME_ALREADY_EXISTS";
        public const string EmailAlreadyExists = "EMAIL_ALREADY_EXISTS";
        public const string UserNotFound = "USER_NOT_FOUND";
    }
}