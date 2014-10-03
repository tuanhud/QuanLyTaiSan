namespace TSCD_GUI.ThongKe
{
    partial class ucTKTaiSan
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
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlTaiSan = new DevExpress.XtraGrid.GridControl();
            this.gridViewTaiSan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControlThongKe = new DevExpress.XtraEditors.GroupControl();
            this.ucComboBoxLoaiTS1 = new TSCD_GUI.MyUserControl.ucComboBoxLoaiTS();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.dateDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dateTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblCoSo = new DevExpress.XtraEditors.LabelControl();
            this.lblDonViSD = new DevExpress.XtraEditors.LabelControl();
            this.lblDonViQL = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiTaiSan = new DevExpress.XtraEditors.LabelControl();
            this.btnThongKe = new DevExpress.XtraEditors.SimpleButton();
            this.checkedComboBoxCoSo = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongKe)).BeginInit();
            this.groupControlThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxCoSo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.gridControlTaiSan);
            this.splitContainerControlMain.Panel1.Text = "Panel1";
            this.splitContainerControlMain.Panel2.Controls.Add(this.groupControlThongKe);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(790, 491);
            this.splitContainerControlMain.SplitterPosition = 291;
            this.splitContainerControlMain.TabIndex = 0;
            this.splitContainerControlMain.Text = "splitContainerControl1";
            // 
            // gridControlTaiSan
            // 
            this.gridControlTaiSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTaiSan.Location = new System.Drawing.Point(0, 0);
            this.gridControlTaiSan.MainView = this.gridViewTaiSan;
            this.gridControlTaiSan.Name = "gridControlTaiSan";
            this.gridControlTaiSan.Size = new System.Drawing.Size(494, 491);
            this.gridControlTaiSan.TabIndex = 0;
            this.gridControlTaiSan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTaiSan});
            // 
            // gridViewTaiSan
            // 
            this.gridViewTaiSan.GridControl = this.gridControlTaiSan;
            this.gridViewTaiSan.Name = "gridViewTaiSan";
            // 
            // groupControlThongKe
            // 
            this.groupControlThongKe.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlThongKe.AppearanceCaption.Options.UseFont = true;
            this.groupControlThongKe.Controls.Add(this.checkedComboBoxCoSo);
            this.groupControlThongKe.Controls.Add(this.ucComboBoxLoaiTS1);
            this.groupControlThongKe.Controls.Add(this.lblDenNgay);
            this.groupControlThongKe.Controls.Add(this.lblTuNgay);
            this.groupControlThongKe.Controls.Add(this.dateDenNgay);
            this.groupControlThongKe.Controls.Add(this.dateTuNgay);
            this.groupControlThongKe.Controls.Add(this.lblCoSo);
            this.groupControlThongKe.Controls.Add(this.lblDonViSD);
            this.groupControlThongKe.Controls.Add(this.lblDonViQL);
            this.groupControlThongKe.Controls.Add(this.lblLoaiTaiSan);
            this.groupControlThongKe.Controls.Add(this.btnThongKe);
            this.groupControlThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlThongKe.Location = new System.Drawing.Point(0, 0);
            this.groupControlThongKe.Name = "groupControlThongKe";
            this.groupControlThongKe.Size = new System.Drawing.Size(291, 491);
            this.groupControlThongKe.TabIndex = 0;
            this.groupControlThongKe.Text = "Thống kê";
            // 
            // ucComboBoxLoaiTS1
            // 
            this.ucComboBoxLoaiTS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucComboBoxLoaiTS1.LoaiTS = null;
            this.ucComboBoxLoaiTS1.Location = new System.Drawing.Point(88, 80);
            this.ucComboBoxLoaiTS1.Name = "ucComboBoxLoaiTS1";
            this.ucComboBoxLoaiTS1.Size = new System.Drawing.Size(185, 20);
            this.ucComboBoxLoaiTS1.TabIndex = 15;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Location = new System.Drawing.Point(5, 56);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(51, 13);
            this.lblDenNgay.TabIndex = 14;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Location = new System.Drawing.Point(5, 30);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(44, 13);
            this.lblTuNgay.TabIndex = 13;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDenNgay.EditValue = null;
            this.dateDenNgay.Location = new System.Drawing.Point(88, 53);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Size = new System.Drawing.Size(185, 20);
            this.dateDenNgay.TabIndex = 12;
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTuNgay.EditValue = null;
            this.dateTuNgay.Location = new System.Drawing.Point(88, 27);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Size = new System.Drawing.Size(185, 20);
            this.dateTuNgay.TabIndex = 11;
            // 
            // lblCoSo
            // 
            this.lblCoSo.Location = new System.Drawing.Point(5, 160);
            this.lblCoSo.Name = "lblCoSo";
            this.lblCoSo.Size = new System.Drawing.Size(31, 13);
            this.lblCoSo.TabIndex = 9;
            this.lblCoSo.Text = "Cơ sở:";
            // 
            // lblDonViSD
            // 
            this.lblDonViSD.Location = new System.Drawing.Point(5, 134);
            this.lblDonViSD.Name = "lblDonViSD";
            this.lblDonViSD.Size = new System.Drawing.Size(77, 13);
            this.lblDonViSD.TabIndex = 8;
            this.lblDonViSD.Text = "Đơn vị sử dụng:";
            // 
            // lblDonViQL
            // 
            this.lblDonViQL.Location = new System.Drawing.Point(5, 108);
            this.lblDonViQL.Name = "lblDonViQL";
            this.lblDonViQL.Size = new System.Drawing.Size(73, 13);
            this.lblDonViQL.TabIndex = 7;
            this.lblDonViQL.Text = "Đơn vị quản lý:";
            // 
            // lblLoaiTaiSan
            // 
            this.lblLoaiTaiSan.Location = new System.Drawing.Point(5, 82);
            this.lblLoaiTaiSan.Name = "lblLoaiTaiSan";
            this.lblLoaiTaiSan.Size = new System.Drawing.Size(58, 13);
            this.lblLoaiTaiSan.TabIndex = 6;
            this.lblLoaiTaiSan.Text = "Loại tài sản:";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.Location = new System.Drawing.Point(88, 183);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // checkedComboBoxCoSo
            // 
            this.checkedComboBoxCoSo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedComboBoxCoSo.Location = new System.Drawing.Point(88, 157);
            this.checkedComboBoxCoSo.Name = "checkedComboBoxCoSo";
            this.checkedComboBoxCoSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxCoSo.Properties.DisplayMember = "ten";
            this.checkedComboBoxCoSo.Properties.ValueMember = "id";
            this.checkedComboBoxCoSo.Size = new System.Drawing.Size(185, 20);
            this.checkedComboBoxCoSo.TabIndex = 16;
            // 
            // ucTKTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "ucTKTaiSan";
            this.Size = new System.Drawing.Size(790, 491);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongKe)).EndInit();
            this.groupControlThongKe.ResumeLayout(false);
            this.groupControlThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxCoSo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraGrid.GridControl gridControlTaiSan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTaiSan;
        private DevExpress.XtraEditors.GroupControl groupControlThongKe;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.DateEdit dateDenNgay;
        private DevExpress.XtraEditors.DateEdit dateTuNgay;
        private DevExpress.XtraEditors.LabelControl lblCoSo;
        private DevExpress.XtraEditors.LabelControl lblDonViSD;
        private DevExpress.XtraEditors.LabelControl lblDonViQL;
        private DevExpress.XtraEditors.LabelControl lblLoaiTaiSan;
        private DevExpress.XtraEditors.SimpleButton btnThongKe;
        private MyUserControl.ucComboBoxLoaiTS ucComboBoxLoaiTS1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxCoSo;

    }
}
