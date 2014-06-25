using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.Libraries;

namespace QuanLyTaiSanGUI.ThongKe
{
    public partial class ucTK_SLTB_TheoTinhTrang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTK_SLTB_TheoTinhTrang()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            checkedComboBoxEdit_tinhTrang.Properties.DataSource =
                new TinhTrang().getAll();

            ucTreeLoaiTB.loadData(new LoaiThietBi().getAll());
            checkedComboBoxEdit_coso.Properties.DataSource = new CoSo().getAll();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            //get condition
            DateTime from = dateEdit_from.DateTime;
            DateTime to = dateEdit_from.DateTime;
            //get result
            //String jk = checkedComboBoxEdit_tinhTrang.;
            List<int> list_coso =CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_coso);
            List<int> list_tinhtrang = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_tinhTrang);
            List<int> list_ltb = null;

            gridControl1.DataSource = new TKSLThietBiFilter().getAll(list_coso,list_ltb,list_tinhtrang,null,null);
        }
    }
}
