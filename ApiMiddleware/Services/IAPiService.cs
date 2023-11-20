using ApiMiddleware.Entity;

namespace ApiMiddleware.Services
{
    public interface IAPiService
    {
        Task<IEnumerable<ContentEntity>> GetAllContent();
        Task CreateContentAndPostToMedium(ContentEntity contentEntity);
    }
}
