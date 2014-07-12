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
            this.checkBtnTheoSL = new DevExpress.XtraEditors.CheckButton();
            this.checkBtnTheoCT = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.checkBtnTheoCT);
            this.panelControl1.Controls.Add(this.checkBtnTheoSL);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(251, 347);
            this.panelControl1.TabIndex = 0;
            // 
            // checkBtnTheoSL
            // 
            this.checkBtnTheoSL.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtnTheoSL.Appearance.Options.UseFont = true;
            this.checkBtnTheoSL.Appearance.Options.UseTextOptions = true;
            this.checkBtnTheoSL.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.checkBtnTheoSL.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBtnTheoSL.Location = new System.Drawing.Point(0, 0);
            this.checkBtnTheoSL.Name = "checkBtnTheoSL";
            this.checkBtnTheoSL.Size = new System.Drawing.Size(251, 23);
            this.checkBtnTheoSL.TabIndex = 2;
            this.checkBtnTheoSL.Text = "Thiết bị quản lý theo số lượng";
            this.checkBtnTheoSL.CheckedChanged += new System.EventHandler(this.checkBtnTheoSL_CheckedChanged);
            // 
            // checkBtnTheoCT
            // 
            this.checkBtnTheoCT.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtnTheoCT.Appearance.Options.UseFont = true;
            this.checkBtnTheoCT.Appearance.Options.UseTextOptions = true;
            this.checkBtnTheoCT.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.checkBtnTheoCT.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBtnTheoCT.Location = new System.Drawing.Point(0, 23);
            this.checkBtnTheoCT.Name = "checkBtnTheoCT";
            this.checkBtnTheoCT.Size = new System.Drawing.Size(251, 23);
            this.checkBtnTheoCT.TabIndex = 3;
            this.checkBtnTheoCT.Text = "Thiết bị quản lý theo cá thể";
            this.checkBtnTheoCT.CheckedChanged += new System.EventHandler(this.checkBtnTheoCT_CheckedChanged);
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
        private DevExpress.XtraEditors.CheckButton checkBtnTheoSL;
        private DevExpress.XtraEditors.CheckButton checkBtnTheoCT;
    }
}
