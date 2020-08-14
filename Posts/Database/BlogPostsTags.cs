using System.Text.Json.Serialization;

namespace Posts.Database
{
    public partial class BlogPostsTags : IEntity
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int BlogPostsId { get; set; }

        [JsonIgnore]
        public virtual BlogPosts BlogPosts { get; set; }
        [JsonIgnore]
        public virtual Tags Tag { get; set; }
    }
}
