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
using QuanLyTaiSanGUI.MyUC;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhong : UserControl
    {
        CoSo objCoSo = new CoSo();
        Dayy objDay = new Dayy();
        Tang objTang = new Tang();
        Phong objPhong = new Phong();
        NhanVienPT objNhanVienPT = new NhanVienPT();

        int row, cosoid, dayid, tangid = 0;

        List<ThietBiFilter> listThietBis = new List<ThietBiFilter>();
        List<ViTriHienThi> listVitris = new List<ViTriHienThi>();
        
        List<Phong> listPhong = new List<Phong>();
        List<HinhAnh> listHinh = new List<HinhAnh>();
        List<HinhAnh> listHinhNV = new List<HinhAnh>();
        List<NhanVienPT> listNhanVienPT = new List<NhanVienPT>();

        ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLPhong");
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, false);     

        String function = "";
        int _idnhanvien = 0;

        public ucQuanLyPhong()
        {
            InitializeComponent();
            loadData();
            enableEdit(false, "");
            enableBar(false);
            _ucTreeViTri.expandAll = true;
        }

        // Load dữ liệu
        public void loadData()
        {
            listVitris = new ViTriHienThi().getAll().ToList();

            _ucTreeViTri.loadData(listVitris);
            _ucTreeViTri.Parent = this;
            _ucComboBoxViTri.loadData(listVitris);
            _ucComboBoxViTri.Dock = DockStyle.Fill;

            panelControl1.Controls.Add(_ucComboBoxViTri);
            ribbonPhong.Parent = null;
            ViTri obj = _ucTreeViTri.getVitri();
            listPhong = new Phong().getPhongByViTri(obj.coso != null ? obj.coso.id : -1, obj.day != null ? obj.day.id : -1, obj.tang != null ? obj.tang.id : -1);
            gridControlPhong.DataSource = listPhong;
            
            listNhanVienPT = objNhanVienPT.getAll();
        }

        //Mở tắt bar
        public void enableBar(bool _enable)
        {
            if (_enable)
            {
                barButtonSuaPhong.Enabled = true;
                barButtonXoaPhong.Enabled = true;
            }
            else
            {
                barButtonSuaPhong.Enabled = false;
                barButtonXoaPhong.Enabled = false;
            }
        }
        //Mở/tắt chỉnh sửa form
        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnImage.Visible = true;
                btnOK.Visible = true;
                btnHuy.Visible = true;
                txtMaPhong.Properties.ReadOnly = false;
                txtTenPhong.Properties.ReadOnly = false;
                txtMoTaPhong.Properties.ReadOnly = false;
                _ucComboBoxViTri.setReadOnly(false);
                lblNhanVienPT.Visible = true;
                searchLookUpEditNhanVienPT.Visible = true;
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtMaPhong.Properties.ReadOnly = true;
                txtTenPhong.Properties.ReadOnly = true;
                txtMoTaPhong.Properties.ReadOnly = true;
                _ucComboBoxViTri.setReadOnly(true);
                lblNhanVienPT.Visible = false;
                searchLookUpEditNhanVienPT.Visible = false;
            }
        }

        // Reload dữ liệu
        public void reLoad()
        {
            try
            {
                _ucTreeViTri.setVitri(objPhong.vitri);
                gridControlPhong.DataSource = null;
                listPhong = new Phong().getPhongByViTri(cosoid, dayid, tangid);
                gridControlPhong.DataSource = listPhong;
            }
            catch
            { }
            finally
            { }
        }

        //Khi thêm mới cơ sở -> phòng thì load treelist bên trái + reload dữ liệu ucQuanLyPhong
        public void reLoadAll()
        {
            listVitris = new ViTriHienThi().getAll().ToList();
            _ucTreeViTri.loadData(listVitris);
            reLoad();
        }


        //FocusedRowChanged in TreePhong
        public void setData(int _cosoid, int _dayid, int _tangid)
        {
            cosoid = _cosoid;
            dayid = _dayid;
            tangid = _tangid;
            //listPhong = new Phong().getPhongByViTri(_cosoid, _dayid, _tangid);
            ViTri obj = new ViTri().getBy3Id(_cosoid, _dayid, _tangid);
            if (obj != null)
            {
                listPhong = obj.phongs.ToList();
                gridControlPhong.DataSource = listPhong;
            }
            else
                gridControlPhong.DataSource = null;
            if (listPhong.Count == 0)
            {
                _ucComboBoxViTri.Visible = false;
                enableEdit(false, "");
                enableBar(false);
            }
            else
            {
                _ucComboBoxViTri.Visible = true;
            }
        }

        public Phong getPhong()
        {
            return objPhong;
        }

        public void setData(Phong _phong)
        {
            try
            {
                if (_phong != null)
                {
                    objPhong = _phong;
                }
                else
                {
                    objPhong = new Phong();
                }
                txtMaPhong.Text = objPhong.subId;
                txtTenPhong.Text = objPhong.ten;
                txtMoTaPhong.Text = objPhong.mota;
                _ucComboBoxViTri.setViTri(objPhong.vitri);
                NhanVienPT objNV = new NhanVienPT();
                if (objPhong.nhanvienpt != null)
                {
                    objNV = objPhong.nhanvienpt;
                }
                txtMaNhanVien.Text = objNV.subId;
                txtTenNhanVien.Text = objNV.hoten;
                txtSoDienThoai.Text = objNV.sodienthoai;
                if (objPhong.hinhanhs == null)
                    listHinh = new List<HinhAnh>();
                else
                    listHinh = objPhong.hinhanhs.ToList();
                if (objPhong.nhanvienpt != null)
                {
                    if (objPhong.nhanvienpt.hinhanhs == null)
                        listHinhNV = new List<HinhAnh>();
                    else
                        listHinhNV = objPhong.nhanvienpt.hinhanhs.ToList();
                }
                else
                {
                    listHinhNV = new List<HinhAnh>();
                }
                reloadImagePhong();
                reloadImageNhanVienPT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { }
        }

        //chỉnh sửa phòng
        private void ChinhSuaPhong()
        {
            if (listHinh != null)
            {
                objPhong.hinhanhs = listHinh;
            }
            objPhong.subId = txtMaPhong.Text;
            objPhong.ten = txtTenPhong.Text;
            objPhong.vitri = _ucComboBoxViTri.getViTri();
            objPhong.mota = txtMoTaPhong.Text;
            //objPhong.nhanvienpt.id = _idnhanvien;// == -1 ? null : _idnhanvien;
            if (_idnhanvien > -1)
                objPhong.nhanvienpt = new NhanVienPT().getById(_idnhanvien);
            else objPhong.nhanvienpt = null;
            if (objPhong.update() != -1)
            {
                XtraMessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reLoadAndFocused(objPhong.id);
            }
            else XtraMessageBox.Show("Có lỗi trong khi chỉnh sửa");
        }

        private void reLoadAndFocused(int _id)
        {
            reLoad();
            int rowHandle = gridViewPhong.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewPhong.FocusedRowHandle = rowHandle;
        }

        //thêm phòng
        private void ThemPhong()
        {
            Phong objPhongNew = new Phong();
            objPhongNew.subId = txtMaPhong.Text;
            objPhongNew.ten = txtTenPhong.Text;
            objPhongNew.mota = txtMoTaPhong.Text;
            objPhongNew.hinhanhs = listHinh;
            objPhongNew.vitri = _ucComboBoxViTri.getViTri();
            objPhongNew.nhanvienpt = new NhanVienPT().getById(_idnhanvien);
            if (objPhongNew.add() != -1)
            {
                XtraMessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reLoad();
            }
            else XtraMessageBox.Show("Có lỗi trong khi thêm");
        }

        //set màu tiêu đề group
        public void SetTextGroupControl(String _text, bool _color)
        {
            groupControl1.Text = _text;
            if (_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Black;
        }

        // kiểm tra dữ liệu trước khi lưu
        private Boolean CheckInput()
        {
            dxErrorProvider.ClearErrors();
            Boolean check = true;
            //if (imgPhong.Images.Count == 0)
            //{
            //    check = false;
            //    dxErrorProvider.SetError(imgPhong, "Cần ít nhất 1 hình ảnh");
            //}
            if (txtTenPhong.Text.Length == 0)
            {
                check = false;
                dxErrorProvider.SetError(txtTenPhong, "Chưa điền tên");
            }
            return check;
        }

        //load lại ảnh phòng
        private void reloadImagePhong()
        {
            imgPhong.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imgPhong.Images.Add(h.getImage());
            }
        }

        //load lại ảnh nhân viên
        private void reloadImageNhanVienPT()
        {
            imgNhanVien.Images.Clear();
            foreach (HinhAnh h in listHinhNV)
            {
                imgNhanVien.Images.Add(h.getImage());
            }
        }

        //xóa phòng
        public void XoaPhong()
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa phòng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (objPhong.delete() != -1)
                {
                    XtraMessageBox.Show("Xóa phòng thành công!");
                    reLoad();
                    reLoadAndFocused(objPhong.id);
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
        }

        private void barButtonThemPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridViewPhong.AddNewRow();
            //int rowHandler = gridViewPhong.RowCount - 1;
            //gridViewPhong.FocusedRowHandle = rowHandler;
            searchLookUpEditNhanVienPT.Properties.DataSource = listNhanVienPT;
            enableEdit(true, "add");
            beforeAdd();
            SetTextGroupControl("Thêm phòng mới", true);
            searchLookUpEditNhanVienPT.EditValue = null;
            _ucComboBoxViTri.Visible = true;
            ViTri _ViTri = _ucTreeViTri.getVitri();
            _ucComboBoxViTri.setViTri(_ViTri);
        }

        private void barButtonSuaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            searchLookUpEditNhanVienPT.Properties.DataSource = listNhanVienPT;
            enableEdit(true, "edit");
            //_index = gridViewPhong.FocusedRowHandle;
            SetTextGroupControl("Chỉnh sửa phòng", true);
            if (objPhong.nhanvienpt != null)
                searchLookUpEditNhanVienPT.EditValue = objPhong.nhanvienpt.id;
        }

        private void barButtonXoaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                XoaPhong();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không có gì để xóa");
                enableBar(false);
            }
        }

        public RibbonControl getRibbon()
        {
            return ribbonPhong;
        }

        public TreeList getTreeList()
        {
            return _ucTreeViTri.getTreeList();
        }

        private void gridViewPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            getInfoPhongNhanVien();
        }

        //Truyền thông tin phòng + nhân viên khi thay đổi dòng gridview
        private void getInfoPhongNhanVien()
        {
            try
            {
                enableBar(true);
                row = gridViewPhong.FocusedRowHandle;
                Phong obj = new Phong();
                obj = obj.getById(Convert.ToInt32(gridViewPhong.GetRowCellValue(gridViewPhong.GetDataRowHandleByGroupRowHandle(row), id)));
                setData(obj);
                objPhong = obj;

                SetTextGroupControl("Chi tiết", false);
                dxErrorProvider.ClearErrors();
                listHinh = null;
                listHinhNV = null;
                enableEdit(false, "");
            }
            catch (Exception ex)
            { }
            finally { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            listHinh = null;
            setData(objPhong);
            enableEdit(false, "");
            //reloadImageNhanVienPT();
            //reLoad();
            //gridViewPhong.FocusedRowHandle = row;
            //reLoadAndFocused(objPhong.id);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                switch (function)
                {
                    case "edit":
                        ChinhSuaPhong();
                        break;
                    case "add":
                        ThemPhong();
                        break;
                }
                enableEdit(false, "");
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = null;

                if (function.Equals("edit"))
                {
                    frm = new frmHinhAnh(listHinh);
                    frm.Text = "Quản lý hình ảnh " + objPhong.ten;
                    frm.ShowDialog();
                    listHinh = frm.getlistHinhs();
                }
                else
                {
                    frm = new frmHinhAnh(listHinh);
                    frm.Text = "Quản lý hình ảnh phòng mới";
                    frm.ShowDialog();
                    listHinh = frm.getlistHinhs();
                }
                reloadImagePhong();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        public void beforeAdd()
        {
            //clear textbox-img phòng
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtMoTaPhong.Text = "";
            imgPhong.Images.Clear();
            //clear textbox-img nhân viên
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtSoDienThoai.Text = "";
            imgNhanVien.Images.Clear();
        }
        
        private void searchLookUpEditNhanVienPT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchLookUpEditNhanVienPT.EditValue != null)
                {
                    // set hình ảnh và thông tin nhân viên phụ trách khi được chọn
                    _idnhanvien = Int32.Parse(searchLookUpEditNhanVienPT.EditValue.ToString());
                    objPhong.nhanvienpt = new NhanVienPT().getById(_idnhanvien);
                    txtMaNhanVien.Text = objPhong.nhanvienpt.subId;
                    txtTenNhanVien.Text = objPhong.nhanvienpt.hoten;
                    txtSoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                    listHinhNV = objPhong.nhanvienpt.hinhanhs.ToList();
                    reloadImageNhanVienPT();
                }
                else
                {
                    _idnhanvien = -1;
                }
            }
            catch(Exception ex)
            {

            }
        }

        //Thêm xóa sửa bằng phím tắt
        private void gridViewPhong_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.T:
                    this.barButtonThemPhong.PerformClick();
                    break;
                case Keys.S:
                    this.barButtonSuaPhong.PerformClick();
                    break;
                case Keys.X : case Keys.Delete:
                    this.barButtonXoaPhong.PerformClick();
                    break;
            }
        }
    }
}
