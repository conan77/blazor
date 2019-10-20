using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using com.caimomo.Dapper.Base;
using com.caimomo.hudan.Shared;
using com.caimomo.hudan.Shared.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly SqlServerRepository _repository;
        private readonly IMemoryCache _cache;

        public OrdersController(ILogger<OrdersController> logger,
            SqlServerRepository repository)
        {
            this.logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<OrderBanCi> Get()
        {
            logger.Log(LogLevel.Information,"get orders api");
            return GetData();
        }

        private IEnumerable<OrderBanCi> GetData()
        {

            var data =new List<OrderBanCi>();
            SqlDataAdapter aqlAdapter=new SqlDataAdapter("Select * from OrderBanCi",_repository.DbConnection as SqlConnection);
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

            return data;
        }
    }
}