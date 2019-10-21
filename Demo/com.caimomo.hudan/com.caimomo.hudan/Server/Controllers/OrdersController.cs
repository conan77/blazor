using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using com.caimomo.Dapper.Base;
using com.caimomo.hudan.Shared;
using com.caimomo.hudan.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using  Dapper;
using  Dapper.Contrib;

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

        private readonly ILogger<OrdersController> _logger;
        private readonly DapperConfig _dbConfig;
        private readonly RepositoryBase<OrderBanCi> _repository;

        public OrdersController(ILogger<OrdersController> logger, DapperConfig dbConfig)
        {
            this._logger = logger;
            _dbConfig = dbConfig;
            _repository=new RepositoryBase<OrderBanCi>(dbConfig, "OrderBanCi");
        }

        [HttpGet]
        public IEnumerable<OrderBanCi> Get()
        {
            Stopwatch watch = Stopwatch.StartNew();
            _logger.Log(LogLevel.Information,"get orders api");
            var data =  GetData();
            watch.Stop();
            _logger.Log(LogLevel.Information,$"服务端取数据花费{watch.Elapsed.Seconds}秒{watch.Elapsed.Milliseconds}毫秒");
            return data;
        }

        private IEnumerable<OrderBanCi> GetData()
        {
            #region Dapper
            return _repository.GetAllEntity();
            #endregion

            #region Ado.net
            //var data =new List<OrderBanCi>();
            //SqlDataAdapter aqlAdapter=new SqlDataAdapter("Select * from OrderBanCi",_repository.ConnectionString);
            //DataSet ds=new DataSet();
            //aqlAdapter.Fill(ds);
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    data.Add(new OrderBanCi()
            //    {
            //        AddTime = Convert.ToDateTime(row["AddTime"]),
            //        BanCiHao = row["BanCiHao"].ToString(),
            //        JiaoZhangMoney =Convert.ToDecimal(row["JiaoZhangMoney"]),
            //        Memo1 = row["Memo1"].ToString(),
            //        Uid = row["Uid"].ToString(),
            //        AddUser = row["AddUser"].ToString()
            //    });
            //}

            //return data;
            #endregion
        }
    }
}