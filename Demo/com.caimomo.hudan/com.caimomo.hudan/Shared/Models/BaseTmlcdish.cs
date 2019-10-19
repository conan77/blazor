using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseTmlcdish
    {
        public string DishId { get; set; }
        public string Tmlcid { get; set; }
        public int StoreId { get; set; }
        public decimal DishPrice { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
