using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Posts.Database;
using Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Posts.Services
{
    public interface IPostService : IData<BlogPosts>
    {
        IList<BlogPosts> GetByTag(string tag);
        BlogPosts InsertPost(CreateGetBlogPostModel entity);
        void DeletePost(int Id);
        CreateGetBlogPostModel GetPost(Expression<Func<BlogPosts, bool>> predicate);
    }

    public class PostService : Data<BlogPosts>, IPostService
    {
        private readonly IData<BlogPostsTags> _serviceBlogPostsTags;
        private readonly IData<Tags> _serviceTags;

        public PostService(PostsDbContext context, IMapper mapper, IData<BlogPostsTags> serviceBlogPostsTags,
            IData<Tags> serviceTags) : base(context, mapper)
        {
            _serviceBlogPostsTags = serviceBlogPostsTags;
            _serviceTags = serviceTags;
        }

        public IList<BlogPosts> GetByTag(string tag)
        {
            return _context
                .BlogPostsTags
                .Include(x => x.BlogPosts)
                .Include(x => x.Tag)
                .Where(t => t.Tag.TagName == tag)
                .Select(x => x.BlogPosts)
                .Distinct()
                .ToList();
        }
        public BlogPosts InsertPost(CreateGetBlogPostModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var x = _entity.Add(_mapper.Map<BlogPosts>(entity));
            _context.SaveChanges();

            foreach (var item in entity.TagList)
            {
                var tag = _serviceTags.Get(x => x.TagName == item);
                if (tag == null)
                {
                    tag = _serviceTags.Insert(new Tags { TagName = item });
                }
                _serviceBlogPostsTags.Insert(new BlogPostsTags { TagId = tag.Id, BlogPostsId = x.Entity.Id });
            }

            return _mapper.Map<BlogPosts>(x.Entity);
        }
        public void DeletePost(int Id)
        {
            var entity = _entity.Find(Id);

            if (entity == null)
                throw new ArgumentNullException();

            var postTags = _serviceBlogPostsTags.GetByCondition(x => x.BlogPostsId == Id).ToList();
            foreach (var item in postTags)
            {
                _serviceBlogPostsTags.Delete(item.Id);
            }

            _entity.Remove(entity);
            _context.SaveChanges();
        }
        public CreateGetBlogPostModel GetPost(Expression<Func<BlogPosts, bool>> predicate)
        {
            var post = _entity.FirstOrDefault(predicate);
            if (post == null)
                return null;

            var postTags = _serviceBlogPostsTags.GetByCondition(x => x.BlogPostsId == post.Id).ToList();

            var model = _mapper.Map<CreateGetBlogPostModel>(post);
            model.TagList = new List<string>();

            foreach (var item in postTags)
            {
                var tag = _serviceTags.Get(x => x.Id == item.TagId);
                if(tag != null)
                    model.TagList.Add(tag.TagName);
            }

            return model;
        }
    }
}
