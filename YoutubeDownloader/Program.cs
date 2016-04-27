using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Youtube Channel ID: [Kitty]");
                var input = Console.ReadLine();
                if (input == "")
                {
                    input = "UC6duv54jElkzAiQHCBfEjow";
                }
                var channelInfo = new YoutubeChannel(input);
                Console.WriteLine("Listing 50 newest videos:");
                channelInfo.DisplayVideoNames();

                Console.WriteLine("Download newest video?");
                var readLine = Console.ReadLine();
                if (readLine != null) input = readLine.ToLower();

                if (input == "y")
                {
                    var downloadVideo = new YoutubeVideoData(channelInfo.NewestVideoId());
                    downloadVideo.YouTubeToDisk();
                } 

                
                //var testFilm = new YoutubeData(@"https://www.youtube.com/watch?v=GLSPub4ydiM");
            }
            catch (Exception)
            {
                Console.WriteLine( "Something went wrong");
            }

            Console.WriteLine("Press any key;");
            Console.Read();

        }
    }
}
