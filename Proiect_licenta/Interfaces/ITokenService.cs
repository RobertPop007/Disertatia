using Proiect_licenta.Entities;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
