using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietPhong : UserControl
    {
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, false);
        ucComboBoxViTri _ucComboBoxViTriChonDay = new ucComboBoxViTri(true, false);
        List<HinhAnh> listHinh = new List<HinhAnh>();
        Phong objPhong = new Phong();
        NhanVienPT objNhanVienPT = new NhanVienPT();
        CoSo objCoSo = new CoSo();
        Dayy objDay = new Dayy();
        Tang objTang = new Tang();
        String type = "";
        String function = "";
        String node = "";

        public ucChiTietPhong()
        {
            InitializeComponent();
            enableEdit(false, "", "");

        }

        public void loadData(List<ViTriHienThi> _list)
        {
            _ucComboBoxViTri.loadData(_list);
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucComboBoxViTri);
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
                _ucComboBoxViTri.setViTri(objPhong.vitri);
                NhanVienPT objNV = new NhanVienPT();
                if (objPhong.nhanvienpt != null)
                {
                    objNV = objPhong.nhanvienpt;
                }
                lblMaNhanVien.Text = objNV.subId;
                lblTenNhanVien.Text = objNV.hoten;
                lblSoDienThoai.Text = objNV.sodienthoai;
                listHinh = objPhong.hinhanhs.ToList();
                reloadImage();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        //public void enableEdit(bool b, String _type)
        //{
        //    btnOK.Visible = b;
        //    btnHuy.Visible = b;
        //    btnImage.Visible = b;
        //    type = _type;
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (CheckInput())
            {
                switch (function)
                {
                    case "edit":
                        editObjPhong();
                        break;
                    case "add":
                        addObjPhong();
                        break;
                }
                enableEdit(false, "", "");
            }
        }

        private void editObjPhong()
        {
            objPhong.ten = txtTenPhong.Text;
            objPhong.mota = txtMoTaPhong.Text;
            objPhong.hinhanhs = listHinh;
            if (objPhong.update() != -1)
            {
                XtraMessageBox.Show("Sửa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucQuanLyPhong uc = this.Parent as ucQuanLyPhong;
                uc.reLoad();
                /*
                findNode = new FindNode(objCoSo.id, typeof(CoSo).Name);
                treeListViTri.NodesIterator.DoOperation(findNode);
                treeListViTri.FocusedNode = findNode.Node;
                 */
            }
        }

        public void enableEdit(bool _enable, String _type, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnImage.Visible = true;
                btnOK.Visible = true;
                btnHuy.Visible = true;
                txtTenPhong.Properties.ReadOnly = false;
                txtMoTaPhong.Properties.ReadOnly = false;
                _ucComboBoxViTri.setReadOnly(false);
                type = _type;
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtTenPhong.Properties.ReadOnly = true;
                txtMoTaPhong.Properties.ReadOnly = true;
                _ucComboBoxViTri.setReadOnly(true);
            }
        }

        private void addObjPhong()
        {
            Phong objPhongNew = new Phong();
            objPhongNew.ten = txtTenPhong.Text;
            objPhongNew.mota = txtMoTaPhong.Text;
            objPhongNew.hinhanhs = listHinh;
            objPhongNew.vitri = _ucComboBoxViTri.getViTri();
            if (objPhongNew.add() != -1)
            {
                XtraMessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucQuanLyPhong uc = this.Parent.Parent.Parent as ucQuanLyPhong;
                uc.reLoad();
                /*findNode = new FindNode(objCoSoNew.id, typeof(CoSo).Name);
                treeListViTri.NodesIterator.DoOperation(findNode);
                treeListViTri.FocusedNode = findNode.Node;*/
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //enableEdit(false, "", "");
            SetTextGroupControl("Chi tiết", false);
            dxErrorProvider.ClearErrors();
            listHinh = null;
            setData(objPhong);
        }

        public void SetTextGroupControl(String _text, bool _color)
        {
            groupControl1.Text = _text;
            if (_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Black;
        }

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

        private void reloadImage()
        {
            imgPhong.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imgPhong.Images.Add(h.getImage());
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
            //_ucComboBoxViTriChonDay.setViTri(_vitri);
            //panelControl1.Controls.Add(_ucComboBoxViTriChonDay);
        }
    }
}
