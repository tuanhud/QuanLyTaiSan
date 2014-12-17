using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using DevExpress.XtraReports.UI;
using TSCD.DataFilter;
using TSCD.DataFilter.SearchFilter;
using TSCD_GUI.Libraries;
using DevExpress.LookAndFeel;
using System.Threading;
using MoreLinq;

namespace TSCD_GUI.ReportTSCD
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        List<DonVi> ListDonVi = new List<DonVi>();
        int HeightNormal = 325, HeightHaveProgress = 375;
        OurDBContext MyNewDbContext = null;

        public delegate void SendMessage();
        public SendMessage _SendMessage;
        System.Threading.Thread _ThreadReport;
        static Boolean IsDesign = false;
        float Zoom = 1.2f;
        public frmReport()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(this.Size.Width, HeightNormal);

            comboBoxEdit_LoaiBaoCao.SelectedIndex = 0;

            dateEdit_TuNgay.DateTime = DateTime.Today.Date;
            dateEdit_DenNgay.DateTime = DateTime.Today.Date;
            dateEdit_Nam.DateTime = DateTime.Today.Date;

            ucComboBoxLoaiTS_LoaiTaiSan.showCheck();
            ucComboBoxLoaiTS_LoaiTaiSan.DataSource = LoaiTSHienThi.Convert(LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten));

            DonVi objNULL = new DonVi();
            ListDonVi = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
            objNULL.id = Guid.Empty;
            objNULL.ten = "[Không có đơn vị]";
            objNULL.parent = null;
            ListDonVi.Insert(0, objNULL);
            ucComboBoxDonVi_ChonDonVi.DataSource = ListDonVi;
            ucComboBoxDonVi_ChonDonVi.DonVi = objNULL;

            checkedComboBoxEdit_ChonCoSo.Properties.DataSource = CoSo.getQuery().OrderBy(c => c.order).ToList();
        }

        private void comboBoxEdit_LoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEdit_LoaiBaoCao.SelectedIndex)
            {
                case 0:
                    dateEdit_TuNgay.Enabled = true;
                    dateEdit_DenNgay.Enabled = true;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    dateEdit_Nam.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    checkEdit_ChuaCoViTri.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 1:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = true;
                    dateEdit_Nam.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    checkEdit_ChuaCoViTri.Enabled = true;
                    checkedComboBoxEdit_ChonCoSo.Enabled = true;
                    break;
                case 2:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    dateEdit_Nam.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
                    checkEdit_ChuaCoViTri.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 3:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    dateEdit_Nam.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
                    checkEdit_ChuaCoViTri.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
            }
        }

        private void simpleButton_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_Xuat_Click(object sender, EventArgs e)
        {
            switch (comboBoxEdit_LoaiBaoCao.SelectedIndex)
            {
                #region Báo cáo tăng giảm tài sản cố định

                case 0:
                    if (dateEdit_TuNgay.DateTime.Date > DateTime.Today.Date)
                    {
                        XtraMessageBox.Show("Ngày từ không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_TuNgay.Focus();
                        return;
                    }
                    if (dateEdit_DenNgay.DateTime.Date > DateTime.Today.Date)
                    {
                        XtraMessageBox.Show("Ngày đến không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_DenNgay.Focus();
                        return;
                    }
                    if (dateEdit_TuNgay.DateTime.Date > dateEdit_DenNgay.DateTime.Date)
                    {
                        XtraMessageBox.Show("Ngày từ không được lớn hơn ngày đến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_TuNgay.Focus();
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        IsDesign = false;
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        IsDesign = true;
                    }

                    ShowAndHide(false);
                    labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                    _ThreadReport = new System.Threading.Thread(() =>
                    {
                        DevExpress.UserSkins.BonusSkins.Register();
                        Application.EnableVisualStyles();
                        UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                        DevExpress.Skins.SkinManager.EnableFormSkins();

                        DateTime From = dateEdit_TuNgay.DateTime.Date, To = dateEdit_DenNgay.DateTime.Date;
                        List<TK_TangGiam_TheoLoaiTS> Data = GetData_BaoCaoTangGiamTaiSanCoDinh(From, To);

                        TSCD_GUI.ReportTSCD.XtraReport_BaoCaoTangGiamTSCD _XtraReport_BaoCaoTangGiamTSCD = new ReportTSCD.XtraReport_BaoCaoTangGiamTSCD(Data, From, To);
                        if (IsDesign)
                        {
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_BaoCaoTangGiamTSCD);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_BaoCaoTangGiamTSCD);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                    });
                    _ThreadReport.SetApartmentState(ApartmentState.STA);
                    _ThreadReport.Start();
                    break;

                #endregion

                #region Sổ tài sản cố định

                case 1:
                    if (dateEdit_Nam.DateTime.Year > DateTime.Today.Year)
                    {
                        XtraMessageBox.Show("Năm lớn hơn năm hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<Guid> ListLoaiTaiSan = ucComboBoxLoaiTS_LoaiTaiSan.list_loaitaisan;
                    if (Object.Equals(ListLoaiTaiSan, null))
                    {
                        XtraMessageBox.Show("Chưa chọn loại tài sản cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!(ListLoaiTaiSan.Count > 0))
                    {
                        XtraMessageBox.Show("Chưa chọn loại tài sản cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<Guid> ListCoSo = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_ChonCoSo);
                    if (!checkEdit_ChuaCoViTri.Checked)
                    {
                        if (Object.Equals(ListCoSo, null))
                        {
                            XtraMessageBox.Show("Chưa chọn cơ sở cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!(ListCoSo.Count > 0))
                        {
                            XtraMessageBox.Show("Chưa chọn cơ sở cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        IsDesign = false;
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        IsDesign = true;
                    }

                    ShowAndHide(false);
                    labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                    _ThreadReport = new System.Threading.Thread(() =>
                    {
                        DevExpress.UserSkins.BonusSkins.Register();
                        Application.EnableVisualStyles();
                        UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                        DevExpress.Skins.SkinManager.EnableFormSkins();

                        Object Data = GetData_SoTaiSanCoDinh(ListLoaiTaiSan, ListCoSo, dateEdit_Nam.DateTime.Year, checkEdit_ChuaCoViTri.Checked);

                        TSCD_GUI.ReportTSCD.XtraReport_SoTaiSanCoDinh _XtraReport_SoTaiSanCoDinh = new ReportTSCD.XtraReport_SoTaiSanCoDinh(Data, dateEdit_Nam.DateTime.Year);
                        if (IsDesign)
                        {
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoTaiSanCoDinh);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoTaiSanCoDinh);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                    });
                    _ThreadReport.SetApartmentState(ApartmentState.STA);
                    _ThreadReport.Start();
                    break;

                #endregion

                #region Sổ chi tiết tài sản cố định

                case 2:
                    if (dateEdit_Nam.DateTime.Year > DateTime.Today.Year)
                    {
                        XtraMessageBox.Show("Năm lớn hơn năm hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi, null))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi.id, Guid.Empty))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        IsDesign = false;
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        IsDesign = true;
                    }

                    ShowAndHide(false);
                    labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                    _ThreadReport = new System.Threading.Thread(() =>
                    {
                        DevExpress.UserSkins.BonusSkins.Register();
                        Application.EnableVisualStyles();
                        UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                        DevExpress.Skins.SkinManager.EnableFormSkins();

                        var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                        Object Data = null;
                        String strTenDonVi = "";
                        if (!Object.Equals(DonViSelected, null))
                        {
                            strTenDonVi = DonViSelected.ten;
                            Data = GetData_SoChiTietTaiSanCoDinh(DonViSelected.id, dateEdit_Nam.DateTime.Year);
                        }

                        TSCD_GUI.ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh _XtraReport_SoChiTietTaiSanCoDinh = new ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh(Data, dateEdit_Nam.DateTime.Year, strTenDonVi);
                        if (IsDesign)
                        {
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoChiTietTaiSanCoDinh);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoChiTietTaiSanCoDinh);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                    });
                    _ThreadReport.SetApartmentState(ApartmentState.STA);
                    _ThreadReport.Start();
                    break;

                #endregion

                #region Sổ theo dõi tài sản cố định tại nơi sử dụng

                case 3:
                    if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi, null))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi.id, Guid.Empty))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        IsDesign = false;
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        IsDesign = true;
                    }

                    ShowAndHide(false);
                    labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                    _ThreadReport = new System.Threading.Thread(() =>
                    {
                        DevExpress.UserSkins.BonusSkins.Register();
                        Application.EnableVisualStyles();
                        UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                        DevExpress.Skins.SkinManager.EnableFormSkins();

                        var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                        Object Data = null;
                        String strTenDonVi = "";
                        if (!Object.Equals(DonViSelected, null))
                        {
                            strTenDonVi = DonViSelected.ten;
                            Data = GetData_SoTheoDoiTaiSanCoDinhTaiNoiSuDung(DonViSelected.id);
                        }

                        TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_SoTheoDoiTSCDTaiNoiSuDung = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(Data, strTenDonVi);
                        if (IsDesign)
                        {
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoTheoDoiTSCDTaiNoiSuDung);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoTheoDoiTSCDTaiNoiSuDung);
                            printTool.PreviewForm.PrintControl.Zoom = Zoom;
                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                    });
                    _ThreadReport.SetApartmentState(ApartmentState.STA);
                    _ThreadReport.Start();
                    break;

                #endregion

                case 4:
                    XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }

        private void ResetDbContext()
        {
            if (!Object.Equals(MyNewDbContext, null))
            {
                MyNewDbContext.Dispose();
                MyNewDbContext = null;
            }
            MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);
        }

        private List<TK_TangGiam_TheoLoaiTS> GetData_BaoCaoTangGiamTaiSanCoDinh(DateTime From, DateTime To)
        {
            ResetDbContext();
            List<TK_TangGiam_TheoLoaiTS> Data = new List<TK_TangGiam_TheoLoaiTS>();
            try
            {
                var list_loaits = MyNewDbContext.LOAITAISANS.ToList();
                foreach (var item in list_loaits)
                {
                    TK_TangGiam_TheoLoaiTS obj = new TK_TangGiam_TheoLoaiTS();
                    obj.tenloai = item.ten;
                    obj.id_loai = item.id;
                    obj.donvitinh = item.donvitinh == null ? "" : item.donvitinh.ten;

                    foreach (var taisan in item.taisans)
                    {
                        //Tính số đầu năm
                        foreach (var ctts in taisan.cttaisans.Where(
                            c =>
                                c.soluong > 0
                                &&
                                (
                                    (c.ngay != null && c.ngay < From)
                                )
                            )
                        )
                        {
                            obj.sodaunam_soluong += ctts.soluong;
                            obj.sodaunam_giatri += ctts.thanhtien;
                        }
                        var list_log_ctts = taisan.logtanggiamtaisans.Where(c => c.ngay != null && c.ngay >= From && c.ngay <= To && c.soluong > 0);
                        //Tính tăng/giảm trong năm
                        foreach (var ctts in list_log_ctts.Where(c => c.tang_giam == 1 || c.tang_giam == -1))
                        {
                            if (ctts.tang_giam == 1)
                            {
                                obj.tangtrongnam_soluong += ctts.soluong;
                                obj.tangtrongnam_giatri += ctts.thanhtien;
                            }
                            else if (ctts.tang_giam == -1)
                            {
                                obj.giamtrongnam_soluong += ctts.soluong;
                                obj.giamtrongnam_giatri += ctts.thanhtien;
                            }
                        }
                        //Tính số cuối năm
                        obj.socuoinam_soluong = obj.sodaunam_soluong + obj.tangtrongnam_soluong - obj.giamtrongnam_soluong;
                        obj.socuoinam_giatri = obj.sodaunam_giatri + obj.tangtrongnam_giatri - obj.giamtrongnam_giatri;
                    }
                    //add to list
                    Data.Add(obj);
                }
            }
            catch (Exception) { return new List<TK_TangGiam_TheoLoaiTS>(); }
            return Data;
        }

        private Object GetData_SoTaiSanCoDinh(List<Guid> ListLoaiTaiSan, List<Guid> ListCoSo, int Year, Boolean ChuaCoViTri)
        {
            ResetDbContext();
            IQueryable<CTTaiSan> IQueryable = MyNewDbContext.CTTAISANS.AsQueryable<CTTaiSan>();
            //get luon so luong = 0, vi tinh tang giam
            //IQueryable = IQueryable.Where(x => x.soluong > 0);
            IQueryable = IQueryable.Where(item => Object.Equals(item.ngay, null) == false);
            IQueryable = IQueryable.Where(item => ((DateTime)item.ngay).Year <= Year);

            //LTB
            if (ListLoaiTaiSan != null && ListLoaiTaiSan.Count > 0)
            {
                IQueryable = IQueryable.Where(x => x.taisan.loaitaisan == null || ListLoaiTaiSan.Contains(x.taisan.loaitaisan.id));
            }
            //COSO
            if (ListCoSo != null && ListCoSo.Count > 0)
            {
                List<Guid> ListPhong = Phong.getQuery().Where(x => ListCoSo.Contains(x.vitri.coso.id)).Select(c => c.id).ToList();
                IQueryable = IQueryable.Where(x => ListCoSo.Contains(x.vitri.coso.id) || ListPhong.Contains(x.phong.id));
            }
            if (ChuaCoViTri)
                IQueryable = IQueryable.Where(x => Object.Equals(x.vitri, null) == true);
            //var DataFiltered_Groups = IQueryable.OrderByDescending(item => item.date_create).DistinctBy(item => new { item.taisan_id, item.tinhtrang_id }).GroupBy(item => item.taisan_id).ToList();
            var DataFiltered_Groups = IQueryable.OrderByDescending(item => item.date_create).GroupBy(item => item.taisan_id).ToList();

            List<TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter> Data = new List<TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter>();
            foreach (var _Group in DataFiltered_Groups)
            {
                int intCount = _Group.Count();

                if (intCount == 1)
                {
                    TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter item = new TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter();
                    //CTTS nay la tang tai san, neu la giam thi ... -_-
                    item.ngay = _Group.ElementAt(0).ngay;
                    item.sohieu_ct = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.sohieu : "";
                    item.ten = _Group.ElementAt(0).taisan.ten;
                    item.nuocsx = _Group.ElementAt(0).taisan.nuocsx;

                    //Do chi co 1 CTTS ma no giam (dac thu la chuyen tinh trang soluong dau = soluong chuyen se khong phat
                    //CTTS moi) nen du lieu tang = giam
                    if (_Group.ElementAt(0).tinhtrang.giam_taisan)
                    {
                        item.sohieu_ct_giam = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.sohieu : "";
                        item.ngay_ct_giam = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.ngay : null;
                        item.ghichu = _Group.ElementAt(0).mota;
                    }
                    //Giam nen lay giam vo tang luon, gia tri ban dau
                    item.dongia_tang = _Group.ElementAt(0).taisan.dongia;
                    item.sohieu_ct_tang = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.sohieu : "";
                    item.ngay_ct_tang = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.ngay : null;

                    item.dongia_tang = !_Group.ElementAt(0).tinhtrang.giam_taisan ? _Group.ElementAt(0).taisan.dongia : 0;
                    item.sohieu_ct_tang = !_Group.ElementAt(0).tinhtrang.giam_taisan ? (_Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.sohieu : "") : "";
                    item.ngay_ct_tang = !_Group.ElementAt(0).tinhtrang.giam_taisan ? (_Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.ngay : null) : null;

                    item.sohieu_ct_giam = _Group.ElementAt(0).tinhtrang.giam_taisan ? (_Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.sohieu : "") : "";
                    item.ngay_ct_giam = _Group.ElementAt(0).tinhtrang.giam_taisan ? (_Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.ngay : null) : null;
                    item.ghichu = _Group.ElementAt(0).tinhtrang.giam_taisan ? _Group.ElementAt(0).mota : null;

                    item.phantramhaomon_32 = Object.Equals(_Group.ElementAt(0).taisan, null) ? 0 : Object.Equals(_Group.ElementAt(0).taisan.loaitaisan, null) ? 0 : _Group.ElementAt(0).taisan.loaitaisan.phantramhaomon_32 * 100;
                    item.sotientrongmotnam = Object.Equals(_Group.ElementAt(0).taisan, null) ? 0 : Object.Equals(_Group.ElementAt(0).taisan.loaitaisan, null) ? 0 : Object.Equals(_Group.ElementAt(0).taisan.loaitaisan.phantramhaomon_32, null) ? 0 : (long)(_Group.ElementAt(0).taisan.dongia * _Group.ElementAt(0).taisan.loaitaisan.phantramhaomon_32);
                    item.haomon_1nam = _Group.ElementAt(0).sonamsudungconlai_final(Year) <= 0 ? 0 : _Group.ElementAt(0).haomon_1nam;
                    item.giatriconlai_final = _Group.ElementAt(0).giatriconlai_final(Year);
                    item.haomonluyke = _Group.ElementAt(0).haomonluyke(Year);
                    item.haomonnamtruocchuyensang = _Group.ElementAt(0).haomonnamtruocchuyensang(Year);

                    Data.Add(item);
                }
                else if (intCount > 1)
                {
                    //Tai san nay co so luong > 1 nen se co n dong cho tai san nay
                    foreach (var CTTS in _Group)
                    {
                        if (CTTS.tinhtrang.giam_taisan)
                        {
                            //Giam
                            for (int i = 1; i <= CTTS.soluong; i++)
                            {
                                TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter item = new TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter();

                                item.ngay = CTTS.ngay;
                                item.sohieu_ct = CTTS.chungtu != null ? CTTS.chungtu.sohieu : "";
                                item.ten = CTTS.taisan.ten;
                                item.nuocsx = CTTS.taisan.nuocsx;

                                item.dongia_tang = CTTS.taisan.dongia;
                                item.sohieu_ct_tang = CTTS.chungtu != null ? CTTS.chungtu.sohieu : "";
                                item.ngay_ct_tang = CTTS.chungtu != null ? CTTS.chungtu.ngay : null;

                                item.sohieu_ct_giam = CTTS.chungtu != null ? CTTS.chungtu.sohieu : "";
                                item.ngay_ct_giam = CTTS.chungtu != null ? CTTS.chungtu.ngay : null;
                                item.ghichu = CTTS.mota;

                                item.phantramhaomon_32 = Object.Equals(CTTS.taisan, null) ? 0 : Object.Equals(CTTS.taisan.loaitaisan, null) ? 0 : CTTS.taisan.loaitaisan.phantramhaomon_32 * 100;
                                item.sotientrongmotnam = Object.Equals(CTTS.taisan, null) ? 0 : Object.Equals(CTTS.taisan.loaitaisan, null) ? 0 : Object.Equals(CTTS.taisan.loaitaisan.phantramhaomon_32, null) ? 0 : (long)(CTTS.taisan.dongia * CTTS.taisan.loaitaisan.phantramhaomon_32);
                                item.haomon_1nam = CTTS.sonamsudungconlai_final(Year) <= 0 ? 0 : CTTS.haomon_1nam;
                                item.giatriconlai_final = CTTS.giatriconlai_final(Year);
                                item.haomonluyke = CTTS.haomonluyke(Year);
                                item.haomonnamtruocchuyensang = CTTS.haomonnamtruocchuyensang(Year);

                                Data.Add(item);
                            }
                        }
                        else
                        {
                            //Tang
                            for (int i = 1; i <= CTTS.soluong; i++)
                            {
                                TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter item = new TSCD.DataFilter.ReportFilter.SoTaiSanCoDinh_DataFilter();

                                item.ngay = CTTS.ngay;
                                item.sohieu_ct = _Group.ElementAt(1).chungtu != null ? _Group.ElementAt(1).chungtu.sohieu : "";
                                item.ten = CTTS.taisan.ten;
                                item.nuocsx = CTTS.taisan.nuocsx;

                                item.dongia_tang = !_Group.ElementAt(1).tinhtrang.giam_taisan ? _Group.ElementAt(1).taisan.dongia : 0;
                                item.sohieu_ct_tang = !_Group.ElementAt(1).tinhtrang.giam_taisan ? (_Group.ElementAt(1).chungtu != null ? _Group.ElementAt(1).chungtu.sohieu : "") : "";
                                item.ngay_ct_tang = !_Group.ElementAt(1).tinhtrang.giam_taisan ? (_Group.ElementAt(1).chungtu != null ? _Group.ElementAt(1).chungtu.ngay : null) : null;

                                item.phantramhaomon_32 = Object.Equals(CTTS.taisan, null) ? 0 : Object.Equals(CTTS.taisan.loaitaisan, null) ? 0 : CTTS.taisan.loaitaisan.phantramhaomon_32 * 100;
                                item.sotientrongmotnam = Object.Equals(CTTS.taisan, null) ? 0 : Object.Equals(CTTS.taisan.loaitaisan, null) ? 0 : Object.Equals(CTTS.taisan.loaitaisan.phantramhaomon_32, null) ? 0 : (long)(CTTS.taisan.dongia * CTTS.taisan.loaitaisan.phantramhaomon_32);
                                item.haomon_1nam = CTTS.sonamsudungconlai_final(Year) <= 0 ? 0 : CTTS.haomon_1nam;
                                item.giatriconlai_final = CTTS.giatriconlai_final(Year);
                                item.haomonluyke = CTTS.haomonluyke(Year);
                                item.haomonnamtruocchuyensang = CTTS.haomonnamtruocchuyensang(Year);

                                Data.Add(item);
                            }
                        }
                    }
                }
            }
            return Data.OrderBy(item => item.ngay).ToList(); ;
        }

        private Object GetData_SoChiTietTaiSanCoDinh(Guid DonViId, int Year)
        {
            ResetDbContext();
            DonVi DonViSelected = MyNewDbContext.DONVIS.Find(DonViId);
            if (Object.Equals(DonViSelected, null))
            {
                return null;
            }
            //get so luong > 0 cung duoc
            var Data = DonViSelected.getAllCTTaiSanRecursive().Where(item => Object.Equals(item.ngay, null) == false).Where(item => ((DateTime)item.ngay).Year <= Year).OrderByDescending(item => item.date_create).DistinctBy(item => item.taisan_id).ToList().Select(x => new
            {
                ten = x.taisan.ten,
                nuocsx = x.taisan.nuocsx,
                ngay = x.ngay,
                phantramhaomon_32 = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : x.taisan.loaitaisan.phantramhaomon_32 * 100,
                dongia = x.taisan.dongia,

                giatriconlai_final = x.giatriconlai_final(Year),
                haomonluyke = x.haomonluyke(Year),
                haomonnamtruocchuyensang = x.haomonnamtruocchuyensang(Year),
                haomon_1nam = x.sonamsudungconlai_final(Year) <= 0 ? 0 : x.haomon_1nam,

                tenloaitaisan = Object.Equals(x.taisan.loaitaisan, null) ? x.taisan.loaitaisan.ten : "",
                loaitaisan = Object.Equals(x.taisan.loaitaisan, null) ? x.taisan.loaitaisan.id : Guid.Empty,
                loaitaisan_parent = Object.Equals(x.taisan.loaitaisan, null) ? Object.Equals(x.taisan.loaitaisan.parent, null) ? x.taisan.loaitaisan.parent_id : Guid.Empty : Guid.Empty
            }).OrderBy(item => item.ngay).ToList();
            return Data;
        }

        private Object GetData_SoTheoDoiTaiSanCoDinhTaiNoiSuDung(Guid DonViId)
        {
            ResetDbContext();
            int Year = DateTime.Today.Year;
            DonVi DonViSelected = MyNewDbContext.DONVIS.Find(DonViId);

            if (Object.Equals(DonViSelected, null))
            {
                return null;
            }
            var IQueryable = DonViSelected.getAllCTTaiSanRecursive_All();
            IQueryable = IQueryable.Where(item => Object.Equals(item.ngay, null) == false);
            IQueryable = IQueryable.Where(item => ((DateTime)item.ngay).Year <= Year);

            var DataFiltered_Groups = IQueryable.OrderByDescending(item => item.date_create).GroupBy(item => item.taisan_id).ToList();

            List<TSCD.DataFilter.ReportFilter.SoTheoDoiTaiSanCoDinhTaiNoiSuDung_DataFilter> Data = new List<TSCD.DataFilter.ReportFilter.SoTheoDoiTaiSanCoDinhTaiNoiSuDung_DataFilter>();
            foreach (var _Group in DataFiltered_Groups)
            {
                int intCount = _Group.Count();
                TSCD.DataFilter.ReportFilter.SoTheoDoiTaiSanCoDinhTaiNoiSuDung_DataFilter item = new TSCD.DataFilter.ReportFilter.SoTheoDoiTaiSanCoDinhTaiNoiSuDung_DataFilter();
                if (intCount == 1)
                {
                    //CTTS nay la tang tai san, neu la giam thi ... -_-
                    item.sohieu_ct = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.sohieu : "";
                    item.ngay_ct = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.ngay : null;

                    item.ten = _Group.ElementAt(0).taisan.ten;
                    item.donvitinh = _Group.ElementAt(0).taisan.loaitaisan.donvitinh != null ? _Group.ElementAt(0).taisan.loaitaisan.donvitinh.ten : "";

                    if (_Group.ElementAt(0).tinhtrang.giam_taisan)
                    {
                        item.soluong_giam = (int?)_Group.ElementAt(0).soluong;
                        item.dongia_giam = (long?)_Group.ElementAt(0).taisan.dongia;
                        item.thanhtien_giam = (long?)_Group.ElementAt(0).soluong * _Group.ElementAt(0).taisan.dongia;
                        item.ghichu = _Group.ElementAt(0).mota;
                    }
                    item.soluong_tang = (int?)_Group.ElementAt(0).soluong;
                    item.dongia_tang = (long?)_Group.ElementAt(0).taisan.dongia;
                    item.thanhtien_tang = (long?)_Group.ElementAt(0).soluong * _Group.ElementAt(0).taisan.dongia;

                    Data.Add(item);
                }
                else if (intCount > 1)
                {
                    int intSoLuongGiam = 0, intSoLuongTang = 0;
                    foreach (var CTTS in _Group)
                    {
                        if (CTTS.tinhtrang.giam_taisan)
                            intSoLuongGiam += CTTS.soluong;
                        else
                            intSoLuongTang += CTTS.soluong;
                    }

                    //Cung la 1 tai san nen lay o vi tri 0
                    item.sohieu_ct = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.sohieu : "";
                    item.ngay_ct = _Group.ElementAt(0).chungtu != null ? _Group.ElementAt(0).chungtu.ngay : null;

                    item.ten = _Group.ElementAt(0).taisan.ten;
                    item.donvitinh = _Group.ElementAt(0).taisan.loaitaisan.donvitinh != null ? _Group.ElementAt(0).taisan.loaitaisan.donvitinh.ten : "";

                    if (intSoLuongTang > 0)
                    {
                        item.soluong_tang = intSoLuongTang;
                        item.dongia_tang = (long?)_Group.ElementAt(0).taisan.dongia;
                        item.thanhtien_tang = (long?)intSoLuongTang * _Group.ElementAt(0).taisan.dongia;
                    }

                    if (intSoLuongGiam > 0)
                    {
                        item.soluong_giam = intSoLuongGiam;
                        item.dongia_giam = (long?)_Group.ElementAt(0).taisan.dongia;
                        item.thanhtien_giam = (long?)intSoLuongGiam * _Group.ElementAt(0).taisan.dongia;
                    }


                    item.ghichu = _Group.ElementAt(0).tinhtrang.giam_taisan ? _Group.ElementAt(0).mota : "";

                    Data.Add(item);
                }
            }
            return Data.OrderBy(item => item.ngay_ct).ToList();
        }

        private void ShowAndHide(Boolean _Enable)
        {
            if (_Enable)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Size = new System.Drawing.Size(this.Size.Width, HeightNormal);
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Size = new System.Drawing.Size(this.Size.Width, HeightHaveProgress);
                });
            }
            simpleButton_Xuat.Invoke((MethodInvoker)delegate
            {
                simpleButton_Xuat.Enabled = _Enable;
            });

            labelControl_Status.Invoke((MethodInvoker)delegate
            {
                labelControl_Status.Visible = !_Enable;
            });
            marqueeProgressBarControl_Status.Invoke((MethodInvoker)delegate
            {
                marqueeProgressBarControl_Status.Enabled = !_Enable;
                marqueeProgressBarControl_Status.Visible = !_Enable;
            });
            simpleButton_Stop.Invoke((MethodInvoker)delegate
            {
                simpleButton_Stop.Enabled = !_Enable;
                simpleButton_Stop.Visible = !_Enable;
            });
        }

        private void ReportCompeleted()
        {
            labelControl_Status.Invoke((MethodInvoker)delegate
            {
                labelControl_Status.Text = "Đã tạo xong report";
            });
            marqueeProgressBarControl_Status.Invoke((MethodInvoker)delegate
            {
                marqueeProgressBarControl_Status.Enabled = false;
            });
            simpleButton_Stop.Invoke((MethodInvoker)delegate
            {
                simpleButton_Stop.Enabled = false;
            });
        }

        private void KillThread()
        {
            if (!Object.Equals(_ThreadReport, null))
            {
                if (_ThreadReport.IsAlive)
                {
                    _ThreadReport.Abort();
                    _ThreadReport = null;
                }
            }
        }

        private void frmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            _SendMessage();
        }

        private void simpleButton_Stop_Click(object sender, EventArgs e)
        {
            KillThread();
            ShowAndHide(true);
        }

        private void frmReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Object.Equals(_ThreadReport, null))
            {
                KillThread();
            }
        }
    }
}