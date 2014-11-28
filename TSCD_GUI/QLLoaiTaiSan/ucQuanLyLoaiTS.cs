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
using TSCD.DataFilter;
using DevExpress.XtraTreeList.Nodes;

namespace TSCD_GUI.QLLoaiTaiSan
{
    public partial class ucQuanLyLoaiTS : DevExpress.XtraEditors.XtraUserControl
    {
        List<LoaiTaiSan> listLoaiTaiSan = new List<LoaiTaiSan>();
        List<DonViTinh> listDonViTinh = new List<DonViTinh>();
        LoaiTaiSan objLoaiTaiSan = new LoaiTaiSan();
        ucComboBoxLoaiTS _ucComboBoxLoaiTS = new ucComboBoxLoaiTS(); 
        String function = "";
        bool working = false;
        public ucQuanLyLoaiTS()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            rbnControlLoaiTS.Parent = null;
            _ucComboBoxLoaiTS.Dock = DockStyle.Fill;
            panelControlParent.Controls.Add(_ucComboBoxLoaiTS);
        }
        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlLoaiTS;
        }
        public void loadData()
        {
            try
            {
                editGUI("view");
                listLoaiTaiSan = LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                treeListLoaiTS.DataSource = LoaiTSHienThi.Convert(listLoaiTaiSan);
                loadDonViTinh();
                LoaiTaiSan LoaiTaiSanNULL = new LoaiTaiSan();
                LoaiTaiSanNULL.id = Guid.Empty;
                LoaiTaiSanNULL.ten = "[Không thuộc loại nào]";
                LoaiTaiSanNULL.parent = null;
                List<LoaiTaiSan> listLoaiTaiSanParent = new List<LoaiTaiSan>(listLoaiTaiSan);
                listLoaiTaiSanParent.Insert(0, LoaiTaiSanNULL);
                _ucComboBoxLoaiTS.DataSource = listLoaiTaiSanParent;
                if (listLoaiTaiSan.Count == 0)
                {
                    enableButton(false);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }
        }
        private void loadDonViTinh()
        {
            try
            {
                listDonViTinh = DonViTinh.getQuery().OrderBy(c => c.ten).ToList();
                DonViTinh DonViTinhNULL = new DonViTinh();
                DonViTinhNULL.id = Guid.Empty;
                DonViTinhNULL.ten = "[Không có đơn vị tính]";
                listDonViTinh.Insert(0, DonViTinhNULL);
                gridLookUpDonVi.Properties.DataSource = listDonViTinh;
                //repositoryLookUpDonVi.DataSource = listDonViTinh;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }
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
                SetTextGroupControl("Thêm loại tài sản", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa loại tài sản", Color.Red);
                enableEdit(true);
                txtTen.Focus();
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
            spinHaoMon351.Properties.ReadOnly = !_enable;
            spinHaoMon32.Properties.ReadOnly = !_enable;
            checkHuuHinh.Properties.ReadOnly = !_enable;
            _ucComboBoxLoaiTS.ReadOnly = !_enable;
            gridLookUpDonVi.Properties.ReadOnly = !_enable;
            enableButton(!_enable);
            btnThem_r.Enabled = !_enable;
            barBtnThemLoaiTS.Enabled = !_enable;
            working = _enable;
        }
        private void enableButton(bool _enable)
        {
            barBtnSuaLoaiTS.Enabled = _enable;
            barBtnXoaLoaiTS.Enabled = _enable;
            btnSua_r.Enabled = _enable;
            btnXoa_r.Enabled = _enable;
        }
        private void clearText()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtMoTa.Text = "";
            _ucComboBoxLoaiTS.LoaiTS = new LoaiTaiSan();
            gridLookUpDonVi.EditValue = null;
        }
        private void setDataView()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                if (!function.Equals("view"))
                    editGUI("view");
                if (treeListLoaiTS.Nodes.Count > 0)
                {
                    TreeListNode node = treeListLoaiTS.FocusedNode;
                    if (node != null && node.GetValue(colobj) != null)
                    {
                        objLoaiTaiSan = node.GetValue(colobj) as LoaiTaiSan;
                        if (objLoaiTaiSan != null)
                        {
                            txtMa.Text = objLoaiTaiSan.subId;
                            txtTen.Text = objLoaiTaiSan.ten;
                            txtMoTa.Text = objLoaiTaiSan.mota;
                            spinHaoMon351.EditValue = objLoaiTaiSan.phantramhaomon_351;
                            spinHaoMon32.EditValue = objLoaiTaiSan.phantramhaomon_32;
                            checkHuuHinh.Checked = objLoaiTaiSan.huuhinh;
                            gridLookUpDonVi.EditValue = objLoaiTaiSan.donvitinh != null ? objLoaiTaiSan.donvitinh.id : Guid.Empty;
                            _ucComboBoxLoaiTS.LoaiTS = objLoaiTaiSan.parent != null ? objLoaiTaiSan.parent : new LoaiTaiSan();
                        }
                        else
                        {
                            clearText();
                            objLoaiTaiSan = new LoaiTaiSan();
                        }
                    }
                    else
                    {
                        clearText();
                        objLoaiTaiSan = new LoaiTaiSan();
                    }
                }
                else
                {
                    enableButton(false);
                    clearText();
                    objLoaiTaiSan = new LoaiTaiSan();
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
                objLoaiTaiSan.subId = txtMa.Text;
                objLoaiTaiSan.ten = txtTen.Text;
                objLoaiTaiSan.mota = txtMoTa.Text;
                objLoaiTaiSan.phantramhaomon_351 = spinHaoMon351.EditValue != null ? double.Parse(spinHaoMon351.EditValue.ToString()) : 0;
                objLoaiTaiSan.phantramhaomon_32 = spinHaoMon32.EditValue != null ? double.Parse(spinHaoMon351.EditValue.ToString()) : 0;
                objLoaiTaiSan.huuhinh = checkHuuHinh.Checked;
                DonViTinh objDonVi = gridLookUpDonVi.EditValue != null ? DonViTinh.getById(GUID.From(gridLookUpDonVi.EditValue)) : null;
                objLoaiTaiSan.donvitinh = (objDonVi != null && objDonVi.id != Guid.Empty) ? objDonVi : null;
                LoaiTaiSan objParent = _ucComboBoxLoaiTS.LoaiTS;
                objLoaiTaiSan.parent = (objParent != null && objParent.id != Guid.Empty) ? objParent : null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataObj: " + ex.Message);
            }
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
                    dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên");
                }
                return check;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkInput: " + ex.Message);
                return false;
            }
        }
        private void deleteObj()
        {
            try
            {
                if (objLoaiTaiSan.childs != null && objLoaiTaiSan.childs.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa!\r\nNguyên do: Có loại tài sản thuộc loại tài sản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (objLoaiTaiSan.taisans != null && objLoaiTaiSan.taisans.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa!\r\nNguyên do: Có tài sản thuộc loại tài sản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa loại tài sản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Guid id = objLoaiTaiSan.parent != null ? objLoaiTaiSan.parent.id : Guid.Empty;
                        if (objLoaiTaiSan.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa loại tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(id, true);
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa loại tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
            }
        }
        private void barBtnDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQuanLyDonViTinh frm = new frmQuanLyDonViTinh();
            frm.ShowDialog();
            loadDonViTinh();
        }
        private void btnDonViTinh_Click(object sender, EventArgs e)
        {
            frmQuanLyDonViTinh frm = new frmQuanLyDonViTinh();
            frm.ShowDialog();
            loadDonViTinh();
        }
        private void treeListLoaiTS_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            setDataView();
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
        private void reLoadAndSelectNode(Guid _id, bool _expanded = false)
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                loadData();
                if (_id != Guid.Empty)
                {
                    DevExpress.XtraTreeList.Nodes.TreeListNode node = treeListLoaiTS.FindNodeByKeyID(_id);
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    switch (function)
                    {
                        case "add":
                            objLoaiTaiSan = new LoaiTaiSan();
                            setDataObj();
                            if (objLoaiTaiSan.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm loại tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objLoaiTaiSan.id;
                                reLoadAndSelectNode(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm loại tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (objLoaiTaiSan.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa loại tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objLoaiTaiSan.id;
                                reLoadAndSelectNode(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa loại tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProviderInfo.ClearErrors();
            setDataView();
        }

        private void barBtnThemLoaiTS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("add");
        }

        private void barBtnSuaLoaiTS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit");
        }

        private void barBtnXoaLoaiTS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        public bool checkworking()
        {
            try
            {
                if (function.Equals("edit"))
                {
                    return
                        (objLoaiTaiSan.subId == null && !txtMa.Text.Equals("")) || 
                        (objLoaiTaiSan.subId != null && objLoaiTaiSan.subId != txtMa.Text) ||
                        objLoaiTaiSan.ten != txtTen.Text ||
                        (objLoaiTaiSan.mota == null && !txtMoTa.Text.Equals("")) ||
                        (objLoaiTaiSan.mota != null && objLoaiTaiSan.mota != txtMoTa.Text) ||
                        objLoaiTaiSan.huuhinh != checkHuuHinh.Checked ||
                        objLoaiTaiSan.donvitinh_id != GUID.From(gridLookUpDonVi.EditValue);
                }
                else if (function.Equals("add"))
                {
                    return
                        !txtMa.Text.Equals("") ||
                        !txtTen.Text.Equals("") ||
                        !txtMoTa.Text.Equals("") ||
                        gridLookUpDonVi.EditValue != null;
                }
                else
                    return working;
            }
            catch
            {
                return true;
            }
        }

        private void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
            open.Title = "Chọn tập tin để Import";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportLoaiTS(open.FileName, "LoaiTS"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                }

            }
        }
    }
}
