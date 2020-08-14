using Microsoft.EntityFrameworkCore;
using System;

namespace Posts.Database
{
    public partial class PostsDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //Blogs
            modelBuilder.Entity<BlogPosts>().HasData(new BlogPosts()
            {
                Id = 1,
                Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                Slug = "augmented-reality-ios-application",
                Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                Title = "Augmented Reality iOS Application",
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            });
            modelBuilder.Entity<BlogPosts>().HasData(new BlogPosts()
            {
                Id = 2,
                Body = "An opinionated commentary, of the most important presentation of the year",
                Slug = "internet-trends-2018",
                Description = "Ever wonder how?",
                Title = "Internet Trends 2018",
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            });

            //BlogsTags
            modelBuilder.Entity<BlogPostsTags>().HasData(new BlogPostsTags()
            {
                Id = 1,
                BlogPostsId = 1,
                TagId = 3
            });
            modelBuilder.Entity<BlogPostsTags>().HasData(new BlogPostsTags()
            {
                Id = 2,
                BlogPostsId = 2,
                TagId = 3
            });
            modelBuilder.Entity<BlogPostsTags>().HasData(new BlogPostsTags()
            {
                Id = 3,
                BlogPostsId = 2,
                TagId = 1
            });
            modelBuilder.Entity<BlogPostsTags>().HasData(new BlogPostsTags()
            {
                Id = 4,
                BlogPostsId = 1,
                TagId = 1
            });
            modelBuilder.Entity<BlogPostsTags>().HasData(new BlogPostsTags()
            {
                Id = 5,
                BlogPostsId = 1,
                TagId = 4
            });

            //Tags
            modelBuilder.Entity<Tags>().HasData(new Tags()
            {
                Id = 1,
                TagName = "iOS"
            });
            modelBuilder.Entity<Tags>().HasData(new Tags()
            {
                Id = 2,
                TagName = ".NET"
            });
            modelBuilder.Entity<Tags>().HasData(new Tags()
            {
                Id = 3,
                TagName = "AngularJS"
            });
            modelBuilder.Entity<Tags>().HasData(new Tags()
            {
                Id = 4,
                TagName = "Android"
            });
        }
    }
}
