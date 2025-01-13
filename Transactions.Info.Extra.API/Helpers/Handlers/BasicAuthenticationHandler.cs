using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Transactions.Info.Infrastructure.Data.DBContexts;

namespace Transactions.Info.Extra.API.Helpers.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AccountInfoDbContext _dbContext;
        public BasicAuthenticationHandler(AccountInfoDbContext dbContext, IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _dbContext = dbContext;
        }


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username = null;
            try
            {
                AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                string[] credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                username = credentials.FirstOrDefault();
                string password = credentials.LastOrDefault();

                var dbResult =  _dbContext.Logins.SingleOrDefault(t => t.UserName == username && t.Password == password);
                if(dbResult == null) { throw new ArgumentException("Invalid credentials"); }

            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication Failed: {ex.Message}");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
