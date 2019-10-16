using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuaDan.Model
{
	public class OrderHuaDanPart
	{
		public string UID { get; set; }
		public int GroupID { get; set; }
		public int StoreID { get; set; }
		public string OrderCode { get; set; }
		public string ZTUID { get; set; }
		public string ZTName { get; set; }
		public string DishUID { get; set; }
		public string DishID { get; set; }
		public string DishName { get; set; }
		public decimal HuaDanNum { get; set; }
		public string UnitName { get; set; }
		public bool IsPackage { get; set; }
		public bool IsPackageDetail { get; set; }
		public DateTime HuaDanTime { get; set; }
		public string AddUser { get; set; }
		public DateTime AddTime { get; set; }
		public string UpdateUser { get; set; }
		public DateTime UpdateTime { get; set; }
	}
}
