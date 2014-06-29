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
using QuanLyTaiSan.Libraries;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen : UserControl
    {
        List<QuanTriVienFilter> listobjQuanTriVienFilter = new List<QuanTriVienFilter>();
        QuanTriVienFilter objQuanTriVienFilter = new QuanTriVienFilter();
        ucPhanQuyen_Control _ucPhanQuyen_Control = new ucPhanQuyen_Control();
        ucPhanQuyen_Group _ucPhanQuyen_Group = new ucPhanQuyen_Group();
        String function = "";

        public ucPhanQuyen()
        {
            InitializeComponent();
            ribbonPhanQuyen.Parent = null;
            _ucPhanQuyen_Control.Parent = this;
            reLoad();
        }

        private void gridViewPhanQuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewPhanQuyen.GetFocusedRow() != null)
            {
                //enableEdit(false, "");
                groupControl1.Text = "Thông tin";
                objQuanTriVienFilter = (QuanTriVienFilter)gridViewPhanQuyen.GetFocusedRow();
                //Truyen qua cho View Thong Tin
                setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
            }
        }
        /// <summary>
        /// Goi hien thi len Panel Thong tin chi tiet
        /// </summary>
        /// <param name="objQuanTriVienFilter"></param>
        private void setThongTinChiTiet(QuanTriVien obj)
        {
            txtMaQuanTriVien.Text = obj.subId;
            txtTaiKhoanQuanTriVien.Text = obj.username;
            txtTenQuanTriVien.Text = obj.hoten;
            txtMatKhauQuanTriVien.Text = obj.password;
            txtXacNhanMK.Text = obj.password;
            dateCreated.DateTime = (DateTime)(obj.date_create==null?ServerTimeHelper.getNow():obj.date_create);
            
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
                dateCreated.Properties.ReadOnly = false;
            }
            else
            {
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtMaQuanTriVien.Properties.ReadOnly = true;
                txtTenQuanTriVien.Properties.ReadOnly = true;
                txtTaiKhoanQuanTriVien.Properties.ReadOnly = true;
                txtMatKhauQuanTriVien.Properties.ReadOnly = true;
                dateCreated.Properties.ReadOnly = true;
            }
        }

        private void reLoad()
        {
            listobjQuanTriVienFilter = QuanTriVienFilter.getAll();
            gridControlPhanQuyen.DataSource = listobjQuanTriVienFilter;
            loadGroup();
        }

        private void dateCreated_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Load DS group cho combobox group
        /// </summary>
        private void loadGroup()
        {
            List<Group> list = Group.getAll();
            lookUpEdit_group.Properties.DataSource = list;
            //lookUpEdit_group.EditValue = list.First().id;
        }

        public RibbonControl getRibbon()
        {
            return ribbonPhanQuyen;
        }

        public PanelControl getControl()
        {
            return _ucPhanQuyen_Control.getControl();
        }

        public void showGroup(bool b)
        {
            splitContainerControl1.Panel1.Controls.Clear();
            splitContainerControl1.Panel2.Controls.Clear();
            if (b)
            {
                splitContainerControl1.Panel1.Controls.Add(_ucPhanQuyen_Group.getLeftControl());
                splitContainerControl1.Panel2.Controls.Add(_ucPhanQuyen_Group.getRightControl());
            }
            else
            {
                splitContainerControl1.Panel1.Controls.Add(gridControlPhanQuyen);
                splitContainerControl1.Panel2.Controls.Add(groupControl1);
            }
        }
    }
}
