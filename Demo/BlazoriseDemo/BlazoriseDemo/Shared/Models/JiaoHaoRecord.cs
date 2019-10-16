using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class JiaoHaoRecord
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string Ztname { get; set; }
        public string OrderZhuoTaiDishUid { get; set; }
        public string DishName { get; set; }
        public int IsCallNumber { get; set; }
        public int Count { get; set; }
        public string Memo { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
