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

namespace HuaDan
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + "\\rem.bin";
                if (System.IO.File.Exists(path))
                {
                    string content = System.IO.File.ReadAllText(path);
                    if (!string.IsNullOrEmpty(content))
                    {
                        string[] userpwd = content.Split('|');
                        if (userpwd.Length == 3)
                        {
                            if ("1".Equals(userpwd[0]))
                            {
                                txtUserID.Text = userpwd[1];
                                txtPassword.Text = userpwd[2];
                                chkRemember.Checked = true;
                            }
                            else if ("0".Equals(userpwd[0]))
                            {
                                chkRemember.Checked = false;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (object.Equals(Tools.CurrentUser, null))
                Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.AppSettings["dbconn"];
            using(SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT UID,GroupID,StoreID,UserID,TrueName,Password FROM SysGroupUser WHERE UserID=@UserID";
                cmd.Parameters.AddWithValue("@UserID",txtUserID.Text.Trim());

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string password = reader.GetString(5);
						string encryptedPwd = "";
						if (!string.IsNullOrWhiteSpace(txtPassword.Text))
							encryptedPwd = RSAEncrypt.EncryptString(txtPassword.Text);
						if (string.Equals(password, encryptedPwd))
                        {
                            SysGroupUser user = new SysGroupUser();
                            user.UID = reader.GetString(0);
                            user.GroupID = reader.GetInt32(1);
                            user.StoreID = reader.GetInt32(2);
                            user.UserID = reader.GetString(3);
                            user.TrueName = reader.GetString(4);
                            Tools.CurrentUser = user;
                            //this.Close();
                            //string isMergeDish = System.Configuration.ConfigurationManager.AppSettings["IsMergeDish"];
                            //string zhuotaimode = System.Configuration.ConfigurationManager.AppSettings["zhuotaimode"];
                            //if (!string.IsNullOrEmpty(zhuotaimode) && "2".Equals(zhuotaimode) && !string.IsNullOrEmpty(isMergeDish) && "1".Equals(isMergeDish))
                            //{
                            //    frmDanXiangMergeDish.Instance.StartMonitor();
                            //}
                            //else
                            //    frmMain.Instance.StartMonitor();
                            RememberUser();

                            this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态
                            this.Close();    //关闭登录窗口
                        }
                        else
                        {
                            MessageBox.Show("密码错误！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户不存在！");
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("登录失败！\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                }
            }


        }

        private void RememberUser()
        {
            try
            {
                string path = Application.StartupPath + "\\rem.bin";
                string content = "";
                if(chkRemember.Checked)
                    content = "1|" + txtUserID.Text.Trim() + "|" + txtPassword.Text;
                else
                    content = "0||";
                System.IO.File.WriteAllText(path, content);
            }
            catch { }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            //new frmSetup().ShowDialog();
            frmSetup frm = new frmSetup();
            frm.ShowDialog();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
                txtUserID.Focus();
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  
    }
}
