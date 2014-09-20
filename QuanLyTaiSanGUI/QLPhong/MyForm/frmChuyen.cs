using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PTB.DataFilter;
using PTB.Entities;
using PTB_GUI.MyUC;
using SHARED.Libraries;

namespace PTB_GUI.QLPhong
{
    public partial class frmChuyen : DevExpress.XtraEditors.XtraForm
    {
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, true);
        CTThietBi objCTThietBi = null;
        List<HinhAnh> listHinh = null;
        public frmChuyen()
        {
            InitializeComponent();
            init();
            loadData();
        }

        private void init()
        {
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucComboBoxViTri);
            listHinh = new List<HinhAnh>();
            _ucComboBoxViTri.ReadOnly = true;
        }

        public frmChuyen(CTThietBi obj)
        {
            InitializeComponent();
            init();
            loadData();
            setData(obj);
        }

        public void loadData()
        {
            List<ViTriHienThi> listViTriHienThi = ViTriHienThi.getAllHavePhong();
            _ucComboBoxViTri.DataSource = listViTriHienThi;
            List<TinhTrang> listTinhTrang = TinhTrang.getAllForTHIETBI();
            lookUpTinhTrang.Properties.DataSource = listTinhTrang;
        }

        public void setData(CTThietBi obj)
        {
            objCTThietBi = obj;
            lblMa.Text = obj.thietbi.subId;
            lblTen.Text = obj.thietbi.ten;
            lblLoai.Text = obj.thietbi.loaithietbi.ten;
            lblPhong.Text = obj.phong.ten;
            lblTinhTrang.Text = obj.tinhtrang.value;
            lblSoLuong.Text = obj.soluong.ToString();
            lookUpTinhTrang.EditValue = obj.tinhtrang_id;
            txtSoLuong.Properties.MaxValue = obj.soluong;
        }

        private void setTextGroup(bool p)
        {
            if (p)
                groupControl2.Text = "Chuyển phòng";
            else
                groupControl2.Text = "Chuyển tình trạng";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioBtnChuyenPhong_CheckedChanged(object sender, EventArgs e)
        {
            _ucComboBoxViTri.ReadOnly = !radioBtnChuyenPhong.Checked;
            setTextGroup(radioBtnChuyenPhong.Checked);
        }

        private void radioBtnChuyenTinhTrang_CheckedChanged(object sender, EventArgs e)
        {
            _ucComboBoxViTri.ReadOnly = radioBtnChuyenTinhTrang.Checked;
            setTextGroup(radioBtnChuyenTinhTrang.Checked);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    if (radioBtnChuyenPhong.Checked)
                    {

                        if (objCTThietBi.dichuyen(_ucComboBoxViTri.Phong, (TinhTrang)lookUpTinhTrang.GetSelectedDataRow(), Convert.ToInt32(txtSoLuong.Text), txtGhiChu.Text, listHinh) > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Chuyển phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }
                    else
                    {
                        if (objCTThietBi.dichuyen(null, (TinhTrang)lookUpTinhTrang.GetSelectedDataRow(), Convert.ToInt32(txtSoLuong.Text), txtGhiChu.Text, listHinh) > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Chuyển tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_Click:" + ex.Message);
            }
        }

        private Boolean CheckInput()
        {
            dxErrorProvider1.ClearErrors();
            if (radioBtnChuyenPhong.Checked && _ucComboBoxViTri.Phong == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
                //dxErrorProvider1.SetError(_ucComboBoxViTri, "Bạn chưa chọn phòng");
            }
            else if (radioBtnChuyenPhong.Checked && _ucComboBoxViTri.Phong.Equals(objCTThietBi.phong))
            {
                XtraMessageBox.Show("Phòng được chuyển đến phải khác phòng cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
                //dxErrorProvider1.SetError(_ucComboBoxViTri, "Phòng được chuyển đến phải khác phòng cũ");
            }
            else if (!radioBtnChuyenPhong.Checked && ((TinhTrang)lookUpTinhTrang.GetSelectedDataRow()).Equals(objCTThietBi.tinhtrang))
            {
                XtraMessageBox.Show("Tình trạng được chuyển phải khác tình trạng cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
                //dxErrorProvider1.SetError(lookUpTinhTrang, "Tình trạng được chuyển phải khác tình trạng cũ");
            }
            return true;
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
                Debug.WriteLine(this.Name + "->btnImage_Click :" + ex.Message);
            }
        }

        private void reloadImage()
        {
            try
            {
                imageSlider1.Images.Clear();
                foreach (HinhAnh h in listHinh)
                {
                    imageSlider1.Images.Add(h.getImage());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadImage :" + ex.Message);
            }
            finally
            { }
        }

        private void imageSlider1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listHinh != null && listHinh.Count > 0)
            {
                frmShowImage frm = new frmShowImage(listHinh);
                frm.ShowDialog();
            }
        }
    }
}
