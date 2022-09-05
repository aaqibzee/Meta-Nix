using Microsoft.Extensions.Configuration;
using System.Text;

namespace MaxSync.Client
{
    internal class APIClient : IAPIClient
    {
        private readonly IConfiguration _configuration;
        private string _apiUserName;
        private string _apiPassword;
        public APIClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUserName = _configuration["Secrets:StageAPIUserName"];
            _apiPassword = _configuration["Secrets:StageAPIPassword"];

        }
        public string GetAPIResponse(string address)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Data Client");
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + GetCredentials());
            HttpResponseMessage response = client.GetAsync(address).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        private string GetCredentials()
        {
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(_apiUserName+":"+_apiPassword));
        }
    }

    public interface IAPIClient
    {
        string GetAPIResponse(string address);
    }
}