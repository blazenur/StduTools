namespace StduTools
{
    partial class frmNotice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotice));
            this.cbAutoExit = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbAutoRun = new System.Windows.Forms.CheckBox();
            this.tmAutoExit = new System.Windows.Forms.Timer(this.components);
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.nfNotice = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.cmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAutoExit
            // 
            this.cbAutoExit.AutoSize = true;
            this.cbAutoExit.Font = new System.Drawing.Font("宋体", 12F);
            this.cbAutoExit.Location = new System.Drawing.Point(67, 66);
            this.cbAutoExit.Name = "cbAutoExit";
            this.cbAutoExit.Size = new System.Drawing.Size(111, 24);
            this.cbAutoExit.TabIndex = 6;
            this.cbAutoExit.Text = "自动退出";
            this.cbAutoExit.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F);
            this.btnOK.Location = new System.Drawing.Point(77, 155);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 45);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbAutoRun
            // 
            this.cbAutoRun.AutoSize = true;
            this.cbAutoRun.Font = new System.Drawing.Font("宋体", 12F);
            this.cbAutoRun.Location = new System.Drawing.Point(67, 27);
            this.cbAutoRun.Name = "cbAutoRun";
            this.cbAutoRun.Size = new System.Drawing.Size(151, 24);
            this.cbAutoRun.TabIndex = 4;
            this.cbAutoRun.Text = "开机自动启动";
            this.cbAutoRun.UseVisualStyleBackColor = true;
            // 
            // tmAutoExit
            // 
            this.tmAutoExit.Interval = 30000;
            this.tmAutoExit.Tick += new System.EventHandler(this.tmAutoExit_Tick);
            // 
            // cmMenu
            // 
            this.cmMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmSetting,
            this.tmAbout,
            this.tmExit});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(115, 82);
            // 
            // tmSetting
            // 
            this.tmSetting.Name = "tmSetting";
            this.tmSetting.Size = new System.Drawing.Size(114, 26);
            this.tmSetting.Text = "设置";
            this.tmSetting.Click += new System.EventHandler(this.tmSetting_Click);
            // 
            // tmAbout
            // 
            this.tmAbout.Name = "tmAbout";
            this.tmAbout.Size = new System.Drawing.Size(114, 26);
            this.tmAbout.Text = "关于";
            this.tmAbout.Click += new System.EventHandler(this.tmAbout_Click);
            // 
            // tmExit
            // 
            this.tmExit.Name = "tmExit";
            this.tmExit.Size = new System.Drawing.Size(114, 26);
            this.tmExit.Text = "退出";
            this.tmExit.Click += new System.EventHandler(this.tmExit_Click);
            // 
            // nfNotice
            // 
            this.nfNotice.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nfNotice.ContextMenuStrip = this.cmMenu;
            this.nfNotice.Icon = ((System.Drawing.Icon)(resources.GetObject("nfNotice.Icon")));
            this.nfNotice.Text = "剩余流量查询";
            this.nfNotice.Visible = true;
            this.nfNotice.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfNotice_MouseDoubleClick);
            this.nfNotice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nfNotice_MouseDown);
            // 
            // cbAutoUpdate
            // 
            this.cbAutoUpdate.AutoSize = true;
            this.cbAutoUpdate.Font = new System.Drawing.Font("宋体", 12F);
            this.cbAutoUpdate.Location = new System.Drawing.Point(66, 105);
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.Size = new System.Drawing.Size(111, 24);
            this.cbAutoUpdate.TabIndex = 8;
            this.cbAutoUpdate.Text = "检查更新";
            this.cbAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // frmNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 272);
            this.ControlBox = false;
            this.Controls.Add(this.cbAutoUpdate);
            this.Controls.Add(this.cbAutoExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbAutoRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNotice";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.frmNotice_Load);
            this.Shown += new System.EventHandler(this.frmNotice_Shown);
            this.cmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAutoExit;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbAutoRun;
        private System.Windows.Forms.Timer tmAutoExit;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem tmSetting;
        private System.Windows.Forms.ToolStripMenuItem tmAbout;
        private System.Windows.Forms.ToolStripMenuItem tmExit;
        private System.Windows.Forms.NotifyIcon nfNotice;
        private System.Windows.Forms.CheckBox cbAutoUpdate;
    }
}