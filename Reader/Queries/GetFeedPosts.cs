using Raven.Client;
using Reader.Controllers;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Queries
{
    public class GetFeedPosts:IQuery<string, FeedPosts>
    {
        private readonly IDocumentSession _session;

        public GetFeedPosts(IDocumentSession session) {
            _session = session;
        }

        public FeedPosts Execute(string input) {
            return _session.Load<FeedPosts>("FeedPosts/" + input);
        }
    }
}