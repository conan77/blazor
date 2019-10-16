using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseDishPeiCai
    {
        public string Uid { get; set; }
        public string DishUid { get; set; }
        public string PeiCaiUid { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
