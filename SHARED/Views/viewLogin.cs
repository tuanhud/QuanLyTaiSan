using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHARED.Views
{
    public partial class viewLogin : UserControl
    {
        public viewLogin()
        {
            InitializeComponent();
            txtMessage.Text = String.Empty;
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void viewLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
