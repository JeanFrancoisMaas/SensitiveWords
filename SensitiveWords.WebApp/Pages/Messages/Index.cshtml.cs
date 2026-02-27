using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SensitiveWords.WebApp.Models.KeyWords;
using SensitiveWords.WebApp.Models.Messages;

namespace SensitiveWords.WebApp.Pages.Messages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _factory;

        public List<ClientMessage> Messages { get; set; } = new List<ClientMessage>();

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        public async Task OnGet()
        {
            var client = _factory.CreateClient("sanitizer");
            var messages = await client.GetFromJsonAsync<List<ClientMessage>>("/api/sanitizer/messages");
            Messages = messages ?? new List<ClientMessage>();

        }
    }
}
