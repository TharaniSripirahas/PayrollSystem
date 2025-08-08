namespace PayrollSystem.src.microservices.AuthenticationService.Services.AuthService
{
    public class UserLoginResponse
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }

}