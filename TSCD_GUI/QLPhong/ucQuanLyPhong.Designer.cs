namespace TSCD_GUI.QLPhong
{
    partial class ucQuanLyPhong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLyPhong));
            this.rbnControlPhong = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThemPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLoaiPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPagePhong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupPhong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupLoaiPhong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupImport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navBarControlLeft = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupViTri = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainerViTri = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlPhong = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsochongoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvitri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.lblViTri = new DevExpress.XtraEditors.LabelControl();
            this.panelControlViTri = new DevExpress.XtraEditors.PanelControl();
            this.btnLoaiPhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpLoai = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpLoaiView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colten_g = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.txtSoChoNgoi = new DevExpress.XtraEditors.SpinEdit();
            this.dxErrorProviderInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).BeginInit();
            this.navBarControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoaiView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoChoNgoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlPhong
            // 
            this.rbnControlPhong.ExpandCollapseItem.Id = 0;
            this.rbnControlPhong.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlPhong.ExpandCollapseItem,
            this.barBtnThemPhong,
            this.barBtnSuaPhong,
            this.barBtnXoaPhong,
            this.barBtnLoaiPhong,
            this.barBtnImport});
            this.rbnControlPhong.Location = new System.Drawing.Point(0, 0);
            this.rbnControlPhong.MaxItemId = 6;
            this.rbnControlPhong.Name = "rbnControlPhong";
            this.rbnControlPhong.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPagePhong});
            this.rbnControlPhong.Size = new System.Drawing.Size(857, 145);
            // 
            // barBtnThemPhong
            // 
            this.barBtnThemPhong.Caption = "Thêm phòng";
            this.barBtnThemPhong.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemPhong.Id = 1;
            this.barBtnThemPhong.Name = "barBtnThemPhong";
            this.barBtnThemPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemPhong_ItemClick);
            // 
            // barBtnSuaPhong
            // 
            this.barBtnSuaPhong.Caption = "Sửa phòng";
            this.barBtnSuaPhong.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaPhong.Id = 2;
            this.barBtnSuaPhong.Name = "barBtnSuaPhong";
            this.barBtnSuaPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaPhong_ItemClick);
            // 
            // barBtnXoaPhong
            // 
            this.barBtnXoaPhong.Caption = "Xóa phòng";
            this.barBtnXoaPhong.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaPhong.Id = 3;
            this.barBtnXoaPhong.Name = "barBtnXoaPhong";
            this.barBtnXoaPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaPhong_ItemClick);
            // 
            // barBtnLoaiPhong
            // 
            this.barBtnLoaiPhong.Caption = "Loại phòng";
            this.barBtnLoaiPhong.Id = 4;
            this.barBtnLoaiPhong.LargeGlyph = global::TSCD_GUI.Properties.Resources.New_room_icon;
            this.barBtnLoaiPhong.Name = "barBtnLoaiPhong";
            this.barBtnLoaiPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLoaiPhong_ItemClick);
            // 
            // barBtnImport
            // 
            this.barBtnImport.Caption = "Import";
            this.barBtnImport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.Glyph")));
            this.barBtnImport.Id = 5;
            this.barBtnImport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.LargeGlyph")));
            this.barBtnImport.Name = "barBtnImport";
            this.barBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnImport_ItemClick);
            // 
            // rbnPagePhong
            // 
            this.rbnPagePhong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupPhong,
            this.rbnGroupLoaiPhong,
            this.rbnGroupImport});
            this.rbnPagePhong.Image = global::TSCD_GUI.Properties.Resources.phong;
            this.rbnPagePhong.Name = "rbnPagePhong";
            this.rbnPagePhong.Text = "Phòng";
            // 
            // rbnGroupPhong
            // 
            this.rbnGroupPhong.ItemLinks.Add(this.barBtnThemPhong);
            this.rbnGroupPhong.ItemLinks.Add(this.barBtnSuaPhong);
            this.rbnGroupPhong.ItemLinks.Add(this.barBtnXoaPhong);
            this.rbnGroupPhong.Name = "rbnGroupPhong";
            this.rbnGroupPhong.ShowCaptionButton = false;
            this.rbnGroupPhong.Text = "Phòng";
            // 
            // rbnGroupLoaiPhong
            // 
            this.rbnGroupLoaiPhong.ItemLinks.Add(this.barBtnLoaiPhong);
            this.rbnGroupLoaiPhong.Name = "rbnGroupLoaiPhong";
            this.rbnGroupLoaiPhong.ShowCaptionButton = false;
            this.rbnGroupLoaiPhong.Text = "Loại phòng";
            // 
            // rbnGroupImport
            // 
            this.rbnGroupImport.ItemLinks.Add(this.barBtnImport);
            this.rbnGroupImport.Name = "rbnGroupImport";
            this.rbnGroupImport.ShowCaptionButton = false;
            this.rbnGroupImport.Text = "Import";
            // 
            // navBarControlLeft
            // 
            this.navBarControlLeft.ActiveGroup = this.navBarGroupViTri;
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainerViTri);
            this.navBarControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControlLeft.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupViTri});
            this.navBarControlLeft.Location = new System.Drawing.Point(0, 145);
            this.navBarControlLeft.Name = "navBarControlLeft";
            this.navBarControlLeft.OptionsNavPane.ExpandedWidth = 210;
            this.navBarControlLeft.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControlLeft.Size = new System.Drawing.Size(210, 376);
            this.navBarControlLeft.TabIndex = 1;
            // 
            // navBarGroupViTri
            // 
            this.navBarGroupViTri.Caption = "Vị trí";
            this.navBarGroupViTri.ControlContainer = this.navBarGroupControlContainerViTri;
            this.navBarGroupViTri.Expanded = true;
            this.navBarGroupViTri.GroupClientHeight = 80;
            this.navBarGroupViTri.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupViTri.Name = "navBarGroupViTri";
            // 
            // navBarGroupControlContainerViTri
            // 
            this.navBarGroupControlContainerViTri.Name = "navBarGroupControlContainerViTri";
            this.navBarGroupControlContainerViTri.Size = new System.Drawing.Size(208, 284);
            this.navBarGroupControlContainerViTri.TabIndex = 0;
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(210, 145);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlPhong);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(647, 376);
            this.splitContainerControlMain.SplitterPosition = 305;
            this.splitContainerControlMain.TabIndex = 2;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // gridControlPhong
            // 
            this.gridControlPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPhong.Location = new System.Drawing.Point(0, 0);
            this.gridControlPhong.MainView = this.gridViewPhong;
            this.gridControlPhong.MenuManager = this.rbnControlPhong;
            this.gridControlPhong.Name = "gridControlPhong";
            this.gridControlPhong.Size = new System.Drawing.Size(338, 376);
            this.gridControlPhong.TabIndex = 0;
            this.gridControlPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhong});
            // 
            // gridViewPhong
            // 
            this.gridViewPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colten,
            this.colloai,
            this.colsochongoi,
            this.colvitri,
            this.colid,
            this.colphong});
            this.gridViewPhong.GridControl = this.gridControlPhong;
            this.gridViewPhong.Name = "gridViewPhong";
            this.gridViewPhong.OptionsBehavior.Editable = false;
            this.gridViewPhong.OptionsBehavior.ReadOnly = true;
            this.gridViewPhong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPhong.OptionsView.ShowAutoFilterRow = true;
            this.gridViewPhong.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewPhong.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPhong_FocusedRowChanged);
            this.gridViewPhong.DataSourceChanged += new System.EventHandler(this.gridViewPhong_DataSourceChanged);
            // 
            // colten
            // 
            this.colten.Caption = "Tên phòng";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "Loại phòng";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            this.colloai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colloai.Visible = true;
            this.colloai.VisibleIndex = 1;
            // 
            // colsochongoi
            // 
            this.colsochongoi.Caption = "Số chỗ ngồi";
            this.colsochongoi.FieldName = "sochongoi";
            this.colsochongoi.Name = "colsochongoi";
            this.colsochongoi.Visible = true;
            this.colsochongoi.VisibleIndex = 2;
            // 
            // colvitri
            // 
            this.colvitri.Caption = "Vị Trí";
            this.colvitri.FieldName = "vitri";
            this.colvitri.Name = "colvitri";
            this.colvitri.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colvitri.Visible = true;
            this.colvitri.VisibleIndex = 3;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colphong
            // 
            this.colphong.Caption = "phong";
            this.colphong.FieldName = "phong";
            this.colphong.Name = "colphong";
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.lblViTri);
            this.groupControlInfo.Controls.Add(this.panelControlViTri);
            this.groupControlInfo.Controls.Add(this.btnLoaiPhong);
            this.groupControlInfo.Controls.Add(this.btnHuy);
            this.groupControlInfo.Controls.Add(this.btnOK);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.lblLoaiPhong);
            this.groupControlInfo.Controls.Add(this.lblTen);
            this.groupControlInfo.Controls.Add(this.gridLookUpLoai);
            this.groupControlInfo.Controls.Add(this.txtTen);
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.txtMoTa);
            this.groupControlInfo.Controls.Add(this.txtSoChoNgoi);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(305, 376);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // lblViTri
            // 
            this.lblViTri.Location = new System.Drawing.Point(5, 85);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(25, 13);
            this.lblViTri.TabIndex = 16;
            this.lblViTri.Text = "Vị trí:";
            // 
            // panelControlViTri
            // 
            this.panelControlViTri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlViTri.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlViTri.Location = new System.Drawing.Point(68, 83);
            this.panelControlViTri.Name = "panelControlViTri";
            this.panelControlViTri.Size = new System.Drawing.Size(221, 20);
            this.panelControlViTri.TabIndex = 15;
            // 
            // btnLoaiPhong
            // 
            this.btnLoaiPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoaiPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnLoaiPhong.Image")));
            this.btnLoaiPhong.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLoaiPhong.Location = new System.Drawing.Point(266, 54);
            this.btnLoaiPhong.Name = "btnLoaiPhong";
            this.btnLoaiPhong.Size = new System.Drawing.Size(23, 23);
            this.btnLoaiPhong.TabIndex = 14;
            this.btnLoaiPhong.Click += new System.EventHandler(this.btnLoaiPhong_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(148, 234);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(67, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(5, 143);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 11;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.Location = new System.Drawing.Point(5, 59);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(56, 13);
            this.lblLoaiPhong.TabIndex = 10;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(5, 32);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(55, 13);
            this.lblTen.TabIndex = 9;
            this.lblTen.Text = "Tên phòng:";
            // 
            // gridLookUpLoai
            // 
            this.gridLookUpLoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpLoai.Location = new System.Drawing.Point(68, 56);
            this.gridLookUpLoai.MenuManager = this.rbnControlPhong;
            this.gridLookUpLoai.Name = "gridLookUpLoai";
            this.gridLookUpLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpLoai.Properties.DisplayMember = "ten";
            this.gridLookUpLoai.Properties.NullText = "[Chưa chọn loại phòng]";
            this.gridLookUpLoai.Properties.ValueMember = "id";
            this.gridLookUpLoai.Properties.View = this.gridLookUpLoaiView;
            this.gridLookUpLoai.Size = new System.Drawing.Size(192, 20);
            this.gridLookUpLoai.TabIndex = 8;
            // 
            // gridLookUpLoaiView
            // 
            this.gridLookUpLoaiView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colten_g});
            this.gridLookUpLoaiView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpLoaiView.Name = "gridLookUpLoaiView";
            this.gridLookUpLoaiView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpLoaiView.OptionsView.ShowGroupPanel = false;
            // 
            // colten_g
            // 
            this.colten_g.Caption = "Loại phòng";
            this.colten_g.FieldName = "ten";
            this.colten_g.Name = "colten_g";
            this.colten_g.Visible = true;
            this.colten_g.VisibleIndex = 0;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(68, 29);
            this.txtTen.MenuManager = this.rbnControlPhong;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(221, 20);
            this.txtTen.TabIndex = 6;
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(266, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 5;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_22;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(240, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 4;
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_22;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(214, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 3;
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(68, 140);
            this.txtMoTa.MenuManager = this.rbnControlPhong;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(221, 88);
            this.txtMoTa.TabIndex = 7;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // txtSoChoNgoi
            // 
            this.txtSoChoNgoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoChoNgoi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSoChoNgoi.Location = new System.Drawing.Point(68, 110);
            this.txtSoChoNgoi.MenuManager = this.rbnControlPhong;
            this.txtSoChoNgoi.Name = "txtSoChoNgoi";
            this.txtSoChoNgoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoChoNgoi.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSoChoNgoi.Properties.Mask.EditMask = "N00";
            this.txtSoChoNgoi.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSoChoNgoi.Size = new System.Drawing.Size(221, 20);
            this.txtSoChoNgoi.TabIndex = 17;
            // 
            // dxErrorProviderInfo
            // 
            this.dxErrorProviderInfo.ContainerControl = this;
            // 
            // ucQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.navBarControlLeft);
            this.Controls.Add(this.rbnControlPhong);
            this.Name = "ucQuanLyPhong";
            this.Size = new System.Drawing.Size(857, 521);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).EndInit();
            this.navBarControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoaiView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoChoNgoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbnControlPhong;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPagePhong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupPhong;
        private DevExpress.XtraNavBar.NavBarControl navBarControlLeft;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupViTri;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPhong;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraBars.BarButtonItem barBtnThemPhong;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaPhong;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaPhong;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainerViTri;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpLoai;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpLoaiView;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblLoaiPhong;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraBars.BarButtonItem barBtnLoaiPhong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLoaiPhong;
        private DevExpress.XtraEditors.SimpleButton btnLoaiPhong;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraGrid.Columns.GridColumn colvitri;
        private DevExpress.XtraGrid.Columns.GridColumn colloai;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colphong;
        private DevExpress.XtraGrid.Columns.GridColumn colten_g;
        private DevExpress.XtraEditors.PanelControl panelControlViTri;
        private DevExpress.XtraEditors.LabelControl lblViTri;
        private DevExpress.XtraBars.BarButtonItem barBtnImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupImport;
        private DevExpress.XtraEditors.SpinEdit txtSoChoNgoi;
        private DevExpress.XtraGrid.Columns.GridColumn colsochongoi;
    }
}
