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
            this.rbnControlTaiSan = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rbnPageTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnGroupTaiSan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnThemTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSuaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoaTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.gridControlTaiSan = new DevExpress.XtraGrid.GridControl();
            this.gridViewTaiSan = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiSan)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnControlTaiSan
            // 
            this.rbnControlTaiSan.ExpandCollapseItem.Id = 0;
            this.rbnControlTaiSan.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbnControlTaiSan.ExpandCollapseItem,
            this.barBtnThemTaiSan,
            this.barBtnSuaTaiSan,
            this.barBtnXoaTaiSan});
            this.rbnControlTaiSan.Location = new System.Drawing.Point(0, 0);
            this.rbnControlTaiSan.MaxItemId = 5;
            this.rbnControlTaiSan.Name = "rbnControlTaiSan";
            this.rbnControlTaiSan.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPageTaiSan});
            this.rbnControlTaiSan.Size = new System.Drawing.Size(858, 142);
            // 
            // rbnPageTaiSan
            // 
            this.rbnPageTaiSan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnGroupTaiSan});
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
            // barBtnThemTaiSan
            // 
            this.barBtnThemTaiSan.Caption = "Thêm tài sản";
            this.barBtnThemTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.plus_2;
            this.barBtnThemTaiSan.Id = 1;
            this.barBtnThemTaiSan.Name = "barBtnThemTaiSan";
            // 
            // barBtnSuaTaiSan
            // 
            this.barBtnSuaTaiSan.Caption = "Sửa tài sản";
            this.barBtnSuaTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.pencil_edit;
            this.barBtnSuaTaiSan.Id = 2;
            this.barBtnSuaTaiSan.Name = "barBtnSuaTaiSan";
            // 
            // barBtnXoaTaiSan
            // 
            this.barBtnXoaTaiSan.Caption = "Xóa tài sản";
            this.barBtnXoaTaiSan.Glyph = global::TSCD_GUI.Properties.Resources.minus_2;
            this.barBtnXoaTaiSan.Id = 3;
            this.barBtnXoaTaiSan.Name = "barBtnXoaTaiSan";
            // 
            // gridControlTaiSan
            // 
            this.gridControlTaiSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTaiSan.Location = new System.Drawing.Point(0, 142);
            this.gridControlTaiSan.MainView = this.gridViewTaiSan;
            this.gridControlTaiSan.MenuManager = this.rbnControlTaiSan;
            this.gridControlTaiSan.Name = "gridControlTaiSan";
            this.gridControlTaiSan.Size = new System.Drawing.Size(858, 367);
            this.gridControlTaiSan.TabIndex = 1;
            this.gridControlTaiSan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTaiSan});
            // 
            // gridViewTaiSan
            // 
            this.gridViewTaiSan.GridControl = this.gridControlTaiSan;
            this.gridViewTaiSan.Name = "gridViewTaiSan";
            // 
            // ucQuanLyTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlTaiSan);
            this.Controls.Add(this.rbnControlTaiSan);
            this.Name = "ucQuanLyTaiSan";
            this.Size = new System.Drawing.Size(858, 509);
            ((System.ComponentModel.ISupportInitialize)(this.rbnControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiSan)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControlTaiSan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTaiSan;
    }
}
