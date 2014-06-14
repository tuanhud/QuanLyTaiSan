namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    partial class ucQuanLyCoSo
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colten = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colmota = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldate_create = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldate_modified = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.dataSet1 = new QuanLyTaiSanGUI.MyDataSet.DataSet1();
            this.cososTableAdapter1 = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.COSOSTableAdapter();
            this.daysTableAdapter1 = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.DAYSTableAdapter();
            this.tangsTableAdapter1 = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.TANGSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(715, 471);
            this.splitContainerControl1.SplitterPosition = 429;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colten,
            this.colmota,
            this.coldate_create,
            this.coldate_modified});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "id";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.ParentFieldName = "parent_id";
            this.treeList1.Size = new System.Drawing.Size(429, 471);
            this.treeList1.TabIndex = 0;
            // 
            // colten
            // 
            this.colten.FieldName = "ten";
            this.colten.MinWidth = 52;
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 0;
            this.colten.Width = 68;
            // 
            // colmota
            // 
            this.colmota.FieldName = "mota";
            this.colmota.Name = "colmota";
            this.colmota.Visible = true;
            this.colmota.VisibleIndex = 1;
            this.colmota.Width = 68;
            // 
            // coldate_create
            // 
            this.coldate_create.FieldName = "date_create";
            this.coldate_create.Name = "coldate_create";
            this.coldate_create.Visible = true;
            this.coldate_create.VisibleIndex = 2;
            this.coldate_create.Width = 69;
            // 
            // coldate_modified
            // 
            this.coldate_modified.FieldName = "date_modified";
            this.coldate_modified.Name = "coldate_modified";
            this.coldate_modified.Visible = true;
            this.coldate_modified.VisibleIndex = 3;
            this.coldate_modified.Width = 69;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cososTableAdapter1
            // 
            this.cososTableAdapter1.ClearBeforeFill = true;
            // 
            // daysTableAdapter1
            // 
            this.daysTableAdapter1.ClearBeforeFill = true;
            // 
            // tangsTableAdapter1
            // 
            this.tangsTableAdapter1.ClearBeforeFill = true;
            // 
            // ucQuanLyCoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucQuanLyCoSo";
            this.Size = new System.Drawing.Size(715, 471);
            this.Load += new System.EventHandler(this.ucQuanLyCoSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colmota;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldate_create;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldate_modified;
        private MyDataSet.DataSet1 dataSet1;
        private MyDataSet.DataSet1TableAdapters.COSOSTableAdapter cososTableAdapter1;
        private MyDataSet.DataSet1TableAdapters.DAYSTableAdapter daysTableAdapter1;
        private MyDataSet.DataSet1TableAdapters.TANGSTableAdapter tangsTableAdapter1;
    }
}
