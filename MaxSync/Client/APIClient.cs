using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSync.Client
{
    internal class APIClient
    {
        internal string GetAPIResponse(string _address)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Data Client");
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + GetCredentials());
            HttpResponseMessage response = client.GetAsync(_address).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        private string GetCredentials()
        {
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(""));
        }
    }
}
