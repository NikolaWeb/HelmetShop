using HelmetShop.Api.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HelmetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        OrderProcessor orderProcessor;

        public OrdersController(OrderProcessor processor)
        {
            orderProcessor = processor;
        }

        [HttpPost]
        public void Post ([FromBody] Order o)
        {  
            orderProcessor.ProcessOrder(o);
        }

    }
}
