using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaxSync.DTOs.Response
{
	[XmlRoot(ElementName = "advertisersContentIndex")]
	public class advertisersContentIndex
	{
		[XmlElement(ElementName = "documentVersion")]
		public string DocumentVersion { get; set; }
		[XmlElement(ElementName = "advertiserIndexEntry")]
		public List<AdvertisersContentIndex> AdvertiserIndexEntries { get; set; }
	}

	[XmlRoot(ElementName = "advertiserIndexEntry")]
	public class AdvertisersContentIndex
	{
		[XmlElement(ElementName = "advertiserAssignedId")]
		public string AdvertiserAssignedId { get; set; }
		[XmlElement(ElementName = "advertiserName")]
		public string AdvertiserName { get; set; }
		[XmlElement(ElementName = "advertiserListingContentIndexUrl")]
		public string AdvertiserListingContentIndexUrl { get; set; }
		[XmlElement(ElementName = "advertiserLodgingConfigurationContentIndexUrl")]
		public string AdvertiserLodgingConfigurationContentIndexUrl { get; set; }
		[XmlElement(ElementName = "advertiserLodgingRateContentIndexUrl")]
		public string AdvertiserLodgingRateContentIndexUrl { get; set; }
		[XmlElement(ElementName = "advertiserUnitAvailabilityContentIndexUrl")]
		public string AdvertiserUnitAvailabilityContentIndexUrl { get; set; }
		[XmlElement(ElementName = "inquiryEmail")]
		public string InquiryEmail { get; set; }
	}
}
