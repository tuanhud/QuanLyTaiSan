namespace QuanLyTaiSanGUI.HeThong
{
    partial class ucDisplaySetting
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
            this.groupControl_giaoDien = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_skinCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_giaoDien)).BeginInit();
            this.groupControl_giaoDien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_skinCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl_giaoDien
            // 
            this.groupControl_giaoDien.Controls.Add(this.textEdit_skinCode);
            this.groupControl_giaoDien.Controls.Add(this.labelControl1);
            this.groupControl_giaoDien.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl_giaoDien.Location = new System.Drawing.Point(0, 0);
            this.groupControl_giaoDien.Name = "groupControl_giaoDien";
            this.groupControl_giaoDien.Size = new System.Drawing.Size(594, 76);
            this.groupControl_giaoDien.TabIndex = 4;
            this.groupControl_giaoDien.Text = "Giao diện Skin";
            // 
            // textEdit_skinCode
            // 
            this.textEdit_skinCode.Location = new System.Drawing.Point(69, 32);
            this.textEdit_skinCode.Name = "textEdit_skinCode";
            this.textEdit_skinCode.Size = new System.Drawing.Size(488, 20);
            this.textEdit_skinCode.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "CODE";
            // 
            // ucDisplaySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl_giaoDien);
            this.Name = "ucDisplaySetting";
            this.Size = new System.Drawing.Size(594, 325);
            this.Load += new System.EventHandler(this.ucDisplaySetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_giaoDien)).EndInit();
            this.groupControl_giaoDien.ResumeLayout(false);
            this.groupControl_giaoDien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_skinCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl_giaoDien;
        private DevExpress.XtraEditors.TextEdit textEdit_skinCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
