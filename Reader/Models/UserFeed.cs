using System.Collections.Generic;
using System.Linq;

namespace Reader.Models
{
    public class UserFeed
    {
        public bool isGroup {
            get { return nodes != null && nodes.Any(); }
        }

        public string name { get; set; }

        public IEnumerable<UserFeed> nodes { get; set; }

        public string feedPostsId { get; set; }

        public string url { get; set; }
    }
}