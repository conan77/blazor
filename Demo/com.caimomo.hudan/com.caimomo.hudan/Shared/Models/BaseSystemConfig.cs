using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseSystemConfig:IEntity
    {
        public int SystemConfigId { get; set; }
        public int StoreId { get; set; }
        public string SystemConfigName { get; set; }
        public string SystemConfigAlias { get; set; }
        public string SystemConfigValue { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public string SystemConfigTypeName { get; set; }

        /// <summary>
        /// 得到主键
        /// </summary>
        /// <returns></returns>
        public object GetPrimaryKey()
        {
            return this.SystemConfigId;
        }

        /// <summary>
        /// 设置主键
        /// </summary>
        /// <param name="value">主键值</param>
        public void SetPrimaryKey(object value)
        {
            this.SystemConfigId = Convert.ToInt32(value);
        }
    }
}
