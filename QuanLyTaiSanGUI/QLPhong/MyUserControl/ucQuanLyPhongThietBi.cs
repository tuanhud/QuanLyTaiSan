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
        List<ChiTietTBHienThi> listCTThietBis = null;
        List<HinhAnh> listHinh = new List<HinhAnh>();
        ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLPhongThietBi");
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();

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
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucTreeLoaiTB);
            _ucTreeLoaiTB.setReadOnly(true);
        }

        // Load dữ liệu
        public void loadData()
        {
            List<LoaiThietBi> listLoai = LoaiThietBi.getAll();
            _ucTreeLoaiTB.loadData(listLoai);
            List<ViTriHienThi> listVitris = ViTriHienThi.getAllHavePhong();
            _ucTreeViTri.loadData(listVitris);
            objPhong = _ucTreeViTri.getPhong();
            gridControlCTThietBi.DataSource = null;
            listCTThietBis = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
            gridControlCTThietBi.DataSource = listCTThietBis;
            editGUI();
        }

        public void setData(int _phongid)
        {
            objPhong = Phong.getById(_phongid);
            gridControlCTThietBi.DataSource = null;
            listCTThietBis = ChiTietTBHienThi.getAllByPhongId(_phongid);
            gridControlCTThietBi.DataSource = listCTThietBis;
            editGUI();
        }

        private void editGUI()
        {
            if (objPhong != null && objPhong.id > 0)
            {
                groupPhong.Text = "Phòng " + objPhong.ten;
                barButtonThemTB.Enabled = true;
            }
            else
            {
                groupPhong.Text = "";
                barButtonThemTB.Enabled = false;
            }
            if (listCTThietBis.Count > 0)
            {
                barButtonSuaTB.Enabled = true;
                barButtonXoaTB.Enabled = true;
                barButtonChuyen.Enabled = true;
            }
            else
            {
                barButtonSuaTB.Enabled = false;
                barButtonXoaTB.Enabled = false;
                barButtonChuyen.Enabled = false;
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

        private void gridViewCTThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                objCTThietBi = CTThietBi.getById(Convert.ToInt32(gridViewCTThietBi.GetRowCellValue(e.FocusedRowHandle, colid)));
                setThongTinThietBi(objCTThietBi);
            }
        }

        private void gridViewCTThietBi_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                objCTThietBi = CTThietBi.getById(Convert.ToInt32(gridViewCTThietBi.GetRowCellValue(e.RowHandle, colid)));
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
                dateMua.DateTime = _obj.thietbi.ngaymua.Value;
                dateLap.DateTime = _obj.thietbi.ngaylap.Value;
                _ucTreeLoaiTB.setLoai(_obj.thietbi.loaithietbi);
                listHinh = _obj.thietbi.hinhanhs.ToList();
                reloadImage();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": setThongTinThietBi :" + ex.Message);
            }
            finally
            { }
        }

        private void reloadImage()
        {
            imageSlider1.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imageSlider1.Images.Add(h.getImage());
            }
        }

        private void gridViewCTThietBi_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewCTThietBi.FocusedRowHandle >= 0)
            {
                objCTThietBi = CTThietBi.getById(Convert.ToInt32(gridViewCTThietBi.GetRowCellValue(gridViewCTThietBi.FocusedRowHandle, colid)));
                setThongTinThietBi(objCTThietBi);
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
            dateMua.Properties.ReadOnly = !_enable;
            dateLap.Properties.ReadOnly = !_enable;
            _ucTreeLoaiTB.setReadOnly(!_enable);
            if (_enable)
            {
                SetTextGroupControl("Sửa thiết bị", true);
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
            }
            enableEdit(false);
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
                obj.ngaymua = dateMua.DateTime;
                obj.ngaylap = dateLap.DateTime;
                obj.hinhanhs = listHinh;
                if (obj.update() > 0)
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
                System.Console.WriteLine(this.Name + ": editObj :" + ex.Message);
            }
            finally
            { }
        }

        private Boolean CheckInput()
        {
            dxErrorProvider.ClearErrors();
            Boolean check = true;
            if (txtTen.Text.Length == 0)
            {
                check = false;
                dxErrorProvider.SetError(txtTen, "Chưa điền tên");
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
                if (XtraMessageBox.Show("Bạn có chắc là muốn loại thiết bị ra khỏi phòng không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (objCTThietBi.delete() > 0)
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
                System.Console.WriteLine(this.Name + " : deleteObj : " + ex.Message);
            }
            finally
            { }
        }

        private void reLoadCTThietBisOnly()
        {
            listCTThietBis = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
            gridControlCTThietBi.DataSource = listCTThietBis;
        }

        private void reLoadCTThietBisOnlyAndFocused(int _id)
        {
            reLoadCTThietBisOnly();
            int rowHandle = gridViewCTThietBi.LocateByValue(colid.FieldName, _id);
            if (rowHandle != GridControl.InvalidRowHandle)
                gridViewCTThietBi.FocusedRowHandle = rowHandle;
        }
    }
}
