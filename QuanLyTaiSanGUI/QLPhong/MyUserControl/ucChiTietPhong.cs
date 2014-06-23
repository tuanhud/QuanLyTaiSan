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

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietPhong : UserControl
    {
        ucTreeViTri _ucTreeViTri = new ucTreeViTri(false, false);
        Phong objPhong;
        String type = "";
        public ucChiTietPhong()
        {
            InitializeComponent();
        }

        public void loadData(List<ViTriFilter> _list)
        {
            _ucTreeViTri.loadData(_list);
            _ucTreeViTri.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucTreeViTri);
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

        public void enableEdit(bool b, String _type)
        {
            btnOK.Visible = b;
            btnHuy.Visible = b;
            btnImage.Visible = b;
            type = _type;
        }
     }
}
