namespace QuanLyTaiSanGUI.HeThong
{
    partial class DoiMatKhau
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
            this.textEdit_newpass = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_newpass_confirm = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_oldpass = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass_confirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_oldpass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_newpass
            // 
            this.textEdit_newpass.Location = new System.Drawing.Point(94, 44);
            this.textEdit_newpass.Name = "textEdit_newpass";
            this.textEdit_newpass.Properties.PasswordChar = '●';
            this.textEdit_newpass.Size = new System.Drawing.Size(185, 20);
            this.textEdit_newpass.TabIndex = 0;
            // 
            // textEdit_newpass_confirm
            // 
            this.textEdit_newpass_confirm.Location = new System.Drawing.Point(94, 75);
            this.textEdit_newpass_confirm.Name = "textEdit_newpass_confirm";
            this.textEdit_newpass_confirm.Properties.PasswordChar = '●';
            this.textEdit_newpass_confirm.Size = new System.Drawing.Size(185, 20);
            this.textEdit_newpass_confirm.TabIndex = 1;
            // 
            // textEdit_oldpass
            // 
            this.textEdit_oldpass.Location = new System.Drawing.Point(94, 13);
            this.textEdit_oldpass.Name = "textEdit_oldpass";
            this.textEdit_oldpass.Properties.PasswordChar = '●';
            this.textEdit_oldpass.Size = new System.Drawing.Size(185, 20);
            this.textEdit_oldpass.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mật khẩu cũ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Xác nhận:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(204, 101);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(14, 105);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Hiện mật khẩu";
            this.checkEdit1.Size = new System.Drawing.Size(124, 19);
            this.checkEdit1.TabIndex = 7;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 139);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit_oldpass);
            this.Controls.Add(this.textEdit_newpass_confirm);
            this.Controls.Add(this.textEdit_newpass);
            this.Name = "DoiMatKhau";
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_newpass_confirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_oldpass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_newpass;
        private DevExpress.XtraEditors.TextEdit textEdit_newpass_confirm;
        private DevExpress.XtraEditors.TextEdit textEdit_oldpass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}