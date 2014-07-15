namespace QuanLyTaiSanGUI.HeThong
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.textEdit_username = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_password = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit_remember = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.button_ok = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.labelControl_msg = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_remember.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_username
            // 
            this.textEdit_username.EditValue = "";
            this.textEdit_username.Location = new System.Drawing.Point(144, 39);
            this.textEdit_username.Name = "textEdit_username";
            this.textEdit_username.Size = new System.Drawing.Size(180, 20);
            this.textEdit_username.TabIndex = 0;
            this.textEdit_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit_username_KeyPress);
            this.textEdit_username.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textEdit_username_KeyUp);
            // 
            // textEdit_password
            // 
            this.textEdit_password.EditValue = "";
            this.textEdit_password.Location = new System.Drawing.Point(144, 68);
            this.textEdit_password.Name = "textEdit_password";
            this.textEdit_password.Properties.PasswordChar = '•';
            this.textEdit_password.Size = new System.Drawing.Size(180, 20);
            this.textEdit_password.TabIndex = 1;
            this.textEdit_password.EditValueChanged += new System.EventHandler(this.textEdit_password_EditValueChanged);
            this.textEdit_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit_password_KeyPress);
            this.textEdit_password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textEdit_password_KeyUp);
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
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(92, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // checkEdit_remember
            // 
            this.checkEdit_remember.EditValue = true;
            this.checkEdit_remember.Location = new System.Drawing.Point(142, 94);
            this.checkEdit_remember.Name = "checkEdit_remember";
            this.checkEdit_remember.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.checkEdit_remember.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit_remember.Properties.Caption = "Ghi nhớ phiên";
            this.checkEdit_remember.Size = new System.Drawing.Size(182, 19);
            this.checkEdit_remember.TabIndex = 4;
            this.checkEdit_remember.CheckedChanged += new System.EventHandler(this.checkEdit_remember_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureEdit1);
            this.groupBox1.Controls.Add(this.labelControl_msg);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.textEdit_username);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.button_ok);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.textEdit_password);
            this.groupBox1.Controls.Add(this.checkEdit_remember);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 149);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý phòng học";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.AllowDrop = true;
            this.pictureEdit1.EditValue = global::QuanLyTaiSanGUI.Properties.Resources.login;
            this.pictureEdit1.Location = new System.Drawing.Point(18, 42);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.InitialImage")));
            this.pictureEdit1.Size = new System.Drawing.Size(68, 71);
            this.pictureEdit1.TabIndex = 9;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(262, 119);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(62, 23);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // button_ok
            // 
            this.button_ok.Image = ((System.Drawing.Image)(resources.GetObject("button_ok.Image")));
            this.button_ok.Location = new System.Drawing.Point(175, 119);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(81, 23);
            this.button_ok.TabIndex = 7;
            this.button_ok.Text = "Đăng nhập";
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelControl_msg
            // 
            this.labelControl_msg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl_msg.Location = new System.Drawing.Point(144, 22);
            this.labelControl_msg.Name = "labelControl_msg";
            this.labelControl_msg.Size = new System.Drawing.Size(49, 13);
            this.labelControl_msg.TabIndex = 6;
            this.labelControl_msg.Text = "Tình trạng";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(354, 175);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_remember.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_username;
        private DevExpress.XtraEditors.TextEdit textEdit_password;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit checkEdit_remember;
        private DevExpress.XtraEditors.SimpleButton button_ok;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl_msg;
    }
}