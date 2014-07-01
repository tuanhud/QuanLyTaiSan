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
        CTThietBi objCTThietBi = new CTThietBi();
        Phong objPhong = new Phong();
        LoaiThietBi objLoaiThietBi = null;
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        Boolean checkadd = true;

        List<LoaiThietBi> listLoaiThietBi = null;
        List<ThietBi> listThietBi = null;
        List<PhongHienThi> listPhongFilter = null;
        List<ViTriHienThi> listViTriFilter = null;
        List<TinhTrang> listTinhTrang = null;
        Boolean coThayDoi = false;

        int HinhThucThem = 0;
        Boolean loaiChung = false;

        public frmNewThietBi()
        {
            InitializeComponent();
            loadData();
        }

        public frmNewThietBi(Phong obj)
        {
            InitializeComponent();
            objPhong = obj;
            loadData();
        }

        public void loadData()
        {
            listLoaiThietBi = LoaiThietBi.getAll();
            _ucTreeLoaiTB.loadData(listLoaiThietBi);
            _ucTreeLoaiTB.type = "add";
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelLoaiTB.Controls.Add(_ucTreeLoaiTB);
            objLoaiThietBi = _ucTreeLoaiTB.getLoaiThietBi();

            //listPhongFilter = PhongHienThi.getAll();//qd
            listViTriFilter = ViTriHienThi.getAllHavePhong();
            _ucComboBoxViTri.loadData(listViTriFilter);
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            _ucComboBoxViTri.setReadOnly(false);
            _ucComboBoxViTri.setPhong(objPhong);
            panelPhong.Controls.Add(_ucComboBoxViTri);

            listTinhTrang = TinhTrang.getAll();//.OrderBy(i => i.value).ToList();
            lookUpTinhTrang.Properties.DataSource = listTinhTrang;
            //lookUpTinhTrang.ItemIndex = 0; // không làm việc, không biết tại sao ???
            setGiaTriDauCho_Phong_LoaiThietBi_TinhTrang();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                objThietBi = new ThietBi();
                setDataObj();
                Boolean thanhcong = false;
                if (HinhThucThem == 0) //0 là thêm mới, 1 là lấy từ danh sách thiết bị
                {
                    if (objThietBi.add() < 0)
                    {
                        // XtraMessageBox.Show("Thêm thiết bị mới vào phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //thanhcong = true;
                        XtraMessageBox.Show("Có lỗi trong khi thêm mới thiết bị!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (objCTThietBi.add() > 0)
                        {
                            XtraMessageBox.Show("Thêm thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            thanhcong = true;
                        }
                        else
                        {
                            XtraMessageBox.Show("Có lỗi trong khi thêm thiết bị vào phòng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (objCTThietBi.add() > 0)
                    {
                        XtraMessageBox.Show("Thêm thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        thanhcong = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Có lỗi trong khi thêm thiết bị vào phòng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                loaiChung = _loaiChung;
                objLoaiThietBi = _ucTreeLoaiTB.getLoaiThietBi();
                HinhThucThems();
                ChangeThietBi();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Boolean checkInput()
        {
            try
            {
                Boolean check = true;
                dxErrorProvider.ClearErrors();
                if (_ucComboBoxViTri.getTextPopupContainerEdit().Equals("[Chưa có phòng]"))
                {
                    check = false;
                    dxErrorProvider.SetError(panelPhong, "Chưa chọn phòng");
                }
                if (_ucComboBoxViTri.getTextPopupContainerEdit().Equals("[Chưa có loại thiết bị]"))
                {
                    check = false;
                    dxErrorProvider.SetError(panelLoaiTB, "Chưa chọn loại thiết bị");
                }
                if (lookUpTinhTrang.EditValue.Equals(null))
                {
                    check = false;
                    dxErrorProvider.SetError(lookUpTinhTrang, "Chưa chọn tình trạng");
                }
                int soluong = Int32.Parse(txtSoLuong.Text);
                if (soluong < 1 || soluong > 1000)
                {
                    check = false;
                    dxErrorProvider.SetError(txtSoLuong, "Số lượng từ 1-1000");
                }
                if (groupControl1.Visible)
                {
                    if (txtTen.Text.Length == 0)
                    {
                        check = false;
                        dxErrorProvider.SetError(txtTen, "Chưa điền tên thiết bị");
                    }
                    if (dateEditMua.DateTime > dateEditLap.DateTime)
                    {
                        check = false;
                        dxErrorProvider.SetError(dateEditLap, "Ngày lắp phải lớn hơn ngày mua");
                    }
                    if (dateEditMua.DateTime > DateTime.Today)
                    {
                        check = false;
                        dxErrorProvider.SetError(dateEditMua, "Ngày mua lớn hơn ngày hiện tại");
                    }
                    if (dateEditLap.DateTime > DateTime.Today)
                    {
                        check = false;
                        dxErrorProvider.SetError(dateEditLap, "Ngày lắp lớn hơn ngày hiện tại");
                    }
                }
                return check;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        private void resetData()
        {
            imgHinhThietBi.Images.Clear();
            searchLookUpEditListThietBi.EditValue = null;
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void setDataObj()
        {
            TinhTrang tinhtrang = (TinhTrang)lookUpTinhTrang.GetSelectedDataRow();
            if (HinhThucThem == 0) //thêm mới thiết bị sau đó thêm thiết bị vào phòng
            {
                try
                {
                    if (loaiChung) // loại chung
                    {
                        //thêm mới thiết bị
                        objThietBi.loaithietbi = objLoaiThietBi;
                        objThietBi.hinhanhs = listHinhAnh;
                        objThietBi.ten = objLoaiThietBi.ten;
                        objThietBi.mota = objLoaiThietBi.mota;

                        //sau đó thêm mới thiết bị vào phòng
                        objCTThietBi.soluong = Int32.Parse(txtSoLuong.Text);
                        objCTThietBi.phong = _ucComboBoxViTri.getPhong();

                        objCTThietBi.thietbi = objThietBi;
                        objCTThietBi.tinhtrang = tinhtrang;
                    }
                    else //loairieng
                    {
                        //thêm mới thiết bị
                        objThietBi.loaithietbi = objLoaiThietBi;
                        objThietBi.hinhanhs = listHinhAnh;
                        objThietBi.subId = txtMa.Text;
                        objThietBi.ten = txtTen.Text;
                        objThietBi.ngaymua = dateEditMua.DateTime;
                        objThietBi.ngaylap = dateEditLap.DateTime;
                        objThietBi.mota = txtMoTa.Text;

                        //sau đó thêm mới thiết bị vào phòng
                        objCTThietBi.soluong = Int32.Parse(txtSoLuong.Text);
                        objCTThietBi.phong = _ucComboBoxViTri.getPhong();

                        objCTThietBi.thietbi = objThietBi;
                        objCTThietBi.tinhtrang = tinhtrang;
                    }                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //CTThietBi ctThietBi = new CTThietBi();
                //Phong phong = _ucComboBoxViTri.getPhong();

                //ctThietBi.phong = phong;
                //ctThietBi.tinhtrang = TinhTrang.getById(tinhtrang.id);
                //ctThietBi.soluong = Int32.Parse(txtSoLuong.Text);

                //LoaiThietBi loaithietbi = _ucTreeLoaiTB.getLoaiThietBi();

                //if (groupControl1.Visible)
                //{
                //    objThietBi.hinhanhs = listHinhAnh;

                //    objThietBi.loaithietbi = loaithietbi;
                //    objThietBi.ctthietbis.Add(ctThietBi);

                //    objThietBi.subId = txtMa.Text;
                //    objThietBi.ten = txtTen.Text;
                //    objThietBi.ngaymua = dateEditMua.DateTime;
                //    objThietBi.ngaylap = dateEditLap.DateTime;
                //    objThietBi.mota = txtMoTa.Text;
                //    checkadd = true;
                //}
                //else
                //{
                //    //thiet bi duoc quan li theo so luong
                //    if (loaithietbi.thietbis.Count > 0)
                //    {
                //        //co
                //        objThietBi = ThietBi.getById(loaithietbi.thietbis.ElementAt(0).id);

                //        if (listHinhAnh.Count > 0)
                //        {
                //            foreach (HinhAnh hinhanh in listHinhAnh)
                //            {
                //                objThietBi.hinhanhs.Add(hinhanh);
                //            }
                //        }
                //        CTThietBi ctThietBiOld = CTThietBi.search(phong, objThietBi, tinhtrang);
                //        if (ctThietBiOld == null)
                //            objThietBi.ctthietbis.Add(ctThietBi);
                //        else
                //            ctThietBiOld.soluong += Int32.Parse(txtSoLuong.Text);

                //        checkadd = false;
                //    }
                //    else
                //    {
                //        //chua co
                //        objThietBi.ten = loaithietbi.ten;
                //        objThietBi.hinhanhs = listHinhAnh;

                //        objThietBi.loaithietbi = loaithietbi;
                //        objThietBi.ctthietbis.Add(ctThietBi);
                //        checkadd = true;
                //    }
                //}
            }
            else //thêm thiết bị đã có vào phòng
            {
                objCTThietBi.soluong = Int32.Parse(txtSoLuong.Text);
                objCTThietBi.phong = _ucComboBoxViTri.getPhong();

                int rowHandle = searchLookUpEditListThietBi.Properties.GetIndexByKeyValue(searchLookUpEditListThietBi.EditValue);
                object row = searchLookUpEditListThietBi.Properties.View.GetRow(rowHandle);
                ThietBi thietbi = (ThietBi)row;
                objCTThietBi.thietbi = thietbi;

                objCTThietBi.tinhtrang = tinhtrang;
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            frmHinhAnh frm = new frmHinhAnh(listHinhAnh);
            frm.Text = "Quản lý hình ảnh của thiết bị";
            frm.ShowDialog();
            listHinhAnh = frm.getlistHinhs();
            if (listHinhAnh.Count > 0)
            {
                HienThiHinhAnhTuListHinhAnh();
            }
        }

        private void frmNewThietBi_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (coThayDoi)
            //    RunDelegate();
        }

        private void comboBoxEditHinhThucThem_SelectedIndexChanged(object sender, EventArgs e)
        {
            HinhThucThem = comboBoxEditHinhThucThem.SelectedIndex;
            HinhThucThems();
            ChangeThietBi();
        }

        //xử lý giữa thêm mới và chọn từ danh sách
        private void HinhThucThems()
        {
            try
            {
                if (HinhThucThem == 1) // Chọn từ danh sách thiết bị
                {
                    btnChonHinh.Visible = false;

                    listThietBi = objLoaiThietBi.thietbis.ToList();
                    searchLookUpEditListThietBi.Properties.DataSource = listThietBi;
                    searchLookUpEditListThietBi.Enabled = true;
                    searchLookUpEditListThietBi.EditValue = listThietBi[0].id;
                }
                else // thêm mới
                {
                    btnChonHinh.Visible = true;
                    searchLookUpEditListThietBi.Enabled = false;
                    searchLookUpEditListThietBi.EditValue = null;
                    imgHinhThietBi.Images.Clear();
                    listHinhAnh = new List<HinhAnh>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void searchLookUpEditListThietBi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchLookUpEditListThietBi.EditValue != null)
                {
                    //lấy id thiết bị
                    int IdThietBi = Int32.Parse(searchLookUpEditListThietBi.EditValue.ToString());
                    //trả về object thiết bị
                    objThietBi = ThietBi.getById(IdThietBi);
                    // gán object vào form
                    listHinhAnh = objThietBi.hinhanhs.ToList();
                    HienThiHinhAnhTuListHinhAnh();
                    ChangeThietBi();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ChangeThietBi()
        {
            try
            {
                groupControl1.Visible = !loaiChung;
                if (!loaiChung)
                {
                    txtSoLuong.Value = 1;
                    txtSoLuong.Properties.ReadOnly = true;
                    if (HinhThucThem == 1)
                    {
                        txtMa.Text = objThietBi.id.ToString();
                        txtTen.Text = objThietBi.ten;
                        txtMoTa.Text = objThietBi.mota;
                        if (objThietBi.ngaylap == null)
                        {
                            dateEditLap.EditValue = null;
                        }
                        else
                        {
                            dateEditLap.DateTime = (DateTime)objThietBi.ngaylap;
                        }
                        if (objThietBi.ngaymua == null)
                        {
                            dateEditMua.EditValue = null;
                        }
                        else
                        {
                            dateEditMua.DateTime = (DateTime)objThietBi.ngaymua;
                        }
                        txtMa.Properties.ReadOnly = true;
                        txtTen.Properties.ReadOnly = true;
                        txtMoTa.Properties.ReadOnly = true;
                        dateEditLap.Properties.ReadOnly = true;
                        dateEditMua.Properties.ReadOnly = true;
                    }
                    else
                    {
                        dateEditLap.DateTime = DateTime.Today;
                        dateEditMua.DateTime = DateTime.Today;
                        dateEditLap.Properties.ReadOnly = false;
                        dateEditMua.Properties.ReadOnly = false;
                        txtMa.Text = String.Empty;
                        txtTen.Text = String.Empty;
                        txtMoTa.Text = String.Empty;
                        txtMa.Properties.ReadOnly = false;
                        txtTen.Properties.ReadOnly = false;
                        txtMoTa.Properties.ReadOnly = false;
                    }
                }
                else
                {
                    txtSoLuong.Properties.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HienThiHinhAnhTuListHinhAnh()
        {
            try
            {
                imgHinhThietBi.Images.Clear();
                foreach (HinhAnh h in listHinhAnh)
                {
                    imgHinhThietBi.Images.Add(h.getImage());
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": " + ex.Message);
            }
        }
    }
}
