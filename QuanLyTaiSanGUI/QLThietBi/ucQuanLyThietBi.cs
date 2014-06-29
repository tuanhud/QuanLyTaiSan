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
        List<LoaiThietBi> listLoaiThietBi = new List<LoaiThietBi>();
        List<LoaiThietBi> listLoaiThietBiChungKhongCoCTTB = new List<LoaiThietBi>();
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();

        ThietBi objThietBi = null;
        LoaiThietBi loaiThietBiNULL = new LoaiThietBi();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        String function = "";
        Boolean loaiChung = true;

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
            loaiChung = _loaichung;
            //Cái quỉ này phải có trước
            listLoaiThietBi = LoaiThietBi.getTheoLoai(_loaichung);
            loaiThietBiNULL.ten = "[Không thuộc loại nào]";
            loaiThietBiNULL.loaichung = false;
            loaiThietBiNULL.id = -1;
            listLoaiThietBi.Insert(0, loaiThietBiNULL);
            _ucTreeLoaiTB.loadData(listLoaiThietBi);

            listThietBiHienThi = ThietBiHienThi.getAllByTypeLoai(_loaichung);
            gridControlThietBi.DataSource = listThietBiHienThi;
        }

        private void reLoad()
        {
            listThietBiHienThi = ThietBiHienThi.getAllByTypeLoai(loaiChung);
            gridControlThietBi.DataSource = listThietBiHienThi;
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
            _ucTreeLoaiTB.setLoai(loaiThietBiNULL);
            if (loaiChung)
            {
                dateEditMua.EditValue = null;
                dateEditLap.EditValue = null;
            }
            else
            {
                dateEditLap.DateTime = DateTime.Today;
                dateEditMua.DateTime = DateTime.Today;
            }
            txtMoTa.Text = "";
        }

        private void enableEdit(Boolean _enable)
        {
            if (_enable)
            {
                btnImage.Visible = true;
                btnOk.Visible = true;
                btnHuy.Visible = true;

                txtMa.Properties.ReadOnly = false;
                txtTen.Properties.ReadOnly = false;
                txtMoTa.Properties.ReadOnly = false;
                if (loaiChung)
                {
                    dateEditMua.Properties.ReadOnly = true;
                    dateEditLap.Properties.ReadOnly = true;
                }
                else
                {
                    dateEditMua.Properties.ReadOnly = false;
                    dateEditLap.Properties.ReadOnly = false;
                }
                _ucTreeLoaiTB.setReadOnly(false);
                //if (objThietBi.loaithietbi.loaichung)
                //{
                //    dateEditMua.Properties.ReadOnly = true;
                //    dateEditLap.Properties.ReadOnly = true;
                //}
                //else
                //{
                //    dateEditMua.Properties.ReadOnly = false;
                //    dateEditLap.Properties.ReadOnly = false;
                //}
                //if (objThietBi.ctthietbis != null)
                //{
                //    if (objThietBi.ctthietbis.Count > 0)
                //        _ucTreeLoaiTB.setReadOnly(false);
                //}
                //else
                //    _ucTreeLoaiTB.setReadOnly(true);
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


                if (objThietBi.loaithietbi.loaichung)
                {
                    dateEditMua.EditValue = null;
                    dateEditLap.EditValue = null;
                }
                else
                {
                    dateEditMua.EditValue = objThietBi.ngaymua;
                    dateEditLap.EditValue = objThietBi.ngaylap;
                }
                
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
                    objThietBi = new ThietBi();
                    setDataObj();
                    if (objThietBi.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                        
                    }
                    break;
                case "edit":
                    setDataObj();
                    if (objThietBi.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoad();
                    }
                    break;
                case "delete":
                    //Xóa sạch, ko luyến tiếc
                    if (XtraMessageBox.Show("Bạn có chắc là xóa thiết bị này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objThietBi.ctthietbis != null)
                        {
                            for (int i = 0; i < objThietBi.ctthietbis.Count; i++)
                            {
                                objThietBi.ctthietbis.ElementAt(i).delete();
                            }
                        }
                        if (objThietBi.logthietbis != null)
                        {
                            for (int i = 0; i < objThietBi.logthietbis.Count; i++)
                            {
                                objThietBi.logthietbis.ElementAt(i).delete();
                            }
                        }
                        if (objThietBi.delete() != -1)
                        {
                            XtraMessageBox.Show("Xóa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reLoad();
                        }
                    }
                    break;
            }
        }

        private Boolean checkInput()
        {
            Boolean check = true;
            errorProvider1.Clear();
            if (txtTen.Text.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtTen, "Chưa điền tên thiết bị");
            }
            if (!objThietBi.loaithietbi.loaichung)
            {
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
            else
            {
                LoaiThietBi loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
                if (loaithietbi != null)
                {
                    if (function.Equals("edit"))
                    {
                        if (loaithietbi.id != objThietBi.loaithietbi.id && loaithietbi.thietbis.Count > 0)
                        {
                            check = false;
                            errorProvider1.SetError(panelControlLoaiThietBi, "Đã có thiết bị thuộc loại này");
                        }
                    }
                    else if (loaithietbi.thietbis.Count > 0)
                    {
                        check = false;
                        errorProvider1.SetError(panelControlLoaiThietBi, "Đã có thiết bị thuộc loại này");
                    }
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
                    objThietBi = ThietBi.getById((gridViewThietBi.GetRow(row) as ThietBiHienThi).id);
                    enableEdit(false);
                    function = "";
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
            enableEdit(false);
            function = "";
            setData();
            gridControlThietBi.Focus();
        }

        private void barButtonThemThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true);
            function = "add";
            
            deleteData();
            txtMa.Focus();
            setTextGroupControl("Thêm thiết bị", Color.Red);
            if (loaiChung)
            {
                dateEditMua.TabIndex = 99;
                dateEditLap.TabIndex = 100;
            }
            else
            {
                dateEditMua.TabIndex = 5;
                dateEditLap.TabIndex = 6;
            }
        }

        private void barButtonSuaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true);
            function = "edit";
            
            setData();
            setTextGroupControl("Sửa thiết bị", Color.Red);
            if (loaiChung)
            {
                dateEditMua.TabIndex = 99;
                dateEditLap.TabIndex = 100;
            }
            else
            {
                dateEditMua.TabIndex = 5;
                dateEditLap.TabIndex = 6;
            }
        }

        private void barButtonXoaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            function = "delete";
            CRUD();
        }

        private void gridControlThietBi_DataSourceChanged(object sender, EventArgs e)
        {
            //if (gridControlThietBi.DataSource != null)
            //{
            //    if ((gridControlThietBi.DataSource as List<ThietBiHienThi>).Count == 0)
            //    {
            //        deleteData();
            //        barButtonSuaThietBi.Enabled = false;
            //        barButtonXoaThietBi.Enabled = false;
            //    }
            //}
        }
    }
}
