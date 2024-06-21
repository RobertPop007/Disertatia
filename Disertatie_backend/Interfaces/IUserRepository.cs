using Disertatie_backend.DTO;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(Guid id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        Task<MemberDto> GetMemberAsync(string username);
        Task<bool> EnableNewsletterUserAsync(string username);
        Task DeleteUser(string username);
    }
}
