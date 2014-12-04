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
using TSCD_GUI.Libraries;
using System.IO;

namespace TSCD_GUI.ThongKe
{
    public partial class ucTKTHPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTKTHPhong()
        {
            InitializeComponent();
            init();
            createLayout();
        }

        private void init()
        {
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
                checkedCbxLoaiPhong.Properties.DataSource = LoaiPhong.getQuery().OrderBy(c => c.order).ToList();

                //ucComboBoxLoaiTS1.DataSource = LoaiTSHienThi.Convert(LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten));
                List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                DonVi objNULL = new DonVi();
                objNULL.id = Guid.Empty;
                objNULL.ten = "[Không có đơn vị]";
                objNULL.parent = null;
                list.Insert(0, objNULL);
                ucComboBoxDonVi1.DataSource = list;
                ucComboBoxDonVi1.DonVi = objNULL;

                List<ViTriHienThi> listViTri = ViTriHienThi.getAll();
                //ViTriHienThi objNULL2 = new ViTriHienThi();
                //objNULL2.id = Guid.Empty;
                //objNULL2.ten = "[Không có vị trí]";
                //objNULL2.parent_id = Guid.Empty;
                //objNULL2.loai = typeof(Phong).Name;
                //listViTri.Insert(0, objNULL2);
                ucComboBoxViTri1.DataSource = listViTri;

                gridControlPhong.DataSource = null;
                //loadSearchXml(this.Name);
                //Search();

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData:" + ex.Message);
            }
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
            //dateNgayTK.DateTime = DateTime.Now;
            //checkedCbxTinhTrang.EditValue = null;
            //ucComboBoxLoaiTS1.EditValue = null;
            //checkLoaiTS.Checked = false;
            checkedCbxLoaiPhong.SetEditValue(null);
            ucComboBoxDonVi1.EditValue = Guid.Empty;
            checkDonVi.Checked = false;
            ucComboBoxViTri1.EditValue = Guid.Empty;
            checkViTri.Checked = false;
            //dateNgayTK.EditValue = null;
            spinSoChoNgoi.EditValue = null;
            //if (comboBoxEdit1.Properties.Items.Count > 0)
            //    comboBoxEdit1.SelectedIndex = 0;
            if (cbxEquation.Properties.Items.Count > 0)
                cbxEquation.SelectedIndex = 0;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
            //List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxCoSo);
            //List<Guid> list_loaiphong = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxLoaiPhong);
            List<Guid> list_loaiphong = CheckedComboBoxEditHelper.getCheckedValueArray(checkedCbxLoaiPhong);
            gridControlPhong.DataSource = Phong_ThongKe.getAllForTH(list_loaiphong, checkViTri.Checked ? ucComboBoxViTri1.ViTri : null, checkDonVi.Checked ? ucComboBoxDonVi1.DonVi : null, 
                cbxEquation.EditValue != null ? cbxEquation.EditValue.ToString() : null, spinSoChoNgoi.EditValue != null ? (int?)Convert.ToInt32(spinSoChoNgoi.EditValue) : null);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        List<Object> listToSummary = new List<Object>();
        private void gridViewPhong_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
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
                Debug.WriteLine(this.Name + "->gridViewPhong_CustomSummaryCalculate:" + ex.Message);
            }
        }

        public void ExpandAllGroups()
        {
            gridViewPhong.ExpandAllGroups();
        }

        public void CollapseAllGroups()
        {
            gridViewPhong.CollapseAllGroups();
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
                gridViewPhong.SaveLayoutToXml(fileMaster);
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
            gridViewPhong.SaveLayoutToXml(fileMaster);
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
                    gridViewPhong.RestoreLayoutFromXml(fileMaster);
                }
                //if (System.IO.File.Exists(fileDetail))
                //{
                //bandedGridViewTSKemTheo.RestoreLayoutFromXml(fileDetail);
                //}
            }
        }

        private void ucTKTHPhong_Leave(object sender, EventArgs e)
        {
            saveLayout();
        }
    }
}
