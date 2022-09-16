using Microsoft.Extensions.Configuration;
using System.Text;

namespace MaxSync.Client
{
    internal class APIClient : IAPIClient
    {
        private readonly IConfiguration configuration;
        private string apiUserName;
        private string apiPassword;
        public APIClient(IConfiguration configuration)
        {
            this.configuration = configuration;
            apiUserName = this.configuration["Secrets:StageAPIUserName"];
            apiPassword = this.configuration["Secrets:StageAPIPassword"];

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
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(apiUserName+":"+apiPassword));
        }
    }

    public interface IAPIClient
    {
        string GetAPIResponse(string address);
    }
}