using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseXiaoFeiLeiXingDetail
    {
        public string Uid { get; set; }
        public string Xflxuid { get; set; }
        public string DishId { get; set; }
        public int Type { get; set; }
        public int Number { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
