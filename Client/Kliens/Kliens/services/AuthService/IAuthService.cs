using System;

public interface IAuthService
{
    Task<AktivBejelentkezes> bejelentkezes(string szerepkor, string password);
    Task<AktivBejelentkezes> tokenellenorzes(string token);
    Task kijelentkezes(string token);
}

