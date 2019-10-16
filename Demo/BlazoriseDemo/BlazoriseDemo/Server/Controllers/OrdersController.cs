using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazoriseDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazoriseDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OrdersController> logger;
        private readonly _182810Context _context;

        public OrdersController(ILogger<OrdersController> logger,
            _182810Context context)
        {
            this.logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<OrderBanCi> Get()
        {
            var data = _context.OrderBanCi.ToList();
            return data;
        }
    }
}