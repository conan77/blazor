using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseWaiMaiManage:IEntity
    {
        public string Uid { get; set; }
        public int PlatCode { get; set; }
        public string PlatName { get; set; }
        public int PlatState { get; set; }
        public int StoreId { get; set; }
        public string Parameters { get; set; }
        public string AddTime { get; set; }
        public string AddUser { get; set; }

        /// <summary>
        /// 得到主键
        /// </summary>
        /// <returns></returns>
        public object GetPrimaryKey()
        {
            return this.Uid;
        }

        /// <summary>
        /// 设置主键
        /// </summary>
        /// <param name="value">主键值</param>
        public void SetPrimaryKey(object value)
        {
            this.Uid = value.ToString();
        }
    }
}
