using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseXiaoFeiLeiXingDetail:IEntity
    {
        public string Uid { get; set; }
        public string Xflxuid { get; set; }
        public string DishId { get; set; }
        public int Type { get; set; }
        public int Number { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }

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
