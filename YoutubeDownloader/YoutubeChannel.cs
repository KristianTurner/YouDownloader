using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace YoutubeDownloader
{
    public class YoutubeChannel
    {
        private string _channelId;
        private static Dictionary<string, string> _videos;
        private static List<YoutubeMovie> VideoInfo;

        public YoutubeChannel(string id)
        {
            _channelId = id;
            _videos = RetrieveVideoIds(_channelId);

            foreach (var video in _videos)
            {
                VideoInfo.Add(new YoutubeMovie(video.Key));
            }
        }

        private static Dictionary<string, string> RetrieveVideoIds(string userId)
        {
            try
            {
                var yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = Secrets.YoutubeApi });

                var searchListRequests = yt.Search.List("Snippet");
                searchListRequests.ChannelId = userId;
                searchListRequests.MaxResults = 50;
                searchListRequests.Order = SearchResource.ListRequest.OrderEnum.Date;
                var searchListResult = searchListRequests.Execute();

                _videos = searchListResult.Items.ToDictionary(i => i.Id.VideoId, i => i.Snippet.Title);
                return _videos;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public void DisplayVideoNames()
        {
            foreach (var video in _videos)
            {
                Console.WriteLine(video.Key + ": " +video.Value);
            }
            Console.WriteLine();
        }

        public string NewestVideoId()
        {
            return @"https://www.youtube.com/watch?v=" + _videos.Keys.First();
        }
    }
}