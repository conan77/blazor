using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseWeiXinDishType
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string DishTypeUid { get; set; }
        public string WebName { get; set; }
        public bool IsEnable { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpadteUser { get; set; }
        public int? Sort { get; set; }
    }
}
