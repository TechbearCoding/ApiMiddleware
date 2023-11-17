using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumClient.Models
{

    public class PostResponse
    {
        public PostData Data { get; set; }
    }
    public class PostData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string[] Tags { get; set; }
        public string Url { get; set; }
        public string CanonicalUrl { get; set; }
        public string PublishStatus { get; set; }
        public long PublishedAt { get; set; }
        public string License { get; set; }
        public string LicenseUrl { get; set; }
    }


}
