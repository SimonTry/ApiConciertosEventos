using ApiConciertos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiConciertos.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> Register(string email, string pw, string role)
        {
            // Capturamos los datos de registro e instanciamos un objeto
            // de la clase identity
            var user = new IdentityUser { UserName = email, Email = email };
            var result= await _userManager.CreateAsync(user, pw);
            //validamos que se crea el usuuario
            if (result.Succeeded) { 
                // validamos que el rol a asignar exista
                if(!await _roleManager.RoleExistsAsync(role))
                {
                    // si no existe lo creamos (rol)
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                // si existe el rol lo asignamos al usuario
                await _userManager.AddToRoleAsync(user, role);
            }

            return result;
        }

        public async Task<string?> Login(string email, string pwd)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user != null && await _userManager.CheckPasswordAsync(user, pwd))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return GenerarJwtToken(user, userRoles);

            }

            return null;
        }

        private string GenerarJwtToken(IdentityUser user, IList<string> roles)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authFirmaKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    authFirmaKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
