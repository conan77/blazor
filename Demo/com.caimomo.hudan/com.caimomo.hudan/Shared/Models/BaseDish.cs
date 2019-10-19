using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseDish
    {
        public string Uid { get; set; }
        public string TypeId { get; set; }
        public string DishCode { get; set; }
        public string DishName { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string QuickCode1 { get; set; }
        public string QuickCode2 { get; set; }
        public decimal CostMoney { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MemberPrice { get; set; }
        public decimal WebPrice { get; set; }
        public bool? IsEnable { get; set; }
        public bool IsPackage { get; set; }
        public int DisplayOrder { get; set; }
        public int StoreId { get; set; }
        public string Memo { get; set; }
        public int MinZheKou { get; set; }
        public bool IsCommodity { get; set; }
        public bool? ChangePrice { get; set; }
        public bool IsPerPerson { get; set; }
        public bool ChangeWeight { get; set; }
        public bool ChangeZuofa { get; set; }
        public bool IsTemp { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string BarCode { get; set; }
        public string StatisticsTypeId { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
        public string ZongBuUid { get; set; }
        public decimal TiChengPrice { get; set; }
        public bool IsPeiCai { get; set; }
        public bool? IsSelfHelp { get; set; }
        public int? SelfHelpNum { get; set; }
        public string SelfHelpDishUid { get; set; }
        public string DishName2 { get; set; }
        public string SpecsDishUid { get; set; }
        public string SpecsUid { get; set; }
        public string SpecsName { get; set; }
    }
}
