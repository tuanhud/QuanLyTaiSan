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
            this.textEdit_username = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_password = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit_remember = new DevExpress.XtraEditors.CheckEdit();
            this.button_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_remember.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_username
            // 
            this.textEdit_username.Location = new System.Drawing.Point(86, 24);
            this.textEdit_username.Name = "textEdit_username";
            this.textEdit_username.Size = new System.Drawing.Size(180, 20);
            this.textEdit_username.TabIndex = 0;
            // 
            // textEdit_password
            // 
            this.textEdit_password.Location = new System.Drawing.Point(86, 53);
            this.textEdit_password.Name = "textEdit_password";
            this.textEdit_password.Size = new System.Drawing.Size(180, 20);
            this.textEdit_password.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tài khoản";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // checkEdit_remember
            // 
            this.checkEdit_remember.Location = new System.Drawing.Point(84, 79);
            this.checkEdit_remember.Name = "checkEdit_remember";
            this.checkEdit_remember.Properties.Caption = "Ghi nhớ phiên";
            this.checkEdit_remember.Size = new System.Drawing.Size(182, 19);
            this.checkEdit_remember.TabIndex = 4;
            // 
            // button_ok
            // 
            this.button_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ok.Location = new System.Drawing.Point(176, 103);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(90, 23);
            this.button_ok.TabIndex = 5;
            this.button_ok.Text = "Đăng nhập";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 147);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.checkEdit_remember);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit_password);
            this.Controls.Add(this.textEdit_username);
            this.Name = "Login";
            this.Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_remember.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_username;
        private DevExpress.XtraEditors.TextEdit textEdit_password;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit checkEdit_remember;
        private System.Windows.Forms.Button button_ok;
    }
}