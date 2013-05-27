using System.Collections.Generic;
using System.Linq;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Queries
{
    public class GetUserFeeds : IQuery<IEnumerable<UserFeed>>
    {
        public static IEnumerable<UserFeed> UserFeeds = new[] {
            new UserFeed {
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

        public IEnumerable<UserFeed> Execute() {
            return UserFeeds;
        }
    }
}