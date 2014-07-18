using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.QLPhong;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi_Old : UserControl
    {
        ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLThietBi");
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, true);
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();

        List<ViTriHienThi> listViTriHienThi = null;
        List<ThietBiFilter> listThietBiFilter = null;
        List<LoaiThietBi> listLoaiThietBi = null;

        ThietBi objThietBi = new ThietBi();
        ThietBiFilter objThietBiFilter = new ThietBiFilter();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        Boolean chonnhieu = false;

        public ucQuanLyThietBi_Old()
        {
            InitializeComponent();
            init();
            //loadData();
        }

        private void init()
        {
            ribbonThietBi.Parent = null;
            _ucTreeViTri.Parent = this;
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            _ucTreeLoaiTB.setReadOnly(true);
            _ucTreeLoaiTB.Visible = false;
            panelControlLoaiThietBi.Controls.Clear();
            panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            _ucComboBoxViTri.setReadOnly(true);
            panelControlPhong.Controls.Clear();
            panelControlPhong.Controls.Add(_ucComboBoxViTri);
            _ucComboBoxViTri.Visible = false;
        }

        public void loadData()
        {
            listViTriHienThi = ViTriHienThi.getAllHavePhong();
            //Xủ lí nếu chưa có cơ sở, dãy, tầng và phòng !!!!!!!!!!!!!!
            //Chưa làm
            _ucTreeViTri.loadData(listViTriHienThi);
            //OrderBy chạy rất chậm
            setData(_ucTreeViTri.phongid, _ucTreeViTri.cosoid, _ucTreeViTri.dayid, _ucTreeViTri.tangid);
            //listLoaiThietBi = LoaiThietBi.getAll().ToList();
            _ucTreeLoaiTB.loadData(listLoaiThietBi);
            _ucComboBoxViTri.loadData(listViTriHienThi);
            reLoadListThietBi();
        }

        protected void reLoadListThietBi()
        {
            ViTri currViTri = _ucTreeViTri.getVitri();
            if (currViTri != null)
            {
                int idCoSo, idDay, idTang;
                if (currViTri.coso != null)
                    idCoSo = currViTri.coso.id;
                else
                    idCoSo = -1;
                if (currViTri.day != null)
                    idDay = currViTri.day.id;
                else
                    idDay = -1;
                if (currViTri.tang != null)
                    idTang = currViTri.tang.id;
                else
                    idTang = -1;
                listThietBiFilter = ThietBiFilter.getAllBy4Id(-1, idCoSo, idDay, idTang);
            }
            else
                listThietBiFilter = new List<ThietBiFilter>();
            gridControlThietBi.DataSource = listThietBiFilter;
        }

        private void deleteData()
        {
            SetTextGroupControl("Chi tiết thiết bị", Color.Black);
            imageSlider1.Images.Clear();
            txtMa.Text = "";
            txtTen.Text = "";
            _ucComboBoxViTri.Visible = false;
            _ucTreeLoaiTB.Visible = false;
            dateEditMua.EditValue = null;
            dateEditLap.EditValue = null;
            txtMoTa.Text = "";
            gridControlLog.DataSource = null;
        }

        public void enableEdit(bool _enable)
        {
            if (_enable)
            {
                btnImage.Visible = true;
                btnOk.Visible = true;
                btnHuy.Visible = true;
                if (objThietBi.loaithietbi.loaichung)
                {
                    txtMa.Properties.ReadOnly = true;
                    txtTen.Properties.ReadOnly = true;
                    txtMoTa.Properties.ReadOnly = true;
                    dateEditMua.Properties.ReadOnly = true;
                    dateEditLap.Properties.ReadOnly = true;

                }
                else
                {
                    txtMa.Properties.ReadOnly = false;
                    txtTen.Properties.ReadOnly = false;
                    txtMoTa.Properties.ReadOnly = false;
                    dateEditMua.Properties.ReadOnly = false;
                    dateEditLap.Properties.ReadOnly = false;
                }
                _ucTreeLoaiTB.setReadOnly(true);
                _ucComboBoxViTri.setReadOnly(true);
            }
            else
            {
                btnImage.Visible = false;
                btnOk.Visible = false;
                btnHuy.Visible = false;

                txtTen.Properties.ReadOnly = true;
                txtMa.Properties.ReadOnly = true;
                txtMoTa.Properties.ReadOnly = true;
                _ucTreeLoaiTB.setReadOnly(true);
                _ucComboBoxViTri.setReadOnly(true);
                dateEditMua.Properties.ReadOnly = true;
                dateEditLap.Properties.ReadOnly = true;
            }
        }

        public void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        public TreeList getTreeList()
        {
            return _ucTreeViTri.getTreeList();
        }

        public RibbonControl getRibbon()
        {
            return ribbonThietBi;
        }

        private Boolean checkInput()
        {
            Boolean check = true;
            errorProvider1.Clear();
            if (!objThietBi.loaithietbi.loaichung)
            {
                if (txtTen.Text.Length == 0)
                {
                    check = false;
                    errorProvider1.SetError(txtTen, "Chưa điền tên thiết bị");
                }
                if (dateEditMua.DateTime > dateEditLap.DateTime)
                {   
                    check = false;
                    errorProvider1.SetError(dateEditLap, "Ngày lắp phải lớn hơn ngày mua");
                }
                if (dateEditMua.DateTime > DateTime.Today)
                {
                    check = false;
                    errorProvider1.SetError(dateEditMua, "Ngày mua lớn hơn ngày hiện tại");
                }
                if (dateEditLap.DateTime > DateTime.Today)
                {
                    check = false;
                    errorProvider1.SetError(dateEditLap, "Ngày lắp lớn hơn ngày hiện tại");
                }
            }
            return check;
        }

        public void setData(int phongid, int cosoid, int dayid, int tangid)
        {
            listThietBiFilter = ThietBiFilter.getAllBy4Id(phongid, cosoid, dayid, tangid);
            gridControlThietBi.DataSource = listThietBiFilter;
        }

        private void setData()
        {
            errorProvider1.Clear();
            if (listThietBiFilter.Count > 0)
            {
                SetTextGroupControl("Chi tiết thiết bị", Color.Black);
                imageSlider1.Images.Clear();
                if (objThietBi.hinhanhs.Count > 0)
                {
                    foreach (HinhAnh hinhanh in objThietBi.hinhanhs)
                    {
                        imageSlider1.Images.Add(hinhanh.IMAGE);
                    }
                }
                listHinhAnh = objThietBi.hinhanhs.ToList();

                txtTen.Text = objThietBi.ten;
                _ucTreeLoaiTB.setLoai(objThietBi.loaithietbi);
                _ucComboBoxViTri.setPhong(Phong.getById(objThietBiFilter.phong_id));
                _ucTreeLoaiTB.Visible = true;
                _ucComboBoxViTri.Visible = true;

                txtMa.Text = objThietBi.subId;
                dateEditMua.EditValue = objThietBi.ngaymua;
                //dateEditLap.EditValue = objThietBi.ngaylap;
                txtMoTa.Text = objThietBi.mota;

                //log chua lam
            }
            else
                deleteData();
        }

        private void setDataObj()
        {
            objThietBi.hinhanhs = listHinhAnh;

            objThietBi.subId = txtMa.Text;
            objThietBi.ten = txtTen.Text;

            if (objThietBi.loaithietbi.loaichung)
            {
                objThietBi.ngaymua = null;
                //objThietBi.ngaylap = null;
            }
            else
            {
                objThietBi.ngaymua = dateEditMua.DateTime;
                //objThietBi.ngaylap = dateEditLap.DateTime;
            }
            objThietBi.mota = txtMoTa.Text;
        }

        private void barButtonThemThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmNewThietBi frm = new frmNewThietBi();
            //frm.sendMessage = new frmNewThietBi.SendMessage(reLoadListThietBi);
            //frm.ShowDialog();
        }

        private void barButtonSuaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true);
            SetTextGroupControl("Sửa thông tin thiết bị", Color.Red);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            frmHinhAnh frm = new frmHinhAnh(listHinhAnh);
            frm.Text = "Quản lý hình ảnh " + objThietBi.ten;
            frm.ShowDialog();
            listHinhAnh = frm.getlistHinhs();
            if (listHinhAnh.Count > 0)
            {
                imageSlider1.Images.Clear();
                foreach (HinhAnh hinhanh in listHinhAnh)
                {
                    imageSlider1.Images.Add(hinhanh.IMAGE);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false);
            setData();
            gridControlThietBi.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                setDataObj();
                if (objThietBi.update() != -1)
                {
                    XtraMessageBox.Show("Sửa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enableEdit(false);
                    reLoadListThietBi();
                    
                }
            }
        }

        private void barButtonXoaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] indexCacRow = gridViewThietBi.GetSelectedRows();
            int soluongthietbi = 0;
            String message = "";
            Boolean thanhcong = true;
            for (int i = 0; i < indexCacRow.Count(); i++)
            {
                if (indexCacRow[i] >= 0)
                    soluongthietbi++;
            }
            if (soluongthietbi == 1)
                message = "Bạn có chắc là muốn xóa thiết bị này?";
            else
                message = "Bạn có chắc là xóa những thiết bị đã chọn?";
            if (soluongthietbi > 0)
            {
                if (XtraMessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < indexCacRow.Count(); i++)
                        {
                            if (indexCacRow[i] >= 0)
                            {
                                objThietBi = ThietBi.getById((gridViewThietBi.GetRow(indexCacRow[i]) as ThietBiFilter).idTB);
                                for (int j = 0; j < objThietBi.ctthietbis.Count; j++)
                                {
                                    objThietBi.ctthietbis.ElementAt(j).delete();
                                }
                                objThietBi.delete();
                            }
                        }
                    }
                    catch
                    {
                        thanhcong = false;
                    }
                    finally
                    {}
                    if (thanhcong)
                    {
                        XtraMessageBox.Show("Xóa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        enableEdit(false);
                        reLoadListThietBi();
                    }
                    else
                    {
                        XtraMessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        enableEdit(false);
                        reLoadListThietBi();
                    }
                }
            }
        }

        private void barButtonChonNhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chonnhieu)
            {
                gridViewThietBi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
                gridViewThietBi.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.Default;
            }
            else
            {
                gridViewThietBi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                gridViewThietBi.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            }
            chonnhieu = !chonnhieu;
        }

        private void gridViewThietBi_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int[] indexCacRow = gridViewThietBi.GetSelectedRows();
            int row = 0;
            if (indexCacRow.Count() > 0)
            {
                int rowGroups = 0, rowThietBis = 0;
                for (int i = 0; i < indexCacRow.Count(); i++)
                {
                    if (indexCacRow[i] >= 0)
                    {
                        rowThietBis++;
                        row = indexCacRow[i];
                    }
                    else
                        rowGroups++;
                    if (rowGroups >= 2 && rowThietBis >= 2)
                        break;
                }
                if (rowThietBis == 1)
                {
                    objThietBiFilter = gridViewThietBi.GetRow(row) as ThietBiFilter;
                    objThietBi = ThietBi.getById(objThietBiFilter.idTB);
                    enableEdit(false);
                    setData();
                    barButtonSuaThietBi.Enabled = true;
                    barButtonXoaThietBi.Enabled = true;
                }
                else if (rowThietBis == 0)
                {
                    deleteData();
                    barButtonSuaThietBi.Enabled = false;
                    barButtonXoaThietBi.Enabled = false;
                }
                else
                {
                    deleteData();
                    barButtonSuaThietBi.Enabled = false;
                    barButtonXoaThietBi.Enabled = true;
                }
            }
            else
            {
                barButtonSuaThietBi.Enabled = false;
                barButtonXoaThietBi.Enabled = false;
                deleteData();
            }
        }
    }
}