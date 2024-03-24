﻿using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Disertatie_backend.Helpers;

namespace Disertatie_backend.DatabaseContext
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
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();

            query = query.Where(u => u.UserName != userParams.CurrentUsername);

            if(!string.IsNullOrWhiteSpace(userParams.SearchedUsername))
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

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(p => p.ProfilePicture)
                .Include(p => p.AddedByUsers)
                .Include(p => p.AddedUsers)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p => p.ProfilePicture)
                .ToListAsync();
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
