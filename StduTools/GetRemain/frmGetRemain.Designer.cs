namespace StduTools
{
    partial class frmGetRemain
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.labPwd = new System.Windows.Forms.Label();
            this.labNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 14F);
            this.btnOK.Location = new System.Drawing.Point(69, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(132, 39);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 14F);
            this.txtPwd.Location = new System.Drawing.Point(195, 90);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(178, 34);
            this.txtPwd.TabIndex = 11;
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("宋体", 14F);
            this.txtNumber.Location = new System.Drawing.Point(195, 34);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(178, 34);
            this.txtNumber.TabIndex = 10;
            // 
            // labPwd
            // 
            this.labPwd.AutoSize = true;
            this.labPwd.Font = new System.Drawing.Font("宋体", 16F);
            this.labPwd.Location = new System.Drawing.Point(11, 97);
            this.labPwd.Name = "labPwd";
            this.labPwd.Size = new System.Drawing.Size(147, 27);
            this.labPwd.TabIndex = 9;
            this.labPwd.Text = "一卡通密码";
            // 
            // labNumber
            // 
            this.labNumber.AutoSize = true;
            this.labNumber.Font = new System.Drawing.Font("宋体", 16F);
            this.labNumber.Location = new System.Drawing.Point(92, 41);
            this.labNumber.Name = "labNumber";
            this.labNumber.Size = new System.Drawing.Size(66, 27);
            this.labNumber.TabIndex = 8;
            this.labNumber.Text = "学号";
            // 
            // frmGetRemain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 253);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.labPwd);
            this.Controls.Add(this.labNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGetRemain";
            this.ShowIcon = false;
            this.Text = "登陆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGetRemain_FormClosing);
            this.Load += new System.EventHandler(this.frmGetRemain_Load);
            this.Shown += new System.EventHandler(this.frmGetRemain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label labPwd;
        private System.Windows.Forms.Label labNumber;
    }
}