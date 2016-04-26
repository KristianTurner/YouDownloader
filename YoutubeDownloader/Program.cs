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
                var testFilm = new YoutubeData(@"https://www.youtube.com/watch?v=GLSPub4ydiM");
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
