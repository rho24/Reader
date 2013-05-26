using System.Collections.Generic;

namespace Reader.Models
{
    public class Feed
    {
        public string name { get; set; }
        public IEnumerable<Post> posts { get; set; }
    }
}