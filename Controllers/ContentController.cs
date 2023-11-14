using ApiMiddleware.Entity;
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

        public ContentController(ContentContext context)
        {
            _context = context;
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

            return Ok();
        }


     
    }
}
