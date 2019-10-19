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
    public partial class frmPort : Form
    {
        public frmPort()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCallNumPort.Text.Trim()))
            {
                MessageBox.Show("请先输入叫号端口号！");
                return;
            }
            try
            {
                int port = Convert.ToInt32(txtCallNumPort.Text.Trim());
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (object.Equals(config.AppSettings.Settings["CallNumPort"], null))
                    config.AppSettings.Settings.Add("CallNumPort", txtCallNumPort.Text.Trim());
                else
                    config.AppSettings.Settings["CallNumPort"].Value = txtCallNumPort.Text.Trim();

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请正确输入端口号！");
            }
        }

        private void frmPort_Load(object sender, EventArgs e)
        {
            setOemInfo();
            string callNumPort = ConfigurationManager.AppSettings["CallNumPort"];
            if (!string.IsNullOrEmpty(callNumPort))
            {
                txtCallNumPort.Text = callNumPort;
            }
            else {
                txtCallNumPort.Text = "35255";
            }
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
                Log.WriteLog("femPort setOemInfo():" + ex.ToString());
            }
        }
    }
}
