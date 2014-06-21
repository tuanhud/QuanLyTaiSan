namespace QuanLyTaiSanGUI
{
    partial class frmThuVienHinhAnh
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuVienHinhAnh));
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnImageCancel = new DevExpress.XtraEditors.SimpleButton();
            this.galleryControlImage = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlImage)).BeginInit();
            this.galleryControlImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelControl1.Location = new System.Drawing.Point(12, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(155, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Chọn hình ảnh cần thêm";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(426, 293);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            // 
            // btnImageCancel
            // 
            this.btnImageCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnImageCancel.Image")));
            this.btnImageCancel.Location = new System.Drawing.Point(507, 293);
            this.btnImageCancel.Name = "btnImageCancel";
            this.btnImageCancel.Size = new System.Drawing.Size(75, 23);
            this.btnImageCancel.TabIndex = 7;
            this.btnImageCancel.Text = "Đóng";
            // 
            // galleryControlImage
            // 
            this.galleryControlImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.galleryControlImage.Controls.Add(this.galleryControlClient1);
            this.galleryControlImage.DesignGalleryGroupIndex = 0;
            this.galleryControlImage.DesignGalleryItemIndex = 0;
            // 
            // galleryControlGallery1
            // 
            this.galleryControlImage.Gallery.AllowHoverImages = true;
            this.galleryControlImage.Gallery.AllowMarqueeSelection = true;
            galleryItemGroup1.Caption = "Danh sách hình ảnh trong thư viện";
            this.galleryControlImage.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.galleryControlImage.Gallery.HoverImageSize = new System.Drawing.Size(200, 200);
            this.galleryControlImage.Gallery.ImageSize = new System.Drawing.Size(100, 100);
            this.galleryControlImage.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.Multiple;
            this.galleryControlImage.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.galleryControlImage.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.galleryControlImage.Gallery.ShowItemText = true;
            this.galleryControlImage.Location = new System.Drawing.Point(2, 28);
            this.galleryControlImage.Name = "galleryControlImage";
            this.galleryControlImage.Size = new System.Drawing.Size(580, 259);
            this.galleryControlImage.TabIndex = 9;
            this.galleryControlImage.Text = "galleryControlImage";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControlImage;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(559, 255);
            // 
            // frmThuVienHinhAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 323);
            this.Controls.Add(this.galleryControlImage);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnImageCancel);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmThuVienHinhAnh";
            this.Text = "Thư viện hình ảnh";
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlImage)).EndInit();
            this.galleryControlImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnImageCancel;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControlImage;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}