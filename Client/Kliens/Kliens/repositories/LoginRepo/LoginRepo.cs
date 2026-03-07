using NpgsqlTypes;
using System;
using Kliens.Shared;

public class LoginRepo : ILoginRepo
{
    string ConnectionString;

    public LoginRepo(DbContext dbContext)
    {
        ConnectionString = dbContext.ConnectionString;
    }
    public async Task<LoginBeleptetes> bejelentkezes(string name, string password, string role)
    {
        await using (PgProcedure procedure = new PgProcedure(ConnectionString, "bejelentkezes"))
        {
            procedure.AddParameter("nev", NpgsqlDbType.Text, name);
            procedure.AddParameter("jelszo", NpgsqlDbType.Text, password);
            procedure.AddParameter("szerepkor", NpgsqlDbType.Text, role);

            var reader = await procedure.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                int eredmeny = reader.GetInt32(0);
                if (eredmeny == 0)
                {
                    return new LoginBeleptetes
                    {
                        UserId = reader.GetInt32(1),
                        Ketlepcsos = reader.GetBoolean(2),
                        Secret = reader.GetString(3)
                    };
                }
            }
            return new LoginBeleptetes();
        }
    }

    Task<int> ILoginRepo.bejelentkezes(string name, string password, string role)
    {
        throw new NotImplementedException();
    }
}

