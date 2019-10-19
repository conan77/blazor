using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseKouBeiDishPeiLiao
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string CmmDishUid { get; set; }
        public string KouBeiDishUid { get; set; }
        public string CmmDishName { get; set; }
        public string KouBeiDishName { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
        public string Bak4 { get; set; }
        public string Bak5 { get; set; }
    }
}
