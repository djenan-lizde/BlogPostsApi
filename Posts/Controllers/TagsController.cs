using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Posts.Database;
using Posts.Services;

namespace Posts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IData<Tags> _serviceTags;

        public TagsController(IData<Tags> serviceTags)
        {
            _serviceTags = serviceTags;
        }

        // GET api/<PostsController>/allTags
        [HttpGet]
        public IActionResult GetTags()
        {
            return Ok(_serviceTags.Get());
        }
    }
}
