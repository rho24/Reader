using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Reader.Models;
using Reader.Queries;

namespace Reader.Controllers
{
    public class FeedController : ApiController
    {
        private readonly GetFeed _getFeed;

        public FeedController(GetFeed getFeed) {
            _getFeed = getFeed;
        }

        public Feed Get(string id) {
            return _getFeed.Execute(id);
        }
    }
}
