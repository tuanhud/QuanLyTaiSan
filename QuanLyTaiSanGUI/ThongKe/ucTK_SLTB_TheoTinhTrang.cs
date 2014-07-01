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
using DevExpress.XtraBars.Ribbon;

namespace QuanLyTaiSanGUI.ThongKe
{
    public partial class ucTK_SLTB_TheoTinhTrang : DevExpress.XtraEditors.XtraUserControl
    {
        QuanLyTaiSanGUI.MyUC.ucTreeLoaiTB ucTreeLoaiTB2 = new MyUC.ucTreeLoaiTB(true);
        public ucTK_SLTB_TheoTinhTrang()
        {
            InitializeComponent();
            ribbonThongKe.Parent = null;
            loadData();
        }
        private void loadData()
        {
            checkedComboBoxEdit_tinhTrang.Properties.DataSource =
                TinhTrang.getAll();

            //ucTreeLoaiTB2
            ucTreeLoaiTB2.loadData(LoaiThietBi.getAll());
            ucTreeLoaiTB2.Dock = DockStyle.Fill;
            panelLoaiTB.Controls.Clear();
            panelLoaiTB.Controls.Add(ucTreeLoaiTB2);

            checkedComboBoxEdit_coso.Properties.DataSource = null;
            checkedComboBoxEdit_coso.Properties.DataSource = CoSo.getAll();
        }

        public RibbonControl getRibbon()
        {
            return ribbonThongKe;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            //get condition
            DateTime? from = (DateTime?)dateEdit_from.EditValue;
            DateTime? to = (DateTime?)dateEdit_to.EditValue;
            //get result
            //String jk = checkedComboBoxEdit_tinhTrang.;
            List<int> list_coso =CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_coso);
            List<int> list_tinhtrang = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_tinhTrang);
            List<int> list_ltb = ucTreeLoaiTB2.getListLoaiTB().Select(x => x.id).ToList();

            List<TKSLThietBiFilter> list_tk = TKSLThietBiFilter.getAll(list_coso, list_ltb, list_tinhtrang,from,to,-1,1);

            //gridControl1.DataSource = null;
            gridControl1.DataSource = list_tk;
            //list_tk = null;
            DBInstance.reNew();
        }
    }
}
