using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace HuaDan
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Init();

			frmLogin fl = new frmLogin();
			fl.ShowDialog();
			if (fl.DialogResult == DialogResult.OK)
			{
				string isMergeDish = System.Configuration.ConfigurationManager.AppSettings["IsMergeDish"];
				string isDishFixed = System.Configuration.ConfigurationManager.AppSettings["IsDishFixed"];
				string isDishFixedShow = System.Configuration.ConfigurationManager.AppSettings["IsDishFixedShow"];
				string zhuotaimode = System.Configuration.ConfigurationManager.AppSettings["zhuotaimode"];
				string userMainNew = System.Configuration.ConfigurationManager.AppSettings["userMainNew"];
				if (!string.IsNullOrEmpty(userMainNew) && "1".Equals(userMainNew))
				{
					Application.Run(new frmMainNew());
				}
				else if (!string.IsNullOrEmpty(zhuotaimode) && "2".Equals(zhuotaimode) && !string.IsNullOrEmpty(isMergeDish) && "1".Equals(isMergeDish))
				{
					if (!string.IsNullOrEmpty(isDishFixed) && "1".Equals(isDishFixed))
						Application.Run(new frmDanXiangMergeDishFixed());
					else if (!string.IsNullOrEmpty(isDishFixedShow) && "1".Equals(isDishFixedShow))
						Application.Run(new frmFixedDishesMergeNum());
					else
						Application.Run(new frmDanXiangMergeDish());
				}
				else if (!string.IsNullOrEmpty(zhuotaimode) && "3".Equals(zhuotaimode))
				{
					Application.Run(new frmZTDish());
				}
				else
				{
					Application.Run(new frmMain());
				}
			}
			else
			{
				return;
			}
		}

		public static void Init()
		{
			//从主程序复制数据库连接
			if (File.Exists("CaiMomoClient.exe.Config"))
			{
				XmlDocument doc = new XmlDocument();
				doc.Load("CaiMomoClient.exe.Config");
				XmlElement root = doc.DocumentElement;
				XmlNode appSettings = root.SelectSingleNode("appSettings");
				XmlNode defaultUrl = appSettings.SelectSingleNode("add[@key='defaulturl']");
				string valDefaultUrl = defaultUrl.Attributes["value"].Value;

				Setting.setLocalSettingsString("serverurl", valDefaultUrl);
			}
		}
	}
}
