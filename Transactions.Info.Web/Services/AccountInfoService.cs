using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Transactions.Info.Web.Models;

namespace Transactions.Info.Web.Services
{
    public class AccountInfoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string SERVER_BASE_URL;
        public AccountInfoService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            SERVER_BASE_URL = configuration["ServerBaseUrl"];
        }

        public async Task<ApiResponseModel> GetAccountInfoAsync(string account, string userName, string password)
        {

            ApiResponseModel model = new ApiResponseModel();

            var client = _httpClientFactory.CreateClient();
            Uri uri = new Uri($"{SERVER_BASE_URL}/api/AccountInfo/GetAccountInfo/{account}");
            client.BaseAddress = uri;
            var authenticationString = $"{userName}:{password}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                model.Body = await response.Content.ReadAsStringAsync();
            }
            else
            {
                model.Body = await response.Content.ReadAsStringAsync();
            }
            model.StatusCode = (int)response.StatusCode;

            return model;
        }
    }
}
