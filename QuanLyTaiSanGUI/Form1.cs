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
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CoSo obj = new CoSo();
            List<CoSo> list = obj.getAll();
            gridControl1.DataSource = list;
        }
    }
}
