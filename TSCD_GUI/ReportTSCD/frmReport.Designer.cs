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
            this.ucComboBoxDonVi_ChonDonVi = new TSCD_GUI.MyUserControl.ucComboBoxDonVi();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_LoaiBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_XuatBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ThietKe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEdit_LoaiBaoCao
            // 
            this.comboBoxEdit_LoaiBaoCao.EditValue = "Báo cáo tăng giảm tài sản cố định";
            this.comboBoxEdit_LoaiBaoCao.Location = new System.Drawing.Point(104, 12);
            this.comboBoxEdit_LoaiBaoCao.Name = "comboBoxEdit_LoaiBaoCao";
            this.comboBoxEdit_LoaiBaoCao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_LoaiBaoCao.Properties.Items.AddRange(new object[] {
            "Báo cáo tăng giảm tài sản cố định",
            "Sổ tài sản cố định",
            "Sổ chi tiết tài sản cố định",
            "Sổ theo dõi tài sản cố định tại nơi sử dụng"});
            this.comboBoxEdit_LoaiBaoCao.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_LoaiBaoCao.Size = new System.Drawing.Size(192, 20);
            this.comboBoxEdit_LoaiBaoCao.TabIndex = 0;
            this.comboBoxEdit_LoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_LoaiBaoCao_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chọn loại báo cáo";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Chọn đơn vị";
            // 
            // dateEdit_TuNgay
            // 
            this.dateEdit_TuNgay.EditValue = null;
            this.dateEdit_TuNgay.Location = new System.Drawing.Point(104, 64);
            this.dateEdit_TuNgay.Name = "dateEdit_TuNgay";
            this.dateEdit_TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TuNgay.Size = new System.Drawing.Size(192, 20);
            this.dateEdit_TuNgay.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Từ ngày";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Đến ngày";
            // 
            // dateEdit_DenNgay
            // 
            this.dateEdit_DenNgay.EditValue = null;
            this.dateEdit_DenNgay.Location = new System.Drawing.Point(104, 90);
            this.dateEdit_DenNgay.Name = "dateEdit_DenNgay";
            this.dateEdit_DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DenNgay.Size = new System.Drawing.Size(192, 20);
            this.dateEdit_DenNgay.TabIndex = 3;
            // 
            // checkEdit_XuatBaoCao
            // 
            this.checkEdit_XuatBaoCao.EditValue = true;
            this.checkEdit_XuatBaoCao.Location = new System.Drawing.Point(102, 116);
            this.checkEdit_XuatBaoCao.Name = "checkEdit_XuatBaoCao";
            this.checkEdit_XuatBaoCao.Properties.Caption = "Xuất báo cáo";
            this.checkEdit_XuatBaoCao.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit_XuatBaoCao.Properties.RadioGroupIndex = 1;
            this.checkEdit_XuatBaoCao.Size = new System.Drawing.Size(93, 19);
            this.checkEdit_XuatBaoCao.TabIndex = 4;
            // 
            // checkEdit_ThietKe
            // 
            this.checkEdit_ThietKe.Location = new System.Drawing.Point(203, 116);
            this.checkEdit_ThietKe.Name = "checkEdit_ThietKe";
            this.checkEdit_ThietKe.Properties.Caption = "Thiết kế";
            this.checkEdit_ThietKe.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit_ThietKe.Properties.RadioGroupIndex = 1;
            this.checkEdit_ThietKe.Size = new System.Drawing.Size(93, 19);
            this.checkEdit_ThietKe.TabIndex = 4;
            this.checkEdit_ThietKe.TabStop = false;
            // 
            // simpleButton_Thoat
            // 
            this.simpleButton_Thoat.Location = new System.Drawing.Point(221, 141);
            this.simpleButton_Thoat.Name = "simpleButton_Thoat";
            this.simpleButton_Thoat.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Thoat.TabIndex = 6;
            this.simpleButton_Thoat.Text = "Thoát";
            this.simpleButton_Thoat.Click += new System.EventHandler(this.simpleButton_Thoat_Click);
            // 
            // simpleButton_Xuat
            // 
            this.simpleButton_Xuat.Location = new System.Drawing.Point(104, 141);
            this.simpleButton_Xuat.Name = "simpleButton_Xuat";
            this.simpleButton_Xuat.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Xuat.TabIndex = 5;
            this.simpleButton_Xuat.Text = "Xuất";
            this.simpleButton_Xuat.Click += new System.EventHandler(this.simpleButton_Xuat_Click);
            // 
            // ucComboBoxDonVi_ChonDonVi
            // 
            this.ucComboBoxDonVi_ChonDonVi.DonVi = null;
            this.ucComboBoxDonVi_ChonDonVi.Location = new System.Drawing.Point(104, 38);
            this.ucComboBoxDonVi_ChonDonVi.Name = "ucComboBoxDonVi_ChonDonVi";
            this.ucComboBoxDonVi_ChonDonVi.Size = new System.Drawing.Size(192, 20);
            this.ucComboBoxDonVi_ChonDonVi.TabIndex = 1;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(308, 178);
            this.Controls.Add(this.simpleButton_Xuat);
            this.Controls.Add(this.simpleButton_Thoat);
            this.Controls.Add(this.checkEdit_ThietKe);
            this.Controls.Add(this.checkEdit_XuatBaoCao);
            this.Controls.Add(this.dateEdit_DenNgay);
            this.Controls.Add(this.dateEdit_TuNgay);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.ucComboBoxDonVi_ChonDonVi);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comboBoxEdit_LoaiBaoCao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReport";
            this.Text = "Xuất báo cáo";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_LoaiBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_XuatBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ThietKe.Properties)).EndInit();
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
    }
}