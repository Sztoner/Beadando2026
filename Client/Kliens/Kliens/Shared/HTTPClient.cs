using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.Shared
{
    public static class ApiKliens 
    {
        public static HttpClient Client { get; private set; }
        public static string JwtToken { get; private set; }

        static ApiKliens()
        {
            Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:5127/");

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void SetJWTToken(string token)
        {
            JwtToken = token;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static string GetRoleFromToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(JwtToken);
            var role = token.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value;

            return role;
        }
    }
}
