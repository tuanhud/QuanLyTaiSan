using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using TSCD.Entities;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmAddTaiSanExist : DevExpress.XtraEditors.XtraForm
    {
        List<CTTaiSan> listCTTaiSan = null;
        public frmAddTaiSanExist()
        {
            InitializeComponent();
        }

        public frmAddTaiSanExist(List<CTTaiSan> list)
        {
            InitializeComponent();
            listCTTaiSan = list;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
        }
    }
}