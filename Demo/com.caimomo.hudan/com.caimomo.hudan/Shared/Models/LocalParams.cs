﻿using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class LocalParams
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Memo { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
