using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseDishType
    {
        public string Uid { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public int PrintOrder { get; set; }
        public string Description { get; set; }
        public bool? IsEnable { get; set; }
        public bool IsPackage { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public string ZongBuUid { get; set; }
        public bool? IsSelfHelp { get; set; }
    }
}
