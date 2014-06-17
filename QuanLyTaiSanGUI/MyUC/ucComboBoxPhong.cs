using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucComboBoxPhong : UserControl
    {
        public ucComboBoxPhong()
        {
            InitializeComponent();
            searchLookUpEdit1.Properties.DataSource = new Phong().getAll().ToList(); 
        }
    }
}
