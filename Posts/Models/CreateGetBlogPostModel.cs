using System;
using System.Collections.Generic;

namespace Posts.Models
{
    public class CreateGetBlogPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Slug { get; set; }
        public List<string> TagList { get; set; }
    }
}
