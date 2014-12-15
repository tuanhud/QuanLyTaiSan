namespace TSCD_GUI.ReportTSCD
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.comboBoxEdit_LoaiBaoCao = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit_TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit_DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.checkEdit_XuatBaoCao = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit_ThietKe = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Xuat = new DevExpress.XtraEditors.SimpleButton();
            this.checkedComboBoxEdit_ChonCoSo = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.marqueeProgressBarControl_Status = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.simpleButton_Stop = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_Status = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit_Nam = new DevExpress.XtraEditors.DateEdit();
            this.ucComboBoxLoaiTS_LoaiTaiSan = new TSCD_GUI.MyUserControl.ucComboBoxLoaiTS();
            this.ucComboBoxDonVi_ChonDonVi = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            this.checkEdit_ChuaCoViTri = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_LoaiBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_XuatBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ThietKe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit_ChonCoSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl_Status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Nam.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Nam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ChuaCoViTri.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEdit_LoaiBaoCao
            // 
            this.comboBoxEdit_LoaiBaoCao.Location = new System.Drawing.Point(116, 12);
            this.comboBoxEdit_LoaiBaoCao.Name = "comboBoxEdit_LoaiBaoCao";
            this.comboBoxEdit_LoaiBaoCao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_LoaiBaoCao.Properties.Items.AddRange(new object[] {
            "Báo cáo tăng giảm tài sản cố định",
            "Sổ tài sản cố định",
            "Sổ chi tiết tài sản cố định",
            "Sổ theo dõi tài sản cố định tại nơi sử dụng"});
            this.comboBoxEdit_LoaiBaoCao.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_LoaiBaoCao.Size = new System.Drawing.Size(180, 20);
            this.comboBoxEdit_LoaiBaoCao.TabIndex = 0;
            this.comboBoxEdit_LoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_LoaiBaoCao_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Chọn loại báo cáo:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 145);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Chọn đơn vị:";
            // 
            // dateEdit_TuNgay
            // 
            this.dateEdit_TuNgay.EditValue = null;
            this.dateEdit_TuNgay.Location = new System.Drawing.Point(116, 38);
            this.dateEdit_TuNgay.Name = "dateEdit_TuNgay";
            this.dateEdit_TuNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit_TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TuNgay.Size = new System.Drawing.Size(180, 20);
            this.dateEdit_TuNgay.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Từ ngày:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Đến ngày:";
            // 
            // dateEdit_DenNgay
            // 
            this.dateEdit_DenNgay.EditValue = null;
            this.dateEdit_DenNgay.Location = new System.Drawing.Point(116, 64);
            this.dateEdit_DenNgay.Name = "dateEdit_DenNgay";
            this.dateEdit_DenNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit_DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DenNgay.Size = new System.Drawing.Size(180, 20);
            this.dateEdit_DenNgay.TabIndex = 2;
            // 
            // checkEdit_XuatBaoCao
            // 
            this.checkEdit_XuatBaoCao.EditValue = true;
            this.checkEdit_XuatBaoCao.Location = new System.Drawing.Point(114, 219);
            this.checkEdit_XuatBaoCao.Name = "checkEdit_XuatBaoCao";
            this.checkEdit_XuatBaoCao.Properties.Caption = "Xuất báo cáo";
            this.checkEdit_XuatBaoCao.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit_XuatBaoCao.Properties.RadioGroupIndex = 1;
            this.checkEdit_XuatBaoCao.Size = new System.Drawing.Size(97, 19);
            this.checkEdit_XuatBaoCao.TabIndex = 8;
            // 
            // checkEdit_ThietKe
            // 
            this.checkEdit_ThietKe.Location = new System.Drawing.Point(217, 219);
            this.checkEdit_ThietKe.Name = "checkEdit_ThietKe";
            this.checkEdit_ThietKe.Properties.Caption = "Thiết kế";
            this.checkEdit_ThietKe.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit_ThietKe.Properties.RadioGroupIndex = 1;
            this.checkEdit_ThietKe.Size = new System.Drawing.Size(79, 19);
            this.checkEdit_ThietKe.TabIndex = 9;
            this.checkEdit_ThietKe.TabStop = false;
            // 
            // simpleButton_Thoat
            // 
            this.simpleButton_Thoat.Location = new System.Drawing.Point(221, 244);
            this.simpleButton_Thoat.Name = "simpleButton_Thoat";
            this.simpleButton_Thoat.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Thoat.TabIndex = 12;
            this.simpleButton_Thoat.Text = "Thoát";
            this.simpleButton_Thoat.Click += new System.EventHandler(this.simpleButton_Thoat_Click);
            // 
            // simpleButton_Xuat
            // 
            this.simpleButton_Xuat.Location = new System.Drawing.Point(116, 244);
            this.simpleButton_Xuat.Name = "simpleButton_Xuat";
            this.simpleButton_Xuat.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Xuat.TabIndex = 10;
            this.simpleButton_Xuat.Text = "Xuất";
            this.simpleButton_Xuat.Click += new System.EventHandler(this.simpleButton_Xuat_Click);
            // 
            // checkedComboBoxEdit_ChonCoSo
            // 
            this.checkedComboBoxEdit_ChonCoSo.EditValue = "";
            this.checkedComboBoxEdit_ChonCoSo.Location = new System.Drawing.Point(116, 193);
            this.checkedComboBoxEdit_ChonCoSo.Name = "checkedComboBoxEdit_ChonCoSo";
            this.checkedComboBoxEdit_ChonCoSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit_ChonCoSo.Properties.DisplayMember = "ten";
            this.checkedComboBoxEdit_ChonCoSo.Properties.ValueMember = "id";
            this.checkedComboBoxEdit_ChonCoSo.Size = new System.Drawing.Size(180, 20);
            this.checkedComboBoxEdit_ChonCoSo.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 93);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Loại tài sản:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 196);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(31, 13);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "Cơ sở:";
            // 
            // marqueeProgressBarControl_Status
            // 
            this.marqueeProgressBarControl_Status.EditValue = 0;
            this.marqueeProgressBarControl_Status.Location = new System.Drawing.Point(12, 302);
            this.marqueeProgressBarControl_Status.Name = "marqueeProgressBarControl_Status";
            this.marqueeProgressBarControl_Status.Properties.MarqueeAnimationSpeed = 200;
            this.marqueeProgressBarControl_Status.Size = new System.Drawing.Size(246, 12);
            this.marqueeProgressBarControl_Status.TabIndex = 10;
            this.marqueeProgressBarControl_Status.Visible = false;
            // 
            // simpleButton_Stop
            // 
            this.simpleButton_Stop.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.simpleButton_Stop.Appearance.Options.UseBackColor = true;
            this.simpleButton_Stop.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Stop.Image")));
            this.simpleButton_Stop.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton_Stop.Location = new System.Drawing.Point(264, 292);
            this.simpleButton_Stop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.simpleButton_Stop.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton_Stop.Name = "simpleButton_Stop";
            this.simpleButton_Stop.Size = new System.Drawing.Size(32, 32);
            this.simpleButton_Stop.TabIndex = 11;
            this.simpleButton_Stop.Visible = false;
            this.simpleButton_Stop.Click += new System.EventHandler(this.simpleButton_Stop_Click);
            // 
            // labelControl_Status
            // 
            this.labelControl_Status.Location = new System.Drawing.Point(12, 273);
            this.labelControl_Status.Name = "labelControl_Status";
            this.labelControl_Status.Size = new System.Drawing.Size(31, 13);
            this.labelControl_Status.TabIndex = 20;
            this.labelControl_Status.Text = "Status";
            this.labelControl_Status.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 119);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(25, 13);
            this.labelControl7.TabIndex = 17;
            this.labelControl7.Text = "Năm:";
            // 
            // dateEdit_Nam
            // 
            this.dateEdit_Nam.EditValue = null;
            this.dateEdit_Nam.Location = new System.Drawing.Point(116, 116);
            this.dateEdit_Nam.Name = "dateEdit_Nam";
            this.dateEdit_Nam.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit_Nam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_Nam.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_Nam.Properties.DisplayFormat.FormatString = "yyyy";
            this.dateEdit_Nam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_Nam.Properties.EditFormat.FormatString = "yyyy";
            this.dateEdit_Nam.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_Nam.Properties.Mask.EditMask = "yyyy";
            this.dateEdit_Nam.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView | DevExpress.XtraEditors.VistaCalendarViewStyle.CenturyView)));
            this.dateEdit_Nam.Size = new System.Drawing.Size(180, 20);
            this.dateEdit_Nam.TabIndex = 4;
            // 
            // ucComboBoxLoaiTS_LoaiTaiSan
            // 
            this.ucComboBoxLoaiTS_LoaiTaiSan.EditValue = null;
            this.ucComboBoxLoaiTS_LoaiTaiSan.LoaiTS = null;
            this.ucComboBoxLoaiTS_LoaiTaiSan.Location = new System.Drawing.Point(116, 90);
            this.ucComboBoxLoaiTS_LoaiTaiSan.Name = "ucComboBoxLoaiTS_LoaiTaiSan";
            this.ucComboBoxLoaiTS_LoaiTaiSan.Size = new System.Drawing.Size(180, 20);
            this.ucComboBoxLoaiTS_LoaiTaiSan.TabIndex = 3;
            // 
            // ucComboBoxDonVi_ChonDonVi
            // 
            this.ucComboBoxDonVi_ChonDonVi.DonVi = null;
            this.ucComboBoxDonVi_ChonDonVi.EditValue = null;
            this.ucComboBoxDonVi_ChonDonVi.Location = new System.Drawing.Point(116, 142);
            this.ucComboBoxDonVi_ChonDonVi.Name = "ucComboBoxDonVi_ChonDonVi";
            this.ucComboBoxDonVi_ChonDonVi.Size = new System.Drawing.Size(180, 20);
            this.ucComboBoxDonVi_ChonDonVi.TabIndex = 5;
            // 
            // checkEdit_ChuaCoViTri
            // 
            this.checkEdit_ChuaCoViTri.Location = new System.Drawing.Point(114, 168);
            this.checkEdit_ChuaCoViTri.Name = "checkEdit_ChuaCoViTri";
            this.checkEdit_ChuaCoViTri.Properties.Caption = "Chưa có vị trí";
            this.checkEdit_ChuaCoViTri.Size = new System.Drawing.Size(97, 19);
            this.checkEdit_ChuaCoViTri.TabIndex = 6;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(308, 336);
            this.Controls.Add(this.checkEdit_ChuaCoViTri);
            this.Controls.Add(this.labelControl_Status);
            this.Controls.Add(this.marqueeProgressBarControl_Status);
            this.Controls.Add(this.checkedComboBoxEdit_ChonCoSo);
            this.Controls.Add(this.ucComboBoxLoaiTS_LoaiTaiSan);
            this.Controls.Add(this.simpleButton_Xuat);
            this.Controls.Add(this.simpleButton_Stop);
            this.Controls.Add(this.simpleButton_Thoat);
            this.Controls.Add(this.checkEdit_ThietKe);
            this.Controls.Add(this.checkEdit_XuatBaoCao);
            this.Controls.Add(this.dateEdit_Nam);
            this.Controls.Add(this.dateEdit_DenNgay);
            this.Controls.Add(this.dateEdit_TuNgay);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.ucComboBoxDonVi_ChonDonVi);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comboBoxEdit_LoaiBaoCao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất báo cáo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReport_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReport_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_LoaiBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_XuatBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ThietKe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit_ChonCoSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl_Status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Nam.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Nam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ChuaCoViTri.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_LoaiBaoCao;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private MyUserControl.ucComboBoxDonVi ucComboBoxDonVi_ChonDonVi;
        private DevExpress.XtraEditors.DateEdit dateEdit_TuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dateEdit_DenNgay;
        private DevExpress.XtraEditors.CheckEdit checkEdit_XuatBaoCao;
        private DevExpress.XtraEditors.CheckEdit checkEdit_ThietKe;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Thoat;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Xuat;
        private MyUserControl.ucComboBoxLoaiTS ucComboBoxLoaiTS_LoaiTaiSan;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit_ChonCoSo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl_Status;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Stop;
        private DevExpress.XtraEditors.LabelControl labelControl_Status;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DateEdit dateEdit_Nam;
        private DevExpress.XtraEditors.CheckEdit checkEdit_ChuaCoViTri;
    }
}