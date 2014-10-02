using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using TSCD.DataFilter;

namespace TSCD_GUI.ThongKe
{
    public partial class ucTKTaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTKTaiSan()
        {
            InitializeComponent();
            ucComboBoxLoaiTS1.showCheck();
        }

        public void loadData()
        {
            ucComboBoxLoaiTS1.DataSource = LoaiTSHienThi.Convert(LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten));
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            String str = "";
            foreach (Guid id in ucComboBoxLoaiTS1.list_loaitaisan)
            {
                str += id;
            }
            MessageBox.Show(str);
        }
    }
}
