namespace SHARED.Views
{
    partial class viewSuaThongTinCaNhan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewSuaThongTinCaNhan));
            this.memoEdit_mota = new DevExpress.XtraEditors.MemoEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_email = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_hoten = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit_showpass = new DevExpress.XtraEditors.CheckEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit_oldpass = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_newpass_confirm = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_newpass = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_mota.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_hoten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_showpass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_oldpass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass_confirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoEdit_mota
            // 
            this.memoEdit_mota.Location = new System.Drawing.Point(346, 3);
            this.memoEdit_mota.Name = "memoEdit_mota";
            this.memoEdit_mota.Size = new System.Drawing.Size(202, 144);
            this.memoEdit_mota.TabIndex = 82;
            this.memoEdit_mota.UseOptimizedRendering = true;
            this.memoEdit_mota.EditValueChanged += new System.EventHandler(this.memoEdit_mota_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 78;
            this.label4.Text = "Mô tả:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "Email:";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // textEdit_email
            // 
            this.textEdit_email.Location = new System.Drawing.Point(83, 34);
            this.textEdit_email.Name = "textEdit_email";
            this.textEdit_email.Size = new System.Drawing.Size(185, 20);
            this.textEdit_email.TabIndex = 76;
            this.textEdit_email.EditValueChanged += new System.EventHandler(this.textEdit_email_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 75;
            this.labelControl1.Text = "Họ tên:";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // textEdit_hoten
            // 
            this.textEdit_hoten.Location = new System.Drawing.Point(83, 4);
            this.textEdit_hoten.Name = "textEdit_hoten";
            this.textEdit_hoten.Size = new System.Drawing.Size(185, 20);
            this.textEdit_hoten.TabIndex = 71;
            this.textEdit_hoten.EditValueChanged += new System.EventHandler(this.textEdit_hoten_EditValueChanged);
            // 
            // checkEdit_showpass
            // 
            this.checkEdit_showpass.Location = new System.Drawing.Point(1, 157);
            this.checkEdit_showpass.Name = "checkEdit_showpass";
            this.checkEdit_showpass.Properties.Caption = "Hiện mật khẩu";
            this.checkEdit_showpass.Size = new System.Drawing.Size(124, 19);
            this.checkEdit_showpass.TabIndex = 83;
            this.checkEdit_showpass.CheckedChanged += new System.EventHandler(this.checkEdit_showpass_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Mật khẩu mới:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Xác nhận:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Mật khẩu cũ:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textEdit_oldpass
            // 
            this.textEdit_oldpass.Location = new System.Drawing.Point(83, 65);
            this.textEdit_oldpass.Name = "textEdit_oldpass";
            this.textEdit_oldpass.Properties.PasswordChar = '●';
            this.textEdit_oldpass.Size = new System.Drawing.Size(185, 20);
            this.textEdit_oldpass.TabIndex = 79;
            this.textEdit_oldpass.ToolTip = "Để trống nếu không muốn đổi mật khẩu";
            this.textEdit_oldpass.EditValueChanged += new System.EventHandler(this.textEdit_oldpass_EditValueChanged);
            // 
            // textEdit_newpass_confirm
            // 
            this.textEdit_newpass_confirm.Location = new System.Drawing.Point(83, 127);
            this.textEdit_newpass_confirm.Name = "textEdit_newpass_confirm";
            this.textEdit_newpass_confirm.Properties.PasswordChar = '●';
            this.textEdit_newpass_confirm.Size = new System.Drawing.Size(185, 20);
            this.textEdit_newpass_confirm.TabIndex = 81;
            this.textEdit_newpass_confirm.ToolTip = "Để trống nếu không muốn đổi mật khẩu";
            this.textEdit_newpass_confirm.EditValueChanged += new System.EventHandler(this.textEdit_newpass_confirm_EditValueChanged);
            // 
            // textEdit_newpass
            // 
            this.textEdit_newpass.Location = new System.Drawing.Point(83, 96);
            this.textEdit_newpass.Name = "textEdit_newpass";
            this.textEdit_newpass.Properties.PasswordChar = '●';
            this.textEdit_newpass.Size = new System.Drawing.Size(185, 20);
            this.textEdit_newpass.TabIndex = 80;
            this.textEdit_newpass.ToolTip = "Để trống nếu không muốn đổi mật khẩu";
            this.textEdit_newpass.EditValueChanged += new System.EventHandler(this.textEdit_newpass_EditValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(473, 155);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 84;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // viewSuaThongTinCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.memoEdit_mota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEdit_email);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit_hoten);
            this.Controls.Add(this.checkEdit_showpass);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit_oldpass);
            this.Controls.Add(this.textEdit_newpass_confirm);
            this.Controls.Add(this.textEdit_newpass);
            this.Name = "viewSuaThongTinCaNhan";
            this.Size = new System.Drawing.Size(551, 183);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_mota.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_hoten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_showpass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_oldpass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass_confirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.MemoEdit memoEdit_mota;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit textEdit_email;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit textEdit_hoten;
        public DevExpress.XtraEditors.CheckEdit checkEdit_showpass;
        public DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit textEdit_oldpass;
        public DevExpress.XtraEditors.TextEdit textEdit_newpass_confirm;
        public DevExpress.XtraEditors.TextEdit textEdit_newpass;
    }
}
