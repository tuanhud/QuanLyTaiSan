namespace QuanLyTaiSanGUI.QLPhong
{
    partial class frmChuyen
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
            this.components = new System.ComponentModel.Container();
            this.txtSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.radioBtnChuyenPhong = new System.Windows.Forms.RadioButton();
            this.radioBtnChuyenTinhTrang = new System.Windows.Forms.RadioButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.lblTinhTrang = new DevExpress.XtraEditors.LabelControl();
            this.lblPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblMa = new DevExpress.XtraEditors.LabelControl();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblLoai = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpTinhTrang = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.btnImage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTinhTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoLuong.Location = new System.Drawing.Point(67, 76);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSoLuong.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtSoLuong.Properties.Mask.EditMask = "N00";
            this.txtSoLuong.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoLuong.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoLuong.Size = new System.Drawing.Size(232, 20);
            this.txtSoLuong.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Mã thiết bị:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Tên thiết bị:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 80);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Loại thiết bị:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 132);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Tình trạng:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 158);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Số lượng:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 53);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(30, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Phòng";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 106);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(34, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Phòng:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 80);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(42, 13);
            this.labelControl9.TabIndex = 18;
            this.labelControl9.Text = "Số lượng";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 106);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(49, 13);
            this.labelControl8.TabIndex = 17;
            this.labelControl8.Text = "Tình trạng";
            // 
            // radioBtnChuyenPhong
            // 
            this.radioBtnChuyenPhong.AutoSize = true;
            this.radioBtnChuyenPhong.Location = new System.Drawing.Point(146, 25);
            this.radioBtnChuyenPhong.Name = "radioBtnChuyenPhong";
            this.radioBtnChuyenPhong.Size = new System.Drawing.Size(95, 17);
            this.radioBtnChuyenPhong.TabIndex = 17;
            this.radioBtnChuyenPhong.Text = "Chuyển phòng";
            this.radioBtnChuyenPhong.UseVisualStyleBackColor = true;
            this.radioBtnChuyenPhong.CheckedChanged += new System.EventHandler(this.radioBtnChuyenPhong_CheckedChanged);
            // 
            // radioBtnChuyenTinhTrang
            // 
            this.radioBtnChuyenTinhTrang.AutoSize = true;
            this.radioBtnChuyenTinhTrang.Checked = true;
            this.radioBtnChuyenTinhTrang.Location = new System.Drawing.Point(12, 25);
            this.radioBtnChuyenTinhTrang.Name = "radioBtnChuyenTinhTrang";
            this.radioBtnChuyenTinhTrang.Size = new System.Drawing.Size(112, 17);
            this.radioBtnChuyenTinhTrang.TabIndex = 18;
            this.radioBtnChuyenTinhTrang.TabStop = true;
            this.radioBtnChuyenTinhTrang.Text = "Chuyển tình trạng";
            this.radioBtnChuyenTinhTrang.UseVisualStyleBackColor = true;
            this.radioBtnChuyenTinhTrang.CheckedChanged += new System.EventHandler(this.radioBtnChuyenTinhTrang_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(143, 207);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(224, 207);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 20;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(12, 132);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(35, 13);
            this.labelControl10.TabIndex = 16;
            this.labelControl10.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(67, 129);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(232, 72);
            this.txtGhiChu.TabIndex = 17;
            this.txtGhiChu.UseOptimizedRendering = true;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.lblSoLuong);
            this.groupControl1.Controls.Add(this.lblTinhTrang);
            this.groupControl1.Controls.Add(this.lblPhong);
            this.groupControl1.Controls.Add(this.lblMa);
            this.groupControl1.Controls.Add(this.lblTen);
            this.groupControl1.Controls.Add(this.lblLoai);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(434, 182);
            this.groupControl1.TabIndex = 21;
            this.groupControl1.Text = "Thông tin thiết bị";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(77, 158);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(51, 13);
            this.lblSoLuong.TabIndex = 19;
            this.lblSoLuong.Text = "lblSoLuong";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Location = new System.Drawing.Point(77, 132);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(58, 13);
            this.lblTinhTrang.TabIndex = 18;
            this.lblTinhTrang.Text = "lblTinhTrang";
            // 
            // lblPhong
            // 
            this.lblPhong.Location = new System.Drawing.Point(77, 106);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(40, 13);
            this.lblPhong.TabIndex = 17;
            this.lblPhong.Text = "lblPhong";
            // 
            // lblMa
            // 
            this.lblMa.Location = new System.Drawing.Point(77, 28);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(24, 13);
            this.lblMa.TabIndex = 16;
            this.lblMa.Text = "lblMa";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(77, 54);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(28, 13);
            this.lblTen.TabIndex = 15;
            this.lblTen.Text = "lblTen";
            // 
            // lblLoai
            // 
            this.lblLoai.Location = new System.Drawing.Point(77, 80);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(29, 13);
            this.lblLoai.TabIndex = 14;
            this.lblLoai.Text = "lblLoai";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.btnImage);
            this.groupControl2.Controls.Add(this.imageSlider1);
            this.groupControl2.Controls.Add(this.lookUpTinhTrang);
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.radioBtnChuyenTinhTrang);
            this.groupControl2.Controls.Add(this.btnHuy);
            this.groupControl2.Controls.Add(this.radioBtnChuyenPhong);
            this.groupControl2.Controls.Add(this.btnOK);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Controls.Add(this.txtGhiChu);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.txtSoLuong);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 182);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(434, 238);
            this.groupControl2.TabIndex = 22;
            this.groupControl2.Text = "Chuyển tình trạng";
            // 
            // lookUpTinhTrang
            // 
            this.lookUpTinhTrang.Location = new System.Drawing.Point(67, 103);
            this.lookUpTinhTrang.Name = "lookUpTinhTrang";
            this.lookUpTinhTrang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpTinhTrang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("value", "Tình trạng")});
            this.lookUpTinhTrang.Properties.DisplayMember = "value";
            this.lookUpTinhTrang.Properties.NullText = "";
            this.lookUpTinhTrang.Properties.ValueMember = "id";
            this.lookUpTinhTrang.Size = new System.Drawing.Size(232, 20);
            this.lookUpTinhTrang.TabIndex = 22;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Location = new System.Drawing.Point(67, 50);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(232, 20);
            this.panelControl1.TabIndex = 21;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // imageSlider1
            // 
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.imageSlider1.Location = new System.Drawing.Point(305, 50);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(120, 120);
            this.imageSlider1.TabIndex = 23;
            this.imageSlider1.Text = "imageSlider1";
            this.imageSlider1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageSlider1_MouseDoubleClick);
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(305, 176);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 24;
            this.btnImage.Text = "Chọn ảnh";
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // frmChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 420);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển thiết bị";
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTinhTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit txtSoLuong;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.RadioButton radioBtnChuyenPhong;
        private System.Windows.Forms.RadioButton radioBtnChuyenTinhTrang;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.LabelControl lblTinhTrang;
        private DevExpress.XtraEditors.LabelControl lblPhong;
        private DevExpress.XtraEditors.LabelControl lblMa;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.LabelControl lblLoai;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpTinhTrang;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.SimpleButton btnImage;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
    }
}