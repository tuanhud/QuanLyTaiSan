using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen_Group : UserControl
    {
        List<Group> listGroup = null;
        Group objGroup = null;
        String function = "";
        bool working = false;

        public ucPhanQuyen_Group()
        {
            InitializeComponent();
            editGUI("view");
            loadData();
        }

        private void loadData()
        {
            listGroup = Group.getAll();
            gridControlGroup.DataSource = listGroup;
        }

        public void editGUI(String _type)
        {
            function = _type;
            if (_type.Equals("view"))
            {
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
            }
            else if (_type.Equals("add"))
            {
                SetTextGroupControl("Thêm nhóm quyền", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa nhóm quyền", Color.Red);
                enableEdit(true);
                txtTen.Focus();
            }
        }

        private void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        private void enableEdit(bool _enable)
        {
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtKey.Properties.ReadOnly = !_enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            working = _enable;
        }

        private void clearText()
        {
            txtKey.Text = "";
            txtTen.Text = "";
            txtMoTa.Text = "";
        }

        public GridControl getLeftControl()
        {
            return gridControlGroup;
        }
        public PanelControl getRightControl()
        {
            return panelControl1;
        }

        private void gridViewGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                objGroup = gridViewGroup.GetRow(e.FocusedRowHandle) as Group;
                setData(objGroup);
            }
        }

        private void setData(Group obj)
        {
            txtKey.Text = obj.key;
            txtTen.Text = obj.ten;
            txtMoTa.Text = obj.mota;
            listBoxQuyen.DataSource = obj.permissions.ToList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        public void showFormPhanQuyen()
        {
            frmSuaPermission frm = new frmSuaPermission(objGroup.permissions.ToList());
            frm.ShowDialog();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            editGUI("view");
        }
    }
}
