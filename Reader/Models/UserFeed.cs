using System.Collections.Generic;

namespace Reader.Models
{
    public class UserFeed
    {
        public bool isGroup { get; set; }

        public string name { get; set; }

        public IEnumerable<UserFeed> nodes { get; set; }
    }
}