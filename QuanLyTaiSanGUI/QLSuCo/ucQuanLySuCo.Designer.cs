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
            this.ribbonSuCoPhong = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnThem = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSua = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPageSuCoPhong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupSuCo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlSuCo = new DevExpress.XtraGrid.GridControl();
            this.gridViewSuCo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonSuCoPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSuCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSuCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonSuCoPhong
            // 
            this.ribbonSuCoPhong.ExpandCollapseItem.Id = 0;
            this.ribbonSuCoPhong.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonSuCoPhong.ExpandCollapseItem,
            this.barBtnThem,
            this.barBtnSua,
            this.barBtnXoa});
            this.ribbonSuCoPhong.Location = new System.Drawing.Point(0, 0);
            this.ribbonSuCoPhong.MaxItemId = 4;
            this.ribbonSuCoPhong.Name = "ribbonSuCoPhong";
            this.ribbonSuCoPhong.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageSuCoPhong});
            this.ribbonSuCoPhong.Size = new System.Drawing.Size(813, 145);
            // 
            // barBtnThem
            // 
            this.barBtnThem.Caption = "Thêm sự cố";
            this.barBtnThem.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.plus_2;
            this.barBtnThem.Id = 1;
            this.barBtnThem.Name = "barBtnThem";
            // 
            // barBtnSua
            // 
            this.barBtnSua.Caption = "Sửa sự cố";
            this.barBtnSua.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.pencil_edit;
            this.barBtnSua.Id = 2;
            this.barBtnSua.Name = "barBtnSua";
            // 
            // barBtnXoa
            // 
            this.barBtnXoa.Caption = "Xóa sự cố";
            this.barBtnXoa.Glyph = global::QuanLyTaiSanGUI.Properties.Resources.minus_2;
            this.barBtnXoa.Id = 3;
            this.barBtnXoa.Name = "barBtnXoa";
            // 
            // rbnPageSuCoPhong
            // 
            this.rbnPageSuCoPhong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupSuCo});
            this.rbnPageSuCoPhong.Image = global::QuanLyTaiSanGUI.Properties.Resources.warning;
            this.rbnPageSuCoPhong.Name = "rbnPageSuCoPhong";
            this.rbnPageSuCoPhong.Text = "Sự cố";
            // 
            // rbnGroupSuCo
            // 
            this.rbnGroupSuCo.ItemLinks.Add(this.barBtnThem);
            this.rbnGroupSuCo.ItemLinks.Add(this.barBtnSua);
            this.rbnGroupSuCo.ItemLinks.Add(this.barBtnXoa);
            this.rbnGroupSuCo.Name = "rbnGroupSuCo";
            this.rbnGroupSuCo.Text = "Sự cố";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 145);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlSuCo);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(813, 417);
            this.splitContainerControl1.SplitterPosition = 291;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlSuCo
            // 
            this.gridControlSuCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSuCo.Location = new System.Drawing.Point(0, 0);
            this.gridControlSuCo.MainView = this.gridViewSuCo;
            this.gridControlSuCo.MenuManager = this.ribbonSuCoPhong;
            this.gridControlSuCo.Name = "gridControlSuCo";
            this.gridControlSuCo.Size = new System.Drawing.Size(517, 417);
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
            this.groupControl1.Size = new System.Drawing.Size(291, 417);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // ucQuanLySuCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonSuCoPhong);
            this.Name = "ucQuanLySuCo";
            this.Size = new System.Drawing.Size(813, 562);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonSuCoPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSuCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSuCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonSuCoPhong;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageSuCoPhong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnGroupSuCo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlSuCo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSuCo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem barBtnThem;
        private DevExpress.XtraBars.BarButtonItem barBtnSua;
        private DevExpress.XtraBars.BarButtonItem barBtnXoa;
    }
}
