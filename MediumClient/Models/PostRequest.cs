using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumClient.Models
{
    public class PostRequest
    {
        public string Title { get; set; }
        public string ContentFormat { get; set; }
        public string Content { get; set; }
        public string CanonicalUrl { get; set; }
        public List<string> Tags { get; set; }
        public string PublishStatus { get; set; }
    }
}
