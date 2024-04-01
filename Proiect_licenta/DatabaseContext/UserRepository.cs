using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Disertatie_backend.Helpers;
using Microsoft.AspNetCore.Identity;
using Disertatie_backend.Configurations;
using Disertatie_backend.Entities.Anime;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Disertatie_backend.DatabaseContext
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private static IMongoCollection<AppUser> _userCollection;

        public UserRepository(DataContext context, IMapper mapper, UserManager<AppUser> userManager, IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _userCollection = mongoDb.GetCollection<AppUser>("Users");

            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            //return await _context.Users
            //    .Where(x => x.UserName == username)
            //    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            //    .SingleOrDefaultAsync();

            var filterByUsername = Builders<AppUser>.Filter.Eq(p => p.UserName, username);
            var user = await _userCollection.Find(filterByUsername).FirstOrDefaultAsync();
            return _mapper.Map<MemberDto>(user);
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();
            //var query = _userCollection.Find(_ => true).ToList().AsQueryable();

            query = query.Where(u => u.UserName != userParams.CurrentUsername);

            if (string.IsNullOrEmpty(userParams.CurrentUsername) || string.IsNullOrWhiteSpace(userParams.CurrentUsername)) return null;

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

        public async Task<AppUser> GetUserByIdAsync(int id)
        { 
            return await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _userCollection.Find(x => x.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
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
