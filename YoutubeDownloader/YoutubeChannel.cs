using System;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace YoutubeDownloader
{
    public class YoutubeChannel
    {
        private string _channelId;
        private List<string> _videoIds;

        public YoutubeChannel(string id)
        {
            _channelId = id;
            _videoIds = RetrieveVideoIds(id);
        }

        private List<string> RetrieveVideoIds(string userId)
        {
            List<string> videoIds = new List<string>();
            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = Secrets.youtubeApi });

            var searchListRequests = yt.Search.List("Snippet");
            searchListRequests.ChannelId = userId;
            searchListRequests.MaxResults = 50;
            searchListRequests.Order = SearchResource.ListRequest.OrderEnum.Date;
            var searchListResult = searchListRequests.Execute();


            foreach (var item in searchListResult.Items)
            {
                videoIds.Add(item.Id.VideoId);
                Console.WriteLine("ID: " + item.Id.VideoId);
                Console.WriteLine("snippet " + item.Snippet.Title);
            }

            return videoIds;
        }
    }
}