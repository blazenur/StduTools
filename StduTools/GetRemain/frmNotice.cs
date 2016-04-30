using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace StduTools
{
    public partial class frmNotice : Form
    {

        //初始化注册表操作
        ClsRegedit RegContral = new ClsRegedit("SdtuTools");

        public frmNotice()
        {
            InitializeComponent();
        }

        private void frmNotice_Load(object sender, EventArgs e)
        {
            this.nfNotice.Visible = true;//显示此种效果

            this.nfNotice.ShowBalloonTip(1000, "剩余流量：", GetRemain(), ToolTipIcon.Info);

            if (RegContral.GetKey("AutoExit") == "1")
            {
                //倒计时30s后自动退出程序
                tmAutoExit.Enabled = true;
            }

        }

        //识别剩余流量
        private string GetRemain()
        {
            return Regex.Replace(Regex.Replace(Regex.Match(frmGetRemain.Html, "<tr><td>剩余流量</td><td id=\"remain_flow\">(.*?)</td></tr>").ToString(), "<tr><td>剩余流量</td><td id=\"remain_flow\">", ""), "</td></tr>", "");
        }
        private void frmNotice_FormClosing(object sender, FormClosingEventArgs e)
        {
            nfNotice.Visible = false;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //自启选项检查
            if (cbAutoRun.Checked)
            {
                RegContral.SetValue("AutoRun", "1");
                //设置开机启动项
                //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
                RegistryKey key = Registry.CurrentUser;
                RegistryKey SubKey = key.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true).CreateSubKey("Run");
                SubKey.SetValue("StduTools", Application.ExecutablePath + " -e");

            }
            else
            {
                RegContral.SetValue("AutoRun", "0");
                try
                {
                    RegistryKey key = Registry.CurrentUser;
                    RegistryKey SubKey = key.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true).CreateSubKey("Run");
                    SubKey.DeleteValue("StduTools");
                }
                catch { }
            }
            //自退选项检查
            if (cbAutoExit.Checked)
            {
                RegContral.SetValue("AutoExit", "1");
                tmAutoExit.Enabled = true;
            }
            else
            {
                RegContral.SetValue("AutoExit", "0");
                tmAutoExit.Enabled = false;
            }
            //更新选项检查
            if (cbAutoUpdate.Checked)
            {
                RegContral.SetValue("AutoUpdate", "1");
                tmAutoExit.Enabled = true;
            }
            else
            {
                RegContral.SetValue("AutoUpdate", "0");
                tmAutoExit.Enabled = false;
            }
            this.Visible = false;
        }

        private void frmNotice_Shown(object sender, EventArgs e)
        {
            //加载配置选项

            if (!RegContral.IsKeyExit("AutoRun") || RegContral.GetKey("AutoRun") == "0")
            {
                cbAutoRun.Checked = false;
            }
            else
            {
                cbAutoRun.Checked = true;
            }
            if (!RegContral.IsKeyExit("AutoExit") || RegContral.GetKey("AutoExit") == "0")
            {
                cbAutoExit.Checked = false;
            }
            else
            {
                cbAutoExit.Checked = true;
            }
            if (!RegContral.IsKeyExit("AutoUpdate") || RegContral.GetKey("AutoUpdate") == "0")
            {
                cbAutoUpdate.Checked = false;
            }
            else
            {
                cbAutoUpdate.Checked = true;
            }
            //检查更新
            if (cbAutoUpdate.Checked == true)
            {
                Thread t = new Thread(new ThreadStart(AutoUpdate));
            }
            this.Visible = false;
        }

        private void AutoUpdate()
        {
            //检查程序更新
            CookieContainer cookie = new CookieContainer();
            string html = ClsHttp.GetHttp("https://raw.githubusercontent.com/blazenur/StduTools/dev/Update.txt", "", ref cookie);
            if (Regex.IsMatch(html, "StduToolsVersion:"))
            {
                string version = Regex.Replace(html, "StduToolsVersion:", "");
                if (version != frmMain.MyVersion)
                {
                    if (MessageBox.Show("发现新版本，是否前往下载？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://raw.githubusercontent.com/blazenur/StduTools/dev/Release/StduTools.exe");
                    }
                }
            }
        }


        private void nfNotice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.Activate();
        }

        private void tmAutoExit_Tick(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                nfNotice.Visible = false;
                Application.Exit();
            }
        }

        private void tmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmAbout_Click(object sender, EventArgs e)
        {
            frmAbout frmAboutContral = new frmAbout();
            tmAutoExit.Enabled = false;
            frmAboutContral.ShowDialog();
            tmAutoExit.Enabled = true;
        }

        private void tmSetting_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }



        private void nfNotice_MouseDown(object sender, MouseEventArgs e)
        {
            this.nfNotice.ShowBalloonTip(1000, "剩余流量：", GetRemain(), ToolTipIcon.Info);
        }
    }
}
