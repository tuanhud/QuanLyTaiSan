namespace QuanLyTaiSanGUI
{
    partial class Test
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
            this.ucThemSuaXoaButton1 = new QuanLyTaiSanGUI.MyUC.ucThemSuaXoaButton();
            this.SuspendLayout();
            // 
            // ucThemSuaXoaButton1
            // 
            this.ucThemSuaXoaButton1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ucThemSuaXoaButton1.Appearance.Options.UseBackColor = true;
            this.ucThemSuaXoaButton1.Location = new System.Drawing.Point(12, 12);
            this.ucThemSuaXoaButton1.Name = "ucThemSuaXoaButton1";
            this.ucThemSuaXoaButton1.Size = new System.Drawing.Size(84, 32);
            this.ucThemSuaXoaButton1.TabIndex = 0;
            this.ucThemSuaXoaButton1.ButtonThemClick += new QuanLyTaiSanGUI.MyUC.MyEventHandler(this.ucThemSuaXoaButton1_ButtonThemClick);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ucThemSuaXoaButton1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private MyUC.ucThemSuaXoaButton ucThemSuaXoaButton1;
    }
}