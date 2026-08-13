namespace DevBoard.Services.Results
{
    public class AuthResult
    {
        public bool Success { get; set; }

        public string? ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}