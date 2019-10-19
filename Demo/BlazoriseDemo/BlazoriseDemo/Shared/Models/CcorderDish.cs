using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class CcorderDish
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string Type { get; set; }
        public string CctemplateUid { get; set; }
        public string CctemplateDetailUid { get; set; }
        public string BatchCode { get; set; }
        public DateTime OperateDate { get; set; }
        public string DishTypeId { get; set; }
        public string DishTypeName { get; set; }
        public string DishId { get; set; }
        public string DishName { get; set; }
        public decimal DishNum { get; set; }
        public decimal DishNumOk { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal DishSignNum { get; set; }
        public string SignType { get; set; }
        public bool IsEnable { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
