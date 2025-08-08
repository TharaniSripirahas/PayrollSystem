using PayrollSystem.src.microservices.AuthenticationService.DTOs;
using PayrollSystem.src.microservices.shared.Common;

namespace PayrollSystem.src.microservices.AuthenticationService.Services.AuthService
{
    public interface IAuthService
    {
        Task<ApiResult<UserLoginResponse>> LoginAsync(LoginRequest request);
        Task<ApiResult<string>> RegisterAsync(RegisterRequest request);
    }

}
