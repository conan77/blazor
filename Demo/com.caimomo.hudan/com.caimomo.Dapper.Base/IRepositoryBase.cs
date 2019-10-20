using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    /// <summary>
    /// 基类业务接口定义
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// 数据连接
        /// </summary>
        IDbConnection DbConnection { get; set; }
    }
}
