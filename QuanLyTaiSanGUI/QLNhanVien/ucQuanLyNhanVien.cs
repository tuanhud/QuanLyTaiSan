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
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;
using QuanLyTaiSanGUI.MyUC;
using DevExpress.XtraBars.Ribbon;

namespace QuanLyTaiSanGUI.QLNhanVien
{
    public partial class ucQuanLyNhanVien : UserControl
    {
        ucTreePhongHaveCheck _ucTreePhongHaveCheck = new ucTreePhongHaveCheck();
        List<NhanVienPT> NhanVienPTs = new List<NhanVienPT>();
        NhanVienPT objNhanVienPT = new NhanVienPT();
        List<HinhAnh> listHinhs = new List<HinhAnh>();
        String function = "";
        public Boolean working = false;

        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
             ribbonNhanVienPT.Parent = null;
            _ucTreePhongHaveCheck.Dock = DockStyle.Fill;
            loadData();
        }

        private void loadData()
        {
            NhanVienPTs = new NhanVienPT().getAll();
            gridControlNhanVien.DataSource = null;
            gridControlNhanVien.DataSource = NhanVienPTs;
        }

        private void gridViewNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewNhanVien.GetFocusedRow() != null)
            {
                enableEdit(false, "");
                SetTextGroupControl("Chi tiết", false);
                objNhanVienPT = (NhanVienPT)gridViewNhanVien.GetFocusedRow();
                SetData();
            }
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnImage.Visible = true;
                btnOK.Visible = true;
                btnHuy.Visible = true;
                txtMa.Properties.ReadOnly = false;
                txtTen.Properties.ReadOnly = false;
                txtSodt.Properties.ReadOnly = false;
                working = true;
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtMa.Properties.ReadOnly = true;
                txtTen.Properties.ReadOnly = true;
                txtSodt.Properties.ReadOnly = true;
                working = false;
            }
        }

        public void reLoad()
        {
            loadData();
            if (!function.Equals(""))
            {
                enableEdit(false, "");
                errorProvider1.Clear();
                listHinhs = null;
                SetData();
            }
        }

        public void beforeAdd()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSodt.Text = "";
            imageSlider1.Images.Clear();
            listHinhs = null;
            listBoxNhanVien.DataSource = null;
        }

        private void Function(String _function)
        {
            if(_function.Equals("edit"))
            {
                objNhanVienPT.subId = txtMa.Text;
                objNhanVienPT.hoten = txtTen.Text;
                objNhanVienPT.sodienthoai = txtSodt.Text;
                objNhanVienPT.hinhanhs = listHinhs;
                if (objNhanVienPT.update() != -1)
                {
                    XtraMessageBox.Show("Sửa nhân viên thành công!");
                    reLoad();
                }
            }
            else
            {
                NhanVienPT objNew = new NhanVienPT();
                objNew.subId = txtMa.Text;
                objNew.hoten = txtTen.Text;
                objNew.sodienthoai = txtSodt.Text;
                objNew.hinhanhs = listHinhs;
                if (objNew.add() != -1)
                {
                    XtraMessageBox.Show("Thêm nhân viên thành công!");
                    reLoad();
                }
            }
        }

        public void deleteObj()
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa nhân viên?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (objNhanVienPT.delete() != -1)
                {
                    XtraMessageBox.Show("Xóa nhân viên thành công!");
                    reLoad();
                }
            }
        }

        public void SetTextGroupControl(String text, bool _color)
        {
            groupControl1.Text = text;
            if (_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Black; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                Function(function);
                enableEdit(false, "");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false, "");
            errorProvider1.Clear();
            listHinhs = null;
            SetData();
        }

        public void SetData()
        {
            SetTextGroupControl("Chi tiết", false);
            txtMa.Text = objNhanVienPT.subId;
            txtTen.Text = objNhanVienPT.hoten;
            txtSodt.Text = objNhanVienPT.sodienthoai;
            listBoxNhanVien.DataSource = objNhanVienPT.phongs;
            listHinhs = objNhanVienPT.hinhanhs.ToList();
            reloadImage();
        }

        private Boolean CheckInput()
        {
            errorProvider1.Clear();
            Boolean check = true;
            if (txtMa.Text.Length == 0)
            {
                errorProvider1.SetError(txtMa, "Chưa điền mã nhân viên");
                check = false;
            }
            if (txtTen.Text.Length == 0)
            {
                errorProvider1.SetError(txtTen, "Chưa điền tên nhân viên");
                check = false;
            }
            if (!(txtSodt.Text.Length >= 9 && txtSodt.Text.Length <= 15))
            {
                errorProvider1.SetError(txtSodt, "Số điện thoại từ 9-15 kí tự");
                check = false;
            }
            if (!IsNumber(txtSodt.Text))
            {
                errorProvider1.SetError(txtSodt, "Số điện thoại không hợp lệ");
                check = false;
            }
            if (txtSodt.Text.Length == 0)
            {
                errorProvider1.SetError(txtSodt, "Chưa điền số điện thoại");
                check = false;
            }
            return check;
        }

        private Boolean IsNumber(String str)
        {
            int num;
            if (int.TryParse(str, out num))
                return true;
            return false;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = null;
                if (function.Equals("edit"))
                {
                    frm = new frmHinhAnh(listHinhs);
                    frm.Text = "Quản lý hình ảnh " + objNhanVienPT.hoten;
                    frm.ShowDialog();
                    listHinhs = frm.getlistHinhs();
                }
                else
                {
                    frm = new frmHinhAnh(listHinhs);
                    frm.Text = "Quản lý hình ảnh nhân viên mới";
                    frm.ShowDialog();
                    listHinhs = frm.getlistHinhs();
                }
    
                reloadImage();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        private void btnHuy_PhanCong_Click(object sender, EventArgs e)
        {
            splitContainerControl1.Panel1.Controls.Clear();
            gridControlNhanVien.Parent = splitContainerControl1.Panel1;
            btnOK_PhanCong.Visible = false;
            btnHuy_PhanCong.Visible = false;
            rbnGroupNhanVien.Enabled = true;
        }

        private void reloadImage()
        {
            imageSlider1.Images.Clear();
            if (listHinhs != null)
            {
                foreach (HinhAnh h in listHinhs)
                {
                    imageSlider1.Images.Add(h.getImage());
                }
            }
        }

        public void PhanCong()
        {
            btnOK_PhanCong.Visible = true;
            btnHuy_PhanCong.Visible = true;
            splitContainerControl1.Panel1.Controls.Clear();
            List<ViTriFilter> listVT = new ViTriFilter().getAllHavePhongNotNhanVien(objNhanVienPT.id);
            _ucTreePhongHaveCheck.loadData(listVT, objNhanVienPT);
            splitContainerControl1.Panel1.Controls.Add(_ucTreePhongHaveCheck);

            rbnGroupNhanVien.Enabled = false;
        }

        public RibbonControl getRibbon()
        {
            return ribbonNhanVienPT;
        }

        private void barBtnThemNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "add");
            SetTextGroupControl("Thêm nhân viên", true);
            beforeAdd();
        }

        private void barBtnSuaNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
            SetData();
            SetTextGroupControl("Sửa nhân viên", true);
        }

        private void barBtnXoaNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        private void barBtnPhanCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhanCong();
        }

    }
}
