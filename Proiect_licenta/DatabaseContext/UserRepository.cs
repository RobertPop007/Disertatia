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
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Z.EntityFramework.Plus;

namespace Disertatie_backend.DatabaseContext
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private static IMongoCollection<AppUser> _userCollection;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string usernameIndex = "Username_index";
        private readonly string idIndex = "Id_index";

        public UserRepository(DataContext context, IMapper mapper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IOptions<DatabaseSettings> databaseSettings)
        {
            _context = context;
            _mapper = mapper;

            _userCollectionHelper = userCollectionHelper;
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            _userCollectionHelper.CreateIndexAscending(u => u.UserName, usernameIndex);
            var filterByUsername = Builders<AppUser>.Filter.Eq(p => p.UserName, username);

            var user = await _userCollection.Find(filterByUsername).FirstOrDefaultAsync();
            var member = _mapper.Map<MemberDto>(user);

            _userCollectionHelper.DropIndex(usernameIndex);
            return member;
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            if (string.IsNullOrEmpty(userParams.CurrentUsername) || string.IsNullOrWhiteSpace(userParams.CurrentUsername)) return null;

            _userCollectionHelper.CreateIndexAscending(u => u.UserName, usernameIndex);
            var filterByUsername = Builders<AppUser>.Filter.Ne(x => x.UserName, userParams.CurrentUsername) &
            Builders<AppUser>.Filter.Where(x => x.UserName.Contains(userParams.SearchedUsername));
            
            var query = _userCollection.Find(filterByUsername).ToEnumerable();

            var queryList = new List<MemberDto>();

            foreach(var document in query)
            {
                queryList.Add(_mapper.Map<MemberDto>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = userParams.OrderBy switch
            {
                "username" => mappedQuery.OrderByDescending(u => u.LastActive).OrderBy(u => u.UserName),
                "newest accounts" => mappedQuery.OrderByDescending(u => u.Created).OrderByDescending(u => u.LastActive),
                _ => mappedQuery.OrderByDescending(u => u.Created)
            };

            _userCollectionHelper.DropIndex(usernameIndex);

            return await PagedList<MemberDto>.CreateAsync(mappedQuery.AsQueryable(),
                userParams.PageNumber, userParams.PageSize);
        }

        public async Task<AppUser> GetUserByIdAsync(ObjectId id)
        {
            var filterById = Builders<AppUser>.Filter.Eq(p => p.Id, id);

            var result = await _userCollection.Find(filterById).FirstOrDefaultAsync();
            return result;
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            _userCollectionHelper.CreateIndexAscending(u => u.UserName, usernameIndex);
            var filterByUsername = Builders<AppUser>.Filter.Eq(p => p.UserName, username);

            var result = await _userCollection.Find(filterByUsername).FirstOrDefaultAsync();
            _userCollectionHelper.DropIndex(usernameIndex);
            return result;
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
