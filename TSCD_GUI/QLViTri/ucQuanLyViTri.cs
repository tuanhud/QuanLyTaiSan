using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using TSCD.Entities;
using SHARED.Libraries;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using TSCD_GUI.MyUserControl;

namespace TSCD_GUI.QLViTri
{
    public partial class ucQuanLyViTri : DevExpress.XtraEditors.XtraUserControl
    {

        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        TextEdit txt = new TextEdit();
        ucComboBoxViTri _ucComboBoxCoSo = new ucComboBoxViTri();
        ucComboBoxViTri _ucComboBoxDay = new ucComboBoxViTri();

        CoSo objCoSo = new CoSo();
        Dayy objDay = new Dayy();
        Tang objTang = new Tang();
        String type = "";
        String function = "";
        String node = "";
        public Boolean working = false;

        public ucQuanLyViTri()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlViTri.Parent = null;
            _ucComboBoxCoSo.Dock = DockStyle.Fill;
            _ucComboBoxDay.Dock = DockStyle.Fill;
            txt.Properties.ReadOnly = true;
            txt.Text = "[Đại học Sài Gòn]";
            txt.Dock = DockStyle.Fill;
        }

        public void loadData()
        {
            try
            {
                _ucComboBoxCoSo.loadData(ViTriHienThi.getAllCoSo());
                _ucComboBoxDay.loadData(ViTriHienThi.getAllHaveDay(), true, false);
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count == 0)
                {
                    editGUI("nothing", "");
                }
                treeListViTri.DataSource = listViTriHienThi;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlViTri;
        }

        private void editGUI(String _function, String _type)
        {
            try
            {
                if (_function.Equals("view"))
                {
                    enableEdit(false);
                    if (_type.Equals(typeof(CoSo).Name))
                    {
                        SetTextGroupControl("Chi tiết cơ sở", Color.Empty);
                        enableCoSoButton(true);
                        barBtnThemCoSo.Enabled = true;
                        enableDayButton(false);
                        barBtnThemDay.Enabled = true;
                        enableTangButton(false);
                        barBtnThemTang.Enabled = false;
                        setPanelControlViTri(typeof(CoSo).Name);
                    }
                    else if (_type.Equals(typeof(Dayy).Name))
                    {
                        SetTextGroupControl("Chi tiết dãy", Color.Empty);
                        enableCoSoButton(false);
                        barBtnThemCoSo.Enabled = true;
                        enableDayButton(true);
                        barBtnThemDay.Enabled = true;
                        enableTangButton(false);
                        barBtnThemTang.Enabled = true;
                        setPanelControlViTri(typeof(Dayy).Name);
                    }
                    else if (_type.Equals(typeof(Tang).Name))
                    {
                        SetTextGroupControl("Chi tiết tầng", Color.Empty);
                        enableCoSoButton(false);
                        barBtnThemCoSo.Enabled = true;
                        enableDayButton(false);
                        barBtnThemDay.Enabled = true;
                        enableTangButton(true);
                        barBtnThemTang.Enabled = true;
                        setPanelControlViTri(typeof(Tang).Name);
                    }
                }
                else if (_function.Equals("add"))
                {
                    enableEdit(true);
                    enableCoSoButton(false);
                    barBtnThemCoSo.Enabled = false;
                    enableDayButton(false);
                    barBtnThemDay.Enabled = false;
                    enableTangButton(false);
                    barBtnThemTang.Enabled = false;
                    clearText();
                    txtTen.Focus();
                    if (_type.Equals(typeof(CoSo).Name))
                    {
                        SetTextGroupControl("Thêm cơ sở", Color.Red);
                        setPanelControlViTri(typeof(CoSo).Name);
                    }
                    else if (_type.Equals(typeof(Dayy).Name))
                    {
                        SetTextGroupControl("Thêm dãy", Color.Red);
                        setPanelControlViTri(typeof(Dayy).Name);
                        ViTri obj = new ViTri();
                        if (node.Equals(typeof(CoSo).Name))
                        {
                            obj.coso = objCoSo;
                        }
                        else if (node.Equals(typeof(Dayy).Name))
                        {
                            obj.coso = objDay.coso;
                        }
                        else if (node.Equals(typeof(Tang).Name))
                        {
                            obj.coso = objTang.day.coso;
                        }
                        _ucComboBoxCoSo.setViTri(obj);
                    }
                    else if (_type.Equals(typeof(Tang).Name))
                    {
                        SetTextGroupControl("Thêm tầng", Color.Red);
                        setPanelControlViTri(typeof(Tang).Name);
                        ViTri obj = new ViTri();
                        if (node.Equals(typeof(Dayy).Name))
                        {
                            obj.day = objDay;
                            obj.coso = objDay.coso;
                        }
                        else if (node.Equals(typeof(Tang).Name))
                        {
                            obj.day = objTang.day;
                            obj.coso = objTang.day.coso;
                        }
                        _ucComboBoxDay.setViTri(obj);
                    }
                }
                else if (_function.Equals("edit"))
                {
                    enableEdit(true);
                    enableCoSoButton(false);
                    barBtnThemCoSo.Enabled = false;
                    enableDayButton(false);
                    barBtnThemDay.Enabled = false;
                    enableTangButton(false);
                    barBtnThemTang.Enabled = false;
                    txtTen.Focus();
                    if (_type.Equals(typeof(CoSo).Name))
                    {
                        SetTextGroupControl("Sửa cơ sở", Color.Red);
                    }
                    else if (_type.Equals(typeof(Dayy).Name))
                    {
                        SetTextGroupControl("Sửa dãy", Color.Red);
                    }
                    else if (_type.Equals(typeof(Tang).Name))
                    {
                        SetTextGroupControl("Sửa tầng", Color.Red);
                    }
                }
                else if (_function.Equals("nothing"))
                {
                    node = typeof(CoSo).Name;
                    enableEdit(false);
                    SetTextGroupControl("Chi tiết", Color.Empty);
                    enableRightButton(false);
                    btnThem_r.Enabled = true;
                    enableCoSoButton(false);
                    barBtnThemCoSo.Enabled = true;
                    enableDayButton(false);
                    barBtnThemDay.Enabled = false;
                    enableTangButton(false);
                    barBtnThemTang.Enabled = false;
                    clearText();
                }
                function = _function;
                type = _type;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->editGUI:" + ex.Message);
            }
        }

        private void setPanelControlViTri(String type)
        {
            if (type.Equals(typeof(CoSo).Name))
            {
                if (panelControlViTri.Controls.Count == 0
                    || (panelControlViTri.Controls.Count > 0 && !panelControlViTri.Controls[0].Equals(txt)))
                {
                    panelControlViTri.Controls.Clear();
                    panelControlViTri.Controls.Add(txt);
                }
            }
            else if (type.Equals(typeof(Dayy).Name))
            {
                if (panelControlViTri.Controls.Count == 0
                    || (panelControlViTri.Controls.Count > 0 && !panelControlViTri.Controls[0].Equals(_ucComboBoxCoSo)))
                {
                    panelControlViTri.Controls.Clear();
                    panelControlViTri.Controls.Add(_ucComboBoxCoSo);
                }
            }
            else if (type.Equals(typeof(Tang).Name))
            {
                if (panelControlViTri.Controls.Count == 0
                    || (panelControlViTri.Controls.Count > 0 && !panelControlViTri.Controls[0].Equals(_ucComboBoxDay)))
                {
                    panelControlViTri.Controls.Clear();
                    panelControlViTri.Controls.Add(_ucComboBoxDay);
                }
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
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            _ucComboBoxCoSo.setReadOnly(!_enable);
            _ucComboBoxDay.setReadOnly(!_enable);
            enableRightButton(!_enable);
            btnThem_r.Enabled = !_enable;
            working = _enable;
        }

        private void enableRightButton(bool _enable)
        {
            btnSua_r.Enabled = _enable;
            btnXoa_r.Enabled = _enable;
            //barBtnDown.Enabled = _enable;
            //barBtnUp.Enabled = _enable;
        }

        private void enableCoSoButton(bool _enable)
        {
            barBtnSuaCoSo.Enabled = _enable;
            barBtnXoaCoSo.Enabled = _enable;
        }

        private void enableDayButton(bool _enable)
        {
            barBtnSuaDay.Enabled = _enable;
            barBtnXoaDay.Enabled = _enable;
        }

        private void enableTangButton(bool _enable)
        {
            barBtnSuaTang.Enabled = _enable;
            barBtnXoaTang.Enabled = _enable;
        }

        private void clearText()
        {
            txtTen.Text = "";
            txtMoTa.Text = "";
            setPanelControlViTri(typeof(CoSo).Name);
        }


        private void setDataView()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                if (listViTriHienThi.Count > 0)
                {
                    if (treeListViTri.FocusedNode != null && treeListViTri.FocusedNode.GetValue(colloai) != null && !GUID.From(treeListViTri.FocusedNode.GetValue(colid)).Equals(Guid.Empty))
                    {
                        if (treeListViTri.FocusedNode.GetValue(colloai).ToString().Equals(typeof(CoSo).Name))
                        {
                            editGUI("view", typeof(CoSo).Name);
                            objCoSo = CoSo.getById(GUID.From(treeListViTri.FocusedNode.GetValue(colid)));
                            txtTen.Text = objCoSo.ten;
                            txtMoTa.Text = objCoSo.mota;
                            node = typeof(CoSo).Name;
                        }
                        else if (treeListViTri.FocusedNode.GetValue(colloai).ToString().Equals(typeof(Dayy).Name))
                        {
                            editGUI("view", typeof(Dayy).Name);
                            objDay = Dayy.getById(GUID.From(treeListViTri.FocusedNode.GetValue(colid)));
                            txtTen.Text = objDay.ten;
                            txtMoTa.Text = objDay.mota;
                            node = typeof(Dayy).Name;
                            _ucComboBoxCoSo.setViTri(ViTri.request(objDay.coso, null, null));
                        }
                        else if (treeListViTri.FocusedNode.GetValue(colloai).ToString().Equals(typeof(Tang).Name))
                        {
                            editGUI("view", typeof(Tang).Name);
                            objTang = Tang.getById(GUID.From(treeListViTri.FocusedNode.GetValue(colid)));
                            txtTen.Text = objTang.ten;
                            txtMoTa.Text = objTang.mota;
                            node = typeof(Tang).Name;
                            _ucComboBoxDay.setViTri(ViTri.request(null, objTang.day, null));
                        }
                    }
                    else
                    {
                        editGUI("nothing", "");
                    }
                }
                else
                {
                    editGUI("nothing", "");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                switch (function)
                {
                    case "edit":
                        editObj(type);
                        break;
                    case "add":
                        addObj(type);
                        break;
                }
            }
        }

        private void editObj(String _type)
        {
            try
            {
                switch (_type)
                {
                    case "CoSo":
                        objCoSo.ten = txtTen.Text;
                        objCoSo.mota = txtMoTa.Text;
                        if (objCoSo.update() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Sửa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objCoSo.id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa cơ sở không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Dayy":
                        objDay.ten = txtTen.Text;
                        objDay.mota = txtMoTa.Text;
                        ViTri _vitri = _ucComboBoxCoSo.getViTri();
                        objDay.coso = _vitri.coso;
                        if (objDay.update() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Sửa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objDay.id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa dãy không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Tang":
                        objTang.ten = txtTen.Text;
                        objTang.mota = txtMoTa.Text;
                        ViTri _vitri2 = _ucComboBoxDay.getViTri();
                        objTang.day = _vitri2.day;
                        if (objTang.update() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Sửa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objTang.id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa tầng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->editObj: " + ex.Message);
            }
        }

        private void addObj(String _type)
        {
            try
            {
                switch (_type)
                {
                    case "CoSo":
                        CoSo objCoSoNew = new CoSo();
                        objCoSoNew.ten = txtTen.Text;
                        objCoSoNew.mota = txtMoTa.Text;
                        if (objCoSoNew.add() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Thêm cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objCoSoNew.id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm cơ sở không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Dayy":
                        Dayy objDayNew = new Dayy();
                        objDayNew.ten = txtTen.Text;
                        objDayNew.mota = txtMoTa.Text;
                        ViTri _vitri = _ucComboBoxCoSo.getViTri();
                        objDayNew.coso = _vitri.coso;
                        if (objDayNew.add() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Thêm dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objDayNew.id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm dãy không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Tang":
                        Tang objTangNew = new Tang();
                        objTangNew.ten = txtTen.Text;
                        objTangNew.mota = txtMoTa.Text;
                        ViTri _vitri2 = _ucComboBoxDay.getViTri();
                        objTangNew.day = _vitri2.day;
                        if (objTangNew.add() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Thêm tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objTangNew.id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm tầng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->addObj: " + ex.Message);
            }
        }

        private void deleteObj(String _type)
        {
            try
            {
                switch (_type)
                {
                    case "CoSo":
                        if (XtraMessageBox.Show("Bạn có chắc là muốn xóa cơ sở?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int ree = objCoSo.delete();
                            if (ree > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Xóa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadData();
                            }
                            else if (ree == -2)
                            {
                                XtraMessageBox.Show("Có phòng trong cơ sở. Vui lòng xóa phòng trước!");
                            }
                            else if (ree == -3)
                            {
                                XtraMessageBox.Show("Có dãy trong cơ sở. Vui lòng xóa dãy trước!");
                            }
                        }
                        break;
                    case "Dayy":
                        if (XtraMessageBox.Show("Bạn có chắc là muốn xóa dãy?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            objCoSo = objDay.coso;
                            int ree = objDay.delete();
                            if (ree > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Xóa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reLoadAndSelectNode(objCoSo.id, true);
                            }
                            else if (ree == -2)
                            {
                                XtraMessageBox.Show("Có phòng trong dãy. Vui lòng xóa phòng trước!");
                            }
                            else if (ree == -3)
                            {
                                XtraMessageBox.Show("Có tầng trong dãy. Vui lòng xóa tầng trước!");
                            }
                        }
                        break;
                    case "Tang":
                        if (XtraMessageBox.Show("Bạn có chắc là muốn xóa tầng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            objDay = objTang.day;
                            if (objTang.delete() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Xóa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reLoadAndSelectNode(objDay.id, true);
                            }
                            else
                            {
                                XtraMessageBox.Show("Có phòng trong tầng. Vui lòng xóa phòng trước!");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
            }
        }

        private void reLoadAndSelectNode(Guid _id, bool _expanded = false)
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                loadData();
                TreeListNode node = treeListViTri.FindNodeByKeyID(_id);
                if (node != null)
                {
                    node.Selected = true;
                    node.Expanded = _expanded;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reLoadAndSelectNode: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProviderInfo.ClearErrors();
            setDataView();
        }

        private Boolean CheckInput()
        {
            dxErrorProviderInfo.ClearErrors();
            Boolean check = true;
            if (txtTen.Text.Length == 0)
            {
                check = false;
                dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên");
            }
            else if (type.Equals(typeof(CoSo).Name))
            {
                if (function.Equals("add"))
                {
                    if (CoSo.getQuery().Where(c => c.ten.ToUpper().Equals(txtTen.Text.ToUpper())).Count() > 0)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên cơ sở này đã tồn tại");
                    }
                }
                else if (function.Equals("edit"))
                {
                    if (!objCoSo.ten.ToUpper().Equals(txtTen.Text.ToUpper()) && CoSo.getQuery().Where(c => c.ten.ToUpper().Equals(txtTen.Text.ToUpper())).Count() > 0)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên cơ sở này đã tồn tại");
                    }
                }
            }
            return check;
        }

        private void OnFilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListViTri.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = treeListViTri.FindFilterText;
            if (StringHelper.CoDauThanhKhongDau(node.GetDisplayText(column)).ToUpper().Contains(StringHelper.CoDauThanhKhongDau(filterValue).ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }

        private void treeListViTri_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            setDataView();
        }

        private void barBtnThemCoSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("add", typeof(CoSo).Name);
        }

        private void barBtnSuaCoSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit", typeof(CoSo).Name);
        }

        private void barBtnXoaCoSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj(typeof(CoSo).Name);
        }

        private void barBtnThemDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("add", typeof(Dayy).Name);
        }

        private void barBtnSuaDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit", typeof(Dayy).Name);
        }

        private void barBtnXoaDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj(typeof(Dayy).Name);
        }

        private void barBtnThemTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("add", typeof(Tang).Name);
        }

        private void barBtnSuaTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit", typeof(Tang).Name);
        }

        private void barBtnXoaTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj(typeof(Tang).Name);
        }
    }
}
