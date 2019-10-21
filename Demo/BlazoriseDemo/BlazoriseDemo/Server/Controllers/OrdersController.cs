using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlazoriseDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        public OrdersController(ILogger<OrdersController> logger,
            IMemoryCache cache)
        {
            this.logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<OrderBanCi> Get()
        {
            logger.Log(LogLevel.Information,"get orders api");
            return GetData();
        }

        private IEnumerable<OrderBanCi> GetData()
        {
            Stopwatch watch = Stopwatch.StartNew();
            var conn = _cache.Get(MemoryCacheKey.ConnectString).ToString();
            var data =new List<OrderBanCi>();
            SqlDataAdapter aqlAdapter=new SqlDataAdapter("Select * from OrderBanCi",conn);
            DataSet ds=new DataSet();
            aqlAdapter.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                data.Add(new OrderBanCi()
                {
                    AddTime = Convert.ToDateTime(row["AddTime"]),
                    BanCiHao = row["BanCiHao"].ToString(),
                    JiaoZhangMoney =Convert.ToDecimal(row["JiaoZhangMoney"]),
                    Memo1 = row["Memo1"].ToString(),
                    Uid = row["Uid"].ToString(),
                    AddUser = row["AddUser"].ToString()
                });
            }
            watch.Stop();
            logger.Log(LogLevel.Information,"取数据花费"+$"{watch.Elapsed.Seconds}秒{watch.Elapsed.Milliseconds}毫秒");
            return data;
        }
    }
}