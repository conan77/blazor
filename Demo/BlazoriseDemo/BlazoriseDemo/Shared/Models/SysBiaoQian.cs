using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class SysBiaoQian
    {
        public string Uid { get; set; }
        public string BiaoQianName { get; set; }
        public string PaperType { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsEnable { get; set; }
        public string AddUser { get; set; }
        public DateTime? AddTime { get; set; }
    }
}
