namespace ApiMiddleware.Entity
{
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
