using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseTingMianLouCeng
    {
        public string Uid { get; set; }
        public string Tmlcname { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public bool? IsEnable { get; set; }
        public int StoreId { get; set; }
        public string DepartmentId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
    }
}
