using System;
using System.Reflection;
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
            _video  = new YoutubeVideoData(_url);
        }

        private string RetrieveVideoIds(string userId)
        {
            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "AIzaSyCVSgK3ufR2w-oGageQ6N90BAN4PTJTeZw" });

            var searchListRequests = yt.Search.List("Snippet");
            searchListRequests.ChannelId = userId;
            var searchListResult = searchListRequests.Execute();

            foreach (var item in searchListResult.Items)
            {
                Console.WriteLine("ID: " + item.Id.VideoId);
                Console.WriteLine("snippet " + item.Snippet.Title);
            }

            return " ";
        }
    }
}