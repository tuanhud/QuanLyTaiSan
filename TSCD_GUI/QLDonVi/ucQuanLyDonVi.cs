using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using SHARED.Libraries;
using TSCD_GUI.MyUserControl;

namespace TSCD_GUI.QLDonVi
{
    public partial class ucQuanLyDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        List<DonVi> listDonVi = new List<DonVi>();
        List<LoaiDonVi> listLoaiDonVi = new List<LoaiDonVi>();
        ucComboBoxDonVi _ucComboBoxDonVi = new ucComboBoxDonVi();
        DonVi objDonVi = new DonVi();
        String function = "";
        bool working = false;
        public ucQuanLyDonVi()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            rbnControlDonVi.Parent = null;
            _ucComboBoxDonVi.Dock = DockStyle.Fill;
            panelControlParent.Controls.Add(_ucComboBoxDonVi);
        }
        public void loadData()
        {
            try
            {
                editGUI("view");
                listDonVi = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                treeListDonVi.DataSource = listDonVi;
                loadLoaiDonVi();
                DonVi DonViNULL = new DonVi();
                DonViNULL.id = Guid.Empty;
                DonViNULL.ten = "[Đại học Sài Gòn]";
                DonViNULL.parent = null;
                List<DonVi> listDonViParent = new List<DonVi>(listDonVi);
                listDonViParent.Insert(0, DonViNULL);
                _ucComboBoxDonVi.loadData(listDonViParent, listLoaiDonVi);
                if (listDonVi.Count == 0)
                {
                    enableButton(false);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }
        }
        private void loadLoaiDonVi()
        {
            listLoaiDonVi = LoaiDonVi.getQuery().OrderBy(c => c.order).ToList();
            gridLookUpLoai.Properties.DataSource = listLoaiDonVi;
            repositoryLookUpLoai.DataSource = listLoaiDonVi;
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlDonVi;
        }

        private void editGUI(String _type)
        {
            function = _type;
            if (_type.Equals("view"))
            {
                clearText();
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
            }
            else if (_type.Equals("add"))
            {
                SetTextGroupControl("Thêm đơn vị", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa đơn vị", Color.Red);
                enableEdit(true);
                txtTen.Focus();
                _ucComboBoxDonVi.setID(objDonVi.id);
            }
        }
        private void SetTextGroupControl(String text, Color color)
        {
            groupControlInfo.Text = text;
            groupControlInfo.AppearanceCaption.ForeColor = color;
        }
        private void enableEdit(bool _enable)
        {
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtMa.Properties.ReadOnly = !_enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            _ucComboBoxDonVi.setReadOnly(!_enable);
            gridLookUpLoai.Properties.ReadOnly = !_enable;
            enableButton(!_enable);
            btnThem_r.Enabled = !_enable;
            barBtnThemDonVi.Enabled = !_enable;
            working = _enable;
        }
        private void enableButton(bool _enable)
        {
            barBtnSuaDonVi.Enabled = _enable;
            barBtnXoaDonVi.Enabled = _enable;
            btnSua_r.Enabled = _enable;
            btnXoa_r.Enabled = _enable;
        }
        private void clearText()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtMoTa.Text = "";
            _ucComboBoxDonVi.setDonViById(Guid.Empty);
            gridLookUpLoai.EditValue = null;
        }
        private void setDataView()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                if (!function.Equals("view"))
                    editGUI("view");
                if (treeListDonVi.Nodes.Count > 0)
                {
                    if (treeListDonVi.FocusedNode != null && treeListDonVi.GetDataRecordByNode(treeListDonVi.FocusedNode) != null)
                    {
                        objDonVi = treeListDonVi.GetDataRecordByNode(treeListDonVi.FocusedNode) as DonVi;
                        if (objDonVi != null)
                        {
                            txtMa.Text = objDonVi.subId;
                            txtTen.Text = objDonVi.ten;
                            txtMoTa.Text = objDonVi.mota;
                            gridLookUpLoai.EditValue = objDonVi.loaidonvi != null ? objDonVi.loaidonvi.id : Guid.Empty;
                            if (objDonVi.parent != null)
                                _ucComboBoxDonVi.setDonVi(objDonVi.parent);
                            else
                                _ucComboBoxDonVi.setDonViById(Guid.Empty);
                        }
                        else
                        {
                            clearText();
                            objDonVi = new DonVi();
                        }
                    }
                    else
                    {
                        clearText();
                        objDonVi = new DonVi();
                    }
                }
                else
                {
                    enableButton(false);
                    clearText();
                    objDonVi = new DonVi();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }
        private void setDataObj()
        {
            try
            {
                objDonVi.subId = txtMa.Text;
                objDonVi.ten = txtTen.Text;
                objDonVi.mota = txtMoTa.Text;
                objDonVi.loaidonvi = gridLookUpLoai.EditValue != null ? LoaiDonVi.getById(GUID.From(gridLookUpLoai.EditValue)) : null;
                DonVi objParent = _ucComboBoxDonVi.getDonVi();
                objDonVi.parent = (objParent != null && objParent.id != Guid.Empty) ? objParent : null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataObj: " + ex.Message);
            }
        }
        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbon()
        {
            return rbnControlDonVi;
        }
        private void treeListDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            setDataView();
        }
        private void barBtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private Boolean checkInput()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                Boolean check = true;
                if (txtTen.Text.Length == 0)
                {
                    check = false;
                    dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên đơn vị");
                }
                if (gridLookUpLoai.EditValue == null)
                {
                    check = false;
                    dxErrorProviderInfo.SetError(gridLookUpLoai, "Chưa chọn loại đơn vị");
                }
                if (objDonVi.Equals(_ucComboBoxDonVi.getDonVi()))
                {
                    check = false;
                    //dxErrorProviderInfo.SetError(panelControlParent, "Đơn vị không thể thuộc chính mình");
                }
                return check;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkInput: " + ex.Message);
                return false;
            }
        }
        private void reLoadAndSelectNode(Guid _id, bool _expanded = false)
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                loadData();
                if (_id != Guid.Empty)
                {
                    DevExpress.XtraTreeList.Nodes.TreeListNode node = treeListDonVi.FindNodeByKeyID(_id);
                    if (node != null)
                    {
                        node.Selected = true;
                        node.Expanded = _expanded;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reLoadAndSelectNode: " + ex.Message);
            }
        }
        private void deleteObj()
        {
            try
            {
                if (objDonVi.childs != null && objDonVi.childs.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa đơn vị này!\r\nNguyên do: Có đơn vị thuộc đơn vị này này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((objDonVi.cttaisan_dangquanlys != null && objDonVi.cttaisan_dangquanlys.Count > 0)
                || (objDonVi.cttaisan_dangsudungs != null && objDonVi.cttaisan_dangsudungs.Count > 0)
                || (objDonVi.logtaisan_dangquanlys != null && objDonVi.logtaisan_dangquanlys.Count > 0)
                || (objDonVi.logtaisan_dangsudungs != null && objDonVi.logtaisan_dangsudungs.Count > 0))
                {
                    XtraMessageBox.Show("Không thể xóa đơn vị này!\r\nNguyên do: Có tài sản thuộc đơn vị này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa đơn vị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Guid id = objDonVi.parent != null ? objDonVi.parent.id : Guid.Empty;
                        if (objDonVi.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa đơn vị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(id, true);
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa đơn vị không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    switch (function)
                    {
                        case "add":
                            objDonVi = new DonVi();
                            setDataObj();
                            if (objDonVi.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm đơn vị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objDonVi.id;
                                reLoadAndSelectNode(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm đơn vị không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (objDonVi.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa đơn vị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objDonVi.id;
                                reLoadAndSelectNode(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa đơn vị không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOk_Click: " + ex.Message);
            }
        }
        private void btnLoaiDonVi_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiDV frm = new frmQuanLyLoaiDV();
            frm.ShowDialog();
            loadLoaiDonVi();
        }
        private void btnThem_r_Click(object sender, EventArgs e)
        {
            editGUI("add");
        }
        private void btnSua_r_Click(object sender, EventArgs e)
        {
            editGUI("edit");
        }
        private void btnXoa_r_Click(object sender, EventArgs e)
        {
            deleteObj();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProviderInfo.ClearErrors();
            setDataView();
        }
        private void barBtnLoaiChuThe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQuanLyLoaiDV frm = new frmQuanLyLoaiDV();
            frm.ShowDialog();
            loadLoaiDonVi();
        }
    }
}
