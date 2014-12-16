namespace TSCD_GUI.Settings
{
    partial class ucImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImport));
            this.simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton
            // 
            this.simpleButton.Appearance.Options.UseTextOptions = true;
            this.simpleButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleButton.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton.Image")));
            this.simpleButton.Location = new System.Drawing.Point(306, 45);
            this.simpleButton.Name = "simpleButton";
            this.simpleButton.Size = new System.Drawing.Size(88, 23);
            this.simpleButton.TabIndex = 1;
            this.simpleButton.Text = "Nhập liệu";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.comboBoxEdit);
            this.groupControl1.Controls.Add(this.simpleButton);
            this.groupControl1.Location = new System.Drawing.Point(88, 83);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(611, 265);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Nhập liệu từ tập tin excel";
            // 
            // comboBoxEdit
            // 
            this.comboBoxEdit.EditValue = "Chọn dữ liệu cần nhập liệu vào phần mềm";
            this.comboBoxEdit.Location = new System.Drawing.Point(44, 47);
            this.comboBoxEdit.Name = "comboBoxEdit";
            this.comboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit.Properties.Items.AddRange(new object[] {
            "Nhập liệu vị trí",
            "Nhập liệu loại phòng",
            "Nhập liệu phòng",
            "Nhập liệu loại đơn vị",
            "Nhập liệu đơn vị",
            "Nhập liệu đơn vị tính",
            "Nhập liệu loại tài sản",
            "Nhập liệu tài sản"});
            this.comboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit.Size = new System.Drawing.Size(256, 20);
            this.comboBoxEdit.TabIndex = 9;
            // 
            // ucImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupControl1);
            this.Name = "ucImport";
            this.Size = new System.Drawing.Size(804, 400);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit;


    }
}
