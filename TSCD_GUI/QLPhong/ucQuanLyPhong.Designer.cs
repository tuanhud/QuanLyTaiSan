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
            this.rbnControlPhong = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rbnPagePhong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupPhong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navBarControlLeft = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupViTri = new DevExpress.XtraNavBar.NavBarGroup();
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.gridControlPhong = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barBtnThemPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaPhong = new DevExpress.XtraBars.BarButtonItem();
            this.navBarGroupControlContainerViTri = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.btnXoa_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua_r = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem_r = new DevExpress.XtraEditors.SimpleButton();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.gridLookUpLoai = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpLoaiView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoaiPhong = new DevExpress.XtraEditors.SimpleButton();
            this.rbnGroupLoaiPhong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnLoaiPhong = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlLeft)).BeginInit();
            this.navBarControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoaiView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
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
            this.barBtnLoaiPhong});
            this.rbnControlPhong.Location = new System.Drawing.Point(0, 0);
            this.rbnControlPhong.MaxItemId = 5;
            this.rbnControlPhong.Name = "rbnControlPhong";
            this.rbnControlPhong.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPagePhong});
            this.rbnControlPhong.Size = new System.Drawing.Size(857, 142);
            // 
            // rbnPagePhong
            // 
            this.rbnPagePhong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupPhong,
            this.rbnGroupLoaiPhong});
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
            // navBarControlLeft
            // 
            this.navBarControlLeft.ActiveGroup = this.navBarGroupViTri;
            this.navBarControlLeft.Controls.Add(this.navBarGroupControlContainerViTri);
            this.navBarControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControlLeft.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupViTri});
            this.navBarControlLeft.Location = new System.Drawing.Point(0, 142);
            this.navBarControlLeft.Name = "navBarControlLeft";
            this.navBarControlLeft.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControlLeft.Size = new System.Drawing.Size(210, 379);
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
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(210, 142);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlPhong);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlInfo);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(647, 379);
            this.splitContainerControlMain.SplitterPosition = 254;
            this.splitContainerControlMain.TabIndex = 2;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlInfo.AppearanceCaption.Options.UseFont = true;
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
            this.groupControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlInfo.Location = new System.Drawing.Point(0, 0);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(254, 379);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Chi tiết";
            // 
            // gridControlPhong
            // 
            this.gridControlPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPhong.Location = new System.Drawing.Point(0, 0);
            this.gridControlPhong.MainView = this.gridViewPhong;
            this.gridControlPhong.MenuManager = this.rbnControlPhong;
            this.gridControlPhong.Name = "gridControlPhong";
            this.gridControlPhong.Size = new System.Drawing.Size(388, 379);
            this.gridControlPhong.TabIndex = 0;
            this.gridControlPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhong});
            // 
            // gridViewPhong
            // 
            this.gridViewPhong.GridControl = this.gridControlPhong;
            this.gridViewPhong.Name = "gridViewPhong";
            // 
            // barBtnThemPhong
            // 
            this.barBtnThemPhong.Caption = "Thêm phòng";
            this.barBtnThemPhong.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemPhong.Id = 1;
            this.barBtnThemPhong.Name = "barBtnThemPhong";
            // 
            // barBtnSuaPhong
            // 
            this.barBtnSuaPhong.Caption = "Sửa phòng";
            this.barBtnSuaPhong.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaPhong.Id = 2;
            this.barBtnSuaPhong.Name = "barBtnSuaPhong";
            // 
            // barBtnXoaPhong
            // 
            this.barBtnXoaPhong.Caption = "Xóa phòng";
            this.barBtnXoaPhong.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaPhong.Id = 3;
            this.barBtnXoaPhong.Name = "barBtnXoaPhong";
            // 
            // navBarGroupControlContainerViTri
            // 
            this.navBarGroupControlContainerViTri.Name = "navBarGroupControlContainerViTri";
            this.navBarGroupControlContainerViTri.Size = new System.Drawing.Size(210, 276);
            this.navBarGroupControlContainerViTri.TabIndex = 0;
            // 
            // btnXoa_r
            // 
            this.btnXoa_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa_r.Image = global::TSCD_GUI.Properties.Resources.minus_2_24;
            this.btnXoa_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa_r.Location = new System.Drawing.Point(215, 0);
            this.btnXoa_r.Name = "btnXoa_r";
            this.btnXoa_r.Size = new System.Drawing.Size(23, 23);
            this.btnXoa_r.TabIndex = 5;
            // 
            // btnSua_r
            // 
            this.btnSua_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua_r.Image = global::TSCD_GUI.Properties.Resources.pencil_edit_24;
            this.btnSua_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSua_r.Location = new System.Drawing.Point(189, 0);
            this.btnSua_r.Name = "btnSua_r";
            this.btnSua_r.Size = new System.Drawing.Size(23, 23);
            this.btnSua_r.TabIndex = 4;
            // 
            // btnThem_r
            // 
            this.btnThem_r.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem_r.Image = global::TSCD_GUI.Properties.Resources.plus_2_24;
            this.btnThem_r.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem_r.Location = new System.Drawing.Point(163, 0);
            this.btnThem_r.Name = "btnThem_r";
            this.btnThem_r.Size = new System.Drawing.Size(23, 23);
            this.btnThem_r.TabIndex = 3;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(68, 29);
            this.txtTen.MenuManager = this.rbnControlPhong;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(170, 20);
            this.txtTen.TabIndex = 6;
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
            this.gridLookUpLoai.Properties.View = this.gridLookUpLoaiView;
            this.gridLookUpLoai.Size = new System.Drawing.Size(118, 20);
            this.gridLookUpLoai.TabIndex = 8;
            // 
            // gridLookUpLoaiView
            // 
            this.gridLookUpLoaiView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpLoaiView.Name = "gridLookUpLoaiView";
            this.gridLookUpLoaiView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpLoaiView.OptionsView.ShowGroupPanel = false;
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(5, 32);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(55, 13);
            this.lblTen.TabIndex = 9;
            this.lblTen.Text = "Tên phòng:";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.Location = new System.Drawing.Point(5, 59);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(56, 13);
            this.lblLoaiPhong.TabIndex = 10;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(5, 85);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(31, 13);
            this.lblMoTa.TabIndex = 11;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(68, 82);
            this.txtMoTa.MenuManager = this.rbnControlPhong;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(170, 20);
            this.txtMoTa.TabIndex = 7;
            this.txtMoTa.UseOptimizedRendering = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(55, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(137, 108);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            // 
            // btnLoaiPhong
            // 
            this.btnLoaiPhong.Location = new System.Drawing.Point(192, 54);
            this.btnLoaiPhong.Name = "btnLoaiPhong";
            this.btnLoaiPhong.Size = new System.Drawing.Size(46, 23);
            this.btnLoaiPhong.TabIndex = 14;
            this.btnLoaiPhong.Text = "+";
            // 
            // rbnGroupLoaiPhong
            // 
            this.rbnGroupLoaiPhong.ItemLinks.Add(this.barBtnLoaiPhong);
            this.rbnGroupLoaiPhong.Name = "rbnGroupLoaiPhong";
            this.rbnGroupLoaiPhong.ShowCaptionButton = false;
            this.rbnGroupLoaiPhong.Text = "Loại phòng";
            // 
            // barBtnLoaiPhong
            // 
            this.barBtnLoaiPhong.Caption = "Loại phòng";
            this.barBtnLoaiPhong.Id = 4;
            this.barBtnLoaiPhong.Name = "barBtnLoaiPhong";
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpLoaiView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
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
    }
}
