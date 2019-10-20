using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HandlingWeiXinOrder:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public int TotalPeopleNum { get; set; }
        public int Status { get; set; }
        public string ZhuoTaiId { get; set; }
        public string ZhuoTaiName { get; set; }
        public decimal OrderMoney { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string OrderDetail { get; set; }
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
