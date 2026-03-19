using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;

public class AuthService : IAuthService
{

    ConcurrentDictionary<string, AktivBejelentkezes> tokenek;
    ILoginRepo loginRepo;
    public AuthService(ILoginRepo loginRepo)
    {
        this.loginRepo = loginRepo;
        tokenek = new();
    }
    public async Task<AktivBejelentkezes> bejelentkezes(string name, string password, string role)
    {
        int felhasznalo_id = await loginRepo.bejelentkezes(name, password, role);
        if (felhasznalo_id == -1)
        {
            return null;
        }

        string token = tokengeneralas();
        AktivBejelentkezes bejelentkezes = new AktivBejelentkezes
        {
            felhasznalo_id = felhasznalo_id,
            ervenyesseg = DateTime.UtcNow.AddDays(1),
            token = token,
        };

        tokenek.TryAdd(token, bejelentkezes);
        return bejelentkezes;
    }

    public async Task<AktivBejelentkezes> tokenellenorzes(string token)
    {
        if (tokenek.TryGetValue(token, out var bejelentkezes))
        {
            return bejelentkezes;
        }
        return null;
    }

    public Task kijelentkezes(string token)
        {
        tokenek.Remove(token, out _);
        return Task.CompletedTask;
    }

    string tokengeneralas()
        {
        byte[] token = new byte[16];
        RandomNumberGenerator.Fill(token);
        return new Guid(token).ToString();
    }

    public Task<AktivBejelentkezes> bejelentkezes(string szerepkor, string password)
    {
        throw new NotImplementedException();
    }
}

