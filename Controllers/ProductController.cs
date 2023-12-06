using Microsoft.AspNetCore.Mvc;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductServices _services;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet("/GetAllDataProduct")]
        public async Task<ActionResult<List<User>>> GetAllDataProduct()
        {
            try
            {
                var resultData = await _services.GetAllDataProduct();

                if (resultData.Count == 0)
                {
                    return NotFound(new { message = "Data Empty" });
                }

                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
