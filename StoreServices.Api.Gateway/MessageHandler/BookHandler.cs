using StoreServices.Api.Gateway.RemoteInterface;
using StoreServices.Api.Gateway.RemoteModel;
using System.Diagnostics;
using System.Text.Json;

namespace StoreServices.Api.Gateway.MessageHandler
{
    public class BookHandler : DelegatingHandler
    {
        private readonly ILogger _logger;
        private readonly IAutorRemote _autorRemote;

        public BookHandler(ILogger<BookHandler>logger, IAutorRemote autorRemote)
        {
            _logger = logger;
            _autorRemote = autorRemote;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            _logger.LogInformation("request is starting");

            var response = await base.SendAsync(request, cancellationToken);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<BookRemoteModel>(content, options);
                var authorResponse = await _autorRemote.GetAutor(result.BookAuthor ?? Guid.Empty);

                if(authorResponse != null)
                {
                    result.RemoteAuthor = authorResponse;
                    var resultStr = JsonSerializer.Serialize(result);
                    response.Content = new StringContent(resultStr, System.Text.Encoding.UTF8, "application/json");
                }
            }



            _logger.LogInformation($"total time of this process: {time.ElapsedMilliseconds}ms");

            return response;
        }
    }
}
