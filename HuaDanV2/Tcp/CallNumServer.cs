using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace HuaDan
{
    public class CallNumServer
    {
        private static CallNumServer _instance = null;
        private TcpServer tcpServer;

        public static CallNumServer getInstance()
        {
            if (object.Equals(null, _instance))
            {
                _instance = new CallNumServer();
            }

            return _instance;
        }

        private CallNumServer()
        {
            int port = 35255;
            string CallNumPort = ConfigurationManager.AppSettings["CallNumPort"];
            if (string.IsNullOrEmpty(CallNumPort))
            {
                CallNumPort = "35255";
            }
            int.TryParse(CallNumPort, out port);
            tcpServer = new TcpServer(port);
            tcpServer.RecvData += CallNumServer_RecvData;
        }

        static void CallNumServer_RecvData(object sender, NetEventArgs e)
        {
            //var str = System.Text.Encoding.GetEncoding("GB18030").GetString(e.Client.Datagram).Trim('\0');
            //this.Send(e.Client, System.Text.Encoding.GetEncoding("GB18030").GetBytes("收到：" + str));
            //_instance.sendBeiCanData();

            //sendBeiCanData();
        }

        public static void Start()
        {
            string CallNumPort = ConfigurationManager.AppSettings["IsStartCallNumServer"];
            if (!string.IsNullOrEmpty(CallNumPort) && "1".Equals(CallNumPort))
            {
                CallNumServer.getInstance().startServer();
            }
        }

        public static void Stop()
        {
            if (!object.Equals(null, _instance))
            {
                CallNumServer.getInstance().stopServer();
                _instance = null;
            }
        }

        public void startServer()
        {
            tcpServer.Start();
        }

        public void stopServer()
        {
            try
            {
                tcpServer.Stop();
            }
            catch (Exception ex)
            {
                Log.WriteLog("CallNumServer stopServer():\r\n" + ex.ToString());
            }
        }

        public void sendData(string content)
        {
            var cloneList = (Hashtable)tcpServer.SessionTable.Clone();
            foreach (Object session in cloneList.Values)
            {
                tcpServer.Send(session as Session, System.Text.Encoding.GetEncoding("GB18030").GetBytes(content));
            }
        }

        public static bool sendJiaoHaoRecord(string recordID)
        {
            try
            {
                if (object.Equals(null, _instance))
                    return false;

                //Log.WriteLog("recordID=" + recordID);
                string strSql = " SELECT * FROM JiaoHaoRecord WHERE UID = '" + recordID + "'";
                var dtRecord = DBHelper.ExeSqlForDataTable(strSql);
                var jsonContent = "";
                if (dtRecord.Rows.Count > 0)
                    jsonContent = JSONConvert.ToJsonString(new { JiaoHaoRecord = JSONConvert.ToDictionary(dtRecord.Rows[0]) });

                if (!string.IsNullOrEmpty(jsonContent))
                {
                    CallNumServer.getInstance().sendData(jsonContent);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("CallNumServer sendJiaoHaoRecord():\r\n" + ex.ToString());
                return false;
            }
            return true;
        }

        public static void sendBeiCanData(bool isConnectCallNumServer)
        {
            try
            {
                string CallNumPort = ConfigurationManager.AppSettings["IsStartCallNumServer"];
                if (string.IsNullOrEmpty(CallNumPort))
                    return;
                if ("0".Equals(CallNumPort))
                    return;

                if (object.Equals(null, _instance))
                    return;

                //DateTime startTime = getNowCanBieBeginTime();
                //DateTime endTime = startTime.AddDays(1).AddSeconds(-1);
                //string startTimeTmp = startTime.ToString("yyyy-MM-dd") + "T" + startTime.ToString("HH:mm:ss");
                //string endTimeTmp = endTime.ToString("yyyy-MM-dd") + "T" + endTime.ToString("HH:mm:ss");

                DateTime startTime = Common.InitCanBie();

                int qiantaiMode = 0;

                string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

                if (!string.IsNullOrEmpty(strQiantaiMode))
                    qiantaiMode = int.Parse(strQiantaiMode);

                string strDishTypes = ConfigurationManager.AppSettings["dishtypes"];
                string strDishes = ConfigurationManager.AppSettings["dishes"];

                string typeCondition = "";
                string dishCondition = "";

                if (string.IsNullOrEmpty(strDishTypes))
                    typeCondition = "('')";
                else
                    typeCondition = "('" + strDishTypes.Replace(",", "','") + "')";

                if (string.IsNullOrEmpty(strDishes))
                    dishCondition = "('')";
                else
                    dishCondition = "('" + strDishes.Replace(",", "','") + "')";

                string strSql = "";
                if (qiantaiMode == 0)  //中餐
                {
                    strSql = " SELECT UID,OrderID,ZhuoTaiName FROM ( "
                           + " SELECT OrderZhuoTai.UID,OrderZhuoTai.OrderID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime "
                           + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
                           + " INNER JOIN OrderInfo with(nolock) ON OrderInfo.UID=OrderZhuoTai.OrderID  "
                           + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
                           + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
                           + " AND OrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
                           + " AND OrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' )  "
                           + " AND  OrderZhuoTai.OrderID NOT IN (SELECT  OrderID FROM JiaoHaoRecord WHERE  OrderZhuoTaiDishUID = '' AND IsCallNumber <> 0) "
                           + " UNION  "
                           + " SELECT OrderZhuoTai.UID,OrderZhuoTai.OrderID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime "
                           + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
                           + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
                           + " INNER JOIN OrderInfo with(nolock) ON OrderInfo.UID=OrderZhuoTai.OrderID  "
                           + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
                           + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
                           + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1  "
                           + " AND  OrderZhuoTai.OrderID NOT IN (SELECT  OrderID FROM JiaoHaoRecord WHERE  OrderZhuoTaiDishUID = '' AND IsCallNumber <> 0) "
                           + " UNION  "
                           + " SELECT HisOrderZhuoTai.UID,HisOrderZhuoTai.OrderID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime  "
                           + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
                           + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
                           + " INNER JOIN HisOrderInfo with(nolock) ON HisOrderInfo.UID=HisOrderZhuoTai.OrderID  "
                           + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0 AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
                           + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
                           + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1  "
                           + " AND  HisOrderZhuoTai.OrderID NOT IN (SELECT  OrderID FROM JiaoHaoRecord WHERE  OrderZhuoTaiDishUID = '' AND IsCallNumber <> 0) "
                           + " ) as t ORDER BY t.AddTime asc ";
                }
                else if (qiantaiMode == 1) //快餐
                {
                    strSql = " SELECT UID,OrderID,ZhuoTaiName FROM( "
                           + " SELECT HisOrderZhuoTai.UID,HisOrderZhuoTai.OrderID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime  "
                           + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
                           + " INNER JOIN HisOrderInfo with(nolock) ON HisOrderInfo.UID=HisOrderZhuoTai.OrderID "
                           + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
                           + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
                           + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
                           + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' )  "
                           + " AND  HisOrderZhuoTai.OrderID NOT IN (SELECT  OrderID FROM JiaoHaoRecord WHERE  OrderZhuoTaiDishUID = '' AND IsCallNumber <> 0) "
                           + " UNION  "
                           + " SELECT OrderZhuoTai.UID,OrderZhuoTai.OrderID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime "
                           + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
                           + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
                           + " INNER JOIN OrderInfo with(nolock) on OrderInfo.UID=OrderZhuoTai.OrderID "
                           + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
                           + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
                           + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1   "
                           + " AND  OrderZhuoTai.OrderID NOT IN (SELECT  OrderID FROM JiaoHaoRecord WHERE  OrderZhuoTaiDishUID = '' AND IsCallNumber <> 0) "
                           + " UNION  "
                           + " SELECT HisOrderZhuoTai.UID,HisOrderZhuoTai.OrderID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime  "
                           + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
                           + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
                           + " INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID=HisOrderZhuoTai.OrderID "
                           + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
                           + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
                           + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1    "
                           + " AND  HisOrderZhuoTai.OrderID NOT IN (SELECT  OrderID FROM JiaoHaoRecord WHERE  OrderZhuoTaiDishUID = '' AND IsCallNumber <> 0) "
                           + " ) as t ORDER BY t.AddTime asc ";
                }

                var dtRecord = DBHelper.ExeSqlForDataTable(strSql);
                var jsonContent = "";

                if (dtRecord.Rows.Count > 0)
                    jsonContent = JSONConvert.ToJsonString(new { BeiCan = Common.ToDictionaryList(dtRecord) });

                if (SetZhuoTai(dtRecord) || isConnectCallNumServer)
                    CallNumServer.getInstance().sendData(jsonContent);

            }
            catch (Exception ex)
            {
                Log.WriteLog("CallNumServer sendBeiCanData():\r\n" + ex.ToString());
            }
        }

        /// <summary>
        /// 设置备餐区待叫号桌台
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public static bool SetZhuoTai(DataTable dtRecord)
        {
            if (dtRecord.Rows.Count > 0)
            {
                List<string> list = new List<string>();
                if (object.Equals(ZTTools.ZhuoTaiUIDList, null))
                {
                    for (int i = 0; i < dtRecord.Rows.Count; i++)
                    {
                        list.Add(dtRecord.Rows[i]["UID"].ToString());
                    }

                    ZTTools.ZhuoTaiUIDList = list;
                    return true;
                }
                else
                {
                    if (ZTTools.ZhuoTaiUIDList.Count == dtRecord.Rows.Count)
                    {
                        bool flag = true;
                        for (int i = 0; i < dtRecord.Rows.Count; i++)
                        {
                            if (!ZTTools.ZhuoTaiUIDList.Contains(dtRecord.Rows[i]["UID"].ToString()))
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (!flag)
                        {
                            ZTTools.ZhuoTaiUIDList.Clear();
                            for (int i = 0; i < dtRecord.Rows.Count; i++)
                            {
                                list.Add(dtRecord.Rows[i]["UID"].ToString());
                            }
                            ZTTools.ZhuoTaiUIDList = list;
                            return true;
                        }
                    }
                    else {
                        ZTTools.ZhuoTaiUIDList.Clear();
                        for (int i = 0; i < dtRecord.Rows.Count; i++)
                        {
                            list.Add(dtRecord.Rows[i]["UID"].ToString());
                        }
                        ZTTools.ZhuoTaiUIDList = list;
                        return true;
                    }
                }
            }
            return false;
        }

        public static void SetCallNumber(string uid)
        {
            try
            {
                string sqlOrderID = " SELECT OrderZhuoTai.OrderID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTaiDish.UID,OrderZhuoTaiDish.OrderZhuoTaiID,OrderZhuoTaiDish.DishName  "
                                  + " FROM OrderZhuoTaiDish with(nolock) INNER JOIN OrderZhuoTai  with(nolock)  on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
                                  + " WHERE OrderZhuoTaiDish.UID='" + uid + "' "
                                  + " UNION  "
                                  + " SELECT HisOrderZhuoTai.OrderID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTaiDish.UID,HisOrderZhuoTaiDish.OrderZhuoTaiID,HisOrderZhuoTaiDish.DishName "
                                  + " FROM HisOrderZhuoTaiDish  with(nolock)   INNER JOIN HisOrderZhuoTai  with(nolock)  on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
                                  + " WHERE HisOrderZhuoTaiDish.UID='" + uid + "'";
                DataTable orderSource = DBHelper.ExeSqlForDataTable(sqlOrderID);
                if (orderSource.Rows.Count <= 0)
                {
                    Log.WriteLog("SetCallNumber uid=" + uid + ",未找到数据！");
                    return;
                }

                string orderID = orderSource.Rows[0]["OrderID"].ToString();
                string ZhuoTaiName = orderSource.Rows[0]["ZhuoTaiName"].ToString();
                string DishName = orderSource.Rows[0]["DishName"].ToString();

                string sql = "SELECT * FROM JiaoHaoRecord WHERE OrderZhuoTaiDishUID='" + uid + "' AND OrderID='" + orderID + "'";
                DataTable table = DBHelper.ExeSqlForDataTable(sql);
                string JiaoHaoRecordUID = string.Empty;
                string sqlJiaoHao = string.Empty;
                if (table.Rows.Count <= 0)
                {
                    JiaoHaoRecordUID = Guid.NewGuid().ToString("N");
                    sqlJiaoHao = " INSERT INTO JiaoHaoRecord(UID, StoreID,OrderID,ZTName,OrderZhuoTaiDishUID " +
                                   " ,DishName,Memo,Count,IsCallNumber,AddUser,AddTime,UpdateUser,UpdateTime) " +
                                   " VALUES('" + JiaoHaoRecordUID + "', " + Tools.CurrentUser.StoreID + ",'" + orderID + "','" + ZhuoTaiName + "' " +
                                   " , '" + uid + "','" + DishName + "','',1,1,'" + Tools.CurrentUser.UID + "' " +
                                   " ,'" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "','" + Tools.CurrentUser.UID + "','" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "') ";
                }
                else
                {
                    JiaoHaoRecordUID = table.Rows[0]["UID"].ToString();
                    sqlJiaoHao = " Update JiaoHaoRecord set Count=Count+1,UpdateUser='" + Tools.CurrentUser.UID + "',UpdateTime='" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "' where UID='" + JiaoHaoRecordUID + "'";
                }

                if (DBHelper.ExecuteNonQuery(sqlJiaoHao))
                {
                    sendJiaoHaoRecord(JiaoHaoRecordUID);
                }
                else
                {
                    Log.WriteLog("SetCallNumber 数据操作错误，sql=" + sqlJiaoHao);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("SetCallNumber 叫号失败,uid=" + uid + "错误原因: " + ex.ToString());
            }
        }

		public static void SetCallNumberForZhengZhuo(string orderid)
		{
			try
			{
				string sqlOrderID = " SELECT OrderZhuoTai.OrderID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTaiDish.UID,OrderZhuoTaiDish.OrderZhuoTaiID,OrderZhuoTaiDish.DishName  "
									 + " FROM OrderZhuoTaiDish with(nolock) INNER JOIN OrderZhuoTai  with(nolock)  on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
									 + " WHERE OrderZhuoTai.OrderID='" + orderid + "' "
									 + " UNION  "
									 + " SELECT HisOrderZhuoTai.OrderID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTaiDish.UID,HisOrderZhuoTaiDish.OrderZhuoTaiID,HisOrderZhuoTaiDish.DishName "
									 + " FROM HisOrderZhuoTaiDish  with(nolock)   INNER JOIN HisOrderZhuoTai  with(nolock)  on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
									 + " WHERE HisOrderZhuoTai.OrderID='" + orderid + "'";
				DataTable orderSource = DBHelper.ExeSqlForDataTable(sqlOrderID);
				if (orderSource.Rows.Count <= 0)
				{
					Log.WriteLog("SetCallNumberForZhengZhuo orderid=" + orderid + ",未找到数据！");
					return;
				}

				string orderID = orderSource.Rows[0]["OrderID"].ToString();
				string ZhuoTaiName = orderSource.Rows[0]["ZhuoTaiName"].ToString();

				string sql = "select * from JiaoHaoRecord where OrderID='" + orderid + "' and OrderZhuoTaiDishUID='' and IsCallNumber=1";
				DataTable table = DBHelper.ExeSqlForDataTable(sql);
				string JiaoHaoRecordUID = string.Empty;
				string sqlJiaoHao = string.Empty;
				if (table.Rows.Count <= 0)
				{
					JiaoHaoRecordUID = Guid.NewGuid().ToString("N");
					sqlJiaoHao = " INSERT INTO JiaoHaoRecord(UID,StoreID,OrderID,OrderZhuoTaiDishUID,ZTName,DishName,IsCallNumber,Count,Memo,AddUser,AddTime,UpdateUser,UpdateTime) " +
								   " VALUES('" + JiaoHaoRecordUID + "', " + Tools.CurrentUser.StoreID + ",'" + orderid + "','','" + ZhuoTaiName + "','', " +
								   " 1,1,'','" + Tools.CurrentUser.UID + "' ,'" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "','" + Tools.CurrentUser.UID + "','" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "')";
				}
				else
				{
					JiaoHaoRecordUID = table.Rows[0]["UID"].ToString();
					sqlJiaoHao = " Update JiaoHaoRecord set UpdateUser='" + Tools.CurrentUser.UID + "',UpdateTime='" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "',Count=Count+1 where UID='" + JiaoHaoRecordUID + "'";
				}

				if (DBHelper.ExecuteNonQuery(sqlJiaoHao))
				{
					sendJiaoHaoRecord(JiaoHaoRecordUID);
				}
				else
				{
					Log.WriteLog("SetCallNumberForZhengZhuo 数据操作错误，sql=" + sqlJiaoHao);
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("SetCallNumberForZhengZhuo 整桌叫号失败,orderid=" + orderid + "错误原因: " + ex.ToString());
			}
		}

        public static DateTime getNowCanBieBeginTime()
        {
            var date = DateTime.Today;
            var strSql = "SELECT * FROM BaseCanBie Where IsEnable = 1 ORDER BY SeqID";
            var dtCanBies = DBHelper.ExeSqlForDataTable(strSql);

            if (dtCanBies.Rows.Count <= 0)//未设置餐别
                return date;

            var result = DateTime.Parse(date.ToString("yyyy-MM-dd") + "T" + DateTime.Parse(dtCanBies.Rows[0]["StartTime"].ToString()).ToString("HH:mm:ss"));
            if (result.CompareTo(DateTime.Now) > 0)
                result = DateTime.Parse(date.AddDays(-1).ToString("yyyy-MM-dd") + "T" + DateTime.Parse(dtCanBies.Rows[0]["StartTime"].ToString()).ToString("HH:mm:ss"));
            return result;
        }
    }
}
