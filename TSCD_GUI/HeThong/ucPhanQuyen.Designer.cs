namespace TSCD_GUI.HeThong
{
    partial class ucPhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhanQuyen));
            this.rbnGroupQTV = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnThemQTV = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaQTV = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaQTV = new DevExpress.XtraBars.BarButtonItem();
            this.dateCreated = new DevExpress.XtraEditors.DateEdit();
            this.lblXNMatKhau = new DevExpress.XtraEditors.LabelControl();
            this.txtXacNhanMK = new DevExpress.XtraEditors.TextEdit();
            this.lblNhom = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_group = new DevExpress.XtraEditors.LookUpEdit();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblNgayTao = new DevExpress.XtraEditors.LabelControl();
            this.lblMatKhau = new DevExpress.XtraEditors.LabelControl();
            this.lblTaiKhoan = new DevExpress.XtraEditors.LabelControl();
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.lblMa = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhauQuanTriVien = new DevExpress.XtraEditors.TextEdit();
            this.txtTaiKhoanQuanTriVien = new DevExpress.XtraEditors.TextEdit();
            this.txtTenQuanTriVien = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProviderInfo = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.rbnPagePhanQuyen = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupNhomQuyen = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnNhomQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemDongTab = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlQTV = new DevExpress.XtraGrid.GridControl();
            this.gridViewQTV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhoten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten_group = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_create = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_modified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnNhomQuyen = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit_mota = new DevExpress.XtraEditors.MemoEdit();
            this.rbnPhanQuyen = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaQuanTriVien = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreated.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXacNhanMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_group.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauQuanTriVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoanQuanTriVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQuanTriVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_mota.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnPhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQuanTriVien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnGroupQTV
            // 
            this.rbnGroupQTV.ItemLinks.Add(this.barBtnThemQTV);
            this.rbnGroupQTV.ItemLinks.Add(this.barBtnSuaQTV);
            this.rbnGroupQTV.ItemLinks.Add(this.barBtnXoaQTV);
            this.rbnGroupQTV.Name = "rbnGroupQTV";
            this.rbnGroupQTV.ShowCaptionButton = false;
            this.rbnGroupQTV.Text = "Quản trị viên";
            // 
            // barBtnThemQTV
            // 
            this.barBtnThemQTV.Caption = "Thêm quản trị viên";
            this.barBtnThemQTV.Glyph = global::TSCD_GUI.Properties.Resources.plus_32;
            this.barBtnThemQTV.Id = 1;
            this.barBtnThemQTV.Name = "barBtnThemQTV";
            this.barBtnThemQTV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemQTV_ItemClick);
            // 
            // barBtnSuaQTV
            // 
            this.barBtnSuaQTV.Caption = "Sửa quản trị viên";
            this.barBtnSuaQTV.Glyph = global::TSCD_GUI.Properties.Resources.pencil_32;
            this.barBtnSuaQTV.Id = 2;
            this.barBtnSuaQTV.Name = "barBtnSuaQTV";
            this.barBtnSuaQTV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaQTV_ItemClick);
            // 
            // barBtnXoaQTV
            // 
            this.barBtnXoaQTV.Caption = "Xóa quản trị viên";
            this.barBtnXoaQTV.Glyph = global::TSCD_GUI.Properties.Resources.delete_32;
            this.barBtnXoaQTV.Id = 3;
            this.barBtnXoaQTV.Name = "barBtnXoaQTV";
            this.barBtnXoaQTV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaQTV_ItemClick);
            // 
            // dateCreated
            // 
            this.dateCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateCreated.EditValue = null;
            this.dateCreated.Location = new System.Drawing.Point(93, 157);
            this.dateCreated.Name = "dateCreated";
            this.dateCreated.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCreated.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCreated.Properties.ReadOnly = true;
            this.dateCreated.Size = new System.Drawing.Size(241, 20);
            this.dateCreated.TabIndex = 9;
            // 
            // lblXNMatKhau
            // 
            this.lblXNMatKhau.Location = new System.Drawing.Point(7, 136);
            this.lblXNMatKhau.Name = "lblXNMatKhau";
            this.lblXNMatKhau.Size = new System.Drawing.Size(65, 13);
            this.lblXNMatKhau.TabIndex = 15;
            this.lblXNMatKhau.Text = "Xác nhận MK:";
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXacNhanMK.Location = new System.Drawing.Point(93, 131);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.Properties.PasswordChar = '●';
            this.txtXacNhanMK.Properties.ReadOnly = true;
            this.txtXacNhanMK.Size = new System.Drawing.Size(241, 20);
            this.txtXacNhanMK.TabIndex = 8;
            // 
            // lblNhom
            // 
            this.lblNhom.Location = new System.Drawing.Point(8, 187);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(31, 13);
            this.lblNhom.TabIndex = 13;
            this.lblNhom.Text = "Nhóm:";
            // 
            // lookUpEdit_group
            // 
            this.lookUpEdit_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEdit_group.Location = new System.Drawing.Point(93, 183);
            this.lookUpEdit_group.Name = "lookUpEdit_group";
            this.lookUpEdit_group.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_group.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", "Tên nhóm")});
            this.lookUpEdit_group.Properties.DisplayMember = "ten";
            this.lookUpEdit_group.Properties.NullText = "[Chưa chọn nhóm quyền]";
            this.lookUpEdit_group.Properties.ReadOnly = true;
            this.lookUpEdit_group.Properties.ValueMember = "id";
            this.lookUpEdit_group.Size = new System.Drawing.Size(212, 20);
            this.lookUpEdit_group.TabIndex = 10;
            this.lookUpEdit_group.ToolTip = "Chỉ có thể đổi Group cho tài khoản\r\nkhác tài khoản đang đăng nhập";
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(174, 311);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 14;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(93, 311);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.Location = new System.Drawing.Point(6, 160);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(48, 13);
            this.lblNgayTao.TabIndex = 7;
            this.lblNgayTao.Text = "Ngày tạo:";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Location = new System.Drawing.Point(6, 108);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(48, 13);
            this.lblMatKhau.TabIndex = 7;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Location = new System.Drawing.Point(6, 82);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(50, 13);
            this.lblTaiKhoan.TabIndex = 7;
            this.lblTaiKhoan.Text = "Tài khoản:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(6, 56);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(36, 13);
            this.lblHoTen.TabIndex = 6;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(6, 30);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(18, 13);
            this.lblMa.TabIndex = 5;
            this.lblMa.Text = "Mã:";
            // 
            // txtMatKhauQuanTriVien
            // 
            this.txtMatKhauQuanTriVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhauQuanTriVien.Location = new System.Drawing.Point(93, 104);
            this.txtMatKhauQuanTriVien.Name = "txtMatKhauQuanTriVien";
            this.txtMatKhauQuanTriVien.Properties.PasswordChar = '●';
            this.txtMatKhauQuanTriVien.Properties.ReadOnly = true;
            this.txtMatKhauQuanTriVien.Size = new System.Drawing.Size(241, 20);
            this.txtMatKhauQuanTriVien.TabIndex = 7;
            // 
            // txtTaiKhoanQuanTriVien
            // 
            this.txtTaiKhoanQuanTriVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaiKhoanQuanTriVien.Location = new System.Drawing.Point(93, 79);
            this.txtTaiKhoanQuanTriVien.Name = "txtTaiKhoanQuanTriVien";
            this.txtTaiKhoanQuanTriVien.Properties.ReadOnly = true;
            this.txtTaiKhoanQuanTriVien.Size = new System.Drawing.Size(241, 20);
            this.txtTaiKhoanQuanTriVien.TabIndex = 6;
            // 
            // txtTenQuanTriVien
            // 
            this.txtTenQuanTriVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenQuanTriVien.Location = new System.Drawing.Point(93, 53);
            this.txtTenQuanTriVien.Name = "txtTenQuanTriVien";
            this.txtTenQuanTriVien.Properties.ReadOnly = true;
            this.txtTenQuanTriVien.Size = new System.Drawing.Size(241, 20);
            this.txtTenQuanTriVien.TabIndex = 5;
            // 
            // dxErrorProviderInfo
            // 
            this.dxErrorProviderInfo.ContainerControl = this;
            // 
            // rbnPagePhanQuyen
            // 
            this.rbnPagePhanQuyen.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupQTV,
            this.rbnGroupNhomQuyen,
            this.ribbonPageGroup1});
            this.rbnPagePhanQuyen.Image = global::TSCD_GUI.Properties.Resources.phanquyen;
            this.rbnPagePhanQuyen.Name = "rbnPagePhanQuyen";
            this.rbnPagePhanQuyen.Text = "Phân quyền";
            // 
            // rbnGroupNhomQuyen
            // 
            this.rbnGroupNhomQuyen.ItemLinks.Add(this.barBtnNhomQuyen);
            this.rbnGroupNhomQuyen.Name = "rbnGroupNhomQuyen";
            this.rbnGroupNhomQuyen.ShowCaptionButton = false;
            this.rbnGroupNhomQuyen.Text = "Nhóm quyền";
            // 
            // barBtnNhomQuyen
            // 
            this.barBtnNhomQuyen.Caption = "Nhóm quyền";
            this.barBtnNhomQuyen.Id = 8;
            this.barBtnNhomQuyen.LargeGlyph = global::TSCD_GUI.Properties.Resources.User_Group_icon;
            this.barBtnNhomQuyen.Name = "barBtnNhomQuyen";
            this.barBtnNhomQuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnNhomQuyen_ItemClick);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemDongTab);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Đóng tab";
            // 
            // barButtonItemDongTab
            // 
            this.barButtonItemDongTab.Caption = "Đóng tab";
            this.barButtonItemDongTab.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemDongTab.Glyph")));
            this.barButtonItemDongTab.Id = 9;
            this.barButtonItemDongTab.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemDongTab.LargeGlyph")));
            this.barButtonItemDongTab.Name = "barButtonItemDongTab";
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 145);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlQTV);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(862, 352);
            this.splitContainerControlMain.SplitterPosition = 350;
            this.splitContainerControlMain.TabIndex = 3;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // gridControlQTV
            // 
            this.gridControlQTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlQTV.Location = new System.Drawing.Point(0, 0);
            this.gridControlQTV.MainView = this.gridViewQTV;
            this.gridControlQTV.Name = "gridControlQTV";
            this.gridControlQTV.Size = new System.Drawing.Size(507, 352);
            this.gridControlQTV.TabIndex = 0;
            this.gridControlQTV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQTV});
            // 
            // gridViewQTV
            // 
            this.gridViewQTV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colusername,
            this.colhoten,
            this.colten_group,
            this.coldate_create,
            this.coldate_modified,
            this.colid});
            this.gridViewQTV.GridControl = this.gridControlQTV;
            this.gridViewQTV.GroupCount = 1;
            this.gridViewQTV.Name = "gridViewQTV";
            this.gridViewQTV.OptionsBehavior.Editable = false;
            this.gridViewQTV.OptionsBehavior.ReadOnly = true;
            this.gridViewQTV.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewQTV.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewQTV.OptionsView.ShowAutoFilterRow = true;
            this.gridViewQTV.OptionsView.ShowGroupPanel = false;
            this.gridViewQTV.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colten_group, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewQTV.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewQTV_FocusedRowChanged);
            this.gridViewQTV.DataSourceChanged += new System.EventHandler(this.gridViewQTV_DataSourceChanged);
            // 
            // colusername
            // 
            this.colusername.Caption = "Tài khoản";
            this.colusername.FieldName = "username";
            this.colusername.Name = "colusername";
            this.colusername.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colusername.Visible = true;
            this.colusername.VisibleIndex = 0;
            this.colusername.Width = 149;
            // 
            // colhoten
            // 
            this.colhoten.Caption = "Họ tên";
            this.colhoten.FieldName = "hoten";
            this.colhoten.Name = "colhoten";
            this.colhoten.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colhoten.Visible = true;
            this.colhoten.VisibleIndex = 1;
            this.colhoten.Width = 182;
            // 
            // colten_group
            // 
            this.colten_group.Caption = "Nhóm quyền";
            this.colten_group.FieldName = "ten_group";
            this.colten_group.Name = "colten_group";
            this.colten_group.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colten_group.Visible = true;
            this.colten_group.VisibleIndex = 6;
            // 
            // coldate_create
            // 
            this.coldate_create.Caption = "Ngày tạo";
            this.coldate_create.FieldName = "date_create";
            this.coldate_create.Name = "coldate_create";
            this.coldate_create.Visible = true;
            this.coldate_create.VisibleIndex = 2;
            this.coldate_create.Width = 182;
            // 
            // coldate_modified
            // 
            this.coldate_modified.Caption = "Ngày chỉnh sửa";
            this.coldate_modified.FieldName = "date_modified";
            this.coldate_modified.Name = "coldate_modified";
            this.coldate_modified.Visible = true;
            this.coldate_modified.VisibleIndex = 3;
            this.coldate_modified.Width = 183;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfo.Controls.Add(this.btnNhomQuyen);
            this.groupControlInfo.Controls.Add(this.btnXoa_r);
            this.groupControlInfo.Controls.Add(this.lblMoTa);
            this.groupControlInfo.Controls.Add(this.btnSua_r);
            this.groupControlInfo.Controls.Add(this.memoEdit_mota);
            this.groupControlInfo.Controls.Add(this.btnThem_r);
            this.groupControlInfo.Controls.Add(this.dateCreated);
            this.groupControlInfo.Controls.Add(this.lblXNMatKhau);
            this.groupControlInfo.Controls.Add(this.txtXacNhanMK);
            this.groupControlInfo.Controls.Add(this.lblNhom);
            this.groupControlInfo.Controls.Add(this.lookUpEdit_group);
            this.groupControlInfo.Controls.Add(this.btnHuy);
            this.groupControlInfo.Controls.Add(this.btnOK);
            this.groupControlInfo.Controls.Add(this.lblNgayTao);
            this.groupControlInfo.Controls.Add(this.lblMatKhau);
            this.groupControlInfo.Controls.Add(this.lblTaiKhoan);
            this.groupControlInfo.Controls.Add(this.lblHoTen);
            this.groupControlInfo.Controls.Add(this.lblMa);
            this.groupControlInfo.Controls.Add(this.txtMatKhauQuanTriVien);
            this.groupControlInfo.Controls.Add(this.txtTaiKhoanQuanTriVien);
            this.groupControlInfo.Controls.Add(this.txtTenQuanTriVien);
            this.groupControlInfo.Controls.Add(this.txtMaQuanTriVien);
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(350, 352);
            this.groupControlInfo.TabIndex = 2;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // btnNhomQuyen
            // 
            this.btnNhomQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhomQuyen.Image = ((System.Drawing.Image)(resources.GetObject("btnNhomQuyen.Image")));
            this.btnNhomQuyen.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNhomQuyen.Location = new System.Drawing.Point(311, 182);
            this.btnNhomQuyen.Name = "btnNhomQuyen";
            this.btnNhomQuyen.Size = new System.Drawing.Size(23, 23);
            this.btnNhomQuyen.TabIndex = 11;
            this.btnNhomQuyen.Click += new System.EventHandler(this.btnNhomQuyen_Click);
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.delete_19;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(311, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 3;
            this.btnXoa_r.Click += new System.EventHandler(this.btnXoa_r_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(8, 212);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 42;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_19;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(285, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 2;
            this.btnSua_r.Click += new System.EventHandler(this.btnSua_r_Click);
            // 
            // memoEdit_mota
            // 
            this.memoEdit_mota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEdit_mota.Location = new System.Drawing.Point(93, 209);
            this.memoEdit_mota.MenuManager = this.rbnPhanQuyen;
            this.memoEdit_mota.Name = "memoEdit_mota";
            this.memoEdit_mota.Properties.ReadOnly = true;
            this.memoEdit_mota.Size = new System.Drawing.Size(241, 96);
            this.memoEdit_mota.TabIndex = 12;
            this.memoEdit_mota.UseOptimizedRendering = true;
            // 
            // rbnPhanQuyen
            // 
            this.rbnPhanQuyen.ExpandCollapseItem.Id = 0;
            this.rbnPhanQuyen.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnPhanQuyen.ExpandCollapseItem,
            this.barBtnThemQTV,
            this.barBtnSuaQTV,
            this.barBtnXoaQTV,
            this.barBtnNhomQuyen,
            this.barButtonItemDongTab});
            this.rbnPhanQuyen.Location = new System.Drawing.Point(0, 0);
            this.rbnPhanQuyen.MaxItemId = 10;
            this.rbnPhanQuyen.Name = "rbnPhanQuyen";
            this.rbnPhanQuyen.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPagePhanQuyen});
            this.rbnPhanQuyen.Size = new System.Drawing.Size(862, 145);
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_19;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(259, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 1;
            this.btnThem_r.Visible = false;
            this.btnThem_r.Click += new System.EventHandler(this.btnThem_r_Click);
            // 
            // txtMaQuanTriVien
            // 
            this.txtMaQuanTriVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaQuanTriVien.Location = new System.Drawing.Point(93, 27);
            this.txtMaQuanTriVien.Name = "txtMaQuanTriVien";
            this.txtMaQuanTriVien.Properties.ReadOnly = true;
            this.txtMaQuanTriVien.Size = new System.Drawing.Size(241, 20);
            this.txtMaQuanTriVien.TabIndex = 4;
            // 
            // ucPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Controls.Add(this.rbnPhanQuyen);
            this.Name = "ucPhanQuyen";
            this.Size = new System.Drawing.Size(862, 497);
            ((System.ComponentModel.ISupportInitialize)(this.dateCreated.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXacNhanMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_group.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauQuanTriVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoanQuanTriVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQuanTriVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_mota.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbnPhanQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQuanTriVien.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupQTV;
        private DevExpress.XtraBars.BarButtonItem barBtnThemQTV;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaQTV;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaQTV;
        private DevExpress.XtraEditors.DateEdit dateCreated;
        private DevExpress.XtraEditors.LabelControl lblXNMatKhau;
        private DevExpress.XtraEditors.TextEdit txtXacNhanMK;
        private DevExpress.XtraEditors.LabelControl lblNhom;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_group;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblNgayTao;
        private DevExpress.XtraEditors.LabelControl lblMatKhau;
        private DevExpress.XtraEditors.LabelControl lblTaiKhoan;
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraEditors.LabelControl lblMa;
        private DevExpress.XtraEditors.TextEdit txtMatKhauQuanTriVien;
        private DevExpress.XtraEditors.TextEdit txtTaiKhoanQuanTriVien;
        private DevExpress.XtraEditors.TextEdit txtTenQuanTriVien;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderInfo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlQTV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQTV;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraGrid.Columns.GridColumn colhoten;
        private DevExpress.XtraGrid.Columns.GridColumn colten_group;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_create;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_modified;
        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.MemoEdit memoEdit_mota;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbnPhanQuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPagePhanQuyen;
        private DevExpress.XtraEditors.TextEdit txtMaQuanTriVien;
        private DevExpress.XtraBars.BarButtonItem barBtnNhomQuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupNhomQuyen;
        private DevExpress.XtraEditors.SimpleButton btnXoa_r;
        private DevExpress.XtraEditors.SimpleButton btnSua_r;
        private DevExpress.XtraEditors.SimpleButton btnThem_r;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraEditors.SimpleButton btnNhomQuyen;
        public DevExpress.XtraBars.BarButtonItem barButtonItemDongTab;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}
