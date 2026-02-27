using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SensitiveWords.WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _factory;

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    public async Task OnGet()
    {

    }
}
