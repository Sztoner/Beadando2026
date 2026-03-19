using System;

public interface ILoginRepo
{

    Task<int> bejelentkezes(string name, string password, string role);
}