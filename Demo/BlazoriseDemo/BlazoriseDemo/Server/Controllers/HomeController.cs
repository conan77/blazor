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
        //private readonly _182810Context _context;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
    }
}