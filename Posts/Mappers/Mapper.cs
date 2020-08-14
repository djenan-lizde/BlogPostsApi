using AutoMapper;
using Posts.Database;
using Posts.Models;

namespace Posts.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BlogPosts, BlogPosts>().ReverseMap();
            CreateMap<BlogPosts, CreateGetBlogPostModel>().ReverseMap();
        }
    }
}
