using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseZuoFa
    {
        public string Uid { get; set; }
        public string ZuoFaName { get; set; }
        public string QuickCode { get; set; }
        public bool? IsEnable { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public int AddPriceTypeId { get; set; }
        public decimal AddMoneyPer { get; set; }
        public string ZongBuUid { get; set; }
        public string ZuoFaTypeId { get; set; }
    }
}
