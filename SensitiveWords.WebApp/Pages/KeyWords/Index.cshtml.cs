using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SensitiveWords.WebApp.Models.KeyWords;

namespace SensitiveWords.WebApp.Pages.KeyWords
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _factory;

        public List<KeyWord> KeyWords { get; set; } = new List<KeyWord>();

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }
        public async Task OnGet()
        {
            var client = _factory.CreateClient("sanitizer");
            var keyWords = await client.GetFromJsonAsync<List<KeyWord>>("/api/sanitizer/keywords");
            KeyWords = keyWords ?? new List<KeyWord>();
        }
    }
}
