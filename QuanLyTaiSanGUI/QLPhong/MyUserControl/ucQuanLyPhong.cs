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
        ViTri _ViTriHienTai = new ViTri();
        Phong objPhong = new Phong();
        NhanVienPT objNhanVienPT = new NhanVienPT();

        int cosoid, dayid, tangid;

        List<ViTriHienThi> listVitris = new List<ViTriHienThi>();
        List<Phong> listPhong = new List<Phong>();
        List<NhanVienPT> listNhanVienPT = new List<NhanVienPT>();

        List<HinhAnh> listHinhAnhPhong = new List<HinhAnh>();
        List<HinhAnh> listHinhAnhNhanVien = new List<HinhAnh>();

        ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLPhong");
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, false);
        String function = "";

        public ucQuanLyPhong()
        {
            InitializeComponent();
        }

        // Load dữ liệu
        public void loadData()
        {
            listVitris = ViTriHienThi.getAll().ToList();

            _ucTreeViTri.loadData(listVitris);
            _ucTreeViTri.Parent = this;

            _ucComboBoxViTri.loadData(listVitris);
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(_ucComboBoxViTri);
            ribbonPhong.Parent = null;

            _ViTriHienTai = _ucTreeViTri.getVitri();
            listPhong = Phong.getPhongByViTri(_ViTriHienTai.coso != null ? _ViTriHienTai.coso.id : -1, _ViTriHienTai.day != null ? _ViTriHienTai.day.id : -1, _ViTriHienTai.tang != null ? _ViTriHienTai.tang.id : -1);
            gridControlPhong.DataSource = listPhong;
            if (listPhong.Count() == 0)
            {
                deleteData();
                enableBar(false);
                enableEdit(false);
            }
            else
            {
                getThongTinPhong(true);
                enableBar(true);
                enableEdit(false);
            }

            listNhanVienPT = NhanVienPT.getAll();
            NhanVienPT NhanVienPTNULL = new NhanVienPT();
            NhanVienPTNULL.hoten = "[Không có]";
            NhanVienPTNULL.id = -1;
            listNhanVienPT.Insert(0, NhanVienPTNULL);
            searchLookUpEditNhanVienPT.Properties.DataSource = listNhanVienPT;
        }

        //Mở tắt bar
        public void enableBar(bool _enable)
        {
            barButtonSuaPhong.Enabled = _enable;
            barButtonXoaPhong.Enabled = _enable;
        }

        //Xóa hết dữ liệu form thông tin phòng + nhân viên
        private void deleteData()
        {
            setTextGroupControl("Chi thiết phòng", Color.Black);
            function = "";
            dxErrorProvider.ClearErrors();
            imgPhong.Images.Clear();
            listHinhAnhPhong = null;
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtMoTaPhong.Text = "";
            if (listVitris.Count > 0)
                _ucComboBoxViTri.setViTri(_ViTriHienTai);
            searchLookUpEditNhanVienPT.EditValue = -1;

            objNhanVienPT = null;
            imgNhanVien.Images.Clear();
            listHinhAnhNhanVien = null;
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtSoDienThoai.Text = "";
        }

        //Mở/tắt chỉnh sửa form
        public void enableEdit(bool _enable)
        {
            btnImage.Visible = _enable;
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtMaPhong.Properties.ReadOnly = !_enable;
            txtTenPhong.Properties.ReadOnly = !_enable;
            txtMoTaPhong.Properties.ReadOnly = !_enable;
            _ucComboBoxViTri.setReadOnly(!_enable);
            lblNhanVienPT.Visible = _enable;
            searchLookUpEditNhanVienPT.Visible = _enable;
        }

        // Reload dữ liệu
        public void reLoad()
        {
            try
            {
                _ucComboBoxViTri = new ucComboBoxViTri(false, false);
                _ucComboBoxViTri.loadData(listVitris);
                _ucComboBoxViTri.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucComboBoxViTri);
                _ucTreeViTri.setVitri(_ViTriHienTai);
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
                _ViTriHienTai = _ucTreeViTri.getVitri();
                cosoid = _cosoid;
                dayid = _dayid;
                tangid = _tangid;
                listPhong = Phong.getPhongByViTri(_cosoid, _dayid, _tangid);
                gridControlPhong.DataSource = listPhong;
                switch (listPhong.Count)
                {
                    case 0:
                        deleteData();
                        enableBar(false);
                        enableEdit(false);
                        break;
                    default:
                        getThongTinPhong(true);
                        enableBar(true);
                        enableEdit(false);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void setData()
        {
            try
            {
                setTextGroupControl("Chi thiết phòng", Color.Black);
                listHinhAnhPhong = new List<HinhAnh>();
                if (objPhong.hinhanhs != null)
                {
                    if (objPhong.hinhanhs.Count > 0)
                    {
                        listHinhAnhPhong = objPhong.hinhanhs.ToList();
                    }
                }
                reloadImagePhong();

                txtMaPhong.Text = objPhong.subId;
                txtTenPhong.Text = objPhong.ten;
                if (objPhong.vitri != null)
                    _ucComboBoxViTri.setViTri(objPhong.vitri);
                txtMoTaPhong.Text = objPhong.mota;

                listHinhAnhNhanVien = new List<HinhAnh>();
                if (objPhong.nhanvienpt != null)
                {
                    searchLookUpEditNhanVienPT.EditValue = objPhong.nhanvienpt.id;
                    if (objPhong.nhanvienpt.hinhanhs != null)
                    {
                        if (objPhong.nhanvienpt.hinhanhs.Count > 0)
                        {
                            listHinhAnhNhanVien = objPhong.nhanvienpt.hinhanhs.ToList();
                        }
                    }

                    txtMaNhanVien.Text = objPhong.nhanvienpt.subId;
                    txtTenNhanVien.Text = objPhong.nhanvienpt.hoten;
                    txtSoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                }
                else
                {
                    searchLookUpEditNhanVienPT.EditValue = -1;
                    imgNhanVien.Images.Clear();
                    txtMaNhanVien.Text = "";
                    txtTenNhanVien.Text = "";
                    txtSoDienThoai.Text = "";
                }
                reloadImageNhanVienPT();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void setDataObj()
        {
            try
            {
                objPhong.hinhanhs = listHinhAnhPhong;
                objPhong.subId = txtMaPhong.Text;
                objPhong.ten = txtTenPhong.Text;
                objPhong.vitri = _ucComboBoxViTri.getViTri();
                objPhong.mota = txtMoTaPhong.Text;
                if (objNhanVienPT != null)
                {
                    if (objNhanVienPT.id > 0)
                    {
                        objPhong.nhanvienpt = objNhanVienPT;
                    }
                }
                else
                    objPhong.nhanvienpt = null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }

        private void getThongTinPhong(Boolean first)
        {
            if (listPhong.Count() > 0)
            {
                int row = 0;
                if (!first)
                    row = gridViewPhong.FocusedRowHandle;
                if (row >= 0 && row < listPhong.Count())
                {
                    int id = (gridViewPhong.GetRow(row) as Phong).id;
                    objPhong = Phong.getById(id);
                    if (objPhong != null)
                    {
                        if (objPhong.nhanvienpt != null)
                        {
                            objNhanVienPT = NhanVienPT.getById(objPhong.nhanvienpt.id);
                        }
                        setData();
                        enableBar(true);
                    }
                }
                else
                {
                    deleteData();
                    enableBar(false);
                }
            }
            else
            {
                deleteData();
                enableBar(false);
            }
            enableEdit(false);
            function = "";
        }

        private void CRUD()
        {
            switch (function)
            {
                case "add":
                    objPhong = new Phong();
                    setDataObj();
                    if (objPhong.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                    }
                    else XtraMessageBox.Show("Có lỗi trong khi thêm");
                    break;
                case "edit":
                    if (objPhong != null)
                    {
                        setDataObj();
                        if (objPhong.update() != -1)
                        {
                            XtraMessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoad();
                        }
                        else XtraMessageBox.Show("Có lỗi trong khi sửa");
                    }
                    break;
                case "delete":
                    if (objPhong != null)
                    {
                        if (objPhong.countThietBi() > 0)
                        {
                            XtraMessageBox.Show("Có thiết bị trong phòng. Vui lòng xóa thiết bị trước!");
                        }
                        else
                        {
                            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa phòng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (objPhong.delete() != -1)
                                {
                                    XtraMessageBox.Show("Xóa phòng thành công!");
                                    reLoad();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Lỗi trong khi xóa phòng!");
                                }
                            }
                        }
                    }
                    break;
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

        //set màu tiêu đề group
        public void setTextGroupControl(String _text, Color _color)
        {
            groupControl1.Text = _text;
            groupControl1.AppearanceCaption.ForeColor = _color;
        }

        // kiểm tra dữ liệu trước khi lưu
        private Boolean CheckInput()
        {
            dxErrorProvider.ClearErrors();
            Boolean check = true;
            if (txtTenPhong.Text.Length == 0)
            {
                check = false;
                dxErrorProvider.SetError(txtTenPhong, "Chưa điền tên");
            }
            //Trường hợp chưa có vị trí
            if (listVitris.Count() == 0)
            {
                check = false;
                dxErrorProvider.SetError(panelControl1, "Chưa có vị trí");
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

        private void barButtonThemPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                deleteData();
                _ucComboBoxViTri.setViTri(_ViTriHienTai);
                txtMaPhong.Focus();
                enableEdit(true);
                function = "add";
                setTextGroupControl("Thêm phòng mới", Color.Red);
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
                setData();
                txtMaPhong.Focus();
                enableEdit(true);
                function = "edit";
                setTextGroupControl("Chỉnh sửa phòng", Color.Red);
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
                function = "delete";
                CRUD();
                gridViewPhong.Focus();
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
            getThongTinPhong(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            deleteData();
            gridViewPhong.Focus();
            enableEdit(false);
            if (listPhong.Count() > 0)
            {
                setData();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                CRUD();
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

        private void searchLookUpEditNhanVienPT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchLookUpEditNhanVienPT.EditValue != null)
                {
                    int id = Int32.Parse(searchLookUpEditNhanVienPT.EditValue.ToString());
                    if (id != -1)
                        objNhanVienPT = NhanVienPT.getById(id);
                    else
                        objNhanVienPT = null;
                    if (objNhanVienPT != null)
                    {
                        txtMaNhanVien.Text = objNhanVienPT.subId;
                        txtTenNhanVien.Text = objNhanVienPT.hoten;
                        txtSoDienThoai.Text = objNhanVienPT.sodienthoai;
                        listHinhAnhNhanVien = objNhanVienPT.hinhanhs.ToList();
                        reloadImageNhanVienPT();
                    }
                    else
                    {
                        imgNhanVien.Images.Clear();
                        txtMaNhanVien.Text = "";
                        txtTenNhanVien.Text = "";
                        txtSoDienThoai.Text = "";
                    }
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
    }
}