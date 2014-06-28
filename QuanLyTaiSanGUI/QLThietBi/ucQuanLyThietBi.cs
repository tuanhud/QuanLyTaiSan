using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi : UserControl
    {
        ucQuanLyThietBi_Control _ucQuanLyThietBi_Control = new ucQuanLyThietBi_Control();
        List<ThietBiHienThi> listThietBiHienThi = new List<ThietBiHienThi>();
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();

        ThietBi objThietBi = null;
        LoaiThietBi loaiThietBiNULL = new LoaiThietBi();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        String function = "";

        public ucQuanLyThietBi()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ribbonThietBi.Parent = null;
            _ucQuanLyThietBi_Control.Parent = this;
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
        }

        public PanelControl getControl()
        {
            return _ucQuanLyThietBi_Control.getControl();
        }

        public RibbonControl getRibbon()
        {
            return ribbonThietBi;
        }

        public void loadData(bool _loaichung)
        {
            listThietBiHienThi = new ThietBiHienThi().getAllByTypeLoai(_loaichung);
            gridControlThietBi.DataSource = listThietBiHienThi;
            List<LoaiThietBi> listLoaiThietBi = new LoaiThietBi().getAll();
            loaiThietBiNULL.ten = "[Không thuộc loại nào]";
            loaiThietBiNULL.loaichung = false;
            loaiThietBiNULL.id = -1;
            //listLoaiThietBi.Insert(0, loaiThietBiNULL);
            _ucTreeLoaiTB.loadData(listLoaiThietBi);
        }

        private void setTextGroupControl(String text, Color color)
        {
            groupControlThietBi.Text = text;
            groupControlThietBi.AppearanceCaption.ForeColor = color;
        }

        private void deleteData()
        {
            setTextGroupControl("Chi tiết thiết bị", Color.Black);
            imageSliderThietBi.Images.Clear();
            txtMa.Text = "";
            txtTen.Text = "";
            _ucTreeLoaiTB.Visible = false;
            dateEditMua.EditValue = null;
            dateEditLap.EditValue = null;
            txtMoTa.Text = "";
        }

        private void enableEdit(Boolean _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnImage.Visible = true;
                btnOk.Visible = true;
                btnHuy.Visible = true;

                txtMa.Properties.ReadOnly = false;
                txtTen.Properties.ReadOnly = false;
                txtMoTa.Properties.ReadOnly = false;
                dateEditMua.Properties.ReadOnly = false;
                dateEditLap.Properties.ReadOnly = false;
                if (objThietBi.ctthietbis != null)
                {
                    if (objThietBi.ctthietbis.Count > 0)
                        _ucTreeLoaiTB.setReadOnly(false);
                }
                else
                    _ucTreeLoaiTB.setReadOnly(true);
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
                dateEditMua.Properties.ReadOnly = true;
                dateEditLap.Properties.ReadOnly = true;
            }
        }

        private void setData()
        {
            errorProvider1.Clear();
            if (listThietBiHienThi.Count > 0)
            {
                setTextGroupControl("Chi tiết thiết bị", Color.Black);
                imageSliderThietBi.Images.Clear();
                if (objThietBi.hinhanhs != null)
                {
                    if (objThietBi.hinhanhs.Count > 0)
                    {
                        foreach (HinhAnh hinhanh in objThietBi.hinhanhs)
                        {
                            imageSliderThietBi.Images.Add(hinhanh.IMAGE);
                        }
                    }
                }
                listHinhAnh = objThietBi.hinhanhs.ToList();

                txtMa.Text = objThietBi.subId;
                txtTen.Text = objThietBi.ten;
                _ucTreeLoaiTB.setLoai(objThietBi.loaithietbi);
                _ucTreeLoaiTB.Visible = true;
                dateEditMua.EditValue = objThietBi.ngaymua;
                dateEditLap.EditValue = objThietBi.ngaylap;
                txtMoTa.Text = objThietBi.mota;
            }
            else
                deleteData();
        }

        private void setDataObj()
        {
            objThietBi.hinhanhs = listHinhAnh;

            objThietBi.subId = txtMa.Text;
            objThietBi.ten = txtTen.Text;
            objThietBi.loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();

            if (objThietBi.loaithietbi.loaichung)
            {
                objThietBi.ngaymua = null;
                objThietBi.ngaylap = null;
            }
            else
            {
                objThietBi.ngaymua = dateEditMua.DateTime;
                objThietBi.ngaylap = dateEditLap.DateTime;
            }
            objThietBi.mota = txtMoTa.Text;
        }

        private void CRUD()
        {
            switch (function)
            {
                case "add":
                    setDataObj();
                    XtraMessageBox.Show("them");
                    break;
                case "edit":
                    XtraMessageBox.Show("sua");
                    setDataObj();
                    break;
                case "delete":
                    XtraMessageBox.Show("xoa");
                    break;
            }
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

        private void gridViewThietBi_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int[] indexCacRow = gridViewThietBi.GetSelectedRows();
            int row = 0;
            if (indexCacRow.Count() > 0)
            {
                int rowThietBis = 0;
                for (int i = 0; i < indexCacRow.Count(); i++)
                {
                    if (indexCacRow[i] >= 0)
                    {
                        rowThietBis++;
                        row = indexCacRow[i];
                    }
                    if (rowThietBis >= 2)
                        break;
                }
                if (rowThietBis == 1)
                {
                    objThietBi = new ThietBi().getById((gridViewThietBi.GetRow(row) as ThietBiHienThi).id);
                    enableEdit(false, "");
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

        private void btnImage_Click(object sender, EventArgs e)
        {
            frmHinhAnh frm = new frmHinhAnh(listHinhAnh);
            frm.Text = "Quản lý hình ảnh " + objThietBi.ten;
            frm.ShowDialog();
            listHinhAnh = frm.getlistHinhs();
            imageSliderThietBi.Images.Clear();
            if (listHinhAnh.Count > 0)
            {
                foreach (HinhAnh hinhanh in listHinhAnh)
                {
                    imageSliderThietBi.Images.Add(hinhanh.IMAGE);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                CRUD();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false, "");
            setData();
            gridControlThietBi.Focus();
        }

        private void barButtonThemThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "add");
            setTextGroupControl("Thêm thiết bị", Color.Red);
            txtTen.Focus();
        }

        private void barButtonSuaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
            setTextGroupControl("Sửa thiết bị", Color.Red);
            setData();
        }

        private void barButtonXoaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            function = "delete";
            CRUD();
        }

        private void gridControlThietBi_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridControlThietBi.DataSource != null)
            {
                if ((gridControlThietBi.DataSource as List<ThietBiHienThi>).Count == 0)
                {
                    deleteData();
                    barButtonSuaThietBi.Enabled = false;
                    barButtonXoaThietBi.Enabled = false;
                }
            }
        }
    }
}
