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
    public partial class frmMain : Form
    {
        string[] args = null;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }
        //当前软件版本
        public static string MyVersion = "0.0.1.0";
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {

            //隐藏主窗体
            this.Hide();
            //加载功能窗体
            frmGetRemain fgrContral = new frmGetRemain(args);
            fgrContral.Show();
        
    }
    }
}
