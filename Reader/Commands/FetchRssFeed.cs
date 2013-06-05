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
            var feedPosts = _session.Load<FeedPosts>(input);

            using (var web = new HttpClient()) {
                var feedData = web.GetStringAsync(feedPosts.Url).Result;

                var xml = XDocument.Parse(feedData);

                var posts = xml.XPathSelectElements("").Select(e => new Post {name = e.Attribute("name").Value}).ToList();

                feedPosts.Posts.AddRange(posts.Where(newP => feedPosts.Posts.Any(p => p.name == newP.name)));

                _session.SaveChanges();
            }
        }
    }
}