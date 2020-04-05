using System.Collections.Generic;

namespace PWNTech.GeonamesHelpers
{
	public class Constants
	{
		public const string DumpBaseURL = "https://download.geonames.org/export/dump/";
		public const string DumpBaseZipCodesURL = "https://download.geonames.org/export/zip/";
	}

	public class DemoData
	{
		public double DefaultLatitude { get; set; } = 43.869617299999994d;
		public double DefaultLongitude { get; set; } = 11.0905524d;
	}
}
