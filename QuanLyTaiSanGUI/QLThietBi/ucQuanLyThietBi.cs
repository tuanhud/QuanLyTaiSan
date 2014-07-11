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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Entities;
using DevExpress.XtraGrid;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi : UserControl
    {
        ucQuanLyThietBi_Control _ucQuanLyThietBi_Control = new ucQuanLyThietBi_Control();
        List<ThietBi> listThietBi = new List<ThietBi>();
        List<LoaiThietBi> listLoaiThietBi = new List<LoaiThietBi>();
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();

        ThietBi objThietBi = null;
        LoaiThietBi loaiThietBiNULL = new LoaiThietBi();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        String function = "";
        Boolean loaiChung = true;
        int khoangcach;
        Point pointLabelMota, pointTxtMota, pointBtnOk, pointBtnHuy;
        public bool working = false;
        bool add = false;

        public ucQuanLyThietBi()
        {
            InitializeComponent();
            pointLabelMota = labelControlMoTa.Location;
            pointTxtMota = txtMoTa.Location;
            pointBtnOk = btnOk.Location;
            pointBtnHuy = btnHuy.Location;
            khoangcach = Math.Abs(dateEditNgayMua.Location.Y - txtMoTa.Location.Y);

            init();
        }

        public ucQuanLyThietBi(bool _add)
        {
            InitializeComponent();
            pointLabelMota = labelControlMoTa.Location;
            pointTxtMota = txtMoTa.Location;
            pointBtnOk = btnOk.Location;
            pointBtnHuy = btnHuy.Location;
            khoangcach = Math.Abs(dateEditNgayMua.Location.Y - txtMoTa.Location.Y);
            add = _add;
            init();
        }

        private void init()
        {
            ribbonThietBi.Parent = null;
            _ucQuanLyThietBi_Control.Parent = this;
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
            loaiThietBiNULL.ten = "[Chọn loại thiết bị]";
            loaiThietBiNULL.loaichung = false;
            loaiThietBiNULL.id = -1;
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
            _ucQuanLyThietBi_Control.enable_disableRiengChung(loaiChung);

            listLoaiThietBi = LoaiThietBi.getTheoLoai(loaiChung);
            listLoaiThietBi.Insert(0, loaiThietBiNULL);

            int Y = Math.Abs(pointBtnHuy.Y - khoangcach);
            if (loaiChung)
            {
                labelControlNgayMua.Visible = false;
                dateEditNgayMua.Visible = false;
                labelControlMoTa.Location = labelControlNgayMua.Location;
                txtMoTa.Location = dateEditNgayMua.Location;
                btnOk.Location = new Point(pointBtnOk.X, Y);
                btnHuy.Location = new Point(pointBtnHuy.X, Y);
                gridViewThietBi.Columns.ColumnByName("colngaymua").Visible = false;
            }
            else
            {
                labelControlNgayMua.Visible = true;
                dateEditNgayMua.Visible = true;
                labelControlMoTa.Location = pointLabelMota;
                txtMoTa.Location = pointTxtMota;
                btnOk.Location = pointBtnOk;
                btnHuy.Location = pointBtnHuy;
                gridViewThietBi.Columns.ColumnByName("colngaymua").Visible = true;
            }
            reLoad();
        }

        private void reLoad()
        {
            _ucTreeLoaiTB = new ucTreeLoaiTB();
            _ucTreeLoaiTB.loadData(listLoaiThietBi);
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            _ucTreeLoaiTB.setReadOnly(true);
            panelControlLoaiThietBi.Controls.Clear();
            panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
            if (add && !loaiChung)
                listThietBi = ThietBi.getAllByTypeLoaiNoPhong(loaiChung).ToList();
            else
                listThietBi = ThietBi.getAllByTypeLoai(loaiChung);
            gridControlThietBi.DataSource = listThietBi;
            if (listThietBi.Count() == 0)
            {
                enableEdit(false);
                function = "";
                deleteData();
                btnR_Sua.Enabled = false;
                btnR_Xoa.Enabled = false;
                barButtonSuaThietBi.Enabled = false;
                barButtonXoaThietBi.Enabled = false;
            }
            else
            {
                btnR_Sua.Enabled = true;
                btnR_Xoa.Enabled = true;
                barButtonSuaThietBi.Enabled = true;
                barButtonXoaThietBi.Enabled = true;
            }
        }

        private void reLoadAndFocused(int _id)
        {
            try
            {
                reLoad();
                int rowHandle = gridViewThietBi.LocateByValue(colid.FieldName, _id);
                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    //Do multiselect true
                    gridViewThietBi.ClearSelection();
                    gridViewThietBi.FocusedRowHandle = rowHandle;
                    gridViewThietBi.SelectRow(rowHandle);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : reLoadAndFocused : " + ex.Message);
            }
            finally
            { }
        }

        private void setTextGroupControl(String text, Color color)
        {
            groupControlThietBi.Text = text;
            groupControlThietBi.AppearanceCaption.ForeColor = color;
        }

        private void deleteData()
        {
            setTextGroupControl("Thông tin thiết bị", Color.Black);
            imageSliderThietBi.Images.Clear();
            txtMa.Text = "";
            txtTen.Text = "";
            _ucTreeLoaiTB.setLoai(loaiThietBiNULL);
            if (loaiChung)
            {
                dateEditNgayMua.EditValue = null;
                //dateEditLap.EditValue = null;
            }
            else
            {
                //dateEditLap.DateTime = DateTime.Today;
                dateEditNgayMua.DateTime = DateTime.Today;
            }
            txtMoTa.Text = "";
        }

        private void enableEdit(Boolean _enable)
        {
            btnImage.Visible = _enable;
            btnOk.Visible = _enable;
            btnHuy.Visible = _enable;

            txtMa.Properties.ReadOnly = !_enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;

            working = _enable;

            //rbnGroupThietBi.Enabled = !_enable;
            //btnR_Them.Enabled = !_enable;
            //btnR_Sua.Enabled = !_enable;
            //btnR_Xoa.Enabled = !_enable;

            if (_enable)
            {
                if (loaiChung)
                {
                    dateEditNgayMua.Properties.ReadOnly = loaiChung;
                    //dateEditLap.Properties.ReadOnly = loaiChung;
                }
                else
                {
                    dateEditNgayMua.Properties.ReadOnly = loaiChung;
                    //dateEditLap.Properties.ReadOnly = loaiChung;
                }
            }
            else
            {
                dateEditNgayMua.Properties.ReadOnly = !_enable;
                //dateEditLap.Properties.ReadOnly = !_enable;
            }
            _ucTreeLoaiTB.setReadOnly(!_enable);
        }

        private void setData()
        {
            errorProvider1.Clear();
            if (listThietBi.Count > 0)
            {
                setTextGroupControl("Thông tin thiết bị", Color.Empty);
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

                if (loaiChung)
                {
                    dateEditNgayMua.EditValue = null;
                    //dateEditLap.EditValue = null;
                }
                else
                {
                    dateEditNgayMua.EditValue = objThietBi.ngaymua;
                    //dateEditLap.EditValue = objThietBi.ngaylap;
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

            if (loaiChung)
            {
                objThietBi.ngaymua = null;
                objThietBi.ngaylap = null;
            }
            else
            {
                objThietBi.ngaymua = dateEditNgayMua.DateTime;
                //objThietBi.ngaylap = dateEditLap.DateTime;
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
                        reLoadAndFocused(objThietBi.id);
                    }
                    break;
                case "edit":
                    setDataObj();
                    if (objThietBi.update() != -1)
                    {
                        XtraMessageBox.Show("Sửa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reLoadAndFocused(objThietBi.id);
                    }
                    break;
                case "delete":
                    //Xóa sạch, ko luyến tiếc
                    int[] indexCacRow = gridViewThietBi.GetSelectedRows();
                    String message = "";
                    Boolean thanhcong = true;
                    if (indexCacRow.Count() == 1)
                        message = "Bạn có chắc là xóa thiết bị này?";
                    if (indexCacRow.Count() > 1)
                        message = "Bạn có chắc là xóa những thiết bị đã chọn?";
                    if (indexCacRow.Count() > 0)
                    {
                        if (XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            for (int i = 0; i < indexCacRow.Count(); i++)
                            {
                                try
                                {
                                    objThietBi = gridViewThietBi.GetRow(indexCacRow[i]) as ThietBi;
                                    if (objThietBi.ctthietbis != null)
                                    {
                                        for (int j = 0; j < objThietBi.ctthietbis.Count; j++)
                                        {
                                            objThietBi.ctthietbis.ElementAt(j).delete();
                                        }
                                    }
                                    if (objThietBi.logthietbis != null)
                                    {
                                        for (int j = 0; j < objThietBi.logthietbis.Count; j++)
                                        {
                                            objThietBi.logthietbis.ElementAt(j).delete();
                                        }
                                    }
                                    objThietBi.delete();
                                }
                                catch
                                {
                                    thanhcong = false;
                                }
                            }
                            if (thanhcong)
                            {
                                reLoad();
                                XtraMessageBox.Show("Xóa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                XtraMessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
            }
        }

        private Boolean checkInput()
        {
            Boolean check = true;
            errorProvider1.Clear();
            LoaiThietBi loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
            if (txtTen.Text.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtTen, "Chưa điền tên thiết bị");
            }
            if (loaithietbi == null)
            {
                check = false;
                errorProvider1.SetError(panelControlLoaiThietBi, "Chưa chọn loại thiết bị");
            }
            if (!loaiChung)
            {
                //if (dateEditMua.DateTime > dateEditLap.DateTime)
                //{
                //    check = false;
                //    errorProvider1.SetError(dateEditLap, "Ngày lắp phải lớn hơn ngày mua");
                //}
                if (dateEditNgayMua.EditValue != null)
                {
                    if (dateEditNgayMua.DateTime > DateTime.Today)
                    {
                        check = false;
                        errorProvider1.SetError(dateEditNgayMua, "Ngày mua lớn hơn ngày hiện tại");
                    }
                }
                else
                {
                    check = false;
                    errorProvider1.SetError(dateEditNgayMua, "Ngày mua sai");
                }
                //if (dateEditLap.DateTime > DateTime.Today)
                //{
                //    check = false;
                //    errorProvider1.SetError(dateEditLap, "Ngày lắp lớn hơn ngày hiện tại");
                //}
            }
            else
            {
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
                    //objThietBi = ThietBi.getById((gridViewThietBi.GetRow(row) as ThietBiHienThi).id);
                    objThietBi = gridViewThietBi.GetRow(row) as ThietBi;
                    enableEdit(false);
                    function = "";
                    setData();
                    //barButtonSuaThietBi.Enabled = true;
                    //barButtonXoaThietBi.Enabled = true;
                    //btnR_Sua.Enabled = true;
                    //btnR_Xoa.Enabled = true;
                    enableAllBarButton(true);
                }
                else if (rowThietBis == 0)
                {
                    deleteData();
                    //barButtonSuaThietBi.Enabled = false;
                    //barButtonXoaThietBi.Enabled = false;
                    //btnR_Sua.Enabled = false;
                    //btnR_Xoa.Enabled = false;
                    enableAllBarButton(true);
                }
                else
                {
                    deleteData();
                    //barButtonSuaThietBi.Enabled = false;
                    //barButtonXoaThietBi.Enabled = true;
                    //btnR_Sua.Enabled = false;
                    //btnR_Xoa.Enabled = true;
                    enableAllBarButton(true);
                }
            }
            else
            {
                //barButtonSuaThietBi.Enabled = false;
                //barButtonXoaThietBi.Enabled = false;
                //btnR_Sua.Enabled = false;
                //btnR_Xoa.Enabled = false;
                enableAllBarButton(true);
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
            int[] indexCacRow = gridViewThietBi.GetSelectedRows();
            if (indexCacRow.Count() == 1)
                setData();
            else
                deleteData();
            enableAllBarButton(true);
            gridControlThietBi.Focus();
        }

        private void barButtonThemThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true);
            function = "add";
            listHinhAnh = new List<HinhAnh>();
            deleteData();
            enableAllBarButton(false);
            txtMa.Focus();
            setTextGroupControl("Thêm thiết bị", Color.Red);
            if (loaiChung)
            {
                dateEditNgayMua.TabIndex = 99;
                //dateEditLap.TabIndex = 100;
            }
            else
            {
                dateEditNgayMua.TabIndex = 5;
                //dateEditLap.TabIndex = 6;
            }
        }

        private void barButtonSuaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true);
            function = "edit";

            setData();
            enableAllBarButton(false);
            setTextGroupControl("Sửa thiết bị", Color.Red);
            if (loaiChung)
            {
                dateEditNgayMua.TabIndex = 99;
                //dateEditLap.TabIndex = 100;
            }
            else
            {
                dateEditNgayMua.TabIndex = 5;
                //dateEditLap.TabIndex = 6;
            }
        }

        private void barButtonXoaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            function = "delete";
            CRUD();
            gridControlThietBi.Focus();
        }

        private void btnR_Them_Click(object sender, EventArgs e)
        {
            enableEdit(true);
            function = "add";
            listHinhAnh = new List<HinhAnh>();
            deleteData();
            enableAllBarButton(false);
            txtMa.Focus();
            setTextGroupControl("Thêm thiết bị", Color.Red);
            if (loaiChung)
            {
                dateEditNgayMua.TabIndex = 99;
                //dateEditLap.TabIndex = 100;
            }
            else
            {
                dateEditNgayMua.TabIndex = 5;
                //dateEditLap.TabIndex = 6;
            }
        }

        private void btnR_Sua_Click(object sender, EventArgs e)
        {
            enableEdit(true);
            function = "edit";

            setData();
            enableAllBarButton(false);
            setTextGroupControl("Sửa thiết bị", Color.Red);
            if (loaiChung)
            {
                dateEditNgayMua.TabIndex = 99;
                //dateEditLap.TabIndex = 100;
            }
            else
            {
                dateEditNgayMua.TabIndex = 5;
                //dateEditLap.TabIndex = 6;
            }
        }

        private void btnR_Xoa_Click(object sender, EventArgs e)
        {
            function = "delete";
            CRUD();
            gridControlThietBi.Focus();
        }

        public ThietBi getThietBi()
        {
            if (!txtTen.Text.Equals(""))
                return objThietBi;
            else
                return null;
        }

        private void enableAllBarButton(Boolean _enable)
        {
            if (_enable)
            {
                int[] indexCacRow = gridViewThietBi.GetSelectedRows();
                if (indexCacRow.Count() > 0)
                {
                    rbnGroupThietBi.Enabled = _enable;
                    barButtonThemThietBi.Enabled = _enable;
                    barButtonXoaThietBi.Enabled = _enable;

                    btnR_Them.Enabled = _enable;
                    btnR_Xoa.Enabled = _enable;
                    if (indexCacRow.Count() > 1)
                    {
                        barButtonSuaThietBi.Enabled = !_enable;
                        btnR_Sua.Enabled = !_enable;
                    }
                    else
                    {
                        barButtonSuaThietBi.Enabled = _enable;
                        btnR_Sua.Enabled = _enable;
                    }
                }
                else
                {
                    rbnGroupThietBi.Enabled = _enable;
                    barButtonThemThietBi.Enabled = _enable;
                    barButtonSuaThietBi.Enabled = !_enable;
                    barButtonXoaThietBi.Enabled = !_enable;

                    btnR_Them.Enabled = _enable;
                    btnR_Sua.Enabled = !_enable;
                    btnR_Xoa.Enabled = !_enable;
                }
            }
            else
            {
                rbnGroupThietBi.Enabled = _enable;
                btnR_Them.Enabled = _enable;
                btnR_Sua.Enabled = _enable;
                btnR_Xoa.Enabled = _enable;
            }
        }
    }
}
