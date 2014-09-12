namespace TSCD_GUI.QLTaiSan
{
    partial class frmLogTaiSan
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
            this.gridControlLog = new DevExpress.XtraGrid.GridControl();
            this.gridViewLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLog)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlLog
            // 
            this.gridControlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLog.Location = new System.Drawing.Point(0, 0);
            this.gridControlLog.MainView = this.gridViewLog;
            this.gridControlLog.Name = "gridControlLog";
            this.gridControlLog.Size = new System.Drawing.Size(805, 457);
            this.gridControlLog.TabIndex = 0;
            this.gridControlLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLog});
            // 
            // gridViewLog
            // 
            this.gridViewLog.GridControl = this.gridControlLog;
            this.gridViewLog.Name = "gridViewLog";
            // 
            // frmLogTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 457);
            this.Controls.Add(this.gridControlLog);
            this.Name = "frmLogTaiSan";
            this.Text = "Log tài sản";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLog;
    }
}