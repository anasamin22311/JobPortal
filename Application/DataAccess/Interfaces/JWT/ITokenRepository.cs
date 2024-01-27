using JobPortal.Domain;
using JobPortal.Domain.JWT;

namespace Twitter.Application.DataAccess.Interfaces.JWT
{
    public interface ITokenRepository
    {
        Tokens Authenticate(User user);
    }
}
