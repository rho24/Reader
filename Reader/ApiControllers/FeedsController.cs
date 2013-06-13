using System.Web.Http;
using Reader.Models;
using Reader.Queries;

namespace Reader.ApiControllers
{
    public class FeedsController : ApiController
    {
        private readonly GetFeedPosts _getFeedPosts;

        public FeedsController(GetFeedPosts getFeedPosts) {
            _getFeedPosts = getFeedPosts;
        }

        public FeedPosts Get(string id) {
            return _getFeedPosts.Execute(id);
        }
    }
}