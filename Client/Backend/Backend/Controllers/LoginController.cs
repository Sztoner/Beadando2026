using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly PostgreDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(PostgreDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("hashpw")]
    public IActionResult HashPw([FromBody] string pw)
    {
       return Ok(BCrypt.Net.BCrypt.HashPassword(pw));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _context.Felhasznalok
            .FirstOrDefaultAsync(x => x.Nev == request.Nev);

        if (user == null)
            return Unauthorized();

        if (!BCrypt.Net.BCrypt.Verify(request.Jelszo, user.JelszoHash))
            return Unauthorized();

        var token = GenerateJwtToken(user);

        return Ok(new { token });
    }

    private string GenerateJwtToken(FelhasznaloAdatok user)
    {
        var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Nev),
            new Claim(ClaimTypes.Role, user.Szerepkor)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}