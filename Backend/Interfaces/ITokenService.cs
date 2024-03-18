using Backend.Entities;
using System.Threading.Tasks;

namespace Backend.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}
