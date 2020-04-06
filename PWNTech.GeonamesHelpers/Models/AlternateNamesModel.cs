namespace PWNTech.GeonamesHelpers.Models
{
	public class AlternateNamesModel
	{
		public uint AlternateNameId { get; set; }
		public uint GeonameId { get; set; }
		public string IsoLanguage { get; set; }
		public string AlternateName { get; set; }
		public bool IsPreferredName { get; set; }
		public bool IsShortName { get; set; }
		public bool IsColloquial { get; set; }
		public bool IsHistoric { get; set; }
		public string From { get; set; }
		public string To { get; set; }
	}
}