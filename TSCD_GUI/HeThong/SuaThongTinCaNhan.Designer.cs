namespace TSCD_GUI.HeThong
{
    partial class SuaThongTinCaNhan
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
            this.viewSuaThongTinCaNhan1 = new SHARED.Views.viewSuaThongTinCaNhan();
            this.SuspendLayout();
            // 
            // viewSuaThongTinCaNhan1
            // 
            this.viewSuaThongTinCaNhan1.Location = new System.Drawing.Point(0, 2);
            this.viewSuaThongTinCaNhan1.Name = "viewSuaThongTinCaNhan1";
            this.viewSuaThongTinCaNhan1.Size = new System.Drawing.Size(551, 183);
            this.viewSuaThongTinCaNhan1.TabIndex = 0;
            // 
            // SuaThongTinCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 185);
            this.Controls.Add(this.viewSuaThongTinCaNhan1);
            this.MaximumSize = new System.Drawing.Size(569, 224);
            this.MinimumSize = new System.Drawing.Size(569, 224);
            this.Name = "SuaThongTinCaNhan";
            this.Text = "Sửa thông tin cá nhân";
            this.Load += new System.EventHandler(this.SuaThongTinCaNhan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SHARED.Views.viewSuaThongTinCaNhan viewSuaThongTinCaNhan1;

    }
}