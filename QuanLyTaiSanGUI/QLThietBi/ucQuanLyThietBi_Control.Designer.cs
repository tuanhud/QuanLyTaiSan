namespace QuanLyTaiSanGUI.QLThietBi
{
    partial class ucQuanLyThietBi_Control
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLoaiChung = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoaiRieng = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnLoaiRieng);
            this.panelControl1.Controls.Add(this.btnLoaiChung);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(251, 347);
            this.panelControl1.TabIndex = 0;
            // 
            // btnLoaiChung
            // 
            this.btnLoaiChung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoaiChung.Location = new System.Drawing.Point(0, 0);
            this.btnLoaiChung.Name = "btnLoaiChung";
            this.btnLoaiChung.Size = new System.Drawing.Size(251, 23);
            this.btnLoaiChung.TabIndex = 0;
            this.btnLoaiChung.Text = "Thiết bị quản lý theo số lượng";
            this.btnLoaiChung.Click += new System.EventHandler(this.btnLoaiChung_Click);
            // 
            // btnLoaiRieng
            // 
            this.btnLoaiRieng.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoaiRieng.Location = new System.Drawing.Point(0, 23);
            this.btnLoaiRieng.Name = "btnLoaiRieng";
            this.btnLoaiRieng.Size = new System.Drawing.Size(251, 23);
            this.btnLoaiRieng.TabIndex = 1;
            this.btnLoaiRieng.Text = "Thiết bị quản lý riêng lẻ";
            this.btnLoaiRieng.Click += new System.EventHandler(this.btnLoaiRieng_Click);
            // 
            // ucQuanLyThietBi_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ucQuanLyThietBi_Control";
            this.Size = new System.Drawing.Size(251, 347);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLoaiRieng;
        private DevExpress.XtraEditors.SimpleButton btnLoaiChung;
    }
}
