using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseCaiWuKeMuDiYongQuan
    {
        public string Uid { get; set; }
        public string Cwkmid { get; set; }
        public int StoreId { get; set; }
        public int Number { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CaipinTypeIds { get; set; }
        public string CaipinIds { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal ShiShouMoney { get; set; }
        public decimal DiYongMoney { get; set; }
        public string GuanLianCwkm { get; set; }
        public decimal? MinPrice { get; set; }
    }
}
