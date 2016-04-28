using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace YoutubeDownloader
{
    public class YoutubeMovie
    {
        public string _title;
        public uint _lengthSeconds;
        private readonly string _url;
        public string Url
        {
            get
            {
                return @"http://youtube.com/watch?=" + _url;
            }
        }

        private YoutubeVideoData _video;

        public YoutubeMovie(string videoUrl)
        {
            _url = videoUrl;
            _video  = new YoutubeVideoData(_url);
            
        }


    }
}