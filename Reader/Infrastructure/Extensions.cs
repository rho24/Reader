using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Reader.Models;

namespace Reader.Infrastructure
{
    public static class Extensions
    {
        public static IHtmlString ToJson(this object obj) {
            return MvcHtmlString.Create(JsonConvert.SerializeObject(obj, Formatting.None));
        }

        public static IEnumerable<UserFeed> Flatify(this IEnumerable<UserFeed> feeds) {
            foreach (var userFeed in feeds) {
                yield return userFeed;

                foreach (var innerFeed in userFeed.nodes.Flatify()) yield return innerFeed;
            }
        }
    }
}