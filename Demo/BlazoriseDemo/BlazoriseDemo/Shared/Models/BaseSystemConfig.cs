using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseSystemConfig
    {
        public int SystemConfigId { get; set; }
        public int StoreId { get; set; }
        public string SystemConfigName { get; set; }
        public string SystemConfigAlias { get; set; }
        public string SystemConfigValue { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public string SystemConfigTypeName { get; set; }
    }
}
