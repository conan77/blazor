using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuaDan.Model
{
	//固定菜品，基础菜品查询
	public class BaseDishModel
	{
		public string DishID { get; set; }
		public string DishName { get; set; }
		public string TypeID { get; set; }
		public string UnitName { get; set; }
	}

	//固定菜品，按菜品合并查询
	public class OrderZTDishModel
	{
		public string DishID { get; set; }
		public string DishName { get; set; }
		public decimal DishNum { get; set; }
		public string UnitName { get; set; }
		public DateTime AddTime { get; set; }
	}

	//固定菜品，所有菜品查询
	public class OrderAllZTDishModel
	{
		public string OrderID { get; set; }
		public string OrderCode { get; set; }
		public string ZTUID { get; set; }
		public string ZhuoTaiName { get; set; }
		public string UID { get; set; }
		public string DishID { get; set; }
		public string DishName { get; set; }
		public string UnitName { get; set; }
		public decimal DishNum { get; set; }
		public string ZuoFaNames { get; set; }
		public string KouWeiNames { get; set; }
		public DateTime SongDanTime { get; set; }
		public bool IsWaiMai { get; set; }
		public bool IsHuaCai { get; set; }
		public DateTime AddTime { get; set; }
		public string DishTypeID { get; set; }
		public string DishStatusDesc { get; set; }
		public string IsPackage { get; set; }
		public string HuaCaiNum { get; set; }
	}
}
