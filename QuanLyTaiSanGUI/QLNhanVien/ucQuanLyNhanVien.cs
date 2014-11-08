using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTB.Entities;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using PTB.DataFilter;
using PTB.Libraries;
using PTB_GUI.MyUC;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using SHARED.Libraries;
using PTB_GUI.ThongKe;
using DevExpress.XtraReports.UI;

namespace PTB_GUI.QLNhanVien
{
    public partial class ucQuanLyNhanVien : UserControl, _ourUcInterface
    {
        ucTreePhongHaveCheck _ucTreePhongHaveCheck = new ucTreePhongHaveCheck();
        List<NhanVienPT> NhanVienPTs = new List<NhanVienPT>();
        List<Phong> listPhong = new List<Phong>();
        NhanVienPT objNhanVienPT = new NhanVienPT();
        List<HinhAnh> listHinhs = new List<HinhAnh>();
        String function = "";
        Boolean working = false;
        bool canAdd = false;
        bool canEdit = false;
        bool canDelete = false;
        bool canPhanCong = false;

        MyLayout layout = new MyLayout();

        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ribbonNhanVienPT.Parent = null;
            _ucTreePhongHaveCheck.Dock = DockStyle.Fill;
            _ucTreePhongHaveCheck.loadListPhong = new ucTreePhongHaveCheck.LoadListPhong(LoadListPhong);
            //gridViewNhanVien.Columns[colhoten.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            listBoxPhong.SortOrder = SortOrder.Ascending;
            gridViewNhanVien.Columns[colhoten.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewNhanVien.Columns[colsodienthoai.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            layout.save(gridViewNhanVien);
        }

        public void loadData()
        {
            try
            {
                checkPermission();
                editGUI("view");
                layout.load(gridViewNhanVien);
                NhanVienPTs = NhanVienPT.getQuery().OrderBy(c => c.hoten).ToList();
                gridControlNhanVien.DataSource = NhanVienPTs;
                if (NhanVienPTs.Count == 0)
                {
                    enableButton(false);
                    barBtnThemNhanVien.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void checkPermission()
        {
            try
            {
                canAdd = Permission.canAdd<NhanVienPT>();
                canEdit = Permission.canEdit<NhanVienPT>(null);
                canDelete = Permission.canDelete<NhanVienPT>(null);
                canPhanCong = Permission.canEdit<Phong>(null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkPermission: " + ex.Message);
            }
        }

        private void editGUI(String _type)
        {
            if (_type.Equals("view"))
            {
                if (function.Equals("phancong"))
                {
                    PhanCong(false);
                }
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
                barBtnThemNhanVien.Enabled = true && canAdd;
            }
            else if (_type.Equals("add"))
            {
                if (function.Equals("phancong"))
                {
                    PhanCong(false);
                }
                SetTextGroupControl("Thêm nhân viên phụ trách", Color.Red);
                enableEdit(true);
                clearText();
                txtMa.Focus();
            }
            else if (_type.Equals("edit"))
            {
                if (function.Equals("phancong"))
                {
                    PhanCong(false);
                }
                SetTextGroupControl("Sửa nhân viên phụ trách", Color.Red);
                enableEdit(true);
                txtMa.Focus();
            }
            else if (_type.Equals("phancong"))
            {
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(true);
                txtMa.Properties.ReadOnly = true;
                txtTen.Properties.ReadOnly = true;
                txtSodt.Properties.ReadOnly = true;
                btnImage.Visible = false;
                PhanCong(true);
            }
            function = _type;
        }

        private void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        private void enableEdit(bool _enable)
        {
            btnImage.Visible = _enable;
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtMa.Properties.ReadOnly = !_enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtSodt.Properties.ReadOnly = !_enable;
            enableButton(!_enable);
            barBtnThemNhanVien.Enabled = !_enable && canAdd;
            btnR_Them.Enabled = !_enable && canAdd;
            working = _enable;
        }

        private void enableButton(bool _enable)
        {
            //btnR_Them.Enabled = _enable;
            btnR_Sua.Enabled = _enable && canEdit;
            btnR_Xoa.Enabled = _enable && canDelete;
            barBtnSuaNhanVien.Enabled = _enable && canEdit;
            barBtnXoaNhanVien.Enabled = _enable && canDelete;
            //rbnGroupNhanVien.Enabled = _enable;
            rbnGroupNhanVienPhong.Enabled = _enable && canPhanCong;
        }

        private void clearText()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSodt.Text = "";
            imageSlider1.Images.Clear();
            listHinhs = new List<HinhAnh>();
            listBoxPhong.DataSource = null;
        }

        private void setDataView()
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                if (!function.Equals("view"))
                    editGUI("view");
                if (gridViewNhanVien.RowCount > 0)
                {
                    if (gridViewNhanVien.FocusedRowHandle > -1 && gridViewNhanVien.GetFocusedRow() != null)
                    {
                        objNhanVienPT = gridViewNhanVien.GetFocusedRow() as NhanVienPT;
                        txtMa.Text = objNhanVienPT.subId;
                        txtTen.Text = objNhanVienPT.hoten;
                        txtSodt.Text = objNhanVienPT.sodienthoai;
                        listPhong = objNhanVienPT.phongs.ToList();
                        listBoxPhong.DataSource = listPhong;
                        listHinhs = objNhanVienPT.hinhanhs.ToList();
                        reloadImage();
                    }
                    else
                    {
                        clearText();
                        objNhanVienPT = new NhanVienPT();
                    }
                }
                else
                {
                    enableButton(false);
                    barBtnThemNhanVien.Enabled = true && canAdd;
                    clearText();
                    objNhanVienPT = new NhanVienPT();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }



        private void gridViewNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
        }

        private void reLoadAndFocused(Guid _id)
        {
            try
            {
                loadData();
                int rowHandle = gridViewNhanVien.LocateByValue(colid.FieldName, _id);
                if (rowHandle != GridControl.InvalidRowHandle)
                    gridViewNhanVien.FocusedRowHandle = rowHandle;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reLoadAndFocused: " + ex.Message);
            }
        }

        private void Function(String _function)
        {
            try
            {
                if (_function.Equals("edit"))
                {
                    objNhanVienPT.subId = txtMa.Text;
                    objNhanVienPT.hoten = txtTen.Text;
                    objNhanVienPT.sodienthoai = txtSodt.Text;
                    objNhanVienPT.hinhanhs = listHinhs;
                    if (objNhanVienPT.update() > 0 && DBInstance.commit() > 0)
                    {
                        XtraMessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //reLoad();
                        reLoadAndFocused(objNhanVienPT.id);
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (_function.Equals("add"))
                {
                    NhanVienPT objNew = new NhanVienPT();
                    objNew.subId = txtMa.Text;
                    objNew.hoten = txtTen.Text;
                    objNew.sodienthoai = txtSodt.Text;
                    objNew.hinhanhs = listHinhs;
                    if (objNew.add() > 0 && DBInstance.commit() > 0)
                    {
                        XtraMessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //reLoad();
                        reLoadAndFocused(objNew.id);
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (_function.Equals("phancong"))
                {
                    Guid id = objNhanVienPT.id;
                    try
                    {
                        objNhanVienPT.phongs.Clear();
                        objNhanVienPT.phongs = listPhong;
                        ////Quan hệ 0 - n nên không thể gán list
                        //List<Phong> listToRemove = objNhanVienPT.phongs.Except(listPhong).ToList();
                        //List<Phong> listToAdd = listPhong.Except(objNhanVienPT.phongs).ToList();
                        //foreach (Phong objToRemove in listToRemove)
                        //{
                        //    objToRemove.nhanvienpt = null;
                        //    objToRemove.update();
                        //}
                        //foreach (Phong objToAdd in listToAdd)
                        //{
                        //    objToAdd.nhanvienpt = objNhanVienPT;
                        //    objToAdd.update();
                        //}
                        if (DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Phân công nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            editGUI("view");
                            reLoadAndFocused(id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Phân công nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(this.Name + "->Function-PhanCong: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->Function: " + ex.Message);
            }
        }

        public void deleteObj()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc là muốn xóa nhân viên?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (objNhanVienPT.delete() > 0 && DBInstance.commit() > 0)
                    {
                        XtraMessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhân viên này đã được phân công, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
            }
            finally
            { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                Function(function);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (function.Equals("phancong"))
            {
                Guid id = objNhanVienPT.id;
                editGUI("view");
                int rowHandle = gridViewNhanVien.LocateByValue(colid.FieldName, id);
                if (rowHandle != GridControl.InvalidRowHandle)
                    gridViewNhanVien.FocusedRowHandle = rowHandle;
            }
            else
            {
                dxErrorProvider1.ClearErrors();
                setDataView();
            }
        }

        private Boolean CheckInput()
        {
            dxErrorProvider1.ClearErrors();
            Boolean check = true;
            //if (txtMa.Text.Length == 0)
            //{
            //    dxErrorProvider1.SetError(txtMa, "Chưa điền mã nhân viên");
            //    check = false;
            //}
            if (txtTen.Text.Length == 0)
            {
                dxErrorProvider1.SetError(txtTen, "Chưa điền tên nhân viên");
                check = false;
            }
            //if (!(txtSodt.Text.Length >= 9 && txtSodt.Text.Length <= 15))
            //{
            //    errorProvider1.SetError(txtSodt, "Số điện thoại từ 9-15 kí tự");
            //    check = false;
            //}
            //if (!IsNumber(txtSodt.Text))
            //{
            //    dxErrorProvider1.SetError(txtSodt, "Số điện thoại không hợp lệ");
            //    check = false;
            //}
            //if (txtSodt.Text.Length == 0)
            //{
            //    dxErrorProvider1.SetError(txtSodt, "Chưa điền số điện thoại");
            //    check = false;
            //}
            return check;
        }

        private Boolean IsNumber(String str)
        {
            int num;
            if (int.TryParse(str, out num))
                return true;
            return false;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = new frmHinhAnh(listHinhs);
                if (function.Equals("edit"))
                {
                    frm.Text = "Quản lý hình ảnh " + objNhanVienPT.hoten;

                }
                else
                {
                    frm.Text = "Quản lý hình ảnh nhân viên mới";
                }
                frm.ShowDialog();
                listHinhs = frm.getlistHinhs();
                reloadImage();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnImage_Click: " + ex.Message);
            }
        }

        private void reloadImage()
        {
            try
            {
                imageSlider1.Images.Clear();
                if (listHinhs != null)
                {
                    foreach (HinhAnh h in listHinhs)
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

        public void PhanCong(bool _bool)
        {
            try
            {
                splitContainerControl1.Panel1.Controls.Clear();
                if (_bool)
                {
                    List<ViTriHienThi> listVT = ViTriHienThi.getAllHavePhongNotNhanVien(objNhanVienPT.id);
                    _ucTreePhongHaveCheck.loadData(listVT, objNhanVienPT);
                    splitContainerControl1.Panel1.Controls.Add(_ucTreePhongHaveCheck);
                }
                else
                {
                    splitContainerControl1.Panel1.Controls.Add(gridControlNhanVien);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->PhanCong: " + ex.Message);
            }
            finally
            { }
        }

        public RibbonControl getRibbon()
        {
            return ribbonNhanVienPT;
        }

        private void barBtnThemNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("add");
        }

        private void barBtnSuaNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit");
        }

        private void barBtnXoaNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        private void barBtnPhanCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("phancong");
            //working = true;
        }

        private void LoadListPhong(List<Phong> list)
        {
            listBoxPhong.DataSource = list;
            listPhong = list;
        }

        private void btnR_Them_Click(object sender, EventArgs e)
        {
            editGUI("add");
        }

        private void btnR_Sua_Click(object sender, EventArgs e)
        {
            editGUI("edit");
        }

        private void btnR_Xoa_Click(object sender, EventArgs e)
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
                        objNhanVienPT.subId != txtMa.Text ||
                        objNhanVienPT.hoten != txtTen.Text ||
                        objNhanVienPT.sodienthoai != txtSodt.Text ||
                        objNhanVienPT.hinhanhs.Except(listHinhs).Count() > 0 ||
                        listHinhs.Except(objNhanVienPT.hinhanhs).Count() > 0;
                }
                else if (function.Equals("add"))
                {
                    return
                        !txtMa.Text.Equals("") ||
                        !txtTen.Text.Equals("") ||
                        !txtSodt.Text.Equals("") ||
                        listHinhs.Count > 0;
                }
                else if (function.Equals("phancong"))
                {
                    return
                        objNhanVienPT.phongs.Except(listPhong).Count() > 0 ||
                        listPhong.Except(objNhanVienPT.phongs).Count() > 0;
                }
                else
                    return working;
            }
            catch (Exception ex)
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
                if (PTB_GUI.Libraries.ExcelDataBaseHelper.ImportNhanVien(open.FileName, "NhanVienPT"))
                //if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportTinhTrang(open.FileName, "TinhTrang"))
                //if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportPhong(open.FileName, "Phong"))
                //if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportThietBiChung(open.FileName, "ThietBiChung"))
                //if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportThietBiRieng(open.FileName, "ThietBiRieng"))
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
                frmShowImage frm = new frmShowImage(listHinhs);
                frm.ShowDialog();
            }
        }

        private void gridViewNhanVien_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }

        public void reLoad()
        {
            throw new NotImplementedException();
        }

        private void barBtnXuatBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Object.Equals(NhanVienPTs, null))
            {
                XtraMessageBox.Show("Chưa có nhân viên phụ trách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NhanVienPTs.Count > 0)
            {
                try
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::PTB_GUI.WaitForm1), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
                    splashScreenManager_Report.ShowWaitForm();
                    splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                    splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                    XtraReport_Template _XtraReport_Template = new XtraReport_Template(SHARED.Libraries.ReportHelper.FillDatasetFromGrid(gridViewNhanVien), gridViewNhanVien, barCheckItemLandscape.Checked, false);
                    _XtraReport_Template.SetTitleText("Danh Sách Nhân Viên Phụ Trách");
                    if (barCheckItemThietKe.Checked)
                    {
                        ReportDesignTool designTool = new ReportDesignTool(_XtraReport_Template);
                        splashScreenManager_Report.CloseWaitForm();
                        designTool.ShowDesignerDialog();

                        ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                        printTool.ShowPreviewDialog();
                    }
                    else
                    {
                        ReportPrintTool printTool = new ReportPrintTool(_XtraReport_Template);
                        splashScreenManager_Report.CloseWaitForm();
                        printTool.ShowPreviewDialog();
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Đã xảy ra lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa có nhân viên phụ trách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
