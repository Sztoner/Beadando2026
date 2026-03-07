using System;

public class LoginRepo : ILoginRepo
{
    string ConnectionString;

    public LoginRepo(DbContext dbContext)
    {
        ConnectionString = dbContext.ConnectionString;
    }
    public async Task<int> bejelentkezes(string name, string password, string role)
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
                        Ketlepcsos = reader.GetBoolean32(2),
                        Secret = reader.GetBoolean32(3),
                    };
                }
            }
            return -1;
        }
    }

