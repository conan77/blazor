﻿using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderZengSongDish
    {
        public string Uid { get; set; }
        public string OrderId { get; set; }
        public int StoreId { get; set; }
        public string OrderZhuoTaiId { get; set; }
        public string OrderZhuoTaiDishId { get; set; }
        public bool IsPackage { get; set; }
        public string PackageDishDetailId { get; set; }
        public string ZengSongDesc { get; set; }
        public decimal DishNum { get; set; }
        public decimal Tzsnum { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
    }
}
