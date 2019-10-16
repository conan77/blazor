﻿using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class PreorderDish
    {
        public string Uid { get; set; }
        public string PreorderId { get; set; }
        public string DishId { get; set; }
        public string DishName { get; set; }
        public decimal DishNum { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string ZuoFaIds { get; set; }
        public string ZuoFaNames { get; set; }
        public string KouWeiIds { get; set; }
        public string KouWeiNames { get; set; }
        public bool IsPackage { get; set; }
        public bool IsTemp { get; set; }
        public decimal DishPrice { get; set; }
        public decimal DishTotalMoney { get; set; }
        public decimal DishZuoFaMoney { get; set; }
        public string DishStatusDesc { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string Memo3 { get; set; }
        public string PeiLiaoNames { get; set; }
        public string ParentId { get; set; }
    }
}
