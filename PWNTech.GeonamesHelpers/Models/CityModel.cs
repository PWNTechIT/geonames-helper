using System;
using System.ComponentModel.DataAnnotations;

namespace PWNTech.GeonamesHelpers.Models
{
	public class CityModel
	{
		public uint GeonameId { get; set; }
		[MaxLength(200)] public string OriginalName { get; set; }
		[MaxLength(200)] public string Name { get; set; }
		[MaxLength(200)] public string AsciiName { get; set; }
		[MaxLength(10000)] public string AlternateNames { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		[MaxLength(1)] public string FeatureClass { get; set; } // see http://www.geonames.org/export/codes.html, char(1)
		[MaxLength(10)] public string FeatureCode { get; set; } // see http://www.geonames.org/export/codes.html, varchar(10)
		[MaxLength(2)] public string CountryCode { get; set; } // ISO-3166 2-letter country code, 2 characters
		[MaxLength(200)] public string CC2 { get; set; } //alternate country codes, comma separated, ISO-3166 2-letter country code, 200 characters
		[MaxLength(20)] public string AdminCode1 { get; set; } //fipscode (subject to change to iso code), see exceptions below, see file admin1Codes.txt for display names of this code; varchar(20)
		[MaxLength(80)] public string AdminCode2 { get; set; } // code for the second administrative division, a county in the US, see file admin2Codes.txt; varchar(80)
		[MaxLength(20)] public string AdminCode3 { get; set; } //code for third level administrative division, varchar(20)
		[MaxLength(20)] public string AdminCode4 { get; set; } //code for fourth level administrative division, varchar(20)
		public ulong? Population { get; set; } // bigint(8 byte int)
		public string Elevation { get; set; } // in meters, integer
		public string DEM { get; set; } // digital elevation model, srtm3 or gtopo30, average elevation of 3''x3'' (ca 90mx90m) or 30''x30'' (ca 900mx900m) area in meters, integer.srtm processed by cgiar/ciat.
		[MaxLength(40)] public string TimeZone { get; set; } // the iana timezone id(see file timeZone.txt) varchar(40)
		public DateTimeOffset ModificationDate { get; set; } // date of last modification in yyyy-MM-dd format

		public bool IsProvince { get; set; } = false;
	}
}