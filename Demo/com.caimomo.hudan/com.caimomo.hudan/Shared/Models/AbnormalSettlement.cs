using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class AbnormalSettlement : IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string CwkmId { get; set; }
        public decimal PayMoney { get; set; }
        public string RelatedOrderId { get; set; }
        public string PayMark { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string Memo3 { get; set; }
        public int Status { get; set; }
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
