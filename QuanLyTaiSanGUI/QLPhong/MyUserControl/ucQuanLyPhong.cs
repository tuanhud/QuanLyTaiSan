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

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhong : UserControl
    {
        CoSo objCoSo = new CoSo();
        Dayy objDay = new Dayy();
        Tang objTang = new Tang();
        Phong objPhong = new Phong();
        NhanVienPT objNhanVienPT = new NhanVienPT();

        List<ThietBiFilter> listThietBis = new List<ThietBiFilter>();
        List<ViTriFilter> listVitris = new List<ViTriFilter>();
        
        List<Phong> listPhong = new List<Phong>();
        List<HinhAnh> listHinh = new List<HinhAnh>();
        List<NhanVienPT> listNhanVienPT = new List<NhanVienPT>();

        ucTreePhong _ucTreePhong = null;
        ucTreeViTri _ucTreeViTri = new ucTreeViTri(false, false);     

        String function = "";
        int _idnhanvien = 0;
        public ucQuanLyPhong()
        {
            InitializeComponent();
            loadData();
            enableEdit(false, "");
            enableBar(false);
        }

        // Load dữ liệu
        public void loadData()
        {
            listVitris = new ViTriFilter().getAll().ToList();
            _ucTreePhong = new ucTreePhong(listVitris, "QLPhong");
            _ucTreePhong.Parent = this;
            _ucTreeViTri.loadData(listVitris);
            _ucTreeViTri.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucTreeViTri);
            ribbonPhong.Parent = null;
            listPhong = new Phong().getPhongByViTri(-1, -1, -1);
            gridControlPhong.DataSource = listPhong;
            listNhanVienPT = objNhanVienPT.getAll();
            lookUpEditNhanVien.Properties.DataSource = listNhanVienPT;
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
                txtTenPhong.Properties.ReadOnly = false;
                txtMoTaPhong.Properties.ReadOnly = false;
                _ucTreeViTri.setReadOnly(false);
                lblNhanVienPT.Visible = true;
                lookUpEditNhanVien.Visible = true;
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtTenPhong.Properties.ReadOnly = true;
                txtMoTaPhong.Properties.ReadOnly = true;
                _ucTreeViTri.setReadOnly(true);
                lblNhanVienPT.Visible = false;
                lookUpEditNhanVien.Visible = false;
            }
        }

        // Reload dữ liệu
        public void reLoad()
        {
            gridControlPhong.DataSource = null;
            listPhong = new Phong().getPhongByViTri(-1, -1, -1);
            gridControlPhong.DataSource = listPhong;
        }

        //FocusedRowChanged in TreePhong
        public void setData(int _cosoid, int _dayid, int _tangid)
        {
            listPhong = new Phong().getPhongByViTri(_cosoid, _dayid, _tangid);
            gridControlPhong.DataSource = null;
            gridControlPhong.DataSource = listPhong;
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
                    objPhong = new Phong();
                txtTenPhong.Text = objPhong.ten;
                txtMoTaPhong.Text = objPhong.mota;
                _ucTreeViTri.setViTri(objPhong.vitri);
                NhanVienPT objNV = new NhanVienPT();
                if (objPhong.nhanvienpt != null)
                {
                    objNV = objPhong.nhanvienpt;
                }
                txtMaNhanVien.Text = objNV.subId;
                txtTenNhanVien.Text = objNV.hoten;
                txtSoDienThoai.Text = objNV.sodienthoai;
                listHinh = objPhong.hinhanhs.ToList();
                reloadImage();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        //chỉnh sửa phòng
        private void ChinhSuaPhong()
        {
            objPhong.ten = txtTenPhong.Text;
            objPhong.mota = txtMoTaPhong.Text;
            objPhong.hinhanhs = listHinh;
            objPhong.nhanvienpt = new NhanVienPT().getById(_idnhanvien);
            if (objPhong.update() != -1)
            {
                XtraMessageBox.Show("Sửa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reLoad();
            }
            else XtraMessageBox.Show("Có lỗi trong khi chỉnh sửa");
        }

        //thêm phòng
        private void ThemPhong()
        {
            Phong objPhongNew = new Phong();
            objPhongNew.ten = txtTenPhong.Text;
            objPhongNew.mota = txtMoTaPhong.Text;
            objPhongNew.hinhanhs = listHinh;
            objPhongNew.vitri = _ucTreeViTri.getViTri();
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
            if (imgPhong.Images.Count == 0)
            {
                check = false;
                dxErrorProvider.SetError(imgPhong, "Cần ít nhất 1 hình ảnh");
            }
            if (txtTenPhong.Text.Length == 0)
            {
                check = false;
                dxErrorProvider.SetError(txtTenPhong, "Chưa điền tên");
            }
            return check;
        }

        //load lại ảnh
        private void reloadImage()
        {
            imgPhong.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imgPhong.Images.Add(h.getImage());
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
            enableEdit(true, "add");
            beforeAdd();
            SetTextGroupControl("Thêm phòng mới", true);
        }

        private void barButtonSuaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
            SetTextGroupControl("Chỉnh sửa phòng", true);
            lookUpEditNhanVien.EditValue = objPhong.nhanvienpt.hoten.ToString();
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
            return _ucTreePhong.getTreeList();
        }

        private void gridViewPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                enableBar(true);
                int row = gridViewPhong.FocusedRowHandle;
                Phong obj = new Phong();
                obj = obj.getById(Convert.ToInt32(gridViewPhong.GetRowCellValue(gridViewPhong.GetDataRowHandleByGroupRowHandle(row), id)));
                setData(obj);
                objPhong = obj;
            }
            catch (Exception ex)
            { }
            finally { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetTextGroupControl("Chi tiết", false);
            dxErrorProvider.ClearErrors();
            listHinh = null;
            setData(objPhong);
            //reLoad();
            //reloadImage();
            enableEdit(false, "");
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
                reloadImage();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        public void beforeAdd()
        {
            txtTenPhong.Text = "";
            txtMoTaPhong.Text = "";
            imgPhong.Images.Clear();
        }

        private void lookUpEditNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            _idnhanvien = Int32.Parse(lookUpEditNhanVien.EditValue.ToString());
        }
    }
}
