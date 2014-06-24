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
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

namespace QuanLyTaiSanGUI.QLLoaiThietBi
{
    public partial class ucQuanLyLoaiTB : UserControl
    {
        List<LoaiThietBi> loaiThietBis = new List<LoaiThietBi>();
        List<LoaiThietBi> listLoaiThietBiCha = new List<LoaiThietBi>();
        List<LoaiThietBi> loaiThietBiParents = new List<LoaiThietBi>();
        string function = "";
        LoaiThietBi objLoaiThietBi = null;
        LoaiThietBi loaiThietBiNULL = new LoaiThietBi();

        public ucQuanLyLoaiTB()
        {
            InitializeComponent();
            ribbonLoaiTB.Parent = null;
            loaiThietBiNULL.ten = "[Không thuộc loại nào]";
            loaiThietBiNULL.id = -1;
            loaiThietBiNULL.parent = null;
        }

        private void treeListLoaiTB_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (treeListLoaiTB.GetDataRecordByNode(e.Node) != null)
            {
                enableEdit(false, "");
                SetTextGroupControl("Chi tiết", Color.Black);
                objLoaiThietBi = (LoaiThietBi)treeListLoaiTB.GetDataRecordByNode(e.Node);
                setData();
            }
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
                lueThuoc.Properties.ReadOnly = false;
                ceTBsoluonglon.Properties.ReadOnly = false;
            }
            else
            {
                btnOk.Visible = false;
                btnHuy.Visible = false;
                txtTen.Properties.ReadOnly = true;
                txtMoTa.Properties.ReadOnly = true;
                lueThuoc.Properties.ReadOnly = true;
                ceTBsoluonglon.Properties.ReadOnly = true;
            }
        }

        public void reLoad()
        {
            loaiThietBis = new LoaiThietBi().getAll().OrderBy(l => l.ten).ToList();
            treeListLoaiTB.DataSource = loaiThietBis;
            listLoaiThietBiCha = new LoaiThietBi().getAllParent().OrderBy(l => l.ten).ToList();
            listLoaiThietBiCha.Insert(0, loaiThietBiNULL);
            lueThuoc.Properties.DataSource = listLoaiThietBiCha;
            checkSuaXoa();
        }

        public void beforeAdd()
        {
            errorProvider1.Clear();
            txtTen.Text = "";
            txtMoTa.Text = "";
            lueThuoc.EditValue = loaiThietBiNULL.id;
            ceTBsoluonglon.Checked = false;
        }

        public void setData()
        {
            if (loaiThietBis.Count > 0)
            {
                errorProvider1.Clear();
                txtTen.Text = objLoaiThietBi.ten;
                txtMoTa.Text = objLoaiThietBi.mota;
                if (objLoaiThietBi.parent_id == null)
                    lueThuoc.EditValue = loaiThietBiNULL.id;
                else
                    lueThuoc.EditValue = objLoaiThietBi.parent_id;
                if (objLoaiThietBi.loaichung)
                    ceTBsoluonglon.Checked = true;
                else
                    ceTBsoluonglon.Checked = false;
                if (objLoaiThietBi.thietbis.Count > 0 || checkLoaiThietBiConCoThietBiKhong(objLoaiThietBi))
                    ceTBsoluonglon.Properties.ReadOnly = true;
            }
            else
                beforeAdd();
        }

        private void CRU()
        {
            switch (function)
            { 
                case "add":
                    objLoaiThietBi = new LoaiThietBi();
                    setDataObj();
                    if (objLoaiThietBi.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm loại thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "edit":
                    setDataObj();
                    if (objLoaiThietBi.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa loại thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        public void deleteObj()
        {
            if (objLoaiThietBi.thietbis.Count > 0 || checkLoaiThietBiConCoThietBiKhong(objLoaiThietBi))
            {
                XtraMessageBox.Show("Không thể xóa loại thiết bị này!\r\nNguyên do: Loại thiết bị này có chứa các thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (XtraMessageBox.Show("Bạn có chắc là muốn xóa loại thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (objLoaiThietBi.childs.Count > 0)
                    {
                        if (XtraMessageBox.Show("Loại thiết bị này là gốc, bạn có muốn xóa luôn những loại thiết bị con?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            for (int i = 0; i < objLoaiThietBi.childs.Count; i++)
                            {
                                objLoaiThietBi.childs.ElementAt(i).delete();
                            }
                        }
                    }
                    if (objLoaiThietBi.delete() != -1)
                    {
                        XtraMessageBox.Show("Xóa loại thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                    }
                }
            }
        }

        private Boolean checkLoaiThietBiConCoThietBiKhong(LoaiThietBi parent)
        {
            foreach (LoaiThietBi loaiThietBiCon in parent.childs)
            {
                if (loaiThietBiCon.thietbis.Count > 0)
                    return true;
            }
            return false;
        }

        private void setDataObj()
        {
            objLoaiThietBi.ten = txtTen.Text;
            objLoaiThietBi.mota = txtMoTa.Text;
            objLoaiThietBi.date_create = DateTime.Today;
            objLoaiThietBi.date_modified = DateTime.Today;
            LoaiThietBi parentLoaiThietBi = (LoaiThietBi)lueThuoc.GetSelectedDataRow();
            if (parentLoaiThietBi.id != -1)
                objLoaiThietBi.parent = new LoaiThietBi().getById(parentLoaiThietBi.id);
            else
            { 
                if(function.Equals("edit"))
                {
                    objLoaiThietBi.parent_id = null;
                }
            }
            if (ceTBsoluonglon.Checked)
                objLoaiThietBi.loaichung = true;
            else
                objLoaiThietBi.loaichung = false;
        }

        public void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetTextGroupControl("Chi tiết", Color.Black);
            lueThuoc.Properties.DataSource = listLoaiThietBiCha;
            setData();
            enableEdit(false, "");
            errorProvider1.Clear();
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

        public void addThietBiChaKhiEdit()
        {
            if (objLoaiThietBi.id >= 1)
            {
                if (objLoaiThietBi.childs.Count > 0)
                {
                    lueThuoc.EditValue = loaiThietBiNULL.id;
                    lueThuoc.Properties.ReadOnly = true;
                }
                else
                {
                    loaiThietBiParents = new List<LoaiThietBi>(listLoaiThietBiCha);
                    loaiThietBiParents.Remove(objLoaiThietBi);
                    lueThuoc.Properties.DataSource = loaiThietBiParents;
                }
            }
        }

        private Boolean checkInput()
        {
            Boolean check = true;
            errorProvider1.Clear();
            if (txtTen.Text.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtTen, "Chưa điền tên thiết bị");
            }
            LoaiThietBi cha = (LoaiThietBi)lueThuoc.GetSelectedDataRow();
            if (cha.id != -1)
            {
                if (cha.loaichung)
                {
                    if (!ceTBsoluonglon.Checked)
                    {
                        check = false;
                        errorProvider1.SetError(ceTBsoluonglon, "Thiết bị cha được quản lí theo số lượng lớn, thiết bị con cũng phải thế");
                    }
                }
                else
                {
                    if (ceTBsoluonglon.Checked)
                    {
                        check = false;
                        errorProvider1.SetError(ceTBsoluonglon, "Thiết bị cha được quản lí theo đơn lẻ, thiết bị con cũng phải thế");
                    }
                }
            }
            else
            {
                if (function.Equals("edit"))
                {
                    if (objLoaiThietBi.childs.Count > 0)
                    {
                        LoaiThietBi con = objLoaiThietBi.childs.ElementAt(0);
                        if (con.loaichung)
                        {
                            if (!ceTBsoluonglon.Checked)
                            {
                                check = false;
                                errorProvider1.SetError(ceTBsoluonglon, "Các thiết bị con được quản lí theo số lượng lớn, thiết bị cha cũng phải thế");
                            }
                        }
                        else
                        {
                            if (ceTBsoluonglon.Checked)
                            {
                                check = false;
                                errorProvider1.SetError(ceTBsoluonglon, "Các thiết bị con được quản lí theo đơn lẻ, thiết bị cha cũng phải thế");
                            }
                        }
                    }
                }
            }
            return check;
        }

        private void checkSuaXoa()
        {
            if (loaiThietBis.Count == 0)
            {
                beforeAdd();
                enableSuaXoa(false);
            }
            else
            {
                enableSuaXoa(true);
            }
        }

        private void barButtonThemLoaiTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "add");
            SetTextGroupControl("Thêm loại thiết bị", Color.Red);
            beforeAdd();
        }

        private void barButtonSuaLoaiTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
            SetTextGroupControl("Sửa loại thiết bị", Color.Red);
            addThietBiChaKhiEdit();
            setData();
        }

        private void barButtonXoaLoaiTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        public void enableSuaXoa(Boolean enable)
        {
            if (enable)
            {
                barButtonSuaLoaiTB.Enabled = true;
                barButtonXoaLoaiTB.Enabled = true;
            }
            else
            {
                barButtonSuaLoaiTB.Enabled = false;
                barButtonXoaLoaiTB.Enabled = false;
            }
        }

        public RibbonControl getRibbon()
        {
            return ribbonLoaiTB;
        }
    }
}
