using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class HisOrderGuQing
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string DishId { get; set; }
        public decimal DishNumber { get; set; }
        public DateTime GqstartTime { get; set; }
        public DateTime GqendTime { get; set; }
        public int Gqtype { get; set; }
        public string CanBieId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
    }
}
