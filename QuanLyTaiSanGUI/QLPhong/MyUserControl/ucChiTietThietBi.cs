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
using QuanLyTaiSanGUI.MyUC;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietThietBi : UserControl
    {
        CTThietBi obj = new CTThietBi();
        List<LoaiThietBi> list;
        ucTreeLoaiTB _ucTreeLoaiTB;
        public ucChiTietThietBi()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            list = new LoaiThietBi().getAll();
            _ucTreeLoaiTB = new ucTreeLoaiTB(list);
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            _ucTreeLoaiTB.setReadOnly(true);
            panelControl1.Controls.Add(_ucTreeLoaiTB);
        }

        public void setData(CTThietBi _obj)
        {
            obj = _obj;
            txtMa.Text = _obj.thietbi.subId;
            txtTen.Text = _obj.thietbi.ten;
            txtMoTa.Text = _obj.thietbi.mota;
            lblTenPhong.Text = _obj.phong.ten;
            dateMua.DateTime = _obj.thietbi.ngaymua.Value;
            dateLap.DateTime = _obj.thietbi.ngaylap.Value;
            _ucTreeLoaiTB.setLoai(_obj.thietbi.loaithietbi);
        }
    }
}
