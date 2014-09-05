namespace TSCD_GUI.QLTaiSan
{
    partial class ucQuanLyDonVi_TaiSan
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
            this.rbnControlDonVi_TaiSan = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThemTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageDonVi_TaiSan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navBarControlLeft = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupDonVi = new DevExpress.XtraNavBar.NavBarGroup();
            this.gridControlDonVi_TaiSan = new DevExpress.XtraGrid.GridControl();
            this.gridViewDonVi_TaiSan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.navBarGroupControlContainerDonVi = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeListDonVi = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlDonVi_TaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).BeginInit();
            this.navBarControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDonVi_TaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDonVi_TaiSan)).BeginInit();
            this.navBarGroupControlContainerDonVi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlDonVi_TaiSan
            // 
            this.rbnControlDonVi_TaiSan.ExpandCollapseItem.Id = 0;
            this.rbnControlDonVi_TaiSan.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlDonVi_TaiSan.ExpandCollapseItem,
            this.barBtnThemTaiSan,
            this.barBtnSuaTaiSan,
            this.barBtnXoaTaiSan});
            this.rbnControlDonVi_TaiSan.Location = new System.Drawing.Point(0, 0);
            this.rbnControlDonVi_TaiSan.MaxItemId = 4;
            this.rbnControlDonVi_TaiSan.Name = "rbnControlDonVi_TaiSan";
            this.rbnControlDonVi_TaiSan.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageDonVi_TaiSan});
            this.rbnControlDonVi_TaiSan.Size = new System.Drawing.Size(861, 142);
            // 
            // barBtnThemTaiSan
            // 
            this.barBtnThemTaiSan.Caption = "Thêm tài sản";
            this.barBtnThemTaiSan.Id = 1;
            this.barBtnThemTaiSan.Name = "barBtnThemTaiSan";
            // 
            // barBtnSuaTaiSan
            // 
            this.barBtnSuaTaiSan.Caption = "Sủa tài sản";
            this.barBtnSuaTaiSan.Id = 2;
            this.barBtnSuaTaiSan.Name = "barBtnSuaTaiSan";
            // 
            // barBtnXoaTaiSan
            // 
            this.barBtnXoaTaiSan.Caption = "Xóa tài sản";
            this.barBtnXoaTaiSan.Id = 3;
            this.barBtnXoaTaiSan.Name = "barBtnXoaTaiSan";
            // 
            // rbnPageDonVi_TaiSan
            // 
            this.rbnPageDonVi_TaiSan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupTaiSan});
            this.rbnPageDonVi_TaiSan.Name = "rbnPageDonVi_TaiSan";
            this.rbnPageDonVi_TaiSan.Text = "Đơn vị - Tài sản";
            // 
            // rbnGroupTaiSan
            // 
            this.rbnGroupTaiSan.ItemLinks.Add(this.barBtnThemTaiSan);
            this.rbnGroupTaiSan.ItemLinks.Add(this.barBtnSuaTaiSan);
            this.rbnGroupTaiSan.ItemLinks.Add(this.barBtnXoaTaiSan);
            this.rbnGroupTaiSan.Name = "rbnGroupTaiSan";
            this.rbnGroupTaiSan.ShowCaptionButton = false;
            this.rbnGroupTaiSan.Text = "Tài sản";
            // 
            // navBarControlLeft
            // 
            this.navBarControlLeft.ActiveGroup = this.navBarGroupDonVi;
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainerDonVi);
            this.navBarControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControlLeft.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupDonVi});
            this.navBarControlLeft.Location = new System.Drawing.Point(0, 142);
            this.navBarControlLeft.Name = "navBarControlLeft";
            this.navBarControlLeft.OptionsNavPane.ExpandedWidth = 187;
            this.navBarControlLeft.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControlLeft.Size = new System.Drawing.Size(187, 382);
            this.navBarControlLeft.TabIndex = 1;
            this.navBarControlLeft.Text = "navBarControl1";
            // 
            // navBarGroupDonVi
            // 
            this.navBarGroupDonVi.Caption = "Đơn vị";
            this.navBarGroupDonVi.ControlContainer = this.navBarGroupControlContainerDonVi;
            this.navBarGroupDonVi.Expanded = true;
            this.navBarGroupDonVi.GroupClientHeight = 80;
            this.navBarGroupDonVi.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupDonVi.Name = "navBarGroupDonVi";
            // 
            // gridControlDonVi_TaiSan
            // 
            this.gridControlDonVi_TaiSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDonVi_TaiSan.Location = new System.Drawing.Point(187, 142);
            this.gridControlDonVi_TaiSan.MainView = this.gridViewDonVi_TaiSan;
            this.gridControlDonVi_TaiSan.MenuManager = this.rbnControlDonVi_TaiSan;
            this.gridControlDonVi_TaiSan.Name = "gridControlDonVi_TaiSan";
            this.gridControlDonVi_TaiSan.Size = new System.Drawing.Size(674, 382);
            this.gridControlDonVi_TaiSan.TabIndex = 3;
            this.gridControlDonVi_TaiSan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDonVi_TaiSan});
            // 
            // gridViewDonVi_TaiSan
            // 
            this.gridViewDonVi_TaiSan.GridControl = this.gridControlDonVi_TaiSan;
            this.gridViewDonVi_TaiSan.Name = "gridViewDonVi_TaiSan";
            // 
            // navBarGroupControlContainerDonVi
            // 
            this.navBarGroupControlContainerDonVi.Controls.Add(this.treeListDonVi);
            this.navBarGroupControlContainerDonVi.Name = "navBarGroupControlContainerDonVi";
            this.navBarGroupControlContainerDonVi.Size = new System.Drawing.Size(187, 279);
            this.navBarGroupControlContainerDonVi.TabIndex = 0;
            // 
            // treeListDonVi
            // 
            this.treeListDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDonVi.Location = new System.Drawing.Point(0, 0);
            this.treeListDonVi.Name = "treeListDonVi";
            this.treeListDonVi.Size = new System.Drawing.Size(187, 279);
            this.treeListDonVi.TabIndex = 0;
            // 
            // ucQuanLyDonVi_TaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlDonVi_TaiSan);
            this.Controls.Add(this.navBarControlLeft);
            this.Controls.Add(this.rbnControlDonVi_TaiSan);
            this.Name = "ucQuanLyDonVi_TaiSan";
            this.Size = new System.Drawing.Size(861, 524);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlDonVi_TaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).EndInit();
            this.navBarControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDonVi_TaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDonVi_TaiSan)).EndInit();
            this.navBarGroupControlContainerDonVi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlDonVi_TaiSan;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageDonVi_TaiSan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupTaiSan;
        private DevExpress.XtraNavBar.NavBarControl navBarControlLeft;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupDonVi;
        private DevExpress.XtraBars.BarButtonItem barBtnThemTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaTaiSan;
        private DevExpress.XtraGrid.GridControl gridControlDonVi_TaiSan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDonVi_TaiSan;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainerDonVi;
        private DevExpress.XtraTreeList.TreeList treeListDonVi;
    }
}
