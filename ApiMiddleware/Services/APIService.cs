using ApiMiddleware.Entity;
using MediumClient.Models;
using MediumClient.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiMiddleware.Services
{
    public class APIService : IAPiService
    {
        private readonly ContentContext _context;
        private readonly IMediumService _mediumService;

        public APIService(ContentContext context, IMediumService mediumService)
        {
            _context = context;
            _mediumService = mediumService;
        }
        public async Task CreateContentAndPostToMedium(ContentEntity contentEntity)
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
        }

        public async Task<IEnumerable<ContentEntity>> GetAllContent()
        {
            return await _context.ContentEntities.ToListAsync();
        }
    }
}
