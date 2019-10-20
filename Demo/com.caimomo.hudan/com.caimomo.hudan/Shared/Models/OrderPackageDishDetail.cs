using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderPackageDishDetail:IEntity
    {
        public string Uid { get; set; }
        public string OrderId { get; set; }
        public int StoreId { get; set; }
        public string OrderZhuoTaiDishId { get; set; }
        public string PackageId { get; set; }
        public string OrderZhuoTaiId { get; set; }
        public string DishId { get; set; }
        public string DishName { get; set; }
        public string DishTypeId { get; set; }
        public string DishTypeName { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal DishNum { get; set; }
        public bool IsSelect { get; set; }
        public decimal DishTuiCaiNum { get; set; }
        public decimal DishZengSongNum { get; set; }
        public bool? DishNumOk { get; set; }
        public decimal DishTzs { get; set; }
        public decimal DishPrice { get; set; }
        public decimal DishVipprice { get; set; }
        public decimal DishWebPrice { get; set; }
        public decimal DishTotalMoney { get; set; }
        public decimal DishZheKouMoney { get; set; }
        public decimal DishPaidMoney { get; set; }
        public decimal DishCostMoney { get; set; }
        public string DishStatusDesc { get; set; }
        public byte DishStatusId { get; set; }
        public string WaiterId { get; set; }
        public string WaiterName { get; set; }
        public int DishDisplayOrder { get; set; }
        public DateTime ShangCaiShiJian { get; set; }
        public bool IfHuaCai { get; set; }
        public bool IsTemp { get; set; }
        public string ZuoFaIds { get; set; }
        public string ZuoFaNames { get; set; }
        public string KouWeiIds { get; set; }
        public string KouWeiNames { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string HuaCaiNum { get; set; }
        public string Memo3 { get; set; }
        public string Memo4 { get; set; }
        public string SongDanUserName { get; set; }
        public DateTime? SongDanTime { get; set; }
        public decimal? DishTiChengMoney { get; set; }
        public bool IsTeJia { get; set; }
        public string Memo5 { get; set; }
        public string Memo6 { get; set; }
        public decimal FenTanDishPrice { get; set; }
        public decimal FenTanDishPaidMoney { get; set; }
        public string ParentId { get; set; }
        public decimal? TuiCaiSum { get; set; }
        public string Spec { get; set; }
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
