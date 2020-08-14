using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Posts.Database
{
    public partial class BlogPosts : IEntity
    {
        public BlogPosts()
        {
            BlogPostsTags = new HashSet<BlogPostsTags>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Slug { get; set; }

        [JsonIgnore]
        public virtual ICollection<BlogPostsTags> BlogPostsTags { get; set; }
    }
}
