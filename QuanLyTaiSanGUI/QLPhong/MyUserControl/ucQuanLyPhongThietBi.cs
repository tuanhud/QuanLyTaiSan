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
using QuanLyTaiSanGUI.QLPhong;
using DevExpress.XtraGrid.Localization;
using QuanLyTaiSanGUI.QLPhong.MyForm;
using SHARED.Libraries;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhongThietBi : UserControl, _ourUcInterface
    {
        Phong objPhong = new Phong();
        CTThietBi objCTThietBi = new CTThietBi();
        List<ChiTietTBHienThi> listCTThietBis = null;
        List<HinhAnh> listHinh = new List<HinhAnh>();
        //ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLPhongThietBi");
        ucTreeViTri _ucTreeViTri = new ucTreeViTri();
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();
        bool working = false;
        MyLayout layout = new MyLayout();

        public ucQuanLyPhongThietBi()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ribbonPhongThietBi.Parent = null;
            //_ucTreeViTri.Parent = this;
            _ucTreeViTri.setData_phongid = new ucTreeViTri.SetData_phongid(setData);
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucTreeLoaiTB);
            _ucTreeLoaiTB.setReadOnly(true);
            //gridViewlog.Columns[colngay.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridViewCTThietBi.Columns[colma.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewCTThietBi.Columns[colten.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewCTThietBi.Columns[colloaiTB.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewCTThietBi.Columns[coltinhtrang.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewCTThietBi.Columns[colnone.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;

            layout.save(gridViewCTThietBi);
        }

        // Load dữ liệu
        public void loadData(Phong obj = null)
        {
            try
            {
                layout.load(gridViewCTThietBi);
                working = false;
                enableEdit(false);
                List<LoaiThietBi> listLoai = LoaiThietBi.getAll();
                _ucTreeLoaiTB.loadData(listLoai);
                List<ViTriHienThi> listVitris = ViTriHienThi.getAllHavePhong();
                _ucTreeViTri.loadData(listVitris);
                if (obj != null)
                {
                    objPhong = obj;
                    _ucTreeViTri.setPhong(objPhong);
                }
                else
                {
                    objPhong = _ucTreeViTri.getPhong();
                }
                gridControlCTThietBi.DataSource = null;
                listCTThietBis = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
                gridControlCTThietBi.DataSource = listCTThietBis;
                editGUI();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }
        }

        public void setData(Guid _phongid)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            try
            {
                objPhong = Phong.getById(_phongid);
                gridControlCTThietBi.DataSource = null;
                listCTThietBis = ChiTietTBHienThi.getAllByPhongId(_phongid);
                gridControlCTThietBi.DataSource = listCTThietBis;
                editGUI();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setData:" + ex.Message);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void editGUI()
        {
            if (objPhong != null && objPhong.id != Guid.Empty)
            {
                bool canEdit = Permission.canEdit<Phong>(objPhong);
                groupPhong.Text = "Phòng " + objPhong.ten;
                barButtonThemTBChung.Enabled = true && canEdit;
                barButtonThemTBRieng.Enabled = true && canEdit;
            }
            else
            {
                groupPhong.Text = "";
                barButtonThemTBChung.Enabled = false;
                barButtonThemTBRieng.Enabled = false;
            }
            if (listCTThietBis.Count > 0)
            {
                bool canEdit = Permission.canEdit<Phong>(objPhong);
                panelControl1.Visible = true;
                barButtonSua.Enabled = true && canEdit;
                barButtonXoa.Enabled = true && canEdit;
                barButtonChuyen.Enabled = true && canEdit;
                btnR_Sua.Enabled = true && canEdit;
                btnR_Xoa.Enabled = true && canEdit;
            }
            else
            {
                barButtonSua.Enabled = false;
                barButtonXoa.Enabled = false;
                barButtonChuyen.Enabled = false;
                btnR_Sua.Enabled = false;
                btnR_Xoa.Enabled = false;
                panelControl1.Visible = false;
                clearGroupChiTiet();
            }
        }

        private void clearGroupChiTiet()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtMoTa.Text = "";
            lblTenPhong.Text = "";
            dateLap.EditValue = "";
            dateMua.EditValue = "";
            imageSlider1.Images.Clear();
            gridControlLog.DataSource = null;
        }

        public RibbonControl getRibbon()
        {
            return ribbonPhongThietBi;
        }

        public TreeList getTreeList()
        {
            return _ucTreeViTri.getTreeList();
        }

        private void gridViewCTThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (working)
            {
                enableEdit(false);
            }
            if (e.FocusedRowHandle >= 0 && gridViewCTThietBi.GetFocusedRow() != null)
            {
                objCTThietBi = CTThietBi.getById(GUID.From(gridViewCTThietBi.GetRowCellValue(e.FocusedRowHandle, colid)));
                objCTThietBi = (gridViewCTThietBi.GetFocusedRow() as ChiTietTBHienThi).ctthietbi;
                if (objCTThietBi != null)
                    setThongTinThietBi(objCTThietBi);
            }
        }

        private void gridViewCTThietBi_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle >= 0 && gridViewCTThietBi.GetFocusedRow() != null)
            {
                //objCTThietBi = CTThietBi.getById(Convert.ToInt32(gridViewCTThietBi.GetRowCellValue(e.RowHandle, colid)));
                objCTThietBi = (gridViewCTThietBi.GetFocusedRow() as ChiTietTBHienThi).ctthietbi;
                if (objCTThietBi != null)
                    setThongTinThietBi(objCTThietBi);
            }
        }

        private void setThongTinThietBi(CTThietBi _obj)
        {
            try
            {
                txtMa.Text = _obj.thietbi.subId;
                txtTen.Text = _obj.thietbi.ten;
                txtMoTa.Text = _obj.thietbi.mota;
                lblTenPhong.Text = _obj.phong.ten;
                dateMua.EditValue = _obj.thietbi.loaithietbi.loaichung ? null : _obj.thietbi.ngaymua;
                dateLap.EditValue = _obj.ngay;
                _ucTreeLoaiTB.setLoai(_obj.thietbi.loaithietbi);
                listHinh = _obj.thietbi.hinhanhs.ToList();
                gridControlLog.DataSource = _obj.thietbi.logthietbis.Where(c=>c.phong_id==_obj.phong.id && c.soluong > 0).OrderByDescending(c=>c.date_create).ToList();
                reloadImage();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setThongTinThietBi:" + ex.Message);
            }
        }

        private void reloadImage()
        {
            imageSlider1.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                try
                {
                    imageSlider1.Images.Add(h.getImage());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->reloadImage: " + ex.Message);
                }
            }
        }

        private void barButtonSuaTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true);
        }

        public void SetTextGroupControl(String _text, bool _color)
        {
            groupControl1.Text = _text;
            if (_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Empty;
        }

        public void enableEdit(bool _enable)
        {
            btnImage.Visible = _enable;
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtMa.Properties.ReadOnly = !_enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            if(objCTThietBi != null && 
                objCTThietBi.thietbi != null && 
                objCTThietBi.thietbi.loaithietbi != null && 
                objCTThietBi.thietbi.loaithietbi.loaichung && _enable)
                dateMua.Properties.ReadOnly = true;
            else
                dateMua.Properties.ReadOnly = !_enable;
            dateLap.Properties.ReadOnly = !_enable;
            _ucTreeLoaiTB.setReadOnly(!_enable);
            working = _enable;
            //
            rbnPageThietBi.Enabled = !_enable;
            rbnPageChuyen.Enabled = !_enable;
            btnR_Sua.Enabled = !_enable;
            btnR_Xoa.Enabled = !_enable;
            if (_enable)
            {
                SetTextGroupControl("Sửa thiết bị", true);
                txtMa.Focus();
            }
            else
            {
                SetTextGroupControl("Chi tiết", false);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                editObj();
                enableEdit(false);
            }
        }

        private void editObj()
        {
            try
            {
                ThietBi obj = objCTThietBi.thietbi;
                obj.subId = txtMa.Text;
                obj.ten = txtTen.Text;
                obj.mota = txtMoTa.Text;
                obj.loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
                obj.ngaymua = dateMua.EditValue != null ? dateMua.DateTime : obj.ngaymua;
                obj.hinhanhs = listHinh;
                if (obj.update() > 0 && DBInstance.commit() > 0)
                {
                    XtraMessageBox.Show("Sửa thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reLoadCTThietBisOnlyAndFocused(objCTThietBi.id);
                }
                else
                {
                    XtraMessageBox.Show("Không thể sửa thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "=>editObj:" + ex.Message);
            }
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

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = new frmHinhAnh(listHinh);
                frm.Text = "Quản lý hình ảnh " + objCTThietBi.thietbi.ten;
                frm.ShowDialog();
                listHinh = frm.getlistHinhs();
                reloadImage();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": btnImage_Click :" + ex.Message);
            }
            finally
            { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setThongTinThietBi(objCTThietBi);
            enableEdit(false);
        }

        private void barButtonXoaTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        public void deleteObj()
        {
            try
            {
                //if (XtraMessageBox.Show("Bạn có chắc là muốn loại thiết bị ra khỏi phòng không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                String str = String.Format("Bạn có chắc là muốn loại thiết bị {0}\n ra khỏi phòng {1} không?", objCTThietBi.thietbi.ten, objCTThietBi.phong.ten);
                frmRemoveThietBi frm = new frmRemoveThietBi(str);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    objCTThietBi.mota = frm.mota;
                    if (objCTThietBi.delete() > 0 && DBInstance.commit() > 0)
                    {
                        XtraMessageBox.Show("Loại thiết bị ra khỏi phòng thành công!");
                        reLoadCTThietBisOnly();
                    }
                    else
                    {
                        XtraMessageBox.Show("Không thể loại thiết bị ra khỏi phòng!");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "=>deleteObj: " + ex.Message);
            }
        }

        private void reLoadCTThietBisOnly()
        {
            listCTThietBis = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
            gridControlCTThietBi.DataSource = listCTThietBis;
            editGUI();
        }

        public void reLoadCTThietBisOnlyAndFocused(Guid _id)
        {
            reLoadCTThietBisOnly();
            int rowHandle = gridViewCTThietBi.LocateByValue(colid.FieldName, _id);
            if (rowHandle != GridControl.InvalidRowHandle)
                gridViewCTThietBi.FocusedRowHandle = rowHandle;
        }

        private void barButtonChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid id = objCTThietBi.id;
            frmChuyen frm = new frmChuyen(objCTThietBi);
            frm.ShowDialog();
            reLoadCTThietBisOnlyAndFocused(id);
        }

        private void barButtonThemTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmNewThietBi frm = new frmNewThietBi(objCTThietBi.phong);
            //frm.ShowDialog();
            frmAddThietBi frm = new frmAddThietBi(objPhong, true);
            frm.Text = "Thêm thiết bị quản lý theo số lượng vào phòng " + objPhong.ten;
            frm.reLoadAndFocused_phong_thietbi = new frmAddThietBi.ReLoadAndFocused_phong_thietbi(reLoadCTThietBisOnlyAndFocused);
            frm.ShowDialog();
        }

        private void barButtonThemTBRieng_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddThietBi frm = new frmAddThietBi(objPhong, false);
            frm.Text = "Thêm thiết bị quản lý theo cá thể vào phòng " + objPhong.ten;
            frm.reLoadAndFocused_phong_thietbi = new frmAddThietBi.ReLoadAndFocused_phong_thietbi(reLoadCTThietBisOnlyAndFocused);
            frm.ShowDialog();
        }

        private void btnR_Sua_Click(object sender, EventArgs e)
        {
            enableEdit(true);
        }

        private void btnR_Xoa_Click(object sender, EventArgs e)
        {
            deleteObj();
        }

        private void gridViewCTThietBi_DataSourceChanged(object sender, EventArgs e)
        {
            if (working)
            {
                enableEdit(false);
            }
            if (gridViewCTThietBi.FocusedRowHandle >= 0 && gridViewCTThietBi.GetFocusedRow() != null)
            {
                objCTThietBi = (gridViewCTThietBi.GetFocusedRow() as ChiTietTBHienThi).ctthietbi;
                if (objCTThietBi != null)
                    setThongTinThietBi(objCTThietBi);
            }
        }

        public bool checkworking()
        {
            try
            {
                if (!txtTen.Properties.ReadOnly)
                {
                    ThietBi obj = objCTThietBi.thietbi;
                    return
                    obj.subId != txtMa.Text ||
                    obj.ten != txtTen.Text ||
                    obj.mota != txtMoTa.Text ||
                    obj.loaithietbi != _ucTreeLoaiTB.getLoaiThietBi() ||
                    obj.ngaymua != dateMua.DateTime ||
                    objCTThietBi.ngay != dateLap.DateTime ||
                    obj.hinhanhs.Except(listHinh).Count() > 0 ||
                    listHinh.Except(obj.hinhanhs).Count() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
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

        private void gridViewlog_DoubleClick(object sender, EventArgs e)
        {
            if (objCTThietBi != null && objCTThietBi.id != Guid.Empty && objCTThietBi.logthietbis.Count > 0)
            {
                frmLogThietBi frm = new frmLogThietBi(objCTThietBi.logthietbis.OrderByDescending(c => c.date_create).ToList());
                frm.Text += " " + objCTThietBi.thietbi.ten;
                frm.ShowDialog();
            }
        }

        private void barBtnImportSL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
            open.Title = "Chọn tập tin để Import";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportThietBiChung(open.FileName, "ThietBiChung"))
                //if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportThietBiRieng(open.FileName, "ThietBiRieng"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                    //loadData();
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                    //loadData();
                }

            }
        }

        private void barBtnImportCT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
            open.Title = "Chọn tập tin để Import";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                //if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportThietBiChung(open.FileName, "ThietBiChung"))
                if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportThietBiRieng(open.FileName, "ThietBiRieng"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                    //loadData();
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                    //loadData();
                }

            }
        }

        public void reLoad()
        {
            throw new NotImplementedException();
        }
    }
}
