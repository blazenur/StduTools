using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StduTools
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //注册表操作初始化
            ClsRegedit RegContral = new ClsRegedit("SdtuTools");
            //清理注册表
            try
            {

                RegContral.DeleteSubKey("StduTools");
            }
            catch { }
            try
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey SubKey = key.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true).CreateSubKey("Run");
                SubKey.DeleteValue("StduTools");
            }
            catch { }
            MessageBox.Show("卸载完成！");
            Application.Exit();
        }
    }
}
