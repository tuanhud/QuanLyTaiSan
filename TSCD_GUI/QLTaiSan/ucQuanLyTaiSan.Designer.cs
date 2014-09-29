namespace TSCD_GUI.QLTaiSan
{
    partial class ucQuanLyTaiSan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLyTaiSan));
            this.rbnControlTaiSan = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThemTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTinhTrang = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXuatBaoCao = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnThietKe = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDefault = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupTinhTrang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupImport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupLayout = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.ucGridControlTaiSan1 = new TSCD_GUI.MyUserControl.ucGridControlTaiSan();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlTimKiem = new DevExpress.XtraEditors.PanelControl();
            this.checkTen = new DevExpress.XtraEditors.CheckEdit();
            this.checkLoai = new DevExpress.XtraEditors.CheckEdit();
            this.checkDVSD = new DevExpress.XtraEditors.CheckEdit();
            this.checkDVQL = new DevExpress.XtraEditors.CheckEdit();
            this.ucComboBoxDonVi2 = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            this.ucComboBoxDonVi1 = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            this.ucComboBoxLoaiTS1 = new TSCD_GUI.MyUserControl.ucComboBoxLoaiTS();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTimKiem)).BeginInit();
            this.panelControlTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDVSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDVQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlTaiSan
            // 
            this.rbnControlTaiSan.ExpandCollapseItem.Id = 0;
            this.rbnControlTaiSan.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlTaiSan.ExpandCollapseItem,
            this.barBtnThemTaiSan,
            this.barBtnSuaTaiSan,
            this.barBtnXoaTaiSan,
            this.barBtnTinhTrang,
            this.barBtnImport,
            this.barBtnXuatBaoCao,
            this.barBtnThietKe,
            this.barBtnDefault});
            this.rbnControlTaiSan.Location = new System.Drawing.Point(0, 0);
            this.rbnControlTaiSan.MaxItemId = 10;
            this.rbnControlTaiSan.Name = "rbnControlTaiSan";
            this.rbnControlTaiSan.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageTaiSan});
            this.rbnControlTaiSan.Size = new System.Drawing.Size(858, 142);
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
            // 
            // barBtnTinhTrang
            // 
            this.barBtnTinhTrang.Caption = "Tình trạng";
            this.barBtnTinhTrang.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTinhTrang.Glyph")));
            this.barBtnTinhTrang.Id = 5;
            this.barBtnTinhTrang.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnTinhTrang.LargeGlyph")));
            this.barBtnTinhTrang.Name = "barBtnTinhTrang";
            this.barBtnTinhTrang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTinhTrang_ItemClick);
            // 
            // barBtnImport
            // 
            this.barBtnImport.Caption = "Import";
            this.barBtnImport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.Glyph")));
            this.barBtnImport.Id = 6;
            this.barBtnImport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.LargeGlyph")));
            this.barBtnImport.Name = "barBtnImport";
            this.barBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnImport_ItemClick);
            // 
            // barBtnXuatBaoCao
            // 
            this.barBtnXuatBaoCao.Caption = "Xuất báo cáo";
            this.barBtnXuatBaoCao.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnXuatBaoCao.Glyph")));
            this.barBtnXuatBaoCao.Id = 7;
            this.barBtnXuatBaoCao.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnXuatBaoCao.LargeGlyph")));
            this.barBtnXuatBaoCao.Name = "barBtnXuatBaoCao";
            this.barBtnXuatBaoCao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXuatBaoCao_ItemClick);
            // 
            // barBtnThietKe
            // 
            this.barBtnThietKe.Caption = "Thiết kế";
            this.barBtnThietKe.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnThietKe.Glyph")));
            this.barBtnThietKe.Id = 8;
            this.barBtnThietKe.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnThietKe.LargeGlyph")));
            this.barBtnThietKe.Name = "barBtnThietKe";
            this.barBtnThietKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThietKe_ItemClick);
            // 
            // barBtnDefault
            // 
            this.barBtnDefault.Caption = "Default";
            this.barBtnDefault.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.Glyph")));
            this.barBtnDefault.Id = 9;
            this.barBtnDefault.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnDefault.LargeGlyph")));
            this.barBtnDefault.Name = "barBtnDefault";
            this.barBtnDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDefault_ItemClick);
            // 
            // rbnPageTaiSan
            // 
            this.rbnPageTaiSan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupTaiSan,
            this.rbnGroupTinhTrang,
            this.rbnGroupImport,
            this.rbnGroupBaoCao,
            this.rbnGroupLayout});
            this.rbnPageTaiSan.Name = "rbnPageTaiSan";
            this.rbnPageTaiSan.Text = "Tài sản";
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
            // rbnGroupTinhTrang
            // 
            this.rbnGroupTinhTrang.ItemLinks.Add(this.barBtnTinhTrang);
            this.rbnGroupTinhTrang.Name = "rbnGroupTinhTrang";
            this.rbnGroupTinhTrang.ShowCaptionButton = false;
            this.rbnGroupTinhTrang.Text = "Tình trạng";
            // 
            // rbnGroupImport
            // 
            this.rbnGroupImport.ItemLinks.Add(this.barBtnImport);
            this.rbnGroupImport.Name = "rbnGroupImport";
            this.rbnGroupImport.ShowCaptionButton = false;
            this.rbnGroupImport.Text = "Import";
            // 
            // rbnGroupBaoCao
            // 
            this.rbnGroupBaoCao.ItemLinks.Add(this.barBtnXuatBaoCao);
            this.rbnGroupBaoCao.ItemLinks.Add(this.barBtnThietKe);
            this.rbnGroupBaoCao.Name = "rbnGroupBaoCao";
            this.rbnGroupBaoCao.ShowCaptionButton = false;
            this.rbnGroupBaoCao.Text = "Báo cáo";
            // 
            // rbnGroupLayout
            // 
            this.rbnGroupLayout.ItemLinks.Add(this.barBtnDefault);
            this.rbnGroupLayout.Name = "rbnGroupLayout";
            this.rbnGroupLayout.ShowCaptionButton = false;
            this.rbnGroupLayout.Text = "Layout";
            // 
            // groupControlMain
            // 
            this.groupControlMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlMain.AppearanceCaption.Options.UseFont = true;
            this.groupControlMain.Controls.Add(this.ucGridControlTaiSan1);
            this.groupControlMain.Controls.Add(this.btnXoa_r);
            this.groupControlMain.Controls.Add(this.btnSua_r);
            this.groupControlMain.Controls.Add(this.btnThem_r);
            this.groupControlMain.Controls.Add(this.panelControlTimKiem);
            this.groupControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlMain.Location = new System.Drawing.Point(0, 142);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(858, 367);
            this.groupControlMain.TabIndex = 3;
            this.groupControlMain.Text = "Tài sản";
            // 
            // ucGridControlTaiSan1
            // 
            this.ucGridControlTaiSan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridControlTaiSan1.Location = new System.Drawing.Point(2, 84);
            this.ucGridControlTaiSan1.Name = "ucGridControlTaiSan1";
            this.ucGridControlTaiSan1.Size = new System.Drawing.Size(854, 281);
            this.ucGridControlTaiSan1.TabIndex = 8;
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(821, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 7;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_22;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(795, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 6;
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_22;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(769, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 5;
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // panelControlTimKiem
            // 
            this.panelControlTimKiem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlTimKiem.Controls.Add(this.checkTen);
            this.panelControlTimKiem.Controls.Add(this.checkLoai);
            this.panelControlTimKiem.Controls.Add(this.checkDVSD);
            this.panelControlTimKiem.Controls.Add(this.checkDVQL);
            this.panelControlTimKiem.Controls.Add(this.ucComboBoxDonVi2);
            this.panelControlTimKiem.Controls.Add(this.btnTim);
            this.panelControlTimKiem.Controls.Add(this.ucComboBoxDonVi1);
            this.panelControlTimKiem.Controls.Add(this.ucComboBoxLoaiTS1);
            this.panelControlTimKiem.Controls.Add(this.txtTen);
            this.panelControlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlTimKiem.Location = new System.Drawing.Point(2, 24);
            this.panelControlTimKiem.Name = "panelControlTimKiem";
            this.panelControlTimKiem.Size = new System.Drawing.Size(854, 60);
            this.panelControlTimKiem.TabIndex = 2;
            // 
            // checkTen
            // 
            this.checkTen.Location = new System.Drawing.Point(7, 7);
            this.checkTen.MenuManager = this.rbnControlTaiSan;
            this.checkTen.Name = "checkTen";
            this.checkTen.Properties.Caption = "Tên TSCĐ:";
            this.checkTen.Size = new System.Drawing.Size(81, 19);
            this.checkTen.TabIndex = 61;
            // 
            // checkLoai
            // 
            this.checkLoai.Location = new System.Drawing.Point(7, 34);
            this.checkLoai.MenuManager = this.rbnControlTaiSan;
            this.checkLoai.Name = "checkLoai";
            this.checkLoai.Properties.Caption = "Loại tài sản:";
            this.checkLoai.Size = new System.Drawing.Size(80, 19);
            this.checkLoai.TabIndex = 60;
            // 
            // checkDVSD
            // 
            this.checkDVSD.Location = new System.Drawing.Point(335, 32);
            this.checkDVSD.MenuManager = this.rbnControlTaiSan;
            this.checkDVSD.Name = "checkDVSD";
            this.checkDVSD.Properties.Caption = "Đơn vị sử dụng:";
            this.checkDVSD.Size = new System.Drawing.Size(98, 19);
            this.checkDVSD.TabIndex = 59;
            // 
            // checkDVQL
            // 
            this.checkDVQL.Location = new System.Drawing.Point(335, 7);
            this.checkDVQL.MenuManager = this.rbnControlTaiSan;
            this.checkDVQL.Name = "checkDVQL";
            this.checkDVQL.Properties.Caption = "Đơn vị quản lý:";
            this.checkDVQL.Size = new System.Drawing.Size(98, 19);
            this.checkDVQL.TabIndex = 58;
            // 
            // ucComboBoxDonVi2
            // 
            this.ucComboBoxDonVi2.DonVi = null;
            this.ucComboBoxDonVi2.Location = new System.Drawing.Point(439, 33);
            this.ucComboBoxDonVi2.Name = "ucComboBoxDonVi2";
            this.ucComboBoxDonVi2.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxDonVi2.TabIndex = 53;
            // 
            // btnTim
            // 
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(692, 16);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 52;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // ucComboBoxDonVi1
            // 
            this.ucComboBoxDonVi1.DonVi = null;
            this.ucComboBoxDonVi1.Location = new System.Drawing.Point(439, 7);
            this.ucComboBoxDonVi1.Name = "ucComboBoxDonVi1";
            this.ucComboBoxDonVi1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxDonVi1.TabIndex = 51;
            // 
            // ucComboBoxLoaiTS1
            // 
            this.ucComboBoxLoaiTS1.LoaiTS = null;
            this.ucComboBoxLoaiTS1.Location = new System.Drawing.Point(93, 33);
            this.ucComboBoxLoaiTS1.Name = "ucComboBoxLoaiTS1";
            this.ucComboBoxLoaiTS1.Size = new System.Drawing.Size(200, 20);
            this.ucComboBoxLoaiTS1.TabIndex = 50;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(93, 6);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(200, 20);
            this.txtTen.TabIndex = 49;
            // 
            // ucQuanLyTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlMain);
            this.Controls.Add(this.rbnControlTaiSan);
            this.Name = "ucQuanLyTaiSan";
            this.Size = new System.Drawing.Size(858, 509);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTimKiem)).EndInit();
            this.panelControlTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDVSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDVQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlTaiSan;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageTaiSan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnThemTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaTaiSan;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaTaiSan;
        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.PanelControl panelControlTimKiem;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi2;
        private DevExpress.XtraEditors.SimpleButton btnTim;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi1;
        private MyUserControl.ucComboBoxLoaiTS ucComboBoxLoaiTS1;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.CheckEdit checkTen;
        private DevExpress.XtraEditors.CheckEdit checkLoai;
        private DevExpress.XtraEditors.CheckEdit checkDVSD;
        private DevExpress.XtraEditors.CheckEdit checkDVQL;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraBars.BarButtonItem barBtnTinhTrang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupTinhTrang;
        private DevExpress.XtraBars.BarButtonItem barBtnImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupImport;
        private MyUserControl.ucGridControlTaiSan ucGridControlTaiSan1;
        private DevExpress.XtraBars.BarButtonItem barBtnXuatBaoCao;
        private DevExpress.XtraBars.BarButtonItem barBtnThietKe;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupBaoCao;
        private DevExpress.XtraBars.BarButtonItem barBtnDefault;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLayout;
    }
}
