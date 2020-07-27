using System;
using System.IO;
using StormLibSharp;

namespace mpq_packer
{
    class Program
    {
        private static void Help()
        {
            Console.WriteLine("You must provide firstly a full path to the folder you're packing. Then the MPQ you're creating.");

            Console.WriteLine("Eg mpq-edit.exe \"C:\\Users\\you\\Desktop\\folder\" \"C:\\Users\\you\\Desktop\\Patch-G.MPQ\"");
        }

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

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Help();

                System.Environment.Exit(0);
            }

            string folder = args[0];
            string mpqPath = args[1];

            string[] files = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);

            Console.WriteLine("Writing files from '{0}' to '{1}'...", folder, mpqPath);

            if (File.Exists(mpqPath))
            {
                File.Delete(mpqPath);
            }

            using (MpqArchive mpq = MpqArchive.CreateNew(mpqPath, MpqArchiveVersion.Version2, MpqFileStreamAttributes.None, MpqFileStreamAttributes.CreateAttributesFile, files.Length))
            {
                foreach (string file in files)
                {
                    string innerPath = After(file, folder);
                    innerPath = innerPath.Substring(1);

                    mpq.AddFileFromDiskWithCompression(file, innerPath, MpqCompressionTypeFlags.MPQ_COMPRESSION_ZLIB);
                }
            }
        }
    }
}
