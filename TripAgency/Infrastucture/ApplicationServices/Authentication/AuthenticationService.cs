using Application.DTOs.Authentication;
using Application.IApplicationServices.Authentication;
using Application.IReositosy;
using Domain.Entities.ApplicationEntities;
using Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationServices.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAppRepository<Customer> _customerRepository;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAppRepository<Customer> customerRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerRepository = customerRepository;
        }
        public async Task<SignInResult> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(loginDto.Email);
                if (existingUser == null)
                    throw new Exception("email or password not correct");

                var isLockout = await _userManager.IsLockedOutAsync(existingUser);
                if (isLockout)
                {
                    var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(existingUser);
                    if (lockoutEndDate.HasValue && lockoutEndDate > DateTimeOffset.UtcNow)
                    {
                        var remainingTime = lockoutEndDate.Value - DateTimeOffset.UtcNow;
                        var remainingMinutes = (int)remainingTime.TotalMinutes;
                        if (remainingMinutes == 0)
                            remainingMinutes = 1;
                        var ex = new Exception("Account locked. Remaining lockout time: {0} " + $"{(remainingMinutes == 1 ? "minute." : "minutes.")}");
                        throw ex;
                    }

                    throw new Exception("User Locked");
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, loginDto.Password);
                if (!isCorrect)
                {
                    if (_userManager.SupportsUserLockout && _userManager.GetLockoutEnabledAsync(existingUser).Result)
                        await _userManager.AccessFailedAsync(existingUser);

                    throw new Exception("email or password not correct");
                }

                if (!existingUser.EmailConfirmed)
                {
                    var ex = new Exception("Unconfirmed Email");
                    throw ex;
                }

                if (!existingUser.IsActive) throw new Exception("Deactivated User");

                var jwtToken = await GenerateJwtToken(existingUser, LoginProvider.Email);

                if (_userManager.SupportsUserLockout && _userManager.GetAccessFailedCountAsync(existingUser).Result > 0)
                    await _userManager.ResetAccessFailedCountAsync(existingUser);

                return jwtToken;
            }
            catch
            {
                throw;
            }
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            throw new NotImplementedException();
        }

        private async Task<TokenDto> GenerateJwtToken(ApplicationUser user, LoginProvider loginProvider)
        {
            try
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(JwtConfig.Secret);
                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.Email ?? string.Empty)
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = JwtConfig.Audience,
                    Issuer = JwtConfig.Issuer,
                    IssuedAt = DateTime.UtcNow,
                    Subject = new ClaimsIdentity(
                        claims.ToArray()),
                    Expires = JwtConfig.ExpiryInMinutes == 0 ? DateTime.UtcNow.AddYears(100) : DateTime.UtcNow.AddMinutes(JwtConfig.ExpiryInMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = jwtTokenHandler.WriteToken(token);
                var refreshToken = Helper.Helper.RandomString(35) + Guid.NewGuid();
                user.RefreshToken = refreshToken;
                await _userRepository.UpdateAsync(user);

                var mainRole = userRoles.FirstOrDefault();

                return new TokenDto()
                {
                    Token = jwtToken,
                    Success = true,
                    RefreshToken = refreshToken,
                    Provider = loginProvider.ToString(),
                    UserRoles = userRoles,
                    MainRole = mainRole
                };
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
