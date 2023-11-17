using MediumClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MediumClient.Services
{
    public class MediumService : IMediumService
    {
        private readonly String _baseUrl = "https://api.medium.com";
        private readonly HttpClient _httpClient;

        public MediumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PostRequest> Post(PostRequest postRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "181d415f34379af07b2c11d144dfbe35d");
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.AcceptCharset.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-8"));

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PostRequest>(_baseUrl + "/v1/users/5303d74c64f66366f00cb9b2a94f3251bf5/posts", postRequest);

            if(response.IsSuccessStatusCode)
            {
                return postRequest;
            }
            else
            {
                throw new HttpRequestException($"Failed with status code: {response.StatusCode}");
            }
        }
    }
}
