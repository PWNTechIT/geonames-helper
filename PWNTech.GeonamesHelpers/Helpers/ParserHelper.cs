using CsvHelper;
using CsvHelper.Configuration;
using PWNTech.GeonamesHelpers.Enums;
using PWNTech.GeonamesHelpers.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PWNTech.GeonamesHelpers
{
	public class ParserHelper
	{
		public IEnumerable<GeonamePostalCodeModel> ParseZipCodes(string path)
		{
			// Path.Combine(dataPath, @"ZipCodes", "IT", "IT.txt")
			IList<GeonamePostalCodeModel> ZipCodes = new List<GeonamePostalCodeModel>();

			using var reader = new StreamReader(path);
			using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "\t", BadDataFound = null });
			
			csv.Read();
			//csv.ReadHeader();
			while (csv.Read())
			{
				var record = new GeonamePostalCodeModel
				{
					CountryCode = csv.GetField(0),
					PostalCode = csv.GetField(1),
					PlaceName = csv.GetField(2),
					AdminName1 = csv.GetField(3),
					AdminCode1 = csv.GetField(4),
					AdminName2 = csv.GetField(5),
					AdminCode2 = csv.GetField(6),
					AdminName3 = csv.GetField(7),
					AdminCode3 = csv.GetField(8),
					Latitude = Convert.ToDouble(csv.GetField(9), CultureInfo.InvariantCulture),
					Longitude = Convert.ToDouble(csv.GetField(10), CultureInfo.InvariantCulture),
					Accuracy = (PositionAccuracy)csv.GetField<int>(11)
				};
				ZipCodes.Add(record);
			}

			return ZipCodes;
		}
	}
}
