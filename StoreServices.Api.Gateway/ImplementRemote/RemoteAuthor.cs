using StoreServices.Api.Gateway.RemoteInterface;
using StoreServices.Api.Gateway.RemoteModel;
using System.Text.Json;

namespace StoreServices.Api.Gateway.ImplementRemote
{
    public class RemoteAuthor : IAutorRemote
    {
        private readonly IHttpClientFactory _client;
        private readonly ILogger _logger;

        public RemoteAuthor(IHttpClientFactory client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<RemoteAuthorModel> GetAutor(Guid id)
        {
            try
            {
                var client = _client.CreateClient("AuthorService");
                var response = await client.GetAsync($"/Author/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<RemoteAuthorModel>(content, options);
                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }
    }
}
