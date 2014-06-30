using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyUserControl;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraEditors;
using QuanLyTaiSanGUI.QLThietBi;

namespace QuanLyTaiSanGUI.QLPhong
{
    public partial class frmNewThietBi : Form
    {
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, true);
        ThietBi objThietBi = new ThietBi();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        Boolean checkadd = true;

        List<LoaiThietBi> listLoaiThietBi = null;
        List<PhongHienThi> listPhongFilter = null;
        List<ViTriHienThi> listViTriFilter = null;
        List<TinhTrang> listTinhTrang = null;
        Boolean coThayDoi = false;

        public delegate void SendMessage();
        public SendMessage sendMessage;

        private void RunDelegate()
        {
            sendMessage();
        }

        public frmNewThietBi()
        {
            InitializeComponent();
            loadData();
            
        }

        public void loadData()
        {
            listLoaiThietBi = LoaiThietBi.getAll();
            _ucTreeLoaiTB.loadData(listLoaiThietBi);
            _ucTreeLoaiTB.type = "add";
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelLoaiTB.Controls.Add(_ucTreeLoaiTB);

            //listPhongFilter = PhongHienThi.getAll();//qd
            listViTriFilter = ViTriHienThi.getAllHavePhong();
            _ucComboBoxViTri.loadData(listViTriFilter);
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            _ucComboBoxViTri.setReadOnly(false);
            panelPhong.Controls.Add(_ucComboBoxViTri);

            listTinhTrang = TinhTrang.getAll().OrderBy(i => i.value).ToList();
            lookUpTinhTrang.Properties.DataSource = listTinhTrang;

            setGiaTriDauCho_Phong_LoaiThietBi_TinhTrang();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                objThietBi = new ThietBi();
                setDataObj();
                Boolean thanhcong = false;
                if (checkadd)
                {
                    if (objThietBi.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        thanhcong = true;
                    }
                }
                else
                {
                    if (objThietBi.update() != -1)
                    {
                        XtraMessageBox.Show("Thêm thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        thanhcong = true;
                    }
                }
                if (thanhcong)
                {
                    resetData();
                    coThayDoi = true;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoaiTB_FocusedChanged(bool _loaiChung)
        {
            groupControl1.Visible = !_loaiChung;
            if (!_loaiChung)
            {
                txtSoLuong.Value = 1;
                txtSoLuong.Properties.ReadOnly = true;
                dateEditLap.DateTime = DateTime.Today;
                dateEditMua.DateTime = DateTime.Today;
            }
            else
                txtSoLuong.Properties.ReadOnly = false;
        }

        private Boolean checkInput()
        {
            Boolean check = true;
            errorProvider1.Clear();
            if (_ucComboBoxViTri.getTextPopupContainerEdit().Equals("[Chưa có phòng]"))
            {
                check = false;
                errorProvider1.SetError(panelPhong, "Chưa chọn phòng");
            }
            if (_ucComboBoxViTri.getTextPopupContainerEdit().Equals("[Chưa có loại thiết bị]"))
            {
                check = false;
                errorProvider1.SetError(panelLoaiTB, "Chưa chọn loại thiết bị");
            }
            if (lookUpTinhTrang.EditValue.Equals("Chưa có tình trạng"))
            {
                check = false;
                errorProvider1.SetError(lookUpTinhTrang, "Chưa chọn tình trạng");
            }
            int soluong = Int32.Parse(txtSoLuong.Text);
            if (soluong < 1 || soluong > 1000)
            {
                check = false;
                errorProvider1.SetError(txtSoLuong, "Số lượng từ 1-1000");
            }
            if (groupControl1.Visible)
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

        private void resetData()
        {
            imageSlider1.Images.Clear();
            listHinhAnh = new List<HinhAnh>();
            setGiaTriDauCho_Phong_LoaiThietBi_TinhTrang();
            txtSoLuong.Value = 1;
            if (groupControl1.Visible)
            {
                txtMa.Text = "";
                txtTen.Text = "";
                dateEditLap.DateTime = DateTime.Today;
                dateEditMua.DateTime = DateTime.Today;
                txtMoTa.Text = "";
            }
        }

        private void setGiaTriDauCho_Phong_LoaiThietBi_TinhTrang()
        {
            if (listPhongFilter.Count > 0)
                _ucComboBoxViTri.setPhong(Phong.getById(listPhongFilter.ElementAt(0).id));
            else
                _ucComboBoxViTri.setTextPopupContainerEdit("[Chưa có phòng]");

            if (listLoaiThietBi.Count > 0)
            {
                _ucTreeLoaiTB.setLoai(listLoaiThietBi.ElementAt(0));
                LoaiTB_FocusedChanged(listLoaiThietBi.ElementAt(0).loaichung);
            }
            else
            {
                _ucTreeLoaiTB.setTextPopupContainerEdit("[Chưa có loại thiết bị]");
                groupControl1.Visible = false;
            }

            if (listTinhTrang.Count > 0)
                lookUpTinhTrang.EditValue = listTinhTrang.First().id;
            else
                lookUpTinhTrang.EditValue = "[Chưa có tình trạng]";
        }

        private void setDataObj()
        {
            CTThietBi ctThietBi = new CTThietBi();
            Phong phong = _ucComboBoxViTri.getPhong();
            TinhTrang tinhtrang = (TinhTrang)lookUpTinhTrang.GetSelectedDataRow();

            ctThietBi.phong = phong;
            ctThietBi.tinhtrang = TinhTrang.getById(tinhtrang.id);
            ctThietBi.soluong = Int32.Parse(txtSoLuong.Text);

            LoaiThietBi loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();

            if (groupControl1.Visible)
            {
                objThietBi.hinhanhs = listHinhAnh;

                objThietBi.loaithietbi = loaithietbi;
                objThietBi.ctthietbis.Add(ctThietBi);

                objThietBi.subId = txtMa.Text;
                objThietBi.ten = txtTen.Text;
                objThietBi.ngaymua = dateEditMua.DateTime;
                objThietBi.ngaylap = dateEditLap.DateTime;
                objThietBi.mota = txtMoTa.Text;
                checkadd = true;
            }
            else
            {
                //thiet bi duoc quan li theo so luong
                if (loaithietbi.thietbis.Count > 0)
                {
                    //co
                    objThietBi = ThietBi.getById(loaithietbi.thietbis.ElementAt(0).id);

                    if (listHinhAnh.Count > 0)
                    {
                        foreach (HinhAnh hinhanh in listHinhAnh)
                        {
                            objThietBi.hinhanhs.Add(hinhanh);
                        }
                    }
                    CTThietBi ctThietBiOld = CTThietBi.search(phong, objThietBi, tinhtrang);
                    if (ctThietBiOld == null)
                        objThietBi.ctthietbis.Add(ctThietBi);
                    else
                        ctThietBiOld.soluong += Int32.Parse(txtSoLuong.Text);

                    checkadd = false;
                }
                else
                {
                    //chua co
                    objThietBi.ten = loaithietbi.ten;
                    objThietBi.hinhanhs = listHinhAnh;

                    objThietBi.loaithietbi = loaithietbi;
                    objThietBi.ctthietbis.Add(ctThietBi);
                    checkadd = true;
                }
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            frmHinhAnh frm = new frmHinhAnh(listHinhAnh);
            frm.Text = "Quản lý hình ảnh của thiết bị";
            frm.ShowDialog();
            listHinhAnh = frm.getlistHinhs();
            imageSlider1.Images.Clear();
            if (listHinhAnh.Count > 0)
            {
                foreach (HinhAnh hinhanh in listHinhAnh)
                {
                    imageSlider1.Images.Add(hinhanh.IMAGE);
                }
            }
        }

        private void frmNewThietBi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (coThayDoi)
                RunDelegate();
        }
    }
}