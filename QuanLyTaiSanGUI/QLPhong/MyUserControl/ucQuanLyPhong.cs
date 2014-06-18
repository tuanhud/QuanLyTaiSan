using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhong : UserControl
    {
        ucChiTietPhong _ucChiTietPhong;
        ucChiTietThietBi uc2 = new ucChiTietThietBi();
        List<ThietBi> listThietBis = new List<ThietBi>();
        List<CoSo> listCoSos = new List<CoSo>();
        public ucQuanLyPhong()
        {
            InitializeComponent();
            listCoSos = new CoSo().getAll().ToList();
            _ucChiTietPhong = new ucChiTietPhong(listCoSos);
            _ucChiTietPhong.Dock = DockStyle.Fill;
            AddControl(_ucChiTietPhong);
            listThietBis = new ThietBi().getAll().ToList();
            gridControlThietBi.DataSource = listThietBis;

        }
        public void LoadDataSet(int _coso, int _day, int _tang, int _phong)
        {
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
                _ucChiTietPhong.Dock = DockStyle.Fill;
                AddControl(_ucChiTietPhong);
                _ucChiTietPhong.LoadData(obj.ToString());
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
        }
    }
}
