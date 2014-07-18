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
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Libraries;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietThietBi : UserControl
    {
        CTThietBi objCTTB = new CTThietBi();
        List<HinhAnh> listHinh = new List<HinhAnh>();
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();

        public ucChiTietThietBi()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            _ucTreeLoaiTB.setReadOnly(true);
            panelControl1.Controls.Add(_ucTreeLoaiTB);
        }

        public void loadData(List<LoaiThietBi> _list)
        {
            _ucTreeLoaiTB.loadData(_list);
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
                ThietBi obj = objCTTB.thietbi;
                obj.subId = txtMa.Text;
                obj.ten = txtTen.Text;
                obj.mota = txtMoTa.Text;
                obj.loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
                obj.ngaymua = dateMua.DateTime;
                //obj.ngaylap = dateLap.DateTime;
                obj.hinhanhs = listHinh;
                if (obj.update() > 0)
                {
                    XtraMessageBox.Show("Sửa thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.Parent.Parent.Parent != null)
                    {
                        ucQuanLyPhongThietBi _ucQuanLyPhongThietBi = this.Parent.Parent.Parent as ucQuanLyPhongThietBi;
                        //_ucQuanLyPhongThietBi.reLoadThietBiTrongPhong();
                    }
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

        private void reloadImage()
        {
            imageSlider1.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imageSlider1.Images.Add(h.getImage());
            }
        }

        public void setData(CTThietBi _obj)
        {
            try
            {
                objCTTB = _obj;
                txtMa.Text = _obj.thietbi.subId;
                txtTen.Text = _obj.thietbi.ten;
                txtMoTa.Text = _obj.thietbi.mota;
                lblTenPhong.Text = _obj.phong.ten;
                dateMua.DateTime = _obj.thietbi.ngaymua.Value;
                //dateLap.DateTime = _obj.thietbi.ngaylap.Value;
                _ucTreeLoaiTB.setLoai(_obj.thietbi.loaithietbi);
                listHinh = _obj.thietbi.hinhanhs.ToList();
                reloadImage();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": setData :" + ex.Message);
            }
            finally
            { }


        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = new frmHinhAnh(listHinh);
                frm.Text = "Quản lý hình ảnh " + objCTTB.thietbi.ten;
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
            setData(objCTTB);
            enableEdit(false);
        }
    }
}
