using System.Collections.Generic;
using Reader.Controllers;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Queries
{
    public class GetUserFeeds:IQuery<IEnumerable<UserFeed>>
    {
        public IEnumerable<UserFeed> Execute() {
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
}