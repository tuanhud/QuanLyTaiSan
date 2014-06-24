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
using DevExpress.XtraGrid;
using DevExpress.XtraBars.Ribbon;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhong : UserControl
    {
        ucChiTietPhong _ucChiTietPhong = new ucChiTietPhong();
        ucChiTietThietBi _ucChiTietThietBi = new ucChiTietThietBi();
        List<ThietBiFilter> listThietBis = new List<ThietBiFilter>();
        List<ViTriFilter> listVitris = new List<ViTriFilter>();
        List<Phong> listPhong = new List<Phong>();
        Phong objPhong;
        CTThietBi objChiTietTB;

        public ucQuanLyPhong()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            ribbonPhong.Parent = null;
            listVitris = new ViTriFilter().getAll().ToList();
            _ucChiTietPhong.loadData(listVitris);
            _ucChiTietPhong.Dock = DockStyle.Fill;
            //AddControl(_ucChiTietPhong);
            listPhong = new Phong().getPhongByViTri(-1, -1, -1);
            gridControlPhong.DataSource = listPhong;
        }

        public void reLoad()
        {
            gridControlPhong.DataSource = null;
            listPhong = new Phong().getPhongByViTri(-1, -1, -1);
            gridControlPhong.DataSource = listPhong;
        }

        public void setData(int _phongid, int _cosoid, int _dayid, int _tangid)
        {
            listPhong = new Phong().getPhongByViTri(_cosoid, _dayid, _tangid);
            gridControlPhong.DataSource = null;
            gridControlPhong.DataSource = listPhong;
            if (listPhong.Count == 0)
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
            //if (this.ParentForm != null)
            //{
            //    frmMain frm = this.ParentForm as frmMain;
            //    frm.enableGroupPhong(_type);
            //}
        }

        public Phong getPhong()
        {
            return objPhong;
        }

        private void gridViewThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int row = gridViewPhong.FocusedRowHandle;
                Phong obj = new Phong();
                obj = obj.getById(Convert.ToInt32(gridViewPhong.GetRowCellValue(gridViewPhong.GetDataRowHandleByGroupRowHandle(row), id)));
                _ucChiTietPhong.Dock = DockStyle.Fill;
                AddControl(_ucChiTietPhong);
                _ucChiTietPhong.setData(obj);
                enableGroupPhong(typeof(Phong).Name);
                objPhong = obj;
            }
            catch (Exception ex)
            { }
            finally { }
        }
        public void addObj()
        {
            _ucChiTietPhong.enableEdit(true, typeof(Phong).Name, "add");
            _ucChiTietPhong.beforeAdd();
            _ucChiTietPhong.SetTextGroupControl("Thêm phòng", true);
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
                            if (objPhong.countThietBi() > 0)
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

        private void gridViewThietBi_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            gridViewPhong.GetDetailView(e.RowHandle, e.RelationIndex).Focus();
        }

        private void barButtonThemPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        //    ViTri obj = new ViTri();
        //    obj = _ucTreePhong.getVitri();
        //    MessageBox.Show(obj.coso.ten + (obj.tang != null ? obj.tang.ten : "") + (obj.day != null ? obj.day.ten : ""));
        }

        private void barButtonSuaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Phong obj2 = new Phong();
            //obj2 = _ucQuanLyPhong.getPhong();
            //ViTri obj = obj2.vitri;
            //MessageBox.Show(obj2.ten + " " + obj.coso.ten + (obj.day != null ? obj.day.ten : "") + (obj.tang != null ? obj.tang.ten : ""));
        }

        private void barButtonXoaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Phong obj2 = new Phong();
            //obj2 = _ucQuanLyPhong.getPhong();
            //ViTri obj = obj2.vitri;
            //_ucQuanLyPhong.deleteObj(typeof(Phong).Name);
            //MessageBox.Show(obj2.ten + " " + obj.coso.ten + (obj.day != null ? obj.day.ten : "") + (obj.tang != null ? obj.tang.ten : ""));
        }

        public RibbonControl getRibbon()
        {
            return ribbonPhong;
        }
    }
}
