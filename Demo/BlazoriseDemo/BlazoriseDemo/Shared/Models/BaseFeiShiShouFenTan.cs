﻿using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseFeiShiShouFenTan
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string CaipinTypeIds { get; set; }
        public string CaipinIds { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}