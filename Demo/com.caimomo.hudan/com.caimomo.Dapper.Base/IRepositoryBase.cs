using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    /// <summary>
    /// 基类业务接口定义
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// 数据连接字符串
        /// </summary>
        string ConnectionString { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        RepositoryBaseType DatabaseType { get; }

        /// <summary>
        /// 数据库连接
        /// </summary>
        IDbConnection DbConnection { get; set; }

    }
}
