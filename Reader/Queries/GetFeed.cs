using Reader.Controllers;
using Reader.Infrastructure;
using Reader.Models;

namespace Reader.Queries
{
    public class GetFeed:IQuery<string, Feed>
    {
        public Feed Execute(string input) {
            return new Feed{name=input, posts = new [] {
                new Post{name = "Post 1"},
                new Post{name = "Post 2"},
                new Post{name = "Post 3"},
                new Post{name = "Post 4"},
                new Post{name = "Post 5"}
            }};
        }
    }
}