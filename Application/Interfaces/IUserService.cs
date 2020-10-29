using System.Threading.Tasks;
using Application.Common.Wrappers;
using Application.DTOs.Account;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<AuthResponse>> AuthenticateAsync(AuthRequest request, string ipAddress);
        Task<Response<string>> VerifyEmailAsync(string userId, string code);
        Task ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<Response<string>> ResetPasswordAsync(ResetPasswordRequest request);
    }
}