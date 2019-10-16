using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace HuaDan
{
	public partial class frmSetup : Form
	{
		List<string> arrDishTypes = new List<string>();
		List<string> arrDishes = new List<string>();
		DataTable talbeDish = new DataTable();
		int lastIndex = -1;
		bool initFinished = false;

		public frmSetup()
		{
			InitializeComponent();
		}

		private void frmSetup_Load(object sender, EventArgs e)
		{
			setOemInfo();
			comGuQingModel.SelectedIndex = 0;
			string strConn = ConfigurationManager.AppSettings["dbconn"];
			string[] arrStrConn = strConn.Split(';');
			for (var i = 0; i < arrStrConn.Length; i++)
			{
				string param = arrStrConn[i];
				string[] arrParam = param.Split('=');
				if (arrParam[0].ToLower().Equals("data source"))
					txtDbAddr.Text = arrParam[1];
				else if (arrParam[0].ToLower().Equals("initial catalog"))
					txtDbName.Text = arrParam[1];
				else if (arrParam[0].ToLower().Equals("user id"))
					txtDbUser.Text = arrParam[1];
				else if (arrParam[0].ToLower().Equals("password"))
					txtDbPassword.Text = arrParam[1];
			}

			string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
			if (!string.IsNullOrEmpty(strAlertTime))
				txtAlertTime.Value = decimal.Parse(strAlertTime);

			string qiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];
			if (string.IsNullOrEmpty(qiantaiMode) || "0".Equals(qiantaiMode))
			{
				radioQianTaiMode0.Checked = true;
				radioQianTaiMode1.Checked = false;
			}
			else
			{
				radioQianTaiMode0.Checked = false;
				radioQianTaiMode1.Checked = true;
			}

			groupSort.Visible = false;
			string zhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
			if (string.IsNullOrEmpty(zhuotaiMode) || "0".Equals(zhuotaiMode))
			{
				radioZhuoTai0.Checked = true;
				radioZhuoTai1.Checked = false;
				radioZhuoTai2.Checked = false;
				radioZhuoTai3.Checked = false;
			}
			else if ("1".Equals(zhuotaiMode))
			{
				radioZhuoTai0.Checked = false;
				radioZhuoTai1.Checked = true;
				radioZhuoTai2.Checked = false;
				radioZhuoTai3.Checked = false;
			}
			else if ("2".Equals(zhuotaiMode))
			{
				radioZhuoTai0.Checked = false;
				radioZhuoTai1.Checked = false;
				radioZhuoTai2.Checked = true;
				radioZhuoTai3.Checked = false;

				groupSort.Visible = true;
				string ifsort = ConfigurationManager.AppSettings["ifsort"];
				if ("0".Equals(ifsort) || object.Equals(ifsort, null))
					chkSort.Checked = false;
				else
					chkSort.Checked = true;

				string getdishmodel = ConfigurationManager.AppSettings["getdishmodel"];
				if ("0".Equals(getdishmodel) || object.Equals(getdishmodel, null))
					chkGetDishModel.Checked = false;
				else
					chkGetDishModel.Checked = true;

				string isMergeDish = ConfigurationManager.AppSettings["IsMergeDish"];
				if ("0".Equals(isMergeDish) || object.Equals(isMergeDish, null))
					chkMergeDish.Checked = false;
				else
					chkMergeDish.Checked = true;

				string isDishFixed = ConfigurationManager.AppSettings["IsDishFixed"];
				if ("0".Equals(isDishFixed) || object.Equals(isDishFixed, null))
					chkDishFixed.Checked = false;
				else
					chkDishFixed.Checked = true;

				string isDishFixedShow = ConfigurationManager.AppSettings["IsDishFixedShow"];
				if ("0".Equals(isDishFixedShow) || object.Equals(isDishFixedShow, null))
					chkDishFixedShow.Checked = false;
				else
					chkDishFixedShow.Checked = true;
			}
			else if ("3".Equals(zhuotaiMode))
			{
				radioZhuoTai0.Checked = false;
				radioZhuoTai1.Checked = false;
				radioZhuoTai2.Checked = false;
				radioZhuoTai3.Checked = true;
			}

			string ifWeiXin = ConfigurationManager.AppSettings["ifweixin"];
			if ("0".Equals(ifWeiXin) || object.Equals(ifWeiXin, null))
				chkWeiXin.Checked = false;
			else
				chkWeiXin.Checked = true;

			if (string.IsNullOrEmpty(qiantaiMode) || "0".Equals(qiantaiMode))
			{
				//中餐
				chkShowDishForFinishPay.Enabled = true;
				string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
				if ("0".Equals(showDishForFinishPay) || object.Equals(showDishForFinishPay, null))
					chkShowDishForFinishPay.Checked = false;
				else
					chkShowDishForFinishPay.Checked = true;
			}
			else
			{
				//快餐
				chkShowDishForFinishPay.Checked = false;
				chkShowDishForFinishPay.Enabled = false;
			}

			radioZhuoTai3_CheckedChanged(null, null);

			//是否启用4方格新模式
			SetMainNewModel();
			string userMainNew = ConfigurationManager.AppSettings["userMainNew"];
			if ("1".Equals(userMainNew))
				chkMainNew.Checked = true;

			ShowHuaDelForDesk();

			InitTingMianLouCeng();
		}


		private void ShowHuaDelForDesk()
		{
			string zhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
			if (string.IsNullOrEmpty(zhuotaiMode) || "0".Equals(zhuotaiMode) || "1".Equals(zhuotaiMode))
			{
				chkHuaDel.Visible = true;
				string huadelfordesk = ConfigurationManager.AppSettings["huadelfordesk"];
				if (string.IsNullOrEmpty(huadelfordesk) || "0".Equals(huadelfordesk))
					chkHuaDel.Checked = false;
				else
					chkHuaDel.Checked = true;
			}
			else
			{
				chkHuaDel.Visible = false;
				chkHuaDel.Checked = false;
			}
		}

		private void btnCancle_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string strConn = "Data Source=" + txtDbAddr.Text.Trim() + ";Initial Catalog=" + txtDbName.Text.Trim()
			   + ";User ID=" + txtDbUser.Text.Trim() + ";Password=" + txtDbPassword.Text.Trim();

			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			if (object.Equals(config.AppSettings.Settings["dbconn"], null))
				config.AppSettings.Settings.Add("dbconn", strConn);
			else
				config.AppSettings.Settings["dbconn"].Value = strConn;

			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");

			MessageBox.Show("连接已保存！");
			this.Close();
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			string strConn = "Data Source=" + txtDbAddr.Text.Trim() + ";Initial Catalog=" + txtDbName.Text.Trim()
			   + ";User ID=" + txtDbUser.Text.Trim() + ";Password=" + txtDbPassword.Text.Trim();

			SqlConnection conn = new SqlConnection(strConn);
			try
			{
				conn.Open();
				conn.Close();
				MessageBox.Show("连接测试成功！");
			}
			catch (Exception ex)
			{
				MessageBox.Show("连接测试失败！\r\n" + ex.Message);
			}
		}

		private void btnClose2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSave2_Click(object sender, EventArgs e)
		{
			string strAlertTime = txtAlertTime.Value.ToString("#");
			string qiantaiMode = "0";
			string zhuotaiMode = "0";
			if (radioQianTaiMode1.Checked)
				qiantaiMode = "1";
			if (radioZhuoTai1.Checked)
				zhuotaiMode = "1";
			else if (radioZhuoTai2.Checked)
				zhuotaiMode = "2";
			else if (radioZhuoTai3.Checked)
				zhuotaiMode = "3";

			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			if (object.Equals(config.AppSettings.Settings["alerttime"], null))
				config.AppSettings.Settings.Add("alerttime", strAlertTime);
			else
				config.AppSettings.Settings["alerttime"].Value = strAlertTime;

			if (object.Equals(config.AppSettings.Settings["qiantaimode"], null))
				config.AppSettings.Settings.Add("qiantaimode", qiantaiMode);
			else
				config.AppSettings.Settings["qiantaimode"].Value = qiantaiMode;

			if (object.Equals(config.AppSettings.Settings["zhuotaimode"], null))
				config.AppSettings.Settings.Add("zhuotaimode", zhuotaiMode);
			else
				config.AppSettings.Settings["zhuotaimode"].Value = zhuotaiMode;

			if (object.Equals(config.AppSettings.Settings["ifweixin"], null))
				config.AppSettings.Settings.Add("ifweixin", chkWeiXin.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["ifweixin"].Value = chkWeiXin.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["ifsort"], null))
				config.AppSettings.Settings.Add("ifsort", chkSort.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["ifsort"].Value = chkSort.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["getdishmodel"], null))
				config.AppSettings.Settings.Add("getdishmodel", chkGetDishModel.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["getdishmodel"].Value = chkGetDishModel.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["IsMergeDish"], null))
				config.AppSettings.Settings.Add("IsMergeDish", chkMergeDish.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["IsMergeDish"].Value = chkMergeDish.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["IsStartCallNumServer"], null))
				config.AppSettings.Settings.Add("IsStartCallNumServer", chkStartServer.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["IsStartCallNumServer"].Value = chkStartServer.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["showDishForFinishPay"], null))
				config.AppSettings.Settings.Add("showDishForFinishPay", chkShowDishForFinishPay.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["showDishForFinishPay"].Value = chkShowDishForFinishPay.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["userMainNew"], null))
				config.AppSettings.Settings.Add("userMainNew", chkMainNew.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["userMainNew"].Value = chkMainNew.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["huadelfordesk"], null))
				config.AppSettings.Settings.Add("huadelfordesk", chkHuaDel.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["huadelfordesk"].Value = chkHuaDel.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["IsDishFixed"], null))
				config.AppSettings.Settings.Add("IsDishFixed", chkDishFixed.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["IsDishFixed"].Value = chkDishFixed.Checked ? "1" : "0";

			if (object.Equals(config.AppSettings.Settings["IsDishFixedShow"], null))
				config.AppSettings.Settings.Add("IsDishFixedShow", chkDishFixedShow.Checked ? "1" : "0");
			else
				config.AppSettings.Settings["IsDishFixedShow"].Value = chkDishFixedShow.Checked ? "1" : "0";

			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");

			MessageBox.Show("设置已保存！");

			this.Close();
		}

		private void tabPage3_Enter(object sender, EventArgs e)
		{
			/*
			if(object.Equals(Tools.CurrentUser,null))
			{
				((Control)tabPage3).Enabled = false;
				return;
			}
			*/
			initFinished = false;
			lastIndex = -1;
			listDishTypes.DataSource = null;
			listDish.DataSource = null;

			string strConn = ConfigurationManager.AppSettings["dbconn"];
			string strDishTypes = ConfigurationManager.AppSettings["dishtypes"];
			string strDishes = ConfigurationManager.AppSettings["dishes"];
			arrDishTypes.Clear();
			arrDishes.Clear();

			if (!string.IsNullOrEmpty(strDishTypes))
				arrDishTypes.AddRange(strDishTypes.Split(','));

			if (!string.IsNullOrEmpty(strDishes))
				arrDishes.AddRange(strDishes.Split(','));

			using (SqlConnection conn = new SqlConnection(strConn))
			{
				try
				{
					conn.Open();
				}
				catch
				{
					MessageBox.Show("数据库连接失败！");
					return;
				}

				List<UIDName> lstAllDishTypes = new List<UIDName>();

				string strCommand = "SELECT UID, TypeName FROM BaseDishType WHERE IsEnable=1 ";
				//string strCommand = "SELECT UID, TypeName FROM BaseDishType WHERE StoreID=100001";
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = strCommand;
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string uid = reader.GetString(0);
					string name = reader.GetString(1);
					UIDName item = new UIDName { UID = uid, Name = name };
					lstAllDishTypes.Add(item);
				}
				reader.Close();

				listDishTypes.DataSource = lstAllDishTypes;
				listDishTypes.ValueMember = "UID";
				listDishTypes.DisplayMember = "Name";
			}

			for (int i = 0; i < listDishTypes.Items.Count; i++)
			{
				UIDName item = listDishTypes.Items[i] as UIDName;
				bool found = arrDishTypes.Contains(item.UID);
				listDishTypes.SetItemChecked(i, found);
			}

			initFinished = true;
		}


		private void listDishTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lastIndex >= 0 && initFinished)
			{
				bool lastChecked = listDishTypes.GetItemChecked(lastIndex);
				if (!lastChecked)
				{
					for (int i = 0; i < listDish.Items.Count; i++)
					{
						bool dishChecked = listDish.GetItemChecked(i);
						if (!dishChecked)
						{
							UIDName item = listDish.Items[i] as UIDName;
							if (arrDishes.Contains(item.UID))
								arrDishes.Remove(item.UID);
						}
					}
				}
			}


			UIDName selitem = listDishTypes.SelectedItem as UIDName;
			if (object.Equals(selitem, null))
				return;

			string dishid = selitem.UID;

			string strConn = ConfigurationManager.AppSettings["dbconn"];
			using (SqlConnection conn = new SqlConnection(strConn))
			{
				try
				{
					conn.Open();
				}
				catch
				{
					MessageBox.Show("数据库连接失败！");
					return;
				}
				List<UIDName> lstAllDishOfTypeID = new List<UIDName>();
				string strCommand = "SELECT UID, DishName,TypeID FROM BaseDish WHERE TypeID='" + dishid + "' AND IsEnable=1 ";
				//string strCommand = "SELECT UID, DishName,TypeID FROM BaseDish WHERE StoreID=100001 AND TypeID='" + dishid + "'";
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = strCommand;
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string uid = reader.GetString(0);
					string name = reader.GetString(1);
					string typeid = reader.GetString(2);
					UIDName item = new UIDName { UID = uid, Name = name, TypeID = typeid };
					lstAllDishOfTypeID.Add(item);
				}
				reader.Close();

				listDish.DataSource = lstAllDishOfTypeID;
				listDish.ValueMember = "UID";
				listDish.DisplayMember = "Name";
			}

			if (listDishTypes.GetItemChecked(listDishTypes.SelectedIndex))
			{
				for (int i = 0; i < listDish.Items.Count; i++)
				{
					UIDName item = listDish.Items[i] as UIDName;
					bool found = !arrDishes.Contains(item.UID);
					listDish.SetItemChecked(i, found);
				}
			}
			else
			{
				for (int i = 0; i < listDish.Items.Count; i++)
				{
					listDish.SetItemChecked(i, false);
				}
			}

			lastIndex = listDishTypes.SelectedIndex;
		}


		private void listDishTypes_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			bool isChecked = (e.NewValue == CheckState.Checked);
			UIDName selitem = listDishTypes.SelectedItem as UIDName;

			if (isChecked)
			{
				if (!arrDishTypes.Contains(selitem.UID))
					arrDishTypes.Add(selitem.UID);

				for (int i = 0; i < listDish.Items.Count; i++)
				{
					UIDName item = listDish.Items[i] as UIDName;
					bool found = !arrDishes.Contains(item.UID);
					listDish.SetItemChecked(i, found);
				}
			}
			else
			{
				if (arrDishTypes.Contains(selitem.UID))
					arrDishTypes.Remove(selitem.UID);

				for (int i = 0; i < listDish.Items.Count; i++)
				{
					listDish.SetItemChecked(i, false);
				}
			}
		}


		private void listDish_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			bool isChecked = (e.NewValue == CheckState.Checked);
			UIDName selitem = listDish.SelectedItem as UIDName;
			if (isChecked)
			{
				if (arrDishes.Contains(selitem.UID))
					arrDishes.Remove(selitem.UID);
			}
			else
			{
				if (!arrDishes.Contains(selitem.UID))
					arrDishes.Add(selitem.UID);
			}
		}


		private void btnSave3_Click(object sender, EventArgs e)
		{
			string dishtypes = string.Join(",", arrDishTypes);
			string dishes = string.Join(",", arrDishes);

			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			if (object.Equals(config.AppSettings.Settings["dishtypes"], null))
				config.AppSettings.Settings.Add("dishtypes", dishtypes);
			else
				config.AppSettings.Settings["dishtypes"].Value = dishtypes;

			if (object.Equals(config.AppSettings.Settings["dishes"], null))
				config.AppSettings.Settings.Add("dishes", dishes);
			else
				config.AppSettings.Settings["dishes"].Value = dishes;


			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");

			MessageBox.Show("设置已保存！");
			this.Close();
		}

		class UIDName
		{
			public string UID { get; set; }
			public string TypeID { get; set; }
			public string Name { get; set; }
		}


		private void tabPage4_Enter(object sender, EventArgs e)
		{
			string strConn = ConfigurationManager.AppSettings["dbconn"];
			DataTable table = new DataTable();
			using (SqlConnection conn = new SqlConnection(strConn))
			{
				try
				{
					conn.Open();
					SqlCommand cmd = conn.CreateCommand();
					cmd.CommandText = "SELECT UID,Name FROM BasePrinter WHERE IsEnable=1";
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					adapter.Fill(table);
				}
				catch
				{
					MessageBox.Show("请正确设置数据库!");
				}
			}
			DataRow row = table.NewRow();
			row["UID"] = "";
			row["Name"] = "";
			table.Rows.InsertAt(row, 0);

			lstPrinters.ValueMember = "UID";
			lstPrinters.DisplayMember = "Name";
			lstPrinters.DataSource = table;

			string printer = ConfigurationManager.AppSettings["printer"];
			if (!string.IsNullOrEmpty(printer))
				lstPrinters.SelectedValue = printer;

			string autoprint = ConfigurationManager.AppSettings["autoprint"];
			chkAutoPrint.Checked = "1".Equals(autoprint);
		}

		private void btnSave4_Click(object sender, EventArgs e)
		{
			try
			{	
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			
				string printValue=object.Equals(lstPrinters.SelectedValue,null)?"": lstPrinters.SelectedValue.ToString();

				if (object.Equals(config.AppSettings.Settings["printer"], null))
					config.AppSettings.Settings.Add("printer", printValue);
				else
					config.AppSettings.Settings["printer"].Value = printValue;
			 
				string autoprint = chkAutoPrint.Checked ? "1" : "0";
				if (object.Equals(config.AppSettings.Settings["autoprint"], null))
					config.AppSettings.Settings.Add("autoprint", autoprint);
				else
					config.AppSettings.Settings["autoprint"].Value = autoprint;
				 
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
		 
				CaiMomoClient.Printer.LocalPrinter = null;

				MessageBox.Show("设置已保存！");
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("保存失败，失败原因:" +ex.ToString());
			}
		}

		private void btnClose4_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void radioZhuoTai2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioZhuoTai2.Checked)
			{
				groupSort.Visible = true;
			}
			else
			{
				groupSort.Visible = false;
				chkSort.Checked = false;
				chkGetDishModel.Checked = false;
				chkMergeDish.Checked = false;
				chkDishFixed.Checked = false;
			}

			SetMainNewModel();
		}

		private void chkGetDishModel_CheckedChanged(object sender, EventArgs e)
		{
			if (chkGetDishModel.Checked)
			{
				chkMergeDish.Checked = false;
				chkMergeDish.Enabled = false;
			}
			else
			{
				chkMergeDish.Enabled = true;
			}
		}

		private void chkMergeDish_CheckedChanged(object sender, EventArgs e)
		{
			if (chkMergeDish.Checked)
			{
				chkGetDishModel.Checked = false;
				chkGetDishModel.Enabled = false;
				lblDishFixed.Visible = true;
				chkDishFixed.Visible = true;
				lblDishFixedShow.Visible = true;
				chkDishFixedShow.Visible = true;
			}
			else
			{
				chkGetDishModel.Enabled = true;
				lblDishFixed.Visible = false;
				chkDishFixed.Visible = false;
				chkDishFixed.Checked = false;
				lblDishFixedShow.Visible = false;
				chkDishFixedShow.Visible = false;
				chkDishFixedShow.Checked = false;
			}
		}

		private void btnSave5_Click(object sender, EventArgs e)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			string guQingModel = string.Empty;
			if (string.IsNullOrEmpty(comGuQingModel.Text.Trim()) || comGuQingModel.Text.Trim().Equals("请选择"))
			{
				guQingModel = "0";
			}
			else if (comGuQingModel.Text.Trim().Equals("快速沽清"))
			{
				guQingModel = "1";
			}
			else
			{
				guQingModel = "2";
			}
			if (object.Equals(config.AppSettings.Settings["guQingModel"], null))
				config.AppSettings.Settings.Add("guQingModel", guQingModel);
			else
				config.AppSettings.Settings["guQingModel"].Value = guQingModel;

			string quickGuQingTip = chkTip.Checked ? "1" : "0";
			if (object.Equals(config.AppSettings.Settings["quickGuQingTip"], null))
				config.AppSettings.Settings.Add("quickGuQingTip", quickGuQingTip);
			else
				config.AppSettings.Settings["quickGuQingTip"].Value = quickGuQingTip;

			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");

			MessageBox.Show("设置已保存！");
			this.Close();
		}

		private void btnClose5_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tabControl1_Enter(object sender, EventArgs e)
		{
			string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
			if ("1".Equals(guQingModel))
			{
				comGuQingModel.Text = "快速沽清";
			}
			else if ("2".Equals(guQingModel))
			{
				comGuQingModel.Text = "普通沽清";
			}
			else
			{
				comGuQingModel.Text = "请选择";
			}
			string quickGuQingTip = ConfigurationManager.AppSettings["quickGuQingTip"];
			chkTip.Checked = "1".Equals(quickGuQingTip);
		}

		private void radioZhuoTai3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioZhuoTai3.Checked)
			{
				chkStartServer.Visible = true;
				btnPort.Visible = true;

				string isStartServer = ConfigurationManager.AppSettings["IsStartCallNumServer"];
				if (string.IsNullOrEmpty(isStartServer) || "0".Equals(isStartServer))
				{
					chkStartServer.Checked = false;
				}
				else { chkStartServer.Checked = true; }

			}
			else
			{
				chkStartServer.Visible = false;
				btnPort.Visible = false;
				chkStartServer.Checked = false;
			}

			SetMainNewModel();
		}

		private void btnPort_Click(object sender, EventArgs e)
		{
			frmPort frm = new frmPort();
			frm.ShowDialog();
		}

		private void radioQianTaiMode0_CheckedChanged(object sender, EventArgs e)
		{
			if (radioQianTaiMode0.Checked)
			{
				//中餐
				chkShowDishForFinishPay.Enabled = true;
			}
			else
			{
				//快餐
				chkShowDishForFinishPay.Checked = false;
				chkShowDishForFinishPay.Enabled = false;
			}
		}

		/// <summary>
		/// 是否启用4方格新模式
		/// </summary>
		private void SetMainNewModel()
		{
			if (radioZhuoTai0.Checked || radioZhuoTai1.Checked)
			{
				chkMainNew.Visible = true;
				chkHuaDel.Visible = true;
			}
			else
			{
				chkMainNew.Visible = false;
				chkMainNew.Checked = false;
				chkHuaDel.Visible = false;
				chkHuaDel.Checked = false;
			}
		}

		private void radioZhuoTai0_CheckedChanged(object sender, EventArgs e)
		{
			SetMainNewModel();
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
				Log.WriteLog("frmSetup setOemInfo():" + ex.ToString());
			}
		}

		#region //厅面楼层
		private void InitTingMianLouCeng()
		{
			listTMLCS.DataSource = null;
			List<BaseTMLC> tmlcList = new List<BaseTMLC>();
			string sql = "SELECT UID,TMLCName FROM BaseTingMianLouCeng with(nolock) where IsEnable=1 ORDER BY AddTime asc";
			DataTable dt = DBHelper.ExeSqlForDataTable(sql);
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				BaseTMLC tmlc = new BaseTMLC();
				tmlc.UID = dt.Rows[i]["UID"].ToString();
				tmlc.TMLCName = dt.Rows[i]["TMLCName"].ToString();
				tmlcList.Add(tmlc);
			}

			tmlcList.Add(new BaseTMLC { UID = Constants.XUNILOUCENG, TMLCName = "虚拟楼层" });

			listTMLCS.DataSource = tmlcList;
			listTMLCS.ValueMember = "UID";
			listTMLCS.DisplayMember = "TMLCName";

			string strTMLC = ConfigurationManager.AppSettings["tmlc"];
			if (object.Equals(strTMLC, null))
			{
				for (int i = 0; i < listTMLCS.Items.Count; i++)
				{
					BaseTMLC item = listTMLCS.Items[i] as BaseTMLC;
					listTMLCS.SetItemChecked(i, true);
				}
			}
			else
			{
				for (int i = 0; i < listTMLCS.Items.Count; i++)
				{
					BaseTMLC item = listTMLCS.Items[i] as BaseTMLC;
					bool found = strTMLC.Contains(item.UID);
					listTMLCS.SetItemChecked(i, found);
				}
			}
		}

		private void btnTMLCSave_Click(object sender, EventArgs e)
		{
			string strTMLC = string.Empty;
			for (int i = 0; i < listTMLCS.Items.Count; i++)
			{
				if (listTMLCS.GetItemChecked(i))
				{
					BaseTMLC item = listTMLCS.Items[i] as BaseTMLC;
					if (string.IsNullOrEmpty(strTMLC))
					{
						strTMLC = item.UID;
					}
					else
					{
						strTMLC = strTMLC + "," + item.UID;
					}
				}
			}

			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			if (object.Equals(config.AppSettings.Settings["tmlc"], null))
				config.AppSettings.Settings.Add("tmlc", strTMLC);
			else
				config.AppSettings.Settings["tmlc"].Value = strTMLC;

			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");

			MessageBox.Show("设置已保存！");
			this.Close();
		}

		private class BaseTMLC
		{
			public string UID { get; set; }
			public string TMLCName { get; set; }
		}

		#endregion

		private void chkDishFixedShow_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDishFixedShow.Checked)
			{
				chkDishFixed.Checked = false;
				chkDishFixed.Enabled = false;
			}
			else
			{
				chkDishFixed.Enabled = true;
			}
		}

		private void chkDishFixed_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDishFixed.Checked)
			{
				chkDishFixedShow.Checked = false;
				chkDishFixedShow.Enabled = false;
			}
			else
			{
				chkDishFixedShow.Enabled = true;
			}
		}

	}
}
