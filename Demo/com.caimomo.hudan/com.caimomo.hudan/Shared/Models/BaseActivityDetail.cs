using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseActivityDetail
    {
        public string Uid { get; set; }
        public string ActivityId { get; set; }
        public string ActivityDishId1 { get; set; }
        public string ActivityDishId2 { get; set; }
        public int ActivityNum1 { get; set; }
        public int ActivityNum2 { get; set; }
        public decimal ActivityZheKou { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public int? TimeType { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? EffectDay { get; set; }
        public int? LaterDay { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
        public string ZongBuUid { get; set; }
    }
}
