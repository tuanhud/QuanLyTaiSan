using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhong : UserControl
    {
        ucChiTietPhong uc = new ucChiTietPhong();
        ucChiTietThietBi uc2 = new ucChiTietThietBi();
        public ucQuanLyPhong()
        {
            InitializeComponent();
        }
        public void LoadDataSet(int _coso, int _day, int _tang, int _phong)
        {
            this.cTTHIETBISTableAdapter.FillBy(dataSet1.CTTHIETBIS, _coso, _day, _tang, _phong);
        }
        public void AddControl(Control _ctr)
        {
            if (splitContainerControl1.Panel2.Controls.Count==0 || !splitContainerControl1.Panel2.Controls[0].Name.Equals(_ctr.Name))
            {
                splitContainerControl1.Panel2.Controls.Clear();
                splitContainerControl1.Panel2.Controls.Add(_ctr);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int row = gridViewThietBi.FocusedRowHandle;
            if (row < 0 && row > -9999)
            {
                object obj = gridViewThietBi.GetGroupRowValue(row);
                uc.Dock = DockStyle.Fill;
                AddControl(uc);
                uc.LoadData(obj.ToString());
            }
            else if (row >= 0)
            {
                uc2.Dock = DockStyle.Fill;
                AddControl(uc2);
                int _id = Convert.ToInt32(gridViewThietBi.GetFocusedRowCellValue(colid));
                uc2.LoadData(_id);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(Control.MousePosition);
        }
    }
}
