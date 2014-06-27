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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.ribbonViTri = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViTri)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 142);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListViTri);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(855, 473);
            this.splitContainerControl1.SplitterPosition = 454;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListViTri
            // 
            this.treeListViTri.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeListViTri.Appearance.FocusedCell.Options.UseBackColor = true;
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
            this.treeListViTri.OptionsBehavior.Editable = false;
            this.treeListViTri.OptionsBehavior.EnableFiltering = true;
            this.treeListViTri.OptionsBehavior.PopulateServiceColumns = true;
            this.treeListViTri.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.treeListViTri.OptionsFind.AllowFindPanel = true;
            this.treeListViTri.OptionsFind.AlwaysVisible = true;
            this.treeListViTri.ParentFieldName = "id_p";
            this.treeListViTri.Size = new System.Drawing.Size(454, 473);
            this.treeListViTri.TabIndex = 0;
            this.treeListViTri.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListViTri_FocusedNodeChanged);
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
            this.groupControl1.Size = new System.Drawing.Size(396, 473);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết";
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(185, 26);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 10;
            this.btnImage.Text = "Chọn";
            this.btnImage.Visible = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(141, 317);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(59, 318);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
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
            this.panelControl1.Size = new System.Drawing.Size(329, 20);
            this.panelControl1.TabIndex = 7;
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
            this.labelControl1.Location = new System.Drawing.Point(7, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Hình ảnh:";
            // 
            // imageSlider1
            // 
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imageSlider1.Location = new System.Drawing.Point(59, 27);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(120, 120);
            this.imageSlider1.TabIndex = 2;
            this.imageSlider1.Text = "imageSlider1";
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(59, 156);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(329, 20);
            this.txtTen.TabIndex = 0;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(59, 208);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Properties.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(329, 106);
            this.txtMoTa.TabIndex = 1;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // rbnPageViTri_Home
            // 
            this.rbnPageViTri_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupViTri_CoSo,
            this.rbnGroupViTri_Day,
            this.rbnGroupViTri_Tang});
            this.rbnPageViTri_Home.Name = "rbnPageViTri_Home";
            this.rbnPageViTri_Home.Text = "Trang chính";
            this.rbnPageViTri_Home.Visible = false;
            // 
            // rbnGroupViTri_CoSo
            // 
            this.rbnGroupViTri_CoSo.ItemLinks.Add(this.barBtnThemCoSo);
            this.rbnGroupViTri_CoSo.ItemLinks.Add(this.barBtnSuaCoSo);
            this.rbnGroupViTri_CoSo.ItemLinks.Add(this.barBtnXoaCoSo);
            this.rbnGroupViTri_CoSo.Name = "rbnGroupViTri_CoSo";
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
            this.rbnGroupViTri_Tang.Enabled = false;
            this.rbnGroupViTri_Tang.ItemLinks.Add(this.barBtnThemTang);
            this.rbnGroupViTri_Tang.ItemLinks.Add(this.barBtnSuaTang);
            this.rbnGroupViTri_Tang.ItemLinks.Add(this.barBtnXoaTang);
            this.rbnGroupViTri_Tang.Name = "rbnGroupViTri_Tang";
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
            this.barBtnXoaTang});
            this.ribbonViTri.Location = new System.Drawing.Point(0, 0);
            this.ribbonViTri.MaxItemId = 30;
            this.ribbonViTri.Name = "ribbonViTri";
            this.ribbonViTri.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageViTri_Home});
            this.ribbonViTri.Size = new System.Drawing.Size(855, 142);
            // 
            // ucQuanLyViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(400, 400);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViTri)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid_c;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid_p;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonViTri;
        private DevExpress.XtraBars.BarButtonItem barBtnThemPhong;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaPhong;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaPhong;
        private DevExpress.XtraBars.BarButtonItem barBtnThemThietBi;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaThietBi;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaThietBi;
        private DevExpress.XtraBars.BarButtonItem barBtnCHuyenTinhTrang;
        private DevExpress.XtraBars.BarButtonItem barBtnChuyenPhong;
        private DevExpress.XtraBars.BarButtonItem barBtnThemCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaCoSo;
        private DevExpress.XtraBars.BarButtonItem barBtnThemDay;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaDay;
        private DevExpress.XtraBars.BarButtonItem barBtnThemTang;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaTang;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaTang;
        private DevExpress.XtraBars.BarButtonItem barBtnThemNhanVien;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaNhanVien;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaNhanVien;
        private DevExpress.XtraBars.BarButtonItem barBtnPhanCong;
        private DevExpress.XtraBars.BarButtonItem barBtnThemLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barBtnSuaLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barBtnXoaLoaiTB;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageViTri_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupViTri_CoSo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupViTri_Day;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupViTri_Tang;
    }
}
