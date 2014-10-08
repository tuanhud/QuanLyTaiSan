namespace TSCD_GUI.QLTaiSan
{
    partial class WaitForm_Report
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
            this.progressPanel_Report = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tableLayoutPanel_Report = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Report.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressPanel_Report
            // 
            this.progressPanel_Report.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel_Report.Appearance.Options.UseBackColor = true;
            this.progressPanel_Report.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel_Report.AppearanceCaption.Options.UseFont = true;
            this.progressPanel_Report.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel_Report.AppearanceDescription.Options.UseFont = true;
            this.progressPanel_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel_Report.ImageHorzOffset = 20;
            this.progressPanel_Report.Location = new System.Drawing.Point(0, 17);
            this.progressPanel_Report.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.progressPanel_Report.Name = "progressPanel_Report";
            this.progressPanel_Report.Size = new System.Drawing.Size(246, 39);
            this.progressPanel_Report.TabIndex = 0;
            // 
            // tableLayoutPanel_Report
            // 
            this.tableLayoutPanel_Report.AutoSize = true;
            this.tableLayoutPanel_Report.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_Report.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_Report.ColumnCount = 1;
            this.tableLayoutPanel_Report.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Report.Controls.Add(this.progressPanel_Report, 0, 0);
            this.tableLayoutPanel_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Report.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Report.Name = "tableLayoutPanel_Report";
            this.tableLayoutPanel_Report.Padding = new System.Windows.Forms.Padding(0, 14, 0, 14);
            this.tableLayoutPanel_Report.RowCount = 1;
            this.tableLayoutPanel_Report.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Report.Size = new System.Drawing.Size(246, 73);
            this.tableLayoutPanel_Report.TabIndex = 1;
            // 
            // WaitForm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(246, 73);
            this.Controls.Add(this.tableLayoutPanel_Report);
            this.DoubleBuffered = true;
            this.Name = "WaitForm_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.tableLayoutPanel_Report.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel_Report;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Report;
    }
}
