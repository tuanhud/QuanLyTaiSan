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
using QuanLyTaiSan.DataFilter;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucComboBoxPhong : UserControl
    {
        public ucComboBoxPhong()
        {
            InitializeComponent();
            //PhongFilter obj = new PhongFilter();
            //List<PhongFilter> list = obj.getAll();
            //searchLookUpEdit1.Properties.DataSource = list; 
        }
    }
}
