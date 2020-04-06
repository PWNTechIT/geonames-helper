using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PWNTech.GeonamesHelpers.Test
{
	[TestClass]
	public class UnitTest1
	{
		private TestContext testContextInstance;

		/// <summary>
		///  Gets or sets the test context which provides
		///  information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get { return testContextInstance; }
			set { testContextInstance = value; }
		}

		[TestMethod]
		public void TestDownload()
		{
			using var downloadHelper = new DownloadHelper();
			var response = downloadHelper.DownloadToTempFile($"{Constants.DumpBaseURL}IT.zip").ConfigureAwait(false).GetAwaiter().GetResult();
			TestContext.WriteLine($"Temp file: {response}");

			Assert.IsTrue(!string.IsNullOrWhiteSpace(response)); // Ensure file path been returned
			Assert.IsTrue(File.Exists(response)); // Ensure file exists
			Assert.IsTrue(new FileInfo(response).Length > 0); // Ensure file has size grater than 0
		}
	}
}
