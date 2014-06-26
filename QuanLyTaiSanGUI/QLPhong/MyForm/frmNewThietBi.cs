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

namespace QuanLyTaiSanGUI.MyForm
{
    public partial class frmNewThietBi : Form
    {
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();
        ucTreeViTri _ucTreeViTri = new ucTreeViTri(false, true);
        ThietBi objThietBi = new ThietBi();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        Boolean checkadd = true;

        List<LoaiThietBi> listLoaiThietBi = null;
        List<PhongFilter> listPhongFilter = null;
        List<ViTriFilter> listViTriFilter = null;
        List<TinhTrang> listTinhTrang = null;

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
            listLoaiThietBi = new LoaiThietBi().getAll();
            _ucTreeLoaiTB.loadData(listLoaiThietBi);
            _ucTreeLoaiTB.type = "add";
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelLoaiTB.Controls.Add(_ucTreeLoaiTB);
            


            listPhongFilter = new PhongFilter().getAll();
            listViTriFilter = new ViTriFilter().getAllHavePhong();
            _ucTreeViTri.loadData(listViTriFilter);
            _ucTreeViTri.Dock = DockStyle.Fill;
            _ucTreeViTri.setReadOnly(false);
            panelPhong.Controls.Add(_ucTreeViTri);



            listTinhTrang = new TinhTrang().getAll().OrderBy(i => i.value).ToList();
            lookUpTinhTrang.Properties.DataSource = listTinhTrang;

            setGiaTriDauCho_Phong_LoaiThietBi_TinhTrang();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (true)
            {
                objThietBi = new ThietBi();
                setDataObj();
                Boolean thanhcong = false;
                if(checkadd)
                {
                    if(objThietBi.add() != -1)
                    {
                        XtraMessageBox.Show("Thêm thiết bị thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        thanhcong = true;
                    }
                }
                else
                {
                    if(objThietBi.update() != -1)
                    {
                        XtraMessageBox.Show("Thêm thiết bị thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        thanhcong = true;
                    }
                }
                if (thanhcong)
                {
                    resetData();
                    
                }
                
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
            RunDelegate();
        }

        public void LoaiTB_FocusedChanged(bool _loaiChung)
        {
            //if (groupControl1.Visible)
            //{
            //    if (_loaiChung)
            //    {
            //        txtMa.Text = "";
            //        txtTen.Text = "";
            //        dateEditLap.DateTime = DateTime.Today;
            //        dateEditMua.DateTime = DateTime.Today;
            //        txtMoTa.Text = "";
            //    }
            //}
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
            if (listHinhAnh.Count == 0)
            {
                check = false;
                errorProvider1.SetError(imageSlider1, "Cần ít nhất 1 hình");
            }
            if (_ucTreeViTri.getTextPopupContainerEdit().Equals("[Chưa có phòng]"))
            {
                check = false;
                errorProvider1.SetError(panelPhong, "Chưa chọn phòng");
            }
            if (_ucTreeViTri.getTextPopupContainerEdit().Equals("[Chưa có loại thiết bị]"))
            {
                check = false;
                errorProvider1.SetError(panelLoaiTB, "Chưa chọn loại thiết bị");
            }
            if (lookUpTinhTrang.EditValue.Equals("Chưa có tình trạng"))
            {
                check = false;
                errorProvider1.SetError(lookUpTinhTrang, "Chưa chọn tình trạng");
            }
            if (Int32.Parse(txtSoLuong.Text) > 0)
            {
                check = false;
                errorProvider1.SetError(txtSoLuong, "Số lượng > 0");
            }
            if (groupControl1.Visible)
            {
                if (txtMa.Text.Length == 0)
                {
                    check = false;
                    errorProvider1.SetError(txtMa, "Chưa điền mã thiết bị");
                }
                if (txtTen.Text.Length == 0)
                {
                    check = false;
                    errorProvider1.SetError(txtTen, "Chưa điền tên thiết bị");
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
                groupControl1.Visible = false;
            }
        }

        private void setGiaTriDauCho_Phong_LoaiThietBi_TinhTrang()
        {
            if (listPhongFilter.Count > 0)
                _ucTreeViTri.setPhong(new Phong().getById(listPhongFilter.ElementAt(0).id));
            else
                _ucTreeViTri.setTextPopupContainerEdit("[Chưa có phòng]");

            if (listLoaiThietBi.Count > 0)
                _ucTreeLoaiTB.setLoai(listLoaiThietBi.ElementAt(0));
            else
                _ucTreeLoaiTB.setTextPopupContainerEdit("[Chưa có loại thiết bị]");

            if (listTinhTrang.Count > 0)
                lookUpTinhTrang.EditValue = listTinhTrang.First().id;
            else
                lookUpTinhTrang.EditValue = "[Chưa có tình trạng]";
        }

        private void setDataObj()
        {
            //add chi tiet thiet bi cho thiet bi nay
            CTThietBi ctThietBi = new CTThietBi();
            Phong phong = _ucTreeViTri.getPhong();
            TinhTrang tinhtrang = (TinhTrang)lookUpTinhTrang.GetSelectedDataRow();

            ctThietBi.phong = phong;
            ctThietBi.tinhtrang = new TinhTrang().getById(tinhtrang.id);
            ctThietBi.soluong = Int32.Parse(txtSoLuong.Text);


            LoaiThietBi loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
            //add

            if (groupControl1.Visible)
            {
                objThietBi.hinhanhs = listHinhAnh;

                //loai thiet bi
                //objThietBi.loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
                objThietBi.loaithietbi = loaithietbi;
                objThietBi.ctthietbis.Add(ctThietBi);
                ////phong, tinh trang, soluong
                //CTThietBi ctThietBi = new CTThietBi();
                //ctThietBi.phong = _ucTreeViTri.getPhong();
                //TinhTrang tinhtrang = (TinhTrang)lookUpTinhTrang.GetSelectedDataRow();
                //ctThietBi.tinhtrang = new TinhTrang().getById(tinhtrang.id);
                //ctThietBi.soluong = Int32.Parse(txtSoLuong.Text);

                objThietBi.subId = txtMa.Text;
                objThietBi.ten = txtTen.Text;
                objThietBi.ngaymua = dateEditMua.DateTime;
                objThietBi.ngaylap = dateEditLap.DateTime;
                objThietBi.mota = txtMoTa.Text;
                checkadd = true;
            }
            else
            {
                //thiet bi o day duoc quan li theo so luong
                //LoaiThietBi loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
                //co thiet bi do chua
                if (loaithietbi.thietbis.Count > 0)
                {
                    //co
                    //tim thiet bi do
                    objThietBi = new ThietBi().getById(loaithietbi.thietbis.ElementAt(0).id);
                    //add them hinh anh moi vao list anh cua thiet bi
                    if (listHinhAnh.Count > 0)
                    {
                        foreach (HinhAnh hinhanh in listHinhAnh)
                        {
                            objThietBi.hinhanhs.Add(hinhanh);
                        }
                    }
                    CTThietBi ctThietBiOld = new CTThietBi().search(phong, objThietBi, tinhtrang);
                    if (ctThietBiOld == null)
                        objThietBi.ctthietbis.Add(ctThietBi);
                    else
                        ctThietBiOld.soluong += Int32.Parse(txtSoLuong.Text);
                    ////add chi tiet thiet bi cho thiet bi nay
                    //CTThietBi ctThietBi = new CTThietBi();
                    //ctThietBi.phong = _ucTreeViTri.getPhong();
                    //TinhTrang tinhtrang = (TinhTrang)lookUpTinhTrang.GetSelectedDataRow();
                    //ctThietBi.tinhtrang = new TinhTrang().getById(tinhtrang.id);
                    //ctThietBi.soluong = Int32.Parse(txtSoLuong.Text);

                    //check xem la add hay update
                    checkadd = false;
                }
                else
                {
                    //chua
                    //them hinh
                    objThietBi.ten = loaithietbi.ten;
                    objThietBi.hinhanhs = listHinhAnh;
                    //objThietBi.loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();
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
    }
}
