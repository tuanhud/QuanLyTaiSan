﻿namespace QuanLyTaiSanGUI.MyUserControl
{
    partial class ucChiTietThietBi
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
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pHONGSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new QuanLyTaiSanGUI.MyDataSet.DataSet1();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lOAITHIETBISBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.textEdit4 = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.lOGTINHTRANGSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltinhtrang_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lOAITHIETBISTableAdapter = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.LOAITHIETBISTableAdapter();
            this.pHONGSTableAdapter = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.PHONGSTableAdapter();
            this.ctthietbisTableAdapter = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.CTTHIETBISTableAdapter();
            this.lOGTINHTRANGSTableAdapter = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.LOGTINHTRANGSTableAdapter();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pHONGSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAITHIETBISBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGTINHTRANGSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.comboBox2);
            this.groupControl1.Controls.Add(this.comboBox1);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dateEdit2);
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.imageSlider1);
            this.groupControl1.Controls.Add(this.textEdit4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(282, 333);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Chi tiết thiết bị";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.pHONGSBindingSource;
            this.comboBox2.DisplayMember = "ten";
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(67, 181);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 17;
            this.comboBox2.ValueMember = "id";
            // 
            // pHONGSBindingSource
            // 
            this.pHONGSBindingSource.DataMember = "PHONGS";
            this.pHONGSBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.lOAITHIETBISBindingSource;
            this.comboBox1.DisplayMember = "ten";
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(67, 154);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.ValueMember = "id";
            // 
            // lOAITHIETBISBindingSource
            // 
            this.lOAITHIETBISBindingSource.DataMember = "LOAITHIETBIS";
            this.lOAITHIETBISBindingSource.DataSource = this.dataSet1;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(6, 262);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(27, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Mô tả";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 237);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Ngày lắp";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 211);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Ngày mua";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 185);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(30, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Phòng";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 158);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Loại thiết bị";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 131);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Tên thiết bị";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Hình ảnh";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(67, 234);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dateEdit2.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dateEdit2.Properties.ReadOnly = true;
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 6;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(67, 208);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dateEdit1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dateEdit1.Properties.ReadOnly = true;
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 5;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(67, 127);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(161, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // imageSlider1
            // 
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imageSlider1.Location = new System.Drawing.Point(67, 24);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(114, 97);
            this.imageSlider1.TabIndex = 0;
            this.imageSlider1.Text = "imageSlider1";
            // 
            // textEdit4
            // 
            this.textEdit4.Location = new System.Drawing.Point(67, 260);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.ReadOnly = true;
            this.textEdit4.Size = new System.Drawing.Size(210, 68);
            this.textEdit4.TabIndex = 4;
            this.textEdit4.UseOptimizedRendering = true;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 333);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(282, 215);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Log";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.lOGTINHTRANGSBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(278, 192);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // lOGTINHTRANGSBindingSource
            // 
            this.lOGTINHTRANGSBindingSource.DataMember = "LOGTINHTRANGS";
            this.lOGTINHTRANGSBindingSource.DataSource = this.dataSet1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colngay,
            this.colsoluong,
            this.coltinhtrang_id});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ReadOnly = true;
            // 
            // colngay
            // 
            this.colngay.FieldName = "ngay";
            this.colngay.Name = "colngay";
            this.colngay.Visible = true;
            this.colngay.VisibleIndex = 0;
            // 
            // colsoluong
            // 
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Visible = true;
            this.colsoluong.VisibleIndex = 2;
            // 
            // coltinhtrang_id
            // 
            this.coltinhtrang_id.FieldName = "tinhtrang_id";
            this.coltinhtrang_id.Name = "coltinhtrang_id";
            this.coltinhtrang_id.Visible = true;
            this.coltinhtrang_id.VisibleIndex = 1;
            // 
            // lOAITHIETBISTableAdapter
            // 
            this.lOAITHIETBISTableAdapter.ClearBeforeFill = true;
            // 
            // pHONGSTableAdapter
            // 
            this.pHONGSTableAdapter.ClearBeforeFill = true;
            // 
            // ctthietbisTableAdapter
            // 
            this.ctthietbisTableAdapter.ClearBeforeFill = true;
            // 
            // lOGTINHTRANGSTableAdapter
            // 
            this.lOGTINHTRANGSTableAdapter.ClearBeforeFill = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(174, 182);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(103, 30);
            this.panelControl1.TabIndex = 18;
            // 
            // ucChiTietThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucChiTietThietBi";
            this.Size = new System.Drawing.Size(282, 548);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pHONGSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAITHIETBISBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGTINHTRANGSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit textEdit4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource pHONGSBindingSource;
        private MyDataSet.DataSet1 dataSet1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource lOAITHIETBISBindingSource;
        private MyDataSet.DataSet1TableAdapters.LOAITHIETBISTableAdapter lOAITHIETBISTableAdapter;
        private MyDataSet.DataSet1TableAdapters.PHONGSTableAdapter pHONGSTableAdapter;
        private MyDataSet.DataSet1TableAdapters.CTTHIETBISTableAdapter ctthietbisTableAdapter;
        private System.Windows.Forms.BindingSource lOGTINHTRANGSBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colngay;
        private DevExpress.XtraGrid.Columns.GridColumn colsoluong;
        private DevExpress.XtraGrid.Columns.GridColumn coltinhtrang_id;
        private MyDataSet.DataSet1TableAdapters.LOGTINHTRANGSTableAdapter lOGTINHTRANGSTableAdapter;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}