using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class DishItemBg
    {
        public string Uid { get; set; }
        public string ItemId { get; set; }
        public int Mode { get; set; }
        public string ForeColor { get; set; }
        public string BgColor { get; set; }
        public string BmpPath { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
