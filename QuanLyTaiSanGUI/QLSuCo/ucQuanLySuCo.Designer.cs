namespace QuanLyTaiSanGUI.QLSuCo
{
    partial class ucQuanLySuCo
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlSuCo = new DevExpress.XtraGrid.GridControl();
            this.gridViewSuCo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSuCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSuCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(813, 142);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 142);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlSuCo);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(813, 420);
            this.splitContainerControl1.SplitterPosition = 291;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlSuCo
            // 
            this.gridControlSuCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSuCo.Location = new System.Drawing.Point(0, 0);
            this.gridControlSuCo.MainView = this.gridViewSuCo;
            this.gridControlSuCo.MenuManager = this.ribbonControl1;
            this.gridControlSuCo.Name = "gridControlSuCo";
            this.gridControlSuCo.Size = new System.Drawing.Size(517, 420);
            this.gridControlSuCo.TabIndex = 0;
            this.gridControlSuCo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSuCo});
            // 
            // gridViewSuCo
            // 
            this.gridViewSuCo.GridControl = this.gridControlSuCo;
            this.gridViewSuCo.Name = "gridViewSuCo";
            this.gridViewSuCo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewSuCo_FocusedRowChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(291, 420);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // ucQuanLySuCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ucQuanLySuCo";
            this.Size = new System.Drawing.Size(813, 562);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSuCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSuCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlSuCo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSuCo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
