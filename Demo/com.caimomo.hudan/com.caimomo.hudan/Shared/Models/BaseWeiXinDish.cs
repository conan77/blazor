using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseWeiXinDish:IEntity
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string DishUid { get; set; }
        public bool IsEnable { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpadteUser { get; set; }
        public bool IsTuiJian { get; set; }
        public int Sort { get; set; }
        public int IsWaiMai { get; set; }
        public decimal Mealfee { get; set; }
        public int MealfeeUnit { get; set; }
        public string RelateDishUid { get; set; }
        public string RelatePsfdishUid { get; set; }
        public decimal? SalesCount { get; set; }
        public DateTime? TongJiDate { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
        public int? IfisOnlyShow { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string Memo3 { get; set; }
        public string Memo4 { get; set; }
        public string Memo5 { get; set; }

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
