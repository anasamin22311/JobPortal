using JobPortal.Domain.Auth;

namespace JobPortal.Application.DataAccess.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthModel> SignUpAsync(SignUpModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
    }
}
