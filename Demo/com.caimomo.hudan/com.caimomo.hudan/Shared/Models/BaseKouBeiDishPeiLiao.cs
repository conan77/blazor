using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseKouBeiDishPeiLiao : IEntity
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string CmmDishUid { get; set; }
        public string KouBeiDishUid { get; set; }
        public string CmmDishName { get; set; }
        public string KouBeiDishName { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
        public string Bak4 { get; set; }
        public string Bak5 { get; set; }

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
