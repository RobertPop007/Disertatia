using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.DTO;
using Proiect_licenta.Entities;
using Proiect_licenta.Extensions;
using Proiect_licenta.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Proiect_licenta.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly DataContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper, IEmailSender emailSender, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _emailSender = emailSender;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username already exists");

            var user = _mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var message = new EmailMessage(new string[] { user.Email }, "Confirmation", "Your account has been created! Welcome to our community!");
            await _emailSender.SendEmailAsync(message, user.UserName);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                KnownAs = user.KnownAs,
                Gender = user.Gender,
                Email = user.Email
            };
        }

        [HttpPost("newsletter/{username}")]
        public async Task SubscribeToNewsletterUser([FromRoute] string username)
        {
            var user = await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

            user.IsSubscribedToNewsletter = !user.IsSubscribedToNewsletter;

            _context.SaveChanges();
        }

        [HttpPost("darkMode/{username}")]
        public async Task EnableDarkModeForUser([FromRoute] string username)
        {
            var user = await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

            user.HasDarkMode = !user.HasDarkMode;

            _context.SaveChanges();
        }

        [HttpDelete("deleteUser/{username}")]
        public async Task DeleteUser([FromRoute] string username)
        {
            var user = await _context.Users.Where(u => u.UserName == username)
                .IncludeOptimized(o => o.AppUserMovie)
                .IncludeOptimized(o => o.AppUserAnime)
                .IncludeOptimized(o => o.AppUserGame)
                .IncludeOptimized(o => o.AppUserTvShow)
                .IncludeOptimized(o => o.AppUserManga)
                .FirstOrDefaultAsync();

            foreach(var item in _context.AppUserAnimeItems)
            {
                if(item.AppUser == user) _context.AppUserAnimeItems.Remove(item);
            }

            foreach (var item in _context.AppUserGameItems)
            {
                if (item.AppUser == user) _context.AppUserGameItems.Remove(item);
            }

            foreach (var item in _context.AppUserMangaItems)
            {
                if (item.AppUser == user) _context.AppUserMangaItems.Remove(item);
            }

            foreach (var item in _context.AppUserMovieItems)
            {
                if (item.AppUser == user) _context.AppUserMovieItems.Remove(item);
            }

            foreach (var item in _context.AppUserTvShowItems)
            {
                if (item.AppUser == user) _context.AppUserTvShowItems.Remove(item);
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
                if (item.AddedByUser == user || item.AddedUser == user) _context.Friends.Remove(item);
            }

            foreach (var item in _context.Messages)
            {
                if (item.SenderUsername == user.UserName || item.RecipientUsername == user.UserName) _context.Messages.Remove(item);
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .Include(p => p.ProfilePicture)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower()); 

            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                PhotoUrl = user.ProfilePicture?.Url,
                KnownAs = user.KnownAs,
                Gender = user.Gender,
                IsSubscribed = user.IsSubscribedToNewsletter,
                HasDarkMode = user.HasDarkMode,
            };
        }
    }
}
