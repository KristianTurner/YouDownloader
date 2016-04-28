using System;
using System.IO;
using VideoLibrary;

namespace YoutubeDownloader
{
    public class YoutubeVideoData
    {
        private YouTube _rawYouTube;
        private YouTubeVideo _rawVideo;

        public YoutubeVideoData(string url)
        {
            _rawYouTube = YouTube.Default;
            try
            {
                _rawVideo = _rawYouTube.GetVideo(url);
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool YouTubeToDisk()
        {

            try
            {
                File.WriteAllBytes(@"C:\temp\" + _rawVideo.FullName, _rawVideo.GetBytes());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true; 
        }

        
    }
}