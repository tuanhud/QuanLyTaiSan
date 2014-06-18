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

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietPhong : UserControl
    {
        ucTreeViTri _ucTreeViTri;
        Phong objPhong;
        public ucChiTietPhong(List<CoSo> _list)
        {
            InitializeComponent();
            _ucTreeViTri = new ucTreeViTri(_list, true, true);
            _ucTreeViTri.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucTreeViTri);
        }
        public void LoadData(Phong _phong)
        {
            try
            {
                objPhong = _phong;
                txtTen.Text = objPhong.ten;
                txtMoTa.Text = objPhong.mota;
                _ucTreeViTri.setViTri(objPhong.vitri);
                NhanVienPT objNV = new NhanVienPT();
                if (objPhong.nhanvienpt != null)
                {
                    objNV = objPhong.nhanvienpt;
                }
                lblMaNhanVien.Text = objNV.subId;
                lblTenNhanVien.Text = objNV.hoten;
                lblSoDienThoai.Text = objNV.sodienthoai;
            }
            catch (Exception ex)
            { }
            finally
            {}
        }
     }
}
