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

namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    public partial class ucQuanLyCoSo : UserControl
    {
        List<ViTriFilter> listTree = new List<ViTriFilter>();
        ucTreeViTri _ucTreeViTri = new ucTreeViTri(false, false);
        ucTreeViTri _ucTreeViTriChonDay = new ucTreeViTri(true, false);
        List<HinhAnh> listHinh = new List<HinhAnh>();
        CoSo objCoSo = new CoSo();
        Dayy objDay = new Dayy();
        Tang objTang = new Tang();
        String type = "";
        String function = "";
        String node = "";

        public ucQuanLyCoSo()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            listTree = new ViTriFilter().getAll();
            treeListViTri.DataSource = listTree;
            listTree = new ViTriFilter().getAllCoSo();
            _ucTreeViTri.loadData(listTree);
            listTree = new ViTriFilter().getAllHaveDay();
            _ucTreeViTriChonDay.loadData(listTree);
        }

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    SetTextGroupControl("Chi tiết", false);
                    if (function.Equals("edit") || function.Equals("add"))
                        enableEdit(false, "", "");
                    if (e.Node.GetValue(2).ToString().Equals(typeof(CoSo).Name))
                    {
                        objCoSo = new CoSo().getById(Convert.ToInt32(e.Node.GetValue(0)));
                        setData(typeof(CoSo).Name);
                    }
                    else if (e.Node.GetValue(2).ToString().Equals(typeof(Dayy).Name))
                    {
                        objDay = new Dayy().getById(Convert.ToInt32(e.Node.GetValue(0)));
                        setData(typeof(Dayy).Name);
                    }
                    else if (e.Node.GetValue(2).ToString().Equals(typeof(Tang).Name))
                    {
                        objTang = new Tang().getById(Convert.ToInt32(e.Node.GetValue(0)));
                        setData(typeof(Tang).Name);
                    }
                }
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        public void enableEdit(bool _enable, String _type, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnImage.Visible = true;
                btnOK.Visible = true;
                btnHuy.Visible = true;
                txtTen.Properties.ReadOnly = false;
                txtMoTa.Properties.ReadOnly = false;
                _ucTreeViTri.setReadOnly(false);
                _ucTreeViTriChonDay.setReadOnly(false);
                type = _type;
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtTen.Properties.ReadOnly = true;
                txtMoTa.Properties.ReadOnly = true;
                _ucTreeViTri.setReadOnly(true);
                _ucTreeViTriChonDay.setReadOnly(true);
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
                enableEdit(false, "", "");
            }
        }

        private void editObj(String _type)
        {
            FindNode findNode = null;
            switch (_type)
            {
                case "CoSo":
                    objCoSo.ten = txtTen.Text;
                    objCoSo.mota = txtMoTa.Text;
                    objCoSo.date_modified = ServerTimeHelper.getNow();
                    objCoSo.hinhanhs = listHinh;
                    if (objCoSo.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                        findNode = new FindNode(objCoSo.id, typeof(CoSo).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Dayy":
                    objDay.ten = txtTen.Text;
                    objDay.mota = txtMoTa.Text;
                    objDay.date_modified = ServerTimeHelper.getNow();
                    ViTri _vitri = _ucTreeViTri.getViTri();
                    objDay.coso = _vitri.coso;
                    objDay.hinhanhs = listHinh;
                    if (objDay.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                        findNode = new FindNode(objDay.id, typeof(Dayy).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Tang":
                    objTang.ten = txtTen.Text;
                    objTang.mota = txtMoTa.Text;
                    objTang.date_modified = ServerTimeHelper.getNow();
                    ViTri _vitri2 = _ucTreeViTriChonDay.getViTri();
                    objTang.day = _vitri2.day;
                    objTang.hinhanhs = listHinh;
                    if (objTang.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                        findNode = new FindNode(objTang.id, typeof(Tang).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
            }
        }

        public void beforeAdd(String _type)
        {
            txtTen.Text = "";
            txtMoTa.Text = "";
            imageSlider1.Images.Clear();
            ViTri _vitri;
            type = _type;
            switch (_type)
            {
                case "CoSo":
                    listHinh = null;
                    panelControl1.Controls.Clear();
                    TextEdit txt = new TextEdit();
                    txt.Properties.ReadOnly = true;
                    txt.Text = "Đại học Sài Gòn";
                    txt.Dock = DockStyle.Fill;
                    panelControl1.Controls.Add(txt);
                    break;
                case "Dayy":
                    listHinh = null;
                    panelControl1.Controls.Clear();
                    _ucTreeViTri.Dock = DockStyle.Fill;
                    _vitri = new ViTri();
                    if (node.Equals(typeof(CoSo).Name))
                        _vitri.coso = objCoSo;
                    else if (node.Equals(typeof(Dayy).Name))
                        _vitri.coso = objDay.coso;
                    else
                        _vitri.coso = objTang.day.coso;
                    _ucTreeViTri.setViTri(_vitri);
                    panelControl1.Controls.Add(_ucTreeViTri);
                    break;
                case "Tang":
                    listHinh = null;
                    panelControl1.Controls.Clear();
                    _ucTreeViTriChonDay.Dock = DockStyle.Fill;
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
                    _ucTreeViTriChonDay.setViTri(_vitri);
                    panelControl1.Controls.Add(_ucTreeViTriChonDay);
                    break;
            }
        }

        private void addObj(String _type)
        {
            FindNode findNode = null;
            switch (_type)
            {
                case "CoSo":
                    CoSo objCoSoNew = new CoSo();
                    objCoSoNew.ten = txtTen.Text;
                    objCoSoNew.mota = txtMoTa.Text;
                    objCoSoNew.date_create = ServerTimeHelper.getNow();
                    objCoSoNew.date_modified = ServerTimeHelper.getNow();
                    objCoSoNew.hinhanhs = listHinh;
                    if (objCoSoNew.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                        findNode = new FindNode(objCoSoNew.id, typeof(CoSo).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Dayy":
                    Dayy objDayNew = new Dayy();
                    objDayNew.ten = txtTen.Text;
                    objDayNew.mota = txtMoTa.Text;
                    objDayNew.date_create = ServerTimeHelper.getNow();
                    objDayNew.date_modified = ServerTimeHelper.getNow();
                    objDayNew.hinhanhs = listHinh;
                    ViTri _vitri = _ucTreeViTri.getViTri();
                    objDayNew.coso = _vitri.coso;
                    if (objDayNew.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                        findNode = new FindNode(objDayNew.id, typeof(Dayy).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Tang":
                    Tang objTangNew = new Tang();
                    objTangNew.ten = txtTen.Text;
                    objTangNew.mota = txtMoTa.Text;
                    objTangNew.date_create = ServerTimeHelper.getNow();
                    objTangNew.date_modified = ServerTimeHelper.getNow();
                    objTangNew.hinhanhs = listHinh;
                    ViTri _vitri2 = _ucTreeViTriChonDay.getViTri();
                    objTangNew.day = _vitri2.day;
                    if (objTangNew.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                        findNode = new FindNode(objTangNew.id, typeof(Tang).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
            }
        }

        public void deleteObj(String _type)
        {
            switch (_type)
            {
                case "CoSo":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa cơ sở?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objCoSo.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoad();
                        }
                        else
                        {
                            XtraMessageBox.Show("Có dãy trong cơ sở. Vui lòng xóa dãy trước!");
                        }
                    }
                    break;
                case "Dayy":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa dãy?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CoSo obj = objDay.coso;
                        if (objDay.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoad();
                        }

                        else
                        {
                            XtraMessageBox.Show("Có tầng/phòng trong dãy. Vui lòng xóa tầng/phòng trước!");
                        }
                    }
                    break;
                case "Tang":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa tầng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Dayy obj = objTang.day;
                        if (objTang.delete() != -1)
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

        private void reLoad()
        {
            errorProvider1.Clear();
            treeListViTri.ClearNodes();
            listTree = new ViTriFilter().getAll();
            treeListViTri.DataSource = listTree;
            //kiem tra truoc khi reload
            listTree = new ViTriFilter().getAllCoSo();
            _ucTreeViTri.reLoad(listTree);
            listTree = new ViTriFilter().getAllHaveDay();
            _ucTreeViTriChonDay.reLoad(listTree);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false, "", "");
            SetTextGroupControl("Chi tiết", false);
            errorProvider1.Clear();
            listHinh = null;
            setData(node);
        }

        public void SetTextGroupControl(String _text, bool _color)
        {
            groupControl1.Text = _text;
            if(_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Black;   
        }

        private Boolean CheckInput()
        {
            errorProvider1.Clear();
            Boolean check = true;
            if (imageSlider1.Images.Count == 0)
            {
                check = false;
                errorProvider1.SetError(imageSlider1, "Cần ít nhất 1 hình ảnh");
            }
            if (txtTen.Text.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtTen, "Chưa điền tên");
            }
            return check;
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
                frmHinhAnh frm = null;
                switch (type)
                {
                    case "CoSo":
                        if (function.Equals("edit"))
                        {
                            frm = new frmHinhAnh(listHinh);
                            frm.Text = "Quản lý hình ảnh " + objCoSo.ten;
                            frm.ShowDialog();
                            listHinh = frm.getlistHinhs();
                        }
                        else
                        {
                            frm = new frmHinhAnh(listHinh);
                            frm.Text = "Quản lý hình ảnh cơ sở mới";
                            frm.ShowDialog();
                            listHinh = frm.getlistHinhs();
                        }
                        break;
                    case "Dayy":
                        if (function.Equals("edit"))
                        {
                            frm = new frmHinhAnh(listHinh);
                            frm.Text = "Quản lý hình ảnh " + objDay.ten;
                            frm.ShowDialog();
                            listHinh = frm.getlistHinhs();
                        }
                        else
                        {
                            frm = new frmHinhAnh(listHinh);
                            frm.Text = "Quản lý hình ảnh dãy mới";
                            frm.ShowDialog();
                            listHinh = frm.getlistHinhs();
                        }
                        break;
                    case "Tang":
                        if (function.Equals("edit"))
                        {
                            frm = new frmHinhAnh(listHinh);
                            frm.Text = "Quản lý hình ảnh " + objTang.ten;
                            frm.ShowDialog();
                            listHinh = frm.getlistHinhs();
                        }
                        else
                        {
                            frm = new frmHinhAnh(listHinh);
                            frm.Text = "Quản lý hình ảnh tầng mới";
                            frm.ShowDialog();
                            listHinh = frm.getlistHinhs();
                        }
                        break;
                }
                reloadImage();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        public void setData(String _type)
        {
            ViTri objViTri = null;
            switch (_type)
            {
                case "CoSo":
                    txtTen.Text = objCoSo.ten;
                    txtMoTa.Text = objCoSo.mota;
                    panelControl1.Controls.Clear();
                    TextEdit txt = new TextEdit();
                    txt.Properties.ReadOnly = true;
                    txt.Text = "Đại học Sài Gòn";
                    txt.Dock = DockStyle.Fill;
                    panelControl1.Controls.Add(txt);
                    node = typeof(CoSo).Name;
                    listHinh = objCoSo.hinhanhs.ToList();
                    reloadImage();
                    if (this.ParentForm != null)
                    {
                        frmMain frm = (frmMain)this.ParentForm;
                        frm.enableGroupViTri(typeof(CoSo).Name);
                    }
                    break;
                case "Dayy":
                    panelControl1.Controls.Clear();
                    _ucTreeViTri.Dock = DockStyle.Fill;
                    panelControl1.Controls.Add(_ucTreeViTri);
                    txtTen.Text = objDay.ten;
                    txtMoTa.Text = objDay.mota;
                    objViTri = new ViTri();
                    objViTri.coso = objDay.coso;
                    _ucTreeViTri.setViTri(objViTri);
                    node = typeof(Dayy).Name;
                    listHinh = objDay.hinhanhs.ToList();
                    reloadImage();
                    if (this.ParentForm != null)
                    {
                        frmMain frm = (frmMain)this.ParentForm;
                        frm.enableGroupViTri(typeof(Dayy).Name);
                    }
                    break;
                case "Tang":
                    panelControl1.Controls.Clear();
                    _ucTreeViTriChonDay.Dock = DockStyle.Fill;
                    panelControl1.Controls.Add(_ucTreeViTriChonDay);
                    txtTen.Text = objTang.ten;
                    txtMoTa.Text = objTang.mota;
                    objViTri = new ViTri();
                    objViTri.day = objTang.day;
                    objViTri.coso = objTang.day.coso;
                    _ucTreeViTriChonDay.setViTri(objViTri);
                    node = typeof(Tang).Name;
                    listHinh = objTang.hinhanhs.ToList();
                    reloadImage();
                    if (this.ParentForm != null)
                    {
                        frmMain frm = (frmMain)this.ParentForm;
                        frm.enableGroupViTri(typeof(Tang).Name);
                    }
                    break;
            }
        }
    }
}
