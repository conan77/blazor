using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class DailyBalanceRecord:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string SettleDate { get; set; }
        public int Status { get; set; }
        public DateTime SettleTime { get; set; }
        public string SettleUserId { get; set; }
        public string SettleUserName { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
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
