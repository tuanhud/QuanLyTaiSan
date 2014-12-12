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

namespace TSCD_GUI.ReportTSCD
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        List<DonVi> ListDonVi = new List<DonVi>();
        int HeightNormal = 270, HeightHaveProgress = 320;
        OurDBContext MyNewDbContext = null;

        public delegate void SendMessage();
        public SendMessage _SendMessage;
        System.Threading.Thread _ThreadReport;

        public frmReport()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(this.Size.Width, HeightNormal);

            comboBoxEdit_LoaiBaoCao.SelectedIndex = 0;

            dateEdit_TuNgay.EditValue = DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = DateTime.Today.Date;

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
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 1:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = true;
                    break;
                case 2:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 3:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
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
                    if (((DateTime)dateEdit_TuNgay.EditValue).Date > DateTime.Today.Date)
                    {
                        XtraMessageBox.Show("Ngày từ không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_TuNgay.Focus();
                        return;
                    }
                    if (((DateTime)dateEdit_DenNgay.EditValue).Date > DateTime.Today.Date)
                    {
                        XtraMessageBox.Show("Ngày đến không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_DenNgay.Focus();
                        return;
                    }
                    if (((DateTime)dateEdit_TuNgay.EditValue).Date > ((DateTime)dateEdit_DenNgay.EditValue).Date)
                    {
                        XtraMessageBox.Show("Ngày từ không được lớn hơn ngày đến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_TuNgay.Focus();
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            if (!Object.Equals(MyNewDbContext, null))
                            {
                                MyNewDbContext.Dispose();
                                MyNewDbContext = null;
                            }
                            MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);

                            DateTime From = ((DateTime)dateEdit_TuNgay.EditValue).Date, To = ((DateTime)dateEdit_DenNgay.EditValue).Date;
                            List<TK_TangGiam_TheoLoaiTS> Data = new List<TK_TangGiam_TheoLoaiTS>();

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

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_BaoCaoTangGiamTSCD _XtraReport_BaoCaoTangGiamTSCD = new ReportTSCD.XtraReport_BaoCaoTangGiamTSCD(Data, From, To);
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_BaoCaoTangGiamTSCD);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            if (!Object.Equals(MyNewDbContext, null))
                            {
                                MyNewDbContext.Dispose();
                                MyNewDbContext = null;
                            }
                            MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);

                            DateTime From = ((DateTime)dateEdit_TuNgay.EditValue).Date, To = ((DateTime)dateEdit_DenNgay.EditValue).Date;
                            List<TK_TangGiam_TheoLoaiTS> Data = new List<TK_TangGiam_TheoLoaiTS>();

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

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_BaoCaoTangGiamTSCD _XtraReport_BaoCaoTangGiamTSCD = new ReportTSCD.XtraReport_BaoCaoTangGiamTSCD(Data, From, To);
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_BaoCaoTangGiamTSCD);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
                    break;

                #endregion

                #region Sổ tài sản cố định

                case 1:
                    List<Guid> ListLoaiTS = ucComboBoxLoaiTS_LoaiTaiSan.list_loaitaisan;
                    if (Object.Equals(ListLoaiTS, null))
                    {
                        XtraMessageBox.Show("Chưa chọn loại tài sản cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!(ListLoaiTS.Count > 0))
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
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            if (!Object.Equals(MyNewDbContext, null))
                            {
                                MyNewDbContext.Dispose();
                                MyNewDbContext = null;
                            }
                            MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);
                            List<TaiSan_ThongKe> Data = new List<TaiSan_ThongKe>();
                            DonVi donvi = null;

                            IQueryable<CTTaiSan> query = MyNewDbContext.CTTAISANS.AsQueryable<CTTaiSan>();
                            query = query.Where(x => x.soluong > 0);
                            if (donvi != null)
                            {
                                List<Guid> list_donviquanly = donvi.getAllChildsRecursive().Select(x => x.id).ToList();
                                query = query.Where(x => x.donviquanly != null && list_donviquanly.Contains(x.donviquanly.id));
                            }
                            //LTB
                            if (ListLoaiTS != null && ListLoaiTS.Count > 0)
                            {
                                query = query.Where(x => x.taisan.loaitaisan == null || ListLoaiTS.Contains(x.taisan.loaitaisan.id));
                            }
                            //COSO
                            if (ListCoSo != null && ListCoSo.Count > 0)
                            {
                                List<Guid> list_phong = Phong.getQuery().Where(x => ListCoSo.Contains(x.vitri.coso.id)).Select(c => c.id).ToList();
                                query = query.Where(x => ListCoSo.Contains(x.vitri.coso.id) || list_phong.Contains(x.phong.id));
                            }
                            Data = query.Select(x => new TaiSan_ThongKe
                            {
                                id = x.id,
                                ngay = x.ngay,
                                sohieu_ct = x.chungtu != null ? x.chungtu.sohieu : "",
                                ngay_ct = x.chungtu != null ? x.chungtu.ngay : null,
                                ten = x.taisan.ten,
                                loaits = x.taisan.loaitaisan.ten,
                                donvitinh = x.taisan.loaitaisan.donvitinh != null ? x.taisan.loaitaisan.donvitinh.ten : "",
                                soluong_tang = !x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                dongia_tang = !x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                thanhtien_tang = !x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                soluong_giam = x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                dongia_giam = x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                thanhtien_giam = x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                sohieu_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                ngay_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                sohieu_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                ngay_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                nuocsx = x.taisan.nuocsx,
                                nguongoc = x.nguongoc,
                                tinhtrang = x.tinhtrang.value,
                                ghichu = x.mota,
                                childs = x.childs,
                                phong = x.phong != null ? x.phong.ten : "",
                                vitri = x.vitri != null ? (x.vitri.coso != null ? x.vitri.coso.ten + (x.vitri.day != null ? " - " +
                                x.vitri.day.ten + (x.vitri.tang != null ? " - " + x.vitri.tang.ten : "") : "") : "") : "",
                                dvquanly = x.donviquanly != null ? x.donviquanly.ten : "",
                                dvsudung = x.donvisudung != null ? x.donvisudung.ten : "",
                                phantramhaomon_32 = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : x.taisan.loaitaisan.phantramhaomon_32 * 100,
                                sotientrongmotnam = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : (long)(x.taisan.dongia * x.taisan.loaitaisan.phantramhaomon_32),
                            }).ToList();

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_SoTaiSanCoDinh _XtraReport_SoTaiSanCoDinh = new ReportTSCD.XtraReport_SoTaiSanCoDinh(Data);
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoTaiSanCoDinh);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            if (!Object.Equals(MyNewDbContext, null))
                            {
                                MyNewDbContext.Dispose();
                                MyNewDbContext = null;
                            }
                            MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);
                            List<TaiSan_ThongKe> Data = new List<TaiSan_ThongKe>();
                            DonVi donvi = null;

                            IQueryable<CTTaiSan> query = MyNewDbContext.CTTAISANS.AsQueryable<CTTaiSan>();
                            query = query.Where(x => x.soluong > 0);
                            if (donvi != null)
                            {
                                List<Guid> list_donviquanly = donvi.getAllChildsRecursive().Select(x => x.id).ToList();
                                query = query.Where(x => x.donviquanly != null && list_donviquanly.Contains(x.donviquanly.id));
                            }
                            //LTB
                            if (ListLoaiTS != null && ListLoaiTS.Count > 0)
                            {
                                query = query.Where(x => x.taisan.loaitaisan == null || ListLoaiTS.Contains(x.taisan.loaitaisan.id));
                            }
                            //COSO
                            if (ListCoSo != null && ListCoSo.Count > 0)
                            {
                                List<Guid> list_phong = Phong.getQuery().Where(x => ListCoSo.Contains(x.vitri.coso.id)).Select(c => c.id).ToList();
                                query = query.Where(x => ListCoSo.Contains(x.vitri.coso.id) || list_phong.Contains(x.phong.id));
                            }
                            Data = query.Select(x => new TaiSan_ThongKe
                            {
                                id = x.id,
                                ngay = x.ngay,
                                sohieu_ct = x.chungtu != null ? x.chungtu.sohieu : "",
                                ngay_ct = x.chungtu != null ? x.chungtu.ngay : null,
                                ten = x.taisan.ten,
                                loaits = x.taisan.loaitaisan.ten,
                                donvitinh = x.taisan.loaitaisan.donvitinh != null ? x.taisan.loaitaisan.donvitinh.ten : "",
                                soluong_tang = !x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                dongia_tang = !x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                thanhtien_tang = !x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                soluong_giam = x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                dongia_giam = x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                thanhtien_giam = x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                sohieu_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                ngay_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                sohieu_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                ngay_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                nuocsx = x.taisan.nuocsx,
                                nguongoc = x.nguongoc,
                                tinhtrang = x.tinhtrang.value,
                                ghichu = x.mota,
                                childs = x.childs,
                                phong = x.phong != null ? x.phong.ten : "",
                                vitri = x.vitri != null ? (x.vitri.coso != null ? x.vitri.coso.ten + (x.vitri.day != null ? " - " +
                                x.vitri.day.ten + (x.vitri.tang != null ? " - " + x.vitri.tang.ten : "") : "") : "") : "",
                                dvquanly = x.donviquanly != null ? x.donviquanly.ten : "",
                                dvsudung = x.donvisudung != null ? x.donvisudung.ten : "",
                                phantramhaomon_32 = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : x.taisan.loaitaisan.phantramhaomon_32 * 100,
                                sotientrongmotnam = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : (long)(x.taisan.dongia * x.taisan.loaitaisan.phantramhaomon_32),
                            }).ToList();

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_SoTaiSanCoDinh _XtraReport_SoTaiSanCoDinh = new ReportTSCD.XtraReport_SoTaiSanCoDinh(Data);
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoTaiSanCoDinh);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
                    break;

                #endregion

                #region Sổ chi tiết tài sản cố định

                case 2:
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
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                            DonVi DonViToProcess = null;
                            List<TaiSanHienThi> Data = new List<TaiSanHienThi>();
                            if (!Object.Equals(DonViSelected, null))
                            {
                                if (!Object.Equals(MyNewDbContext, null))
                                {
                                    MyNewDbContext.Dispose();
                                    MyNewDbContext = null;
                                }
                                MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);
                                DonViToProcess = MyNewDbContext.DONVIS.Find(DonViSelected.id);

                                Data = DonViToProcess.cttaisans.Select(ct => new TaiSanHienThi
                                {
                                    id = ct.id,
                                    ngay = ct.ngay,
                                    sohieu_ct = ct.chungtu != null ? ct.chungtu.sohieu : "",
                                    ngay_ct = ct.chungtu != null ? ct.chungtu.ngay : null,
                                    ten = ct.taisan.ten,
                                    loaits = ct.taisan.loaitaisan.ten,
                                    donvitinh = ct.taisan.loaitaisan.donvitinh != null ? ct.taisan.loaitaisan.donvitinh.ten : "",
                                    soluong = ct.soluong,
                                    dongia = ct.taisan.dongia,
                                    thanhtien = ct.soluong * ct.taisan.dongia,
                                    nuocsx = ct.taisan.nuocsx,
                                    nguongoc = ct.nguongoc,
                                    tinhtrang = ct.tinhtrang.value,
                                    ghichu = ct.mota,
                                    childs = ct.childs,
                                    phong = ct.phong != null ? ct.phong.ten : "",
                                    vitri = ct.vitri != null ? (ct.vitri.coso != null ? ct.vitri.coso.ten + (ct.vitri.day != null ? " - " +
                                    ct.vitri.day.ten + (ct.vitri.tang != null ? " - " + ct.vitri.tang.ten : "") : "") : "") : "",
                                    dvquanly = ct.donviquanly != null ? ct.donviquanly.ten : "",
                                    dvsudung = ct.donvisudung != null ? ct.donvisudung.ten : "",
                                    obj = ct,
                                }).ToList();
                            }

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh _XtraReport_SoChiTietTaiSanCoDinh = new ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh(Data, DonViToProcess);
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoChiTietTaiSanCoDinh);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                            DonVi DonViToProcess = null;
                            List<TaiSanHienThi> Data = new List<TaiSanHienThi>();
                            if (!Object.Equals(DonViSelected, null))
                            {
                                if (!Object.Equals(MyNewDbContext, null))
                                {
                                    MyNewDbContext.Dispose();
                                    MyNewDbContext = null;
                                }
                                MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);
                                DonViToProcess = MyNewDbContext.DONVIS.Find(DonViSelected.id);

                                Data = DonViToProcess.cttaisans.Select(ct => new TaiSanHienThi
                                {
                                    id = ct.id,
                                    ngay = ct.ngay,
                                    sohieu_ct = ct.chungtu != null ? ct.chungtu.sohieu : "",
                                    ngay_ct = ct.chungtu != null ? ct.chungtu.ngay : null,
                                    ten = ct.taisan.ten,
                                    loaits = ct.taisan.loaitaisan.ten,
                                    donvitinh = ct.taisan.loaitaisan.donvitinh != null ? ct.taisan.loaitaisan.donvitinh.ten : "",
                                    soluong = ct.soluong,
                                    dongia = ct.taisan.dongia,
                                    thanhtien = ct.soluong * ct.taisan.dongia,
                                    nuocsx = ct.taisan.nuocsx,
                                    nguongoc = ct.nguongoc,
                                    tinhtrang = ct.tinhtrang.value,
                                    ghichu = ct.mota,
                                    childs = ct.childs,
                                    phong = ct.phong != null ? ct.phong.ten : "",
                                    vitri = ct.vitri != null ? (ct.vitri.coso != null ? ct.vitri.coso.ten + (ct.vitri.day != null ? " - " +
                                    ct.vitri.day.ten + (ct.vitri.tang != null ? " - " + ct.vitri.tang.ten : "") : "") : "") : "",
                                    dvquanly = ct.donviquanly != null ? ct.donviquanly.ten : "",
                                    dvsudung = ct.donvisudung != null ? ct.donvisudung.ten : "",
                                    obj = ct,
                                }).ToList();
                            }

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh _XtraReport_SoChiTietTaiSanCoDinh = new ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh(Data, DonViToProcess);
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoChiTietTaiSanCoDinh);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
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
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                            DonVi DonViToProcess = null;
                            List<TaiSan_ThongKe> Data = new List<TaiSan_ThongKe>();
                            if (!Object.Equals(DonViSelected, null))
                            {
                                if (!Object.Equals(MyNewDbContext, null))
                                {
                                    MyNewDbContext.Dispose();
                                    MyNewDbContext = null;
                                }
                                MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);
                                DonViToProcess = MyNewDbContext.DONVIS.Find(DonViSelected.id);

                                IQueryable<CTTaiSan> query = MyNewDbContext.CTTAISANS.AsQueryable<CTTaiSan>();
                                query = query.Where(x => x.soluong > 0);
                                if (DonViToProcess != null)
                                {
                                    List<Guid> list_donviquanly = DonViToProcess.getAllChildsRecursive().Select(x => x.id).ToList();
                                    query = query.Where(x => x.donviquanly != null && list_donviquanly.Contains(x.donviquanly.id));
                                }
                                //FINAL SELECT
                                Data = query.Select(x => new TaiSan_ThongKe
                                {
                                    id = x.id,
                                    ngay = x.ngay,
                                    sohieu_ct = x.chungtu != null ? x.chungtu.sohieu : "",
                                    ngay_ct = x.chungtu != null ? x.chungtu.ngay : null,
                                    ten = x.taisan.ten,
                                    loaits = x.taisan.loaitaisan.ten,
                                    donvitinh = x.taisan.loaitaisan.donvitinh != null ? x.taisan.loaitaisan.donvitinh.ten : "",
                                    soluong_tang = !x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                    dongia_tang = !x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                    thanhtien_tang = !x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                    soluong_giam = x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                    dongia_giam = x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                    thanhtien_giam = x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                    sohieu_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                    ngay_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                    sohieu_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                    ngay_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                    nuocsx = x.taisan.nuocsx,
                                    nguongoc = x.nguongoc,
                                    tinhtrang = x.tinhtrang.value,
                                    ghichu = x.mota,
                                    childs = x.childs,
                                    phong = x.phong != null ? x.phong.ten : "",
                                    vitri = x.vitri != null ? (x.vitri.coso != null ? x.vitri.coso.ten + (x.vitri.day != null ? " - " +
                                    x.vitri.day.ten + (x.vitri.tang != null ? " - " + x.vitri.tang.ten : "") : "") : "") : "",
                                    dvquanly = x.donviquanly != null ? x.donviquanly.ten : "",
                                    dvsudung = x.donvisudung != null ? x.donvisudung.ten : "",
                                    phantramhaomon_32 = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : x.taisan.loaitaisan.phantramhaomon_32 * 100,
                                    sotientrongmotnam = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : (long)(x.taisan.dongia * x.taisan.loaitaisan.phantramhaomon_32),
                                }
                                ).ToList();
                            }

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(Data, DonViToProcess);
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_PhongBan);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            #region Get Data

                            var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                            DonVi DonViToProcess = null;
                            List<TaiSan_ThongKe> Data = new List<TaiSan_ThongKe>();
                            if (!Object.Equals(DonViSelected, null))
                            {
                                if (!Object.Equals(MyNewDbContext, null))
                                {
                                    MyNewDbContext.Dispose();
                                    MyNewDbContext = null;
                                }
                                MyNewDbContext = new OurDBContext(TSCD.Global.working_database.get_connection_string(), false);
                                DonViToProcess = MyNewDbContext.DONVIS.Find(DonViSelected.id);

                                IQueryable<CTTaiSan> query = MyNewDbContext.CTTAISANS.AsQueryable<CTTaiSan>();
                                query = query.Where(x => x.soluong > 0);
                                if (DonViToProcess != null)
                                {
                                    List<Guid> list_donviquanly = DonViToProcess.getAllChildsRecursive().Select(x => x.id).ToList();
                                    query = query.Where(x => x.donviquanly != null && list_donviquanly.Contains(x.donviquanly.id));
                                }
                                //FINAL SELECT
                                Data = query.Select(x => new TaiSan_ThongKe
                                {
                                    id = x.id,
                                    ngay = x.ngay,
                                    sohieu_ct = x.chungtu != null ? x.chungtu.sohieu : "",
                                    ngay_ct = x.chungtu != null ? x.chungtu.ngay : null,
                                    ten = x.taisan.ten,
                                    loaits = x.taisan.loaitaisan.ten,
                                    donvitinh = x.taisan.loaitaisan.donvitinh != null ? x.taisan.loaitaisan.donvitinh.ten : "",
                                    soluong_tang = !x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                    dongia_tang = !x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                    thanhtien_tang = !x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                    soluong_giam = x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                                    dongia_giam = x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                                    thanhtien_giam = x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                                    sohieu_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                    ngay_ct_tang = !x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                    sohieu_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.sohieu : "") : "",
                                    ngay_ct_giam = x.tinhtrang.giam_taisan ? (x.chungtu != null ? x.chungtu.ngay : null) : null,
                                    nuocsx = x.taisan.nuocsx,
                                    nguongoc = x.nguongoc,
                                    tinhtrang = x.tinhtrang.value,
                                    ghichu = x.mota,
                                    childs = x.childs,
                                    phong = x.phong != null ? x.phong.ten : "",
                                    vitri = x.vitri != null ? (x.vitri.coso != null ? x.vitri.coso.ten + (x.vitri.day != null ? " - " +
                                    x.vitri.day.ten + (x.vitri.tang != null ? " - " + x.vitri.tang.ten : "") : "") : "") : "",
                                    dvquanly = x.donviquanly != null ? x.donviquanly.ten : "",
                                    dvsudung = x.donvisudung != null ? x.donvisudung.ten : "",
                                    phantramhaomon_32 = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : x.taisan.loaitaisan.phantramhaomon_32 * 100,
                                    sotientrongmotnam = Object.Equals(x.taisan, null) ? 0 : Object.Equals(x.taisan.loaitaisan, null) ? 0 : (long)(x.taisan.dongia * x.taisan.loaitaisan.phantramhaomon_32),
                                }
                                ).ToList();
                            }

                            #endregion

                            TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(Data, DonViToProcess);
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_PhongBan);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.SetApartmentState(ApartmentState.STA);
                        _ThreadReport.Start();
                    }
                    break;

                #endregion

                case 4:
                    XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
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