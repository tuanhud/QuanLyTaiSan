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
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhong : UserControl
    {
        ucChiTietPhong _ucChiTietPhong = new ucChiTietPhong();
        ucChiTietThietBi _ucChiTietThietBi = new ucChiTietThietBi();
        List<ThietBiFilter> listThietBis = new List<ThietBiFilter>();
        List<ViTriFilter> listVitris = new List<ViTriFilter>();
        Phong objPhong;
        CTThietBi objChiTietTB;
        public ucQuanLyPhong()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            listVitris = new ViTriFilter().getAll().ToList();
            _ucChiTietPhong.loadData(listVitris);
            _ucChiTietPhong.Dock = DockStyle.Fill;
            AddControl(_ucChiTietPhong);
            //listThietBis = new ThietBi().getAll().ToList();
            ThietBiFilter obj = new ThietBiFilter();
            listThietBis = obj.getAllBy4Id(-1, -1, -1, -1);
            gridControlThietBi.DataSource = listThietBis;

        }

        private void reLoad()
        {
            //listVitris = new ViTriFilter().getAll().ToList();
            //_ucChiTietPhong.loadData(listVitris);
            //_ucChiTietPhong.Dock = DockStyle.Fill;
            //AddControl(_ucChiTietPhong);
            //listThietBis = new ThietBi().getAll().ToList();
            gridControlThietBi.DataSource = null;
            ThietBiFilter obj = new ThietBiFilter();
            listThietBis = obj.getAllBy4Id(-1, -1, -1, -1);
            gridControlThietBi.DataSource = listThietBis;
        }

        public void setData(int _phongid, int _cosoid, int _dayid, int _tangid)
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

        }

        private void showDetailPhong(int _id)
        {
            Phong obj = new Phong().getById(_id);
            _ucChiTietPhong.Dock = DockStyle.Fill;
            AddControl(_ucChiTietPhong);
            _ucChiTietPhong.setData(obj);
            if (_id == -1)
                enableGroupPhong("other");
            else
            {
                enableGroupPhong(typeof(Phong).Name);
                objPhong = obj;
            }

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

        private void gridViewThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
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
                    _ucChiTietPhong.setData(obj);
                    enableGroupPhong(typeof(Phong).Name);
                    objPhong = obj;
                }
                else if (row >= 0)
                {
                    _ucChiTietThietBi.Dock = DockStyle.Fill;
                    AddControl(_ucChiTietThietBi);
                    CTThietBi objct = new CTThietBi();
                    int temp = Convert.ToInt32(gridViewThietBi.GetFocusedRowCellValue(colid));
                    objct = objct.getById(Convert.ToInt32(gridViewThietBi.GetFocusedRowCellValue(colid)));
                    _ucChiTietThietBi.setData(objct);
                    enableGroupPhong(typeof(ThietBi).Name);
                    objChiTietTB = objct;
                }
            }
            catch (Exception ex)
            { }
            finally { }
        }

        public void deleteObj(String _type)
        {
            switch (_type)
            {
                case "Phong":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa phòng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        XtraMessageBox.Show(objPhong.id.ToString());
                        if (objPhong.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa phòng thành công!");
                            reLoad();
                        }
                        else
                        {
                            if (-1 == -1)
                            {
                                XtraMessageBox.Show("Có thiết bị trong phòng. Vui lòng xóa thiết bị trước!");
                            }
                            else
                            {
                                XtraMessageBox.Show("Phòng có chứa Log tình trạng. Không thể xóa!");
                            }
                        }
                    }
                    break;
                case "ThietBi":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa thiết bị?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Phong obj = objChiTietTB.phong;
                        if (objChiTietTB.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa thiết bị thành công!");
                            reLoad();
                        }
                        else
                        {
                            XtraMessageBox.Show("Có lỗi trong khi xóa thiết bị!");
                        }
                    }
                    break;
            }
        }
    }
}
