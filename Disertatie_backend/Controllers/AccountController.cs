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
using System;
using Disertatie_backend.EmailTemplates;
using System.Linq;
using System.Security.Cryptography;
using Disertatie_backend.Extensions;

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

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var message = new EmailMessage(new string[] { user.Email }, "Confirmation", RecommandationEmailTemplate.GetConfirmationEmailTemplate(user.Id, token));

            await _emailSender.SendHtmlEmailAsync(message, user.UserName);

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

            token = token.Replace(" ", "+");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded) return Ok();

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
            userContentObj.Password = GenerateRandomString(12);

            if (await UserExists(userContentObj.Username)) return BadRequest("Username already exists");

            var user = _mapper.Map<AppUser>(userContentObj);

            user.UserName = userContentObj.Username.ToLower();

            var result = await _userManager.CreateAsync(user, userContentObj.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var message = new EmailMessage(new string[] { user.Email }, "Confirmation", RecommandationEmailTemplate.GetConfirmationEmailWithFacebookTemplate(user.Id, user.UserName, userContentObj.Password, token));
            await _emailSender.SendHtmlEmailAsync(message, user.UserName);

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
        public async Task<IActionResult> SubscribeToNewsletterUser([FromRoute] string username)
        {
            var result = await _userRepository.EnableNewsletterUserAsync(username);

            if (result == false) return BadRequest("The user was not found");

            return Ok();
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
        public async Task<IActionResult> ForgotPassword()
        {
            var userId = User.GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                /*
                 * Fără acel forgotPasswordLink
                 * Aici ceva de genul: To change your password use the link below: "https://4200/pagina-de-schimbat-parola?token=avemToken&email=avemEmail
                 * Și facem o pagina in angular care sa ia din url acele 2 valori, parola o ia din ceva formular si apelam resetPassword cu ele
                 */
                //var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Account", new {token, email = user.Email}, Request.Scheme);

                var message = new EmailMessage(new string[] { user.Email }, "Forgot password link", RecommandationEmailTemplate.GetChangePasswordEmailTemplate(user.Email, token));
                await _emailSender.SendHtmlEmailAsync(message, user.UserName);

                return Ok();
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
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
            {
                resetPassword.Token = resetPassword.Token.Replace(" ", "+");
                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

                if(!resetPasswordResult.Succeeded) 
                {
                    foreach(var error in resetPasswordResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    //return Ok(ModelState);
                }

                return Ok();
            }

            return BadRequest("Could not send the link");
        }

        [HttpDelete("deleteUser/{username}")]
        public async Task DeleteUser([FromRoute] string username)
        {
            await _userRepository.DeleteUser(username);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username) != null;
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email) != null;
        }

        private string GenerateRandomString(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;:',.<>?";
            char[] chars = new char[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    chars[i] = validChars[randomBytes[i] % validChars.Length];
                }
            }

            // Ensure at least one lowercase letter
            if (!chars.Any(char.IsLower))
            {
                int randomIndex = new Random().Next(length);
                chars[randomIndex] = validChars[new Random().Next(26)]; // lowercase letters are from index 0 to 25
            }

            // Ensure at least one uppercase letter
            if (!chars.Any(char.IsUpper))
            {
                int randomIndex = new Random().Next(length);
                chars[randomIndex] = validChars[new Random().Next(26, 52)]; // uppercase letters are from index 26 to 51
            }

            // Ensure at least one number
            if (!chars.Any(char.IsDigit))
            {
                int randomIndex = new Random().Next(length);
                chars[randomIndex] = validChars[new Random().Next(52, 62)]; // numbers are from index 52 to 61
            }

            // Ensure at least one special character
            if (!chars.Any(char.IsSymbol))
            {
                int randomIndex = new Random().Next(length);
                chars[randomIndex] = validChars[new Random().Next(62, validChars.Length)]; // special characters are from index 62 to end
            }

            return new string(chars);
        }
    }
}
