using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseCaiWuKeMu
    {
        public string Uid { get; set; }
        public string Cwkmname { get; set; }
        public string Cwkmcode { get; set; }
        public int DisplayOrder { get; set; }
        public bool? IsEnable { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public bool? IfShiShou { get; set; }
        public bool? IfQianTai { get; set; }
        public bool IfChuZhi { get; set; }
        public bool? IfShouQuan { get; set; }
        public string CwkmtypeId { get; set; }
    }
}
