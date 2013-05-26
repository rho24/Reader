using System.Collections.Generic;
using System.Web.Http;
using Reader.Models;
using Reader.Queries;

namespace Reader.Controllers
{
    public class UserFeedsController : ApiController
    {
        private readonly GetUserFeeds _getUserFeeds;

        public UserFeedsController(GetUserFeeds getUserFeeds) {
            _getUserFeeds = getUserFeeds;
        }

        // GET api/feeds
        public IEnumerable<UserFeed> Get() {
            return _getUserFeeds.Execute();
        }
    }
}