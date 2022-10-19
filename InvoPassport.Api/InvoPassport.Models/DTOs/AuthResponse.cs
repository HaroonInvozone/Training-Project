namespace InvoPassport.Models.DTOs
{
    public class AuthResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; } = string.Empty;
    }
}
