namespace QuanLyTaiSanGUI.MyUC
{
    partial class ucThemSuaXoaButton
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
            this.btnR_Sua = new DevExpress.XtraEditors.SimpleButton();
            this.btnR_Them = new DevExpress.XtraEditors.SimpleButton();
            this.btnR_Xoa = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnR_Sua
            // 
            this.btnR_Sua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnR_Sua.Image = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit_24;
            this.btnR_Sua.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Sua.Location = new System.Drawing.Point(30, 3);
            this.btnR_Sua.Name = "btnR_Sua";
            this.btnR_Sua.Size = new System.Drawing.Size(23, 23);
            this.btnR_Sua.TabIndex = 27;
            this.btnR_Sua.Click += new System.EventHandler(this.btnR_Sua_Click);
            // 
            // btnR_Them
            // 
            this.btnR_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnR_Them.Image = global::QuanLyTaiSanGUI.Properties.Resources.plus_2_24;
            this.btnR_Them.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Them.Location = new System.Drawing.Point(3, 3);
            this.btnR_Them.Name = "btnR_Them";
            this.btnR_Them.Size = new System.Drawing.Size(23, 23);
            this.btnR_Them.TabIndex = 26;
            this.btnR_Them.Click += new System.EventHandler(this.btnR_Them_Click);
            // 
            // btnR_Xoa
            // 
            this.btnR_Xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnR_Xoa.Image = global::QuanLyTaiSanGUI.Properties.Resources.minus_2_24;
            this.btnR_Xoa.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Xoa.Location = new System.Drawing.Point(56, 3);
            this.btnR_Xoa.Name = "btnR_Xoa";
            this.btnR_Xoa.Size = new System.Drawing.Size(23, 23);
            this.btnR_Xoa.TabIndex = 25;
            this.btnR_Xoa.Click += new System.EventHandler(this.btnR_Xoa_Click);
            // 
            // ucThemSuaXoaButton
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnR_Sua);
            this.Controls.Add(this.btnR_Them);
            this.Controls.Add(this.btnR_Xoa);
            this.Name = "ucThemSuaXoaButton";
            this.Size = new System.Drawing.Size(84, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnR_Sua;
        private DevExpress.XtraEditors.SimpleButton btnR_Them;
        private DevExpress.XtraEditors.SimpleButton btnR_Xoa;

    }
}
