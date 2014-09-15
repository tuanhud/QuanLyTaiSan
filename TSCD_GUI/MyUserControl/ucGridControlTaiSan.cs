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
using SHARED.Libraries;
using TSCD.Entities;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucGridControlTaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGridControlTaiSan()
        {
            InitializeComponent();
        }

        public Object DataSource
        {
            set
            {
                gridControlTaiSan.DataSource = value;
            }
        }

        public CTTaiSan CTTaiSan
        {
            get
            {
                BandedGridView view = gridControlTaiSan.FocusedView as BandedGridView;
                if (view.GetFocusedRow() != null)
                {
                    return (view.GetFocusedRow() as TaiSanHienThi).obj;
                }
                else
                    return null;
            }
        }

        public void ExpandAllGroups()
        {
            bandedGridViewTaiSan.ExpandAllGroups();
        }

        public void reloadAndFocused(Guid _id)
        {
            try
            {
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
                e.ChildList = TaiSanHienThi.Convert(c.childs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->bandedGridViewTaiSan_MasterRowGetChildList: " + ex.Message);
            }
        }
    }
}
