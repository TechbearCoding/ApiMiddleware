using Microsoft.EntityFrameworkCore;

namespace ApiMiddleware.Entity
{
    public class ContentContext : DbContext
    {
        public String DbPath { get; private set; }

        public ContentContext() : base()
        {
            DbPath = "Content.db";
        }

        public DbSet<ContentEntity> ContentEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }
    }   
    public class ContentEntity
    {
        public String Id { get; set; }
        public String PostTitle { get; set; }
        public String PostContent { get; set; }
        public ContentEntity(String id, String postTitle, String postContent) 
        {
            Id = id;
            PostTitle = postTitle;
            PostContent = postContent;
        }  
    }
}
