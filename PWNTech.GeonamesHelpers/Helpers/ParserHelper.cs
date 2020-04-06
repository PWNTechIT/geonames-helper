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
		public IEnumerable<PostalCodeModel> ParseZipCodes(string path)
		{
			// Path.Combine(dataPath, @"ZipCodes", "IT", "IT.txt")
			IList<PostalCodeModel> ZipCodes = new List<PostalCodeModel>();

			using var reader = new StreamReader(path);
			using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "\t", BadDataFound = null });
			
			csv.Read();
			//csv.ReadHeader();
			while (csv.Read())
			{
				var record = new PostalCodeModel
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

		public IEnumerable<CityModel> ParseCities(string path)
		{
			IList<CityModel> Cities = new List<CityModel>();

			// Path.Combine(dataPath, @"Cities", "IT", "IT.txt")
			using (var reader = new StreamReader(path))
			using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "\t", BadDataFound = null }))
			{
				csv.Read();
				//csv.ReadHeader();
				while (csv.Read())
				{
					var record = new CityModel
					{
						GeonameId = csv.GetField<uint>(0),
						OriginalName = csv.GetField(1),
						Name = csv.GetField(1),
						AsciiName = csv.GetField(2),
						AlternateNames = csv.GetField(3),
						Latitude = Convert.ToDouble(csv.GetField(4), CultureInfo.InvariantCulture),
						Longitude = Convert.ToDouble(csv.GetField(5), CultureInfo.InvariantCulture),
						FeatureClass = csv.GetField(6),
						FeatureCode = csv.GetField(7),
						CountryCode = csv.GetField(8),
						CC2 = csv.GetField(9),
						AdminCode1 = csv.GetField(10),
						AdminCode2 = csv.GetField(11),
						AdminCode3 = csv.GetField(12),
						AdminCode4 = csv.GetField(13),
						Population = csv.GetField<ulong?>(14),
						Elevation = csv.GetField(15),
						DEM = csv.GetField(16),
						TimeZone = csv.GetField(17),
						ModificationDate = DateTimeOffset.ParseExact(csv.GetField(18), "yyyy-MM-dd", CultureInfo.InvariantCulture),
					};

					//record.Name = AlternateNames
					//	.FirstOrDefault(x => x.GeonameId == record.GeonameId && x.IsoLanguage.Equals("IT", StringComparison.OrdinalIgnoreCase))
					//	?.AlternateName;

					if (record.FeatureCode == "ADM2")
					{
						if (record.Name.Contains("Provincia di ", StringComparison.Ordinal)
							|| record.Name.Contains("Provincia del ", StringComparison.Ordinal)
							|| record.Name.Contains("Provincia ", StringComparison.Ordinal)
							|| record.Name.Contains("Province of ", StringComparison.Ordinal)
							|| record.Name.Contains("Provincia dell' ", StringComparison.Ordinal))
							record.IsProvince = true;

						record.Name = record.Name
							.Replace("Provincia di ", string.Empty, StringComparison.Ordinal)
							.Replace("Provincia del ", string.Empty, StringComparison.Ordinal)
							.Replace("Provincia ", string.Empty, StringComparison.Ordinal)
							.Replace("Provincia dell' ", string.Empty, StringComparison.Ordinal)
							.Replace("Province of ", string.Empty, StringComparison.Ordinal);

						record.AsciiName = record.AsciiName
							.Replace("Provincia di ", string.Empty, StringComparison.Ordinal)
							.Replace("Provincia del ", string.Empty, StringComparison.Ordinal)
							.Replace("Provincia ", string.Empty, StringComparison.Ordinal)
							.Replace("Provincia dell' ", string.Empty, StringComparison.Ordinal)
							.Replace("Province of ", string.Empty, StringComparison.Ordinal);
					}

					if (record.Name == "Rome")
					{
						record.Name = "Roma";
						record.AsciiName = "Roma";
					}

					if (record.Name == "Genoa")
					{
						record.Name = "Genova";
						record.AsciiName = "Genova";
					}


					Cities.Add(record);
				}
			}

			return Cities;
		}
	}
}
