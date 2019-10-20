using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisOrderZheKou:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Zkid { get; set; }
        public string Zkname { get; set; }
        public decimal ZkziDingYi { get; set; }
        public byte ZheKouType { get; set; }
        public string AddUser { get; set; }
        public string AddUserName { get; set; }
        public string ShouQuanRenId { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public int ZheKouSource { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string AttachZheKouId { get; set; }
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
