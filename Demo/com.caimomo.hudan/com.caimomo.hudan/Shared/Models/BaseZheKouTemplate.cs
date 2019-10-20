using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseZheKouTemplate:IEntity
    {
        public string Uid { get; set; }
        public string TempName { get; set; }
        public string TempCode { get; set; }
        public decimal Parameters { get; set; }
        public bool? IsEnable { get; set; }
        public int StoreId { get; set; }
        public bool NeedMember { get; set; }
        public int MinMemberLevel { get; set; }
        public string CanBieId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public string CaiPuIds { get; set; }
        public bool IsHuiYuanPrice { get; set; }
        public string ZongBuUid { get; set; }
        public decimal ZheKouLimit { get; set; }

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
