using System;

namespace Reader.Models
{
    public class Post
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Guid { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Data { get; set; }
    }
}