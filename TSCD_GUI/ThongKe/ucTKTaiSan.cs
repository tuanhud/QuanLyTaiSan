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
using TSCD_GUI.Libraries;

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
            checkedComboBoxCoSo.Properties.DataSource = CoSo.getQuery().OrderBy(c => c.order).ToList();
            List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
            DonVi objNULL = new DonVi();
            objNULL.id = Guid.Empty;
            objNULL.ten = "[Đại học Sài Gòn]";
            objNULL.parent = null;
            list.Insert(0, objNULL);
            ucComboBoxDonVi1.DataSource = list;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            //String str = "";
            //foreach (Guid id in ucComboBoxLoaiTS1.list_loaitaisan)
            //{
            //    str += id;
            //}
            //MessageBox.Show(str);
            List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxCoSo);
            gridControlTaiSan.DataSource = TaiSan_ThongKe.getAll(list_coso, ucComboBoxLoaiTS1.list_loaitaisan);
            //bandedGridViewTaiSan.PopulateColumns();
        }

        private void btnThongKeTangGiam_Click(object sender, EventArgs e)
        {
            //List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxCoSo);
            DonVi obj = ucComboBoxDonVi1.DonVi;
            gridControlTaiSan.DataSource = TaiSan_ThongKe.getTangGiamAll(obj != null ? obj.id : Guid.Empty, null, null);
        }

        public void ExpandAllGroups()
        {
            bandedGridViewTaiSan.ExpandAllGroups();
        }

        public void CollapseAllGroups()
        {
            bandedGridViewTaiSan.CollapseAllGroups();
        }
    }
}
