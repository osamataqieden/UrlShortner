using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers
{
    [ApiController]
    public class UrlController : ControllerBase
    {

        private readonly Services.IUrlService _service;

        public UrlController(Services.IUrlService service)
        {
            _service = service;
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
            catch(Exception ex)
            {
                return new JsonResult(new
                {
                    Error = "Link not found"
                }
                );
                //return RedirectToPage("Index");
            }
        }
    }
}
