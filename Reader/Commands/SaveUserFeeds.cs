using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Raven.Client.Linq;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Commands
{
    public class SaveUserFeeds : ICommand<IEnumerable<UserFeed>>
    {
        private readonly IDocumentSession _session;

        public SaveUserFeeds(IDocumentSession session) {
            _session = session;
        }

        public void Execute(IEnumerable<UserFeed> input) {

            var flatFeeds = input.Flatify().Where(f => !f.isGroup).ToList();

            var existingFeedPosts = _session.Query<FeedPosts>().Where(p => p.Url.In(flatFeeds.Select(i => i.url).ToList())).ToList();

            foreach (var userFeed in flatFeeds) {
                var feedPosts = existingFeedPosts.SingleOrDefault(p => p.Url == userFeed.url);
                if (feedPosts == null) {
                    feedPosts = new FeedPosts {Id = userFeed.feedPostsId, CreatedDate = DateTime.UtcNow, Name = userFeed.name, Url = userFeed.url, Posts = new List<Post>()};
                    _session.Store(feedPosts);
                }
                userFeed.feedPostsId = feedPosts.Id;
            }
            
            var userInfo = _session.Load<UserInfo>("UserInfos/guest");
            userInfo.userFeeds = input;

            _session.SaveChanges();
        }
    }
}