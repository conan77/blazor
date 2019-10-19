using HuaDan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaDan
{
    public partial class frmMainNew : Form
    {
        ListBox[] listBoxes = new ListBox[4];
        Label[] listLabels = new Label[4];
        DateTime startTime = DateTime.Now;  //餐别开始时间
        public static double alertTime = 30;//警报时间
        int qiantaiMode = 0; //前台模式：中餐、快餐
        int zhuotaiMode = 0; //桌台模式：台卡号、桌台
        int CurrentPageNo = 0;
        DateTime lastClickTime = DateTime.Now;
        bool handMode = false;
        DataTable orderGuQingTable = new DataTable();

        public frmMainNew()
        {
            InitializeComponent();

            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            for (int i = 0; i < 4; i++)
            {
                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill;

                listLabels[i] = new Label();
                listLabels[i].Dock = DockStyle.Top;
                listLabels[i].Height = 50;
                listLabels[i].Font = new Font("新宋体", 16.0f, FontStyle.Bold);
                listLabels[i].BackColor = Color.FromArgb(96, 96, 96);
                listLabels[i].ForeColor = Color.LightYellow;
                listLabels[i].AutoSize = false;
                listLabels[i].TextAlign = ContentAlignment.MiddleLeft;
                listLabels[i].BorderStyle = BorderStyle.FixedSingle;
                listLabels[i].Click += listLabels_Click;

                listBoxes[i] = new ListBox();
                listBoxes[i].Dock = DockStyle.Fill;
                listBoxes[i].BackColor = Color.FromArgb(64, 64, 64);
                listBoxes[i].ForeColor = Color.LightYellow;
                listBoxes[i].Font = new Font("新宋体", 16.0f);
                listBoxes[i].SelectionMode = SelectionMode.MultiSimple;
                listBoxes[i].DrawMode = DrawMode.OwnerDrawFixed;
                listBoxes[i].DrawItem += listBoxes_DrawItem;
                listBoxes[i].ItemHeight = 40;
                listBoxes[i].Click += listBoxes_Click;
                listBoxes[i].MouseDown += listBox1_MouseDown;

                panel.Controls.Add(listBoxes[i]);
                panel.Controls.Add(listLabels[i]);

                tableLayoutPanel1.Controls.Add(panel);
            }
        }

        private void listLabels_Click(object sender, EventArgs e)
        {
            lastClickTime = DateTime.Now;
            handMode = true;

            int index = -1;
            for (int i = 0; i < listLabels.Length; i++)
            {
                if (object.Equals(listLabels[i], sender))
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0)
            {
                ListBox listbox = listBoxes[index];
                if (listbox.Items.Count == 0)
                    return;
                bool selected = listbox.GetSelected(0) && listbox.GetSelected(listbox.Items.Count - 1);

                for (int i = 0; i < listbox.Items.Count; i++)
                {
                    if (selected)
                        listbox.SetSelected(i, false);
                    else
                        listbox.SetSelected(i, true);
                }
            }


            List<string> resultList = CommonGuQing.ChangeBtnGuQingName(listBoxes);
            if (resultList.Count <= 0)
            {
                btnGuQing.Enabled = false;
                btnGuQing.Text = "沽清";
            }
            else
            {
                btnGuQing.Enabled = true;
                string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
                if (!string.IsNullOrEmpty(guQingModel) && "1".Equals(guQingModel))
                {
                    btnGuQing.Text = resultList[0];
                }
                else
                {
                    btnGuQing.Text = "沽清";
                }
            }
        }

        private void listBoxes_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                ListBoxItem item = (sender as ListBox).Items[e.Index] as ListBoxItem;

                e.DrawBackground();
                Brush mybsh = Brushes.LightYellow;
                e.DrawFocusRectangle();
                if (item.IsHuaCai || (item.DishNum + item.DishZengSongNum) == 0)
                {
                    mybsh = Brushes.Red;
                }

                try
                {
                    if (orderGuQingTable.Rows.Count > 0)
                    {
                        DataRow[] dr = orderGuQingTable.Select("DishID='" + item.DishID + "'");
                        Brush br;
                        if (dr.Count() > 0)
                        {
                            br = Brushes.Green;
                            e.Graphics.FillRectangle(br, e.Bounds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //指定绘制文本的位置
                RectangleF rf = new RectangleF(e.Bounds.X, e.Bounds.Y + 9, e.Bounds.Width, e.Font.Height);

                //绘制指定的字符串
                e.Graphics.DrawString(item.ToString(), e.Font, mybsh, rf, StringFormat.GenericDefault);

            }
        }

        private void listBoxes_Click(object sender, EventArgs e)
        {
            lastClickTime = DateTime.Now;
            handMode = true;
        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lb = ((ListBox)sender);
            Point pt = new Point(e.X, e.Y);
            int index = lb.IndexFromPoint(pt);
            if (index >= 0)
            {
                ListBox listBox = sender as ListBox;
                if (listBox.Items.Count == 0)
                    return;

                ListBoxItem list = listBox.Items[index] as ListBoxItem;
                string isTaoCanDetail = list.IsTaoCanDetail; //区分是否套餐明细 是：是 | 否：否
                bool isPackage = list.IsPackage;             //是否套餐
                string OrderZhuoTaiDishID = list.IsPackage ? list.UID : list.OrderZhuoTaiDishID;//OrderZhuoTaiDish主键UID
                bool selected = listBox.GetSelected(index);
                if (string.Equals(isTaoCanDetail, "否") && isPackage) //表示套餐总名称
                {
                    #region //点击套餐全部选中或取消
                    string UID = string.Empty;
                    for (int i = 0; i < listBox.Items.Count; i++)
                    {
                        ListBoxItem listTmp = listBox.Items[i] as ListBoxItem;
                        if (string.Equals(listTmp.IsTaoCanDetail, "否") && listTmp.IsPackage && i == index) //套餐的名称 非明细
                        {
                            UID = listTmp.UID;
                        }

                        if (string.Equals(listTmp.IsTaoCanDetail, "是") && !listTmp.IsPackage && string.Equals(UID, listTmp.OrderZhuoTaiDishID) && !listTmp.IsHuaCai && listTmp.DishNum > 0)
                        {
                            if (selected)
                                listBox.SetSelected(i, true);
                            else
                                listBox.SetSelected(i, false);
                        }
                    }
                    #endregion
                }
                else if (string.Equals(isTaoCanDetail, "是") && !isPackage) //表示套餐内菜品明细
                {
                    #region//点击套餐内明细全部选中或取消套餐名称选中状态
                    int countTotal = 0;//获取套餐内菜品总数--未划菜
                    int count = 0;     //获取套餐内菜品以选中总数--未划菜
                    int indexDish = 0;//套餐菜品所在索引
                    for (int i = 0; i < listBox.Items.Count; i++)
                    {
                        ListBoxItem listTmp = listBox.Items[i] as ListBoxItem;
                        if (string.Equals(listTmp.IsTaoCanDetail, "否") && listTmp.IsPackage && string.Equals(listTmp.UID, OrderZhuoTaiDishID))
                            indexDish = i;
                        if (string.Equals(isTaoCanDetail, "是") && !isPackage && listTmp.DishNum > 0 && !listTmp.IsHuaCai && string.Equals(listTmp.OrderZhuoTaiDishID, OrderZhuoTaiDishID))
                        {
                            bool selectedTmp = listBox.GetSelected(i);
                            if (selectedTmp)
                                count++;
                            countTotal++;
                        }
                    }

                    if (!selected)
                        listBox.SetSelected(indexDish, false);
                    else
                    {
                        if (count == countTotal && countTotal != 0)
                            listBox.SetSelected(indexDish, true);
                        else
                            listBox.SetSelected(indexDish, false);
                    }
                    #endregion
                }
            }

            #region //沽清按钮
            List<string> resultList = CommonGuQing.ChangeBtnGuQingName(listBoxes);
            if (resultList.Count <= 0)
            {
                btnGuQing.Enabled = false;
                btnGuQing.Text = "沽清";
            }
            else
            {
                btnGuQing.Enabled = true;
                string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
                if (!string.IsNullOrEmpty(guQingModel) && "1".Equals(guQingModel))
                {
                    btnGuQing.Text = resultList[0];
                }
                else
                {
                    btnGuQing.Text = "沽清";
                }
            }
            #endregion
        }

        private void frmMainNew_Load(object sender, EventArgs e)
        {
            setOemInfo();
            this.WindowState = FormWindowState.Maximized;
            txtHuaCaiNum.Focus();
            StartMonitor();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            CurrentPageNo--;
            LoadAllZhuoTaiDish();
        }

        public void LoadAllZhuoTaiDish()
        {
            startTime = Common.InitCanBie();
            try
            {
                string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
                if (!string.IsNullOrEmpty(strAlertTime))
                    alertTime = double.Parse(strAlertTime);

                string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"]; //前台模式:中餐、快餐
                string strZhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"]; //桌台模式:台卡号、桌台
                if (!string.IsNullOrEmpty(strQiantaiMode))
                    qiantaiMode = int.Parse(strQiantaiMode);
                if (!string.IsNullOrEmpty(strZhuotaiMode))
                    zhuotaiMode = int.Parse(strZhuotaiMode);

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

                //普通点菜、外卖、套餐明细、中餐完成结算未划单

                string strSql = "";

                if (qiantaiMode == 0)  //中餐
                {
                    string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
                    if (zhuotaiMode == 0 || zhuotaiMode == 1)  //台卡号 或 桌台
                    {
                        if ("1".Equals(showDishForFinishPay))
                        {
                            strSql = " select * from( "
                               + "SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
                               + "OrderZhuoTaiDish.DishName, OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
                               + "OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum ,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
                               + "FROM OrderZhuoTaiDish INNER JOIN "
                               + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
                               + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
                               + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
                               + "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
                               + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
                               + " UNION "
                               + "SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
                               + "HisOrderZhuoTaiDish.DishName, HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
                               + "HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum ,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
                               + "FROM HisOrderZhuoTaiDish INNER JOIN "
                               + "HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
                               + "INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
                               + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
                               + "(SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
                               + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " ) d " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + " ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName";
                        }
                        else
                        {
                            strSql = "SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
                                   + "OrderZhuoTaiDish.DishName, OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
                                   + "OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum ,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
                                   + "FROM OrderZhuoTaiDish INNER JOIN "
                                   + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
                                   + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
                                   + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
                                   + "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
								   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and OrderZhuoTaiDish.IsHuaCai=0 " : "")
                                   + " ORDER BY OrderZhuoTai.AddTime,ZhuoTaiName, OrderZhuoTaiDish.AddTime,IsHuaCai,DishTypeID,DishName";
                        }
                    }
                }
                else if (qiantaiMode == 1)
                {
                    if (zhuotaiMode == 0)  //台卡号
                    {
						strSql = "SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + "HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID,HisOrderZhuoTai.ZhuoTaiName, "// HisOrderInfo.TaiKaHao ZhuoTaiName, "
							   + "HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + "FROM HisOrderZhuoTaiDish INNER JOIN "
							   + "HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " INNER JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderInfo.UID IN "
							   + "(SELECT DISTINCT OrderID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and HisOrderZhuoTaiDish.IsHuaCai=0 " : "")
							   + " ORDER BY HisOrderZhuoTai.AddTime,ZhuoTaiName,HisOrderZhuoTaiDish.AddTime,IsHuaCai,DishTypeID,DishName";
                    }
                    else if (zhuotaiMode == 1)  //桌台
                    {
						strSql = "SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + "HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + "HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + "FROM HisOrderZhuoTaiDish INNER JOIN "
							   + "HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
							   + "(SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and HisOrderZhuoTaiDish.IsHuaCai=0 " : "")
							   + " ORDER BY HisOrderZhuoTai.AddTime,ZhuoTaiName,HisOrderZhuoTaiDish.AddTime,IsHuaCai,DishTypeID,DishName";
					}
                }

                string strConn = ConfigurationManager.AppSettings["dbconn"];
                DataTable table = new DataTable();

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = strSql;
                    cmd.Parameters.AddWithValue("@StoreID", Tools.CurrentUser.StoreID);
                    cmd.Parameters.AddWithValue("@AddTime", startTime);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                GetOrderGuQing();

                //获取外卖--数据  select 字段 同步上面sql
                DataTable dtTpm = QueryKCWaiMaiOrder(table);
                table.Clear();
                table = dtTpm.Copy();

                if (zhuotaiMode == 0 || zhuotaiMode == 1)
                {

                    string ifsort = ConfigurationManager.AppSettings["ifsort"];
                    if ("0".Equals(ifsort) || object.Equals(ifsort, null))
                    {
						if (qiantaiMode == 0)
							ShowZhuoTaiDish(QueryTaoCan(table));
						else
							ShowZhuoTaiDish(table);
                    }
                    else
                        ShowZhuoTaiDish(CloneTable(table));
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("frmMainNew LoadAllZhuoTaiDish 错误原因:" + ex.ToString());
            }
        }

		public DataTable QueryKCWaiMaiOrder(DataTable paramTable)
		{
			DataTable curTable = new DataTable();
			string strSql = string.Empty;
			try
			{
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

				string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
				if (zhuotaiMode == 0)
				{
					if ("1".Equals(showDishForFinishPay))
					{
						#region //台卡号
						strSql = " SELECT * FROM ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID,OrderZhuoTai.ZhuoTaiName, "// OrderInfo.TaiKaHao ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish INNER JOIN "
							   + " OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1  AND OrderInfo.UID IN "
							   + " (SELECT DISTINCT OrderID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " UNION ALL "
							   + " SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + " HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID,  HisOrderZhuoTai.ZhuoTaiID,HisOrderZhuoTai.ZhuoTaiName, "// OrderInfo.TaiKaHao ZhuoTaiName, "
							   + " HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM HisOrderZhuoTaiDish INNER JOIN "
							   + " HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " INNER JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderId=HisOrderInfo.UID "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1  AND HisOrderInfo.UID IN "
							   + " (SELECT DISTINCT OrderID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " ) tmpTable " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + " ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";
						#endregion
					}
					else
					{
						strSql = " SELECT * FROM ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID,OrderZhuoTai.ZhuoTaiName, "// OrderInfo.TaiKaHao ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish INNER JOIN "
							   + " OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1  AND OrderInfo.UID IN "
							   + " (SELECT DISTINCT OrderID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " ) tmpTable " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + " ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";
					}
				}
				else if (zhuotaiMode == 1)
				{
					if ("1".Equals(showDishForFinishPay))
					{
						#region //桌台
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish  "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderZhuoTaiDish.OrderID "
							   + " INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
							   + " (SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "' AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " UNION ALL "
							   + " SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + " HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + " HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM HisOrderZhuoTaiDish  "
							   + " INNER JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderId=HisOrderZhuoTaiDish.OrderID "
							   + " INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
							   + " (SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + " ) "
							   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable  " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + "  ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";

						#endregion
					}
					else
					{
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish  "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderZhuoTaiDish.OrderID "
							   + " INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
							   + " (SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "' AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable  " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + "  ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";
					}
				}
				else if (zhuotaiMode == 2)
				{
					if ("1".Equals(showDishForFinishPay))
					{
						#region //单项
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " isnull(OrderZhuoTaiDish.SongDanTime,OrderInfo.Addtime) SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,OrderZhuoTaiDish.AddTime as DishAddTime "
							   + " FROM OrderZhuoTaiDish INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " LEFT JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " UNION "
							   + " SELECT HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + " HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + " isnull(HisOrderZhuoTaiDish.SongDanTime,HisOrderInfo.Addtime)  SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.AddTime as DishAddTime "
							   + " FROM HisOrderZhuoTaiDish INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " LEFT JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderId=HisOrderInfo.UID "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0 AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable ORDER BY DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName ";
						#endregion
					}
					else
					{
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " isnull(OrderZhuoTaiDish.SongDanTime,OrderInfo.Addtime) SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,OrderZhuoTaiDish.AddTime as DishAddTime "
							   + " FROM OrderZhuoTaiDish INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " LEFT JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable ORDER BY DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName ";
					}
				}

				//所有外卖信息
				DataTable tableWaiMai = DBHelper.ExeSqlForDataTable(strSql);

				curTable = paramTable.Clone();
				foreach (DataRow dr in paramTable.Rows)
				{
					DataRow newRow = curTable.NewRow();
					curTable.Rows.Add(newRow);
					for (int i = 0; i < dr.ItemArray.Length; i++)
					{
						newRow[i] = dr[i];
					}
				}

				foreach (DataRow dr in tableWaiMai.Rows)
				{
					DataRow newRow = curTable.NewRow();
					curTable.Rows.Add(newRow);
					for (int i = 0; i < dr.ItemArray.Length; i++)
					{
						newRow[i] = dr[i];
					}
				}

				if (zhuotaiMode == 0 || zhuotaiMode == 1)  //台卡号
				{
					curTable.DefaultView.Sort = "ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName";
				}
				else
				{
					curTable.DefaultView.Sort = "DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
				}

				curTable = curTable.DefaultView.ToTable();
			}
			catch (Exception ex)
			{
				Log.WriteLog("QueryKCWaiMaiOrder strSql=" + strSql);
				Log.WriteLog("QueryKCWaiMaiOrder 错误信息:" + ex.ToString());
			}

			//去重
			DataView dv = new DataView(curTable);
			DataTable table = dv.ToTable(true);
			if (zhuotaiMode == 0 || zhuotaiMode == 1)  //台卡号
			{
				table.DefaultView.Sort = "ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName";
			}
			else
			{
				table.DefaultView.Sort = "DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
			}

			return table;
		}

		public DataTable QueryTaoCan(DataTable table)
		{
			DataTable curTable;
			curTable = table.Clone();
			try
			{
				if (object.Equals(table, null))
				{
					Log.WriteLog("QueryTaoCan table为NULL");
					return table;
				}
				#region //【目的】：将等叫的桌台放在最后面---获取所有起菜和等叫的桌台
				List<string> listDishStatusQiCai = new List<string>();       //用于存放所有【起菜】的桌台
				List<string> listDishStatusDengJiao = new List<string>();    //用于存放所有【等叫】的桌台
				DataRow[] strDj = table.Select("DishStatusDesc='等叫'", "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");
				foreach (DataRow drDish in strDj)
				{
					string ZhuoTaiID = drDish["ZhuoTaiID"] as string;
					if (!listDishStatusDengJiao.Contains(ZhuoTaiID))
					{
						listDishStatusDengJiao.Add(ZhuoTaiID);
					}
				}

				DataRow[] strQc = table.Select("DishStatusDesc<>'等叫'", "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");
				foreach (DataRow drDish in strQc)
				{
					string ZhuoTaiID = drDish["ZhuoTaiID"] as string;
					if (!listDishStatusDengJiao.Contains(ZhuoTaiID) && !listDishStatusQiCai.Contains(ZhuoTaiID))
					{
						listDishStatusQiCai.Add(ZhuoTaiID);
					}
				}

				#endregion

				#region //拼接套餐【目的】：可以划菜单个套餐菜品
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

				//注释【此sql语句所有字段排序必须与LoadAllZhuoTaiDish 的 sql 字段 排序一致】【===否则问题很大===】【目的：拼接表格】
				string strSql = "";
				string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
				if ("1".Equals(showDishForFinishPay))
				{
					strSql = "select * from ("
					+ "SELECT  OrderZhuoTai.AddTime as ZTAddTime,OrderPackageDishDetail.AddTime as DishAddTime,OrderPackageDishDetail.UID, OrderPackageDishDetail.StoreID, OrderPackageDishDetail.OrderID, OrderPackageDishDetail.OrderZhuoTaiID, OrderPackageDishDetail.DishID, "
					+ "OrderPackageDishDetail.DishName, OrderPackageDishDetail.DishTypeID,OrderPackageDishDetail.UnitName,(OrderPackageDishDetail.DishNum+OrderPackageDishDetail.DishZengSongNum) as DishNum, OrderPackageDishDetail.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
					+ "OrderZhuoTaiDish.SongDanTime,OrderPackageDishDetail.IfHuaCai as IsHuaCai,OrderPackageDishDetail.HuaCaiNum ,OrderPackageDishDetail.ZuoFaNames,OrderPackageDishDetail.KouWeiNames,OrderInfo.IsWaiMai,OrderPackageDishDetail.DishTuiCaiNum,OrderPackageDishDetail.DishZengSongNum,OrderPackageDishDetail.DishStatusDesc,0 as IsPackage,'是' as IsTaoCanDetail,OrderPackageDishDetail.OrderZhuoTaiDishID "
					+ "FROM OrderZhuoTaiDish INNER JOIN "
					+ "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
					+ "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
					+ "INNER JOIN OrderPackageDishDetail ON OrderPackageDishDetail.OrderZhuoTaiDishID=OrderZhuoTaiDish.UID "
					+ "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
					+ "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
					+ " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
					+ " UNION "
					+ " SELECT  HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderPackageDishDetail.AddTime as DishAddTime,HisOrderPackageDishDetail.UID, HisOrderPackageDishDetail.StoreID, HisOrderPackageDishDetail.OrderID, HisOrderPackageDishDetail.OrderZhuoTaiID, HisOrderPackageDishDetail.DishID, "
					+ " HisOrderPackageDishDetail.DishName, HisOrderPackageDishDetail.DishTypeID,HisOrderPackageDishDetail.UnitName,(HisOrderPackageDishDetail.DishNum+HisOrderPackageDishDetail.DishZengSongNum) as DishNum, HisOrderPackageDishDetail.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
					+ "HisOrderZhuoTaiDish.SongDanTime,HisOrderPackageDishDetail.IfHuaCai as IsHuaCai,HisOrderPackageDishDetail.HuaCaiNum ,HisOrderPackageDishDetail.ZuoFaNames,HisOrderPackageDishDetail.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderPackageDishDetail.DishTuiCaiNum,HisOrderPackageDishDetail.DishZengSongNum,HisOrderPackageDishDetail.DishStatusDesc,0 as IsPackage,'是' as IsTaoCanDetail,HisOrderPackageDishDetail.OrderZhuoTaiDishID "
					+ "FROM HisOrderZhuoTaiDish INNER JOIN "
					+ "HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
					+ "INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
					+ "INNER JOIN HisOrderPackageDishDetail ON HisOrderPackageDishDetail.OrderZhuoTaiDishID=HisOrderZhuoTaiDish.UID "
					+ "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
					+ "(SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
					+ " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
					+ ") as t  " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + "  order by ZTAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
				}
				else
				{
					strSql = "SELECT  OrderZhuoTai.AddTime as ZTAddTime,OrderPackageDishDetail.AddTime as DishAddTime,OrderPackageDishDetail.UID, OrderPackageDishDetail.StoreID, OrderPackageDishDetail.OrderID, OrderPackageDishDetail.OrderZhuoTaiID, OrderPackageDishDetail.DishID, "
				   + "OrderPackageDishDetail.DishName, OrderPackageDishDetail.DishTypeID,OrderPackageDishDetail.UnitName,(OrderPackageDishDetail.DishNum+OrderPackageDishDetail.DishZengSongNum) as DishNum, OrderPackageDishDetail.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
				   + "OrderZhuoTaiDish.SongDanTime,OrderPackageDishDetail.IfHuaCai as IsHuaCai,OrderPackageDishDetail.HuaCaiNum ,OrderPackageDishDetail.ZuoFaNames,OrderPackageDishDetail.KouWeiNames,OrderInfo.IsWaiMai,OrderPackageDishDetail.DishTuiCaiNum,OrderPackageDishDetail.DishZengSongNum,OrderPackageDishDetail.DishStatusDesc,0 as IsPackage,'是' as IsTaoCanDetail,OrderPackageDishDetail.OrderZhuoTaiDishID "
				   + "FROM OrderZhuoTaiDish INNER JOIN "
				   + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
				   + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
				   + "INNER JOIN OrderPackageDishDetail ON OrderPackageDishDetail.OrderZhuoTaiDishID=OrderZhuoTaiDish.UID "
				   + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
				   + "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
				   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and OrderPackageDishDetail.IfHuaCai=0 " : "")
				   + " ORDER BY OrderZhuoTai.AddTime,OrderZhuoTai.ZhuoTaiName, OrderPackageDishDetail.AddTime,OrderPackageDishDetail.IfHuaCai,OrderPackageDishDetail.DishTypeID,OrderPackageDishDetail.DishName";
				}
				DataTable tableTaoCan = DBHelper.ExeSqlForDataTable(strSql);

				#endregion



				#region //重新拼接table
				string conditionQC = string.Empty;
				for (int i = 0; i < listDishStatusQiCai.Count; i++)
				{
					if (string.IsNullOrEmpty(conditionQC))
						conditionQC = "ZhuoTaiID='" + listDishStatusQiCai[i] + "'";
					else
						conditionQC += " OR ZhuoTaiID='" + listDishStatusQiCai[i] + "'";
				}
				if (!string.IsNullOrEmpty(conditionQC))
				{

					DataRow[] dr = table.Select(conditionQC, "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");

					foreach (DataRow drDJ in dr)
					{
						DataRow newRow = curTable.NewRow();
						curTable.Rows.Add(newRow);
						for (int i = 0; i < drDJ.ItemArray.Length; i++)
						{
							newRow[i] = drDJ[i];
						}

						var ispackage = (bool)drDJ["IsPackage"];
						if (ispackage)
						{
							string dishUID = drDJ["UID"] as string;
							DataRow[] drPackage = tableTaoCan.Select("OrderZhuoTaiDishID='" + dishUID + "'", "ZTAddTime,ZhuoTaiName,IsHuaCai, DishAddTime,DishTypeID,DishName");
							foreach (DataRow drpackageTmp in drPackage)
							{
								DataRow newRowPackage = curTable.NewRow();
								curTable.Rows.Add(newRowPackage);
								for (int i = 0; i < drpackageTmp.ItemArray.Length; i++)
								{
									newRowPackage[i] = drpackageTmp[i];
								}
							}
						}
					}
				}

				string conditionDJ = string.Empty;
				for (int i = 0; i < listDishStatusDengJiao.Count; i++)
				{
					if (string.IsNullOrEmpty(conditionDJ))
						conditionDJ = "ZhuoTaiID='" + listDishStatusDengJiao[i] + "'";
					else
						conditionDJ += " OR ZhuoTaiID='" + listDishStatusDengJiao[i] + "'";
				}

				if (!string.IsNullOrEmpty(conditionDJ))
				{
					DataRow[] dr = table.Select(conditionDJ, "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");

					foreach (DataRow drDJ in dr)
					{
						DataRow newRow = curTable.NewRow();
						curTable.Rows.Add(newRow);
						for (int i = 0; i < drDJ.ItemArray.Length; i++)
						{
							newRow[i] = drDJ[i];
						}

						var ispackage = (bool)drDJ["IsPackage"];
						if (ispackage)
						{
							string dishUID = drDJ["UID"] as string;
							DataRow[] drPackage = tableTaoCan.Select("OrderZhuoTaiDishID='" + dishUID + "'", "ZTAddTime,ZhuoTaiName,IsHuaCai, DishAddTime,DishTypeID,DishName");

							foreach (DataRow drpackageTmp in drPackage)
							{
								DataRow newRowPackage = curTable.NewRow();
								curTable.Rows.Add(newRowPackage);
								for (int i = 0; i < drpackageTmp.ItemArray.Length; i++)
								{
									newRowPackage[i] = drpackageTmp[i];
								}
							}
						}
					}
				}

				#endregion



				return curTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("QueryTaoCan 错误原因:" + ex.ToString());

			}

			return curTable;
		}

        public DataTable CloneTable(DataTable tableParam)
        {
            DataTable table = new DataTable();
            List<string> list = new List<string>();
            foreach (DataRow row in tableParam.Rows)
            {
                string dishname = row["DishName"] as string;
                if (!string.IsNullOrEmpty(dishname) && !list.Contains(dishname))
                {
                    list.Add(dishname);
                }
            }

            table = tableParam.Clone();

            for (int i = 0; i < list.Count; i++)
            {
                foreach (DataRow row in tableParam.Rows)
                {
                    if (list[i].Equals(row[5]))
                    {
                        DataRow newRow = table.NewRow();
                        table.Rows.Add(newRow);
                        for (int j = 0; j < row.ItemArray.Length; j++)
                        {
                            newRow[j] = row[j];
                        }
                    }
                }
            }

            return table;
        }

        private void ShowZhuoTaiDish(DataTable table)
        {
            List<DataTable> dataTables = new List<DataTable>();
            string currZhuoTaiID = null;
            DataTable curTable = null;
            foreach (DataRow row in table.Rows)
            {
                string newZhuoTaiID = row["ZhuoTaiName"] as string; //row["ZhuoTaiID"] as string;
                if (!string.Equals(currZhuoTaiID, newZhuoTaiID))
                {
                    currZhuoTaiID = newZhuoTaiID;
                    curTable = table.Clone();
                    dataTables.Add(curTable);
                }

                DataRow newRow = curTable.NewRow();
                curTable.Rows.Add(newRow);
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    newRow[i] = row[i];
                }
            }

            //MessageBox.Show(dataTables.Count.ToString());

            this.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();

            for (int i = 0; i < 4; i++)
            {
                listBoxes[i].Items.Clear();
                listLabels[i].Text = "";
            }

            int startIndex = CurrentPageNo * 4;
            if (CurrentPageNo > 0)
                btnUp.Enabled = true;
            else
                btnUp.Enabled = false;

            int endIndex = startIndex + 4;
            if (endIndex > dataTables.Count)
                endIndex = dataTables.Count;

            if (endIndex < dataTables.Count)
                btnDown.Enabled = true;
            else
                btnDown.Enabled = false;

            //MessageBox.Show(startIndex + ":" + endIndex);

            for (int i = startIndex; i < endIndex; i++)
            {
                ListBox listBox = listBoxes[i % 4];
                DataTable nowTable = dataTables[i];
                foreach (DataRow row in nowTable.Rows)
                {
                    //Label lbl = new Label();
                    //lbl.Text = row["DishName"] as string;
                    string dishName = row["DishName"] as string;
                    string DishStatusDesc = row["DishStatusDesc"] as string;

                    if (string.Equals((string)row["IsTaoCanDetail"], "否"))
                    {
                        if ((bool)row["IsPackage"] == true && string.Equals(DishStatusDesc, "等叫"))
                        {
                            dishName = "【等叫】【套】" + dishName;
                        }
                        else if ((bool)row["IsPackage"] == false && string.Equals(DishStatusDesc, "等叫"))
                        {
                            dishName = "【等叫】" + dishName;
                        }
                    }
                    else
                    {
                        dishName = "   " + dishName;
                    }


                    ListBoxItem item = new ListBoxItem()
                    {
                        UID = row["UID"] as string,//说明：1、IsTaoCanDetail="是"=>OrderPackageDishDetail的主键UID 2、IsTaoCanDetail="否"=>OrderZhuoTaiDish的主键UID
                        DishName = dishName,
                        DishNum = (decimal)row["DishNum"],
                        IsHuaCai = (bool)row["IsHuaCai"],
                        SongDanTime = (DateTime)row["SongDanTime"],
                        DishTuiCaiNum = (decimal)row["DishTuiCaiNum"],
                        DishZengSongNum = (decimal)row["DishZengSongNum"],
                        IsPackage = (bool)row["IsPackage"],
                        IsTaoCanDetail = row["IsTaoCanDetail"] as string, //区分是套餐内菜品还是套餐外菜品
                        OrderZhuoTaiDishID = row["OrderZhuoTaiDishID"] as string,
                        DishID = row["DishID"] as string,
						ZuoFaNames = row["ZuoFaNames"] as string,
						KouWeiNames = row["KouWeiNames"] as string
                    };

                    listBox.Items.Add(item);

                    if (string.IsNullOrEmpty(listLabels[i % 4].Text))
                        listLabels[i % 4].Text = row["ZhuoTaiName"] as string;
                }
            }

            tableLayoutPanel1.ResumeLayout();
            this.ResumeLayout();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllZhuoTaiDish();
        }

        public void StartMonitor()
        {
            Common.ajudgeLocalTimeBaseServer();
            LoadAllZhuoTaiDish();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan delta = DateTime.Now - lastClickTime;
            if (delta.TotalMilliseconds >= 15000)
            {
                LoadAllZhuoTaiDish();
                txtHuaCaiNum.Focus();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            CurrentPageNo++;
            LoadAllZhuoTaiDish();
        }

        private void btnHuaDan_Click(object sender, EventArgs e)
        {
            List<string> uids = new List<string>();
            ListBoxItem onSelectedItem = null;  //划过的菜再划提示下，如果只有一个菜，那就是这个菜啦。
            foreach (ListBox listBox in listBoxes)
            {
                foreach (object obj in listBox.SelectedItems)
                {
                    uids.Add((obj as ListBoxItem).UID);
                    onSelectedItem = obj as ListBoxItem;
                }
            }

            if (uids.Count == 1 && !object.Equals(onSelectedItem, null))
            {
                if (onSelectedItem.IsHuaCai)
                {
                    DialogResult result = MessageBox.Show(onSelectedItem.DishName + " 已经划过了，重新划吗？", "确认", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                }
            }

            HuaDan(uids);
        }

        private void HuaDan(List<string> uids)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                foreach (string uid in uids)
                {
                    builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n")
                        .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n");

                    builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n")
                        .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n");
                }
                string strSql = builder.ToString();

                string strConn = ConfigurationManager.AppSettings["dbconn"];

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = strSql;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch { }
                }

                LoadAllZhuoTaiDish();
                if ("1".Equals(ConfigurationManager.AppSettings["autoprint"]))
                {
                    Task.Factory.StartNew(
                       () =>
                       {
						   HuaDanClass.PrintDishes(uids,new List<OrderAllZTDishModel>());
                       }
                   );
                }

                bool ifweixin = "1".Equals(ConfigurationManager.AppSettings["ifweixin"]);
                if (ifweixin)
                {
                    Task.Factory.StartNew(
                        () =>
                        {
                            HuaDanClass.CallWeiXin(uids);
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGuQing_Click(object sender, EventArgs e)
        {
            List<string> list = CommonGuQing.ChangeBtnGuQingName(listBoxes);
            if (list.Count > 0)
            {
                string guQingModel = ConfigurationManager.AppSettings["guQingModel"]; //是否快速沽清
                if (!object.Equals(guQingModel, null) && "1".Equals(guQingModel))
                {
                    //快速沽清模式
                    string quickGuQingTip = ConfigurationManager.AppSettings["quickGuQingTip"]; //快速沽清是否提醒
                    if (!object.Equals(quickGuQingTip, null) && "1".Equals(quickGuQingTip))
                    {
                        if (DialogResult.Yes == MessageBox.Show("菜品【" + list[2] + "】确定要" + btnGuQing.Text.Trim() + "吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            if (CommonGuQing.GuQingOpreate(btnGuQing.Text.Trim(), list[2], list[1], "", 0))
                            {
                                RefreshGuQing();
                            }
                            else
                            {
                                MessageBox.Show("沽清失败！");
                            }
                        }
                    }
                    else
                    {
                        //直接操作
                        if (CommonGuQing.GuQingOpreate(btnGuQing.Text.Trim(), list[2], list[1], "", 0))
                        {
                            RefreshGuQing();
                        }
                        else
                        {
                            MessageBox.Show("沽清失败！");
                        }
                    }
                }
                else if (!object.Equals(guQingModel, null) && "2".Equals(guQingModel))
                {
                    //普通沽清模式
                    frmGuQing frm = new frmGuQing(btnGuQing.Text.Trim(), list[2], list[1], true);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshGuQing();
                    }
                }

            }
        }

        private void RefreshGuQing()
        {
            string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
            if ("2".Equals(guQingModel))
            {
                btnGuQing.Text = "沽清";
            }
            else
            {
                if (btnGuQing.Text.Trim().Equals("取消沽清"))
                    btnGuQing.Text = "沽清";
                else if (btnGuQing.Text.Trim().Equals("沽清"))
                    btnGuQing.Text = "取消沽清";
            }
            LoadAllZhuoTaiDish();
            CommonGuQing.uploadGuQingData();
        }

        /// <summary>
        /// 刷新沽清菜品数据源
        /// </summary>
        private void GetOrderGuQing()
        {
            string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
            if (!string.IsNullOrEmpty(guQingModel) && !"0".Equals(guQingModel))
            {
                orderGuQingTable = CommonGuQing.GetOrderGuQingAllData();
            }
        }

        private void lblZCTip_Click(object sender, EventArgs e)
        {
            frmGuQingList frm = new frmGuQingList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAllZhuoTaiDish();
            }
            else
            {
                LoadAllZhuoTaiDish();
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            new frmSetup().ShowDialog(this);
        }

        private void txtHuaCaiNum_Click(object sender, EventArgs e)
        {
            handMode = false;
        }

        private void txtHuaCaiNum_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtHuaCaiNum.Text.Trim()))
                        return;

                    StringBuilder builder = new StringBuilder();
                    string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string sql = string.Empty;
                    string qiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];
                    if (string.IsNullOrEmpty(qiantaiMode) || "0".Equals(qiantaiMode))
                    {
                        sql = " select OrderZhuoTaiDish.UID,OrderPackageDishDetail.HuaCaiNum,OrderPackageDishDetail.OrderZhuoTaiDishID from OrderZhuoTaiDish " +
                                    " INNER JOIN OrderPackageDishDetail ON OrderPackageDishDetail.OrderZhuoTaiDishID=OrderZhuoTaiDish.UID where OrderPackageDishDetail.IfHuaCai=0 AND OrderZhuoTaiDish.IsHuaCai=0 and OrderZhuoTaiDish.DishNum>0 and OrderPackageDishDetail.DishNum>0 ";
                    }
                    else
                    {
                        sql = " select HisOrderZhuoTaiDish.UID,HisOrderPackageDishDetail.HuaCaiNum,HisOrderPackageDishDetail.OrderZhuoTaiDishID from HisOrderZhuoTaiDish " +
                              " INNER JOIN HisOrderPackageDishDetail ON HisOrderPackageDishDetail.OrderZhuoTaiDishID=HisOrderZhuoTaiDish.UID where HisOrderPackageDishDetail.IfHuaCai=0 AND HisOrderZhuoTaiDish.IsHuaCai=0 and HisOrderZhuoTaiDish.DishNum>0 and HisOrderPackageDishDetail.DishNum>0 ";
                    }
                    DataTable dt = DBHelper.ExeSqlForDataTable(sql);
                    if (dt.Rows.Count > 0) //说明有套餐明细
                    {
                        DataRow[] source = dt.Select("HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "'");//是套餐的划单号
                        if (source.Count() <= 0) //套餐OrderZhuoTaiDish表的菜品总名称
                        {
                            string sqlAll = string.Empty;
                            if (string.IsNullOrEmpty(qiantaiMode) || "0".Equals(qiantaiMode))
                            {
                                sqlAll = " select top 1 * from OrderZhuoTaiDish where HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' order by addtime desc ";
                            }
                            else
                            {
                                sqlAll = " select top 1 * from HisOrderZhuoTaiDish where HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' order by addtime desc  ";
                            }
                            DataTable dtAll = DBHelper.ExeSqlForDataTable(sqlAll);
                            if (dtAll.Rows.Count > 0)
                            {
                                if ((bool)dtAll.Rows[0]["IsPackage"])
                                {
                                    string UID = dtAll.Rows[0]["UID"].ToString();
                                    DialogResult dr = MessageBox.Show("确定整个套餐划单？", "提示", MessageBoxButtons.OKCancel);
                                    if (dr == DialogResult.OK)
                                    {
                                        builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n")
                                               .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n")
                                               .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UID + "' ").Append("\r\n")
                                               .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UID + "' ").Append("\r\n");
                                    }
                                }
                                else
                                {
                                    builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
                                           .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");
                                }
                            }
                        }
                        else
                        {
                            string OrderZhuoTaiDishUID = source[0]["UID"].ToString();

                            DataRow[] sourceDetail = dt.Select("OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "'");
                            if (sourceDetail.Count() == 1)
                            {
                                builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
                                       .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
                                       .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
                                       .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n");
                            }
                            else
                            {
                                #region//注释=>根据套餐划单号是否 划去整个套餐
                                //DialogResult dr = MessageBox.Show("确定整个套餐划单？\r\n确定 --> 套餐内所有菜品被划单！\r\n取消 --> 根据划单号划单一菜品！", "提示", MessageBoxButtons.OKCancel);

                                //if (dr == DialogResult.OK)
                                //{
                                //    builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
                                //           .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
                                //           .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
                                //           .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n");
                                //}
                                //else if (dr == DialogResult.Cancel)
                                //{
                                //    builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
                                //           .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");
                                //}
                                #endregion

                                builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
                                       .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");

                            }
                        }
                    }
                    else
                    {
                        builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
                                .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");
                    }
                    string strSql = builder.ToString();

                    string strConn = ConfigurationManager.AppSettings["dbconn"];

                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = strSql;
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch { }
                    }
                    txtHuaCaiNum.Clear();
                    LoadAllZhuoTaiDish();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("txtHuaCaiNum_KeyDown 错误信息:" + ex.ToString());
            }
        }

        private void txtHuaCaiNum_Leave(object sender, EventArgs e)
        {
            if (!handMode)
                txtHuaCaiNum.Focus();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            frmQuery frm = new frmQuery("frmMainNew");
            frm.Owner = this;
            frm.ShowDialog();
        }

		private bool IsHuaDel()
		{
			string huadelfordesk = ConfigurationManager.AppSettings["huadelfordesk"];
			if (string.IsNullOrEmpty(huadelfordesk) || "0".Equals(huadelfordesk))
				return false;

			return true;
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
                Log.WriteLog("MainFormNew setOemInfo():" + ex.ToString());
            }
        }
    }
}
