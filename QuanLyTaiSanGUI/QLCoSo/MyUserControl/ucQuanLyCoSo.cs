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
using QuanLyTaiSan.Libraries;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    public partial class ucQuanLyCoSo : UserControl
    {
        TreeListViewState treeListViewState;
        List<CoSo> listCoSos = new List<CoSo>();
        ucTreeViTri _ucTreeViTri;
        ucTreeViTri _ucTreeViTri2;
        CoSo objCoSo = new CoSo();
        Dayy objDay = new Dayy();
        Tang objTang = new Tang();
        String type = "";
        String function = "";
        String node = "";

        public ucQuanLyCoSo()
        {
            InitializeComponent();
            listCoSos = new CoSo().getAll().ToList();
            _ucTreeViTri = new ucTreeViTri(listCoSos,false, false);
            _ucTreeViTri2 = new ucTreeViTri(listCoSos,true, false);
        }

        private void ucQuanLyCoSo_Load(object sender, EventArgs e)
        {
            CreateNodes(treeListViTri);
            //_ucTreeViTri.Dock = DockStyle.Left;
            //panelControl1.Controls.Add(_ucTreeViTri);
        }

        private void CreateNodes(TreeList tl)
        {
            try
            {
                List<Dayy> listDays = new List<Dayy>();
                List<Tang> listTangs = new List<Tang>();
                tl.BeginUnboundLoad();
                // Create a root node .
                TreeListNode parentForRootNodes = null;
                listCoSos = new CoSo().getAll();
                foreach (CoSo _coso in listCoSos)
                {
                    TreeListNode rootNode = tl.AppendNode(new object[] { _coso.id, _coso.ten, typeof(CoSo).Name }, parentForRootNodes);
                    // Create a child of the rootNode
                    listDays = _coso.days.ToList();
                    foreach (Dayy _day in listDays)
                    {
                        TreeListNode rootNode2 = tl.AppendNode(new object[] { _day.id, _day.ten, typeof(Dayy).Name }, rootNode);
                        // Create a child of the rootNode
                        listTangs = _day.tangs.ToList();
                        foreach (Tang _tang in listTangs)
                        {
                            tl.AppendNode(new object[] { _tang.id, _tang.ten, typeof(Tang).Name }, rootNode2);
                            // Creating more nodes
                            // ...
                        }
                    }
                }
                tl.EndUnboundLoad();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    groupControl1.Text = "Chi tiết";
                    if (function.Equals("edit") || function.Equals("add"))
                        enableEdit(false, "", "");
                    if (e.Node.GetValue(2).ToString().Equals(typeof(CoSo).Name))
                    {
                        objCoSo = new CoSo().getById(Convert.ToInt32(e.Node.GetValue(0)));
                        txtTen.Text = objCoSo.ten;
                        txtMoTa.Text = objCoSo.mota;
                        panelControl1.Controls.Clear();
                        TextEdit txt = new TextEdit();
                        txt.Properties.ReadOnly = true;
                        txt.Text = "Đại học Sài Gòn";
                        txt.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(txt);
                        //type = "coso";
                        if (this.ParentForm != null)
                        {
                            frmMain frm = (frmMain)this.ParentForm;
                            frm.enableGroupViTri(typeof(CoSo).Name);
                        }
                        node = typeof(CoSo).Name;
                        reloadImage();
                    }
                    else if (e.Node.GetValue(2).ToString().Equals(typeof(Dayy).Name))
                    {
                        panelControl1.Controls.Clear();
                        _ucTreeViTri.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(_ucTreeViTri);
                        objDay = new Dayy().getById(Convert.ToInt32(e.Node.GetValue(0)));
                        txtTen.Text = objDay.ten;
                        txtMoTa.Text = objDay.mota;
                        ViTri objViTri = new ViTri();
                        objViTri.coso = objDay.coso;
                        _ucTreeViTri.setViTri(objViTri);
                        //type = "day";
                        if (this.ParentForm != null)
                        {
                            frmMain frm = (frmMain)this.ParentForm;
                            frm.enableGroupViTri(typeof(Dayy).Name);
                        }
                        node = typeof(Dayy).Name;
                        reloadImage();
                    }
                    else if (e.Node.GetValue(2).ToString().Equals(typeof(Tang).Name))
                    {
                        panelControl1.Controls.Clear();
                        _ucTreeViTri2.Dock = DockStyle.Fill;
                        panelControl1.Controls.Add(_ucTreeViTri2);
                        objTang = new Tang().getById(Convert.ToInt32(e.Node.GetValue(0)));
                        txtTen.Text = objTang.ten;
                        txtMoTa.Text = objTang.mota;
                        ViTri objViTri = new ViTri();
                        objViTri.day = objTang.day;
                        objViTri.coso = objTang.day.coso;
                        _ucTreeViTri2.setViTri(objViTri);
                        //type = "tang";
                        if (this.ParentForm != null)
                        {
                            frmMain frm = (frmMain)this.ParentForm;
                            frm.enableGroupViTri(typeof(Tang).Name);
                        }
                        node = typeof(Tang).Name;
                        reloadImage();
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
                _ucTreeViTri2.setReadOnly(false);
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
                _ucTreeViTri2.setReadOnly(true);
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
            FindNode findNode3 = null;
            FindNode findNode2 = null;
            FindNode findNode = null;
            TreeListNode _node = null;
            TreeListNode _node2 = null;
            switch (_type)
            {
                case "CoSo":
                    findNode2 = new FindNode(objCoSo.id, typeof(CoSo).Name);
                    treeListViTri.NodesIterator.DoOperation(findNode2);
                    _node = findNode2.Node;
                    objCoSo.ten = txtTen.Text;
                    objCoSo.mota = txtMoTa.Text;
                    objCoSo.date_modified = ServerTimeHelper.getNow();
                    if (objCoSo.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa cơ sở thành công!");
                        reLoad();
                        findNode = new FindNode(objCoSo.id, typeof(CoSo).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Dayy":
                    findNode2 = new FindNode(objDay.coso.id, typeof(CoSo).Name);
                    treeListViTri.NodesIterator.DoOperation(findNode2);
                    _node = findNode2.Node;
                    CoSo _coso = objDay.coso;
                    objDay.ten = txtTen.Text;
                    objDay.mota = txtMoTa.Text;
                    objDay.date_modified = ServerTimeHelper.getNow();
                    ViTri _vitri = _ucTreeViTri.getViTri(objDay.DB);
                    objDay.coso = _vitri.coso;
                    if (objDay.update() != -1)
                    {
                    XtraMessageBox.Show("Sửa dãy thành công!");
                        //reLoad();
                        reLoadByNode(_node, _coso, typeof(CoSo).Name);
                        if (!_coso.id.Equals(objDay.coso.id))
                        {
                            findNode3 = new FindNode(objDay.coso.id, typeof(CoSo).Name);
                            treeListViTri.NodesIterator.DoOperation(findNode3);
                            _node2 = findNode3.Node;
                            reLoadByNode(_node2, objDay.coso, typeof(CoSo).Name);
                        }
                        findNode = new FindNode(objDay.id, typeof(Dayy).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Tang":
                    findNode2 = new FindNode(objTang.day.id, typeof(Dayy).Name);
                    treeListViTri.NodesIterator.DoOperation(findNode2);
                    _node = findNode2.Node;
                    Dayy _day = objTang.day;
                    objTang.ten = txtTen.Text;
                    objTang.mota = txtMoTa.Text;
                    objTang.date_modified = ServerTimeHelper.getNow();
                    ViTri _vitri2 = _ucTreeViTri2.getViTri(objTang.DB);
                    objTang.day = _vitri2.day;
                    if (objTang.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa tầng thành công!");
                        reLoadByNode(_node, _day, typeof(Dayy).Name);
                        if (!_day.id.Equals(objTang.day.id))
                        {
                            findNode3 = new FindNode(objTang.day.id, typeof(Dayy).Name);
                            treeListViTri.NodesIterator.DoOperation(findNode3);
                            _node2 = findNode3.Node;
                            reLoadByNode(_node2, objTang.day, typeof(Dayy).Name);
                        }
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
                    panelControl1.Controls.Clear();
                    TextEdit txt = new TextEdit();
                    txt.Properties.ReadOnly = true;
                    txt.Text = "Đại học Sài Gòn";
                    txt.Dock = DockStyle.Fill;
                    panelControl1.Controls.Add(txt);
                    break;
                case "Dayy":
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
                    panelControl1.Controls.Clear();
                    _ucTreeViTri2.Dock = DockStyle.Fill;
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
                    _ucTreeViTri2.setViTri(_vitri);
                    panelControl1.Controls.Add(_ucTreeViTri2);
                    break;
            }
        }

        public void beforeEdit(String _type)
        {
            ViTri _vitri;
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
                    break;
                case "Dayy":
                    txtTen.Text = objDay.ten;
                    txtMoTa.Text = objDay.mota;
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
                    txtTen.Text = objTang.ten;
                    txtMoTa.Text = objTang.mota;
                    panelControl1.Controls.Clear();
                    _ucTreeViTri2.Dock = DockStyle.Fill;
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
                    _ucTreeViTri2.setViTri(_vitri);
                    panelControl1.Controls.Add(_ucTreeViTri2);
                    break;
            }
        }

        private void addObj(String _type)
        {
            FindNode findNode2 = null;
            FindNode findNode = null;
            TreeListNode _node = null;
            TreeListNode _node2 = null;
            switch (_type)
            {
                case "CoSo":
                    objCoSo = new CoSo();
                    objCoSo.ten = txtTen.Text;
                    objCoSo.mota = txtMoTa.Text;
                    objCoSo.date_create = ServerTimeHelper.getNow();
                    objCoSo.date_modified = ServerTimeHelper.getNow();
                    if (objCoSo.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm cơ sở thành công!");
                        reLoad();
                        findNode = new FindNode(objCoSo.id, typeof(CoSo).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Dayy":
                    objDay = new Dayy();
                    objDay.ten = txtTen.Text;
                    objDay.mota = txtMoTa.Text;
                    objDay.date_create = ServerTimeHelper.getNow();
                    objDay.date_modified = ServerTimeHelper.getNow();
                    ViTri _vitri = _ucTreeViTri.getViTri(objDay.DB);
                    objDay.coso = _vitri.coso;
                    if (objDay.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm dãy thành công!");
                        //reLoad();
                        findNode2 = new FindNode(objDay.coso.id, typeof(CoSo).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode2);
                        _node2 = findNode2.Node;
                        reLoadByNode(_node2, objDay.coso, typeof(CoSo).Name);
                        findNode = new FindNode(objDay.id, typeof(Dayy).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
                case "Tang":
                    objTang = new Tang();
                    objTang.ten = txtTen.Text;
                    objTang.mota = txtMoTa.Text;
                    objTang.date_create = ServerTimeHelper.getNow();
                    objTang.date_modified = ServerTimeHelper.getNow();
                    ViTri _vitri2 = _ucTreeViTri2.getViTri(objTang.DB);
                    objTang.day = _vitri2.day;
                    if (objTang.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm tầng thành công!");
                        findNode2 = new FindNode(objTang.day.id, typeof(Dayy).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode2);
                        _node2 = findNode2.Node;
                        reLoadByNode(_node2, objTang.day, typeof(Dayy).Name);
                        findNode = new FindNode(objTang.id, typeof(Tang).Name);
                        treeListViTri.NodesIterator.DoOperation(findNode);
                        treeListViTri.FocusedNode = findNode.Node;
                    }
                    break;
            }
        }

        public void deleteObj(String _type)
        {
            FindNode findNode = null;
            TreeListNode _node = null;
            switch (_type)
            {
                case "CoSo":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa cơ sở?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (objCoSo.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa cơ sở thành công!");
                            reLoad();
                        }
                    }
                    break;
                case "Dayy":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa dãy?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CoSo obj = objDay.coso;
                        if (objDay.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa dãy thành công!");
                            findNode = new FindNode(obj.id, typeof(CoSo).Name);
                            treeListViTri.NodesIterator.DoOperation(findNode);
                            _node = findNode.Node;
                            reLoadByNode(_node, obj, typeof(CoSo).Name);
                        }
                    }
                    break;
                case "Tang":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa tầng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Dayy obj = objTang.day;
                        if (objTang.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa tầng thành công!");
                            findNode = new FindNode(obj.id, typeof(Dayy).Name);
                            treeListViTri.NodesIterator.DoOperation(findNode);
                            _node = findNode.Node;
                            reLoadByNode(_node, obj, typeof(Dayy).Name);
                        }
                    }
                    break;
            }
        }

        private void reLoad()
        {
            //treeListViewState = new TreeListViewState(treeListViTri);
            //treeListViewState.SaveState();
            errorProvider1.Clear();
            listCoSos = new CoSo().getAll();
            treeListViTri.ClearNodes();
            CreateNodes(treeListViTri);
            //kiem tra truoc khi reload
            _ucTreeViTri.reLoad(listCoSos);
            _ucTreeViTri2.reLoad(listCoSos);
            //treeListViewState.LoadState();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false, "", "");
            errorProvider1.Clear();
            groupControl1.Text = "Chi tiết";
            errorProvider1.Clear();
            beforeEdit(node);
        }

        public void SetTextGroupControl(String text)
        {
            groupControl1.Text = text;
        }

        private Boolean CheckInput()
        {
            errorProvider1.Clear();
            Boolean check = true;
            if (txtTen.Text.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtTen, "Chưa điền tên");
            }
            return check;
        }

        private void reloadImage()
        {
            List<HinhAnh> hinhs = null;
            if (!function.Equals("add"))
            {
                switch (node)
                {
                    case "CoSo":
                        hinhs = objCoSo.hinhanhs.ToList();
                        break;
                    case "Dayy":
                        hinhs = objDay.hinhanhs.ToList();
                        break;
                    case "Tang":
                        hinhs = objTang.hinhanhs.ToList();
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case "CoSo":
                        hinhs = objCoSo.hinhanhs.ToList();
                        break;
                    case "Dayy":
                        hinhs = objDay.hinhanhs.ToList();
                        break;
                    case "Tang":
                        hinhs = objTang.hinhanhs.ToList();
                        break;
                }
            }
            imageSlider1.Images.Clear();
            foreach (HinhAnh h in hinhs)
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
                        //frm = new frmHinhAnh(objCoSo.id, objCoSo.hinhanhs.ToList(), typeof(CoSo).Name);
                        if (function.Equals("edit"))
                        {
                            frm = new frmHinhAnh(objCoSo.hinhanhs.ToList(), objCoSo.DB);
                            frm.Text = "Quản lý hình ảnh " + objCoSo.ten;
                            frm.ShowDialog();
                            objCoSo.hinhanhs = frm.getHinhAnhs();
                        }
                        else
                        {
                            objCoSo.hinhanhs = new List<HinhAnh>();
                            frm = new frmHinhAnh(objCoSo.hinhanhs.ToList(), objCoSo.DB);
                            frm.Text = "Quản lý hình ảnh cơ sở mới";
                            frm.ShowDialog();
                            objCoSo.hinhanhs = frm.getHinhAnhs();
                        }
                        break;
                    case "Dayy":
                        if (function.Equals("edit"))
                        {
                            frm = new frmHinhAnh(objDay.hinhanhs.ToList(), objDay.DB);
                            frm.Text = "Quản lý hình ảnh " + objDay.ten;
                            frm.ShowDialog();
                            objDay.hinhanhs = frm.getHinhAnhs();
                        }
                        else
                        {
                            objDay.hinhanhs = new List<HinhAnh>();
                            frm = new frmHinhAnh(objDay.hinhanhs.ToList(), objDay.DB);
                            frm.Text = "Quản lý hình ảnh dãy mới";
                            frm.ShowDialog();
                            objDay.hinhanhs = frm.getHinhAnhs();
                        }
                        //frm = new frmHinhAnh(objDay.id, objDay.hinhanhs.ToList(), typeof(Dayy).Name);
                        //frm.Text = "Quản lý hình ảnh của dãy";
                        //frm.ShowDialog();
                        //objDay = new Dayy().getById(objDay.id);
                        break;
                    case "Tang":
                        if (function.Equals("edit"))
                        {
                            frm = new frmHinhAnh(objTang.hinhanhs.ToList(), objTang.DB);
                            frm.Text = "Quản lý hình ảnh " + objTang.ten;
                            frm.ShowDialog();
                            objTang.hinhanhs = frm.getHinhAnhs();
                        }
                        else
                        {
                            objTang.hinhanhs = new List<HinhAnh>();
                            frm = new frmHinhAnh(objTang.hinhanhs.ToList(), objTang.DB);
                            frm.Text = "Quản lý hình ảnh tầng mới";
                            frm.ShowDialog();
                            objTang.hinhanhs = frm.getHinhAnhs();
                        }
                        //frm = new frmHinhAnh(objTang.id, objTang.hinhanhs.ToList(), typeof(Tang).Name);
                        //frm.Text = "Quản lý hình ảnh của tầng";
                        //frm.ShowDialog();
                        //objTang = new Tang().getById(objTang.id);
                        break;
                }

                reloadImage();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        private void reLoadByNode(TreeListNode node, Object obj, String type)
        {
            node.Nodes.Clear();
            List<Dayy> listDays = null;
            List<Tang> listTangs = null;
            //MessageBox.Show(obj.GetType().Name);
            if (type.Equals(typeof(CoSo).Name))
            {
                CoSo _coso = new CoSo().getById((obj as CoSo).id);
                listDays = _coso.days.ToList();
                foreach (Dayy _day in listDays)
                {
                    TreeListNode rootNode2 = treeListViTri.AppendNode(new object[] { _day.id, _day.ten, typeof(Dayy).Name }, node);
                    // Create a child of the rootNode
                    listTangs = _day.tangs.ToList();
                    foreach (Tang _tang in listTangs)
                    {
                        treeListViTri.AppendNode(new object[] { _tang.id, _tang.ten, typeof(Tang).Name }, rootNode2);
                        // Creating more nodes
                        // ...
                    }
                }

                listCoSos = new CoSo().getAll();
                //kiem tra truoc khi reload
                _ucTreeViTri.reLoad(listCoSos);
                _ucTreeViTri2.reLoad(listCoSos);

            }
            else
            {
                Dayy _day = new Dayy().getById((obj as Dayy).id);
                listTangs = _day.tangs.ToList();
                foreach (Tang _tang in listTangs)
                {
                    treeListViTri.AppendNode(new object[] { _tang.id, _tang.ten, typeof(Tang).Name }, node);
                    // Creating more nodes
                    // ...
                }
            }



        }
    }
}
