using System;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using System.Xml.XPath;
using Raven.Client;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Commands
{
    public class FetchRssFeed : ICommand<string>
    {
        private readonly IDocumentSession _session;

        public FetchRssFeed(IDocumentSession session) {
            _session = session;
        }

        public void Execute(string input) {
            var feedPosts = _session.Load<FeedPosts>("FeedPosts/" + input);

            using (var web = new HttpClient()) {
                var feedData = web.GetStringAsync(feedPosts.Url).Result;

                var xml = XDocument.Parse(feedData);

                var posts = xml.XPathSelectElements("rss/channel/item").Select(e => new Post {
                    Data = e.ToString(),
                    Name = e.TryElementAsString("title"),
                    Url = e.TryElementAsString("link"),
                    Description = e.TryElementAsString("description"),
                    Author = e.TryElementAsString("author"),
                    Guid = e.TryElementAsString("guid"),
                    PublishDate = e.TryElementAsDateTime("pubDate")
                }).ToList();

                feedPosts.Posts.AddRange(posts.Where(newP => feedPosts.Posts.All(p => p.Name != newP.Name)));

                _session.SaveChanges();
            }
        }
    }
}