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
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    public partial class ucQuanLyCoSo : UserControl
    {
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
                    TreeListNode rootNode = tl.AppendNode(new object[] { _coso.id, _coso.ten, "coso" }, parentForRootNodes);
                    // Create a child of the rootNode
                    listDays = _coso.days.ToList();
                    foreach (Dayy _day in listDays)
                    {
                        TreeListNode rootNode2 = tl.AppendNode(new object[] { _day.id, _day.ten, "day" }, rootNode);
                        // Create a child of the rootNode
                        listTangs = _day.tangs.ToList();
                        foreach (Tang _tang in listTangs)
                        {
                            tl.AppendNode(new object[] { _tang.id, _tang.ten, "tang" }, rootNode2);
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
                    if (function.Equals("edit") || function.Equals("add"))
                        enableEdit(false, "", "");
                    if (e.Node.GetValue(2).ToString().Equals("coso"))
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
                            frm.enableGroupViTri("coso");
                        }
                        node = "coso";
                    }
                    else if (e.Node.GetValue(2).ToString().Equals("day"))
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
                            frm.enableGroupViTri("day");
                        }
                        node = "day";
                    }
                    else if (e.Node.GetValue(2).ToString().Equals("tang"))
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
                            frm.enableGroupViTri("tang");
                        }
                        node = "tang";
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

        private void editObj(String _type)
        {
            switch (_type)
            {
                case "coso":
                    objCoSo.ten = txtTen.Text;
                    objCoSo.mota = txtMoTa.Text;
                    if (objCoSo.update() == 1)
                    {
                        XtraMessageBox.Show("Sửa cơ sở thành công!");
                        reLoad();
                    }
                    break;
                case "day":
                    //objDay.ten = txtTen.Text;
                    //objDay.mota = txtMoTa.Text;
                    //ViTri _vitri = _ucTreeViTri.getViTri();
                    //objDay.coso = _vitri.coso;
                    //if (objDay.update() == 1)
                    //{
                    //    XtraMessageBox.Show("Sửa dãy thành công!");
                    //    reLoad();
                    //}
                    break;
                case "tang":
                    //objTang.ten = txtTen.Text;
                    //objTang.mota = txtMoTa.Text;
                    //ViTri _vitri2 = _ucTreeViTri2.getViTri();
                    //objTang.day = _vitri2.day;
                    //if (objTang.update() == 1)
                    //{
                    //    XtraMessageBox.Show("Sửa tầng thành công!");
                    //    reLoad();
                    //}
                    break;
            }
        }

        public void beforeAdd(String _type)
        {
            txtTen.Text = "";
            txtMoTa.Text = "";
            ViTri _vitri;
            switch (_type)
            {
                case "coso":
                    panelControl1.Controls.Clear();
                    TextEdit txt = new TextEdit();
                    txt.Properties.ReadOnly = true;
                    txt.Text = "Đại học Sài Gòn";
                    txt.Dock = DockStyle.Fill;
                    panelControl1.Controls.Add(txt);
                    break;
                case "day":
                    panelControl1.Controls.Clear();
                    _ucTreeViTri.Dock = DockStyle.Fill;
                    _vitri = new ViTri();
                    if (node.Equals("coso"))
                        _vitri.coso = objCoSo;
                    else if (node.Equals("day"))
                        _vitri.coso = objDay.coso;
                    else
                        _vitri.coso = objTang.day.coso;
                    _ucTreeViTri.setViTri(_vitri);
                    panelControl1.Controls.Add(_ucTreeViTri);
                    break;
                case "tang":
                    panelControl1.Controls.Clear();
                    _ucTreeViTri2.Dock = DockStyle.Fill;
                    _vitri = new ViTri();
                    if (node.Equals("day"))
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
            switch (_type)
            {
                case "coso":
                    objCoSo = new CoSo();
                    objCoSo.ten = txtTen.Text;
                    objCoSo.mota = txtMoTa.Text;
                    if (objCoSo.add() == 1)
                    {
                        XtraMessageBox.Show("Thêm cơ sở thành công!");
                        reLoad();
                    }
                    break;
                case "day":
                    //objDay = new Dayy();
                    //objDay.ten = txtTen.Text;
                    //objDay.mota = txtMoTa.Text;
                    //ViTri _vitri = _ucTreeViTri.getViTri();
                    //objDay.coso = _vitri.coso;
                    //if (objDay.add() == 1)
                    //{
                    //    XtraMessageBox.Show("Thêm dãy thành công!");
                    //    reLoad();
                    //}
                    break;
                case "tang":
                    //objTang = new Tang();
                    //objTang.ten = txtTen.Text;
                    //objTang.mota = txtMoTa.Text;
                    //ViTri _vitri2 = _ucTreeViTri2.getViTri();
                    //objTang.day = _vitri2.day;
                    //if (objTang.add() == 1)
                    //{
                    //    XtraMessageBox.Show("Thêm tầng thành công!");
                    //    reLoad();
                    //}
                    break;
            }
        }

        public void deleteObj(String _type)
        {
            switch (_type)
            {
                case "coso":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa cơ sở?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (objCoSo.delete() == 1)
                        {
                            XtraMessageBox.Show("Xóa cơ sở thành công!");
                            reLoad();
                        }
                    }
                    break;
                case "day":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa dãy?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (objDay.delete() == 1)
                        {
                            XtraMessageBox.Show("Xóa dãy thành công!");
                            reLoad();
                        }
                    }
                    break;
                case "tang":
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa tầng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (objTang.delete() == 1)
                        {
                            XtraMessageBox.Show("Xóa tầng thành công!");
                            reLoad();
                        }
                    }
                    break;
            }
        }

        private void reLoad()
        {
            listCoSos = new CoSo().getAll();
            treeListViTri.ClearNodes();
            CreateNodes(treeListViTri);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false, "", "");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_ucTreeViTri.getViTri().coso.ten);
        }
    }
}
