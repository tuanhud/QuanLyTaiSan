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
using QuanLyTaiSan.DataFilter;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhong : UserControl
    {
        ucChiTietPhong _ucChiTietPhong;
        ucChiTietThietBi _ucChiTietThietBi = new ucChiTietThietBi();
        //List<ThietBi> listThietBis = new List<ThietBi>();
        List<CoSo> listCoSos = new List<CoSo>();
        public ucQuanLyPhong()
        {
            InitializeComponent();
            listCoSos = new CoSo().getAll().ToList();
            _ucChiTietPhong = new ucChiTietPhong(listCoSos);
            _ucChiTietPhong.Dock = DockStyle.Fill;
            AddControl(_ucChiTietPhong);
            //listThietBis = new ThietBi().getAll().ToList();
            ThietBiFilter obj = new ThietBiFilter();
            List<ThietBiFilter> list = obj.getAllBy4Id(-1,-1,-1,-1);
            gridControlThietBi.DataSource = list;

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
            try
            {
                int row = gridViewThietBi.FocusedRowHandle;
                if (row < 0 && row > -9999)
                {
                    Phong obj = new Phong();
                    obj = obj.getById(Convert.ToInt32(gridViewThietBi.GetRowCellValue(gridViewThietBi.GetDataRowHandleByGroupRowHandle(row), colphong_id)));
                    _ucChiTietPhong.Dock = DockStyle.Fill;
                    AddControl(_ucChiTietPhong);
                    _ucChiTietPhong.LoadData(obj);
                }
                else if (row >= 0)
                {
                    _ucChiTietThietBi.Dock = DockStyle.Fill;
                    AddControl(_ucChiTietThietBi);
                    CTThietBi objct = new CTThietBi();
                    objct = objct.getById(Convert.ToInt32(gridViewThietBi.GetFocusedRowCellValue(colid)));
                    _ucChiTietThietBi.LoadData(objct);
                }
            }
            catch (Exception ex)
            { }
            finally { }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
        }
    }
}
