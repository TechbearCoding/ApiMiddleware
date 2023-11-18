using MediumClient.Models;
using System;
using System.Net.Http.Json;

namespace MediumClient.Services
{
    public class MediumService : IMediumService
    {
        private readonly HttpClient _httpClient;

        public MediumService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MediumApiClient");

        }
        public async Task<PostRequest> Post(PostRequest postRequest)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PostRequest>(_httpClient.BaseAddress +  "/v1/users/5303d74c64f66366f00cb9b2a94f3251bf5/posts", postRequest);

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
