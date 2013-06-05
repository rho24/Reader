using System;
using System.Collections.Generic;

namespace Reader.Models
{
    public class FeedPosts
    {
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Url { get; set; }

        public List<Post> Posts { get; set; }

        public string Name { get; set; }
    }
}