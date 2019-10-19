using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class PrintHistory
    {
        public string Uid { get; set; }
        public string PrinterId { get; set; }
        public string PrinterName { get; set; }
        public string PrintContent { get; set; }
        public string LastPrinter { get; set; }
        public string LastPrinterName { get; set; }
        public int PrintStatus { get; set; }
        public string Client { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
