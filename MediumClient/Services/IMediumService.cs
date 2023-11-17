using MediumClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumClient.Services
{
    public interface IMediumService
    {
        Task<PostRequest> Post(PostRequest postRequest);
    }
}
