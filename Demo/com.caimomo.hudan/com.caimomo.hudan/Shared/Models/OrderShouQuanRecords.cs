using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderShouQuanRecords:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public string ShouQuanRight { get; set; }
        public string ShouQuanContent { get; set; }
        public string ShouQuanUserId { get; set; }
        public string ShouQuanUserName { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string AddUser { get; set; }
        public string AddUserName { get; set; }
        public DateTime AddTime { get; set; }

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
