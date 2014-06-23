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

namespace QuanLyTaiSanGUI.QLNhanVien
{
    public partial class ucQuanLyNhanVien : UserControl
    {
        ucTreePhongHaveCheck _ucTreePhongHaveCheck = new ucTreePhongHaveCheck();
        List<NhanVienPT> NhanVienPTs = new List<NhanVienPT>();
        NhanVienPT objNhanVienPT = new NhanVienPT();
        NhanVienPT objNhanVienPTNew = null;
        String function = "";

        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            //loadData();
        }

        public void loadData(int _phongid, int _cosoid, int _dayid, int _tangid)
        {
            NhanVienPTs = new NhanVienPT().getAllByViTri(_phongid, _cosoid, _dayid, _tangid);
            gridControlNhanVien.DataSource = null;
            gridControlNhanVien.DataSource = NhanVienPTs;
        }

        private void gridViewNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewNhanVien.GetFocusedRow() != null)
            {
                enableEdit(false, "");
                groupControl1.Text = "Chi tiết";
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
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtMa.Properties.ReadOnly = true;
                txtTen.Properties.ReadOnly = true;
                txtSodt.Properties.ReadOnly = true;
            }
        }

        private void reLoad()
        {
            //NhanVienPTs = new NhanVienPT().getAll();
            //gridControlNhanVien.DataSource = NhanVienPTs;
        }

        public void beforeAdd()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSodt.Text = "";
            imageSlider1.Images.Clear();
            objNhanVienPTNew = new NhanVienPT();
        }

        public void beforeEdit()
        {
            txtMa.Text = objNhanVienPT.subId;
            txtTen.Text = objNhanVienPT.hoten;
            txtSodt.Text = objNhanVienPT.sodienthoai;
            imageSlider1.Images.Clear();
        }

        private void Function(String _function)
        {
            switch (_function)
            {
                case "them":
                    objNhanVienPT = new NhanVienPT();
                    objNhanVienPT.subId = txtMa.Text;
                    objNhanVienPT.hoten = txtTen.Text;
                    objNhanVienPT.sodienthoai = txtSodt.Text;
                    objNhanVienPT.date_create = ServerTimeHelper.getNow();
                    objNhanVienPT.date_modified = ServerTimeHelper.getNow();
                    if (objNhanVienPT.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm nhân viên thành công!");
                        reLoad();
                    }
                    break;
                case "sua":
                    objNhanVienPT.subId = txtMa.Text;
                    objNhanVienPT.hoten = txtTen.Text;
                    objNhanVienPT.sodienthoai = txtSodt.Text;
                    objNhanVienPT.date_modified = ServerTimeHelper.getNow();
                    if (objNhanVienPT.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa nhân viên thành công!");
                        reLoad();
                    }
                    break;
                case "xoa":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa nhân viên?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (objNhanVienPT.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa nhân viên thành công!");
                            reLoad();
                        }
                    }
                    break;
            }
        }

        public void deleteObj()
        {
            Function("xoa");
        }

        public void SetTextGroupControl(String text)
        {
            groupControl1.Text = text;
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
            SetData();
        }

        private void SetData()
        {
            if (objNhanVienPT.id >= 1)
            {
                groupControl1.Text = "Chi tiết";
                txtMa.Text = objNhanVienPT.subId;
                txtTen.Text = objNhanVienPT.hoten;
                txtSodt.Text = objNhanVienPT.sodienthoai;
                listBoxNhanVien.DataSource = objNhanVienPT.phongs;
            }
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
                    frm = new frmHinhAnh(objNhanVienPT.hinhanhs.ToList());
                    frm.Text = "Quản lý hình ảnh " + objNhanVienPT.hoten;
                    frm.ShowDialog();
                }
                else
                {
                    if (objNhanVienPTNew.hinhanhs == null)
                        objNhanVienPTNew.hinhanhs = new List<HinhAnh>();
                    frm = new frmHinhAnh(objNhanVienPTNew.hinhanhs.ToList());
                    frm.Text = "Quản lý hình ảnh nhân viên mới";
                    frm.ShowDialog();
                }
    
                //reloadImage();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        private void reloadImage()
        {
            List<HinhAnh> hinhs = null;
            if (!function.Equals("add"))
            {
                hinhs = objNhanVienPTNew.hinhanhs.ToList();
            }
            else
            {
                hinhs = objNhanVienPT.hinhanhs.ToList();
            }
            imageSlider1.Images.Clear();
            foreach (HinhAnh h in hinhs)
            {
                imageSlider1.Images.Add(h.getImage());
            }
        }

    }
}
