﻿using System.Web.Http;
using Reader.Commands;
using Reader.Models;
using Reader.Queries;

namespace Reader.Controllers
{
    public class FeedPostsController : ApiController
    {
        private readonly FetchRssFeed _fetchRssFeed;
        private readonly GetFeedPosts _getFeedPosts;

        public FeedPostsController(GetFeedPosts getFeedPosts, FetchRssFeed fetchRssFeed) {
            _getFeedPosts = getFeedPosts;
            _fetchRssFeed = fetchRssFeed;
        }

        public FeedPosts Get(string id) {
            _fetchRssFeed.Execute(id);

            return _getFeedPosts.Execute(id);
        }
    }
}