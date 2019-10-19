using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseUserRight
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public int RightId { get; set; }
        public string UserId { get; set; }
        public bool IsAllow { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
