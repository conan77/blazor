using HuaDan.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HuaDan
{
    public class Common
    {
        //系统参数集合
        private static Dictionary<string, object> systemParamList = new Dictionary<string, object>();

        public static string getSystemConfig(string configName, string defaultValue)
        {
            if (containsSystemParam(configName))
            {
                object param = getSystemParam(configName);
                if (!object.Equals(null, param))
                    return param.ToString();
            }

            var result = defaultValue;

            var sql = "SELECT * FROM BaseSystemConfig WHERE SystemConfigName = '" + configName + "'";
            var dataResult = DBHelper.ExeSqlForDataTable(sql);
            if (!object.Equals(null, dataResult))
            {
                var configs = ToDictionaryList(dataResult);

                if (configs.Count > 0)
                    result = configs[0]["SystemConfigValue"].ToString();
                else
                {
                    sql = "SELECT * FROM BaseSystemConfigDefault WHERE SystemConfigName = '" + configName + "'";
                    dataResult = DBHelper.ExeSqlForDataTable(sql);
                    if (!object.Equals(dataResult, null))
                    {
                        var configDefaults = ToDictionaryList(dataResult);

                        if (configDefaults.Count > 0)
                            result = configDefaults[0]["SystemConfigValue"].ToString();
                    }
                }
            }

            setSystemParam(configName, result);
            return result;
        }

        //本机设置config项集合
        public static bool containsSystemParam(string key)
        {
            return systemParamList.ContainsKey(key);
        }

        public static object getSystemParam(string key)
        {
            if (systemParamList.ContainsKey(key))
                return systemParamList[key];
            else
                return null;
        }

        public static void setSystemParam(string key, object value)
        {
            if (systemParamList.ContainsKey(key))
                systemParamList[key] = value;
            else
                systemParamList.Add(key, value);
        }

        public static List<Dictionary<string, object>> ToDictionaryList(DataTable dt)
        {
            var list = dt.Rows.Cast<DataRow>().Select(x =>
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn dc in dt.Columns)
                {
                    dict.Add(dc.ColumnName, x[dc.ColumnName]);
                }
                return dict;
            }).ToList();

            return list;
        }

        public static bool convertToBool(object o)
        {
            try
            {
                if (object.Equals(o, null))
                    return false;

                if (o is bool)
                    return (bool)o;
                else if (o.ToString().Trim().Equals("1") || o.ToString().Trim().ToUpper().Equals("TRUE"))
                    return true;

            }
            catch { }

            return false;
        }

        public static string decimalFormatter(decimal value, int precision)
        {
            var result = value.ToString("F" + precision).Replace(".".PadRight(precision + 1, '0'), "");
            if (result == "-0")
                result = "0";

            return result;
        }

        public static string decimalFormatter(double value, int precision)
        {
            var result = value.ToString("F" + precision).Replace(".".PadRight(precision, '0'), "");
            if (result == "-0")
                result = "0";

            return result;
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

        public static string getPrinterData(string printerID)
        {
            DataTable dtPrinter = DBHelper.ExeSqlForDataTable("SELECT * FROM BasePrinter WHERE UID='" + printerID + "' AND IsEnable = 1");
            if (dtPrinter == null || dtPrinter.Rows.Count <= 0)
                return string.Empty;
            else
                return dtPrinter.Rows[0]["Name"].ToString();
        }

        public static string CreateDB()
        {
            string strConn = ConfigurationManager.AppSettings["dbconn"];

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                string sql = " IF NOT EXISTS (select * from dbo.sysobjects where xtype='U' and Name = 'OrderHuaDan') " +
                             " BEGIN " +
                             " create table OrderHuaDan( " +
                             " UID          varchar(50) primary key , " +
                             " GroupID      int, " +
                             " StoreID      int, " +
                             " ZTDishUID    varchar(50), " +
                             " ZTName       varchar(50), " +
                             " XiaDanTime   datetime, " +
                             " QiangDanTime datetime, " +
                             " HuaDanTime   datetime, " +
                             " TotalNum     decimal(18,2), " +
                             " HuaDanNum    decimal(18,2), " +
                             " QiangDanUser varchar(50), " +
                             " IsEnable     bit, " +
                             " AddUser      varchar(50), " +
                             " AddTime      datetime, " +
                             " UpdateUser   varchar(50), " +
                             " UpdateTime   datetime, " +
                             " bak1         varchar(50), " +
                             " bak2         varchar(50), " +
                             " bak3         varchar(50) " +
                             " ); " +
                             " create table HisOrderHuaDan( " +
                             " UID          varchar(50) primary key , " +
                             " GroupID      int, " +
                             " StoreID      int, " +
                             " ZTDishUID    varchar(50), " +
                             " ZTName       varchar(50), " +
                             " XiaDanTime   datetime, " +
                             " QiangDanTime datetime, " +
                             " HuaDanTime   datetime, " +
                             " TotalNum     decimal(18,2), " +
                             " HuaDanNum    decimal(18,2), " +
                             " QiangDanUser varchar(50), " +
                             " IsEnable     bit, " +
                             " AddUser      varchar(50), " +
                             " AddTime      datetime, " +
                             " UpdateUser   varchar(50), " +
                             " UpdateTime   datetime, " +
                             " bak1         varchar(50), " +
                             " bak2         varchar(50), " +
                             " bak3         varchar(50)  " +
                             " ); " +
                             " END ";
                cmd.CommandText = sql;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    return "fail";
                }
            }

            return "success";
        }

		public static string CreatePartHuaDanDB()
		{
			string strConn = ConfigurationManager.AppSettings["dbconn"];

			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				string sql = " IF NOT EXISTS (select * from dbo.sysobjects where xtype='U' and Name = 'OrderHuaDanPart') " +
							 " BEGIN " +
							 " create table OrderHuaDanPart( " +
							 " UID          varchar(50) primary key , " +
							 " GroupID      int, " +
							 " StoreID      int, " +
							 " OrderID    varchar(50), " +
							 " OrderCode    varchar(50), " +
							 " ZTUID    varchar(50), " +
							 " ZTName       varchar(50), " +
							 " DishUID    varchar(50), " +
							 " DishID    varchar(50), " +
							 " DishName   nvarchar(200), " +
						     " HuaDanNum    decimal(18,2), " +
							 " UnitName nvarchar(16), "+
							 " IsPackage     bit, " +
							 " IsPackageDetail     bit, " +
							 " HuaDanTime      datetime, " +
							 " AddUser      varchar(50), " +
							 " AddTime      datetime, " +
							 " UpdateUser   varchar(50), " +
							 " UpdateTime   datetime " +
							 " ); " +
							 " END ";
				cmd.CommandText = sql;
				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
				catch (Exception ex)
				{
					return "fail";
				}
			}

			return "success";
		}

        public static void ajudgeLocalTimeBaseServer()
        {
            string strConn = ConfigurationManager.AppSettings["dbconn"];
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select GETDATE()";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                try
                {
                    conn.Open();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        SystemTimeManage.setSystemTime(Convert.ToDateTime(table.Rows[0][0]));
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static DateTime InitCanBie()
        {
            string strConn = ConfigurationManager.AppSettings["dbconn"];
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " select * from BaseCanBie where StoreID='" + Tools.CurrentUser.StoreID + "' and  IsEnable='1' order by SeqID asc";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                try
                {
                    conn.Open();
                    adapter.Fill(table);

                    List<BaseCanBie> canbieList = new List<BaseCanBie>();
                    canbieList = DBOperator.TableToList<BaseCanBie>(table);
                    if (canbieList.Count <= 0)
						return DateTimeFormat(DateTime.Now.AddDays(-1));

                    DateTime dtTmp = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd" + " " + canbieList[0].StartTime.ToString("HH:mm:ss")));
                    if (dtTmp.Ticks > DateTime.Now.Ticks)
                        dtTmp = dtTmp.AddDays(-1);
                    //return Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd" + " " + canbieList[0].StartTime.ToString("HH:mm:ss"))).AddSeconds(-1);
                    return DateTimeFormat(dtTmp);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("初始化餐别失败，失败原因:" + ex.Message);
                    return DateTimeFormat(DateTime.Now.AddDays(-1)) ;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

		public static DateTime DateTimeFormat(DateTime dt)
		{
		   return Convert.ToDateTime(dt.ToString("yyyy-MM-dd HH:mm:ss"));
		}

        /// <summary>
        /// 获取【当天】餐别的起始时间和结束时间
        /// </summary>
        /// <returns></returns>
        public static DateTimeModel GetCurrDayCanBie()
        {
            DateTimeModel dtResult = new DateTimeModel();

            string sql = "select * from BaseCanBie where IsEnable=1  and StoreID='" + Tools.CurrentUser.StoreID + "' ORDER BY SeqID asc ";
            DataTable table = DBHelper.ExeSqlForDataTable(sql);
            if (table.Rows.Count > 0)
            {
                dtResult.StartTime = DateTime.Now.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(table.Rows[0]["StartTime"].ToString()).ToString("HH:mm:ss");
                dtResult.EndTime = Convert.ToDateTime(dtResult.StartTime).AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
                if (DateTime.Now.Ticks <= Convert.ToDateTime(dtResult.StartTime).Ticks)
                {
                    dtResult.StartTime = Convert.ToDateTime(dtResult.StartTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
                    dtResult.EndTime = Convert.ToDateTime(dtResult.EndTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
                }
                dtResult.CanBieUID = table.Rows[0]["UID"].ToString();
            }

            return dtResult;
        }

		/// <summary>
		/// 获取【当前时间】所在的起始时间和结束时间
		/// </summary>
		/// <returns></returns>
		public static DateTimeModel GetCurrCanBie()
		{
			DateTime dtNow = DateTime.Now;
			DateTimeModel dtResult = new DateTimeModel();
			string sql = "select * from BaseCanBie where IsEnable=1  and StoreID='" + Tools.CurrentUser.StoreID + "' ORDER BY SeqID desc ";
			DataTable table = DBHelper.ExeSqlForDataTable(sql);
			for (int i = 0; i < table.Rows.Count; i++)
			{
				DateTime dtStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(table.Rows[i]["StartTime"].ToString()).ToString("HH:mm:ss"));
				DateTime dtEndTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(table.Rows[i]["EndTime"].ToString()).ToString("HH:mm:ss"));
				if (dtStartTime.Ticks < dtEndTime.Ticks)
				{
					if (dtStartTime.Ticks <= dtNow.Ticks && dtNow.Ticks <= dtEndTime.Ticks)
					{
						dtResult.StartTime = dtStartTime.ToString("yyyy-MM-dd HH:mm:ss");
						dtResult.EndTime = dtEndTime.ToString("yyyy-MM-dd HH:mm:ss");
						dtResult.CanBieUID = table.Rows[i]["UID"].ToString();
					}
				}
				else
				{
					dtStartTime = dtStartTime.AddDays(-1);
					if (dtStartTime.Ticks <= dtNow.Ticks && dtNow.Ticks <= dtEndTime.Ticks)
					{
						dtResult.StartTime = dtStartTime.ToString("yyyy-MM-dd HH:mm:ss");
						dtResult.EndTime = dtEndTime.ToString("yyyy-MM-dd HH:mm:ss");
						dtResult.CanBieUID = table.Rows[i]["UID"].ToString();
					}
					else
					{
						dtStartTime = dtStartTime.AddDays(1);
						dtEndTime = dtEndTime.AddDays(1);
						if (dtStartTime.Ticks <= dtNow.Ticks && dtNow.Ticks <= dtEndTime.Ticks)
						{
							dtResult.StartTime = dtStartTime.ToString("yyyy-MM-dd HH:mm:ss");
							dtResult.EndTime = dtEndTime.ToString("yyyy-MM-dd HH:mm:ss");
							dtResult.CanBieUID = table.Rows[i]["UID"].ToString();
						}
					}
				}
			}
			return dtResult;
		}

	    /// <summary>
	    /// 根据设置菜品类型和菜品筛选菜品 OR 当前选中菜品类型选中数据
	    /// </summary>
	    /// <param name="dishTypeID">设置选中的菜品类型</param>
	    /// <param name="dishID">设置非选中的菜品</param>
	    /// <param name="CurrDishTypeUID">当前菜品类型UID</param>
	    /// <returns></returns>
		public static List<BaseDishModel> GetAllDish(string dishTypeID, string dishID, string CurrDishTypeUID)
		{
			try
			{
				string condition = string.Empty;
				if (!string.IsNullOrEmpty(CurrDishTypeUID) && !CurrDishTypeUID.Equals("全部"))
				{
					condition= " and BaseDishType.UID='" + CurrDishTypeUID + "'";
				}

				string sql = " select BaseDish.UID as DishID,BaseDish.DishName,BaseDish.TypeID,BaseDish.UnitName "
                           + " from BaseDish "
                           + " inner join BaseDishType on BaseDishType.UID=BaseDish.TypeID "
						   + " where BaseDish.IsEnable=1 and BaseDishType.IsEnable=1 and BaseDish.IsPackage=0 " + condition;

				if (!string.IsNullOrEmpty(dishTypeID))
				{
					sql = sql + " and  BaseDishType.UID in " + dishTypeID;
				}

				if (!string.IsNullOrEmpty(dishID))
				{
					sql = sql + " and BaseDish.UID not in " + dishID;
				}

				sql = sql + " order by BaseDishType.PrintOrder,BaseDish.DisplayOrder ";
				DataTable table = DBHelper.ExeSqlForDataTable(sql);
				return EntityUtil.ToList<BaseDishModel>(table);
			}
			catch (Exception ex)
			{
				Log.WriteLog("GetAllDish 错误原因:"+ex.ToString());
				return new List<BaseDishModel>();
			}
		}

		/// <summary>
		/// 获取部分划单数据
		/// </summary>
		/// <returns></returns>
		public static List<OrderHuaDanPart> GetDishPartHuaDanData()
		{
			string sql = "select * from OrderHuaDanPart order by AddTime asc";
			return EntityUtil.ToList<OrderHuaDanPart>(DBHelper.ExeSqlForDataTable(sql));
		}

		/// <summary>
		/// 获取门店名称
		/// </summary>
		/// <returns></returns>
		public static string GetStoreName() 
		{
			string storeName = string.Empty;
			DataTable dt = DBHelper.ExeSqlForDataTable("select * from SysStoreInfo");
			if (!object.Equals(dt, null) && dt.Rows.Count > 0)
			{
				storeName = dt.Rows[0]["StoreName"].ToString();
			}

			return storeName;
		}

		public static string GetTMLCCondition()
		{
			string tmlcCondition = string.Empty;
			string strTMLC = ConfigurationManager.AppSettings["tmlc"];
			if (!object.Equals(strTMLC, null))
			{
				if (strTMLC.Contains(Constants.XUNILOUCENG))
				{
					string str = string.Empty;
					string[] arr = strTMLC.Split(',');
					for (int i = 0; i < arr.Count(); i++)
					{
						if (!arr[i].Equals(Constants.XUNILOUCENG))
						{
							str = str + (string.IsNullOrEmpty(str) ? arr[i] : ("," + arr[i]));
						}
					}

					tmlcCondition = " and (tmlc.UID in ('" + str.Replace(",", "','") + "') or orderzt.ZhuoTaiID='')";
				}
				else
				{
					tmlcCondition = " and tmlc.UID in ('" + strTMLC.Replace(",", "','") + "')";
				}
			}

			return tmlcCondition;
		}
    }
}
