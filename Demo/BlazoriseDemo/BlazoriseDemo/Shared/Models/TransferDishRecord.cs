using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class TransferDishRecord
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string SourceOrderId { get; set; }
        public string TargetOrderId { get; set; }
        public string SourceZhuoTaiName { get; set; }
        public string TargetZhuoTaiName { get; set; }
        public string SourceOrderZhuoTaiDishId { get; set; }
        public string TargetOrderZhuoTaiDishId { get; set; }
        public string UnitName { get; set; }
        public string DishName { get; set; }
        public decimal DishNum { get; set; }
        public int? Type { get; set; }
        public string SourceZhuoTaiId { get; set; }
        public string TargetZhuoTaiId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
    }
}
