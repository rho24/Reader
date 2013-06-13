using System.Collections.Generic;
using System.Web.Http;
using Reader.Models;
using Reader.Queries;

namespace Reader.ApiControllers
{
    public class PostsController : ApiController
    {
        private readonly GetFeedPosts _getFeedPosts;

        public PostsController(GetFeedPosts getFeedPosts) {
            _getFeedPosts = getFeedPosts;
        }

        public List<Post> Get(string id) {
            return _getFeedPosts.Execute(id).Posts;
        }
    }
}