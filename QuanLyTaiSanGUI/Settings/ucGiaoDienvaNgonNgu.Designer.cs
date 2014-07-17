namespace QuanLyTaiSanGUI.Settings
{
    partial class ucGiaoDienvaNgonNgu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGiaoDienvaNgonNgu));
            this.comboBoxEditNgonNgu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.galleryControlGiaoDien = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonLuuGiaoDien = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonHuyGiaoDien = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNgonNgu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlGiaoDien)).BeginInit();
            this.galleryControlGiaoDien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxEditNgonNgu
            // 
            this.comboBoxEditNgonNgu.EditValue = "Tiếng việt";
            this.comboBoxEditNgonNgu.Location = new System.Drawing.Point(124, 41);
            this.comboBoxEditNgonNgu.Name = "comboBoxEditNgonNgu";
            this.comboBoxEditNgonNgu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditNgonNgu.Size = new System.Drawing.Size(150, 20);
            this.comboBoxEditNgonNgu.TabIndex = 0;
            // 
            // galleryControlGiaoDien
            // 
            this.galleryControlGiaoDien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.galleryControlGiaoDien.Controls.Add(this.galleryControlClient1);
            this.galleryControlGiaoDien.DesignGalleryGroupIndex = 0;
            this.galleryControlGiaoDien.DesignGalleryItemIndex = 0;
            // 
            // galleryControlGallery1
            // 
            this.galleryControlGiaoDien.Gallery.ImageSize = new System.Drawing.Size(200, 200);
            this.galleryControlGiaoDien.Gallery.ShowItemText = true;
            this.galleryControlGiaoDien.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControlGallery1_ItemClick);
            this.galleryControlGiaoDien.Location = new System.Drawing.Point(2, 55);
            this.galleryControlGiaoDien.Name = "galleryControlGiaoDien";
            this.galleryControlGiaoDien.Size = new System.Drawing.Size(705, 240);
            this.galleryControlGiaoDien.TabIndex = 0;
            this.galleryControlGiaoDien.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControlGiaoDien;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(684, 236);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.comboBoxEditNgonNgu);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(711, 79);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Ngôn ngữ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chọn ngôn ngữ";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImage")));
            this.groupControl2.Controls.Add(this.simpleButtonLuuGiaoDien);
            this.groupControl2.Controls.Add(this.simpleButtonHuyGiaoDien);
            this.groupControl2.Controls.Add(this.galleryControlGiaoDien);
            this.groupControl2.Location = new System.Drawing.Point(3, 85);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(711, 298);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Giao diện";
            // 
            // simpleButtonLuuGiaoDien
            // 
            this.simpleButtonLuuGiaoDien.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonLuuGiaoDien.Image")));
            this.simpleButtonLuuGiaoDien.Location = new System.Drawing.Point(6, 28);
            this.simpleButtonLuuGiaoDien.Name = "simpleButtonLuuGiaoDien";
            this.simpleButtonLuuGiaoDien.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonLuuGiaoDien.TabIndex = 2;
            this.simpleButtonLuuGiaoDien.Text = "Lưu";
            this.simpleButtonLuuGiaoDien.Click += new System.EventHandler(this.simpleButtonLuuGiaoDien_Click);
            // 
            // simpleButtonHuyGiaoDien
            // 
            this.simpleButtonHuyGiaoDien.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonHuyGiaoDien.Image")));
            this.simpleButtonHuyGiaoDien.Location = new System.Drawing.Point(89, 28);
            this.simpleButtonHuyGiaoDien.Name = "simpleButtonHuyGiaoDien";
            this.simpleButtonHuyGiaoDien.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonHuyGiaoDien.TabIndex = 2;
            this.simpleButtonHuyGiaoDien.Text = "Hủy";
            this.simpleButtonHuyGiaoDien.Click += new System.EventHandler(this.simpleButtonHuyGiaoDien_Click);
            // 
            // ucGiaoDienvaNgonNgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.MinimumSize = new System.Drawing.Size(717, 381);
            this.Name = "ucGiaoDienvaNgonNgu";
            this.Size = new System.Drawing.Size(717, 383);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNgonNgu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlGiaoDien)).EndInit();
            this.galleryControlGiaoDien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditNgonNgu;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControlGiaoDien;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLuuGiaoDien;
        private DevExpress.XtraEditors.SimpleButton simpleButtonHuyGiaoDien;
    }
}
