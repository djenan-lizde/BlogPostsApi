using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Posts.Database;
using Posts.Models;
using Posts.Services;

namespace Posts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _serviceBlogPosts;

        public PostsController(
            IPostService serviceBlogPosts
            )
        {
            _serviceBlogPosts = serviceBlogPosts;
        }

        // GET api/<PostsController>
        [HttpGet]
        public IActionResult Get([FromQuery] string tag)
        {
            var posts = new List<BlogPosts>();
            if (string.IsNullOrEmpty(tag))
            {
                posts = _serviceBlogPosts.Get().OrderByDescending(x => x.CreatedAt).ToList();
            }
            else
            {
                posts = _serviceBlogPosts.GetByTag(tag).OrderByDescending(x => x.CreatedAt).ToList();
            }
            return Ok(new BlogPostsModel
            {
                Posts = posts,
                PostsCount = posts.Count()
            });
        }

        // GET api/<PostsController>/slug
        [HttpGet("{slug}")]
        public IActionResult GetBySlug(string slug)
        {
            try
            {
                if (string.IsNullOrEmpty(slug))
                {
                    return BadRequest();
                }
                return Ok(_serviceBlogPosts.GetPost(x => x.Slug == slug));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/<PostsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateGetBlogPostModel blogPosts)
        {
            try
            {
                if (blogPosts == null)
                {
                    return BadRequest();
                }
                blogPosts.CreatedAt = DateTime.Now;
                blogPosts.UpdatedAt = null;
                blogPosts.Slug = blogPosts.Title.Replace(' ', '-').ToLower();
                return Ok(_serviceBlogPosts.InsertPost(blogPosts));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<PostsController>/slug
        [HttpPut("{slug}")]
        public IActionResult Put(string slug, [FromBody] BlogPosts blogPosts)
        {
            try
            {
                if (slug != blogPosts.Title.Replace(' ', '-').ToLower())
                {
                    blogPosts.Slug = blogPosts.Title.Replace(' ', '-').ToLower();
                }

                var entity = _serviceBlogPosts.Get(x => x.Slug == slug);
                if (entity == null)
                {
                    return NotFound();
                }
                blogPosts.Id = entity.Id;
                blogPosts.UpdatedAt = DateTime.Now;
                blogPosts.CreatedAt = entity.CreatedAt;
                return Ok(_serviceBlogPosts.Update(entity.Id, blogPosts));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<PostsController>/slug
        [HttpDelete("{slug}")]
        public IActionResult Delete(string slug)
        {
            try
            {
                var entity = _serviceBlogPosts.Get(x => x.Slug == slug);
                if (entity == null)
                {
                    return NotFound();
                }
                _serviceBlogPosts.DeletePost(entity.Id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
