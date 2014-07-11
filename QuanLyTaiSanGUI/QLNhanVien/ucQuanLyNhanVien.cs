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
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;
using QuanLyTaiSanGUI.MyUC;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;

namespace QuanLyTaiSanGUI.QLNhanVien
{
    public partial class ucQuanLyNhanVien : UserControl
    {
        ucTreePhongHaveCheck _ucTreePhongHaveCheck = new ucTreePhongHaveCheck();
        List<NhanVienPT> NhanVienPTs = new List<NhanVienPT>();
        List<Phong> listPhong = new List<Phong>();
        NhanVienPT objNhanVienPT = new NhanVienPT();
        List<HinhAnh> listHinhs = new List<HinhAnh>();
        String function = "";
        public Boolean working = false;

        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
             ribbonNhanVienPT.Parent = null;
            _ucTreePhongHaveCheck.Dock = DockStyle.Fill;
            gridViewNhanVien.Columns[colhoten.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            listBoxPhong.SortOrder = SortOrder.Ascending;
            gridViewNhanVien.Columns[colhoten.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewNhanVien.Columns[colsodienthoai.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
        }

        public void loadData()
        {
            try
            {
                NhanVienPTs = NhanVienPT.getAll();
                gridControlNhanVien.DataSource = null;
                gridControlNhanVien.DataSource = NhanVienPTs;
                if (NhanVienPTs.Count > 0)
                {
                    barBtnSuaNhanVien.Enabled = true;
                    barBtnXoaNhanVien.Enabled = true;
                    btnR_Sua.Enabled = true;
                    btnR_Xoa.Enabled = true;
                    barBtnPhanCong.Enabled = true;
                }
                else
                {
                    barBtnSuaNhanVien.Enabled = false;
                    barBtnXoaNhanVien.Enabled = false;
                    btnR_Sua.Enabled = false;
                    btnR_Xoa.Enabled = false;
                    barBtnPhanCong.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : loadData : " + ex.Message);
            }
            finally
            { }
        }

        private void gridViewNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewNhanVien.GetFocusedRow() != null)
                {
                    if (function.Equals("edit") || function.Equals("add"))
                    {
                        enableEdit(false, "");
                        SetTextGroupControl("Chi tiết", false);
                    }
                    objNhanVienPT = (NhanVienPT)gridViewNhanVien.GetFocusedRow();
                    SetData();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : gridViewNhanVien_FocusedRowChanged : " + ex.Message);
            }
            finally
            { }
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            btnImage.Visible = _enable;
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtMa.Properties.ReadOnly = !_enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtSodt.Properties.ReadOnly = !_enable;
            working = _enable;
            //
            rbnGroupNhanVien.Enabled = !_enable;
            rbnGroupNhanVienPhong.Enabled = !_enable;
            btnR_Them.Enabled = !_enable;
            btnR_Sua.Enabled = !_enable;
            btnR_Xoa.Enabled = !_enable;
        }

        public void reLoad()
        {
            loadData();
            if (!function.Equals(""))
            {
                enableEdit(false, "");
                errorProvider1.Clear();
                listHinhs = null;
                SetData();
            }
        }

        private void reLoadAndFocused(int _id)
        {
            try
            {
                reLoad();
                int rowHandle = gridViewNhanVien.LocateByValue(colid.FieldName, _id);
                if (rowHandle != GridControl.InvalidRowHandle)
                    gridViewNhanVien.FocusedRowHandle = rowHandle;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : reLoadAndFocused : " + ex.Message);
            }
            finally
            { }
        }

        public void beforeAdd()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSodt.Text = "";
            imageSlider1.Images.Clear();
            listHinhs = new List<HinhAnh>();
            listBoxPhong.DataSource = null;
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
                    if (objNhanVienPT.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa nhân viên thành công!");
                        //reLoad();
                        reLoadAndFocused(objNhanVienPT.id);
                    }
                }
                else if (_function.Equals("add"))
                {
                    NhanVienPT objNew = new NhanVienPT();
                    objNew.subId = txtMa.Text;
                    objNew.hoten = txtTen.Text;
                    objNew.sodienthoai = txtSodt.Text;
                    objNew.hinhanhs = listHinhs;
                    if (objNew.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm nhân viên thành công!");
                        //reLoad();
                        reLoadAndFocused(objNew.id);
                    }
                }
                else if (_function.Equals("phancong"))
                {
                    int id = objNhanVienPT.id;
                    try
                    {
                        
                        //Quan hệ 0 - n nên không thể gán list
                        List<Phong> listToRemove = objNhanVienPT.phongs.ToList();
                        foreach (Phong objToRemove in listToRemove)
                        {
                            objToRemove.nhanvienpt = null;
                            objToRemove.update();
                        }
                        foreach (Phong objToAdd in listPhong)
                        {
                            objToAdd.nhanvienpt = objNhanVienPT;
                            objToAdd.update();
                        }
                        //objNhanVienPT.phongs = listPhong;
                        //if (objNhanVienPT.update() != -1)
                        //{
                        //    XtraMessageBox.Show("Phân công nhân viên thành công!");
                        //    reLoad();
                        //    PhanCong(false);
                        //}
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(this.Name + " : btnOK_PhanCong_Click : " + ex.Message);
                    }
                    finally
                    {
                        XtraMessageBox.Show("Phân công nhân viên thành công!");
                        PhanCong(false);
                        reLoadAndFocused(id);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : Function : " + ex.Message);
            }
            finally
            { }
        }

        public void deleteObj()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc là muốn xóa nhân viên?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (objNhanVienPT.delete() > 0)
                    {
                        XtraMessageBox.Show("Xóa nhân viên thành công!");
                        reLoad();
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhân viên này đã được phân công, không thể xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : deleteObj : " + ex.Message);
            }
            finally
            { }
        }

        public void SetTextGroupControl(String text, bool _color)
        {
            groupControl1.Text = text;
            if (_color)
                groupControl1.AppearanceCaption.ForeColor = Color.Red;
            else
                groupControl1.AppearanceCaption.ForeColor = Color.Empty; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                Function(function);
                enableEdit(false, "");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (function.Equals("phancong"))
            {
                PhanCong(false);
            }
            else
            {
                enableEdit(false, "");
                errorProvider1.Clear();
                listHinhs = null;
            }
            SetData();
        }

        public void SetData()
        {
            try
            {
                SetTextGroupControl("Chi tiết", false);
                txtMa.Text = objNhanVienPT.subId;
                txtTen.Text = objNhanVienPT.hoten;
                txtSodt.Text = objNhanVienPT.sodienthoai;
                listBoxPhong.DataSource = objNhanVienPT.phongs;
                listHinhs = objNhanVienPT.hinhanhs.ToList();
                reloadImage();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : SetData : " + ex.Message);
            }
            finally
            { }
        }

        private Boolean CheckInput()
        {
            errorProvider1.Clear();
            Boolean check = true;
            if (txtMa.Text.Length == 0)
            {
                errorProvider1.SetError(txtMa, "Chưa điền mã nhân viên");
                check = false;
            }
            if (txtTen.Text.Length == 0)
            {
                errorProvider1.SetError(txtTen, "Chưa điền tên nhân viên");
                check = false;
            }
            if (!(txtSodt.Text.Length >= 9 && txtSodt.Text.Length <= 15))
            {
                errorProvider1.SetError(txtSodt, "Số điện thoại từ 9-15 kí tự");
                check = false;
            }
            if (!IsNumber(txtSodt.Text))
            {
                errorProvider1.SetError(txtSodt, "Số điện thoại không hợp lệ");
                check = false;
            }
            if (txtSodt.Text.Length == 0)
            {
                errorProvider1.SetError(txtSodt, "Chưa điền số điện thoại");
                check = false;
            }
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
                System.Console.WriteLine(this.Name + " : btnImage_Click : " + ex.Message);
            }
            finally
            { }
        }

        private void reloadImage()
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

        public void PhanCong(bool _bool)
        {
            try
            {
                btnOK.Visible = _bool;
                btnHuy.Visible = _bool;
                rbnGroupNhanVien.Enabled = !_bool;
                btnR_Them.Enabled = !_bool;
                btnR_Sua.Enabled = !_bool;
                btnR_Xoa.Enabled = !_bool;
                splitContainerControl1.Panel1.Controls.Clear();
                if (_bool)
                {
                    function = "phancong";
                    List<ViTriHienThi> listVT = ViTriHienThi.getAllHavePhongNotNhanVien(objNhanVienPT.id);
                    _ucTreePhongHaveCheck.loadData(listVT, objNhanVienPT);
                    splitContainerControl1.Panel1.Controls.Add(_ucTreePhongHaveCheck);
                }
                else
                {
                    function = "";
                    splitContainerControl1.Panel1.Controls.Add(gridControlNhanVien);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : PhanCong : " + ex.Message);
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
            enableEdit(true, "add");
            SetTextGroupControl("Thêm nhân viên", true);
            beforeAdd();
        }

        private void barBtnSuaNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
            SetData();
            SetTextGroupControl("Sửa nhân viên", true);
        }

        private void barBtnXoaNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        private void barBtnPhanCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhanCong(true);
            working = true;
        }

        public void LoadListPhong(List<Phong> list)
        {
            listBoxPhong.DataSource = list;
            listPhong = list;
        }

        private void btnR_Them_Click(object sender, EventArgs e)
        {
            enableEdit(true, "add");
            SetTextGroupControl("Thêm nhân viên", true);
            beforeAdd();
        }

        private void btnR_Sua_Click(object sender, EventArgs e)
        {
            enableEdit(true, "edit");
            SetData();
            SetTextGroupControl("Sửa nhân viên", true);
        }

        private void btnR_Xoa_Click(object sender, EventArgs e)
        {
            deleteObj();
        }
    }
}
