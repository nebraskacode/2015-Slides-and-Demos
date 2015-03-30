using System;
using System.IO;
using System.IO.Compression;

namespace Aws.Worker.Updater.Concrete
{
    public class Unzipper
    {
        public static void Unzip(string zipfilePath, string extractPath, bool overwrite)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipfilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(extractPath, entry.FullName), overwrite);
                }
            }
        }
    }
}