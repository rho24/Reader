using System.Web.Http;
using Reader.Infrastructure;

namespace Reader.Controllers
{
    public class UserActionsController : ApiController
    {
        private readonly NotificationHub _notification;

        public UserActionsController(NotificationHub notification) {
            _notification = notification;
        }


        [HttpPost]
        [ActionName("RefreshFeedPosts")]
        public void RefreshFeedPosts(string id) {
            _notification.Notify("Refreshed {0}".Fmt(id));
        }
    }
}