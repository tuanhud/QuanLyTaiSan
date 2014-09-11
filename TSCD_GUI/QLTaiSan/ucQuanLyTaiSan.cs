using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using TSCD.Entities;
using SHARED.Libraries;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace TSCD_GUI.QLTaiSan
{
    public partial class ucQuanLyTaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyTaiSan()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlTaiSan.Parent = null;
        }

        public void loadData()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlTaiSan;
        }

        public CTTaiSan CTTaiSan
        {
            get
            {
                try
                {
                    BandedGridView view = gridControlTaiSan.FocusedView as BandedGridView;
                    if (view.GetFocusedRow() != null)
                        return (view.GetFocusedRow() as TaiSanHienThi).obj;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->getCTTaiSan:" + ex.Message);
                    return null;
                }
            }
        }


        private void reloadAndFocused(Guid _id)
        {
            try
            {
                loadData();
                if (_id != Guid.Empty)
                {
                    int rowHandle = bandedGridViewTaiSan.LocateByValue(colid.FieldName, _id);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        bandedGridViewTaiSan.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadAndFocused:" + ex.Message);
            }
        }

        private void barBtnThemTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddTaiSan frm = new frmAddTaiSan();
            frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void barBtnSuaTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BandedGridView view = gridControlTaiSan.FocusedView as BandedGridView;
            if (view.GetFocusedRow() != null)
            {
                frmAddTaiSan frm = new frmAddTaiSan((view.GetFocusedRow() as TaiSanHienThi).obj);
                frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
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
                Debug.WriteLine(this.Name + "->bandedGridViewTaiSan_MasterRowEmpty:" + ex.Message);
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
                Debug.WriteLine(this.Name + "->bandedGridViewTaiSan_MasterRowGetChildList:" + ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
                gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnTim_Click:" + ex.Message);
            }
        }
    }
}
