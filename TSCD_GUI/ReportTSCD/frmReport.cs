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
        int HeightNormal = 300, HeightHaveProgress = 350;
        OurDBContext MyNewDbContext = null;

        public delegate void SendMessage();
        public SendMessage _SendMessage;
        System.Threading.Thread _ThreadReport;
        static Boolean IsDesign = false;

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
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 1:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = true;
                    dateEdit_Nam.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = true;
                    break;
                case 2:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    dateEdit_Nam.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 3:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    dateEdit_Nam.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
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
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_BaoCaoTangGiamTSCD);

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

                        Object Data = GetData_SoTaiSanCoDinh(ListLoaiTaiSan, ListCoSo, dateEdit_Nam.DateTime.Year);

                        TSCD_GUI.ReportTSCD.XtraReport_SoTaiSanCoDinh _XtraReport_SoTaiSanCoDinh = new ReportTSCD.XtraReport_SoTaiSanCoDinh(Data, dateEdit_Nam.DateTime.Year);
                        if (IsDesign)
                        {
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoTaiSanCoDinh);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoTaiSanCoDinh);

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
                        Object Data = new Object();
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
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoChiTietTaiSanCoDinh);

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
                        Object Data = new Object();
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
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        }
                        else
                        {
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoTheoDoiTSCDTaiNoiSuDung);

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

        /// <summary>
        /// Cai nay khong biet :v
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sai la cai chac, biet cho sai nhung khong them sua :v
        /// </summary>
        /// <param name="ListLoaiTaiSan"></param>
        /// <param name="ListCoSo"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        private Object GetData_SoTaiSanCoDinh(List<Guid> ListLoaiTaiSan, List<Guid> ListCoSo, int Year)
        {
            ResetDbContext();
            IQueryable<CTTaiSan> IQueryable = MyNewDbContext.CTTAISANS.AsQueryable<CTTaiSan>();
            IQueryable = IQueryable.Where(x => x.soluong > 0);
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
                List<Guid> list_phong = Phong.getQuery().Where(x => ListCoSo.Contains(x.vitri.coso.id)).Select(c => c.id).ToList();
                IQueryable = IQueryable.Where(x => ListCoSo.Contains(x.vitri.coso.id) || list_phong.Contains(x.phong.id));
            }

            var Data = IQueryable.OrderByDescending(item => item.date_create).DistinctBy(item => item.taisan_id).ToList().Select(x => new
            {
                //Phai dung it nhat 2 chi tiet tai san cua tai san nay de tinh tang, giam cua tai san

                id = x.id,
                ngay = x.ngay,
                //Chung tu gi day (tang hay giam, phu thuoc tinh trang cua chi tiet tai san) -_-
                sohieu_ct = x.chungtu != null ? x.chungtu.sohieu : "",
                ten = x.taisan.ten,
                nuocsx = x.taisan.nuocsx,

                //Kiem chi tiet tai san ma tinh trang la tang tai san
                dongia_tang = !x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                sohieu_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                ngay_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,

                //Kiem chi tiet tai san ma tinh trang la tang tai san
                sohieu_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                ngay_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                ghichu = x.tinhtrang.giam_taisan ? x.mota : null,

                phantramhaomon_32 = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : x.taisan.loaitaisan.phantramhaomon_32 * 100,
                sotientrongmotnam = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan.phantramhaomon_32, null) ? 0 : (long)(x.taisan.dongia * x.taisan.loaitaisan.phantramhaomon_32),

                haomon_1nam = x.sonamsudungconlai_final(Year) <= 0 ? 0 : x.haomon_1nam,
                giatriconlai_final = x.giatriconlai_final(Year),
                haomonluyke = x.haomonluyke(Year),
                haomonnamtruocchuyensang = x.haomonnamtruocchuyensang(Year),
            }).ToList();
            return Data;
        }

        /// <summary>
        /// Cai nay dung ne :v
        /// </summary>
        /// <param name="DonViId"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        private Object GetData_SoChiTietTaiSanCoDinh(Guid DonViId, int Year)
        {
            ResetDbContext();
            DonVi DonViSelected = MyNewDbContext.DONVIS.Find(DonViId);
            if (Object.Equals(DonViSelected, null))
            {
                return new Object();
            }
            var Data = DonViSelected.cttaisans.Where(item => Object.Equals(item.ngay, null) == false).Where(item => ((DateTime)item.ngay).Year <= Year).OrderByDescending(item => item.date_create).DistinctBy(item => item.taisan_id).Select(x => new
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
            }).ToList();
            return Data;
        }

        /// <summary>
        /// Sai la cai chac, biet cho sai nhung khong them sua :v
        /// </summary>
        /// <param name="DonViId"></param>
        /// <returns></returns>
        private Object GetData_SoTheoDoiTaiSanCoDinhTaiNoiSuDung(Guid DonViId)
        {
            ResetDbContext();
            int Year = DateTime.Today.Year;
            IQueryable<CTTaiSan> IQueryable = MyNewDbContext.CTTAISANS.AsQueryable<CTTaiSan>();
            IQueryable = IQueryable.Where(x => x.soluong > 0);
            IQueryable = IQueryable.Where(item => Object.Equals(item.ngay, null) == false);
            IQueryable = IQueryable.Where(item => ((DateTime)item.ngay).Year <= Year);

            DonVi DonViSelected = MyNewDbContext.DONVIS.Find(DonViId);

            if (Object.Equals(DonViSelected, null))
            {
                return new Object();
            }
            List<Guid> ListGuid = DonViSelected.getAllChildsRecursive().Select(x => x.id).ToList();
            IQueryable = IQueryable.Where(x => x.donviquanly != null && ListGuid.Contains(x.donviquanly.id));

            var Data = DonViSelected.cttaisans.Where(item => Object.Equals(item.ngay, null) == false).Where(item => ((DateTime)item.ngay).Year <= Year).OrderByDescending(item => item.date_create).DistinctBy(item => item.taisan_id).Select(x => new
            {
                //Phai dung nhung chi tiet tai san cua tai san de tinh toan tang, giam
                sohieu_ct = x.chungtu != null ? x.chungtu.sohieu : "",
                ngay_ct = x.chungtu != null ? x.chungtu.ngay : null,

                ten = x.taisan.ten,
                donvitinh = x.taisan.loaitaisan.donvitinh != null ? x.taisan.loaitaisan.donvitinh.ten : "",

                //Phai kiem chi tiet tai san cua tai san nay ma no lam tang tai san
                soluong_tang = !x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                dongia_tang = !x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                thanhtien_tang = !x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,

                //Chi tiet tai san cua tai san nay ma no lam giam tai san
                soluong_giam = x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                dongia_giam = x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                thanhtien_giam = x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,

                ghichu = x.tinhtrang.giam_taisan ? x.mota : "",
            }).ToList();
            return Data;
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