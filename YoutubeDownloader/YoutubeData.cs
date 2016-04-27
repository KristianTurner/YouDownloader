using System;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace YoutubeDownloader
{
    public class YoutubeData
    {
        private string _title;
        private uint _lengthSeconds;
        private string _url;
        private YoutubeAudioData _audio;
        private YoutubeVideoData _video;

        public YoutubeData(string videoUrl)
        {
            _url = videoUrl;
            //_video  = new YoutubeVideoData(_url);
            
        }

        
    }
}