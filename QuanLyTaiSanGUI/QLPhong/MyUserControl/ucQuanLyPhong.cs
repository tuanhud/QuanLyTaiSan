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
using DevExpress.XtraGrid.Views.Base;

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

        //List<ThietBiFilter> listThietBis = new List<ThietBiFilter>();
        List<ViTriHienThi> listVitris = new List<ViTriHienThi>();

        List<Phong> listPhong = new List<Phong>();

        List<NhanVienPT> listNhanVienPT = new List<NhanVienPT>();
        List<HinhAnh> listHinhAnhPhong = new List<HinhAnh>();
        List<HinhAnh> listHinhAnhNhanVien = new List<HinhAnh>();

        ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLPhong");
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, false);

        String function = "";
        int _idnhanvien = 0;

        public ucQuanLyPhong()
        {
            InitializeComponent();
            //loadData();
            //enableEdit(false, "");
            //enableBar(false);
        }

        // Load dữ liệu
        public void loadData()
        {
            enableEdit(false, "");
            enableBar(false);
            listVitris = ViTriHienThi.getAll().ToList();

            _ucTreeViTri.loadData(listVitris);
            _ucTreeViTri.Parent = this;
            _ucComboBoxViTri.loadData(listVitris);
            _ucComboBoxViTri.Dock = DockStyle.Fill;

            panelControl1.Controls.Add(_ucComboBoxViTri);
            ribbonPhong.Parent = null;
            ViTri obj = _ucTreeViTri.getVitri();
            listPhong = Phong.getPhongByViTri(obj.coso != null ? obj.coso.id : -1, obj.day != null ? obj.day.id : -1, obj.tang != null ? obj.tang.id : -1);
            gridControlPhong.DataSource = listPhong;
            getInfoPhongNhanVien(true);

            listNhanVienPT = NhanVienPT.getAll();
        }

        //Mở tắt bar
        public void enableBar(bool _enable)
        {
            //if (_enable)
            //{
            //    barButtonSuaPhong.Enabled = true;
            //    barButtonXoaPhong.Enabled = true;
            //}
            //else
            //{
            //    barButtonSuaPhong.Enabled = false;
            //    barButtonXoaPhong.Enabled = false;
            //}
            barButtonSuaPhong.Enabled = _enable;
            barButtonXoaPhong.Enabled = _enable;
        }

        //Xóa hết dữ liệu form thông tin phòng + nhân viên
        public void resetAll()
        {
            imgPhong.Images.Clear();
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtMoTaPhong.Text = "";
            imgNhanVien.Images.Clear();
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtSoDienThoai.Text = "";
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
                listPhong = Phong.getPhongByViTri(cosoid, dayid, tangid);
                gridControlPhong.DataSource = listPhong;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        //Khi thêm mới cơ sở -> phòng thì load treelist bên trái + reload dữ liệu ucQuanLyPhong
        public void reLoadAll()
        {
            try
            {
                listVitris = ViTriHienThi.getAll().ToList();
                _ucTreeViTri.loadData(listVitris);
                reLoad();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }


        //FocusedRowChanged in TreePhong
        public void setData(int _cosoid, int _dayid, int _tangid)
        {
            try
            {
                cosoid = _cosoid;
                dayid = _dayid;
                tangid = _tangid;
                listPhong = Phong.getPhongByViTri(_cosoid, _dayid, _tangid);
                gridControlPhong.DataSource = listPhong;
                switch (listPhong.Count)
                {
                    case 0:
                        _ucComboBoxViTri.Visible = false;
                        resetAll();
                        enableEdit(false, "");
                        enableBar(false);
                        break;
                    default:
                        getInfoPhongNhanVien(true);
                        _ucComboBoxViTri.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
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
                    listHinhAnhPhong = new List<HinhAnh>();
                else
                    listHinhAnhPhong = objPhong.hinhanhs.ToList();
                if (objPhong.nhanvienpt != null)
                {
                    if (objPhong.nhanvienpt.hinhanhs == null)
                        listHinhAnhNhanVien = new List<HinhAnh>();
                    else
                        listHinhAnhNhanVien = objPhong.nhanvienpt.hinhanhs.ToList();
                }
                else
                {
                    listHinhAnhNhanVien = new List<HinhAnh>();
                }
                reloadImagePhong();


                reloadImageNhanVienPT();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        //chỉnh sửa phòng
        private void ChinhSuaPhong()
        {
            try
            {
                if (listHinhAnhPhong != null)
                {
                    objPhong.hinhanhs = listHinhAnhPhong;
                }
                objPhong.subId = txtMaPhong.Text;
                objPhong.ten = txtTenPhong.Text;
                objPhong.vitri = _ucComboBoxViTri.getViTri();
                objPhong.mota = txtMoTaPhong.Text;
                if (_idnhanvien > -1)
                    objPhong.nhanvienpt = NhanVienPT.getById(_idnhanvien);
                else objPhong.nhanvienpt = null;
                if (objPhong.update() != -1)
                {
                    //XtraMessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reLoadAndFocused(objPhong.id);
                }
                else XtraMessageBox.Show("Có lỗi trong khi chỉnh sửa");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void reLoadAndFocused(int _id)
        {
            try
            {
                reLoad();
                int rowHandle = gridViewPhong.LocateByValue(colid.FieldName, _id);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    gridViewPhong.FocusedRowHandle = rowHandle;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        //thêm phòng
        private void ThemPhong()
        {
            try
            {
                Phong objPhongNew = new Phong();
                objPhongNew.subId = txtMaPhong.Text;
                objPhongNew.ten = txtTenPhong.Text;
                objPhongNew.mota = txtMoTaPhong.Text;
                objPhongNew.hinhanhs = listHinhAnhPhong;
                objPhongNew.vitri = _ucComboBoxViTri.getViTri();
                objPhongNew.nhanvienpt = NhanVienPT.getById(_idnhanvien);
                if (objPhongNew.add() != -1)
                {
                    XtraMessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reLoad();
                }
                else XtraMessageBox.Show("Có lỗi trong khi thêm");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
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
            try
            {
                imgPhong.Images.Clear();
                foreach (HinhAnh h in listHinhAnhPhong)
                {
                    imgPhong.Images.Add(h.getImage());
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        //load lại ảnh nhân viên
        private void reloadImageNhanVienPT()
        {
            try
            {
                imgNhanVien.Images.Clear();
                foreach (HinhAnh h in listHinhAnhNhanVien)
                {
                    imgNhanVien.Images.Add(h.getImage());
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        //xóa phòng
        public void XoaPhong()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc là muốn xóa phòng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (objPhong.delete() != -1)
                    {
                        XtraMessageBox.Show("Xóa phòng thành công!");
                        reLoad();
                        //reLoadAndFocused(objPhong.id);
                    }
                    else
                    {
                        if (objPhong.countThietBi() > 0)
                        {
                            XtraMessageBox.Show("Có thiết bị trong phòng. Vui lòng xóa thiết bị trước!");
                        }
                        else
                        {
                            XtraMessageBox.Show("Lỗi trong khi xóa phòng!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void barButtonThemPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void barButtonSuaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                searchLookUpEditNhanVienPT.Properties.DataSource = listNhanVienPT;

                //_index = gridViewPhong.FocusedRowHandle;
                SetTextGroupControl("Chỉnh sửa phòng", true);

                if (objPhong.nhanvienpt != null)
                    searchLookUpEditNhanVienPT.EditValue = objPhong.nhanvienpt.id;
                getInfoPhongNhanVien(false);
                enableEdit(true, "edit");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void barButtonXoaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                XoaPhong();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
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
            getInfoPhongNhanVien(false);
        }

        //Truyền thông tin phòng + nhân viên khi thay đổi dòng gridview
        private void getInfoPhongNhanVien(bool getfirst)
        {
            try
            {
                enableBar(true);
                if (getfirst) row = 0;
                else row = gridViewPhong.FocusedRowHandle;
                Phong obj = new Phong();
                obj = Phong.getById(Convert.ToInt32(gridViewPhong.GetRowCellValue(gridViewPhong.GetDataRowHandleByGroupRowHandle(row), id)));
                setData(obj);
                objPhong = obj;

                SetTextGroupControl("Chi tiết", false);
                dxErrorProvider.ClearErrors();
                listHinhAnhPhong = null;
                listHinhAnhNhanVien = null;
                enableEdit(false, "");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            listHinhAnhPhong = null;
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
                    frm = new frmHinhAnh(listHinhAnhPhong);
                    frm.Text = "Quản lý hình ảnh " + objPhong.ten;
                    frm.ShowDialog();
                    listHinhAnhPhong = frm.getlistHinhs();
                }
                else
                {
                    frm = new frmHinhAnh(listHinhAnhPhong);
                    frm.Text = "Quản lý hình ảnh phòng mới";
                    frm.ShowDialog();
                    listHinhAnhPhong = frm.getlistHinhs();
                }
                reloadImagePhong();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
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
                    objPhong.nhanvienpt = NhanVienPT.getById(_idnhanvien);
                    txtMaNhanVien.Text = objPhong.nhanvienpt.subId;
                    txtTenNhanVien.Text = objPhong.nhanvienpt.hoten;
                    txtSoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                    listHinhAnhNhanVien = objPhong.nhanvienpt.hinhanhs.ToList();
                    reloadImageNhanVienPT();
                }
                else
                {
                    _idnhanvien = -1;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
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
                case Keys.X:
                case Keys.Delete:
                    this.barButtonXoaPhong.PerformClick();
                    break;
            }
        }

        private void gridViewPhong_Click(object sender, EventArgs e)
        {
            getInfoPhongNhanVien(false);
        }
    }
}