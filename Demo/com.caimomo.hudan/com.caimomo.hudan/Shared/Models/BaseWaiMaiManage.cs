using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseWaiMaiManage
    {
        public string Uid { get; set; }
        public int PlatCode { get; set; }
        public string PlatName { get; set; }
        public int PlatState { get; set; }
        public int StoreId { get; set; }
        public string Parameters { get; set; }
        public string AddTime { get; set; }
        public string AddUser { get; set; }
    }
}
