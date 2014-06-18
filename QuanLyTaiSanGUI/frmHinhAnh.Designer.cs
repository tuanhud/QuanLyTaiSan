namespace QuanLyTaiSanGUI
{
    partial class frmHinhAnh
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
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHinhAnh));
            this.galleryControl1 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.btnImageCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnImageSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnImageUpload = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).BeginInit();
            this.galleryControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // galleryControl1
            // 
            this.galleryControl1.Controls.Add(this.galleryControlClient1);
            this.galleryControl1.DesignGalleryGroupIndex = 0;
            this.galleryControl1.DesignGalleryItemIndex = 0;
            // 
            // galleryControlGallery1
            // 
            galleryItemGroup1.Caption = "Danh sách hình ảnh";
            this.galleryControl1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.galleryControl1.Gallery.ImageSize = new System.Drawing.Size(100, 100);
            this.galleryControl1.Location = new System.Drawing.Point(0, 0);
            this.galleryControl1.Name = "galleryControl1";
            this.galleryControl1.Size = new System.Drawing.Size(585, 228);
            this.galleryControl1.TabIndex = 0;
            this.galleryControl1.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControl1;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(564, 224);
            // 
            // btnImageCancel
            // 
            this.btnImageCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnImageCancel.Image")));
            this.btnImageCancel.Location = new System.Drawing.Point(497, 234);
            this.btnImageCancel.Name = "btnImageCancel";
            this.btnImageCancel.Size = new System.Drawing.Size(75, 23);
            this.btnImageCancel.TabIndex = 1;
            this.btnImageCancel.Text = "Hủy bỏ";
            // 
            // btnImageSave
            // 
            this.btnImageSave.Image = ((System.Drawing.Image)(resources.GetObject("btnImageSave.Image")));
            this.btnImageSave.Location = new System.Drawing.Point(416, 234);
            this.btnImageSave.Name = "btnImageSave";
            this.btnImageSave.Size = new System.Drawing.Size(75, 23);
            this.btnImageSave.TabIndex = 2;
            this.btnImageSave.Text = "Lưu lại";
            // 
            // btnImageUpload
            // 
            this.btnImageUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnImageUpload.Image")));
            this.btnImageUpload.Location = new System.Drawing.Point(335, 234);
            this.btnImageUpload.Name = "btnImageUpload";
            this.btnImageUpload.Size = new System.Drawing.Size(75, 23);
            this.btnImageUpload.TabIndex = 3;
            this.btnImageUpload.Text = "Tải lên";
            // 
            // frmHinhAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.btnImageUpload);
            this.Controls.Add(this.btnImageSave);
            this.Controls.Add(this.btnImageCancel);
            this.Controls.Add(this.galleryControl1);
            this.Name = "frmHinhAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hình ảnh";
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).EndInit();
            this.galleryControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraEditors.SimpleButton btnImageCancel;
        private DevExpress.XtraEditors.SimpleButton btnImageSave;
        private DevExpress.XtraEditors.SimpleButton btnImageUpload;
    }
}