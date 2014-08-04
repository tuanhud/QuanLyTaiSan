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
        TextEdit txt = new TextEdit();
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, false);
        ucComboBoxViTri _ucComboBoxViTriChonDay = new ucComboBoxViTri(true, false);
        List<HinhAnh> listHinh = new List<HinhAnh>();
        CoSo objCoSo = new CoSo();
        Dayy objDay = new Dayy();
        Tang objTang = new Tang();
        String type = "";
        String function = "";
        String node = "";
        int khoangcach = -1;
        Point pointLabelMota, pointTxtMota, pointBtnOK, pointBtnHuy;
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
            //treeListViTri.Columns[colid.FieldName].SortOrder = SortOrder.Ascending;
            txt.Properties.ReadOnly = true;
            txt.Text = "[Đại học Sài Gòn]";
            txt.Dock = DockStyle.Fill;
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            _ucComboBoxViTriChonDay.Dock = DockStyle.Fill;

            pointLabelMota = labelControlMoTa.Location;
            pointTxtMota = txtMoTa.Location;
            pointBtnOK = btnOK.Location;
            pointBtnHuy = btnHuy.Location;
            khoangcach = Math.Abs(txtDiaChi.Location.Y - txtMoTa.Location.Y);
        }

        public void loadData()
        {
            try
            {
                listViTriHienThi = ViTriHienThi.getAllCoSo();
                _ucComboBoxViTri.loadData(listViTriHienThi);
                listViTriHienThi = ViTriHienThi.getAllHaveDay();
                _ucComboBoxViTriChonDay.loadData(listViTriHienThi);
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

        private void showDiaChi(bool show)
        {
            labelControlDiaChi.Visible = show;
            txtDiaChi.Visible = show;
            if (!show)
            {
                labelControlMoTa.Location = labelControlDiaChi.Location;
                txtMoTa.Location = txtDiaChi.Location;
                btnOK.Location = new Point(pointBtnOK.X, pointBtnOK.Y - khoangcach);
                btnHuy.Location = new Point(pointBtnHuy.X, pointBtnHuy.Y - khoangcach);
            }
            else
            {
                labelControlMoTa.Location = pointLabelMota;
                txtMoTa.Location = pointTxtMota;
                btnOK.Location = new Point(pointBtnOK.X, pointBtnOK.Y);
                btnHuy.Location = new Point(pointBtnHuy.X, pointBtnHuy.Y);
            }
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
                        showDiaChi(true);
                        enableCoSoButton(true);
                        barBtnThemCoSo.Enabled = true;
                        enableDayButton(false);
                        barBtnThemDay.Enabled = true;
                        enableTangButton(false);
                        barBtnThemTang.Enabled = false;
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(txt);
                    }
                    else if (_type.Equals(typeof(Dayy).Name))
                    {
                        SetTextGroupControl("Chi tiết dãy", Color.Empty);
                        showDiaChi(false);
                        enableCoSoButton(false);
                        barBtnThemCoSo.Enabled = true;
                        enableDayButton(true);
                        barBtnThemDay.Enabled = true;
                        enableTangButton(false);
                        barBtnThemTang.Enabled = true;
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucComboBoxViTri);
                    }
                    else if (_type.Equals(typeof(Tang).Name))
                    {
                        SetTextGroupControl("Chi tiết tầng", Color.Empty);
                        showDiaChi(false);
                        enableCoSoButton(false);
                        barBtnThemCoSo.Enabled = true;
                        enableDayButton(false);
                        barBtnThemDay.Enabled = true;
                        enableTangButton(true);
                        barBtnThemTang.Enabled = true;
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucComboBoxViTriChonDay);
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
                        showDiaChi(true);
                        if (panelControl1.Controls.Count > 0 && !panelControl1.Controls[0].Equals(txt))
                        {
                            panelControl1.Controls.Clear();
                            panelControl1.Controls.Add(txt);
                        }
                    }
                    else if (_type.Equals(typeof(Dayy).Name))
                    {
                        SetTextGroupControl("Thêm dãy", Color.Red);
                        showDiaChi(false);
                        if (panelControl1.Controls.Count > 0 && !panelControl1.Controls[0].Equals(_ucComboBoxViTri))
                        {
                            panelControl1.Controls.Clear();
                            panelControl1.Controls.Add(_ucComboBoxViTri);
                        }
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
                        _ucComboBoxViTri.setViTri(obj);
                    }
                    else if (_type.Equals(typeof(Tang).Name))
                    {
                        SetTextGroupControl("Thêm tầng", Color.Red);
                        showDiaChi(false);
                        if (panelControl1.Controls.Count > 0 && !panelControl1.Controls[0].Equals(_ucComboBoxViTriChonDay))
                        {
                            panelControl1.Controls.Clear();
                            panelControl1.Controls.Add(_ucComboBoxViTriChonDay);
                        }
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
                        _ucComboBoxViTriChonDay.setViTri(obj);
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
                        showDiaChi(true);
                        if (panelControl1.Controls.Count > 0 && !panelControl1.Controls[0].Equals(txt))
                        {
                            panelControl1.Controls.Clear();
                            panelControl1.Controls.Add(txt);
                        }
                    }
                    else if (_type.Equals(typeof(Dayy).Name))
                    {
                        SetTextGroupControl("Sửa dãy", Color.Red);
                        showDiaChi(false);
                        if (panelControl1.Controls.Count > 0 && !panelControl1.Controls[0].Equals(_ucComboBoxViTri))
                        {
                            panelControl1.Controls.Clear();
                            panelControl1.Controls.Add(_ucComboBoxViTri);
                        }
                    }
                    else if (_type.Equals(typeof(Tang).Name))
                    {
                        SetTextGroupControl("Sửa tầng", Color.Red);
                        showDiaChi(false);
                        if (panelControl1.Controls.Count > 0 && !panelControl1.Controls[0].Equals(_ucComboBoxViTriChonDay))
                        {
                            panelControl1.Controls.Clear();
                            panelControl1.Controls.Add(_ucComboBoxViTriChonDay);
                        }
                    }
                }
                else if (_function.Equals("nothing"))
                {
                    node = typeof(CoSo).Name;
                    enableEdit(false);
                    SetTextGroupControl("Chi tiết", Color.Empty);
                    enableRightButton(false);
                    btnR_Them.Enabled = true;
                    enableCoSoButton(false);
                    barBtnThemCoSo.Enabled = true;
                    enableDayButton(false);
                    barBtnThemDay.Enabled = false;
                    enableTangButton(false);
                    barBtnThemTang.Enabled = false;
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(txt);
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

        private void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        private void enableEdit(bool _enable)
        {
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            btnImage.Visible = _enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            txtDiaChi.Properties.ReadOnly = !_enable;
            _ucComboBoxViTri.setReadOnly(!_enable);
            _ucComboBoxViTriChonDay.setReadOnly(!_enable);
            enableRightButton(!_enable);
            btnR_Them.Enabled = !_enable;
            working = _enable;
        }

        private void enableRightButton(bool _enable)
        {
            //btnR_Them.Enabled = _enable;
            btnR_Sua.Enabled = _enable;
            btnR_Xoa.Enabled = _enable;
            barBtnDown.Enabled = _enable;
            barBtnUp.Enabled = _enable;
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
            listHinh = new List<HinhAnh>();
            imageSlider1.Images.Clear();
        }

        
        private void setDataView()
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                if (listViTriHienThi.Count > 0)
                {
                    if (treeListViTri.FocusedNode != null && treeListViTri.FocusedNode.GetValue(2) != null && Convert.ToInt32(treeListViTri.FocusedNode.GetValue(0)) > 0)
                    {
                        if (treeListViTri.FocusedNode.GetValue(2).ToString().Equals(typeof(CoSo).Name))
                        {
                            editGUI("view", typeof(CoSo).Name);
                            objCoSo = CoSo.getById(Convert.ToInt32(treeListViTri.FocusedNode.GetValue(0)));
                            txtTen.Text = objCoSo.ten;
                            txtMoTa.Text = objCoSo.mota;
                            node = typeof(CoSo).Name;
                            listHinh = objCoSo.hinhanhs.ToList();
                            reloadImage();
                        }
                        else if (treeListViTri.FocusedNode.GetValue(2).ToString().Equals(typeof(Dayy).Name))
                        {
                            editGUI("view", typeof(Dayy).Name);
                            objDay = Dayy.getById(Convert.ToInt32(treeListViTri.FocusedNode.GetValue(0)));
                            txtTen.Text = objDay.ten;
                            txtMoTa.Text = objDay.mota;
                            node = typeof(Dayy).Name;
                            listHinh = objDay.hinhanhs.ToList();
                            ViTri objViTri = new ViTri();
                            objViTri.coso = objDay.coso;
                            _ucComboBoxViTri.setViTri(objViTri);
                            reloadImage();
                        }
                        else if (treeListViTri.FocusedNode.GetValue(2).ToString().Equals(typeof(Tang).Name))
                        {
                            editGUI("view", typeof(Tang).Name);
                            objTang = Tang.getById(Convert.ToInt32(treeListViTri.FocusedNode.GetValue(0)));
                            txtTen.Text = objTang.ten;
                            txtMoTa.Text = objTang.mota;
                            node = typeof(Tang).Name;
                            listHinh = objTang.hinhanhs.ToList();
                            ViTri objViTri = new ViTri();
                            objViTri.coso = objTang.day.coso;
                            objViTri.day = objTang.day;
                            _ucComboBoxViTriChonDay.setViTri(objViTri);
                            reloadImage();
                        }
                    }
                    else
                    {
                        editGUI("nothing","");
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
        

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            setDataView();
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
                        objCoSo.diachi = txtDiaChi.Text;
                        objCoSo.hinhanhs = listHinh;
                        if (objCoSo.update() > 0)
                        {
                            XtraMessageBox.Show("Sửa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objCoSo.id, typeof(CoSo).Name);
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa cơ sở không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Dayy":
                        objDay.ten = txtTen.Text;
                        objDay.mota = txtMoTa.Text;
                        ViTri _vitri = _ucComboBoxViTri.getViTri();
                        objDay.coso = _vitri.coso;
                        objDay.hinhanhs = listHinh;
                        if (objDay.update() > 0)
                        {
                            XtraMessageBox.Show("Sửa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objDay.id, typeof(Dayy).Name);
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa dãy không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Tang":
                        objTang.ten = txtTen.Text;
                        objTang.mota = txtMoTa.Text;
                        ViTri _vitri2 = _ucComboBoxViTriChonDay.getViTri();
                        objTang.day = _vitri2.day;
                        objTang.hinhanhs = listHinh;
                        if (objTang.update() > 0)
                        {
                            XtraMessageBox.Show("Sửa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objTang.id, typeof(Tang).Name);
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
                        objCoSo.diachi = txtDiaChi.Text;
                        objCoSoNew.hinhanhs = listHinh;
                        if (objCoSoNew.add() > 0)
                        {
                            XtraMessageBox.Show("Thêm cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objCoSoNew.id, typeof(CoSo).Name);
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
                        objDayNew.hinhanhs = listHinh;
                        ViTri _vitri = _ucComboBoxViTri.getViTri();
                        objDayNew.coso = _vitri.coso;
                        if (objDayNew.add() > 0)
                        {
                            XtraMessageBox.Show("Thêm dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objDayNew.id, typeof(Dayy).Name);
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
                        objTangNew.hinhanhs = listHinh;
                        ViTri _vitri2 = _ucComboBoxViTriChonDay.getViTri();
                        objTangNew.day = _vitri2.day;
                        if (objTangNew.add() > 0)
                        {
                            XtraMessageBox.Show("Thêm tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoadAndSelectNode(objTangNew.id, typeof(Tang).Name);
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
                            if (ree>0)
                            {
                                XtraMessageBox.Show("Xóa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadData();
                            }
                            else if(ree == -2)
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
                            if (ree>0)
                            {
                                XtraMessageBox.Show("Xóa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reLoadAndSelectNode(objCoSo.id, typeof(CoSo).Name, true);
                            }
                            else if(ree == -2)
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
                            if (objTang.delete() > 0)
                            {
                                XtraMessageBox.Show("Xóa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reLoadAndSelectNode(objDay.id, typeof(Dayy).Name, true);
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

        private void reLoadAndSelectNode(int _id, String _type, bool _expanded = false)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                loadData();
                FindNode findNode = new FindNode(_id, _type);
                treeListViTri.NodesIterator.DoOperation(findNode);
                treeListViTri.FocusedNode = findNode.Node;
                treeListViTri.FocusedNode.Expanded = _expanded;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reLoadAndSelectNode: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            setDataView();
        }

        private Boolean CheckInput()
        {
            dxErrorProvider1.ClearErrors();
            Boolean check = true;
            if (txtTen.Text.Length == 0)
            {
                check = false;
                dxErrorProvider1.SetError(txtTen, "Chưa điền tên");
            }
            return check;
        }

        private void reloadImage()
        {
            try
            {
                imageSlider1.Images.Clear();
                if (listHinh != null)
                {
                    foreach (HinhAnh h in listHinh)
                    {
                        imageSlider1.Images.Add(h.getImage());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadImage: " + ex.Message);
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
                Debug.WriteLine(this.Name + "->btnImage_Click: " + ex.Message);
            }
        }

        public RibbonControl getRibbon()
        {
            return ribbonViTri;
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
            editGUI("edit", node);
        }

        private void btnR_Them_Click(object sender, EventArgs e)
        {
            editGUI("add", node);
        }
        public bool checkworking()
        {
            try
            {
                if (function.Equals("add"))
                {
                    return
                        !txtTen.Text.Equals("") ||
                        !txtMoTa.Text.Equals("") ||
                        (txtDiaChi.Properties.ReadOnly && !txtDiaChi.Text.Equals("")) ||
                        listHinh.Count() > 0;
                }
                else if (function.Equals("edit"))
                {
                    if (type.Equals("CoSo"))
                        return
                            objCoSo.ten != txtTen.Text ||
                            objCoSo.mota != txtMoTa.Text ||
                            (txtDiaChi.Text != (objCoSo.diachi != null ? objCoSo.diachi : "")) ||
                            objCoSo.hinhanhs.Except(listHinh).Count() > 0 ||
                            listHinh.Except(objCoSo.hinhanhs).Count() > 0;
                    else if (type.Equals("Dayy"))
                    {
                        ViTri _vitri = _ucComboBoxViTri.getViTri();
                        return
                            objDay.ten != txtTen.Text ||
                            objDay.mota != txtMoTa.Text ||
                            objDay.coso != _vitri.coso ||
                            objDay.hinhanhs.Except(listHinh).Count() > 0 ||
                            listHinh.Except(objDay.hinhanhs).Count() > 0;
                    }
                    else if (type.Equals("Tang"))
                    {
                        ViTri _vitri2 = _ucComboBoxViTriChonDay.getViTri();
                        return
                            objTang.ten != txtTen.Text ||
                            objTang.mota != txtMoTa.Text ||
                            objTang.day != _vitri2.day ||
                            objTang.hinhanhs.Except(listHinh).Count() > 0 ||
                            listHinh.Except(objTang.hinhanhs).Count() > 0;
                    }
                    else
                        return true;
                }
                else
                    return working;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkworking: " + ex.Message);
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
                    loadData();
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                    loadData();
                }

            }
        }

        private void imageSlider1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (imageSlider1.Images.Count > 0)
            {
                frmShowImage frm = new frmShowImage(listHinh);
                frm.ShowDialog();
            }
        }

        private void barBtnMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (objCoSo != null && objCoSo.id > 0 && objCoSo.diachi != null && objCoSo.diachi.Length > 0)
            {
                String url = @"http://www.google.com/maps/search/";
                System.Diagnostics.Process.Start(url + objCoSo.diachi);
            }
        }

        private void barBtnUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (node.Equals(typeof(CoSo).Name))
                {
                    objCoSo.moveUp();
                    reLoadAndSelectNode(objCoSo.id, typeof(CoSo).Name);
                }
                else if (node.Equals(typeof(Dayy).Name))
                {
                    objDay.moveUp();
                    reLoadAndSelectNode(objDay.id, typeof(Dayy).Name);
                }
                else if (node.Equals(typeof(Tang).Name))
                {
                    objTang.moveUp();
                    reLoadAndSelectNode(objTang.id, typeof(Tang).Name);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->barBtnUp_ItemClick: " + ex.Message);
            }
        }

        private void barBtnDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (node.Equals(typeof(CoSo).Name))
                {
                    objCoSo.moveDown();
                    reLoadAndSelectNode(objCoSo.id, typeof(CoSo).Name);
                }
                else if (node.Equals(typeof(Dayy).Name))
                {
                    objDay.moveDown();
                    reLoadAndSelectNode(objDay.id, typeof(Dayy).Name);
                }
                else if (node.Equals(typeof(Tang).Name))
                {
                    objTang.moveDown();
                    reLoadAndSelectNode(objTang.id, typeof(Tang).Name);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->barBtnDown_ItemClick: " + ex.Message);
            }
        }
    }
}
