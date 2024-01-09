using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, ICustomerServices services)
        {

            _logger = logger;
            _services = services;
        }


        [HttpGet("/GetAllDataCustomer")]
        public async Task<ActionResult<List<User>>> GetAllDataCustomer()
        {
            try
            {
                var resultData = await _services.GetAllDataCustomer();

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
