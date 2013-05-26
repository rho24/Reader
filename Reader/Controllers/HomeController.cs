using System.Collections.Generic;
using System.Web.Mvc;
using Reader.Models;
using Reader.Queries;

namespace Reader.Controllers
{
    public class HomeController : Controller
    {
        private readonly GetUserFeeds _getUserFeeds;

        public HomeController(GetUserFeeds getUserFeeds) {
            _getUserFeeds = getUserFeeds;
        }
        
        //
        // GET: /Home/

        public ActionResult Index() {
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