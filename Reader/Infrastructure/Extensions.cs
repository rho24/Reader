using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Reader.Infrastructure
{
    public static class Extensions
    {
        public static IHtmlString ToJson(this object obj) {
            return MvcHtmlString.Create(JsonConvert.SerializeObject(obj, Formatting.None));
        }
    }
}