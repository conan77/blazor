using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaDan
{
    public partial class frmDishTongJi : Form
    {
        public static double alertTime = 30;
        DateTime startTime = DateTime.Now;//餐别开始时间

        public frmDishTongJi()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadAllZhuoTaiDish();
        }

        private void LoadAllZhuoTaiDish()
        {
            try
            {
                startTime = Common.InitCanBie();

                string queryCondition = string.Empty;
                if (!string.IsNullOrEmpty(txtDishCondition.Text.Trim()))
                    queryCondition = " where (BaseDish.DishCode like '%" + txtDishCondition.Text.Trim() + "%' or BaseDish.DishName like '%" + txtDishCondition.Text.Trim() + "%' or BaseDish.QuickCode1 like '%" + txtDishCondition.Text.Trim() + "%'  ) ";

                string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
                if (!string.IsNullOrEmpty(strAlertTime))
                    alertTime = double.Parse(strAlertTime);

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
                    string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
                    string sqlYJS = string.Empty;
                    if ("1".Equals(showDishForFinishPay))
                    {
                        sqlYJS = " UNION ALL "
                               + " select ISNULL(pd.DishID,ztd.DishID) as DishID,ISNULL(pd.DishName,ztd.DishName) as DishName, "
                               + " case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end as DishNum  "
                               + " from HisOrderZhuoTaiDish ztd with(nolock) "
                               + " inner join HisOrderZhuoTai zt with(nolock) on zt.OrderID=ztd.OrderID "
                               + " left join HisOrderPackageDishDetail pd with(nolock) on ztd.UID=pd.OrderZhuoTaiDishID "
							   + " WHERE ztd.DishStatusID=1  AND IsHuaCai=0  AND ztd.StoreID=" + Tools.CurrentUser.StoreID + " AND ztd.SongDanTime>'" + startTime + "'  "
                               + " AND ztd.DishTypeID IN " + typeCondition + " AND (case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end)>0  AND ISNULL(pd.DishID,ztd.DishID) NOT IN " + dishCondition
                               + " AND zt.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
                               + " AND zt.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) ";
                    }

                    strSql = " select '' as '顺序',t.DishName as '菜品名称',sum(isnull(t.DishNum,0)) as '数量',t.DishID,BaseDish.DishCode,BaseDish.QuickCode1 from ( "
                               + " select ISNULL(pd.DishID,ztd.DishID) as DishID,ISNULL(pd.DishName,ztd.DishName) as DishName, "
                               + " case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end as DishNum  "
                               + " from OrderZhuoTaiDish ztd  with(nolock) "
                               + " inner join OrderZhuoTai zt with(nolock) on zt.OrderID=ztd.OrderID "
                               + " left join OrderPackageDishDetail pd with(nolock) on ztd.UID=pd.OrderZhuoTaiDishID "
							   + " WHERE ztd.DishStatusID=1  AND IsHuaCai=0   AND ztd.StoreID=" + Tools.CurrentUser.StoreID + " AND ztd.SongDanTime>'" + startTime + "'  "
                               + " AND ztd.DishTypeID IN " + typeCondition + " AND (case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end)>0  AND ISNULL(pd.DishID,ztd.DishID) NOT IN " + dishCondition
                               + " AND zt.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
                               + " AND zt.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
                               + " UNION ALL "
                               + " select ISNULL(pd.DishID,ztd.DishID) as DishID,ISNULL(pd.DishName,ztd.DishName) as DishName, "
                               + " case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end as DishNum  "
                               + " from OrderZhuoTaiDish ztd with(nolock) "
                               + " inner join OrderZhuoTai zt with(nolock) on zt.OrderID=ztd.OrderID "
                               + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=ztd.OrderID "
                               + " left join OrderPackageDishDetail pd with(nolock) on ztd.UID=pd.OrderZhuoTaiDishID "
							   + " WHERE ztd.DishStatusID=1  AND IsHuaCai=0   AND ztd.StoreID=" + Tools.CurrentUser.StoreID + " AND ztd.SongDanTime>'" + startTime + "'  "
                               + " AND ztd.DishTypeID IN " + typeCondition + " AND (case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end)>0  AND ISNULL(pd.DishID,ztd.DishID) NOT IN " + dishCondition
                               + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1   "
                               + " UNION ALL "
                               + " select ISNULL(pd.DishID,ztd.DishID) as DishID,ISNULL(pd.DishName,ztd.DishName) as DishName, "
                               + " case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end as DishNum  "
                               + " from HisOrderZhuoTaiDish ztd with(nolock) "
                               + " inner join HisOrderZhuoTai zt with(nolock) on zt.OrderID=ztd.OrderID "
                               + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=ztd.OrderID "
                               + " left join HisOrderPackageDishDetail pd with(nolock) on ztd.UID=pd.OrderZhuoTaiDishID "
							   + " WHERE ztd.DishStatusID=1  AND IsHuaCai=0   AND ztd.StoreID=" + Tools.CurrentUser.StoreID + " AND ztd.SongDanTime>'" + startTime + "'  "
                               + " AND ztd.DishTypeID IN " + typeCondition + " AND (case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end)>0  AND ISNULL(pd.DishID,ztd.DishID) NOT IN " + dishCondition
                               + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1   "
                               + sqlYJS
                               + " ) as t inner join BaseDish on BaseDish.UID=t.DishID "
                               + queryCondition
                               + " group by t.DishID,t.DishName,BaseDish.DishCode,BaseDish.QuickCode1  order by '数量' desc";
                }
                else if (qiantaiMode == 1) //快餐
                {
                    strSql = " select '' as '顺序',t.DishName  as '菜品名称',sum(isnull(t.DishNum,0)) as '数量',t.DishID, BaseDish.DishCode,BaseDish.QuickCode1 from ( "
                           + " select ISNULL(pd.DishID,ztd.DishID) as DishID,ISNULL(pd.DishName,ztd.DishName) as DishName, "
                           + " case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end as DishNum  "
                           + " from HisOrderZhuoTaiDish ztd  with(nolock) "
                           + " inner join HisOrderZhuoTai zt with(nolock) on zt.OrderID=ztd.OrderID "
                           + " left join HisOrderPackageDishDetail pd with(nolock) on ztd.UID=pd.OrderZhuoTaiDishID "
						   + " WHERE ztd.DishStatusID=1  AND IsHuaCai=0   AND ztd.StoreID=" + Tools.CurrentUser.StoreID + " AND ztd.SongDanTime>'" + startTime + "'  "
                           + " AND ztd.DishTypeID IN " + typeCondition + " AND (case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end)>0  AND ISNULL(pd.DishID,ztd.DishID) NOT IN " + dishCondition
                           + " AND zt.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
                           + " AND zt.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
                           + " UNION ALL "
                           + " select ISNULL(pd.DishID,ztd.DishID) as DishID,ISNULL(pd.DishName,ztd.DishName) as DishName, "
                           + " case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end as DishNum  "
                           + " from OrderZhuoTaiDish ztd with(nolock) "
                           + " inner join OrderZhuoTai zt with(nolock) on zt.OrderID=ztd.OrderID "
                           + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=ztd.OrderID "
                           + " left join OrderPackageDishDetail pd with(nolock) on ztd.UID=pd.OrderZhuoTaiDishID "
						   + " WHERE ztd.DishStatusID=1  AND IsHuaCai=0   AND ztd.StoreID=" + Tools.CurrentUser.StoreID + " AND ztd.SongDanTime>'" + startTime + "'  "
                           + " AND ztd.DishTypeID IN " + typeCondition + " AND (case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end)>0  AND ISNULL(pd.DishID,ztd.DishID) NOT IN " + dishCondition
                           + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1   "
                           + " UNION ALL "
                           + " select ISNULL(pd.DishID,ztd.DishID) as DishID,ISNULL(pd.DishName,ztd.DishName) as DishName, "
                           + " case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end as DishNum  "
                           + " from HisOrderZhuoTaiDish ztd with(nolock) "
                           + " inner join HisOrderZhuoTai zt with(nolock) on zt.OrderID=ztd.OrderID "
                           + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=ztd.OrderID "
                           + " left join HisOrderPackageDishDetail pd with(nolock) on ztd.UID=pd.OrderZhuoTaiDishID "
						   + " WHERE ztd.DishStatusID=1  AND IsHuaCai=0   AND ztd.StoreID=" + Tools.CurrentUser.StoreID + " AND ztd.SongDanTime>'" + startTime + "'  "
                           + " AND ztd.DishTypeID IN " + typeCondition + " AND (case when pd.DishNum is null then (ztd.DishNum+ztd.DishZengSongNum) else (pd.DishNum+pd.DishZengSongNum)*(ztd.DishNum+ztd.DishZengSongNum) end)>0  AND ISNULL(pd.DishID,ztd.DishID) NOT IN " + dishCondition
                           + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1   "
                           + " ) as t inner join BaseDish on BaseDish.UID=t.DishID "
                           + queryCondition
                           + " group by t.DishID,t.DishName,BaseDish.DishCode,BaseDish.QuickCode1  order by '数量' desc";

                }

                DataTable table = DBHelper.ExeSqlForDataTable(strSql);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["顺序"] = i + 1; 
                    table.Rows[i]["数量"] = table.Rows[i]["数量"] == null ? "0" : Convert.ToDecimal(table.Rows[i]["数量"]).ToString("0.00");
                }

                dgSource.DataSource = table;

                if (!object.Equals(table, null))
                {
                    //隐藏列
                    dgSource.Columns["DishID"].Visible = false;
                    dgSource.Columns["DishCode"].Visible = false;
                    dgSource.Columns["QuickCode1"].Visible = false;

                    //禁止点击表头排序
                    for (int i = 0; i < this.dgSource.Columns.Count; i++)
                    {
                        this.dgSource.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("frmDishTongJi LoadAllZhuoTaiDish 错误信息:" + ex.ToString());
            }
        }

        private void frmDishTongJi_Load(object sender, EventArgs e)
        {
            try
            {
                txtDishCondition.Clear();
                LoadAllZhuoTaiDish();

                dgSource.Columns[0].Width = 50;
                dgSource.Columns[1].Width = 275;
                dgSource.Columns[2].Width = 80;

                dgSource.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSource.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                Log.WriteLog("frmDishTongJi frmDishTongJi_Load 错误信息:"+ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDishCondition.Clear();
        }

    }
}
