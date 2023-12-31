﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderHeaderController : ControllerBase
    {
        private readonly IOrderHeaderServices _services;
        private readonly ILogger<OrderHeaderController> _logger;

        public OrderHeaderController(ILogger<OrderHeaderController> logger, IOrderHeaderServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet("/GetAllDataHeader")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllDataHeader()
        {
            try
            {
                var resultData = await _services.GetAllDataHeader();

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

        [HttpGet("/GetDataHeaderFiltered")]
        public async Task<ActionResult<IEnumerable<object>>> GetDataHeaderFiltered(string? orderID, string? custName)
        {
            try
            {
                var resultData = await _services.GetDataHeaderFiltered(orderID, custName);

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

        [HttpDelete("/DeleteOrder/{orderID}")]
        public async Task<IActionResult> DeleteOrder(string orderID)
        {
            try
            {
                bool result = await _services.DeleteOrder(orderID);

                if (result == false)
                {
                    return BadRequest(new { message = "Data Not Success deleted" });
                }

                return Ok(new { message = "Data Success deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/AddOrder")]
        public async Task<ActionResult<OrderHeader>> AddOrder([FromForm] string postData)
        {
            try
            {
                var result = await _services.AddOrder(postData);

                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
