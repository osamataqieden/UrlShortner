using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortner.Models;

namespace UrlShortner.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Services.IUrlService _urlService;

        public IndexModel(ILogger<IndexModel> logger, Services.IUrlService urlService)
        {
            _logger = logger;
            _urlService = urlService;
        }

        public void OnGet()
        {
        }

        public void OnPost(string URL)
        {
            try
            {
                if (!string.IsNullOrEmpty(URL))
                {
                    if (!_urlService.isExist("", URL))
                    {
                        Url url = _urlService.AddUrl(URL);
                        _logger.LogInformation($"{URL} shortned to ${url.ShortID}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}