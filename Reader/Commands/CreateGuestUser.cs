using Raven.Client;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Commands
{
    public class CreateGuestUser:ICommand
    {
        private readonly IDocumentSession _session;

        public CreateGuestUser(IDocumentSession session) {
            _session = session;
        }

        public void Execute() {
            if(_session.Load<UserInfo>("UserInfos/guest") != null)
                return;

            _session.Store(new UserInfo{name = "Guest", userFeeds = new UserFeed[]{}}, "UserInfos/guest");

            _session.SaveChanges();
        }
    }
}