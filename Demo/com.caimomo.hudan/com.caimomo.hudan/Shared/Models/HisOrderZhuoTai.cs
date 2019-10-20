using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisOrderZhuoTai:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string ZhuoTaiId { get; set; }
        public string ZhuoTaiName { get; set; }
        public int ZtpeopleNum { get; set; }
        public int ZhuoTaiDishOrder { get; set; }
        public string Memo { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string WaiterId { get; set; }
        public string WaiterName { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
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
