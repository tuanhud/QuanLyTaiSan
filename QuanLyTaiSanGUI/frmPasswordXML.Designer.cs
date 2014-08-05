namespace QuanLyTaiSanGUI
{
    partial class frmPasswordXML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPasswordXML));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Password = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Password";
            // 
            // textEdit_Password
            // 
            this.textEdit_Password.Location = new System.Drawing.Point(74, 12);
            this.textEdit_Password.Name = "textEdit_Password";
            this.textEdit_Password.Properties.UseSystemPasswordChar = true;
            this.textEdit_Password.Size = new System.Drawing.Size(218, 20);
            this.textEdit_Password.TabIndex = 0;
            this.textEdit_Password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textEdit_Password_KeyUp);
            // 
            // simpleButton_Ok
            // 
            this.simpleButton_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton_Ok.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Ok.Image")));
            this.simpleButton_Ok.Location = new System.Drawing.Point(217, 38);
            this.simpleButton_Ok.Name = "simpleButton_Ok";
            this.simpleButton_Ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Ok.TabIndex = 1;
            this.simpleButton_Ok.Text = "Ok";
            this.simpleButton_Ok.Click += new System.EventHandler(this.simpleButton_Ok_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmPasswordXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 74);
            this.Controls.Add(this.simpleButton_Ok);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit_Password);
            this.Name = "frmPasswordXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDatPasswordXML";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_Ok;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit textEdit_Password;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}