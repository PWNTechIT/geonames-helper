using System;
using System.IO;
using System.IO.Compression;

namespace PWNTech.GeonamesHelpers
{
	public class ArchiveHelper
	{
		public string[] UnzipFile(string sourcePath)
		{
			sourcePath = sourcePath?.Trim();

			if (string.IsNullOrEmpty(sourcePath))
				throw new ArgumentNullException(nameof(sourcePath));

			if (!File.Exists(sourcePath))
				throw new FileNotFoundException("File provided does not exists", sourcePath);

			if (Path.GetExtension(sourcePath).ToLowerInvariant() != ".zip")
				throw new NotSupportedException("Only .zip files are supported");

			string archiveName = Path.GetFileNameWithoutExtension(sourcePath);
			string tempPath = Path.Combine(Path.GetTempPath(), archiveName);
			Directory.CreateDirectory(tempPath);
			ZipFile.ExtractToDirectory(sourcePath, tempPath);

			return Directory.GetFiles(tempPath);
		}
	}
}
