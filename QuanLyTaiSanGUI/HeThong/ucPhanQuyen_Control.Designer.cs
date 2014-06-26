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
            this.btnQTV = new DevExpress.XtraEditors.SimpleButton();
            this.btnGroup = new DevExpress.XtraEditors.SimpleButton();
            this.panelPhanQuyen_Control = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelPhanQuyen_Control)).BeginInit();
            this.panelPhanQuyen_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQTV
            // 
            this.btnQTV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQTV.Location = new System.Drawing.Point(0, 23);
            this.btnQTV.Name = "btnQTV";
            this.btnQTV.Size = new System.Drawing.Size(255, 23);
            this.btnQTV.TabIndex = 0;
            this.btnQTV.Text = "Quản trị viên";
            this.btnQTV.Click += new System.EventHandler(this.btnQTV_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGroup.Location = new System.Drawing.Point(0, 0);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(255, 23);
            this.btnGroup.TabIndex = 1;
            this.btnGroup.Text = "Group";
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // panelPhanQuyen_Control
            // 
            this.panelPhanQuyen_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelPhanQuyen_Control.Controls.Add(this.btnQTV);
            this.panelPhanQuyen_Control.Controls.Add(this.btnGroup);
            this.panelPhanQuyen_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPhanQuyen_Control.Location = new System.Drawing.Point(0, 0);
            this.panelPhanQuyen_Control.Name = "panelPhanQuyen_Control";
            this.panelPhanQuyen_Control.Size = new System.Drawing.Size(255, 440);
            this.panelPhanQuyen_Control.TabIndex = 2;
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

        private DevExpress.XtraEditors.SimpleButton btnQTV;
        private DevExpress.XtraEditors.SimpleButton btnGroup;
        private DevExpress.XtraEditors.PanelControl panelPhanQuyen_Control;
    }
}
