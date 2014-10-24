namespace PTB_GUI.QLLoaiThietBi
{
    partial class ucQuanLyLoaiTB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLyLoaiTB));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListLoaiTB = new DevExpress.XtraTreeList.TreeList();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colkieu_ql = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnImage = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlHinh = new DevExpress.XtraEditors.LabelControl();
            this.imageSliderLoaiTB = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.btnR_Sua = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlMota = new DevExpress.XtraEditors.LabelControl();
            this.btnR_Them = new DevExpress.XtraEditors.SimpleButton();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnR_Xoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlLoai = new DevExpress.XtraEditors.PanelControl();
            this.lueThuoc = new DevExpress.XtraEditors.LookUpEdit();
            this.ceTBsoluonglon = new DevExpress.XtraEditors.CheckEdit();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControlLoai = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTen = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.ribbonLoaiTB = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonThemLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSuaLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonXoaLoaiTB = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDown = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageLoaiTB_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupLoaiTB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupOrder = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnGroupImport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSliderLoaiTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLoai)).BeginInit();
            this.panelControlLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueThuoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceTBsoluonglon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonLoaiTB)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 145);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListLoaiTB);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(944, 584);
            this.splitContainerControl1.SplitterPosition = 350;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListLoaiTB
            // 
            this.treeListLoaiTB.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid,
            this.colten,
            this.colkieu_ql});
            this.treeListLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLoaiTB.KeyFieldName = "id";
            this.treeListLoaiTB.Location = new System.Drawing.Point(0, 0);
            this.treeListLoaiTB.Name = "treeListLoaiTB";
            this.treeListLoaiTB.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeListLoaiTB.OptionsBehavior.Editable = false;
            this.treeListLoaiTB.OptionsBehavior.EnableFiltering = true;
            this.treeListLoaiTB.OptionsFind.AllowFindPanel = true;
            this.treeListLoaiTB.OptionsFind.AlwaysVisible = true;
            this.treeListLoaiTB.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListLoaiTB.ParentFieldName = "parent_id";
            this.treeListLoaiTB.Size = new System.Drawing.Size(590, 584);
            this.treeListLoaiTB.TabIndex = 0;
            this.treeListLoaiTB.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListLoaiTB_FocusedNodeChanged);
            this.treeListLoaiTB.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.OnFilterNode);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.Caption = "Loại thiết bị";
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            // 
            // colkieu_ql
            // 
            this.colkieu_ql.Caption = "Kiểu quản lý";
            this.colkieu_ql.FieldName = "kieu_ql";
            this.colkieu_ql.Name = "colkieu_ql";
            this.colkieu_ql.Visible = true;
            this.colkieu_ql.VisibleIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnImage);
            this.groupControl1.Controls.Add(this.labelControlHinh);
            this.groupControl1.Controls.Add(this.imageSliderLoaiTB);
            this.groupControl1.Controls.Add(this.btnR_Sua);
            this.groupControl1.Controls.Add(this.labelControlMota);
            this.groupControl1.Controls.Add(this.btnR_Them);
            this.groupControl1.Controls.Add(this.txtMoTa);
            this.groupControl1.Controls.Add(this.btnR_Xoa);
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.btnOk);
            this.groupControl1.Controls.Add(this.panelControlLoai);
            this.groupControl1.Controls.Add(this.ceTBsoluonglon);
            this.groupControl1.Controls.Add(this.txtTen);
            this.groupControl1.Controls.Add(this.labelControlLoai);
            this.groupControl1.Controls.Add(this.labelControlTen);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(350, 584);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết";
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(183, 54);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 6;
            this.btnImage.Text = "Chọn";
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // labelControlHinh
            // 
            this.labelControlHinh.Location = new System.Drawing.Point(5, 54);
            this.labelControlHinh.Name = "labelControlHinh";
            this.labelControlHinh.Size = new System.Drawing.Size(46, 13);
            this.labelControlHinh.TabIndex = 32;
            this.labelControlHinh.Text = "Hình ảnh:";
            // 
            // imageSliderLoaiTB
            // 
            this.imageSliderLoaiTB.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.imageSliderLoaiTB.Location = new System.Drawing.Point(57, 52);
            this.imageSliderLoaiTB.Name = "imageSliderLoaiTB";
            this.imageSliderLoaiTB.Size = new System.Drawing.Size(120, 120);
            this.imageSliderLoaiTB.TabIndex = 5;
            this.imageSliderLoaiTB.Text = "imageSlider1";
            this.imageSliderLoaiTB.ToolTip = "Nhấp đôi vào đây để phóng to hình ảnh";
            // 
            // btnR_Sua
            // 
            this.btnR_Sua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Sua.Image = global::PTB_GUI.Properties.Resources.pencil_19;
            this.btnR_Sua.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Sua.Location = new System.Drawing.Point(286, 0);
            this.btnR_Sua.Name = "btnR_Sua";
            this.btnR_Sua.Size = new System.Drawing.Size(23, 23);
            this.btnR_Sua.TabIndex = 2;
            this.btnR_Sua.Click += new System.EventHandler(this.btnR_Sua_Click);
            // 
            // labelControlMota
            // 
            this.labelControlMota.Location = new System.Drawing.Point(5, 206);
            this.labelControlMota.Name = "labelControlMota";
            this.labelControlMota.Size = new System.Drawing.Size(31, 13);
            this.labelControlMota.TabIndex = 12;
            this.labelControlMota.Text = "Mô tả:";
            // 
            // btnR_Them
            // 
            this.btnR_Them.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Them.Image = global::PTB_GUI.Properties.Resources.plus_19;
            this.btnR_Them.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Them.Location = new System.Drawing.Point(260, 0);
            this.btnR_Them.Name = "btnR_Them";
            this.btnR_Them.Size = new System.Drawing.Size(23, 23);
            this.btnR_Them.TabIndex = 1;
            this.btnR_Them.Click += new System.EventHandler(this.btnR_Them_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(57, 204);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Properties.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(278, 91);
            this.txtMoTa.TabIndex = 8;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnR_Xoa
            // 
            this.btnR_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR_Xoa.Image = global::PTB_GUI.Properties.Resources.delete_19;
            this.btnR_Xoa.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnR_Xoa.Location = new System.Drawing.Point(312, 0);
            this.btnR_Xoa.Name = "btnR_Xoa";
            this.btnR_Xoa.Size = new System.Drawing.Size(23, 23);
            this.btnR_Xoa.TabIndex = 3;
            this.btnR_Xoa.Click += new System.EventHandler(this.btnR_Xoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(138, 327);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(57, 327);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelControlLoai
            // 
            this.panelControlLoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlLoai.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlLoai.Controls.Add(this.lueThuoc);
            this.panelControlLoai.Location = new System.Drawing.Point(57, 301);
            this.panelControlLoai.Name = "panelControlLoai";
            this.panelControlLoai.Size = new System.Drawing.Size(278, 20);
            this.panelControlLoai.TabIndex = 7;
            // 
            // lueThuoc
            // 
            this.lueThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueThuoc.Location = new System.Drawing.Point(0, 0);
            this.lueThuoc.Name = "lueThuoc";
            this.lueThuoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueThuoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", "Loại")});
            this.lueThuoc.Properties.DisplayMember = "ten";
            this.lueThuoc.Properties.NullText = "";
            this.lueThuoc.Properties.ReadOnly = true;
            this.lueThuoc.Properties.ValueMember = "id";
            this.lueThuoc.Size = new System.Drawing.Size(278, 20);
            this.lueThuoc.TabIndex = 9;
            // 
            // ceTBsoluonglon
            // 
            this.ceTBsoluonglon.Location = new System.Drawing.Point(55, 29);
            this.ceTBsoluonglon.Name = "ceTBsoluonglon";
            this.ceTBsoluonglon.Properties.Caption = "Thiết bị được quản lý với số lượng lớn";
            this.ceTBsoluonglon.Properties.ReadOnly = true;
            this.ceTBsoluonglon.Size = new System.Drawing.Size(222, 19);
            this.ceTBsoluonglon.TabIndex = 4;
            this.ceTBsoluonglon.CheckedChanged += new System.EventHandler(this.ceTBsoluonglon_CheckedChanged);
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(57, 178);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(278, 20);
            this.txtTen.TabIndex = 7;
            // 
            // labelControlLoai
            // 
            this.labelControlLoai.Location = new System.Drawing.Point(5, 304);
            this.labelControlLoai.Name = "labelControlLoai";
            this.labelControlLoai.Size = new System.Drawing.Size(33, 13);
            this.labelControlLoai.TabIndex = 2;
            this.labelControlLoai.Text = "Thuộc:";
            // 
            // labelControlTen
            // 
            this.labelControlTen.Location = new System.Drawing.Point(5, 181);
            this.labelControlTen.Name = "labelControlTen";
            this.labelControlTen.Size = new System.Drawing.Size(41, 13);
            this.labelControlTen.TabIndex = 1;
            this.labelControlTen.Text = "Tên loại:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // ribbonLoaiTB
            // 
            this.ribbonLoaiTB.ApplicationIcon = global::PTB_GUI.Properties.Resources.Logo;
            this.ribbonLoaiTB.ExpandCollapseItem.Id = 0;
            this.ribbonLoaiTB.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonLoaiTB.ExpandCollapseItem,
            this.barButtonThemLoaiTB,
            this.barButtonSuaLoaiTB,
            this.barButtonXoaLoaiTB,
            this.barBtnImport,
            this.barBtnUp,
            this.barBtnDown});
            this.ribbonLoaiTB.Location = new System.Drawing.Point(0, 0);
            this.ribbonLoaiTB.MaxItemId = 45;
            this.ribbonLoaiTB.Name = "ribbonLoaiTB";
            this.ribbonLoaiTB.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageLoaiTB_Home});
            this.ribbonLoaiTB.Size = new System.Drawing.Size(944, 145);
            // 
            // barButtonThemLoaiTB
            // 
            this.barButtonThemLoaiTB.Caption = "Thêm loại thiết bị";
            this.barButtonThemLoaiTB.Glyph = global::PTB_GUI.Properties.Resources.plus_32;
            this.barButtonThemLoaiTB.Id = 39;
            this.barButtonThemLoaiTB.Name = "barButtonThemLoaiTB";
            this.barButtonThemLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonThemLoaiTB_ItemClick);
            // 
            // barButtonSuaLoaiTB
            // 
            this.barButtonSuaLoaiTB.Caption = "Sửa loại thiết bị";
            this.barButtonSuaLoaiTB.Glyph = global::PTB_GUI.Properties.Resources.pencil_32;
            this.barButtonSuaLoaiTB.Id = 40;
            this.barButtonSuaLoaiTB.Name = "barButtonSuaLoaiTB";
            this.barButtonSuaLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSuaLoaiTB_ItemClick);
            // 
            // barButtonXoaLoaiTB
            // 
            this.barButtonXoaLoaiTB.Caption = "Xóa loại thiết bị";
            this.barButtonXoaLoaiTB.Glyph = global::PTB_GUI.Properties.Resources.delete_32;
            this.barButtonXoaLoaiTB.Id = 41;
            this.barButtonXoaLoaiTB.Name = "barButtonXoaLoaiTB";
            this.barButtonXoaLoaiTB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonXoaLoaiTB_ItemClick);
            // 
            // barBtnImport
            // 
            this.barBtnImport.Caption = "Import";
            this.barBtnImport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.Glyph")));
            this.barBtnImport.Id = 42;
            this.barBtnImport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.LargeGlyph")));
            this.barBtnImport.Name = "barBtnImport";
            this.barBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnImport_ItemClick);
            // 
            // barBtnUp
            // 
            this.barBtnUp.Caption = "Lên";
            this.barBtnUp.Glyph = global::PTB_GUI.Properties.Resources.arrow_up;
            this.barBtnUp.Id = 43;
            this.barBtnUp.Name = "barBtnUp";
            this.barBtnUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUp_ItemClick);
            // 
            // barBtnDown
            // 
            this.barBtnDown.Caption = "Xuống";
            this.barBtnDown.Glyph = global::PTB_GUI.Properties.Resources.arrow_down;
            this.barBtnDown.Id = 44;
            this.barBtnDown.Name = "barBtnDown";
            this.barBtnDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDown_ItemClick);
            // 
            // rbnPageLoaiTB_Home
            // 
            this.rbnPageLoaiTB_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupLoaiTB,
            this.rbnGroupOrder,
            this.rbnGroupImport});
            this.rbnPageLoaiTB_Home.Image = global::PTB_GUI.Properties.Resources.chair_icon;
            this.rbnPageLoaiTB_Home.Name = "rbnPageLoaiTB_Home";
            this.rbnPageLoaiTB_Home.Text = "Loại thiết bị";
            // 
            // rbnGroupLoaiTB
            // 
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barButtonThemLoaiTB);
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barButtonSuaLoaiTB);
            this.rbnGroupLoaiTB.ItemLinks.Add(this.barButtonXoaLoaiTB);
            this.rbnGroupLoaiTB.Name = "rbnGroupLoaiTB";
            this.rbnGroupLoaiTB.ShowCaptionButton = false;
            this.rbnGroupLoaiTB.Text = "Loại thiết bị";
            // 
            // rbnGroupOrder
            // 
            this.rbnGroupOrder.ItemLinks.Add(this.barBtnUp);
            this.rbnGroupOrder.ItemLinks.Add(this.barBtnDown);
            this.rbnGroupOrder.Name = "rbnGroupOrder";
            this.rbnGroupOrder.ShowCaptionButton = false;
            this.rbnGroupOrder.Text = "Sắp xếp";
            // 
            // rbnGroupImport
            // 
            this.rbnGroupImport.ItemLinks.Add(this.barBtnImport);
            this.rbnGroupImport.Name = "rbnGroupImport";
            this.rbnGroupImport.ShowCaptionButton = false;
            this.rbnGroupImport.Text = "Import";
            // 
            // ucQuanLyLoaiTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonLoaiTB);
            this.Name = "ucQuanLyLoaiTB";
            this.Size = new System.Drawing.Size(944, 729);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLoaiTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSliderLoaiTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLoai)).EndInit();
            this.panelControlLoai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueThuoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceTBsoluonglon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonLoaiTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeListLoaiTB;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControlLoai;
        private DevExpress.XtraEditors.LabelControl labelControlTen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraEditors.CheckEdit ceTBsoluonglon;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.PanelControl panelControlLoai;
        private DevExpress.XtraEditors.LookUpEdit lueThuoc;
        private DevExpress.XtraEditors.LabelControl labelControlMota;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barButtonThemLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barButtonSuaLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barButtonXoaLoaiTB;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageLoaiTB_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupLoaiTB;
        private DevExpress.XtraEditors.SimpleButton btnR_Sua;
        private DevExpress.XtraEditors.SimpleButton btnR_Them;
        private DevExpress.XtraEditors.SimpleButton btnR_Xoa;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraBars.BarButtonItem barBtnImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupImport;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colkieu_ql;
        private DevExpress.XtraBars.BarButtonItem barBtnUp;
        private DevExpress.XtraBars.BarButtonItem barBtnDown;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupOrder;
        private DevExpress.XtraEditors.SimpleButton btnImage;
        private DevExpress.XtraEditors.LabelControl labelControlHinh;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSliderLoaiTB;
    }
}
