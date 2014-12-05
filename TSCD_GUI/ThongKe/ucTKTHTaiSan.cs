using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using TSCD.DataFilter;
using SHARED.Libraries;
using TSCD.DataFilter.SearchFilter;
using TSCD_GUI.Libraries;
using System.IO;

namespace TSCD_GUI.ThongKe
{
    public partial class ucTKTHTaiSan : DevExpress.XtraEditors.XtraUserControl
    {

        public List<TaiSanHienThi> taisans = new List<TaiSanHienThi>();

        public ucTKTHTaiSan()
        {
            InitializeComponent();
            init();
            createLayout();
        }

        private void init()
        {
            //ucGridControlTaiSan1.fileName = this.Name;
            //ucGridControlTaiSan1.createLayout();
            ucComboBoxLoaiTS1.editValueChanged = new MyUserControl.ucComboBoxLoaiTS.EditValueChanged(CheckedLoaiTS);
            ucComboBoxViTri1.editValueChanged = new MyUserControl.ucComboBoxViTri.EditValueChanged(CheckedViTri);
            ucComboBoxDonVi1.editValueChanged = new MyUserControl.ucComboBoxDonVi.EditValueChanged(CheckedDonVi);
        }

        public void loadData()
        {
            try
            {
                loadLayout();
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
                //gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
                //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                checkedCbxTinhTrang.Properties.DataSource = TinhTrang.getQuery().OrderBy(c => c.order).ToList();

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

                gridControlTaiSan.DataSource = null;
                taisans = null;
                //loadSearchXml(this.Name);
                //Search();

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }

        }

        private void CheckedLoaiTS()
        {
            checkLoaiTS.Checked = true;
        }

        private void CheckedViTri()
        {
            checkViTri.Checked = true;
        }

        private void CheckedDonVi()
        {
            checkDonVi.Checked = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dateNgaySD.DateTime = DateTime.Now;
            checkedCbxTinhTrang.SetEditValue(null);
            ucComboBoxLoaiTS1.EditValue = null;
            checkLoaiTS.Checked = false;
            ucComboBoxDonVi1.EditValue = Guid.Empty;
            checkDonVi.Checked = false;
            ucComboBoxViTri1.EditValue = Guid.Empty;
            checkViTri.Checked = false;
            dateNgaySD.EditValue = null;
            spinDonGia.EditValue = null;
            if (cbxEquationNgaySD.Properties.Items.Count > 0)
                cbxEquationNgaySD.SelectedIndex = 0;
            if (cbxEquationDonGia.Properties.Items.Count > 0)
                cbxEquationDonGia.SelectedIndex = 0;
        }

        public void Search()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            try
            {
                //String ten = checkTen.Checked ? txtTen.Text : null;
                //String ten = txtTen.Text;
                List<Guid> tinhtrangs = CheckedComboBoxEditHelper.getCheckedValueArray(checkedCbxTinhTrang);
                LoaiTaiSan loai = checkLoaiTS.Checked ? ucComboBoxLoaiTS1.LoaiTS : null;
                DonVi DVQL = ucComboBoxDonVi1.DonVi;
                ViTri vitri = ucComboBoxViTri1.ViTri;
                Phong phong = ucComboBoxViTri1.Phong;
                bool isViTri = true;
                if (vitri == null)
                    isViTri = false;
                List<TaiSanHienThi> list = TaiSanHienThi.Convert(CTTaiSanSF.search(null, loai, checkDonVi.Checked, DVQL, false, null, isViTri && checkViTri.Checked, vitri, !isViTri && checkViTri.Checked, phong, tinhtrangs, 
                    cbxEquationDonGia.EditValue != null ? cbxEquationDonGia.EditValue.ToString() : null, spinDonGia.EditValue != null ? (long?)long.Parse(spinDonGia.EditValue.ToString()) : null,
                    cbxEquationNgaySD.EditValue != null ? cbxEquationNgaySD.EditValue.ToString() : null, dateNgaySD.EditValue != null ? (DateTime?)dateNgaySD.DateTime : null));
                //ucGridControlTaiSan1.DataSource = list;
                gridControlTaiSan.DataSource = list;
                taisans = list;
                //bool isEnabled = list.Count > 0;
                //barBtnSuaTaiSan.Enabled = isEnabled;
                //barBtnXoaTaiSan.Enabled = isEnabled;
                //btnSua_r.Enabled = isEnabled;
                //btnXoa_r.Enabled = isEnabled;

                //saveSearchXml(this.Name);
                //ucGridControlTaiSan1.CollapseAllGroups();
                gridViewTaiSan.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->Search:" + ex.Message);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Search();
        }

        List<Object> listToSummary = new List<Object>();
        private void gridViewTaiSan_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                    listToSummary.Add(e.FieldValue);
                else
                {
                    List<Object> tmp = listToSummary.Distinct().ToList();
                    tmp.Remove("");
                    e.TotalValue = tmp.Count();
                    listToSummary.Clear();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->gridViewTaiSan_CustomSummaryCalculate:" + ex.Message);
            }
        }

        public void ExpandAllGroups()
        {
            gridViewTaiSan.ExpandAllGroups();
        }

        public void CollapseAllGroups()
        {
            gridViewTaiSan.CollapseAllGroups();
        }

        public void createLayout()
        {
            String currentPath = Directory.GetCurrentDirectory();
            String path = Path.Combine(currentPath, "Layout");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            String fileMaster = path + "//" + this.Name + "_Master_Default.xml";
            //String fileDetail = path + "//" + fileName + "_Detail_Default.xml";
            if (!System.IO.File.Exists(fileMaster))
            {
                gridViewTaiSan.SaveLayoutToXml(fileMaster);
            }
            //if (!System.IO.File.Exists(fileDetail))
            //{
            //    bandedGridViewTaiSan.SaveLayoutToXml(fileDetail);
            //}
        }

        public void saveLayout()
        {
            String currentPath = Directory.GetCurrentDirectory();
            String path = Path.Combine(currentPath, "Layout");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            String fileMaster = path + "//" + this.Name + "_Master_Current.xml";
            //String fileDetail = path + "//" + fileName + "_Detail_Current.xml";
            gridViewTaiSan.SaveLayoutToXml(fileMaster);
            //bandedGridViewTSKemTheo.SaveLayoutToXml(fileDetail);
        }

        public void loadLayout(bool Default = false)
        {
            String currentPath = Directory.GetCurrentDirectory();
            String path = Path.Combine(currentPath, "Layout");
            if (Directory.Exists(path))
            {
                String fileMaster = "";
                //String fileDetail = "";
                if (Default)
                {
                    fileMaster = path + "//" + this.Name + "_Master_Default.xml";
                    //fileDetail = path + "//" + fileName + "_Detail_Default.xml";
                }
                else
                {
                    fileMaster = path + "//" + this.Name + "_Master_Current.xml";
                    //fileDetail = path + "//" + fileName + "_Detail_Current.xml";
                }
                if (System.IO.File.Exists(fileMaster))
                {
                    gridViewTaiSan.RestoreLayoutFromXml(fileMaster);
                }
                //if (System.IO.File.Exists(fileDetail))
                //{
                //bandedGridViewTSKemTheo.RestoreLayoutFromXml(fileDetail);
                //}
            }
        }

        private void ucTKTHTaiSan_Leave(object sender, EventArgs e)
        {
            saveLayout();
        }
    }
}
