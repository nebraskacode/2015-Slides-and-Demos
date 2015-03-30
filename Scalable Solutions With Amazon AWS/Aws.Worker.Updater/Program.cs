using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aws.Core.AwsCallers;
using Aws.Core.Credentials;
using Aws.Worker.Updater.Concrete;
using Aws.Worker.Updater.Model;
using NDesk.Options;

namespace Aws.Worker.Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showHelp = false;
            var instructions = new UpdateInstructions {StartDelay = 1000};

            var p = new OptionSet() {
                { "a|access=", "Required. The Amazon {ACCESS KEY} with permissions to access the S3 bucket",
                    v => instructions.AwsAccessKey = v },
                { "s|secret=", "Required. The Amazon {SECRET KEY} with permissions to access the S3 bucket",
                    v => instructions.AwsSecretKey = v },
                { "b|bucket=", "Required. The Amazon S3 {BUCKET} name containing the files",
                    v => instructions.BucketName = v },
                { "r|remotepath=", "Required. The {REMOTE_PATH} of the update zip file within the S3 bucket",
                    v => instructions.RemotePath = v },
                { "f|folder=", "Required. The local path of the folder containing the application. The ZIPFILE will be extracted here, replacing existing files",
                    v => instructions.Folder = v },
                { "e|exe=", "Required. The local path of the {EXECUTABLE} to launch after completion",
                    v => instructions.ExePath = v },
                { "v|service=", "Optional. Is the exe a TopShelf service? If yes, appends a start argument\nOptions: true or false. Default is false.",
                    (bool v) => instructions.IsService = v },
                { "d|delay=", "Optional. The {DELAY} in millseconds to wait before beginning the update process. Default is 1000.",
                    (int v) => instructions.StartDelay = v },
                { "t|temp=", "Optional. The local path to the {TEMPDIR} in which to store download files\nBy default \\temp in relation to updater will be used",
                    v => instructions.TempDir = v },
                { "u|url=", "Optional. The {URL} to POST errors to",
                   v => instructions.ErrorUrl = v },
                { "h|help",  "show this message and exit", 
                   v => showHelp = v != null },
            };

            try
            {
                p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("There was an error: ");
                Console.WriteLine(e.Message);
                ShowHelp(p);
                return;
            }

            if (showHelp)
            {
                ShowHelp(p);
                return;
            }

            bool success = false;
            try
            {
                Console.WriteLine("Beginning update process");
                Console.Write("Delay is set to {0}ms. Waiting.", instructions.StartDelay);
                Thread.Sleep(instructions.StartDelay);
                Console.WriteLine("Continuing");
                // If temp directory wasn't set by an argument, set it to current folder\Temp
                if (string.IsNullOrWhiteSpace(instructions.TempDir))
                {
                    instructions.TempDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Temp";
                }

                // Make sure the temp directory exists
                Directory.CreateDirectory(instructions.TempDir);

                // Try to delete any files that exist in the directory
                try
                {
                    var dirInfo = new DirectoryInfo(instructions.TempDir);
                    foreach (System.IO.FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }
                catch (Exception)
                {
                    // Do nothing, deleting files isn't really all that important.
                }
                

                Console.WriteLine("Using TempDir: " + instructions.TempDir);

                // Download file to temp dir
                var downloader =
                    new FileDownloader(
                        new S3Caller(new SimpleCredentialsRetriever(instructions.AwsAccessKey, instructions.AwsSecretKey)),
                        instructions.BucketName);

                var srcFilename = instructions.RemotePath;
                string workerFilename = srcFilename;
                if (srcFilename.Contains('/'))
                {
                    workerFilename = srcFilename.Split('/').Last();
                }
                var destFullPath = Path.Combine(instructions.TempDir, workerFilename);

                Console.WriteLine("Downloading file from S3 bucket: " + instructions.BucketName);
                Console.WriteLine("Source file: " + srcFilename);
                Console.WriteLine("Destination: " + destFullPath);
                downloader.DownloadFile(srcFilename, destFullPath);

                // Extract zip to folder, replacing all files
                Console.WriteLine("Download complete. Extracting zip file to: " + instructions.Folder);
                Unzipper.Unzip(destFullPath, instructions.Folder, true);

                // Run the exe
                Console.WriteLine("Update complete. Launching: " + instructions.ExePath);
                success = true;
            }
            catch (Exception ex)
            {
                // TODO: Try to Post error message to url
                Console.WriteLine("THERE WAS AN ERROR!\n" + ex);
            }
            finally
            {
                if (instructions.IsService)
                {
                    Console.WriteLine("Launching as a service by appending the start argument");
                    Process.Start(instructions.ExePath, "start");
                }
                else
                {
                    Process.Start(instructions.ExePath);
                }

                if (success) Console.WriteLine("Success. Exiting.");
            }
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: aws.worker.updater [OPTIONS]");
            Console.WriteLine("Downloads ZIPFILE, deletes the application in FOLDER, and replaces with contents of ZIPFILE. Then runs EXECUTABLE.");
            Console.WriteLine("Optionally outputs error messages by making an Http Post request to URL.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}
