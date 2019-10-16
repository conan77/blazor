using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class OrderTuiCaiDish
    {
        public string Uid { get; set; }
        public string OrderId { get; set; }
        public int StoreId { get; set; }
        public string OrderZhuoTaiId { get; set; }
        public string OrderZhuoTaiDishId { get; set; }
        public bool IsPackage { get; set; }
        public string PackageDishDetailId { get; set; }
        public string TuiCaiDesc { get; set; }
        public decimal DishPrice { get; set; }
        public decimal DishNum { get; set; }
        public decimal Tzsnum { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
    }
}
