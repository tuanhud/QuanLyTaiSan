using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using TSCD.Entities;
using SHARED.Libraries;
using DevExpress.XtraGrid.Views.BandedGrid;
using TSCD.DataFilter.SearchFilter;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Xml;

namespace TSCD_GUI.QLTaiSan
{
    public partial class ucQuanLyTaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyTaiSan()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlTaiSan.Parent = null;
            ucGridControlTaiSan1.fileName = this.Name;
            ucGridControlTaiSan1.createLayout();
            ucComboBoxLoaiTS1.editValueChanged = new MyUserControl.ucComboBoxLoaiTS.EditValueChanged(CheckedLoaiTS);
            ucComboBoxViTri1.editValueChanged = new MyUserControl.ucComboBoxViTri.EditValueChanged(CheckedViTri);
            ucComboBoxDonVi1.editValueChanged = new MyUserControl.ucComboBoxDonVi.EditValueChanged(CheckedDonVi);
        }

        public void loadData()
        {
            try
            {
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
                //gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
                //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                ucComboBoxLoaiTS1.DataSource = LoaiTSHienThi.Convert(LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten));
                List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                DonVi objNULL = new DonVi();
                objNULL.id = Guid.Empty;
                objNULL.ten = "[Không có đơn vị]";
                objNULL.parent = null;
                list.Insert(0, objNULL);
                ucComboBoxDonVi1.DataSource = list;
                ucComboBoxDonVi1.DonVi = objNULL;

                List<ViTriHienThi> listViTri = ViTriHienThi.getAllHavePhong();
                ViTriHienThi objNULL2 = new ViTriHienThi();
                objNULL2.id = Guid.Empty;
                objNULL2.ten = "[Không có vị trí]";
                objNULL2.parent_id = Guid.Empty;
                objNULL2.loai = typeof(Phong).Name;
                listViTri.Insert(0, objNULL2);
                ucComboBoxViTri1.DataSource = listViTri;
                //ucComboBoxDonVi2.DonVi = objNULL;
                ucGridControlTaiSan1.DataSource = null;
                barBtnSuaTaiSan.Enabled = false;
                barBtnXoaTaiSan.Enabled = false;
                btnSua_r.Enabled = false;
                btnXoa_r.Enabled = false;

                loadSearchXml(this.Name);
                Search();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }
        }

        public void Search()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            try
            {
                //String ten = checkTen.Checked ? txtTen.Text : null;
                String ten = txtTen.Text;
                LoaiTaiSan loai = checkLoai.Checked ? ucComboBoxLoaiTS1.LoaiTS : null;
                DonVi DVQL = ucComboBoxDonVi1.DonVi;
                ViTri vitri = ucComboBoxViTri1.ViTri;
                Phong phong = ucComboBoxViTri1.Phong;
                bool isViTri = true;
                if (vitri == null)
                    isViTri = false;
                List<TaiSanHienThi> list = TaiSanHienThi.Convert(CTTaiSanSF.search(ten, loai, checkDVQL.Checked, DVQL, false, null, isViTri && checkViTri.Checked, vitri, !isViTri && checkViTri.Checked, phong));
                ucGridControlTaiSan1.DataSource = list;
                

                bool isEnabled = list.Count > 0;
                barBtnSuaTaiSan.Enabled = isEnabled;
                barBtnXoaTaiSan.Enabled = isEnabled;
                btnSua_r.Enabled = isEnabled;
                btnXoa_r.Enabled = isEnabled;

                saveSearchXml(this.Name);
                ucGridControlTaiSan1.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->Search:" + ex.Message);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlTaiSan;
        }

        public CTTaiSan CTTaiSan
        {
            get
            {
                try
                {
                    return ucGridControlTaiSan1.CTTaiSan;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->getCTTaiSan:" + ex.Message);
                    return null;
                }
            }
        }


        private void reloadAndFocused(Guid _id)
        {
            try
            {
                Search();
                ucGridControlTaiSan1.reloadAndFocused(_id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadAndFocused:" + ex.Message);
            }
        }

        private void barBtnThemTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddTaiSan frm = new frmAddTaiSan();
            frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void barBtnSuaTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmAddTaiSan frm = new frmAddTaiSan(obj);
                frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void barBtnTinhTrang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQuanLyTinhTrang frm = new frmQuanLyTinhTrang();
            frm.ShowDialog();
        }

        private void btnThem_r_Click(object sender, EventArgs e)
        {
            frmAddTaiSan frm = new frmAddTaiSan();
            frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void btnSua_r_Click(object sender, EventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmAddTaiSan frm = new frmAddTaiSan(obj);
                frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void btnXoa_r_Click(object sender, EventArgs e)
        {
            deleteObj();
        }

        private void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
            open.Title = "Chọn tập tin để Import";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportTaiSan(open.FileName, "TaiSan"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                }
            }
        }

        private void barBtnXuatBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTSCD.frmReport _frmReport = new ReportTSCD.frmReport();
            _frmReport.ShowDialog();
            /*TSCD_GUI.ReportTSCD.XtraReportTSCD_Grid _XtraReportTSCD_Grid = new ReportTSCD.XtraReportTSCD_Grid(ucGridControlTaiSan1.gridControlTaiSan);
            ReportPrintTool _ReportPrintTool = new ReportPrintTool(_XtraReportTSCD_Grid);
            _ReportPrintTool.ShowPreviewDialog();*/

            //ReportTSCD.XtraReportTSCD _XtraReportTSCD = new ReportTSCD.XtraReportTSCD(ucGridControlTaiSan1.gridControlTaiSan);
        }

        /*private void barBtnThietKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TSCD_GUI.ReportTSCD.XtraReportTSCD_Grid _XtraReportTSCD_Grid = new ReportTSCD.XtraReportTSCD_Grid(ucGridControlTaiSan1.gridControlTaiSan);
            ReportDesignTool _ReportDesignTool = new ReportDesignTool(_XtraReportTSCD_Grid);

            _ReportDesignTool.ShowDesignerDialog();
            ReportPrintTool _ReportPrintTool = new ReportPrintTool(_ReportDesignTool.Report);
            _ReportPrintTool.ShowPreviewDialog();
        }*/

        private void barBtnDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGridControlTaiSan1.loadLayout(true);
        }

        public void saveSearchXml(String fileName)
        {
            try
            {
                String currentPath = Directory.GetCurrentDirectory();
                String path = Path.Combine(currentPath, "Search");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                String file = path + "//" + fileName + "_Search.xml";
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                XmlWriter writer = XmlWriter.Create(file, settings);
                writer.WriteStartDocument();
                //writer.WriteComment("");
                writer.WriteStartElement("Search");
                //writer.WriteAttributeString("cTen", checkTen.Checked ? "1" : "0");
                writer.WriteAttributeString("vTen", txtTen.Text);
                writer.WriteAttributeString("cLoai", checkLoai.Checked ? "1" : "0");
                LoaiTaiSan loai = ucComboBoxLoaiTS1.LoaiTS;
                writer.WriteAttributeString("vLoai", loai != null ? loai.id.ToString() : "");
                writer.WriteAttributeString("cDVQL", checkDVQL.Checked ? "1" : "0");
                DonVi dvql = ucComboBoxDonVi1.DonVi;
                writer.WriteAttributeString("vDVQL", dvql != null ? dvql.id.ToString() : "");
                writer.WriteAttributeString("cViTri", checkViTri.Checked ? "1" : "0");
                Guid id = GUID.From(ucComboBoxViTri1.EditValue);
                writer.WriteAttributeString("vViTri", id != Guid.Empty ? id.ToString() : "");
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->saveSearchXml:" + ex.Message);
            }
        }

        public void loadSearchXml(String fileName)
        {
            try
            {
                String currentPath = Directory.GetCurrentDirectory();
                String path = Path.Combine(currentPath, "Search");
                if (Directory.Exists(path))
                {
                    String file = path + "//" + fileName + "_Search.xml";
                    if (!File.Exists(file))
                    {
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        XmlWriter writer_new = XmlWriter.Create(file, settings);
                        writer_new.WriteStartDocument();
                        writer_new.WriteStartElement("Search");
                        writer_new.WriteAttributeString("vTen", "Không có");
                        writer_new.WriteAttributeString("cLoai", "0");
                        writer_new.WriteAttributeString("vLoai", "");
                        writer_new.WriteAttributeString("cDVQL", "0");
                        writer_new.WriteAttributeString("vDVQL", "");
                        writer_new.WriteAttributeString("cViTri", "0");
                        writer_new.WriteAttributeString("vViTri", "");
                        writer_new.WriteEndElement();
                        writer_new.WriteEndDocument();
                        writer_new.Flush();
                        writer_new.Close();
                    }
                    if (System.IO.File.Exists(file))
                    {
                        XmlReader reader = XmlReader.Create(file);
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Search")
                            {
                                //checkTen.Checked = Convert.ToInt32(reader.GetAttribute(0)).Equals(1) ? true : false;
                                txtTen.Text = reader.GetAttribute(0);
                                ucComboBoxLoaiTS1.LoaiTS = LoaiTaiSan.getById(GUID.From(reader.GetAttribute(2)));
                                checkLoai.Checked = Convert.ToInt32(reader.GetAttribute(1)).Equals(1) ? true : false;
                                ucComboBoxDonVi1.DonVi = DonVi.getById(GUID.From(reader.GetAttribute(4)));
                                checkDVQL.Checked = Convert.ToInt32(reader.GetAttribute(3)).Equals(1) ? true : false;
                                ucComboBoxViTri1.EditValue = GUID.From(reader.GetAttribute(6));
                                checkViTri.Checked = Convert.ToInt32(reader.GetAttribute(5)).Equals(1) ? true : false;
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadSearchXml:" + ex.Message);
            }
        }

        private void barBtnImportChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
            open.Title = "Chọn tập tin để Import";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportChungTu(open.FileName, "ChungTu"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                }

            }
        }

        private void barBtnChuyenTinhTrang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmChuyenTinhTrang frm = new frmChuyenTinhTrang(obj);
                frm.reloadAndFocused = new frmChuyenTinhTrang.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void barBtnXoaTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        private void deleteObj()
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                if (XtraMessageBox.Show("Tài sản bị xóa sẽ mất log và không thể thống kê được nữa. \n Bạn có chắc là muốn xóa tài sản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (obj.taisan.delete() > 0 && DBInstance.commit() > 0)
                    {
                        XtraMessageBox.Show("Xóa tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Search();
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void barBtnAttachment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmFileChungTu frm = new frmFileChungTu(obj.chungtu, true);
                frm.ShowDialog();
            }
        }

        private void barBtnChuyenDonVi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmInputViTri_DonVi frm = new frmInputViTri_DonVi(obj);
                frm.reloadAndFocused = new frmInputViTri_DonVi.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTen.Text = "";
            checkLoai.Checked = false;
            ucComboBoxLoaiTS1.EditValue = null;
            checkDVQL.Checked = false;
            ucComboBoxDonVi1.DonVi = null;
            checkViTri.Checked = false;
            ucComboBoxViTri1.EditValue = Guid.Empty;
        }

        private void barBtnExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGridControlTaiSan1.ExpandAllGroups();
        }

        private void barBtnCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGridControlTaiSan1.CollapseAllGroups();
        }

        private void CheckedLoaiTS()
        {
            checkLoai.Checked = true;
        }

        private void CheckedViTri()
        {
            checkViTri.Checked = true;
        }

        private void CheckedDonVi()
        {
            checkDVQL.Checked = true;
        }
    }
}
