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

namespace TSCD_GUI.QLTaiSan
{
    public partial class ucQuanLyDonVi_TaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyDonVi_TaiSan()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlDonVi_TaiSan.Parent = null;
            ucTreeDonVi1.focusedNodeChanged = new MyUserControl.ucTreeDonVi.FocusedNodeChanged(reloadData);
        }

        public void loadData()
        {
            ucTreeDonVi1.DataSource = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
            reloadData();
        }

        private void reloadAndFocused(Guid _id)
        {
            reloadData();
            int rowHandle = bandedGridViewTaiSan.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                bandedGridViewTaiSan.FocusedRowHandle = rowHandle;
        }

        public void reloadData()
        {
            DonVi obj = ucTreeDonVi1.DonVi;
            gridControlTaiSan.DataSource = TaiSanHienThi.getAllByDonVi(obj);
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlDonVi_TaiSan;
        }

        private void barBtnThemTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddTaiSan_DonVi frm = new frmAddTaiSan_DonVi(ucTreeDonVi1.DonVi);
            frm.reloadAndFocused = new frmAddTaiSan_DonVi.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void barBtnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bandedGridViewTaiSan.ShowRibbonPrintPreview();
        }
    }
}
