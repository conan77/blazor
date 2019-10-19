using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class PreordainDishTmp
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string MemberId { get; set; }
        public string PreordainUid { get; set; }
        public string PreorderDishUid { get; set; }
        public string DishId { get; set; }
        public string DishName { get; set; }
        public decimal DishNum { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public int Status { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
    }
}
