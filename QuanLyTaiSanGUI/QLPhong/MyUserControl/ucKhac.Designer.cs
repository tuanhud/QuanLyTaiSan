namespace QuanLyTaiSanGUI.MyUserControl
{
    partial class ucKhac
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dAYSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new QuanLyTaiSanGUI.MyDataSet.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_create = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_modified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcoso_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cOSOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colhinhanh_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dAYSTableAdapter = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.DAYSTableAdapter();
            this.cOSOSTableAdapter = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.COSOSTableAdapter();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.lOAITHIETBISBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOAITHIETBISTableAdapter = new QuanLyTaiSanGUI.MyDataSet.DataSet1TableAdapters.LOAITHIETBISTableAdapter();
            this.colid1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colten1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colmota1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldate_create1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldate_modified1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAYSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOSOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAITHIETBISBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.dAYSBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(369, 411);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dAYSBindingSource
            // 
            this.dAYSBindingSource.DataMember = "DAYS";
            this.dAYSBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colsubId,
            this.colten,
            this.colmota,
            this.coldate_create,
            this.coldate_modified,
            this.colcoso_id,
            this.colhinhanh_id});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ReadOnly = true;
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colsubId
            // 
            this.colsubId.FieldName = "subId";
            this.colsubId.Name = "colsubId";
            this.colsubId.Visible = true;
            this.colsubId.VisibleIndex = 1;
            // 
            // colten
            // 
            this.colten.FieldName = "ten";
            this.colten.Name = "colten";
            this.colten.Visible = true;
            this.colten.VisibleIndex = 2;
            // 
            // colmota
            // 
            this.colmota.FieldName = "mota";
            this.colmota.Name = "colmota";
            this.colmota.Visible = true;
            this.colmota.VisibleIndex = 3;
            // 
            // coldate_create
            // 
            this.coldate_create.FieldName = "date_create";
            this.coldate_create.Name = "coldate_create";
            this.coldate_create.Visible = true;
            this.coldate_create.VisibleIndex = 4;
            // 
            // coldate_modified
            // 
            this.coldate_modified.FieldName = "date_modified";
            this.coldate_modified.Name = "coldate_modified";
            this.coldate_modified.Visible = true;
            this.coldate_modified.VisibleIndex = 5;
            // 
            // colcoso_id
            // 
            this.colcoso_id.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colcoso_id.FieldName = "coso_id";
            this.colcoso_id.Name = "colcoso_id";
            this.colcoso_id.Visible = true;
            this.colcoso_id.VisibleIndex = 6;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.cOSOSBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "ten";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "id";
            // 
            // cOSOSBindingSource
            // 
            this.cOSOSBindingSource.DataMember = "COSOS";
            this.cOSOSBindingSource.DataSource = this.dataSet1;
            // 
            // colhinhanh_id
            // 
            this.colhinhanh_id.FieldName = "hinhanh_id";
            this.colhinhanh_id.Name = "colhinhanh_id";
            this.colhinhanh_id.Visible = true;
            this.colhinhanh_id.VisibleIndex = 7;
            // 
            // dAYSTableAdapter
            // 
            this.dAYSTableAdapter.ClearBeforeFill = true;
            // 
            // cOSOSTableAdapter
            // 
            this.cOSOSTableAdapter.ClearBeforeFill = true;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colid1,
            this.colten1,
            this.colmota1,
            this.coldate_create1,
            this.coldate_modified1});
            this.treeList1.DataSource = this.lOAITHIETBISBindingSource;
            this.treeList1.Location = new System.Drawing.Point(378, 3);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.ParentFieldName = "parent_id";
            this.treeList1.Size = new System.Drawing.Size(400, 411);
            this.treeList1.TabIndex = 1;
            // 
            // lOAITHIETBISBindingSource
            // 
            this.lOAITHIETBISBindingSource.DataMember = "LOAITHIETBIS";
            this.lOAITHIETBISBindingSource.DataSource = this.dataSet1;
            // 
            // lOAITHIETBISTableAdapter
            // 
            this.lOAITHIETBISTableAdapter.ClearBeforeFill = true;
            // 
            // colid1
            // 
            this.colid1.FieldName = "id";
            this.colid1.MinWidth = 52;
            this.colid1.Name = "colid1";
            this.colid1.OptionsColumn.ReadOnly = true;
            this.colid1.Visible = true;
            this.colid1.VisibleIndex = 0;
            this.colid1.Width = 63;
            // 
            // colten1
            // 
            this.colten1.FieldName = "ten";
            this.colten1.Name = "colten1";
            this.colten1.Visible = true;
            this.colten1.VisibleIndex = 1;
            this.colten1.Width = 63;
            // 
            // colmota1
            // 
            this.colmota1.FieldName = "mota";
            this.colmota1.Name = "colmota1";
            this.colmota1.Visible = true;
            this.colmota1.VisibleIndex = 2;
            this.colmota1.Width = 64;
            // 
            // coldate_create1
            // 
            this.coldate_create1.FieldName = "date_create";
            this.coldate_create1.Name = "coldate_create1";
            this.coldate_create1.Visible = true;
            this.coldate_create1.VisibleIndex = 3;
            this.coldate_create1.Width = 64;
            // 
            // coldate_modified1
            // 
            this.coldate_modified1.FieldName = "date_modified";
            this.coldate_modified1.Name = "coldate_modified1";
            this.coldate_modified1.Visible = true;
            this.coldate_modified1.VisibleIndex = 4;
            this.coldate_modified1.Width = 64;
            // 
            // ucKhac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.gridControl1);
            this.Name = "ucKhac";
            this.Size = new System.Drawing.Size(786, 417);
            this.Load += new System.EventHandler(this.ucKhac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAYSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOSOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAITHIETBISBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource dAYSBindingSource;
        private MyDataSet.DataSet1 dataSet1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colsubId;
        private DevExpress.XtraGrid.Columns.GridColumn colten;
        private DevExpress.XtraGrid.Columns.GridColumn colmota;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_create;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_modified;
        private DevExpress.XtraGrid.Columns.GridColumn colcoso_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource cOSOSBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colhinhanh_id;
        private MyDataSet.DataSet1TableAdapters.DAYSTableAdapter dAYSTableAdapter;
        private MyDataSet.DataSet1TableAdapters.COSOSTableAdapter cOSOSTableAdapter;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colten1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colmota1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldate_create1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldate_modified1;
        private System.Windows.Forms.BindingSource lOAITHIETBISBindingSource;
        private MyDataSet.DataSet1TableAdapters.LOAITHIETBISTableAdapter lOAITHIETBISTableAdapter;
    }
}
