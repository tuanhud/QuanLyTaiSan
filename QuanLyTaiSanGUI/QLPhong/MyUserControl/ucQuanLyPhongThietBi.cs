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
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSanGUI.MyUC;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid;
using QuanLyTaiSanGUI.MyForm;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhongThietBi : UserControl
    {
        Phong objPhong = new Phong();
        CTThietBi objCTThietBi = new CTThietBi();
        NhanVienPT objNhanVienPT = new NhanVienPT();

        int row, cosoid, dayid, tangid = -1;
        
        //List<Phong> listPhong = new List<Phong>();
        List<PhongHienThi> listPhongHienThi = null;
        List<HinhAnh> listHinh = new List<HinhAnh>();
        List<HinhAnh> listHinhNV = new List<HinhAnh>();
        List<NhanVienPT> listNhanVienPT = new List<NhanVienPT>();

        ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLPhongThietBi");
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, false);     

        String function = "";
        int _idnhanvien = 0;

        ucChiTietThietBi _ucChiTietThietBi = new ucChiTietThietBi();

        public ucQuanLyPhongThietBi()
        {
            InitializeComponent();
            //loadData();
            //enableEdit(false, "");
            //enableBar(false);
            init();
        }

        private void init()
        {
            ribbonPhongThietBi.Parent = null;
            _ucTreeViTri.Parent = this;
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            _ucChiTietThietBi.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucComboBoxViTri);
        }

        // Load dữ liệu
        public void loadData()
        {
            List<LoaiThietBi> listLoai = LoaiThietBi.getAll();
            _ucChiTietThietBi.loadData(listLoai);
            List<ViTriHienThi> listVitris = ViTriHienThi.getAllHavePhong();
            _ucTreeViTri.loadData(listVitris);
            _ucComboBoxViTri.loadData(listVitris);
            ViTri obj = _ucTreeViTri.getVitri();
            listPhongHienThi = PhongHienThi.getAllByViTri(obj.coso != null ? obj.coso.id : -1, obj.day != null ? obj.day.id : -1, obj.tang != null ? obj.tang.id : -1);
            gridControlPhong.DataSource = listPhongHienThi;
            listNhanVienPT = NhanVienPT.getAll();
            searchLookUpEditNhanVienPT.Properties.DataSource = listNhanVienPT;
            if (function.Equals("edit") || function.Equals("add"))
            {
                enableBar(true);
                SetTextGroupControl("Chi tiết", false);
                dxErrorProvider.ClearErrors();
                enableEdit(false, "");
            }
        }

        //Khi thêm mới cơ sở -> phòng thì load treelist bên trái + reload dữ liệu ucQuanLyPhongThietBi
        //public void reLoadAll()
        //{
        //    listVitris = ViTriHienThi.getAll().ToList();
        //    _ucTreeViTri.loadData(listVitris);
        //    reLoad();
        //}

        //Mở tắt bar
        public void enableBar(bool _enable)
        {
            barButtonSuaPhong.Enabled = _enable;
            barButtonXoaPhong.Enabled = _enable;
        }
        //Mở/tắt chỉnh sửa form
        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            btnImage.Visible = _enable;
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtMaPhong.Properties.ReadOnly = !_enable;
            txtTenPhong.Properties.ReadOnly = !_enable;
            txtMoTaPhong.Properties.ReadOnly = !_enable;
            _ucComboBoxViTri.setReadOnly(!_enable);
            lblNhanVienPT.Visible = _enable;
            searchLookUpEditNhanVienPT.Visible = _enable;
        }

        //Reload listPhong
        //public void reLoad()
        //{
        //    try
        //    {
        //        _ucTreeViTri.setVitri(objPhong.vitri);
        //        gridControlPhong.DataSource = null;
        //        listPhong = Phong.getPhongByViTri(cosoid, dayid, tangid);
        //        gridControlPhong.DataSource = listPhong;
        //    }
        //    catch
        //    { }
        //    finally
        //    { }
        //}


        public void reLoadThietBiTrongPhong()
        {
            gridViewPhong.SetMasterRowExpanded(gridViewPhong.FocusedRowHandle, false);
            gridViewPhong.SetMasterRowExpanded(gridViewPhong.FocusedRowHandle, true);
        }

        //FocusedRowChanged in TreePhong
        public void setData(int _cosoid, int _dayid, int _tangid)
        {
            cosoid = _cosoid;
            dayid = _dayid;
            tangid = _tangid;
            listPhongHienThi = PhongHienThi.getAllByViTri(_cosoid, _dayid, _tangid);
            gridControlPhong.DataSource = listPhongHienThi;
            if (listPhongHienThi.Count == 0)
            {
                _ucComboBoxViTri.Visible = false;
                enableEdit(false, "");
                enableBar(false);
            }
            else
            {
                _ucComboBoxViTri.Visible = true;
            }
        }

        //chỉnh sửa phòng
        private void ChinhSuaPhong()
        {
            try
            {
                if (listHinh != null)
                {
                    objPhong.hinhanhs = listHinh;
                }
                objPhong.subId = txtMaPhong.Text;
                objPhong.ten = txtTenPhong.Text;
                objPhong.vitri = _ucComboBoxViTri.getViTri();
                objPhong.mota = txtMoTaPhong.Text;
                if (_idnhanvien > -1)
                    objPhong.nhanvienpt = NhanVienPT.getById(_idnhanvien);
                else objPhong.nhanvienpt = null;
                if (objPhong.update() != -1)
                {
                    XtraMessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reLoadAndFocused(objPhong.id);
                }
                else XtraMessageBox.Show("Có lỗi trong khi chỉnh sửa");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void reLoadAndFocused(int _id)
        {
            //reLoad();
            int rowHandle = gridViewPhong.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewPhong.FocusedRowHandle = rowHandle;
        }

        //thêm phòng
        private void ThemPhong()
        {
            Phong objPhongNew = new Phong();
            objPhongNew.subId = txtMaPhong.Text;
            objPhongNew.ten = txtTenPhong.Text;
            objPhongNew.mota = txtMoTaPhong.Text;
            objPhongNew.hinhanhs = listHinh;
            objPhongNew.vitri = _ucComboBoxViTri.getViTri();
            objPhongNew.nhanvienpt = NhanVienPT.getById(_idnhanvien);
            if (objPhongNew.add() != -1)
            {
                XtraMessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //reLoad();
            }
            else XtraMessageBox.Show("Có lỗi trong khi thêm");
        }

        //set màu tiêu đề group
        public void SetTextGroupControl(String _text, bool _color)
        {
            groupControl1.Text = _text;
            if (_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Empty;
        }

        // kiểm tra dữ liệu trước khi lưu
        private Boolean CheckInput()
        {
            dxErrorProvider.ClearErrors();
            Boolean check = true;
            //if (imgPhong.Images.Count == 0)
            //{
            //    check = false;
            //    dxErrorProvider.SetError(imgPhong, "Cần ít nhất 1 hình ảnh");
            //}
            if (txtTenPhong.Text.Length == 0)
            {
                check = false;
                dxErrorProvider.SetError(txtTenPhong, "Chưa điền tên");
            }
            return check;
        }

        //load lại ảnh phòng
        private void reloadImagePhong()
        {
            imgPhong.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imgPhong.Images.Add(h.getImage());
            }
        }

        //load lại ảnh nhân viên
        private void reloadImageNhanVienPT()
        {
            imgNhanVien.Images.Clear();
            foreach (HinhAnh h in listHinhNV)
            {
                imgNhanVien.Images.Add(h.getImage());
            }
        }

        //xóa phòng
        public void XoaPhong()
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa phòng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (objPhong.delete() != -1)
                {
                    XtraMessageBox.Show("Xóa phòng thành công!");
                    //reLoad();
                    reLoadAndFocused(objPhong.id);
                }
                else
                {
                    if (objPhong.countThietBi() > 0)
                    {
                        XtraMessageBox.Show("Có thiết bị trong phòng. Vui lòng xóa thiết bị trước!");
                    }
                    else
                    {
                        XtraMessageBox.Show("Phòng có chứa Log tình trạng. Không thể xóa!");
                    }
                }
            }
        }

        private void barButtonThemPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridViewPhong.AddNewRow();
            //int rowHandler = gridViewPhong.RowCount - 1;
            //gridViewPhong.FocusedRowHandle = rowHandler;
            searchLookUpEditNhanVienPT.Properties.DataSource = listNhanVienPT;
            enableEdit(true, "add");
            beforeAdd();
            SetTextGroupControl("Thêm phòng mới", true);
            searchLookUpEditNhanVienPT.EditValue = null;
            _ucComboBoxViTri.Visible = true;
            ViTri _ViTri = _ucTreeViTri.getVitri();
            _ucComboBoxViTri.setViTri(_ViTri);
        }

        private void barButtonSuaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            searchLookUpEditNhanVienPT.Properties.DataSource = listNhanVienPT;
            enableEdit(true, "edit");
            //_index = gridViewPhong.FocusedRowHandle;
            SetTextGroupControl("Chỉnh sửa phòng", true);
            if (objPhong.nhanvienpt != null)
                searchLookUpEditNhanVienPT.EditValue = objPhong.nhanvienpt.id;
        }

        private void barButtonXoaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                XoaPhong();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không có gì để xóa");
                enableBar(false);
            }
        }

        public RibbonControl getRibbon()
        {
            return ribbonPhongThietBi;
        }

        public TreeList getTreeList()
        {
            return _ucTreeViTri.getTreeList();
        }

        private void gridViewPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                showChiTietTB(false);
                objPhong = Phong.getById(Convert.ToInt32(gridViewPhong.GetRowCellValue(e.FocusedRowHandle, id)));
                setInfoPhongNhanVien();
            }
        }

        //Truyền thông tin phòng + nhân viên khi thay đổi dòng gridview
        private void setInfoPhongNhanVien()
        {
            try
            {
                if (function.Equals("edit") || function.Equals("add"))
                {
                    enableBar(true);
                    SetTextGroupControl("Chi tiết", false);
                    dxErrorProvider.ClearErrors();
                    enableEdit(false, "");
                }
                if (objPhong == null)
                {
                    objPhong = new Phong();
                }
                txtMaPhong.Text = objPhong.subId;
                txtTenPhong.Text = objPhong.ten;
                txtMoTaPhong.Text = objPhong.mota;
                _ucComboBoxViTri.setViTri(objPhong.vitri);
                NhanVienPT objNV = new NhanVienPT();
                if (objPhong.nhanvienpt != null)
                {
                    objNV = objPhong.nhanvienpt;
                }
                txtMaNhanVien.Text = objNV.subId;
                txtTenNhanVien.Text = objNV.hoten;
                txtSoDienThoai.Text = objNV.sodienthoai;
                if (objPhong.hinhanhs == null)
                    listHinh = new List<HinhAnh>();
                else
                    listHinh = objPhong.hinhanhs.ToList();
                if (objPhong.nhanvienpt != null)
                {
                    if (objPhong.nhanvienpt.hinhanhs == null)
                        listHinhNV = new List<HinhAnh>();
                    else
                        listHinhNV = objPhong.nhanvienpt.hinhanhs.ToList();
                }
                else
                {
                    listHinhNV = new List<HinhAnh>();
                }
                reloadImagePhong();
                reloadImageNhanVienPT();
            }
            catch (Exception ex)
            { }
            finally { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setInfoPhongNhanVien();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                switch (function)
                {
                    case "edit":
                        ChinhSuaPhong();
                        break;
                    case "add":
                        ThemPhong();
                        break;
                }
                enableEdit(false, "");
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = new frmHinhAnh(listHinh);

                if (function.Equals("edit"))
                {
                    frm.Text = "Quản lý hình ảnh " + objPhong.ten;
                }
                else
                {
                    frm.Text = "Quản lý hình ảnh phòng mới";
                }
                frm.ShowDialog();
                listHinh = frm.getlistHinhs();
                reloadImagePhong();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        public void beforeAdd()
        {
            //clear textbox-img phòng
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtMoTaPhong.Text = "";
            imgPhong.Images.Clear();
            listHinh = new List<HinhAnh>();
            //clear textbox-img nhân viên
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtSoDienThoai.Text = "";
            imgNhanVien.Images.Clear();
        }
        
        private void searchLookUpEditNhanVienPT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchLookUpEditNhanVienPT.EditValue != null)
                {
                    // set hình ảnh và thông tin nhân viên phụ trách khi được chọn
                    _idnhanvien = Int32.Parse(searchLookUpEditNhanVienPT.EditValue.ToString());
                    objPhong.nhanvienpt = NhanVienPT.getById(_idnhanvien);
                    txtMaNhanVien.Text = objPhong.nhanvienpt.subId;
                    txtTenNhanVien.Text = objPhong.nhanvienpt.hoten;
                    txtSoDienThoai.Text = objPhong.nhanvienpt.sodienthoai;
                    listHinhNV = objPhong.nhanvienpt.hinhanhs.ToList();
                    reloadImageNhanVienPT();
                }
                else
                {
                    _idnhanvien = -1;
                }
            }
            catch(Exception ex)
            {

            }
        }

        //Thêm xóa sửa bằng phím tắt
        private void gridViewPhong_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.T:
                    this.barButtonThemPhong.PerformClick();
                    break;
                case Keys.S:
                    this.barButtonSuaPhong.PerformClick();
                    break;
                case Keys.X : case Keys.Delete:
                    this.barButtonXoaPhong.PerformClick();
                    break;
            }
        }

        private void gridViewPhong_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            PhongHienThi p = (PhongHienThi)gridViewPhong.GetRow(e.RowHandle);
            e.IsEmpty = p.soluongtb == 0;
        }

        private void gridViewPhong_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridViewPhong_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "ChiTietTBs";
        }

        private void gridViewPhong_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            PhongHienThi p = (PhongHienThi)gridViewPhong.GetRow(e.RowHandle);
            e.ChildList = p.ChiTietTBs();
        }

        private void gridViewChiTietTBs_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                GridView view = sender as GridView;
                _ucChiTietThietBi.setData(CTThietBi.getById(Convert.ToInt32(view.GetRowCellValue(e.FocusedRowHandle, coltbid))));
                showChiTietTB(true);
            }
        }

        private void showChiTietTB(bool _show)
        {
            if (_show)
            {
                splitContainerControl1.Panel2.Controls.Clear();
                splitContainerControl1.Panel2.Controls.Add(_ucChiTietThietBi);
            }
            else
            {
                splitContainerControl1.Panel2.Controls.Clear();
                splitContainerControl1.Panel2.Controls.Add(panelPhong);
            }
            barButtonSuaTB.Enabled = _show;
            barButtonXoaTB.Enabled = _show;
            barButtonSuaPhong.Enabled = !_show;
            barButtonXoaPhong.Enabled = !_show;
            barButtonChuyen.Enabled = _show;
        }

        private void gridViewChiTietTBs_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
        }

        private void gridViewPhong_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                showChiTietTB(false);
                setInfoPhongNhanVien();
            }
        }

        private void gridViewChiTietTBs_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                GridView view = sender as GridView;
                objCTThietBi = CTThietBi.getById(Convert.ToInt32(view.GetRowCellValue(e.RowHandle, coltbid)));
                _ucChiTietThietBi.setData(objCTThietBi);
                showChiTietTB(true);
            }
        }

        private void barButtonSuaTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ucChiTietThietBi.enableEdit(true);
        }

        private void barButtonXoaTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        private void deleteObj()
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn loại thiết bị ra khỏi phòng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (objCTThietBi.delete() > 0)
                {
                    XtraMessageBox.Show("Loại thiết bị ra khỏi phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reLoadThietBiTrongPhong();
                }
                else
                {
                    XtraMessageBox.Show("Không thể loại thiết bị ra khỏi phòng!");
                }
            }
        }

        private void barButtonThemTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNewThietBi frm = new frmNewThietBi();
            frm.ShowDialog();
        }
    }
}
