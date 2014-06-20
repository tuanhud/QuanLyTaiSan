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
        List<ThietBiFilter> listThietBis = new List<ThietBiFilter>();
        List<TreeDataFilter> listCoSos = new List<TreeDataFilter>();
        Phong objPhong;
        CTThietBi objChiTietTB;
        public ucQuanLyPhong()
        {
            InitializeComponent();
            listCoSos = new TreeDataFilter().getAll().ToList();
            _ucChiTietPhong = new ucChiTietPhong(listCoSos);
            _ucChiTietPhong.Dock = DockStyle.Fill;
            AddControl(_ucChiTietPhong);
            //listThietBis = new ThietBi().getAll().ToList();
            ThietBiFilter obj = new ThietBiFilter();
            listThietBis = obj.getAllBy4Id(-1, -1, -1, -1);
            gridControlThietBi.DataSource = listThietBis;

        }
        public void loadData(int _phongid, int _cosoid, int _dayid, int _tangid)
        {
            listThietBis = new ThietBiFilter().getAllBy4Id(_phongid, _cosoid, _dayid, _tangid);
            gridControlThietBi.DataSource = null;
            gridControlThietBi.DataSource = listThietBis;
            if(listThietBis.Count == 0)
                showDetailPhong(_phongid);
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
                    enableGroupPhong(typeof(Phong).Name);
                    objPhong = obj;
                }
                else if (row >= 0)
                {
                    _ucChiTietThietBi.Dock = DockStyle.Fill;
                    AddControl(_ucChiTietThietBi);
                    CTThietBi objct = new CTThietBi();
                    objct = objct.getById(Convert.ToInt32(gridViewThietBi.GetFocusedRowCellValue(colid)));
                    _ucChiTietThietBi.LoadData(objct);
                    enableGroupPhong(typeof(ThietBi).Name);
                    objChiTietTB = objct;
                }
            }
            catch (Exception ex)
            { }
            finally { }
        }

        private void showDetailPhong(int _id)
        {
            Phong obj = new Phong().getById(_id);
            _ucChiTietPhong.Dock = DockStyle.Fill;
            AddControl(_ucChiTietPhong);
            _ucChiTietPhong.LoadData(obj);
            if (_id == -1)
                enableGroupPhong("other");
            else
            {
                enableGroupPhong(typeof(Phong).Name);
                objPhong = obj;
            }

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
        }

        private void enableGroupPhong(String _type)
        {
            if (this.ParentForm != null)
            {
                frmMain frm = this.ParentForm as frmMain;
                frm.enableGroupPhong(_type);
            }
        }

        public Phong getPhong()
        {
            return objPhong;
        }

        public CTThietBi getCTThietBi()
        {
            return objChiTietTB;
        }
    }
}
