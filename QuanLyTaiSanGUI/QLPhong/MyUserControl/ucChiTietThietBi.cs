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
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Libraries;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietThietBi : UserControl
    {
        CTThietBi obj = new CTThietBi();
        List<LoaiThietBi> list = null;
        List<HinhAnh> listHinh = new List<HinhAnh>();
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();
        Phong objPhong = new Phong();
        CTThietBi objCTThietBi = new CTThietBi();
        String type = "";
        String function = "";
        String node = "";

        public ucChiTietThietBi()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            list = new LoaiThietBi().getAll();
            _ucTreeLoaiTB.loadData(list);
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            _ucTreeLoaiTB.setReadOnly(true);
            panelControl1.Controls.Add(_ucTreeLoaiTB);
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
                _ucTreeLoaiTB.setReadOnly(false);
                type = _type;
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtTen.Properties.ReadOnly = true;
                txtMoTa.Properties.ReadOnly = true;
                _ucTreeLoaiTB.setReadOnly(true);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (CheckInput())
            //{
            //    switch (function)
            //    {
            //        case "edit":
            //            editObj(type);
            //            break;
            //        case "add":
            //            addObj(type);
            //            break;
            //    }
            //    enableEdit(false, "", "");
            //}
        }

        //private void editObj(String _type)
        //{
        //    FindNode findNode = null;
        //    switch (_type)
        //    {
        //        case "Phong":
        //            objPhong.ten = txtTen.Text;
        //            objPhong.mota = txtMoTa.Text;
        //            objPhong.date_modified = ServerTimeHelper.getNow();
        //            objPhong.hinhanhs = listHinh;
        //            if (objPhong.update() != -1)
        //            {
        //                XtraMessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                //reLoad();
        //                findNode = new FindNode(objPhong.id, typeof(Phong).Name);
        //                //treeListViTri.NodesIterator.DoOperation(findNode);
        //                //treeListViTri.FocusedNode = findNode.Node;
        //            }
        //            break;
        //        case "ThietBi":
        //            objCTThietBi.id = txtTen.Text;
        //            objCTThietBi.mota = txtMoTa.Text;
        //            //objCTThietBi.date_modified = ServerTimeHelper.getNow();
        //            ViTri _vitri = _ucTreeViTri.getViTri();
        //            objDay.coso = _vitri.coso;
        //            objDay.hinhanhs = listHinh;
        //            if (objDay.update() != -1)
        //            {
        //                XtraMessageBox.Show("Sửa dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                reLoad();
        //                findNode = new FindNode(objDay.id, typeof(Dayy).Name);
        //                treeListViTri.NodesIterator.DoOperation(findNode);
        //                treeListViTri.FocusedNode = findNode.Node;
        //            }
        //            break;
        //        case "Tang":
        //            objTang.ten = txtTen.Text;
        //            objTang.mota = txtMoTa.Text;
        //            objTang.date_modified = ServerTimeHelper.getNow();
        //            ViTri _vitri2 = _ucTreeViTriChonDay.getViTri();
        //            objTang.day = _vitri2.day;
        //            objTang.hinhanhs = listHinh;
        //            if (objTang.update() != -1)
        //            {
        //                XtraMessageBox.Show("Sửa tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                reLoad();
        //                findNode = new FindNode(objTang.id, typeof(Tang).Name);
        //                treeListViTri.NodesIterator.DoOperation(findNode);
        //                treeListViTri.FocusedNode = findNode.Node;
        //            }
        //            break;
        //    }
        //}

        //public void beforeAdd(String _type)
        //{
        //    txtTen.Text = "";
        //    txtMoTa.Text = "";
        //    imageSlider1.Images.Clear();
        //    ViTri _vitri;
        //    type = _type;
        //    switch (_type)
        //    {
        //        case "CoSo":
        //            listHinh = null;
        //            panelControl1.Controls.Clear();
        //            TextEdit txt = new TextEdit();
        //            txt.Properties.ReadOnly = true;
        //            txt.Text = "Đại học Sài Gòn";
        //            txt.Dock = DockStyle.Fill;
        //            panelControl1.Controls.Add(txt);
        //            break;
        //        case "Dayy":
        //            listHinh = null;
        //            panelControl1.Controls.Clear();
        //            _ucTreeViTri.Dock = DockStyle.Fill;
        //            _vitri = new ViTri();
        //            if (node.Equals(typeof(CoSo).Name))
        //                _vitri.coso = objCoSo;
        //            else if (node.Equals(typeof(Dayy).Name))
        //                _vitri.coso = objDay.coso;
        //            else
        //                _vitri.coso = objTang.day.coso;
        //            _ucTreeViTri.setViTri(_vitri);
        //            panelControl1.Controls.Add(_ucTreeViTri);
        //            break;
        //        case "Tang":
        //            listHinh = null;
        //            panelControl1.Controls.Clear();
        //            _ucTreeViTriChonDay.Dock = DockStyle.Fill;
        //            _vitri = new ViTri();
        //            if (node.Equals(typeof(Dayy).Name))
        //            {
        //                _vitri.coso = objDay.coso;
        //                _vitri.day = objDay;
        //            }
        //            else
        //            {
        //                _vitri.coso = objTang.day.coso;
        //                _vitri.day = objTang.day;
        //            }
        //            _ucTreeViTriChonDay.setViTri(_vitri);
        //            panelControl1.Controls.Add(_ucTreeViTriChonDay);
        //            break;
        //    }
        //}

        //private void addObj(String _type)
        //{
        //    FindNode findNode = null;
        //    switch (_type)
        //    {
        //        case "CoSo":
        //            CoSo objCoSoNew = new CoSo();
        //            objCoSoNew.ten = txtTen.Text;
        //            objCoSoNew.mota = txtMoTa.Text;
        //            objCoSoNew.date_create = ServerTimeHelper.getNow();
        //            objCoSoNew.date_modified = ServerTimeHelper.getNow();
        //            objCoSoNew.hinhanhs = listHinh;
        //            if (objCoSoNew.add() != -1)
        //            {
        //                XtraMessageBox.Show("Thêm cơ sở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                reLoad();
        //                findNode = new FindNode(objCoSoNew.id, typeof(CoSo).Name);
        //                treeListViTri.NodesIterator.DoOperation(findNode);
        //                treeListViTri.FocusedNode = findNode.Node;
        //            }
        //            break;
        //        case "Dayy":
        //            Dayy objDayNew = new Dayy();
        //            objDayNew.ten = txtTen.Text;
        //            objDayNew.mota = txtMoTa.Text;
        //            objDayNew.date_create = ServerTimeHelper.getNow();
        //            objDayNew.date_modified = ServerTimeHelper.getNow();
        //            objDayNew.hinhanhs = listHinh;
        //            ViTri _vitri = _ucTreeViTri.getViTri();
        //            objDayNew.coso = _vitri.coso;
        //            if (objDayNew.add() != -1)
        //            {
        //                XtraMessageBox.Show("Thêm dãy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                reLoad();
        //                findNode = new FindNode(objDayNew.id, typeof(Dayy).Name);
        //                treeListViTri.NodesIterator.DoOperation(findNode);
        //                treeListViTri.FocusedNode = findNode.Node;
        //            }
        //            break;
        //        case "Tang":
        //            Tang objTangNew = new Tang();
        //            objTangNew.ten = txtTen.Text;
        //            objTangNew.mota = txtMoTa.Text;
        //            objTangNew.date_create = ServerTimeHelper.getNow();
        //            objTangNew.date_modified = ServerTimeHelper.getNow();
        //            objTangNew.hinhanhs = listHinh;
        //            ViTri _vitri2 = _ucTreeViTriChonDay.getViTri();
        //            objTangNew.day = _vitri2.day;
        //            if (objTangNew.add() != -1)
        //            {
        //                XtraMessageBox.Show("Thêm tầng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                reLoad();
        //                findNode = new FindNode(objTangNew.id, typeof(Tang).Name);
        //                treeListViTri.NodesIterator.DoOperation(findNode);
        //                treeListViTri.FocusedNode = findNode.Node;
        //            }
        //            break;
        //    }
        //}

        private Boolean CheckInput()
        {
            dxErrorProvider.ClearErrors();
            //errorProvider1.Clear();
            Boolean check = true;
            if (imageSlider1.Images.Count == 0)
            {
                check = false;
                dxErrorProvider.SetError(imageSlider1, "Cần ít nhất 1 hình ảnh");
            }
            if (txtTen.Text.Length == 0)
            {
                check = false;
                dxErrorProvider.SetError(txtTen, "Chưa điền tên");
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

        public void setData(CTThietBi _obj)
        {
            obj = _obj;
            txtMa.Text = _obj.thietbi.subId;
            txtTen.Text = _obj.thietbi.ten;
            txtMoTa.Text = _obj.thietbi.mota;
            lblTenPhong.Text = _obj.phong.ten;
            dateMua.DateTime = _obj.thietbi.ngaymua.Value;
            dateLap.DateTime = _obj.thietbi.ngaylap.Value;
            _ucTreeLoaiTB.setLoai(_obj.thietbi.loaithietbi);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmHinhAnh frm = null;
            //    switch (type)
            //    {
            //        case "CoSo":
            //            if (function.Equals("edit"))
            //            {
            //                frm = new frmHinhAnh(listHinh);
            //                frm.Text = "Quản lý hình ảnh " + objCoSo.ten;
            //                frm.ShowDialog();
            //                listHinh = frm.getlistHinhs();
            //            }
            //            else
            //            {
            //                frm = new frmHinhAnh(listHinh);
            //                frm.Text = "Quản lý hình ảnh cơ sở mới";
            //                frm.ShowDialog();
            //                listHinh = frm.getlistHinhs();
            //            }
            //            break;
            //        case "Dayy":
            //            if (function.Equals("edit"))
            //            {
            //                frm = new frmHinhAnh(listHinh);
            //                frm.Text = "Quản lý hình ảnh " + objDay.ten;
            //                frm.ShowDialog();
            //                listHinh = frm.getlistHinhs();
            //            }
            //            else
            //            {
            //                frm = new frmHinhAnh(listHinh);
            //                frm.Text = "Quản lý hình ảnh dãy mới";
            //                frm.ShowDialog();
            //                listHinh = frm.getlistHinhs();
            //            }
            //            break;
            //        case "Tang":
            //            if (function.Equals("edit"))
            //            {
            //                frm = new frmHinhAnh(listHinh);
            //                frm.Text = "Quản lý hình ảnh " + objTang.ten;
            //                frm.ShowDialog();
            //                listHinh = frm.getlistHinhs();
            //            }
            //            else
            //            {
            //                frm = new frmHinhAnh(listHinh);
            //                frm.Text = "Quản lý hình ảnh tầng mới";
            //                frm.ShowDialog();
            //                listHinh = frm.getlistHinhs();
            //            }
            //            break;
            //    }
            //    reloadImage();
            //}
            //catch (Exception ex)
            //{ }
            //finally
            //{ }
        }
    }
}
