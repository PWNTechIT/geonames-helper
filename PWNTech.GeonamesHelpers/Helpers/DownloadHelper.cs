using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PWNTech.GeonamesHelpers
{
	public class DownloadHelper : IDisposable
	{
		private readonly System.Net.WebClient _webClient;
		public DownloadHelper()
		{
			_webClient = new System.Net.WebClient();
		}

		public void Dispose()
		{
			_webClient.Dispose();
		}

		public async Task<string> DownloadToTempFile(string url)
		{
			url = url?.Trim();
			if (string.IsNullOrEmpty(url))
				throw new ArgumentNullException(nameof(url));

			bool isValidUri = Uri.TryCreate(url, UriKind.Absolute, out Uri validatedURI);
			if (!isValidUri) throw new ArgumentException($"URI {url} is not valid");

			string tempFilePath = Path.Combine(Path.GetTempPath(), validatedURI.Segments.LastOrDefault());
			
			await _webClient.DownloadFileTaskAsync(validatedURI, tempFilePath).ConfigureAwait(false);
			
			return tempFilePath;
		}
	}
}
