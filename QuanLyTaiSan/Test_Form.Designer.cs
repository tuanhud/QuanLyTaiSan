namespace QuanLyTaiSan
{
    partial class Test_Form
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_permissionName = new System.Windows.Forms.TextBox();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.textBox_permissionNameEdit = new System.Windows.Forms.TextBox();
            this.button_generateSample = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(246, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(281, 12);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(106, 23);
            this.button_refresh.TabIndex = 1;
            this.button_refresh.Text = "Refresh/Load";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(281, 111);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(106, 23);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBox_permissionName
            // 
            this.textBox_permissionName.Location = new System.Drawing.Point(281, 85);
            this.textBox_permissionName.Name = "textBox_permissionName";
            this.textBox_permissionName.Size = new System.Drawing.Size(106, 20);
            this.textBox_permissionName.TabIndex = 3;
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(281, 47);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(106, 23);
            this.button_remove.TabIndex = 4;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(281, 185);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(106, 23);
            this.button_update.TabIndex = 5;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // textBox_permissionNameEdit
            // 
            this.textBox_permissionNameEdit.Location = new System.Drawing.Point(281, 159);
            this.textBox_permissionNameEdit.Name = "textBox_permissionNameEdit";
            this.textBox_permissionNameEdit.Size = new System.Drawing.Size(106, 20);
            this.textBox_permissionNameEdit.TabIndex = 6;
            // 
            // button_generateSample
            // 
            this.button_generateSample.Location = new System.Drawing.Point(446, 11);
            this.button_generateSample.Name = "button_generateSample";
            this.button_generateSample.Size = new System.Drawing.Size(74, 59);
            this.button_generateSample.TabIndex = 7;
            this.button_generateSample.Text = "Generate Sample Data";
            this.button_generateSample.UseVisualStyleBackColor = true;
            this.button_generateSample.Click += new System.EventHandler(this.button_generateSample_Click);
            // 
            // Test_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 288);
            this.Controls.Add(this.button_generateSample);
            this.Controls.Add(this.textBox_permissionNameEdit);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.textBox_permissionName);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.listBox1);
            this.Name = "Test_Form";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Test_Form_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_permissionName;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.TextBox textBox_permissionNameEdit;
        private System.Windows.Forms.Button button_generateSample;
    }
}

