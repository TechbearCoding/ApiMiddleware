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

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PostRequest>("/v1/users/1fc03fe1c49713e818c5313d9844cc2c8e0727bc7849375beccece443d8e6553c/posts", postRequest);

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
