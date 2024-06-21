using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Disertatie_backend.Helpers;
using MongoDB.Driver;
using AutoMapper.QueryableExtensions;
using System;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Disertatie_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();

            query = query.Where(u => u.UserName != userParams.CurrentUsername);

            if (!string.IsNullOrWhiteSpace(userParams.SearchedUsername))
                query = query.Where(u => u.UserName.Contains(userParams.SearchedUsername));

            query = userParams.OrderBy switch
            {
                "username" => query.OrderByDescending(u => u.LastActive).OrderBy(u => u.UserName),
                "newest accounts" => query.OrderByDescending(u => u.Created).OrderByDescending(u => u.LastActive),
                _ => query.OrderByDescending(u => u.Created)

            };

            return await PagedList<MemberDto>.CreateAsync(query.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                userParams.PageNumber, userParams.PageSize);
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<AppUser> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(p => p.Photos)
                .Include(p => p.AppUserAnime)
                .Include(p => p.AppUserManga)
                .Include(p => p.AppUserMovie)
                .Include(p => p.AppUserTvShow)
                .Include(p => p.AppUserGame)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<bool> EnableNewsletterUserAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null) return false;

            user.IsSubscribedToNewsletter = !user.IsSubscribedToNewsletter;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteUser(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if(user == null) return;

            foreach (var item in _context.UserAnimes)
            {
                if (item.AppUser == user) _context.UserAnimes.Remove(item);
            }

            foreach (var item in _context.UserGames)
            {
                if (item.AppUser == user) _context.UserGames.Remove(item);
            }

            foreach (var item in _context.UserMangas)
            {
                if (item.AppUser == user) _context.UserMangas.Remove(item);
            }

            foreach (var item in _context.UserMovies)
            {
                if (item.AppUser == user) _context.UserMovies.Remove(item);
            }

            foreach (var item in _context.UserTvShows)
            {
                if (item.AppUser == user) _context.UserTvShows.Remove(item);
            }

            foreach (var item in _context.UserRoles)
            {
                if (item.User == user) _context.UserRoles.Remove(item);
            }

            foreach (var item in _context.UserLogins)
            {
                if (item.UserId == user.Id) _context.UserLogins.Remove(item);
            }

            foreach (var item in _context.UserClaims)
            {
                if (item.UserId == user.Id) _context.UserClaims.Remove(item);
            }

            foreach (var item in _context.Friends)
            {
                if (item.User1 == user || item.User2 == user) _context.Friends.Remove(item);
            }

            foreach (var item in _context.Messages)
            {
                if (item.SenderUsername == user.UserName || item.RecipientUsername == user.UserName) _context.Messages.Remove(item);
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
