using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Libraries;

namespace QuanLyTaiSanGUI.QLTinhTrang
{
    public partial class ucQuanLyTinhTrang : DevExpress.XtraEditors.XtraUserControl
    {
        List<TinhTrang> listTinhTrang = new List<TinhTrang>();
        TinhTrang objTinhTrang = new TinhTrang();
        String function = "";

        public ucQuanLyTinhTrang()
        {
            InitializeComponent();
        }

        public void reLoad()
        {
            listTinhTrang = new TinhTrang().getAll().OrderBy(i => i.value).ToList();
            treeListTinhTrang.DataSource = listTinhTrang;
            checkSuaXoa();
        }

        private void checkSuaXoa()
        {
            if (listTinhTrang.Count == 0)
            {
                beforeAdd();
                if (this.ParentForm != null)
                {
                    frmMain frm = (frmMain)this.ParentForm;
                    //frm.enableSuaXoaRibbonTinhTrang(false);
                }
            }
            else
            {
                if (this.ParentForm != null)
                {
                    frmMain frm = (frmMain)this.ParentForm;
                    //frm.enableSuaXoaRibbonTinhTrang(true);
                }
            }
        }

        public void beforeAdd()
        {
            txtTen.Text = "";
            txtMoTa.Text = "";        
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnOk.Visible = true;
                btnHuy.Visible = true;
                txtTen.Properties.ReadOnly = false;
                txtMoTa.Properties.ReadOnly = false;
            }
            else
            {
                btnOk.Visible = false;
                btnHuy.Visible = false;
                txtTen.Properties.ReadOnly = true;
                txtMoTa.Properties.ReadOnly = true;
            }
        }

        public void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        public void setData()
        {
            if (listTinhTrang.Count > 0)
            {
                errorProvider1.Clear();
                txtTen.Text = objTinhTrang.value;
                txtMoTa.Text = objTinhTrang.mota;
            }
            else
                beforeAdd();
        }

        private void setDataObj()
        {
            //string ten = txtTen.Text.Trim();
            //while (ten.IndexOf("  ") != -1)
            //{
            //    ten = ten.Replace("  ", " ");
            //}
            //objTinhTrang.value = ten;
            objTinhTrang.value = txtTen.Text;
            objTinhTrang.mota = txtMoTa.Text;
            objTinhTrang.key = StringHelper.CoDauThanhKhongDau(txtTen.Text).Replace(" ", String.Empty).ToUpper();
        }

        private void CRU()
        {
            switch (function)
            { 
                case "add":
                    objTinhTrang = new TinhTrang();
                    setDataObj();
                    if (objTinhTrang.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "edit":
                    setDataObj();
                    if (objTinhTrang.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;    
            }
        }

        public void deleteObj()
        {
            if (new CTThietBi().listThietBiTheoTinhTrang(objTinhTrang.id).Count > 0)
            {
                XtraMessageBox.Show("Không thể xóa tình trạng này!\r\nNguyên do: Có các thiết bị thuộc tình trạng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (XtraMessageBox.Show("Bạn có chắc là muốn xóa tình trạng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (objTinhTrang.delete() != -1)
                    {
                        XtraMessageBox.Show("Xóa loại tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                    }
                }
            }
        }

        private Boolean checkInput()
        { 
            Boolean check = true;
            if (function.Equals("add"))
            {
                if (listTinhTrang.Where(i => i.value == txtTen.Text).FirstOrDefault() != null)
                {
                    check = false;
                    errorProvider1.SetError(txtTen, "Tên tình trạng đã có");
                }
            }
            else if (function.Equals("edit"))
            {
                if (listTinhTrang.Where(i => i.value == txtTen.Text && i.id != objTinhTrang.id).FirstOrDefault() != null)
                {
                    check = false;
                    errorProvider1.SetError(txtTen, "Tên tình trạng đã có");
                }
            }
            if (txtTen.Text.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtTen, "Chưa điền tên tình trạng");
            }
            return check;
        }

        private void treeListTinhTrang_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (treeListTinhTrang.GetDataRecordByNode(e.Node) != null)
            {
                enableEdit(false, "");
                SetTextGroupControl("Chi tiết", Color.Black);
                objTinhTrang = (TinhTrang)treeListTinhTrang.GetDataRecordByNode(e.Node);
                setData();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                CRU();
                reLoad();
                setData();
                enableEdit(false, "");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetTextGroupControl("Chi tiết", Color.Black);
            setData();
            enableEdit(false, "");
            errorProvider1.Clear();
        }
    }
}
