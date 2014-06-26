using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen_Group : UserControl
    {
        public ucPhanQuyen_Group()
        {
            InitializeComponent();
        }
        public GridControl getLeftControl()
        {
            return gridControlGroup;
        }
        public GroupControl getRightControl()
        {
            return groupControl1;
        }
    }
}
