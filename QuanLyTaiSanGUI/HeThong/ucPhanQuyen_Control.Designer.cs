namespace QuanLyTaiSanGUI.HeThong
{
    partial class ucPhanQuyen_Control
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
            this.panelPhanQuyen_Control = new DevExpress.XtraEditors.PanelControl();
            this.checkBtnGroup = new DevExpress.XtraEditors.CheckButton();
            this.checkBtnQTV = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelPhanQuyen_Control)).BeginInit();
            this.panelPhanQuyen_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPhanQuyen_Control
            // 
            this.panelPhanQuyen_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelPhanQuyen_Control.Controls.Add(this.checkBtnGroup);
            this.panelPhanQuyen_Control.Controls.Add(this.checkBtnQTV);
            this.panelPhanQuyen_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPhanQuyen_Control.Location = new System.Drawing.Point(0, 0);
            this.panelPhanQuyen_Control.Name = "panelPhanQuyen_Control";
            this.panelPhanQuyen_Control.Size = new System.Drawing.Size(255, 440);
            this.panelPhanQuyen_Control.TabIndex = 2;
            // 
            // checkBtnGroup
            // 
            this.checkBtnGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBtnGroup.Location = new System.Drawing.Point(0, 23);
            this.checkBtnGroup.Name = "checkBtnGroup";
            this.checkBtnGroup.Size = new System.Drawing.Size(255, 23);
            this.checkBtnGroup.TabIndex = 2;
            this.checkBtnGroup.Text = "Nhóm quyền";
            this.checkBtnGroup.CheckedChanged += new System.EventHandler(this.checkBtnGroup_CheckedChanged);
            // 
            // checkBtnQTV
            // 
            this.checkBtnQTV.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBtnQTV.Location = new System.Drawing.Point(0, 0);
            this.checkBtnQTV.Name = "checkBtnQTV";
            this.checkBtnQTV.Size = new System.Drawing.Size(255, 23);
            this.checkBtnQTV.TabIndex = 3;
            this.checkBtnQTV.Text = "Quản trị viên";
            this.checkBtnQTV.CheckedChanged += new System.EventHandler(this.checkBtnQTV_CheckedChanged);
            // 
            // ucPhanQuyen_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPhanQuyen_Control);
            this.Name = "ucPhanQuyen_Control";
            this.Size = new System.Drawing.Size(255, 440);
            ((System.ComponentModel.ISupportInitialize)(this.panelPhanQuyen_Control)).EndInit();
            this.panelPhanQuyen_Control.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelPhanQuyen_Control;
        private DevExpress.XtraEditors.CheckButton checkBtnQTV;
        private DevExpress.XtraEditors.CheckButton checkBtnGroup;
    }
}
