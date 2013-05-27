using System.Collections.Generic;
using System.Web.Mvc;
using Reader.Commands;
using Reader.Models;
using Reader.Queries;

namespace Reader.Controllers
{
    public class HomeController : Controller
    {
        private readonly GetUserFeeds _getUserFeeds;
        private readonly CreateGuestUser _createGuestUser;

        public HomeController(GetUserFeeds getUserFeeds, CreateGuestUser createGuestUser) {
            _getUserFeeds = getUserFeeds;
            _createGuestUser = createGuestUser;
        }

        //
        // GET: /Home/

        public ActionResult Index() {
            _createGuestUser.Execute();
            return View(new IndexVM{feeds = _getUserFeeds.Execute()});
        }

        #region Nested type: IndexVM

        public class IndexVM
        {
            public IEnumerable<UserFeed> feeds { get; set; }

        }

        #endregion
    }
}