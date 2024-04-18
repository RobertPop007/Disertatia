using Disertatie_backend.Entities.User;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
