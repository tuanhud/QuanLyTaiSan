namespace TSCD_GUI.QLTaiSan
{
    partial class frmFileChungTu
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
            this.btnChonFile = new DevExpress.XtraEditors.SimpleButton();
            this.label_uploading = new DevExpress.XtraEditors.LabelControl();
            this.gridControlAttachment = new DevExpress.XtraGrid.GridControl();
            this.gridViewAttachment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colfile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttachment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 12);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 4;
            this.btnChonFile.Text = "Chọn files";
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // label_uploading
            // 
            this.label_uploading.Location = new System.Drawing.Point(113, 17);
            this.label_uploading.Name = "label_uploading";
            this.label_uploading.Size = new System.Drawing.Size(90, 13);
            this.label_uploading.TabIndex = 5;
            this.label_uploading.Text = "Upload progress...";
            // 
            // gridControlAttachment
            // 
            this.gridControlAttachment.Location = new System.Drawing.Point(12, 41);
            this.gridControlAttachment.MainView = this.gridViewAttachment;
            this.gridControlAttachment.Name = "gridControlAttachment";
            this.gridControlAttachment.Size = new System.Drawing.Size(585, 266);
            this.gridControlAttachment.TabIndex = 6;
            this.gridControlAttachment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAttachment});
            // 
            // gridViewAttachment
            // 
            this.gridViewAttachment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colfile});
            this.gridViewAttachment.GridControl = this.gridControlAttachment;
            this.gridViewAttachment.Name = "gridViewAttachment";
            this.gridViewAttachment.OptionsBehavior.Editable = false;
            this.gridViewAttachment.OptionsBehavior.ReadOnly = true;
            this.gridViewAttachment.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewAttachment.OptionsView.ShowGroupPanel = false;
            // 
            // colfile
            // 
            this.colfile.Caption = "File";
            this.colfile.FieldName = "path";
            this.colfile.Name = "colfile";
            this.colfile.Visible = true;
            this.colfile.VisibleIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(522, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(441, 323);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(522, 323);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmFileChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 358);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gridControlAttachment);
            this.Controls.Add(this.label_uploading);
            this.Controls.Add(this.btnChonFile);
            this.Name = "frmFileChungTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chứng từ kèm theo";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttachment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnChonFile;
        private DevExpress.XtraEditors.LabelControl label_uploading;
        private DevExpress.XtraGrid.GridControl gridControlAttachment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAttachment;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn colfile;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
    }
}