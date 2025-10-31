using CollageWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollageWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CollageDbContext _context;

        public AuthController(IConfiguration configuration, CollageDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            var member = _context.Members
                .FirstOrDefault(m => m.Username == user.Username && m.Password == user.Password);

            if (member == null)
                return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(member.Username, member.Role);
            return Ok(new { token, role = member.Role });
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Member user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Username and password are required.");

            var existingUser = await _context.Members.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
                return Conflict("Username already exists.");

            // Default role (optional)
            if (string.IsNullOrEmpty(user.Role))
                user.Role = "Student";

            _context.Members.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully!");
        }

        // JWT GENERATOR
        private string GenerateJwtToken(string username, string role)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
