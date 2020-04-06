using PWNTech.GeonamesHelpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace PWNTech.GeonamesHelpers.Models
{
	public class PostalCodeModel
	{
		[MaxLength(2)] public string CountryCode { get; set; }
		[MaxLength(20)] public string PostalCode { get; set; }
		[MaxLength(180)] public string PlaceName { get; set; }
		[MaxLength(100)] public string AdminName1 { get; set; }
		[MaxLength(20)] public string AdminCode1 { get; set; }
		[MaxLength(100)] public string AdminName2 { get; set; }
		[MaxLength(20)] public string AdminCode2 { get; set; }
		[MaxLength(100)] public string AdminName3 { get; set; }
		[MaxLength(20)] public string AdminCode3 { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public PositionAccuracy Accuracy { get; set; }
	}
}