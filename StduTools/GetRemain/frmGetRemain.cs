using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace StduTools
{
    public partial class frmGetRemain : Form
    {
        public static string Html;
        string[] args = null;
        //初始化注册表操作
        ClsRegedit RegContral = new ClsRegedit("SdtuTools");

        public frmGetRemain()
        {
            InitializeComponent();
        }
        public frmGetRemain(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //更改按钮内容以提示
            btnOK.Text = "请稍后";
            //禁用按钮防止多点
            btnOK.Enabled = false;

            //禁用输入
            txtNumber.Enabled = false;
            txtPwd.Enabled = false;

            //检查网络
            if (!ClsTools.IsNetReady())
            {
                MessageBox.Show("网络连接失败！");
                //更改按钮状态
                   btnOK.Enabled = true;
                txtNumber.Enabled = true;
                txtPwd.Enabled = true;
                btnOK.Text = "确认";
                return;
            }
            if (Work())
            {
                frmNotice frmNoticeContral = new frmNotice();
                frmNoticeContral.Show();
            }
        }


        private bool Work()
        {
            CookieContainer cookie = GetRemainClsCookie.GetCookie(txtNumber.Text, txtPwd.Text);
            //判断是否登陆成功
            if (GetRemainClsCookie.IsReady(cookie))
            {
                //成功
                //保存信息到注册表

                RegContral.SetValue("UserName", txtNumber.Text);
                RegContral.SetValue("UserPwd", txtPwd.Text);
                this.Hide();
                return true;

            }
            else
            {
                //失败
                MessageBox.Show("登陆失败！");
                //更改按钮状态
                btnOK.Enabled = true;
                txtNumber.Enabled = true;
                txtPwd.Enabled = true;
                btnOK.Text = "确认";
                this.Visible = true;
                return false;
            }
        }

        private void frmGetRemain_FormClosing(object sender, FormClosingEventArgs e)
        {

            //释放注册表操作
            RegContral = null;
            Application.Exit();
        
    }

        private void frmGetRemain_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
            //判断是否为开机自启
            if (args == null)
            {
                this.Visible = true;
                return;
            }
            //判断网络是否正常
            while (!ClsTools.IsNetReady())
            {
                System.Threading.Thread.Sleep(60000);
            }
            if (Work())
            {
                frmNotice frmNoticeContral = new frmNotice();
                frmNoticeContral.Show();
            }
            else
            {
                //显示引导界面
                this.Visible = true;
                return;
            }
        }

        private void frmGetRemain_Load(object sender, EventArgs e)
        {
            //注册表有键值存在
            if (RegContral.IsKeyExit("UserName") && RegContral.IsKeyExit("UserPwd"))
            {
                txtNumber.Text = RegContral.GetKey("UserName");
                txtPwd.Text = RegContral.GetKey("UserPwd");
            }
            else
            {
                //首次启动
                //提示是否添加开机启动项
                if (MessageBox.Show("是否添加到开机启动？(稍后可取消)", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    RegContral.SetValue("AutoRun", "1");
                    //设置开机启动项
                    //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
                    RegistryKey key = Registry.CurrentUser;
                    RegistryKey SubKey = key.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion", true).CreateSubKey("Run");
                    SubKey.SetValue("StduTools", Application.ExecutablePath + " -e");
                }

            }
        }
    }
}
