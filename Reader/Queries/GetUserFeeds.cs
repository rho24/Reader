using System.Collections.Generic;
using Raven.Client;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Queries
{
    public class GetUserFeeds : IQuery<IEnumerable<UserFeed>>
    {
        private readonly IDocumentSession _session;

        public GetUserFeeds(IDocumentSession session) {
            _session = session;
        }

        public IEnumerable<UserFeed> Execute() {
            var userInfo = _session.Load<UserInfo>("UserInfos/guest");

            return userInfo.userFeeds;
        }
    }
}