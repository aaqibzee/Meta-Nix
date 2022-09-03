using MaxSync.Client;
using MaxSync.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MaxSync.DataProviders
{
    public class AdvertiserDataProvider : IAdvertiserDataProvider
    {

        string advertiserIndexesUrl = @"";
        private APIClient _apiClient;
        public AdvertiserDataProvider()
        {
            _apiClient = new APIClient();
        }
        public void GetAdvertisersIndexes()
        {
            var response = DeserializeData(_apiClient.GetAPIResponse(advertiserIndexesUrl));
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
}
