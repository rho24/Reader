using System.Web.Http;
using Reader.Commands;
using Reader.Infrastructure;

namespace Reader.ApiControllers
{
    public class UserActionsController : ApiController
    {
        private readonly FetchRssFeed _fetchRssFeed;
        private readonly AsyncCommandRunner _runner;

        public UserActionsController(AsyncCommandRunner runner, FetchRssFeed fetchRssFeed) {
            _runner = runner;
            _fetchRssFeed = fetchRssFeed;
        }

        [HttpPost]
        [ActionName("RefreshFeedPosts")]
        public void RefreshFeedPosts(string id) {
            _runner.Execute(_fetchRssFeed, id);
        }
    }
}