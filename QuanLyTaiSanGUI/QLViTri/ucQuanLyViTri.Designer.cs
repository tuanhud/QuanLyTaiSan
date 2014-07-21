namespace QuanLyTaiSanGUI.QLViTri.MyUserControl
{
    partial class ucQuanLyViTri
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListViTri = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colloai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colid_c = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colid_p = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnR_Sua = new DevExpress.XtraEditors.SimpleButton();
            this.btnR_Them = new DevExpress.XtraEditors.SimpleButton();
            this.btnR_Xoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.rbnPageViTri_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupViTri_CoSo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnThemCoSo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaCoSo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaCoSo = new DevExpress.XtraBars.BarButtonItem();
            this.rbnGroupViTri_Day = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnThemDay = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaDay = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaDay = new DevExpress.XtraBars.BarButtonItem();
            this.rbnGroupViTri_Tang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnThemTang = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaTang = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaTang = new DevExpress.XtraBars.BarButtonItem();
            this.rbnGroupImport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.rbnGroupMap = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnMap = new DevExpress.XtraBars.BarButtonItem();
            this.rbnGroupOrder = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnUp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDown = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonViTri = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 145);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListViTri);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(855, 470);
            this.splitContainerControl1.SplitterPosition = 350;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListViTri
            // 
            this.treeListViTri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colloai,
            this.colid_c,
            this.colid_p});
            this.treeListViTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViTri.KeyFieldName = "id_c";
            this.treeListViTri.Location = new System.Drawing.Point(0, 0);
            this.treeListViTri.Name = "treeListViTri";
            this.treeListViTri.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeListViTri.OptionsBehavior.Editable = false;
            this.treeListViTri.OptionsBehavior.EnableFiltering = true;
            this.treeListViTri.OptionsFind.AllowFindPanel = true;
            this.treeListViTri.OptionsFind.AlwaysVisible = true;
            this.treeListViTri.OptionsFind.ShowCloseButton = false;
            this.treeListViTri.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListViTri.ParentFieldName = "id_p";
            this.treeListViTri.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeListViTri.Size = new System.Drawing.Size(500, 470);
            this.treeListViTri.TabIndex = 0;
            this.treeListViTri.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListViTri_FocusedNodeChanged);
            this.treeListViTri.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Vị trí";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colloai
            // 
            this.colloai.Caption = "loai";
            this.colloai.FieldName = "loai";
            this.colloai.Name = "colloai";
            // 
            // colid_c
            // 
            this.colid_c.Caption = "id_c";
            this.colid_c.FieldName = "id_c";
            this.colid_c.Name = "colid_c";
            // 
            // colid_p
            // 
            this.colid_p.Caption = "id_p";
            this.colid_p.FieldName = "id_p";
            this.colid_p.Name = "colid_p";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnR_Sua);
            this.groupControl1.Controls.Add(this.btnR_Them);
            this.groupControl1.Controls.Add(this.btnR_Xoa);
            this.groupControl1.Controls.Add(this.btnImage);
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.btnOK);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.imageSlider1);
            this.groupControl1.Controls.Add(this.txtTen);
            this.groupControl1.Controls.Add(this.txtMoTa);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(350, 470);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết";
            // 
            // btnR_Sua
            // 
            this.btnR_Sua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Sua.Image = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit_24;
            this.btnR_Sua.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Sua.Location = new System.Drawing.Point(290, 0);
            this.btnR_Sua.Name = "btnR_Sua";
            this.btnR_Sua.Size = new System.Drawing.Size(23, 23);
            this.btnR_Sua.TabIndex = 14;
            this.btnR_Sua.Click += new System.EventHandler(this.btnR_Sua_Click);
            // 
            // btnR_Them
            // 
            this.btnR_Them.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Them.Image = global::QuanLyTaiSanGUI.Properties.Resources.plus_2_24;
            this.btnR_Them.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Them.Location = new System.Drawing.Point(264, 0);
            this.btnR_Them.Name = "btnR_Them";
            this.btnR_Them.Size = new System.Drawing.Size(23, 23);
            this.btnR_Them.TabIndex = 13;
            this.btnR_Them.Click += new System.EventHandler(this.btnR_Them_Click);
            // 
            // btnR_Xoa
            // 
            this.btnR_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Xoa.Image = global::QuanLyTaiSanGUI.Properties.Resources.minus_2_24;
            this.btnR_Xoa.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Xoa.Location = new System.Drawing.Point(316, 0);
            this.btnR_Xoa.Name = "btnR_Xoa";
            this.btnR_Xoa.Size = new System.Drawing.Size(23, 23);
            this.btnR_Xoa.TabIndex = 11;
            this.btnR_Xoa.Click += new System.EventHandler(this.btnR_Xoa_Click);
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(185, 30);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 6;
            this.btnImage.Text = "Chọn";
            this.btnImage.Visible = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(141, 317);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(59, 318);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Location = new System.Drawing.Point(59, 182);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(280, 20);
            this.panelControl1.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 211);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Mô tả:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 185);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Thuộc:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 159);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tên:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Hình ảnh:";
            // 
            // imageSlider1
            // 
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.imageSlider1.Location = new System.Drawing.Point(59, 30);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(120, 120);
            this.imageSlider1.TabIndex = 2;
            this.imageSlider1.Text = "imageSlider1";
            this.imageSlider1.ToolTip = "Nhấp đôi vào đây để phóng to hình ảnh";
            this.imageSlider1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageSlider1_MouseDoubleClick);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(59, 156);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(280, 20);
            this.txtTen.TabIndex = 1;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(59, 208);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Properties.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(280, 106);
            this.txtMoTa.TabIndex = 3;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // rbnPageViTri_Home
            // 
            this.rbnPageViTri_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupViTri_CoSo,
            this.rbnGroupViTri_Day,
            this.rbnGroupViTri_Tang,
            this.rbnGroupImport,
            this.rbnGroupMap,
            this.rbnGroupOrder});
            this.rbnPageViTri_Home.Image = global::QuanLyTaiSanGUI.Properties.Resources.vitri1;
            this.rbnPageViTri_Home.Name = "rbnPageViTri_Home";
            this.rbnPageViTri_Home.Text = "Vị trí";
            // 
            // rbnGroupViTri_CoSo
            // 
            this.rbnGroupViTri_CoSo.ItemLinks.Add(this.barBtnThemCoSo);
            this.rbnGroupViTri_CoSo.ItemLinks.Add(this.barBtnSuaCoSo);
            this.rbnGroupViTri_CoSo.ItemLinks.Add(this.barBtnXoaCoSo);
            this.rbnGroupViTri_CoSo.Name = "rbnGroupViTri_CoSo";
            this.rbnGroupViTri_CoSo.ShowCaptionButton = false;
            this.rbnGroupViTri_CoSo.Text = "Cơ sở";
            // 
            // barBtnThemCoSo
            // 
            this.barBtnThemCoSo.Caption = "Thêm cơ sở";
            this.barBtnThemCoSo.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.plus_2;
            this.barBtnThemCoSo.Id = 9;
            this.barBtnThemCoSo.Name = "barBtnThemCoSo";
            this.barBtnThemCoSo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemCoSo_ItemClick);
            // 
            // barBtnSuaCoSo
            // 
            this.barBtnSuaCoSo.Caption = "Sửa cơ sở";
            this.barBtnSuaCoSo.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit;
            this.barBtnSuaCoSo.Id = 10;
            this.barBtnSuaCoSo.Name = "barBtnSuaCoSo";
            this.barBtnSuaCoSo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaCoSo_ItemClick);
            // 
            // barBtnXoaCoSo
            // 
            this.barBtnXoaCoSo.Caption = "Xóa cơ sở";
            this.barBtnXoaCoSo.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.minus_2;
            this.barBtnXoaCoSo.Id = 11;
            this.barBtnXoaCoSo.Name = "barBtnXoaCoSo";
            this.barBtnXoaCoSo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaCoSo_ItemClick);
            // 
            // rbnGroupViTri_Day
            // 
            this.rbnGroupViTri_Day.ItemLinks.Add(this.barBtnThemDay);
            this.rbnGroupViTri_Day.ItemLinks.Add(this.barBtnSuaDay);
            this.rbnGroupViTri_Day.ItemLinks.Add(this.barBtnXoaDay);
            this.rbnGroupViTri_Day.Name = "rbnGroupViTri_Day";
            this.rbnGroupViTri_Day.ShowCaptionButton = false;
            this.rbnGroupViTri_Day.Text = "Dãy";
            // 
            // barBtnThemDay
            // 
            this.barBtnThemDay.Caption = "Thêm Dãy";
            this.barBtnThemDay.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.plus_2;
            this.barBtnThemDay.Id = 12;
            this.barBtnThemDay.Name = "barBtnThemDay";
            this.barBtnThemDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemDay_ItemClick);
            // 
            // barBtnSuaDay
            // 
            this.barBtnSuaDay.Caption = "Sửa dãy";
            this.barBtnSuaDay.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit;
            this.barBtnSuaDay.Id = 13;
            this.barBtnSuaDay.Name = "barBtnSuaDay";
            this.barBtnSuaDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaDay_ItemClick);
            // 
            // barBtnXoaDay
            // 
            this.barBtnXoaDay.Caption = "Xóa dãy";
            this.barBtnXoaDay.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.minus_2;
            this.barBtnXoaDay.Id = 14;
            this.barBtnXoaDay.Name = "barBtnXoaDay";
            this.barBtnXoaDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaDay_ItemClick);
            // 
            // rbnGroupViTri_Tang
            // 
            this.rbnGroupViTri_Tang.ItemLinks.Add(this.barBtnThemTang);
            this.rbnGroupViTri_Tang.ItemLinks.Add(this.barBtnSuaTang);
            this.rbnGroupViTri_Tang.ItemLinks.Add(this.barBtnXoaTang);
            this.rbnGroupViTri_Tang.Name = "rbnGroupViTri_Tang";
            this.rbnGroupViTri_Tang.ShowCaptionButton = false;
            this.rbnGroupViTri_Tang.Text = "Tầng";
            // 
            // barBtnThemTang
            // 
            this.barBtnThemTang.Caption = "Thêm tầng";
            this.barBtnThemTang.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.plus_2;
            this.barBtnThemTang.Id = 15;
            this.barBtnThemTang.Name = "barBtnThemTang";
            this.barBtnThemTang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnThemTang_ItemClick);
            // 
            // barBtnSuaTang
            // 
            this.barBtnSuaTang.Caption = "Sửa tầng";
            this.barBtnSuaTang.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit;
            this.barBtnSuaTang.Id = 16;
            this.barBtnSuaTang.Name = "barBtnSuaTang";
            this.barBtnSuaTang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSuaTang_ItemClick);
            // 
            // barBtnXoaTang
            // 
            this.barBtnXoaTang.Caption = "Xóa tầng";
            this.barBtnXoaTang.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.minus_2;
            this.barBtnXoaTang.Id = 17;
            this.barBtnXoaTang.Name = "barBtnXoaTang";
            this.barBtnXoaTang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnXoaTang_ItemClick);
            // 
            // rbnGroupImport
            // 
            this.rbnGroupImport.ItemLinks.Add(this.barBtnImport);
            this.rbnGroupImport.Name = "rbnGroupImport";
            this.rbnGroupImport.ShowCaptionButton = false;
            this.rbnGroupImport.Text = "Import";
            // 
            // barBtnImport
            // 
            this.barBtnImport.Caption = "Import";
            this.barBtnImport.Id = 30;
            this.barBtnImport.LargeGlyph = global::QuanLyTaiSanGUI.Properties.Resources.import_icon;
            this.barBtnImport.Name = "barBtnImport";
            this.barBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnImport_ItemClick);
            // 
            // rbnGroupMap
            // 
            this.rbnGroupMap.ItemLinks.Add(this.barBtnMap);
            this.rbnGroupMap.Name = "rbnGroupMap";
            this.rbnGroupMap.ShowCaptionButton = false;
            this.rbnGroupMap.Text = "Bản đồ";
            // 
            // barBtnMap
            // 
            this.barBtnMap.Caption = "Xem bản đồ";
            this.barBtnMap.Id = 31;
            this.barBtnMap.LargeGlyph = global::QuanLyTaiSanGUI.Properties.Resources.Maps_icon;
            this.barBtnMap.Name = "barBtnMap";
            this.barBtnMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnMap_ItemClick);
            // 
            // rbnGroupOrder
            // 
            this.rbnGroupOrder.ItemLinks.Add(this.barBtnUp);
            this.rbnGroupOrder.ItemLinks.Add(this.barBtnDown);
            this.rbnGroupOrder.Name = "rbnGroupOrder";
            this.rbnGroupOrder.ShowCaptionButton = false;
            this.rbnGroupOrder.Text = "Sắp xếp";
            // 
            // barBtnUp
            // 
            this.barBtnUp.Caption = "Lên";
            this.barBtnUp.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.arrow_up;
            this.barBtnUp.Id = 32;
            this.barBtnUp.Name = "barBtnUp";
            this.barBtnUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUp_ItemClick);
            // 
            // barBtnDown
            // 
            this.barBtnDown.Caption = "Xuống";
            this.barBtnDown.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.arrow_down;
            this.barBtnDown.Id = 33;
            this.barBtnDown.Name = "barBtnDown";
            this.barBtnDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDown_ItemClick);
            // 
            // ribbonViTri
            // 
            this.ribbonViTri.ApplicationIcon = global::QuanLyTaiSanGUI.Properties.Resources.Logo;
            this.ribbonViTri.ExpandCollapseItem.Id = 0;
            this.ribbonViTri.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonViTri.ExpandCollapseItem,
            this.barBtnThemCoSo,
            this.barBtnSuaCoSo,
            this.barBtnXoaCoSo,
            this.barBtnThemDay,
            this.barBtnSuaDay,
            this.barBtnXoaDay,
            this.barBtnThemTang,
            this.barBtnSuaTang,
            this.barBtnXoaTang,
            this.barBtnImport,
            this.barBtnMap,
            this.barBtnUp,
            this.barBtnDown});
            this.ribbonViTri.Location = new System.Drawing.Point(0, 0);
            this.ribbonViTri.MaxItemId = 34;
            this.ribbonViTri.Name = "ribbonViTri";
            this.ribbonViTri.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageViTri_Home});
            this.ribbonViTri.Size = new System.Drawing.Size(855, 145);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // ucQuanLyViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonViTri);
            this.Name = "ucQuanLyViTri";
            this.Size = new System.Drawing.Size(855, 615);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeListViTri;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colloai;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraEditors.SimpleButton btnImage;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid_c;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid_p;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonViTri;
        private DevExpress.XtraBars.BarButtonItem barBtnThemCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnThemDay;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnThemTang;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaTang;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaTang;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageViTri_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupViTri_CoSo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupViTri_Day;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupViTri_Tang;
        private DevExpress.XtraEditors.SimpleButton btnR_Xoa;
        private DevExpress.XtraEditors.SimpleButton btnR_Sua;
        private DevExpress.XtraEditors.SimpleButton btnR_Them;
        private DevExpress.XtraBars.BarButtonItem barBtnImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupImport;
        private DevExpress.XtraBars.BarButtonItem barBtnMap;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupMap;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupOrder;
        private DevExpress.XtraBars.BarButtonItem barBtnUp;
        private DevExpress.XtraBars.BarButtonItem barBtnDown;
    }
}
