using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderInfoForKouBei
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderCode { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
    }
}
