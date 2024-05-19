using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using Disertatie_backend.Entities.User;
using System.Net.Http;
using Disertatie_backend.Configurations;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

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

            if (await EmailExists(registerDto.Email)) return BadRequest("Email already exists");

            var user = _mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            //var confirmationLink = Url.Action("ConfirmEmail", "Account", new {UserId = user.Id, Token = token}, Request.Scheme);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var message = new EmailMessage(new string[] { user.Email }, "Confirmation", $"Your account has been created! Welcome to our community! Use this link to activate your email: {token}");
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
        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(Guid userId, string token)
        {
            if (userId == Guid.Empty || token == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound("The user was not found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded) return Ok("Your account has been confirmed");

            return UnprocessableEntity("Something went wrong");
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
                .GetAsync("https://graph.facebook.com/me?fields=id,name,email,gender,birthday,hometown&access_token=" + credential);

            var userContent = await meResponse.Content.ReadAsStringAsync();
            var userContentObj = JsonConvert.DeserializeObject<RegisterWithFacebookDto>(userContent);

            userContentObj.Username = userContentObj.Username.Replace(" ", "");
            userContentObj.KnownAs = userContentObj.Username;
            userContentObj.Password = "Random_password1!";

            if (await UserExists(userContentObj.Username)) return BadRequest("Username already exists");

            var user = _mapper.Map<AppUser>(userContentObj);

            user.UserName = userContentObj.Username.ToLower();

            var result = await _userManager.CreateAsync(user, userContentObj.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var message = new EmailMessage(new string[] { user.Email }, "Confirmation", $"Your account has been created! Welcome to our community! Please note that your username is: {user.UserName} and your password is: {userContentObj.Password}. You are advised to change your password after you login into your account!");
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

        [HttpPost("forgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                /*
                 * Fără acel forgotPasswordLink
                 * Aici ceva de genul: To change your password use the link below: "https://4200/pagina-de-schimbat-parola?token=avemToken&email=avemEmail
                 * Și facem o pagina in angular care sa ia din url acele 2 valori, parola o ia din ceva formular si apelam resetPassword cu ele
                 */
                var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Account", new {token, email = user.Email}, Request.Scheme);

                var message = new EmailMessage(new string[] { user.Email }, "Forgot password link", forgotPasswordLink);
                await _emailSender.SendEmailAsync(message, user.UserName);

                return Ok("The email was sent, please verify your inbox");
            }

            return BadRequest("The user was not found");
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel{ Token = token, Email = email };

            return Ok(model);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
            {
                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

                if(!resetPasswordResult.Succeeded) 
                {
                    foreach(var error in resetPasswordResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return Ok(ModelState);
                }

                return Ok("Password has been changed");
            }

            return BadRequest("Could not send the link");
        }

        [HttpDelete("deleteUser/{username}")]
        public async Task DeleteUser([FromRoute] string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            foreach (var item in _context.UserAnimes)
            {
                if(item.AppUser == user) _context.UserAnimes.Remove(item);
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

            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username) != null;
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email) != null;
        }
    }
}
