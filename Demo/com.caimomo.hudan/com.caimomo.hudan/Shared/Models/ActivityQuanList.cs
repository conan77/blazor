using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class ActivityQuanList :IEntity
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string MemberId { get; set; }
        public string QuanId { get; set; }
        public int Num { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
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
