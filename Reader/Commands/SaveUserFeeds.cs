using System.Collections.Generic;
using Raven.Client;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Commands
{
    public class SaveUserFeeds:ICommand<IEnumerable<UserFeed>>
    {
        private readonly IDocumentSession _session;

        public SaveUserFeeds(IDocumentSession session) {
            _session = session;
        }

        public void Execute(IEnumerable<UserFeed> input) {
            var userInfo = _session.Load<UserInfo>("UserInfos/guest");
            userInfo.userFeeds = input;
            _session.SaveChanges();
        }
    }
}