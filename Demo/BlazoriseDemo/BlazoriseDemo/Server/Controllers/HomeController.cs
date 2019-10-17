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
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> logger;
        private readonly _182810Context _context;

        public HomeController(ILogger<HomeController> logger,
            _182810Context context)
        {
            this.logger = logger;
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            logger.Log(LogLevel.Information,"home api connect server");
            var data = _context.BaseSystemConfig.ToList();
            return string.Empty;
        }
    }
}