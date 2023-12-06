using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailServices _services;
        private readonly ILogger<OrderDetailsController> _logger;

        public OrderDetailsController(ILogger<OrderDetailsController> logger, IOrderDetailServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet("/GetAllDataOrderDetail")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllDataOrderDetail()
        {
            try
            {
                var resultData = await _services.GetAllDataOrderDetail();

                if (resultData == null)
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

        [HttpGet("/GetDataODByOrderID")]
        public async Task<ActionResult<IEnumerable<object>>> GetDataODByOrderID(string orderID)
        {
            try
            {
                var resultData = await _services.GetDataOrderDetailByOrderID(orderID);

                if (resultData == null)
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
