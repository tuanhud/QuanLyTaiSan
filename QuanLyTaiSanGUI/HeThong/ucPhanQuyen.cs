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

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen : UserControl
    {
        List<QuanTriVienFilter> listobjQuanTriVienFilter = new List<QuanTriVienFilter>();
        QuanTriVienFilter objQuanTriVienFilter = new QuanTriVienFilter();
        String function = "";

        public ucPhanQuyen()
        {
            InitializeComponent();
            reLoad();
        }

        private void gridViewPhanQuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewPhanQuyen.GetFocusedRow() != null)
            {
                //enableEdit(false, "");
                groupControl1.Text = "Thông tin";
                objQuanTriVienFilter = (QuanTriVienFilter)gridViewPhanQuyen.GetFocusedRow();
                //SetData();
            }
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnOK.Visible = true;
                btnHuy.Visible = true;
                txtMaQuanTriVien.Properties.ReadOnly = false;
                txtTenQuanTriVien.Properties.ReadOnly = false;
                txtTaiKhoanQuanTriVien.Properties.ReadOnly = false;
                txtMatKhauQuanTriVien.Properties.ReadOnly = false;
                timeNgayTaoQuanTriVien.Properties.ReadOnly = false;
            }
            else
            {
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtMaQuanTriVien.Properties.ReadOnly = true;
                txtTenQuanTriVien.Properties.ReadOnly = true;
                txtTaiKhoanQuanTriVien.Properties.ReadOnly = true;
                txtMatKhauQuanTriVien.Properties.ReadOnly = true;
                timeNgayTaoQuanTriVien.Properties.ReadOnly = true;
            }
        }

        private void reLoad()
        {
            listobjQuanTriVienFilter = objQuanTriVienFilter.getAll();
            gridControlPhanQuyen.DataSource = listobjQuanTriVienFilter;
        }
    }
}
