using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers
{
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly Services.IUrlService _service;
        private readonly ILogger<UrlController> _logger;
        public UrlController(Services.IUrlService service, ILogger<UrlController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [Route("/{ID}")]
        [HttpGet]
        public IActionResult Link(string ID)
        {
            try
            {
                string url = _service.GetLongUrl(ID);
                return Redirect(url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(new
                {
                    Error = "Link not found"
                }
                );
            }
        }

        [ResponseCache(Duration = 5)]
        [Route("/API/Url")]
        [HttpGet]
        public IActionResult GetAllUrls()
        {
            try
            {
                return Ok(_service.GetAllUrls());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new
                {
                    Error = ex.Message
                }
                );
            }
        }

        [ResponseCache(Duration = 5)]
        [Route("/API/Url/Paged")]
        [HttpGet]
        public IActionResult GetPagedUrls(string pageSize, string pageNum)
        {
            try
            {
                int PageSize = Convert.ToInt32(pageSize);
                int PageNum = Convert.ToInt32(pageNum);
                return Ok(_service.GetPagedUrls(PageNum, PageSize));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Error = ex.Message });
            }
        }

        [Route("/API/Url")]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult AddUrl([FromForm]string url)
        {
            try
            {
                var result = _service.AddUrl(url);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        [Route("/API/Url")]
        [HttpDelete]
        public IActionResult RemoveURL([FromForm]string url)
        {
            try
            {
                if (_service.isExist("", url))
                {
                    _service.DeleteUrl(_service.GetShortUrl(url));
                    return Ok(new { Result = "Success" });
                }
                else return NotFound(new { Result = "Url not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
