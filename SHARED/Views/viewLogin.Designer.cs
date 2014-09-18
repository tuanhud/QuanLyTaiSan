namespace SHARED.Views
{
    partial class viewLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewLogin));
            this.groupBox_Title = new System.Windows.Forms.GroupBox();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.cbRemember = new DevExpress.XtraEditors.CheckEdit();
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetLocalSetting = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRemember.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Title
            // 
            this.groupBox_Title.Controls.Add(this.pictureEdit1);
            this.groupBox_Title.Controls.Add(this.txtMessage);
            this.groupBox_Title.Controls.Add(this.btnThoat);
            this.groupBox_Title.Controls.Add(this.txtUsername);
            this.groupBox_Title.Controls.Add(this.labelControl2);
            this.groupBox_Title.Controls.Add(this.btnOK);
            this.groupBox_Title.Controls.Add(this.labelControl1);
            this.groupBox_Title.Controls.Add(this.txtPassword);
            this.groupBox_Title.Controls.Add(this.cbRemember);
            this.groupBox_Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Title.ForeColor = System.Drawing.Color.Blue;
            this.groupBox_Title.Location = new System.Drawing.Point(3, 30);
            this.groupBox_Title.Name = "groupBox_Title";
            this.groupBox_Title.Size = new System.Drawing.Size(330, 149);
            this.groupBox_Title.TabIndex = 10;
            this.groupBox_Title.TabStop = false;
            this.groupBox_Title.Text = "Quản lý phòng học";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.AllowDrop = true;
            this.pictureEdit1.EditValue = global::SHARED.Properties.Resources.login;
            this.pictureEdit1.Location = new System.Drawing.Point(18, 42);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.InitialImage")));
            this.pictureEdit1.Size = new System.Drawing.Size(68, 71);
            this.pictureEdit1.TabIndex = 9;
            // 
            // txtMessage
            // 
            this.txtMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(144, 22);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(49, 13);
            this.txtMessage.TabIndex = 6;
            this.txtMessage.Text = "Tình trạng";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(262, 119);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(62, 23);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            // 
            // txtUsername
            // 
            this.txtUsername.EditValue = "";
            this.txtUsername.Location = new System.Drawing.Point(144, 39);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(180, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(92, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(175, 119);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Đăng nhập";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(92, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tài khoản";
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(144, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(180, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // cbRemember
            // 
            this.cbRemember.EditValue = true;
            this.cbRemember.Location = new System.Drawing.Point(142, 94);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cbRemember.Properties.Appearance.Options.UseForeColor = true;
            this.cbRemember.Properties.Caption = "Ghi nhớ phiên";
            this.cbRemember.Size = new System.Drawing.Size(182, 19);
            this.cbRemember.TabIndex = 4;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(4, 4);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 11;
            this.btnSync.TabStop = false;
            this.btnSync.Text = "Đồng bộ";
            // 
            // btnResetLocalSetting
            // 
            this.btnResetLocalSetting.Location = new System.Drawing.Point(105, 4);
            this.btnResetLocalSetting.Name = "btnResetLocalSetting";
            this.btnResetLocalSetting.Size = new System.Drawing.Size(91, 23);
            this.btnResetLocalSetting.TabIndex = 12;
            this.btnResetLocalSetting.TabStop = false;
            this.btnResetLocalSetting.Text = "Reset cấu hình";
            // 
            // viewLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResetLocalSetting);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.groupBox_Title);
            this.Name = "viewLogin";
            this.Size = new System.Drawing.Size(337, 182);
            this.Load += new System.EventHandler(this.viewLogin_Load);
            this.groupBox_Title.ResumeLayout(false);
            this.groupBox_Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRemember.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox_Title;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        public DevExpress.XtraEditors.LabelControl txtMessage;
        public DevExpress.XtraEditors.SimpleButton btnThoat;
        public DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtPassword;
        public DevExpress.XtraEditors.CheckEdit cbRemember;
        public DevExpress.XtraEditors.SimpleButton btnSync;
        public DevExpress.XtraEditors.SimpleButton btnResetLocalSetting;
    }
}
