using StoreServices.Api.ShoppingCart.RemoteInterface;
using StoreServices.Api.ShoppingCart.RemoteModel;
using System.Text.Json;

namespace StoreServices.Api.ShoppingCart.RemoteServices
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<RemoteBook> GetLibro(Guid Id)
        {
            try
            {
                var client = _httpClient.CreateClient("Book");
                client.DefaultRequestVersion = new Version(2, 0);
                var response = await client.GetAsync($"api/Book/{Id}");

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<RemoteBook>(content, options);
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
