using System.Collections.Generic;
using System.Linq;

namespace PWNTech.GeonamesHelpers.Models
{
	public class SimpleCityModel
	{
		public uint GeonameId { get; set; }

		public string City { get; set; }
		public string Province { get; set; } // $"{CountryCode}.{AdminCode1}.{AdminCode2}" - AdminCode2 - https://download.geonames.org/export/dump/admin2Codes.txt
		public string State { get; set; } // $"{CountryCode}.{AdminCode1}" - AdminCode1 - https://download.geonames.org/export/dump/admin1CodesASCII.txt

		public string CountryCode { get; set; }

		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public List<string> ZipCodes { get; set; }
		public string ZipCode => ZipCodes?.FirstOrDefault();

		public string FeatureClass { get; set; }
		public string FeatureCode { get; set; }

		public ulong? Population { get; set; }

		public string Text => $"{ZipCode} - {City} ({Province})";

		public override int GetHashCode()
		{
			return GeonameId.GetHashCode();
		}
	}
}