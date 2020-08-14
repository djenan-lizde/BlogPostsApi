using Posts.Database;
using System.Collections.Generic;

namespace Posts.Models
{
    public class BlogPostsModel
    {
        public List<BlogPosts> Posts { get; set; }
        public int PostsCount { get; set; }
    }
}
