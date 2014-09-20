namespace QuanLyTaiSanGUI.QLTinhTrang
{
    partial class ucQuanLyTinhTrang_Control
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
            this.panelTinhTrang_Control = new DevExpress.XtraEditors.PanelControl();
            this.checkBtnTinhTrang_P = new DevExpress.XtraEditors.CheckButton();
            this.checkBtnTinhTrang_TB = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTinhTrang_Control)).BeginInit();
            this.panelTinhTrang_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTinhTrang_Control
            // 
            this.panelTinhTrang_Control.Controls.Add(this.checkBtnTinhTrang_P);
            this.panelTinhTrang_Control.Controls.Add(this.checkBtnTinhTrang_TB);
            this.panelTinhTrang_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTinhTrang_Control.Location = new System.Drawing.Point(0, 0);
            this.panelTinhTrang_Control.Name = "panelTinhTrang_Control";
            this.panelTinhTrang_Control.Size = new System.Drawing.Size(268, 331);
            this.panelTinhTrang_Control.TabIndex = 6;
            // 
            // checkBtnTinhTrang_P
            // 
            this.checkBtnTinhTrang_P.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBtnTinhTrang_P.Location = new System.Drawing.Point(2, 25);
            this.checkBtnTinhTrang_P.Name = "checkBtnTinhTrang_P";
            this.checkBtnTinhTrang_P.Size = new System.Drawing.Size(264, 23);
            this.checkBtnTinhTrang_P.TabIndex = 4;
            this.checkBtnTinhTrang_P.Text = "Tình trạng \"sự cố phòng\"";
            this.checkBtnTinhTrang_P.CheckedChanged += new System.EventHandler(this.checkBtnTinhTrang_P_CheckedChanged);
            // 
            // checkBtnTinhTrang_TB
            // 
            this.checkBtnTinhTrang_TB.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBtnTinhTrang_TB.Location = new System.Drawing.Point(2, 2);
            this.checkBtnTinhTrang_TB.Name = "checkBtnTinhTrang_TB";
            this.checkBtnTinhTrang_TB.Size = new System.Drawing.Size(264, 23);
            this.checkBtnTinhTrang_TB.TabIndex = 5;
            this.checkBtnTinhTrang_TB.Text = "Tình trạng \"thiết bị\"";
            this.checkBtnTinhTrang_TB.CheckedChanged += new System.EventHandler(this.checkBtnTinhTrang_TB_CheckedChanged);
            // 
            // ucQuanLyTinhTrang_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTinhTrang_Control);
            this.Name = "ucQuanLyTinhTrang_Control";
            this.Size = new System.Drawing.Size(268, 331);
            ((System.ComponentModel.ISupportInitialize)(this.panelTinhTrang_Control)).EndInit();
            this.panelTinhTrang_Control.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTinhTrang_Control;
        private DevExpress.XtraEditors.CheckButton checkBtnTinhTrang_TB;
        private DevExpress.XtraEditors.CheckButton checkBtnTinhTrang_P;
    }
}
