using AutoMapper;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Repositories;
using Disertatie_backend_Tests.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disertatie_backend_Tests.Repositories_Tests
{
    public class UserRepository_Tests
    {
        private readonly UserRepository _userRepository;
        private readonly Mock<DataContext> _mockContext;
        private readonly IMapper _mapper;
        private readonly AppUser user = UserMockData.ValidUser();

        public UserRepository_Tests()
        {
            var mockUsersSet = new Mock<DbSet<AppUser>>();
            var users = new List<AppUser> { user }.AsQueryable();
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.Provider).Returns(users.Provider);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.Expression).Returns(users.Expression);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            _mockContext = new Mock<DataContext>();
            _mockContext.Setup(c => c.Users).Returns(mockUsersSet.Object);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                    src.Photos.Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                    src.DateOfBirth.CalculateAge())).ReverseMap();
            });
            _mapper = config.CreateMapper();

            _userRepository = new UserRepository(_mockContext.Object, _mapper);
        }

        [Fact]
        public async Task GetUser_PositiveResult()
        {
            var user = await _userRepository.GetMemberAsync("Random Username");

            user.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUsers_PositiveResult()
        {
            var userParams = new UserParams()
            {
                CurrentUsername = "rae",
                OrderBy = "",
                PageNumber = 1,
                PageSize = 3,
                SearchedUsername = ""
            };

            var users = await _userRepository.GetMembersAsync(userParams);

            users.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUserById_PositiveResult()
        {
            var userById = await _userRepository.GetUserByIdAsync(user.Id);

            userById.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUserByUsername_PositiveResult()
        {
            var userByUsername = await _userRepository.GetUserByUsernameAsync(user.UserName);

            userByUsername.Should().NotBeNull();
        }
    }
}
