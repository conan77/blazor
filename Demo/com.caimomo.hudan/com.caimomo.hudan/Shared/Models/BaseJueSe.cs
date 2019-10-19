using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseJueSe
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public string RightIds { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
