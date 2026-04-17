using BCrypt.Net;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
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


        Random random = new Random();
        int code = random.Next(100000, 999999);

        int codeValidTime = 5;
        DateTime validUntil = DateTime.UtcNow.AddMinutes(codeValidTime);

        user.TwoFactorSecret = code;
        user.TwoFactorValidDate = validUntil;

        await _context.SaveChangesAsync();

        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress("napelemrendszer2fa@gmail.com", "Napelemrendszer 2FA");

            mail.To.Add(user.Email);
            mail.Subject = "Hitelesítő kód";
            mail.Body = $"A folytatáshoz használja a következő kódot\n({codeValidTime}percig érvényes)\n\n{code}";

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_config["Email:Address"], _config["Email:Password"]);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
        }

        return Ok();
    }

    [HttpPost("verify2fa")]
    public async Task<IActionResult> Verify2FA(TwoFactorRequest request)
    {
        var user = await _context.Felhasznalok
            .FirstOrDefaultAsync(x => x.Nev == request.Nev);

        if (user == null)
            return Unauthorized("Nincs ilyen felhasználó");

        if (user.TwoFactorSecret == 0)
            return Unauthorized("Nem található aktív 2FA kérés");

        if (user.TwoFactorValidDate < DateTime.UtcNow)
            return Unauthorized("A megadott kód lejárt, kérem jelentkezzen be újra");

        if (user.TwoFactorSecret != request.Code)
            return Unauthorized("A megadott kód érvénytelen");

        user.TwoFactorSecret = 0;
        user.TwoFactorValidDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();

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