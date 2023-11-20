using ApiMiddleware.Entity;
using ApiMiddleware.Services;
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
        private readonly IAPiService _aPiService;

        public ContentController(ContentContext context, IAPiService aPiService)
        {
            _context = context;
            _aPiService = aPiService;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _aPiService.CreateContentAndPostToMedium(contentEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


     
    }
}
