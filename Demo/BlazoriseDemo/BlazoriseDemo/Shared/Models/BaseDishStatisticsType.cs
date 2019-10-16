using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseDishStatisticsType
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string StatisticsCode { get; set; }
        public string StatisticsName { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool? IsEnable { get; set; }
    }
}
