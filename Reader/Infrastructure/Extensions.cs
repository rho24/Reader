using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;
using Reader.Models;

namespace Reader.Infrastructure
{
    public static class Extensions
    {
        public static string Fmt(this string s, params object[] args) {
            return string.Format(s, args);
        }

        public static IHtmlString ToJson(this object obj) {
            return MvcHtmlString.Create(JsonConvert.SerializeObject(obj, Formatting.None));
        }

        public static IEnumerable<UserFeed> Flatify(this IEnumerable<UserFeed> feeds) {
            foreach (var userFeed in feeds) {
                yield return userFeed;

                foreach (var innerFeed in userFeed.nodes.Flatify()) yield return innerFeed;
            }
        }

        public static string TryElementAsString(this XElement e, XName name) {
            var element = e.Element(name);
            return element != null ? element.Value : null;
        }

        public static DateTime? TryElementAsDateTime(this XElement e, XName name) {
            var element = e.Element(name);

            if (element == null)
                return null;

            DateTime d;
            return DateTime.TryParse(element.Value, out d) ? (DateTime?) d : null;
        }
    }
}