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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLyDonVi_TaiSan));
            this.rbnControlDonVi_TaiSan = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThemTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXuatBaoCao = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLog = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDefault = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnChuyenTinhTrang = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnThietKe = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAttachment = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageDonVi_TaiSan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupChuyen = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupImport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupLayout = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupAttachment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navBarControlLeft = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupDonVi = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainerDonVi = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucTreeDonVi1 = new TSCD_GUI.MyUserControl.ucTreeDonVi();
            this.treeListDonVi = new DevExpress.XtraTreeList.TreeList();
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.ucGridControlTaiSan1 = new TSCD_GUI.MyUserControl.ucGridControlTaiSan();
            this.splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.QLTaiSan.WaitForm_Report), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlDonVi_TaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).BeginInit();
            this.navBarControlLeft.SuspendLayout();
            this.navBarGroupControlContainerDonVi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnControlDonVi_TaiSan
            // 
            this.rbnControlDonVi_TaiSan.ExpandCollapseItem.Id = 0;
            this.rbnControlDonVi_TaiSan.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlDonVi_TaiSan.ExpandCollapseItem,
            this.barBtnThemTaiSan,
            this.barBtnSuaTaiSan,
            this.barBtnXoaTaiSan,
            this.barBtnXuatBaoCao,
            this.barBtnChuyen,
            this.barBtnLog,
            this.barBtnImport,
            this.barBtnDefault,
            this.barBtnChuyenTinhTrang,
            this.barBtnThietKe,
            this.barBtnAttachment});
            this.rbnControlDonVi_TaiSan.Location = new System.Drawing.Point(0, 0);
            this.rbnControlDonVi_TaiSan.MaxItemId = 12;
            this.rbnControlDonVi_TaiSan.Name = "rbnControlDonVi_TaiSan";
            this.rbnControlDonVi_TaiSan.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageDonVi_TaiSan});
            this.rbnControlDonVi_TaiSan.Size = new System.Drawing.Size(861, 145);
            // 
            // barBtnThemTaiSan
            // 
            this.barBtnThemTaiSan.Caption = "Thêm tài sản";
            this.barBtnThemTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemTaiSan.Id = 1;
            this.barBtnThemTaiSan.Name = "barBtnThemTaiSan";
            this.barBtnThemTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemTaiSan_ItemClick);
            // 
            // barBtnSuaTaiSan
            // 
            this.barBtnSuaTaiSan.Caption = "Sửa tài sản";
            this.barBtnSuaTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaTaiSan.Id = 2;
            this.barBtnSuaTaiSan.Name = "barBtnSuaTaiSan";
            this.barBtnSuaTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaTaiSan_ItemClick);
            // 
            // barBtnXoaTaiSan
            // 
            this.barBtnXoaTaiSan.Caption = "Xóa tài sản";
            this.barBtnXoaTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaTaiSan.Id = 3;
            this.barBtnXoaTaiSan.Name = "barBtnXoaTaiSan";
            this.barBtnXoaTaiSan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaTaiSan_ItemClick);
            // 
            // barBtnXuatBaoCao
            // 
            this.barBtnXuatBaoCao.Caption = "Xuất báo cáo";
            this.barBtnXuatBaoCao.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnXuatBaoCao.Glyph")));
            this.barBtnXuatBaoCao.Id = 4;
            this.barBtnXuatBaoCao.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnXuatBaoCao.LargeGlyph")));
            this.barBtnXuatBaoCao.Name = "barBtnXuatBaoCao";
            this.barBtnXuatBaoCao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXuatBaoCao_ItemClick);
            // 
            // barBtnChuyen
            // 
            this.barBtnChuyen.Caption = "Chuyển đơn vị";
            this.barBtnChuyen.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnChuyen.Glyph")));
            this.barBtnChuyen.Id = 5;
            this.barBtnChuyen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnChuyen.LargeGlyph")));
            this.barBtnChuyen.Name = "barBtnChuyen";
            this.barBtnChuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnChuyen_ItemClick);
            // 
            // barBtnLog
            // 
            this.barBtnLog.Caption = "Log";
            this.barBtnLog.Enabled = false;
            this.barBtnLog.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnLog.Glyph")));
            this.barBtnLog.Id = 6;
            this.barBtnLog.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnLog.LargeGlyph")));
            this.barBtnLog.Name = "barBtnLog";
            this.barBtnLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLog_ItemClick);
            // 
            // barBtnImport
            // 
            this.barBtnImport.Caption = "Import";
            this.barBtnImport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.Glyph")));
            this.barBtnImport.Id = 7;
            this.barBtnImport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.LargeGlyph")));
            this.barBtnImport.Name = "barBtnImport";
            this.barBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnImport_ItemClick);
            // 
            // barBtnDefault
            // 
            this.barBtnDefault.Caption = "Mặc định";
            this.barBtnDefault.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.Glyph")));
            this.barBtnDefault.Id = 8;
            this.barBtnDefault.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.LargeGlyph")));
            this.barBtnDefault.Name = "barBtnDefault";
            this.barBtnDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDefault_ItemClick);
            // 
            // barBtnChuyenTinhTrang
            // 
            this.barBtnChuyenTinhTrang.Caption = "Chuyển tình trạng";
            this.barBtnChuyenTinhTrang.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnChuyenTinhTrang.Glyph")));
            this.barBtnChuyenTinhTrang.Id = 9;
            this.barBtnChuyenTinhTrang.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnChuyenTinhTrang.LargeGlyph")));
            this.barBtnChuyenTinhTrang.Name = "barBtnChuyenTinhTrang";
            this.barBtnChuyenTinhTrang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnChuyenTinhTrang_ItemClick);
            // 
            // barBtnThietKe
            // 
            this.barBtnThietKe.Caption = "Thiết kế";
            this.barBtnThietKe.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnThietKe.Glyph")));
            this.barBtnThietKe.Id = 10;
            this.barBtnThietKe.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnThietKe.LargeGlyph")));
            this.barBtnThietKe.Name = "barBtnThietKe";
            this.barBtnThietKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThietKe_ItemClick);
            // 
            // barBtnAttachment
            // 
            this.barBtnAttachment.Caption = "File chứng từ";
            this.barBtnAttachment.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnAttachment.Glyph")));
            this.barBtnAttachment.Id = 11;
            this.barBtnAttachment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnAttachment.LargeGlyph")));
            this.barBtnAttachment.Name = "barBtnAttachment";
            this.barBtnAttachment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAttachment_ItemClick);
            // 
            // rbnPageDonVi_TaiSan
            // 
            this.rbnPageDonVi_TaiSan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupTaiSan,
            this.rbnGroupChuyen,
            this.rbnGroupLog,
            this.rbnGroupBaoCao,
            this.rbnGroupImport,
            this.rbnGroupLayout,
            this.rbnGroupAttachment});
            this.rbnPageDonVi_TaiSan.Image = ((System.Drawing.Image)(resources.GetObject("rbnPageDonVi_TaiSan.Image")));
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
            // rbnGroupChuyen
            // 
            this.rbnGroupChuyen.ItemLinks.Add(this.barBtnChuyen);
            this.rbnGroupChuyen.ItemLinks.Add(this.barBtnChuyenTinhTrang);
            this.rbnGroupChuyen.Name = "rbnGroupChuyen";
            this.rbnGroupChuyen.ShowCaptionButton = false;
            this.rbnGroupChuyen.Text = "Chuyển";
            // 
            // rbnGroupLog
            // 
            this.rbnGroupLog.ItemLinks.Add(this.barBtnLog);
            this.rbnGroupLog.Name = "rbnGroupLog";
            this.rbnGroupLog.ShowCaptionButton = false;
            this.rbnGroupLog.Text = "Log";
            // 
            // rbnGroupBaoCao
            // 
            this.rbnGroupBaoCao.ItemLinks.Add(this.barBtnXuatBaoCao);
            this.rbnGroupBaoCao.ItemLinks.Add(this.barBtnThietKe);
            this.rbnGroupBaoCao.Name = "rbnGroupBaoCao";
            this.rbnGroupBaoCao.ShowCaptionButton = false;
            this.rbnGroupBaoCao.Text = "Báo cáo";
            // 
            // rbnGroupImport
            // 
            this.rbnGroupImport.ItemLinks.Add(this.barBtnImport);
            this.rbnGroupImport.Name = "rbnGroupImport";
            this.rbnGroupImport.ShowCaptionButton = false;
            this.rbnGroupImport.Text = "Import";
            // 
            // rbnGroupLayout
            // 
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnDefault);
            this.rbnGroupLayout.Name = "rbnGroupLayout";
            this.rbnGroupLayout.ShowCaptionButton = false;
            this.rbnGroupLayout.Text = "Layout";
            // 
            // rbnGroupAttachment
            // 
            this.rbnGroupAttachment.ItemLinks.Add(this.barBtnAttachment);
            this.rbnGroupAttachment.Name = "rbnGroupAttachment";
            this.rbnGroupAttachment.ShowCaptionButton = false;
            this.rbnGroupAttachment.Text = "File chứng từ";
            // 
            // navBarControlLeft
            // 
            this.navBarControlLeft.ActiveGroup = this.navBarGroupDonVi;
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainerDonVi);
            this.navBarControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControlLeft.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupDonVi});
            this.navBarControlLeft.Location = new System.Drawing.Point(0, 145);
            this.navBarControlLeft.Name = "navBarControlLeft";
            this.navBarControlLeft.OptionsNavPane.ExpandedWidth = 307;
            this.navBarControlLeft.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControlLeft.Size = new System.Drawing.Size(307, 379);
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
            // navBarGroupControlContainerDonVi
            // 
            this.navBarGroupControlContainerDonVi.Controls.Add(this.ucTreeDonVi1);
            this.navBarGroupControlContainerDonVi.Controls.Add(this.treeListDonVi);
            this.navBarGroupControlContainerDonVi.Name = "navBarGroupControlContainerDonVi";
            this.navBarGroupControlContainerDonVi.Size = new System.Drawing.Size(307, 276);
            this.navBarGroupControlContainerDonVi.TabIndex = 0;
            // 
            // ucTreeDonVi1
            // 
            this.ucTreeDonVi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTreeDonVi1.DonVi = null;
            this.ucTreeDonVi1.Location = new System.Drawing.Point(0, 0);
            this.ucTreeDonVi1.Name = "ucTreeDonVi1";
            this.ucTreeDonVi1.Size = new System.Drawing.Size(307, 276);
            this.ucTreeDonVi1.TabIndex = 1;
            // 
            // treeListDonVi
            // 
            this.treeListDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDonVi.Location = new System.Drawing.Point(0, 0);
            this.treeListDonVi.Name = "treeListDonVi";
            this.treeListDonVi.Size = new System.Drawing.Size(307, 276);
            this.treeListDonVi.TabIndex = 0;
            // 
            // groupControlMain
            // 
            this.groupControlMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlMain.AppearanceCaption.Options.UseFont = true;
            this.groupControlMain.Controls.Add(this.ucGridControlTaiSan1);
            this.groupControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlMain.Location = new System.Drawing.Point(307, 145);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(554, 379);
            this.groupControlMain.TabIndex = 5;
            this.groupControlMain.Text = "Tài sản";
            // 
            // ucGridControlTaiSan1
            // 
            this.ucGridControlTaiSan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridControlTaiSan1.Location = new System.Drawing.Point(2, 24);
            this.ucGridControlTaiSan1.Name = "ucGridControlTaiSan1";
            this.ucGridControlTaiSan1.Size = new System.Drawing.Size(550, 353);
            this.ucGridControlTaiSan1.TabIndex = 0;
            // 
            // ucQuanLyDonVi_TaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlMain);
            this.Controls.Add(this.navBarControlLeft);
            this.Controls.Add(this.rbnControlDonVi_TaiSan);
            this.Name = "ucQuanLyDonVi_TaiSan";
            this.Size = new System.Drawing.Size(861, 524);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlDonVi_TaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).EndInit();
            this.navBarControlLeft.ResumeLayout(false);
            this.navBarGroupControlContainerDonVi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
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
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainerDonVi;
        private DevExpress.XtraTreeList.TreeList treeListDonVi;
        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private MyUserControl.ucTreeDonVi ucTreeDonVi1;
        private DevExpress.XtraBars.BarButtonItem barBtnXuatBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupBaoCao;
        private DevExpress.XtraBars.BarButtonItem barBtnChuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupChuyen;
        private DevExpress.XtraBars.BarButtonItem barBtnLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLog;
        private DevExpress.XtraBars.BarButtonItem barBtnImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupImport;
        private MyUserControl.ucGridControlTaiSan ucGridControlTaiSan1;
        private DevExpress.XtraBars.BarButtonItem barBtnDefault;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLayout;
        private DevExpress.XtraBars.BarButtonItem barBtnChuyenTinhTrang;
        private DevExpress.XtraBars.BarButtonItem barBtnThietKe;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupAttachment;
        private DevExpress.XtraBars.BarButtonItem barBtnAttachment;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report;
    }
}
