using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Posts.Database
{
    public partial class Tags : IEntity
    {
        public Tags()
        {
            BlogPostsTags = new HashSet<BlogPostsTags>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }

        [JsonIgnore]
        public virtual ICollection<BlogPostsTags> BlogPostsTags { get; set; }
    }
}
