using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class MachineJiaoHaoRecord
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string JiaoHaoRecordUid { get; set; }
        public string MachineId { get; set; }
        public string ZhuoTaiName { get; set; }
        public string DishName { get; set; }
        public string Memo { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
