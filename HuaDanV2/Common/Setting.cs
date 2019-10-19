using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace HuaDan
{
    public class Setting
    {
        public static void setLocalSettingsString(string name, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (object.Equals(config.AppSettings.Settings[name], null))
                config.AppSettings.Settings.Add(name, value);
            else
                config.AppSettings.Settings[name].Value = value;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
