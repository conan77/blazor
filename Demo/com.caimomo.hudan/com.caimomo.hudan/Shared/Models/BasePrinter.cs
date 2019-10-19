using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BasePrinter
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public int PrinterType { get; set; }
        public string Ipaddress { get; set; }
        public string ComPort { get; set; }
        public int SelectType { get; set; }
        public string CaipinTypeIds { get; set; }
        public string CaipinIds { get; set; }
        public bool IsEnable { get; set; }
        public string DanJuList { get; set; }
        public int PaperType { get; set; }
        public string RelatedPrinter { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public bool? Isbell { get; set; }
        public int? BellNum { get; set; }
        public int? BellInterval { get; set; }
        public string LouCengIds { get; set; }
        public bool? IfZhenDa { get; set; }
        public int BellPrintType { get; set; }
        public int? ControlState { get; set; }
    }
}
