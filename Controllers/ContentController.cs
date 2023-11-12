using ApiMiddleware.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMiddleware.Controllers
{
    [ApiController]
    [Route("post")]
    public class ContentController : ControllerBase
    {
        private static List<ContentEntity> contentEntities = new List<ContentEntity>()
        {
            new ContentEntity("1", "this is title", "this is post"),
            new ContentEntity("2", "this is another title", "this is another post"),
            new ContentEntity("3", "this is yet another title", "this is yet another post"),
        };

        [HttpGet(Name = "GetContent")]
        public IEnumerable<ContentEntity> Get()
        {
            return contentEntities;
        }
     
    }
}
