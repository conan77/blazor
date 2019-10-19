using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseDishZuoFa
    {
        public string Uid { get; set; }
        public string DishId { get; set; }
        public string ZuoFaId { get; set; }
        public int AddPriceTypeId { get; set; }
        public decimal AddMoneyPer { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
    }
}
