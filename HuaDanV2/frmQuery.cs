using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaDan
{
    public partial class frmQuery : Form
    {
        int qiantaiMode = 0; //前台模式：中餐、快餐
        string FrmName = string.Empty;
        public frmQuery(string paramFrmName)
        {
            InitializeComponent();
            FrmName = paramFrmName;
        }

        private void frmQuery_Load(object sender, EventArgs e)
        {
            setOemInfo();
            string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"]; //前台模式:中餐、快餐
            if (!string.IsNullOrEmpty(strQiantaiMode))
                qiantaiMode = int.Parse(strQiantaiMode);

            dt = new DataTable();
            Clear();
            LoadHuaDanInfo();
            Init();

            try
            {
                if (!object.Equals(dgSource.Columns["UID"], null))
                {
                    //隐藏列
                    dgSource.Columns["UID"].Visible = false;
                    dgSource.Columns["OrderZhuoTaiDishID"].Visible = false;
                    dgSource.Columns["OrderZhuoTaiID"].Visible = false;

                    //禁止点击表头排序
                    for (int i = 0; i < this.dgSource.Columns.Count; i++)
                    {
                        this.dgSource.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                dgSource.Columns[0].Width = 100;
                dgSource.Columns[2].Width = 150;//订单号
                dgSource.Columns[3].Width = 100;//桌台名称
                dgSource.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSource.Columns[4].Width = 180;//菜品名称
                dgSource.Columns[5].Width = 80; //数量
                dgSource.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgSource.Columns[6].Width = 80;  //单位
                dgSource.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSource.Columns[7].Width = 80;  //是否套餐
                dgSource.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSource.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSource.Columns[9].Width = 150;
				dgSource.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public int currPage = 1;

        public Dictionary<string, DateTime> GetCurrentCanBie()
        {
            try
            {
                string sql = " select * From BaseCanBie order by SeqID   ";
                DataTable table = DBHelper.ExeSqlForDataTable(sql);
                if (table.Rows.Count > 0)
                {
                    Int64 curDt = DateTime.Now.Ticks;
                    DateTime starttimeTmp = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(table.Rows[0]["StartTime"].ToString()).ToString("HH:mm:ss"));
                    DateTime endtimeTmp = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(table.Rows[table.Rows.Count - 1]["StartTime"].ToString()).ToString("HH:mm:ss"));

                    if (starttimeTmp.Ticks > curDt)
                    {
                        Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
                        dic.Add("StartTime", endtimeTmp.AddDays(-1));
                        dic.Add("EndTime", starttimeTmp.AddSeconds(-1));
                        return dic;
                    }

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DateTime starttime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(table.Rows[i]["StartTime"].ToString()).ToString("HH:mm:ss"));
                        DateTime endtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Parse(table.Rows[i]["EndTime"].ToString()).ToString("HH:mm:ss"));
                        if (starttime.Ticks > endtime.Ticks)
                        {
                            endtime = endtime.AddDays(1);
                        }
                        if (starttime.Ticks <= curDt && curDt <= endtime.Ticks)
                        {
                            Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
                            dic.Add("StartTime", starttime);
                            dic.Add("EndTime", endtime);
                            return dic;
                        }
                    }
                }
                Dictionary<string, DateTime> dic1 = new Dictionary<string, DateTime>();
                dic1.Add("StartTime", DateTime.Now.AddDays(2));
                dic1.Add("EndTime", DateTime.Now.AddDays(2).AddSeconds(1));
                return dic1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取当前餐别失败！");
                return new Dictionary<string, DateTime>();
            }
        }

        public void LoadHuaDanInfo()
        {
            DataTable table = new DataTable();
            Dictionary<string, DateTime> dic = GetCurrentCanBie();
            if (dic.Count <= 0)
                return;

            string condition = string.Empty;
            if (!string.IsNullOrEmpty(txtOrderCode.Text.Trim()))
                condition = " AND oi.OrderCode like '%" + txtOrderCode.Text.Trim() + "%' ";
            if (!string.IsNullOrEmpty(txtZhuoTai.Text.Trim()))
                condition += " AND zt.ZhuoTaiName like '%" + txtZhuoTai.Text.Trim() + "%' ";
            if (!string.IsNullOrEmpty(txtDish.Text.Trim()))
                condition += " AND (bd.DishCode LIKE '%" + txtDish.Text.Trim() + "%' "
                         + " OR bd.DishName LIKE '%" + txtDish.Text.Trim() + "%' "
                         + " OR bd.QuickCode1 LIKE '%" + txtDish.Text.Trim() + "%' "
                         + " OR bd.BarCode = '" + txtDish.Text.Trim() + "' )";

            string strHDH = string.Empty;
            if (!string.IsNullOrEmpty(txtHuaDanHao.Text.Trim()))
                strHDH = " and ztdish.HuaCaiNum='" + txtHuaDanHao.Text.Trim() + "' ";
            string strHDHDetail = string.Empty;
            if (!string.IsNullOrEmpty(txtHuaDanHao.Text.Trim()))
                strHDHDetail = " and detail.HuaCaiNum='" + txtHuaDanHao.Text.Trim() + "' ";

            string sql = "";
            if (qiantaiMode == 0)
            {
                 string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
                 if ("1".Equals(showDishForFinishPay))
                 {
                     sql = " select UID,OrderCode as 订单号,ZTName as 桌台名称,DishName as 品项名称,DishNum as 数量,UnitName as 单位,case when IsPackage=1 then '是' else '否' end as 是否套餐,IsPackageDetail as 是否套餐内菜品,UpdateTime as 划单时间,OrderZhuoTaiDishID,OrderZhuoTaiID " +
                             " From ( SELECT ztdish.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,ztdish.DishName,ztdish.DishNum,ztdish.UnitName,ztdish.IsPackage,'否' as IsPackageDetail,DATEADD(second,1,ztdish.UpdateTime) as UpdateTime,'' as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                             " FROM OrderInfo oi " +
                             " INNER JOIN OrderZhuoTai zt on oi.UID=zt.OrderID " +
                             " INNER JOIN OrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                             " INNER JOIN BaseDish bd on bd.UID=ztdish.DishID " +
                             " WHERE ztdish.DishNum>0 AND ztdish.IsHuaCai=1 AND ztdish.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDH +
                             " UNION " +
                             " SELECT detail.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,detail.DishName,detail.DishNum,detail.UnitName,1 as IsPackage,'是' as IsPackageDetail,detail.UpdateTime,detail.OrderZhuoTaiDishID as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                             " FROM OrderInfo oi " +
                             " INNER JOIN OrderZhuoTai zt on oi.UID=zt.OrderID " +
                             " INNER JOIN OrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                             " INNER JOIN OrderPackageDishDetail detail on detail.OrderZhuoTaiDishID=ztdish.UID " +
                             " INNER JOIN BaseDish bd on bd.UID=detail.DishID " +
                             " WHERE detail.IfHuaCai=1 and  detail.DishNum>0 and detail.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDHDetail +
                             " UNION "+
                             " SELECT ztdish.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,ztdish.DishName,ztdish.DishNum,ztdish.UnitName,ztdish.IsPackage,'否' as IsPackageDetail,DATEADD(second,1,ztdish.UpdateTime) as UpdateTime,'' as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                             " FROM HisOrderInfo oi " +
                             " INNER JOIN HisOrderZhuoTai zt on oi.UID=zt.OrderID " +
                             " INNER JOIN HisOrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                             " INNER JOIN BaseDish bd on bd.UID=ztdish.DishID " +
                             " WHERE ztdish.DishNum>0 AND ztdish.IsHuaCai=1 AND ztdish.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDH +
                             " UNION " +
                             " SELECT detail.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,detail.DishName,detail.DishNum,detail.UnitName,1 as IsPackage,'是' as IsPackageDetail,detail.UpdateTime,detail.OrderZhuoTaiDishID as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                             " FROM HisOrderInfo oi " +
                             " INNER JOIN HisOrderZhuoTai zt on oi.UID=zt.OrderID " +
                             " INNER JOIN HisOrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                             " INNER JOIN HisOrderPackageDishDetail detail on detail.OrderZhuoTaiDishID=ztdish.UID " +
                             " INNER JOIN BaseDish bd on bd.UID=detail.DishID " +
                             " WHERE detail.IfHuaCai=1 and  detail.DishNum>0 and detail.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDHDetail +
                             " ) s order by UpdateTime desc";
                 }
                 else
                 {
                     //中餐
                     sql = " select UID,OrderCode as 订单号,ZTName as 桌台名称,DishName as 品项名称,DishNum as 数量,UnitName as 单位,case when IsPackage=1 then '是' else '否' end as 是否套餐,IsPackageDetail as 是否套餐内菜品,UpdateTime as 划单时间,OrderZhuoTaiDishID,OrderZhuoTaiID " +
                           " From ( SELECT ztdish.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,ztdish.DishName,ztdish.DishNum,ztdish.UnitName,ztdish.IsPackage,'否' as IsPackageDetail,DATEADD(second,1,ztdish.UpdateTime) as UpdateTime,'' as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                           " FROM OrderInfo oi " +
                           " INNER JOIN OrderZhuoTai zt on oi.UID=zt.OrderID " +
                           " INNER JOIN OrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                           " INNER JOIN BaseDish bd on bd.UID=ztdish.DishID " +
                           " WHERE ztdish.DishNum>0 AND ztdish.IsHuaCai=1 AND ztdish.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDH +
                           " UNION " +
                           " SELECT detail.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,detail.DishName,detail.DishNum,detail.UnitName,1 as IsPackage,'是' as IsPackageDetail,detail.UpdateTime,detail.OrderZhuoTaiDishID as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                           " FROM OrderInfo oi " +
                           " INNER JOIN OrderZhuoTai zt on oi.UID=zt.OrderID " +
                           " INNER JOIN OrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                           " INNER JOIN OrderPackageDishDetail detail on detail.OrderZhuoTaiDishID=ztdish.UID " +
                           " INNER JOIN BaseDish bd on bd.UID=detail.DishID " +
                           " WHERE detail.IfHuaCai=1 and  detail.DishNum>0 and detail.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDHDetail +
                           " ) s order by UpdateTime desc";
                 }
            }
            else
            {
                //快餐
                sql = " select UID,OrderCode as 订单号,ZTName as 桌台名称,DishName as 品项名称,DishNum as 数量,UnitName as 单位,case when IsPackage=1 then '是' else '否' end as 是否套餐,IsPackageDetail as 是否套餐内菜品,UpdateTime as 划单时间,OrderZhuoTaiDishID,OrderZhuoTaiID " +
                             " From ( SELECT ztdish.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,ztdish.DishName,ztdish.DishNum,ztdish.UnitName,ztdish.IsPackage,'否' as IsPackageDetail,DATEADD(second,1,ztdish.UpdateTime) as UpdateTime,'' as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                             " FROM HisOrderInfo oi " +
                             " INNER JOIN HisOrderZhuoTai zt on oi.UID=zt.OrderID " +
                             " INNER JOIN HisOrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                             " INNER JOIN BaseDish bd on bd.UID=ztdish.DishID " +
                             " WHERE ztdish.DishNum>0 AND ztdish.IsHuaCai=1 AND ztdish.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDH +
                             " UNION " +
                             " SELECT detail.UID,oi.OrderCode,zt.ZhuoTaiName as ZTName,detail.DishName,detail.DishNum,detail.UnitName,1 as IsPackage,'是' as IsPackageDetail,detail.UpdateTime,detail.OrderZhuoTaiDishID as OrderZhuoTaiDishID,ztdish.OrderZhuoTaiID " +
                             " FROM HisOrderInfo oi " +
                             " INNER JOIN HisOrderZhuoTai zt on oi.UID=zt.OrderID " +
                             " INNER JOIN HisOrderZhuoTaiDish ztdish on zt.UID= ztdish.OrderZhuoTaiID " +
                             " INNER JOIN HisOrderPackageDishDetail detail on detail.OrderZhuoTaiDishID=ztdish.UID " +
                             " INNER JOIN BaseDish bd on bd.UID=detail.DishID " +
                             " WHERE detail.IfHuaCai=1 and  detail.DishNum>0 and detail.UpdateTime BETWEEN '" + dic["StartTime"] + "' AND '" + dic["EndTime"] + "' " + condition + strHDHDetail +
                             " ) s order by UpdateTime desc";
            }

            dt = DBHelper.ExeSqlForDataTable(sql);
        }

        public void Clear()
        {
            txtOrderCode.Clear();
            txtDish.Clear();
            txtHuaDanHao.Clear();
            txtZhuoTai.Clear();
        }

        DataTable dt;
        public void BindDataSource()
        {
            lblPage.Text = "共1页，当前第1页";
            if (dt.Rows.Count <= 0)
            {
                dgSource.DataSource = dt;
                return;
            }

            DataTable curTable = dt.Clone();
            if (currPage == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        DataRow newRow = curTable.NewRow();
                        curTable.Rows.Add(newRow);
                        for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                        {
                            newRow[j] = dt.Rows[i][j];
                        }
                    }
                }
            }
            else
            {
                for (int i = (currPage - 1) * 10; i < currPage * 10; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        DataRow newRow = curTable.NewRow();
                        curTable.Rows.Add(newRow);
                        for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                        {
                            newRow[j] = dt.Rows[i][j];
                        }
                    }
                }
            }
            dgSource.DataSource = curTable;

            lblPage.Text = "共" + (dt.Rows.Count == 0 ? "1" : Math.Ceiling((double)dt.Rows.Count / 10).ToString()) + "页，当前第" + currPage + "页";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadHuaDanInfo();
            Init();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #region //取消划单【套餐全部取消】【单个菜品取消】【整桌取消】
        private void dgSource_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                if (e.ColumnIndex == dgSource.Columns[0].Index)
                {
                    string UID = dt.Rows[e.RowIndex]["UID"].ToString();
                    string DishName = dt.Rows[e.RowIndex]["品项名称"].ToString();
                    string IsPackage = dt.Rows[e.RowIndex]["是否套餐"].ToString();
                    string IsPackageDetail = dt.Rows[e.RowIndex]["是否套餐内菜品"].ToString();
                    string OrderZhuoTaiDishID = dt.Rows[e.RowIndex]["OrderZhuoTaiDishID"].ToString();

                    StringBuilder builder = new StringBuilder();
                    if (string.Equals(IsPackage, "是") && string.Equals(IsPackageDetail, "否")) //套餐 总名称
                    {
                        DialogResult dr = MessageBox.Show("套餐菜品是否全部取消划单？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                          
                                builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n")
                                       .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UID + "' ").Append("\r\n");
                            
                                builder.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n")
                                 .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UID + "' ").Append("\r\n");

                        }
                    }
                    else if (string.Equals(IsPackage, "否") && string.Equals(IsPackageDetail, "否"))//非套餐菜品
                    {
                        DialogResult dr = MessageBox.Show("是否取消【" + DishName + "】划单？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            
                                builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n");
                            
                                builder.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n");
                        }
                    }
                    else if (string.Equals(IsPackage, "是") && string.Equals(IsPackageDetail, "是"))//套餐明细菜品
                    {
                        DialogResult dr = MessageBox.Show("是否取消套餐内菜品名为【" + DishName + "】的划单？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            
                                builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishID + "' ").Append("\r\n")
                                       .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n");
                            
                                builder.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishID + "' ").Append("\r\n")
                                       .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n");
                        }
                    }

                    string strSql = builder.ToString();
                    bool result = DBHelper.ExecuteNonQuery(strSql);
                    if (result)
                    {
                        LoadHuaDanInfo();
                        Init();

                        if (FrmName.Equals("frmMainNew"))
                        {
                            frmMainNew frm = (frmMainNew)this.Owner;
                            frm.LoadAllZhuoTaiDish();
                        }
                        else if (FrmName.Equals("frmDanXiangMergeDish"))
                        {
                            frmDanXiangMergeDish frm = (frmDanXiangMergeDish)this.Owner;
                            frm.LoadAllZhuoTaiDish("");
                        }
                        else if (FrmName.Equals("frmZTDish"))
                        {
                            frmZTDish frm = (frmZTDish)this.Owner;
                            frm.RefreshData();
                        }
                        else
                        {
                            frmMain frm = (frmMain)this.Owner;
                            frm.LoadAllZhuoTaiDish();
                        }

                    }
                }
                else if (e.ColumnIndex == dgSource.Columns[3].Index)
                {
                    string ZTName = dt.Rows[e.RowIndex]["桌台名称"].ToString();
                    DialogResult dr = MessageBox.Show("是否【" + ZTName + "】整桌取消划单？", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string OrderZhuoTaiID = dt.Rows[e.RowIndex]["OrderZhuoTaiID"].ToString();
                        string sql = "";
                        if (qiantaiMode == 0)
                        {
                             string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
                             if ("1".Equals(showDishForFinishPay))
                             {
                                 sql = " select UID from OrderZhuoTaiDish where OrderZhuoTaiID='" + OrderZhuoTaiID + "' UNION  select UID from HisOrderZhuoTaiDish where OrderZhuoTaiID='" + OrderZhuoTaiID + "' ";
                             }
                             else
                             {
                                 sql = " select UID from OrderZhuoTaiDish where OrderZhuoTaiID='" + OrderZhuoTaiID + "' ";
                             }
                        }
                        else
                        {
                            sql = " select UID from HisOrderZhuoTaiDish where OrderZhuoTaiID='" + OrderZhuoTaiID + "' ";
                        }
                        DataTable table = DBHelper.ExeSqlForDataTable(sql);
                        if (table.Rows.Count > 0)
                        {
                            StringBuilder builder = new StringBuilder();
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                string UIDTmp = table.Rows[i]["UID"].ToString();
                               
                                    builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UIDTmp + "' ").Append("\r\n")
                                           .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UIDTmp + "' ").Append("\r\n");
                               
                                    builder.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UIDTmp + "' ").Append("\r\n")
                                           .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UIDTmp + "' ").Append("\r\n");
                              
                            }
                            string strSql = builder.ToString();
                            bool result = DBHelper.ExecuteNonQuery(strSql);
                            if (result)
                            {
                                LoadHuaDanInfo();
                                Init();

                                if (FrmName.Equals("frmMainNew"))
                                {
                                    frmMainNew frm = (frmMainNew)this.Owner;
                                    frm.LoadAllZhuoTaiDish();
                                }
                                else if (FrmName.Equals("frmDanXiangMergeDish"))
                                {
                                    frmDanXiangMergeDish frm = (frmDanXiangMergeDish)this.Owner;
                                    frm.LoadAllZhuoTaiDish("");
                                }
								else if (FrmName.Equals("frmZTDish"))
								{
									frmZTDish frm = (frmZTDish)this.Owner;
									frm.RefreshData();
								}
                                else
                                {
                                    frmMain frm = (frmMain)this.Owner;
                                    frm.LoadAllZhuoTaiDish();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("取消划单失败：" + ex.ToString());
            }
        }

        #endregion

        private void btnDown_Click(object sender, EventArgs e)
        {
            int totalNum = Convert.ToInt32(Math.Ceiling((double)dt.Rows.Count / 10));
            if (totalNum == 1)
            {
                currPage = 1;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
            else if (currPage >= totalNum)
            {
                currPage = totalNum;
                btnDown.Enabled = false;
            }
            else if (currPage + 1 < totalNum)
            {
                currPage++;
                btnUp.Enabled = true;
                btnDown.Enabled = true;
            }
            else if (currPage + 1 == totalNum)
            {
                currPage++;
                btnUp.Enabled = true;
                btnDown.Enabled = false;
            }
            BindDataSource();

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int totalNum = Convert.ToInt32(Math.Ceiling((double)dt.Rows.Count / 10));
            if (totalNum == 1)
            {
                currPage = totalNum;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
            else if (currPage - 1 > 1)
            {
                currPage--;
                btnDown.Enabled = true;
            }
            else if ((currPage - 1 == 1) && totalNum == 1)
            {
                currPage = 1;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
            else if ((currPage - 1 == 1) && totalNum > 1)
            {
                currPage = 1;
                btnUp.Enabled = false;
                btnDown.Enabled = true;
            }
            BindDataSource();
        }

        public void Init()
        {
            currPage = 1;
            btnDown.Enabled = false;
            btnUp.Enabled = false;
            int totalNum = Convert.ToInt32(Math.Ceiling((double)dt.Rows.Count / 10));
            if (totalNum > 1)
                btnDown.Enabled = true;
            BindDataSource();
        }

        private void setOemInfo()
        {
            try
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\oem\\info.ini"))
                    return;

                IniFileHelper iniHelper = new IniFileHelper(Directory.GetCurrentDirectory() + "\\oem\\info.ini");

                StringBuilder simplename = new StringBuilder(55);
                iniHelper.GetIniString("oem", "simplename", "", simplename, simplename.Capacity);

                if (File.Exists(Directory.GetCurrentDirectory() + "\\oem\\res\\images\\app.ico"))
                {
                    this.Icon = new System.Drawing.Icon(Directory.GetCurrentDirectory() + "\\oem\\res\\images\\app.ico");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("frmQuery setOemInfo():" + ex.ToString());
            }
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);   
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);   
        }
    }
}
