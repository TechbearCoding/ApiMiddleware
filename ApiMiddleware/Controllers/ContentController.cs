using ApiMiddleware.Entity;
using MediumClient.Models;
using MediumClient.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ApiMiddleware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly ContentContext _context;
        private readonly IMediumService _mediumService;

        public ContentController(ContentContext context, IMediumService mediumService)
        {
            _context = context;
            _mediumService = mediumService;
        }

        [HttpGet(Name = "GetContent")]
        public async Task<ActionResult<ContentEntity>> GetAll()
        {
            var contentEntities = await _context.ContentEntities.ToListAsync();
            if (contentEntities == null)
            {
                return NotFound();
            }
            return Ok(contentEntities);
        }

        [HttpPost(Name = "PostContent")]
        public async Task<ActionResult<ContentEntity>> Post(ContentEntity contentEntity)
        {
            _context.ContentEntities.Add(contentEntity);
            await _context.SaveChangesAsync();

            PostRequest postRequest = new PostRequest
            {
                Title = contentEntity.PostTitle,
                Content = contentEntity.PostContent,
                ContentFormat = "markdown",
                PublishStatus = "draft"
            };


            await _mediumService.Post(postRequest);

            return Ok();
        }


     
    }
}
