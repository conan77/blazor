using HuaDan;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace CaiMomoClient
{
	public class DanJu
	{
		//public static string GenerateZhiZuoDan(DataRow orderDishRow)
		//{
		//    StringBuilder zhiZuoDanText = new StringBuilder();

		//    zhiZuoDanText.Append(getPrintLine("制作单", 1, 2));
		//    zhiZuoDanText.Append(printSeparatedLine());
		//    zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0, 0));
		//    zhiZuoDanText.Append(getPrintLine("点菜员：" + orderDishRow["SongDanUserName"].ToString().Trim() + "  人数：" +  orderDishRow["TotalPeopleNum"] + "人", 0, 0));
		//    if (string.IsNullOrEmpty(orderDishRow["ZhuoTaiName"] as string))
		//        zhiZuoDanText.Append(getPrintLine(orderDishRow["TaiKaHao"] as string, 1, 3));
		//    else 
		//        zhiZuoDanText.Append(getPrintLine(orderDishRow["ZhuoTaiName"] as string , 1, 3));
		//    zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

		//    var KWZFStr = string.Empty;
		//    if (orderDishRow["ZuoFaNames"].ToString().Trim() != "" && orderDishRow["ZuoFaNames"].ToString().Trim() != "无")
		//        KWZFStr += orderDishRow["ZuoFaNames"].ToString().Trim();
		//    if (orderDishRow["KouWeiNames"].ToString().Trim() != "" && orderDishRow["KouWeiNames"].ToString().Trim() != "无")
		//    {
		//        if (KWZFStr != "")
		//            KWZFStr += " " + orderDishRow["KouWeiNames"].ToString().Trim();
		//        else
		//            KWZFStr += orderDishRow["KouWeiNames"].ToString().Trim();
		//    }

		//    if (!string.IsNullOrWhiteSpace(orderDishRow["Memo6"] as string)) 
		//    {
		//        if (KWZFStr != "")
		//            KWZFStr += " " + orderDishRow["Memo6"].ToString().Trim();
		//        else
		//            KWZFStr += orderDishRow["Memo6"].ToString().Trim();
		//    }

		//    if (!string.IsNullOrEmpty(KWZFStr))
		//        KWZFStr = "(" + KWZFStr + ")";

		//    zhiZuoDanText.Append(getPrintLine(orderDishRow["DishStatusDesc"].ToString().Trim() + " " + orderDishRow["DishName"].ToString().Trim() + KWZFStr, 0, 3));

		//    zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

		//    var numStr = "数量:" + decimalFormatter(decimal.Parse(orderDishRow["DishNum"].ToString())) + orderDishRow["UnitName"].ToString().Trim();
		//    var tzs = "";
		//    if (!object.Equals(orderDishRow["DishTZS"], null) && decimal.Parse(orderDishRow["DishTZS"].ToString()) != 0)
		//        tzs = "&&&align=0&size=2&text=(" + orderDishRow["DishTZS"].ToString() + "条/只)";
		//    if (string.IsNullOrEmpty(tzs))
		//        zhiZuoDanText.Append(getPrintLine(numStr, 1, 3));
		//    else
		//        zhiZuoDanText.Append(getPrintLine(numStr + tzs, 0, 3));

		//    zhiZuoDanText.Append(printBlank());
		//    zhiZuoDanText.Append(printCutPage());

		//    return zhiZuoDanText.ToString();

		//}

		private static string getPrintLine(string pszString, int nFontAlign, int nFontSize)
		{
			return string.Format("align={0}&size={1}&text={2}\r\n", nFontAlign, nFontSize, pszString);
		}

		private static string getPrintLine(string line)
		{
			return string.Format(line + "\r\n");
		}

		private static string printBlank()
		{
			return "[blank]\r\n";
		}

		private static string printCutPage()
		{
			return "[cutpage]\r\n";
		}

		protected static string printSeparatedLine()
		{
			if (Printer.LocalPrinter.paperType == E_PaperType.八十毫米)
			{
				return getPrintLine("- - - - - - - - - - - - - - - - - - - - - ", 0, 0);
			}
			else
			{
				return getPrintLine("- - - - - - - - - - - - - - - - ", 0, 0);
			}
		}

		public static string decimalFormatter(double value)
		{
			var result = value.ToString("F2").Replace(".00", "");
			if (result == "-0")
				result = "0";

			return result;
		}

		public static string decimalFormatter(decimal value)
		{
			var result = value.ToString("F2").Replace(".00", "");
			if (result == "-0")
				result = "0";

			return result;
		}

		/// <summary>
		/// 制作单打印
		/// </summary>
		/// <param name="orderDishRow"></param>
		/// <param name="type">0：仅非套餐表数据 1：仅套餐表数据 2：套餐存在套餐明细数据</param>
		/// <returns></returns>
		public static string GenerateZhiZuoDan(DataRow orderDishRow, decimal dishNum, E_PaperType paperType, string printerName)
		{
			string zhiZuoDanText = string.Empty; ;
			if (object.Equals(orderDishRow["IsPackageDetail"], null))
				return zhiZuoDanText;

			if (paperType == E_PaperType.八十毫米)
			{
				if ("否".Equals(orderDishRow["IsPackageDetail"].ToString()))
					zhiZuoDanText = AddZhiZuoDan80Text(orderDishRow, dishNum, printerName);
				else
					zhiZuoDanText = AddZhiZuoDanTaoCan80Text(orderDishRow, dishNum, printerName);
			}
			else
			{
				if ("否".Equals(orderDishRow["IsPackageDetail"].ToString()))
					zhiZuoDanText = AddZhiZuoDan58Text(orderDishRow, dishNum, printerName);
				else
					zhiZuoDanText = AddZhiZuoDanTaoCan58Text(orderDishRow, dishNum, printerName);
			}

			return zhiZuoDanText;
		}

		public static string AddZhiZuoDan80Text(DataRow orderDishRow, decimal dishNumParam, string printerName)
		{
			if (!string.IsNullOrEmpty(printerName))
				printerName = "(" + printerName + ")";

			ZhiZuoDan zzd = new ZhiZuoDan();
			var param = zzd.param;

			StringBuilder zhiZuoDanText = new StringBuilder();

			param.showZhuoTaiFont = param.showZhuoTaiFont == null ? "3" : param.showZhuoTaiFont;
			param.showDishFont = param.showDishFont == null ? "3" : param.showDishFont;
			param.showDishNumFont = param.showDishNumFont == null ? "3" : param.showDishNumFont;

			string zhuoTaiName = string.Empty;
			if (string.IsNullOrEmpty(orderDishRow["ZhuoTaiName"] as string))
				zhuoTaiName = orderDishRow["TaiKaHao"] as string;
			else
				zhuoTaiName = orderDishRow["ZhuoTaiName"] as string;

			if (param.selTemplate == "1")
			{
				#region 模版一
				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0, 0));
				zhiZuoDanText.Append(getPrintLine("送单人：" + orderDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? " (" + orderDishRow["TotalPeopleNum"].ToString() + "人)" : ""), 1, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(printBlank());

				var KWZFStr = string.Empty;
				if (orderDishRow["ZuoFaNames"].ToString().Trim() != "" && orderDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderDishRow["ZuoFaNames"].ToString().Trim();
				if (orderDishRow["KouWeiNames"].ToString().Trim() != "" && orderDishRow["KouWeiNames"].ToString().Trim() != "无")
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderDishRow["DishStatusDesc"].ToString().Trim()) ? (orderDishRow["DishStatusDesc"].ToString().Trim() + " " + orderDishRow["DishName"].ToString().Trim() + KWZFStr) : (orderDishRow["DishName"].ToString().Trim() + KWZFStr), 0, Convert.ToInt32(param.showDishFont)));

				zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

				var zengSongStr = decimal.Parse(orderDishRow["DishZengSongNum"].ToString()) > 0 ? "(含赠" + getUnitFormatter(decimal.Parse(orderDishRow["DishZengSongNum"].ToString()), orderDishRow["UnitName"].ToString().Trim()) + ")" : "";
				var numStr = "数量:" + getUnitFormatter(decimal.Parse(orderDishRow["DishNum"].ToString()) + decimal.Parse(orderDishRow["DishZengSongNum"].ToString()), orderDishRow["UnitName"].ToString().Trim()) + zengSongStr + orderDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = "数量:" + getUnitFormatter(dishNumParam, orderDishRow["UnitName"].ToString().Trim()) + orderDishRow["UnitName"].ToString().Trim();

				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = getAnotherPrintCmd("  金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString())), 0, Convert.ToInt32(param.showDishNumFont));
					if (dishNumParam > 0)
						moneyStr = getAnotherPrintCmd("  金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderDishRow["DishNum"].ToString()) * dishNumParam), 0, Convert.ToInt32(param.showDishNumFont));
				}

				var tzs = "";
				if (!object.Equals(orderDishRow["DishTZS"], null) && decimal.Parse(orderDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderDishRow["DishTZS"].ToString() + "条/只)", 0, Convert.ToInt32(param.showDishNumFont));
				if (string.IsNullOrEmpty(tzs))
				{
					if (string.IsNullOrEmpty(moneyStr))
						zhiZuoDanText.Append(getPrintLine(numStr, 1, Convert.ToInt32(param.showDishNumFont)));
					else
						zhiZuoDanText.Append(getPrintLine(numStr + moneyStr, 0, Convert.ToInt32(param.showDishNumFont)));
				}
				else
					zhiZuoDanText.Append(getPrintLine(numStr + tzs + moneyStr, 0, Convert.ToInt32(param.showDishNumFont)));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(printCutPage());
				#endregion
			}
			else
			{
				#region 模版二
				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = "   金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString()));
					if (dishNumParam > 0)
						moneyStr = "   金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderDishRow["DishNum"].ToString()) * dishNumParam);
				}

				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 送单人：" + orderDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? "(" + orderDishRow["TotalPeopleNum"].ToString() + "人)" : "") + moneyStr, 0, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(printBlank());
				var KWZFStr = string.Empty;
				if (orderDishRow["ZuoFaNames"].ToString().Trim() != "" && orderDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderDishRow["ZuoFaNames"].ToString().Trim();
				if (orderDishRow["KouWeiNames"].ToString().Trim() != "" && orderDishRow["KouWeiNames"].ToString().Trim() != "无")
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				var zengSongStr = decimal.Parse(orderDishRow["DishZengSongNum"].ToString()) > 0 ? "(含赠" + getUnitFormatter(decimal.Parse(orderDishRow["DishZengSongNum"].ToString()), orderDishRow["UnitName"].ToString().Trim()) + ")" : "";
				var numStr = getUnitFormatter(decimal.Parse(orderDishRow["DishNum"].ToString()) + decimal.Parse(orderDishRow["DishZengSongNum"].ToString()), orderDishRow["UnitName"].ToString().Trim()) + zengSongStr + orderDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = getUnitFormatter(dishNumParam, orderDishRow["UnitName"].ToString().Trim()) + orderDishRow["UnitName"].ToString().Trim();

				var tzs = "";
				if (!object.Equals(orderDishRow["DishTZS"], null) && decimal.Parse(orderDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderDishRow["DishTZS"].ToString() + "条/只)", 0, Convert.ToInt32(param.showDishFont));
				numStr += tzs;

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderDishRow["DishStatusDesc"].ToString().Trim()) ? (orderDishRow["DishStatusDesc"].ToString().Trim() + " " + orderDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr) : (orderDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr), 0, Convert.ToInt32(param.showDishFont)));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(printCutPage());
				#endregion
			}

			return zhiZuoDanText.ToString();

		}

		public static string AddZhiZuoDanTaoCan80Text(DataRow orderPackageDishRow, decimal dishNumParam, string printerName)
		{
			if (!string.IsNullOrEmpty(printerName))
				printerName = "(" + printerName + ")";

			ZhiZuoDan zzd = new ZhiZuoDan();
			var param = zzd.param;

			StringBuilder zhiZuoDanText = new StringBuilder();

			param.showZhuoTaiFont = param.showZhuoTaiFont == null ? "3" : param.showZhuoTaiFont;
			param.showDishFont = param.showDishFont == null ? "3" : param.showDishFont;
			param.showDishNumFont = param.showDishNumFont == null ? "3" : param.showDishNumFont;

			string zhuoTaiName = string.Empty;
			if (string.IsNullOrEmpty(orderPackageDishRow["ZhuoTaiName"] as string))
				zhuoTaiName = orderPackageDishRow["TaiKaHao"] as string;
			else
				zhuoTaiName = orderPackageDishRow["ZhuoTaiName"] as string;

			if (param.selTemplate == "1")
			{
				#region //模板一
				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0, 0));
				zhiZuoDanText.Append(getPrintLine("送单人：" + orderPackageDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? " (" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人)" : ""), 1, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(printBlank());

				var KWZFStr = string.Empty;
				if (orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "" && orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderPackageDishRow["ZuoFaNames"].ToString().Trim();
				if (!object.Equals(null, orderPackageDishRow["KouWeiNames"]) && !string.IsNullOrEmpty(orderPackageDishRow["KouWeiNames"].ToString().Trim()) && !object.Equals(orderPackageDishRow["KouWeiNames"].ToString().Trim(), "无"))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderPackageDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderPackageDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderPackageDishRow["DishStatusDesc"].ToString().Trim()) ? (orderPackageDishRow["DishStatusDesc"].ToString().Trim() + " (套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr) : ("(套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr), 0, Convert.ToInt32(param.showDishFont)));

				zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

				decimal dishNum = (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * (decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()));
				var zengSongStr = decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) > 0 || decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()) > 0 ? "(含赠" + getUnitFormatter(decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) * decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["UnitName"].ToString().Trim()) + ")" : "";

				var numStr = "数量:" + getUnitFormatter(dishNum, orderPackageDishRow["UnitName"].ToString().Trim()) + zengSongStr + orderPackageDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = "数量:" + getUnitFormatter(dishNumParam, orderPackageDishRow["UnitName"].ToString().Trim()) + orderPackageDishRow["UnitName"].ToString().Trim();

				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = getAnotherPrintCmd(" 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString())), 0, Convert.ToInt32(param.showDishNumFont));
					if (dishNumParam > 0)
						moneyStr = getAnotherPrintCmd(" 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderPackageDishRow["DishNum"].ToString()) * dishNumParam), 0, Convert.ToInt32(param.showDishNumFont));
				}

				var tzs = "";
				if (!object.Equals(orderPackageDishRow["DishTZS"], null) && decimal.Parse(orderPackageDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderPackageDishRow["DishTZS"].ToString() + "条/只)", 0, 2);
				if (string.IsNullOrEmpty(tzs))
				{
					if (string.IsNullOrEmpty(moneyStr))
						zhiZuoDanText.Append(getPrintLine(numStr, 1, Convert.ToInt32(param.showDishNumFont)));
					else
						zhiZuoDanText.Append(getPrintLine(numStr + moneyStr, 0, Convert.ToInt32(param.showDishNumFont)));
				}
				else
					zhiZuoDanText.Append(getPrintLine(numStr + tzs, 0, Convert.ToInt32(param.showDishNumFont)));

				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(getPrintLine("套餐【" + orderPackageDishRow["ZTDishName"].ToString() + "】" + getUnitFormatter(decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["ZTUnitName"].ToString()) + orderPackageDishRow["ZTUnitName"].ToString(), 0, 1));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderPackageDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderPackageDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderPackageDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());

				zhiZuoDanText.Append(printCutPage());
				#endregion
			}
			else
			{
				#region //模板二
				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = " 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString()));
					if (dishNumParam > 0)
						moneyStr = " 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderPackageDishRow["DishNum"].ToString()) * dishNumParam);
				}
				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 送单人：" + orderPackageDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? " (" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人)" : "") + moneyStr, 0, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(printBlank());

				var KWZFStr = string.Empty;
				if (orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "" && orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderPackageDishRow["ZuoFaNames"].ToString().Trim();
				if (!object.Equals(null, orderPackageDishRow["KouWeiNames"]) && !string.IsNullOrEmpty(orderPackageDishRow["KouWeiNames"].ToString().Trim()) && !object.Equals(orderPackageDishRow["KouWeiNames"].ToString().Trim(), "无"))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderPackageDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderPackageDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				decimal dishNum = (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * (decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()));
				var zengSongStr = decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) > 0 || decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()) > 0 ? "(含赠" + getUnitFormatter(decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) * decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["UnitName"].ToString().Trim()) + ")" : "";

				var numStr = Common.decimalFormatter(dishNum) + zengSongStr + orderPackageDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = Common.decimalFormatter(dishNumParam) + orderPackageDishRow["UnitName"].ToString().Trim();

				var tzs = "";
				if (!object.Equals(orderPackageDishRow["DishTZS"], null) && decimal.Parse(orderPackageDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderPackageDishRow["DishTZS"].ToString() + "条/只)", 0, Convert.ToInt32(param.showDishFont));
				numStr += tzs;

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderPackageDishRow["DishStatusDesc"].ToString().Trim()) ? (orderPackageDishRow["DishStatusDesc"].ToString().Trim() + " (套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr) : ("(套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr), 0, Convert.ToInt32(param.showDishFont)));

				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(getPrintLine("套餐【" + orderPackageDishRow["ZTDishName"].ToString() + "】" + getUnitFormatter(decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["ZTUnitName"].ToString()) + orderPackageDishRow["ZTUnitName"].ToString(), 0, 1));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderPackageDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderPackageDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderPackageDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());

				zhiZuoDanText.Append(printCutPage());
				#endregion
			}

			return zhiZuoDanText.ToString();
		}

		public static string AddZhiZuoDan58Text(DataRow orderDishRow, decimal dishNumParam, string printerName)
		{
			if (!string.IsNullOrEmpty(printerName))
				printerName = "(" + printerName + ")";

			ZhiZuoDan zzd = new ZhiZuoDan();
			var param = zzd.param;

			StringBuilder zhiZuoDanText = new StringBuilder();

			param.showZhuoTaiFont = param.showZhuoTaiFont == null ? "3" : param.showZhuoTaiFont;
			param.showDishFont = param.showDishFont == null ? "3" : param.showDishFont;
			param.showDishNumFont = param.showDishNumFont == null ? "3" : param.showDishNumFont;

			string zhuoTaiName = string.Empty;
			if (string.IsNullOrEmpty(orderDishRow["ZhuoTaiName"] as string))
				zhuoTaiName = orderDishRow["TaiKaHao"] as string;
			else
				zhuoTaiName = orderDishRow["ZhuoTaiName"] as string;

			if (param.selTemplate == "1")
			{
				#region //模版一
				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0, 0));

				zhiZuoDanText.Append(getPrintLine("送单人：" + orderDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? " (" + orderDishRow["TotalPeopleNum"].ToString() + "人)" : ""), 1, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

				var KWZFStr = string.Empty;
				if (orderDishRow["ZuoFaNames"].ToString().Trim() != "" && orderDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderDishRow["ZuoFaNames"].ToString().Trim();
				if (orderDishRow["KouWeiNames"].ToString().Trim() != "" && orderDishRow["KouWeiNames"].ToString().Trim() != "无")
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderDishRow["DishStatusDesc"].ToString().Trim()) ? (orderDishRow["DishStatusDesc"].ToString().Trim() + " " + orderDishRow["DishName"].ToString().Trim() + KWZFStr) : (orderDishRow["DishName"].ToString().Trim() + KWZFStr), 0, Convert.ToInt32(param.showDishFont)));

				zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

				var zengSongStr = decimal.Parse(orderDishRow["DishZengSongNum"].ToString()) > 0 ? "(含赠" + getUnitFormatter(decimal.Parse(orderDishRow["DishZengSongNum"].ToString()), orderDishRow["UnitName"].ToString().Trim()) + ")" : "";
				var numStr = getUnitFormatter(decimal.Parse(orderDishRow["DishNum"].ToString()) + decimal.Parse(orderDishRow["DishZengSongNum"].ToString()), orderDishRow["UnitName"].ToString().Trim()) + zengSongStr + orderDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = getUnitFormatter(dishNumParam, orderDishRow["UnitName"].ToString().Trim()) + orderDishRow["UnitName"].ToString().Trim();

				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = getAnotherPrintCmd(" 金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString())), 0, Convert.ToInt32(param.showDishNumFont));
					if (dishNumParam > 0)
						moneyStr = getAnotherPrintCmd(" 金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderDishRow["DishNum"].ToString()) * dishNumParam), 0, Convert.ToInt32(param.showDishNumFont));
				}
				var tzs = "";
				if (!object.Equals(orderDishRow["DishTZS"], null) && decimal.Parse(orderDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderDishRow["DishTZS"].ToString() + "条/只)", 0, Convert.ToInt32(param.showDishNumFont));
				if (string.IsNullOrEmpty(tzs))
				{
					if (string.IsNullOrEmpty(moneyStr))
						zhiZuoDanText.Append(getPrintLine(numStr, 1, Convert.ToInt32(param.showDishNumFont)));
					else
						zhiZuoDanText.Append(getPrintLine(numStr + moneyStr, 0, Convert.ToInt32(param.showDishNumFont)));
				}
				else
					zhiZuoDanText.Append(getPrintLine(numStr + tzs, 0, Convert.ToInt32(param.showDishNumFont)));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(printCutPage());

				#endregion
			}
			else
			{
				#region //模版二
				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = " 金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString()));
					if (dishNumParam > 0)
						moneyStr = " 金额:" + Common.decimalFormatter(decimal.Parse(orderDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderDishRow["DishNum"].ToString()) * dishNumParam);
				}
				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 送单人：" + orderDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(getPrintLine(" ", 1, 0));
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? " (" + orderDishRow["TotalPeopleNum"].ToString() + "人)" : "") + moneyStr, 0, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(getPrintLine(" ", 1, 0));

				var KWZFStr = string.Empty;
				if (orderDishRow["ZuoFaNames"].ToString().Trim() != "" && orderDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderDishRow["ZuoFaNames"].ToString().Trim();
				if (orderDishRow["KouWeiNames"].ToString().Trim() != "" && orderDishRow["KouWeiNames"].ToString().Trim() != "无")
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				var numStr = "数量:" + getUnitFormatter(decimal.Parse(orderDishRow["DishNum"].ToString()), orderDishRow["UnitName"].ToString().Trim()) + orderDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = "数量:" + getUnitFormatter(dishNumParam, orderDishRow["UnitName"].ToString().Trim()) + orderDishRow["UnitName"].ToString().Trim();

				var tzs = "";
				if (!object.Equals(orderDishRow["DishTZS"], null) && decimal.Parse(orderDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderDishRow["DishTZS"].ToString() + "条/只)", 0, Convert.ToInt32(param.showDishFont));
				numStr += tzs;

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderDishRow["DishStatusDesc"].ToString().Trim()) ? (orderDishRow["DishStatusDesc"].ToString().Trim() + " " + orderDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr) : (orderDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr), 0, Convert.ToInt32(param.showDishFont)));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(printCutPage());

				#endregion
			}

			return zhiZuoDanText.ToString();

		}

		public static string AddZhiZuoDanTaoCan58Text(DataRow orderPackageDishRow, decimal dishNumParam, string printerName)
		{
			if (!string.IsNullOrEmpty(printerName))
				printerName = "(" + printerName + ")";

			ZhiZuoDan zzd = new ZhiZuoDan();
			var param = zzd.param;

			StringBuilder zhiZuoDanText = new StringBuilder();

			param.showZhuoTaiFont = param.showZhuoTaiFont == null ? "3" : param.showZhuoTaiFont;
			param.showDishFont = param.showDishFont == null ? "3" : param.showDishFont;
			param.showDishNumFont = param.showDishNumFont == null ? "3" : param.showDishNumFont;

			string zhuoTaiName = string.Empty;
			if (string.IsNullOrEmpty(orderPackageDishRow["ZhuoTaiName"] as string))
				zhuoTaiName = orderPackageDishRow["TaiKaHao"] as string;
			else
				zhuoTaiName = orderPackageDishRow["ZhuoTaiName"] as string;

			if (param.selTemplate == "1")
			{
				#region //模板一
				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0, 0));
				zhiZuoDanText.Append(getPrintLine("送单人：" + orderPackageDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? " (" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人)" : ""), 1, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

				var KWZFStr = string.Empty;
				if (orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "" && orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderPackageDishRow["ZuoFaNames"].ToString().Trim();
				if (!object.Equals(null, orderPackageDishRow["KouWeiNames"]) && !string.IsNullOrEmpty(orderPackageDishRow["KouWeiNames"].ToString().Trim()) && !object.Equals(orderPackageDishRow["KouWeiNames"].ToString().Trim(), "无"))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderPackageDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderPackageDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderPackageDishRow["DishStatusDesc"].ToString().Trim()) ? (orderPackageDishRow["DishStatusDesc"].ToString().Trim() + " (套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr) : ("(套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr), 0, Convert.ToInt32(param.showDishFont)));

				zhiZuoDanText.Append(getPrintLine(" ", 1, 1));

				decimal dishNum = (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * (decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()));
				var zengSongStr = decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) > 0 || decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()) > 0 ? "(含赠" + getUnitFormatter(decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) * decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["UnitName"].ToString().Trim()) + ")" : "";

				var numStr = "数量:" + getUnitFormatter(dishNum, orderPackageDishRow["UnitName"].ToString().Trim()) + zengSongStr + orderPackageDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = "数量:" + getUnitFormatter(dishNumParam, orderPackageDishRow["UnitName"].ToString().Trim()) + orderPackageDishRow["UnitName"].ToString().Trim();

				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = getAnotherPrintCmd(" 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString())), 0, Convert.ToInt32(param.showDishNumFont));
					if (dishNumParam > 0)
						moneyStr = getAnotherPrintCmd(" 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderPackageDishRow["DishNum"].ToString()) * dishNumParam), 0, Convert.ToInt32(param.showDishNumFont));
				}
				var tzs = "";
				if (!object.Equals(orderPackageDishRow["DishTZS"], null) && decimal.Parse(orderPackageDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderPackageDishRow["DishTZS"].ToString() + "条/只)", 0, 2);
				if (string.IsNullOrEmpty(tzs))
				{
					if (string.IsNullOrEmpty(moneyStr))
						zhiZuoDanText.Append(getPrintLine(numStr, 1, Convert.ToInt32(param.showDishNumFont)));
					else
						zhiZuoDanText.Append(getPrintLine(numStr + moneyStr, 0, Convert.ToInt32(param.showDishNumFont)));
				}
				else
					zhiZuoDanText.Append(getPrintLine(numStr + tzs, 0, Convert.ToInt32(param.showDishNumFont)));

				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(getPrintLine("套餐【" + orderPackageDishRow["ZTDishName"].ToString() + "】" + getUnitFormatter(decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["ZTUnitName"].ToString()) + orderPackageDishRow["ZTUnitName"].ToString(), 0, 1));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderPackageDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderPackageDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderPackageDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());

				zhiZuoDanText.Append(printCutPage());
				#endregion
			}
			else
			{
				#region //模板二
				var moneyStr = string.Empty;
				if (param.showZhiZuoDanPrice)
				{
					moneyStr = " 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString()));
					if (dishNumParam > 0)
						moneyStr = " 金额:" + Common.decimalFormatter(decimal.Parse(orderPackageDishRow["DishPaidMoney"].ToString()) / decimal.Parse(orderPackageDishRow["DishNum"].ToString()) * dishNumParam);
				}
				zhiZuoDanText.Append(getPrintLine("制作单" + printerName, 1, 2));
				zhiZuoDanText.Append(printSeparatedLine());
				zhiZuoDanText.Append(getPrintLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 送单人：" + orderPackageDishRow["SongDanUserName"].ToString().Trim() + (!param.showPeopleNumBigFont ? "  人数：" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人" : ""), 0, 0));
				zhiZuoDanText.Append(getPrintLine(" ", 1, 0));
				zhiZuoDanText.Append(getPrintLine(zhuoTaiName + (param.showPeopleNumBigFont ? " (" + orderPackageDishRow["TotalPeopleNum"].ToString() + "人)" : "") + moneyStr, 0, Convert.ToInt32(param.showZhuoTaiFont)));
				zhiZuoDanText.Append(getPrintLine(" ", 1, 0));

				var KWZFStr = string.Empty;
				if (orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "" && orderPackageDishRow["ZuoFaNames"].ToString().Trim() != "无")
					KWZFStr += orderPackageDishRow["ZuoFaNames"].ToString().Trim();
				if (!object.Equals(null, orderPackageDishRow["KouWeiNames"]) && !string.IsNullOrEmpty(orderPackageDishRow["KouWeiNames"].ToString().Trim()) && !object.Equals(orderPackageDishRow["KouWeiNames"].ToString().Trim(), "无"))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["KouWeiNames"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["KouWeiNames"].ToString().Trim();
				}
				if (!object.Equals(orderPackageDishRow["Memo6"], null) && !string.IsNullOrEmpty(orderPackageDishRow["Memo6"].ToString().Trim()))
				{
					if (KWZFStr != "")
						KWZFStr += " " + orderPackageDishRow["Memo6"].ToString().Trim();
					else
						KWZFStr += orderPackageDishRow["Memo6"].ToString().Trim();
				}

				if (!string.IsNullOrEmpty(KWZFStr))
					KWZFStr = "(" + KWZFStr + ")";

				decimal dishNum = (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * (decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()));
				var zengSongStr = decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) > 0 || decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()) > 0 ? "(含赠" + getUnitFormatter(decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString()) * decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + (decimal.Parse(orderPackageDishRow["DishNum"].ToString()) + decimal.Parse(orderPackageDishRow["DishZengSongNum"].ToString())) * decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["UnitName"].ToString().Trim()) + ")" : "";

				var numStr = Common.decimalFormatter(dishNum) + zengSongStr + orderPackageDishRow["UnitName"].ToString().Trim();
				if (dishNumParam > 0)
					numStr = Common.decimalFormatter(dishNumParam) + orderPackageDishRow["UnitName"].ToString().Trim();

				var tzs = "";
				if (!object.Equals(orderPackageDishRow["DishTZS"], null) && decimal.Parse(orderPackageDishRow["DishTZS"].ToString()) != 0)
					tzs = getAnotherPrintCmd("(" + orderPackageDishRow["DishTZS"].ToString() + "条/只)", 0, Convert.ToInt32(param.showDishFont));
				numStr += tzs;

				zhiZuoDanText.Append(getPrintLine(param.showChuCaiWay && !string.IsNullOrEmpty(orderPackageDishRow["DishStatusDesc"].ToString().Trim()) ? (orderPackageDishRow["DishStatusDesc"].ToString().Trim() + " (套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr) : ("(套)" + orderPackageDishRow["DishName"].ToString().Trim() + KWZFStr + " " + numStr), 0, Convert.ToInt32(param.showDishFont)));

				zhiZuoDanText.Append(printBlank());
				zhiZuoDanText.Append(getPrintLine("套餐【" + orderPackageDishRow["ZTDishName"].ToString() + "】" + getUnitFormatter(decimal.Parse(orderPackageDishRow["ZTDishNum"].ToString()) + decimal.Parse(orderPackageDishRow["ZTDishZengSongNum"].ToString()), orderPackageDishRow["ZTUnitName"].ToString()) + orderPackageDishRow["ZTUnitName"].ToString(), 0, 1));

				if (param.showZhiZuoDanHuaDanHao && !object.Equals(orderPackageDishRow["HuaCaiNum"], null) && !string.IsNullOrEmpty(orderPackageDishRow["HuaCaiNum"].ToString().Trim()))
				{
					zhiZuoDanText.Append(printBlank());
					zhiZuoDanText.Append("[tiaoma]" + orderPackageDishRow["HuaCaiNum"].ToString().Trim() + "\r\n");
				}
				zhiZuoDanText.Append(printBlank());

				zhiZuoDanText.Append(printCutPage());
				#endregion
			}

			return zhiZuoDanText.ToString();
		}

		public static string getUnitFormatter(decimal value, string unitName)
		{
			if (unitName != null && isSetWeightPrecision(unitName))
			{
				return value.ToString("F3");
			}
			else
				return Common.decimalFormatter(value);
		}

		public static bool isSetWeightPrecision(string unitName)
		{
			if (object.Equals(unitName, "千克") || object.Equals(unitName, "公斤") || object.Equals(unitName, "斤") || object.Equals(unitName, "KG"))
				return true;
			else
				return false;
		}

		protected static string getAnotherPrintCmd(string pszString, int nFontAlign, int nFontSize)
		{
			return "&&&align=0&size=" + nFontSize + "&text=" + pszString;
		}
	}

	public class ZhiZuoDan
	{

		public ZhiZuoDan()
		{
			init();
		}

		public Param param;
		public class Param
		{
			public string selTemplate = "1";
			public bool showChuCaiWay = true;
			public bool showFootTaoCanDish = true;
			public bool showPeopleNumBigFont = true;
			public bool showZhiZuoDanHuaDanHao = false;
			public bool showZhiZuoDanPrice = false;

			public string showZhuoTaiFont = "3";
			public string showDishFont = "3";
			public string showDishNumFont = "3";
		}

		protected void init()
		{
			string paramStr = getDanJuParam();

			if (!string.IsNullOrEmpty(paramStr))
			{
				JavaScriptSerializer serializer = new JavaScriptSerializer();
				try
				{
					param = (Param)serializer.Deserialize(paramStr.Replace('^', '"'), typeof(Param));
				}
				catch
				{
					initParam();
				}
			}
			else
				initParam();

			param.showZhuoTaiFont = param.showZhuoTaiFont == null ? "3" : param.showZhuoTaiFont;
			param.showDishFont = param.showDishFont == null ? "3" : param.showDishFont;
			param.showDishNumFont = param.showDishNumFont == null ? "3" : param.showDishNumFont;
		}

		protected string getDanJuParam()
		{
			return Common.getSystemConfig("ZhiZuoDan", "");
		}

		public void initParam()
		{
			param = new Param();

			param.selTemplate = "1";
			param.showChuCaiWay = true;
			param.showFootTaoCanDish = object.Equals(Common.getSystemConfig("IfPrintTCDishForFastFood", "1"), "1");
			param.showPeopleNumBigFont = object.Equals(Common.getSystemConfig("IsShowRenShuBigFontInZhiZuoDanJu", "1"), "1");
			param.showZhiZuoDanHuaDanHao = object.Equals(Common.getSystemConfig("UseHuaCaiNum", "0"), "1");
			param.showZhiZuoDanPrice = object.Equals(Common.getSystemConfig("IsShowPriceForZhiZuoDanJu", "0"), "1");
		}

	}
}
