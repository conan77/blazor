using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseDictionary
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string DicType { get; set; }
        public string DicName { get; set; }
        public string QuickCode { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public int? DisplayOrder { get; set; }
        public string ZongBuUid { get; set; }
    }
}
