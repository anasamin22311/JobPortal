using JobPortal.Application.DataAccess.Interfaces.Auth;
using JobPortal.Domain;
using JobPortal.Domain.Auth;
using JobPortal.Domain.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobPortal.Application.DataAccess.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public static void AddIdentityServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });


            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
                options.SlidingExpiration = true;
                //options.LoginPath = "/Account/Login";
                //options.LogoutPath = "/Account/Logout";
                //options.AccessDeniedPath = "/Account/AccessDenied";
            });
        }
        public async Task<AuthModel> SignUpAsync(SignUpModel signUpModel)
        {
            var existingUserByEmail = await _userManager.FindByEmailAsync(signUpModel.Email);
            var existingUserByName = await _userManager.FindByNameAsync(signUpModel.UserName);
            if (existingUserByEmail != null || existingUserByName != null)
            {
                return new AuthModel
                {
                    IsAuthenticated = false,
                    Message = "Email or username already exists",
                };
            }

            var user = new User { UserName = signUpModel.UserName, Email = signUpModel.Email };
            var result = await _userManager.CreateAsync(user, signUpModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                return new AuthModel
                {
                    IsAuthenticated = true,
                    Message = "User created successfully!",
                    Username = user.UserName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user),
                    Token = await GenerateJwtTokenAsync(user),
                    ExpiresOn = DateTime.Now.AddHours(2)
                };
            }

            return new AuthModel
            {
                IsAuthenticated = false,
                Message = "Failed to create user",
            };
        }


        public async Task<AuthModel> LoginAsync(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginModel.Email);

                return new AuthModel
                {
                    IsAuthenticated = true,
                    Message = "Login successful",
                    Username = user.UserName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user),
                    Token = await GenerateJwtTokenAsync(user),
                    ExpiresOn = DateTime.Now.AddHours(2)
                };
            }

            return new AuthModel
            {
                IsAuthenticated = false,
                Message = "Invalid login attempt",
            };
        }

        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[nameof(JWT.Key)]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(2);

            // we can add more claims as needed
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                _configuration[nameof(JWT.Issuer)],
                _configuration[nameof(JWT.Audience)],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
