using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderPayMethod:IEntity
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string FinancialAccountsId { get; set; }
        public string FinancialAccountsName { get; set; }
        public bool IsRealPaid { get; set; }
        public DateTime? AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime? UpdateTime { get; set; }
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
