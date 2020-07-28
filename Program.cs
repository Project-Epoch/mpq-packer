using System;
using System.IO;
using StormLibSharp;

namespace mpq_packer
{
    class Program
    {
        /// <summary>
        /// Print the Help Menu.
        /// </summary>
        private static void Help()
        {
            Logger.Warning("You must provide firstly a full path to the folder you're packing. Then the MPQ you're creating.\n");

            Logger.Warning("Eg mpq-edit.exe \"C:\\Users\\you\\Desktop\\folder\" \"C:\\Users\\you\\Desktop\\Patch-G.MPQ\"\n");
        }

        /// <summary>
        /// Get the contents of abstract string after the other string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private static string After(string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }

        /// <summary>
        /// Actually run the App.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Help();

                System.Environment.Exit(0);
            }

            string folder = args[0];
            string mpqPath = args[1];

            if (! Directory.Exists(folder)) {
                Logger.Danger("Could not find specified folder '" + folder + "'. Please ensure this exists!");

                System.Environment.Exit(0);
            }

            string[] files = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);

            int total = files.Length;

            Logger.Info(String.Format("Writing ({0}) files from '{1}' to '{2}'...\n", total, folder, mpqPath));

            if (File.Exists(mpqPath))
            {
                File.Delete(mpqPath);
            }

            ProgressBar progress = new ProgressBar(60);

            int current = 1;

            using (MpqArchive mpq = MpqArchive.CreateNew(mpqPath, MpqArchiveVersion.Version2, MpqFileStreamAttributes.None, MpqFileStreamAttributes.CreateAttributesFile, files.Length))
            {
                foreach (string file in files)
                {
                    string innerPath = After(file, folder);
                    innerPath = innerPath.Substring(1); // Get rid of leading slash.

                    mpq.AddFileFromDiskWithCompression(file, innerPath, MpqCompressionTypeFlags.MPQ_COMPRESSION_ZLIB);

                    int percentage = (current / total) * 100;

                    progress.Update(percentage);

                    current++;
                }
            }

            Logger.Success("\n\nDone!\n");
        }
    }
}
