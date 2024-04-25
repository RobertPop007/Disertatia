using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using Disertatie_backend.Entities.User;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Disertatie_backend.Configurations;
using Newtonsoft.Json;

namespace Disertatie_backend.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IHttpClientFactory _httpClient;
        private readonly FacebookLoginSettings _facebookLoginSettings;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            ITokenService tokenService, 
            IMapper mapper, 
            IEmailSender emailSender, 
            IUserRepository userRepository,
            IHttpClientFactory httpClient,
            FacebookLoginSettings facebookLoginSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _emailSender = emailSender;
            _userRepository = userRepository;
            _httpClient = httpClient;
            _facebookLoginSettings = facebookLoginSettings;
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

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                PhotoUrl = user.Photos?.Url,
                KnownAs = user.KnownAs,
                Gender = user.Gender,
                IsSubscribed = user.IsSubscribedToNewsletter,
                HasDarkMode = user.HasDarkMode,
            };
        }

        [HttpPost("LoginWithFacebook")]
        public async Task<ActionResult<UserDto>> LoginWithFacebook([FromBody] string credential)
        {
            HttpResponseMessage debugTokenResponse = await _httpClient.CreateClient()
                .GetAsync("https://graph.facebook.com/debug_token?input_token=" + credential +
                          $"&access_token={_facebookLoginSettings.FacebookAppId}|{_facebookLoginSettings.FacebookSecret}");

            var stringResult = await debugTokenResponse.Content.ReadAsStringAsync();
            var userObj = JsonConvert.DeserializeObject<FBUser>(stringResult);

            if(userObj.Data.IsValid == false) return Unauthorized();

            HttpResponseMessage meResponse = await _httpClient.CreateClient()
                .GetAsync("https://graph.facebook.com/me?fields=first_name,last_name,email,id&access_token=" + credential);

            var userContent = await meResponse.Content.ReadAsStringAsync();
            var userContentObj = JsonConvert.DeserializeObject<RegisterDto>(userContent);

            if (await UserExists(userContentObj.Username)) return BadRequest("Username already exists");

            var user = _mapper.Map<AppUser>(userContentObj);

            user.UserName = userContentObj.Username.ToLower();

            var result = await _userManager.CreateAsync(user, userContentObj.Password);

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
            var user = await _userManager.FindByNameAsync(username);
            //var user = await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

            user.IsSubscribedToNewsletter = !user.IsSubscribedToNewsletter;

            _context.SaveChanges();
        }

        [HttpPost("darkMode/{username}")]
        public async Task EnableDarkModeForUser([FromRoute] string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            user.HasDarkMode = !user.HasDarkMode;

            _context.SaveChanges();
        }

        [HttpDelete("deleteUser/{username}")]
        public async Task DeleteUser([FromRoute] string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            //foreach (var item in _context.AppUserAnimeItems)
            //{
            //    if(item.AppUser == user) _context.AppUserAnimeItems.Remove(item);
            //}

            //foreach (var item in _context.AppUserGameItems)
            //{
            //    if (item.AppUser == user) _context.AppUserGameItems.Remove(item);
            //}

            //foreach (var item in _context.AppUserMangaItems)
            //{
            //    if (item.AppUser == user) _context.AppUserMangaItems.Remove(item);
            //}

            //foreach (var item in _context.AppUserMovieItems)
            //{
            //    if (item.AppUser == user) _context.AppUserMovieItems.Remove(item);
            //}

            //foreach (var item in _context.AppUserTvShowItems)
            //{
            //    if (item.AppUser == user) _context.AppUserTvShowItems.Remove(item);
            //}

            //foreach (var item in _context.UserRoles)
            //{
            //    if (item.User == user) _context.UserRoles.Remove(item);
            //}

            //foreach (var item in _context.UserLogins)
            //{
            //    if (item.UserId == user.Id) _context.UserLogins.Remove(item);
            //}

            //foreach (var item in _context.UserClaims)
            //{
            //    if (item.UserId == user.Id) _context.UserClaims.Remove(item);
            //}

            //foreach (var item in _context.Friends)
            //{
            //    if (item.AddedByUser == user || item.AddedUser == user) _context.Friends.Remove(item);
            //}

            //foreach (var item in _context.Messages)
            //{
            //    if (item.SenderUsername == user.UserName || item.RecipientUsername == user.UserName) _context.Messages.Remove(item);
            //}

            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username) != null;
        }
    }
}
