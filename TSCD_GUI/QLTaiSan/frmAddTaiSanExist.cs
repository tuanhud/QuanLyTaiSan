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
using SHARED.Libraries;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmAddTaiSanExist : DevExpress.XtraEditors.XtraForm
    {
        List<CTTaiSan> listCTTaiSan = null;
        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;
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
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BandedGridView view = gridControlTaiSan.FocusedView as BandedGridView;
            if (view.GetFocusedRow() != null)
            {
                CTTaiSan obj = (view.GetFocusedRow() as TaiSanHienThi).obj;
                listCTTaiSan.Add(obj);
                if (reloadAndFocused != null)
                    reloadAndFocused(obj.id);
                this.Close();
            }
        }

        private void bandedGridViewTaiSan_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            TaiSanHienThi c = (TaiSanHienThi)bandedGridViewTaiSan.GetRow(e.RowHandle);
            e.IsEmpty = c.childs == null || c.childs.Count == 0;
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
            TaiSanHienThi c = (TaiSanHienThi)bandedGridViewTaiSan.GetRow(e.RowHandle);
            e.ChildList = TaiSanHienThi.Convert(new List<CTTaiSan>(c.childs));
        }
    }
}