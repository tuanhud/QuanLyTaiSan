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
using QuanLyTaiSanGUI.MyForm;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi : UserControl
    {
        ucTreeViTri _ucTreeViTri = null;
        ucComboBoxViTri _ucComboBoxViTri = null;
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();

        List<ViTriHienThi> listViTriHienThi = null;
        List<ThietBiFilter> listThietBiFilter = null;
        List<LoaiThietBi> listLoaiThietBi = null;

        ThietBi objThietBi = new ThietBi();
        ThietBiFilter objThietBiFilter = new ThietBiFilter();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        String function = "";

        public ucQuanLyThietBi()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            ribbonThietBi.Parent = null;
            listViTriHienThi = new ViTriHienThi().getAllHavePhong();
            //Xủ lí nếu chưa có cơ sở, dãy, tầng và phòng !!!!!!!!!!!!!!
            //Chưa làm

            _ucTreeViTri = new ucTreeViTri(listViTriHienThi, "QLThietBi");
            _ucTreeViTri.Parent = this;

            listLoaiThietBi = new LoaiThietBi().getAll().OrderBy(i => i.ten).ToList();
            _ucTreeLoaiTB.loadData(listLoaiThietBi);
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            _ucTreeLoaiTB.setReadOnly(true);
            panelControlLoaiThietBi.Controls.Clear();
            panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
            _ucTreeLoaiTB.Visible = false;

            _ucComboBoxViTri = new ucComboBoxViTri(false, true);
            _ucComboBoxViTri.loadData(listViTriHienThi);
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            _ucComboBoxViTri.setReadOnly(true);
            panelControlPhong.Controls.Clear();
            panelControlPhong.Controls.Add(_ucComboBoxViTri);
            _ucComboBoxViTri.Visible = false;

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
                listThietBiFilter = new ThietBiFilter().getAllBy4Id(-1, idCoSo, idDay, idTang);
            }
            else
                listThietBiFilter = new List<ThietBiFilter>();
            gridControlThietBi.DataSource = listThietBiFilter;
        }

        private void deleteData()
        {
            imageSlider1.Images.Clear();
            txtMa.Text = "";
            txtTen.Text = "";
            _ucComboBoxViTri.Visible = false;
            _ucTreeLoaiTB.Visible = false;
            dateMua.EditValue = null;
            dateLap.EditValue = null;
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
                    dateMua.Properties.ReadOnly = true;
                    dateLap.Properties.ReadOnly = true;

                }
                else
                {
                    txtMa.Properties.ReadOnly = false;
                    txtTen.Properties.ReadOnly = false;
                    txtMoTa.Properties.ReadOnly = false;
                    dateMua.Properties.ReadOnly = false;
                    dateLap.Properties.ReadOnly = false;
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
                dateMua.Properties.ReadOnly = true;
                dateLap.Properties.ReadOnly = true;
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
            }
            return check;
        }

        public void setData(int phongid, int cosoid, int dayid, int tangid)
        {
            listThietBiFilter = new ThietBiFilter().getAllBy4Id(phongid, cosoid, dayid, tangid);
            gridControlThietBi.DataSource = listThietBiFilter;
        }

        private void setData()
        {
            if (listThietBiFilter.Count > 0)
            {
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
                _ucComboBoxViTri.setPhong(new Phong().getById(objThietBiFilter.phong_id));
                _ucTreeLoaiTB.Visible = true;
                _ucComboBoxViTri.Visible = true;

                txtMa.Text = objThietBi.subId;
                dateMua.EditValue = objThietBi.ngaymua;
                dateLap.EditValue = objThietBi.ngaylap;
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
                objThietBi.ngaylap = null;
            }
            else
            {
                objThietBi.ngaymua = dateMua.DateTime;
                objThietBi.ngaylap = dateLap.DateTime;
            }
            objThietBi.mota = txtMoTa.Text;
        }

        private void barButtonThemThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNewThietBi frm = new frmNewThietBi();
            frm.sendMessage = new frmNewThietBi.SendMessage(reLoadListThietBi);
            frm.ShowDialog();
        }

        private void gridViewThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int row = gridViewThietBi.FocusedRowHandle;
            if (row >= 0)
            {
                //objThietBi = new ThietBi().getById(Convert.ToInt32(gridViewThietBi.GetFocusedRowCellValue(colidTB)));
                objThietBiFilter = gridViewThietBi.GetFocusedRow() as ThietBiFilter;
                objThietBi = new ThietBi().getById(objThietBiFilter.idTB);
                enableEdit(false);
                setData();
                barButtonSuaThietBi.Enabled = true;
                barButtonXoaThietBi.Enabled = true;
            }
            else
            {
                deleteData();
                barButtonSuaThietBi.Enabled = false;
                barButtonXoaThietBi.Enabled = false;
            }
        }

        private void barButtonSuaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            frmHinhAnh frm = new frmHinhAnh(listHinhAnh);
            frm.Text = "Quản lý hình ảnh " + objThietBi.ten;
            frm.ShowDialog();
            listHinhAnh = frm.getlistHinhs();
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
                    setData();
                }
            }
        }

        private void barButtonXoaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (int i = 0; i < objThietBi.ctthietbis.Count; i++)
                {
                    objThietBi.ctthietbis.ElementAt(i).delete();
                }
                if (objThietBi.delete() != -1)
                {
                    XtraMessageBox.Show("Xóa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enableEdit(false);
                    reLoadListThietBi();
                }
            }
        }
    }
}