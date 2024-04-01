using Disertatie_backend.DTO.Identity;
using Disertatie_backend.Entities;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
