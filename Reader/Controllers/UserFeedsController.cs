using System.Collections.Generic;
using System.Web.Http;

namespace Reader.Controllers
{
    public class UserFeedsController : ApiController
    {
        // GET api/feeds
        public IEnumerable<UserFeed> Get() {
            return new[] {
                new UserFeed {
                    isGroup = true,
                    name = "Forums",
                    nodes = new[] {
                        new UserFeed {name = "Glimpse"},
                        new UserFeed {name = "Autofac"},
                        new UserFeed {name = "RavenDb2"}
                    }
                },
                new UserFeed {name = "Hanselman"},
                new UserFeed {name = "Haacked"},
                new UserFeed {name = "ScottGu2"}
            };
        }
    }

    #region Nested type: UserFeed

    public class UserFeed
    {
        public bool isGroup { get; set; }

        public string name { get; set; }

        public IEnumerable<UserFeed> nodes { get; set; }
    }

    #endregion
}