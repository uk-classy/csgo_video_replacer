using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace csvideoreplacer
{
    class Program
    {
        public static string SourceVideoFile = "video.txt";

        public static string SteamFolderLocation = "C:/Program Files (x86)/Steam/userdata";
        static void Main(string[] args)
        {
            if (!File.Exists(SourceVideoFile))
            {
                Console.WriteLine("Couldn't find " + SourceVideoFile + " Error, Press any key to exit..");
                Console.ReadLine();
                Environment.Exit(-1);
            }

            string[] UserDirectories = Directory.GetDirectories(SteamFolderLocation);

            foreach (string Dir in UserDirectories)
            {
                Console.WriteLine(Dir + "/730/local/cfg");
                string OriginalVideoFile = Dir + "/730/local/cfg/video.txt";
                string OldVid = Dir + "/730/local/cfg/video_backup_old.txt";


                if (File.Exists(OriginalVideoFile))
                {
                    if (!File.Exists(OldVid))
                    {
                        File.Copy(OriginalVideoFile, OldVid);
                    }
                  
                    File.Delete(OriginalVideoFile);

                    File.Copy(SourceVideoFile, OriginalVideoFile);
                    
                   // File.Replace(SourceVideoFile, OriginalVideoFile, OldVid);
                    Console.WriteLine("Replaced for " + OriginalVideoFile);
                }
                else
                {
                    Console.WriteLine("Creating " + OriginalVideoFile);
                    File.Copy(SourceVideoFile, OriginalVideoFile);
                }
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
