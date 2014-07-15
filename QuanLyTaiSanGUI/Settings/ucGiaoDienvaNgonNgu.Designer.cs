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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxEditNgonNgu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.galleryControlGiaoDien = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNgonNgu.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlGiaoDien)).BeginInit();
            this.galleryControlGiaoDien.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxEditNgonNgu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ngôn ngữ";
            // 
            // comboBoxEditNgonNgu
            // 
            this.comboBoxEditNgonNgu.Location = new System.Drawing.Point(35, 19);
            this.comboBoxEditNgonNgu.Name = "comboBoxEditNgonNgu";
            this.comboBoxEditNgonNgu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditNgonNgu.Properties.Items.AddRange(new object[] {
            "Tiếng việt",
            "Tiếng anh",
            "Tiếng pháp"});
            this.comboBoxEditNgonNgu.Size = new System.Drawing.Size(150, 20);
            this.comboBoxEditNgonNgu.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.galleryControlGiaoDien);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(0, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 312);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giao diện";
            // 
            // galleryControlGiaoDien
            // 
            this.galleryControlGiaoDien.Controls.Add(this.galleryControlClient1);
            this.galleryControlGiaoDien.DesignGalleryGroupIndex = 0;
            this.galleryControlGiaoDien.DesignGalleryItemIndex = 0;
            this.galleryControlGiaoDien.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // galleryControlGallery1
            // 
            this.galleryControlGiaoDien.Gallery.ImageSize = new System.Drawing.Size(150, 150);
            this.galleryControlGiaoDien.Location = new System.Drawing.Point(3, 16);
            this.galleryControlGiaoDien.Name = "galleryControlGiaoDien";
            this.galleryControlGiaoDien.Size = new System.Drawing.Size(708, 293);
            this.galleryControlGiaoDien.TabIndex = 0;
            this.galleryControlGiaoDien.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControlGiaoDien;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(687, 289);
            // 
            // ucGiaoDienvaNgonNgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(717, 381);
            this.Name = "ucGiaoDienvaNgonNgu";
            this.Size = new System.Drawing.Size(717, 381);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNgonNgu.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.galleryControlGiaoDien)).EndInit();
            this.galleryControlGiaoDien.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditNgonNgu;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControlGiaoDien;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}
