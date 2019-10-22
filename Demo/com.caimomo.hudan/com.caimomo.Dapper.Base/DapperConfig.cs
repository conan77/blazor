﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    public class DapperConfig
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectString => DbConnection?.ConnectionString;

        /// <summary>
        /// 数据库类型
        /// </summary>
        public RepositoryBaseType DataBaseType { get; set; }

        /// <summary>
        /// 数据库连接
        /// </summary>
        public DbConnection DbConnection { get; set; }
    }
}
