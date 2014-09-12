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
using DevExpress.XtraGrid.Views.BandedGrid;
using SHARED.Libraries;

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
            try
            {
                ucTreeDonVi1.DataSource = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                reloadData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void reloadAndFocused(Guid _id)
        {
            try
            {
                reloadData();
                int rowHandle = bandedGridViewTaiSan.LocateByValue(colid.FieldName, _id);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    bandedGridViewTaiSan.FocusedRowHandle = rowHandle;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadAndFocused: " + ex.Message);
            }
        }

        public void reloadData()
        {
            try
            {
                DonVi obj = ucTreeDonVi1.DonVi;
                //gridControlTaiSan.DataSource = TaiSanHienThi.getAllByDonVi(obj);
                gridControlTaiSan.DataSource = TaiSanHienThi.Convert(obj.getAllCTTaiSanRecursive().ToList());
                bandedGridViewTaiSan.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadData: " + ex.Message);
            }
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlDonVi_TaiSan;
        }

        private void barBtnThemTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddTaiSanExist frm = new frmAddTaiSanExist(ucTreeDonVi1.DonVi);
            frm.reloadAndFocused = new frmAddTaiSanExist.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void barBtnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bandedGridViewTaiSan.ShowRibbonPrintPreview();
        }

        private void bandedGridViewTaiSan_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            try
            {
                TaiSanHienThi c = (TaiSanHienThi)bandedGridViewTaiSan.GetRow(e.RowHandle);
                e.IsEmpty = c.childs == null || c.childs.Count == 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->bandedGridViewTaiSan_MasterRowEmpty: " + ex.Message);
            }
        }

        private void bandedGridViewTaiSan_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void bandedGridViewTaiSan_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Tài sản kèm theo";
        }

        private void bandedGridViewTaiSan_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            try
            {
                TaiSanHienThi c = (TaiSanHienThi)bandedGridViewTaiSan.GetRow(e.RowHandle);
                e.ChildList = TaiSanHienThi.Convert(new List<CTTaiSan>(c.childs));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->bandedGridViewTaiSan_MasterRowGetChildList: " + ex.Message);
            }
        }

        private void barBtnChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BandedGridView view = gridControlTaiSan.FocusedView as BandedGridView;
            if (view.GetFocusedRow() != null)
            {
                frmInputViTri_DonVi frm = new frmInputViTri_DonVi((view.GetFocusedRow() as TaiSanHienThi).obj);
                frm.reloadAndFocused = new frmInputViTri_DonVi.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void barBtnSuaTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BandedGridView view = gridControlTaiSan.FocusedView as BandedGridView;
            if (view.GetFocusedRow() != null)
            {
                frmAddTaiSan frm = new frmAddTaiSan((view.GetFocusedRow() as TaiSanHienThi).obj, true);
                frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void barBtnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BandedGridView view = gridControlTaiSan.FocusedView as BandedGridView;
            if (view.GetFocusedRow() != null)
            {
                frmLogTaiSan frm = new frmLogTaiSan((view.GetFocusedRow() as TaiSanHienThi).obj);
                frm.ShowDialog();
            }
        }
    }
}
