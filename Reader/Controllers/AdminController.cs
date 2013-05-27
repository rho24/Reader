using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.XPath;
using Ionic.Zip;
using Reader.Models;
using Reader.Queries;

namespace Reader.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Upload() {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file) {
            if (file.ContentLength > 0) {
                using (var zip = ZipFile.Read(file.InputStream)) {
                    var subsFile = zip.FirstOrDefault(f => Path.GetFileName(f.FileName) == "subscriptions.xml");

                    if (subsFile == null)
                        return View();

                    using (var subsStream = new MemoryStream()) {
                        subsFile.Extract(subsStream);
                        subsStream.Position = 0;

                        var xml = XElement.Load(subsStream);


                        var userFeeds = xml.XPathSelectElements("body/outline").Select(ToUserFeed).ToList();

                        GetUserFeeds.UserFeeds = userFeeds.OrderByDescending(f => f.isGroup).ThenBy(f => f.name);
                    }
                }
            }

            return View();
        }

        private UserFeed ToUserFeed(XElement arg) {
            return new UserFeed {name = arg.Attribute("title").Value, nodes = arg.Elements("outline").Select(ToUserFeed)};
        }
    }
}