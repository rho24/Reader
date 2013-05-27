using System.Collections.Generic;

namespace Reader.Models
{
    public class UserInfo
    {
        public string name { get; set; }
        public IEnumerable<UserFeed> userFeeds { get; set; }
    }
}