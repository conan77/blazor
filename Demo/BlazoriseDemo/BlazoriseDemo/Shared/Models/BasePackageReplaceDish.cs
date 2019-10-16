using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BasePackageReplaceDish
    {
        public string Uid { get; set; }
        public string PackageId { get; set; }
        public string PackageDishId { get; set; }
        public string ReplaceDishId { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public float? DishNumber { get; set; }
        public decimal? DishTzs { get; set; }
        public string ZuoFaId { get; set; }
        public string ZuoFaName { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
    }
}
