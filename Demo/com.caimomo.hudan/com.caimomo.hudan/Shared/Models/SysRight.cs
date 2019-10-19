using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class SysRight
    {
        public int RightId { get; set; }
        public string RightName { get; set; }
        public int RightType { get; set; }
        public string PageName { get; set; }
        public string ClassName { get; set; }
        public int Sort { get; set; }
    }
}
