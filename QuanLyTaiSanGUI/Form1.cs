using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSanGUI.QLLoaiThietBi;

namespace QuanLyTaiSanGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<NhanVienPT> list = new NhanVienPT().getAllByViTri(-1,1,1,7);
            gridControl1.DataSource = list;

        }
    }
}
