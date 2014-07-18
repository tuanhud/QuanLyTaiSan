using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Localization;

namespace QuanLyTaiSanGUI.QLViTri.MyUserControl
{
    public partial class ucQuanLyViTri : UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, false);
        ucComboBoxViTri _ucComboBoxViTriChonDay = new ucComboBoxViTri(true, false);
        List<HinhAnh> listHinh = new List<HinhAnh>();
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
            //Ẩn ribbon
            ribbonViTri.Parent = null;
            //treeListViTri.Columns[colten.FieldName].SortOrder = SortOrder.Ascending;
            treeListViTri.Columns[colid.FieldName].SortOrder = SortOrder.Ascending;
            //loadData();
        }

        public void loadData()
        {
            try
            {
                listViTriHienThi = ViTriHienThi.getAll();
                if (listViTriHienThi.Count == 0)
                {
                    txtTen.Text = "";
                    txtMoTa.Text = "";
                    enableGroupViTri("");
                    btnR_Sua.Enabled = false;
                    btnR_Xoa.Enabled = false;
                }
                else
                {
                    btnR_Sua.Enabled = true;
                    btnR_Xoa.Enabled = true;
                }
                treeListViTri.DataSource = listViTriHienThi;
                listViTriHienThi = ViTriHienThi.getAllCoSo();
                _ucComboBoxViTri.loadData(listViTriHienThi);
                listViTriHienThi = ViTriHienThi.getAllHaveDay();
                _ucComboBoxViTriChonDay.loadData(listViTriHienThi);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": loadData :" + ex.Message);
            }
            finally
            { }
        }

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    //SetTextGroupControl("Chi tiết", false);
                    if (function.Equals("edit") || function.Equals("add"))
                    {
                        enableEdit(false, "", "");
                        SetTextGroupControl("Chi tiết", false);
                    }
                    if (e.Node.GetValue(2).ToString().Equals(typeof(CoSo).Name))
                    {
                        objCoSo = CoSo.getById(Convert.ToInt32(e.Node.GetValue(0)));
                        setData(typeof(CoSo).Name);
                    }
                    else if (e.Node.GetValue(2).ToString().Equals(typeof(Dayy).Name))
                    {
                        objDay = Dayy.getById(Convert.ToInt32(e.Node.GetValue(0)));
                        setData(typeof(Dayy).Name);
                    }
                    else if (e.Node.GetValue(2).ToString().Equals(typeof(Tang).Name))
                    {
                        objTang = Tang.getById(Convert.ToInt32(e.Node.GetValue(0)));
                        setData(typeof(Tang).Name);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : treeListViTri_FocusedNodeChanged : " + ex.Message);
            }
            finally
            { }
        }

        public void enableEdit(bool _enable, String _type, String _function)
        {
            function = _function;
            btnImage.Visible = _enable;
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            _ucComboBoxViTri.setReadOnly(!_enable);
            _ucComboBoxViTriChonDay.setReadOnly(!_enable);
            type = _type;
            //làm việc
            working = _enable;
            //
            rbnGroupViTri_CoSo.Enabled = !_enable;
            rbnGroupViTri_Day.Enabled = !_enable;
            rbnGroupViTri_Tang.Enabled = !_enable;
            btnR_Them.Enabled = !_enable;
            btnR_Sua.Enabled = !_enable;
            btnR_Xoa.Enabled = !_enable;
            if (_enable)
                txtTen.Focus();
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
                enableEdit(false, "", "");
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
                        objCoSo.hinhanhs = listHinh;
                        if (objCoSo.update() != -1)
                        {
                            XtraMessageBox.Show("Sửa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objCoSo.id, typeof(CoSo).Name);
                        }
                        break;
                    case "Dayy":
                        objDay.ten = txtTen.Text;
                        objDay.mota = txtMoTa.Text;
                        ViTri _vitri = _ucComboBoxViTri.getViTri();
                        objDay.coso = _vitri.coso;
                        objDay.hinhanhs = listHinh;
                        if (objDay.update() != -1)
                        {
                            XtraMessageBox.Show("Sửa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objDay.id, typeof(Dayy).Name);
                        }
                        break;
                    case "Tang":
                        objTang.ten = txtTen.Text;
                        objTang.mota = txtMoTa.Text;
                        ViTri _vitri2 = _ucComboBoxViTriChonDay.getViTri();
                        objTang.day = _vitri2.day;
                        objTang.hinhanhs = listHinh;
                        if (objTang.update() != -1)
                        {
                            XtraMessageBox.Show("Sửa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objTang.id, typeof(Tang).Name);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : editObj : " + ex.Message);
            }
            finally
            { }
        }

        public void beforeAdd(String _type)
        {
            try
            {
                txtTen.Text = "";
                txtMoTa.Text = "";
                imageSlider1.Images.Clear();
                ViTri _vitri;
                type = _type;
                switch (_type)
                {
                    case "CoSo":
                        //ThemMoiNode(-1, "", typeof(CoSo).Name);
                        listHinh = new List<HinhAnh>();
                        panelControl1.Controls.Clear();
                        TextEdit txt = new TextEdit();
                        txt.Properties.ReadOnly = true;
                        txt.Text = "[Đại học Sài Gòn]";
                        txt.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(txt);
                        break;
                    case "Dayy":
                        listHinh = new List<HinhAnh>();
                        panelControl1.Controls.Clear();
                        _ucComboBoxViTri.Dock = DockStyle.Fill;
                        _vitri = new ViTri();
                        if (node.Equals(typeof(CoSo).Name))
                            _vitri.coso = objCoSo;
                        else if (node.Equals(typeof(Dayy).Name))
                            _vitri.coso = objDay.coso;
                        else
                            _vitri.coso = objTang.day.coso;
                        //ThemMoiNode(_vitri.coso.id, typeof(CoSo).Name, typeof(Dayy).Name);
                        _ucComboBoxViTri.setViTri(_vitri);
                        panelControl1.Controls.Add(_ucComboBoxViTri);
                        break;
                    case "Tang":
                        listHinh = new List<HinhAnh>();
                        panelControl1.Controls.Clear();
                        _ucComboBoxViTriChonDay.Dock = DockStyle.Fill;
                        _vitri = new ViTri();
                        if (node.Equals(typeof(Dayy).Name))
                        {
                            _vitri.coso = objDay.coso;
                            _vitri.day = objDay;
                        }
                        else
                        {
                            _vitri.coso = objTang.day.coso;
                            _vitri.day = objTang.day;
                        }
                        //ThemMoiNode(_vitri.day.id, typeof(Dayy).Name, typeof(Tang).Name);
                        _ucComboBoxViTriChonDay.setViTri(_vitri);
                        panelControl1.Controls.Add(_ucComboBoxViTriChonDay);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : beforeAdd : " + ex.Message);
            }
            finally
            { }
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
                        objCoSoNew.hinhanhs = listHinh;
                        if (objCoSoNew.add() != -1)
                        {
                            XtraMessageBox.Show("Thêm cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objCoSoNew.id, typeof(CoSo).Name);
                        }
                        break;
                    case "Dayy":
                        Dayy objDayNew = new Dayy();
                        objDayNew.ten = txtTen.Text;
                        objDayNew.mota = txtMoTa.Text;
                        objDayNew.hinhanhs = listHinh;
                        ViTri _vitri = _ucComboBoxViTri.getViTri();
                        objDayNew.coso = _vitri.coso;
                        if (objDayNew.add() != -1)
                        {
                            XtraMessageBox.Show("Thêm dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objDayNew.id, typeof(Dayy).Name);
                        }
                        break;
                    case "Tang":
                        Tang objTangNew = new Tang();
                        objTangNew.ten = txtTen.Text;
                        objTangNew.mota = txtMoTa.Text;
                        objTangNew.hinhanhs = listHinh;
                        ViTri _vitri2 = _ucComboBoxViTriChonDay.getViTri();
                        objTangNew.day = _vitri2.day;
                        if (objTangNew.add() != -1)
                        {
                            XtraMessageBox.Show("Thêm tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objTangNew.id, typeof(Tang).Name);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : addObj : " + ex.Message);
            }
            finally
            { }
        }

        public void deleteObj(String _type)
        {
            try
            {
                switch (_type)
                {
                    case "CoSo":
                        if (XtraMessageBox.Show("Bạn có chắc là muốn xóa cơ sở?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            int ree = objCoSo.delete();
                            if (ree>0)
                            {
                                XtraMessageBox.Show("Xóa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reLoad();
                            }
                            else if(ree==-2)
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
                            CoSo obj = objDay.coso;
                            int ree = objDay.delete();
                            if (ree>0)
                            {
                                XtraMessageBox.Show("Xóa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reLoad();
                            }

                            else if(ree==-2)
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
                            Dayy obj = objTang.day;
                            if (objTang.delete() > 0)
                            {
                                XtraMessageBox.Show("Xóa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reLoad();
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
                System.Console.WriteLine(this.Name + " : deleteObj : " + ex.Message);
            }
            finally
            { }
        }

        public void reLoad()
        {
            errorProvider1.Clear();
            treeListViTri.ClearNodes();
            loadData();
            if (!function.Equals(""))
            {
                enableEdit(false, "", "");
                SetTextGroupControl("Chi tiết", false);
                listHinh = new List<HinhAnh>();
            }
        }

        private void reLoadAndSelectNode(int _id, String _type)
        {
            try
            {
                reLoad();
                FindNode findNode = new FindNode(_id, _type);
                treeListViTri.NodesIterator.DoOperation(findNode);
                treeListViTri.FocusedNode = findNode.Node;
                enableGroupViTri(_type);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : reLoadAndSelectNode : " + ex.Message);
            }
            finally
            { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (function.Equals("add"))
            {
                reLoad();
            }
            else if (function.Equals("edit"))
            {
                enableEdit(false, "", "");
                SetTextGroupControl("Chi tiết", false);
                listHinh = new List<HinhAnh>();
                setData(node);
            }
        }

        public void SetTextGroupControl(String _text, bool _color)
        {
            groupControl1.Text = _text;
            if(_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Empty;   
        }

        private Boolean CheckInput()
        {
            errorProvider1.Clear();
            if (txtTen.Text.Length == 0)
            {
                errorProvider1.SetError(txtTen, "Chưa điền tên");
                return false;
            }
            return true;
        }

        private void reloadImage()
        {
            imageSlider1.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imageSlider1.Images.Add(h.getImage());
            }
            
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = new frmHinhAnh(listHinh);
                switch (type)
                {
                    case "CoSo":
                        if (function.Equals("edit"))
                        {
                            frm.Text = "Quản lý hình ảnh " + objCoSo.ten;
                        }
                        else
                        {
                            frm.Text = "Quản lý hình ảnh cơ sở mới";
                        }
                        break;
                    case "Dayy":
                        if (function.Equals("edit"))
                        {
                            frm.Text = "Quản lý hình ảnh " + objDay.ten;
                        }
                        else
                        {
                            frm.Text = "Quản lý hình ảnh dãy mới";
                        }
                        break;
                    case "Tang":
                        if (function.Equals("edit"))
                        {
                            frm.Text = "Quản lý hình ảnh " + objTang.ten;
                        }
                        else
                        {
                            frm.Text = "Quản lý hình ảnh tầng mới";
                        }
                        break;
                }
                frm.ShowDialog();
                listHinh = frm.getlistHinhs();
                reloadImage();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : btnImage_Click : " + ex.Message);
            }
            finally
            { }
        }

        public void setData(String _type)
        {
            try
            {
                ViTri objViTri = null;
                errorProvider1.Clear();
                switch (_type)
                {
                    case "CoSo":
                        txtTen.Text = objCoSo.ten;
                        txtMoTa.Text = objCoSo.mota;
                        panelControl1.Controls.Clear();
                        TextEdit txt = new TextEdit();
                        txt.Properties.ReadOnly = true;
                        txt.Text = "[Đại học Sài Gòn]";
                        txt.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(txt);
                        node = typeof(CoSo).Name;
                            listHinh = objCoSo.hinhanhs.ToList();
                        reloadImage();
                        enableGroupViTri(typeof(CoSo).Name);
                        break;
                    case "Dayy":
                        panelControl1.Controls.Clear();
                        _ucComboBoxViTri.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(_ucComboBoxViTri);
                        txtTen.Text = objDay.ten;
                        txtMoTa.Text = objDay.mota;
                        objViTri = new ViTri();
                        objViTri.coso = objDay.coso;
                        _ucComboBoxViTri.setViTri(objViTri);
                        node = typeof(Dayy).Name;
                            listHinh = objDay.hinhanhs.ToList();
                        reloadImage();
                        enableGroupViTri(typeof(Dayy).Name);
                        break;
                    case "Tang":
                        panelControl1.Controls.Clear();
                        _ucComboBoxViTriChonDay.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(_ucComboBoxViTriChonDay);
                        txtTen.Text = objTang.ten;
                        txtMoTa.Text = objTang.mota;
                        objViTri = new ViTri();
                        objViTri.day = objTang.day;
                        objViTri.coso = objTang.day.coso;
                        _ucComboBoxViTriChonDay.setViTri(objViTri);
                        node = typeof(Tang).Name;
                            listHinh = objTang.hinhanhs.ToList();
                        reloadImage();
                        enableGroupViTri(typeof(Tang).Name);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : setData : " + ex.Message);
            }
            finally
            { }
        }

        public RibbonControl getRibbon()
        {
            return ribbonViTri;
        }

        private void barBtnThemCoSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            beforeAdd(typeof(CoSo).Name);
            SetTextGroupControl("Thêm cơ sở", true);
            enableEdit(true, typeof(CoSo).Name, "add");
        }

        private void barBtnSuaCoSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setData(typeof(CoSo).Name);
            SetTextGroupControl("Sửa cơ sở", true);
            enableEdit(true, typeof(CoSo).Name, "edit");
        }

        private void barBtnXoaCoSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj(typeof(CoSo).Name);
        }

        private void barBtnThemDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            beforeAdd(typeof(Dayy).Name);
            SetTextGroupControl("Thêm dãy", true);
            enableEdit(true, typeof(Dayy).Name, "add");
        }

        private void barBtnSuaDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setData(typeof(Dayy).Name);
            SetTextGroupControl("Sửa dãy", true);
            enableEdit(true, typeof(Dayy).Name, "edit");
        }

        private void barBtnXoaDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj(typeof(Dayy).Name);
        }

        private void barBtnThemTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            beforeAdd(typeof(Tang).Name);
            SetTextGroupControl("Thêm tầng", true);
            enableEdit(true, typeof(Tang).Name, "add");
        }

        private void barBtnSuaTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setData(typeof(Tang).Name);
            SetTextGroupControl("Sửa tầng", true);
            enableEdit(true, typeof(Tang).Name, "edit");
        }

        private void barBtnXoaTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj(typeof(Tang).Name);
        }

        public void enableGroupViTri(String _type)
        {
            switch (_type)
            {
                case "CoSo":
                    rbnGroupViTri_Day.Enabled = true;
                    rbnGroupViTri_Tang.Enabled = false;
                    barBtnSuaDay.Enabled = false;
                    barBtnXoaDay.Enabled = false;
                    barBtnSuaCoSo.Enabled = true;
                    barBtnXoaCoSo.Enabled = true;
                    break;
                case "Dayy":
                    rbnGroupViTri_Day.Enabled = true;
                    rbnGroupViTri_Tang.Enabled = true;
                    barBtnSuaDay.Enabled = true;
                    barBtnXoaDay.Enabled = true;
                    barBtnSuaTang.Enabled = false;
                    barBtnXoaTang.Enabled = false;
                    barBtnSuaCoSo.Enabled = false;
                    barBtnXoaCoSo.Enabled = false;
                    break;
                case "Tang":
                    rbnGroupViTri_Tang.Enabled = true;
                    barBtnSuaDay.Enabled = false;
                    barBtnXoaDay.Enabled = false;
                    barBtnSuaTang.Enabled = true;
                    barBtnXoaTang.Enabled = true;
                    barBtnSuaCoSo.Enabled = false;
                    barBtnXoaCoSo.Enabled = false;
                    break;
                default:
                    rbnGroupViTri_Day.Enabled = false;
                    rbnGroupViTri_Tang.Enabled = false;
                    barBtnSuaCoSo.Enabled = false;
                    barBtnXoaCoSo.Enabled = false;
                    break;
            }
        }

        private void ThemMoiNode(int _id, String _type, String _typenode)
        {
            try
            {
                FindNode findNode = null;
                if (_type.Equals(""))
                {
                    treeListViTri.AppendNode(new object[] { -1, "new", "new" }, null);
                    findNode = new FindNode(-1, "new");
                    treeListViTri.NodesIterator.DoOperation(findNode);
                    treeListViTri.FocusedNode = findNode.Node;
                }
                else
                {
                    findNode = new FindNode(_id, _type);
                    treeListViTri.NodesIterator.DoOperation(findNode);
                    treeListViTri.AppendNode(new object[] { -1, "new", "new" }, findNode.Node);
                    findNode = new FindNode(-1, "new");
                    treeListViTri.NodesIterator.DoOperation(findNode);
                    treeListViTri.FocusedNode = findNode.Node;
                }
                enableGroupViTri(_typenode);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : ThemMoiNode : " + ex.Message);
            }
            finally
            { }
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
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
            if (node.GetDisplayText(column).ToUpper().Contains(filterValue.ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }

        private void btnR_Xoa_Click(object sender, EventArgs e)
        {
            deleteObj(node);
        }

        private void btnR_Sua_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                setData(node);
                if (node.Equals(typeof(CoSo).Name))
                {
                    SetTextGroupControl("Sửa cơ sở", true);
                }
                else if (node.Equals(typeof(Dayy).Name))
                {
                    SetTextGroupControl("Sửa dãy", true);
                }
                else
                {
                    SetTextGroupControl("Sửa tầng", true);
                }
                enableEdit(true, node, "edit");
            }
        }

        private void btnR_Them_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                beforeAdd(node);
                if (node.Equals(typeof(CoSo).Name))
                {
                    SetTextGroupControl("Thêm cơ sở", true);
                }
                else if (node.Equals(typeof(Dayy).Name))
                {
                    SetTextGroupControl("Thêm dãy", true);
                }
                else
                {
                    SetTextGroupControl("Thêm tầng", true);
                }
                enableEdit(true, node, "add");
            }
        }
        public bool checkworking()
        {
            try
            {
                if (!function.Equals("edit"))
                    return working;
                else
                {
                    if (type.Equals("CoSo"))
                        return objCoSo.ten != txtTen.Text || objCoSo.mota != txtMoTa.Text || objCoSo.hinhanhs.ToString() != listHinh.ToString();
                    else if (type.Equals("Dayy"))
                    {
                        ViTri _vitri = _ucComboBoxViTri.getViTri();
                        return objDay.ten != txtTen.Text || objDay.mota != txtMoTa.Text || objDay.coso != _vitri.coso || objDay.hinhanhs.ToString() != listHinh.ToString();
                    }
                    else if (type.Equals("Tang"))
                    {
                        ViTri _vitri2 = _ucComboBoxViTriChonDay.getViTri();
                        return objTang.ten != txtTen.Text || objTang.mota != txtMoTa.Text || objTang.day != _vitri2.day || objTang.hinhanhs.ToString() != listHinh.ToString();
                    }
                    else
                        return true;
                }
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
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportViTri(open.FileName, "ViTri"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                    reLoad();
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                    reLoad();
                }

            }
        }

        private void imageSlider1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listHinh != null && listHinh.Count > 0)
            {
                frmShowImage frm = new frmShowImage(listHinh);
                frm.ShowDialog();
            }
        }

        private void barBtnMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (objCoSo != null && objCoSo.id > 0 && objCoSo.mota.Length>0)
            {
                String url = @"http://www.google.com/maps/search/";
                System.Diagnostics.Process.Start(url + objCoSo.mota);
            }
        }
    }
}
