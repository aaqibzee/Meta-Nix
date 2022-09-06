using MaxSync.Client;
using MaxSync.DTOs.Response;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;

namespace MaxSync.DataProviders
{
    public class AdvertiserDataProvider : IAdvertiserDataProvider
    {
        private readonly IConfiguration configuration;
        private string advertiserIndexesUrl;
        private IAPIClient apiClient;
        public AdvertiserDataProvider(IConfiguration configuration, IAPIClient client)
        {
            this.configuration = configuration;
            apiClient = client;
            advertiserIndexesUrl = this.configuration["APIUrls:StageUrl"];
        }

        public void GetAdvertisersIndexes()
        {
            var response = apiClient.GetAPIResponse(advertiserIndexesUrl);
            var advertiserIndexes = DeserializeData(response);
        }


        //TODO can be moved to a common place
        private advertisersContentIndex DeserializeData(string dataXML)
        {
            var xDoc = new XmlDocument();
            xDoc.LoadXml(dataXML);
            var xNodeReader = new XmlNodeReader(xDoc.DocumentElement);
            var xmlSerializer = new XmlSerializer(typeof(advertisersContentIndex));
            var employeeData = xmlSerializer.Deserialize(xNodeReader);
            advertisersContentIndex deserializedEmployee = (advertisersContentIndex)employeeData;
            return deserializedEmployee;
        }
    }
    public interface IAdvertiserDataProvider
    {
        void GetAdvertisersIndexes();
    }
}
