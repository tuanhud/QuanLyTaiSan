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

namespace TSCD_GUI.ThongKe
{
    public partial class ucTKTHPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTKTHPhong()
        {
            InitializeComponent();
            init();
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
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
                //gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
                //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                checkedComboBoxEdit1.Properties.DataSource = LoaiPhong.getQuery().OrderBy(c => c.order).ToList();

                //ucComboBoxLoaiTS1.DataSource = LoaiTSHienThi.Convert(LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten));
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

                //ucGridControlTaiSan1.DataSource = null;
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
            ucComboBoxDonVi1.EditValue = Guid.Empty;
            checkDonVi.Checked = false;
            ucComboBoxViTri1.EditValue = Guid.Empty;
            checkViTri.Checked = false;
            //dateNgayTK.EditValue = null;
            spinEdit1.EditValue = null;
            //if (comboBoxEdit1.Properties.Items.Count > 0)
            //    comboBoxEdit1.SelectedIndex = 0;
            if (comboBoxEdit2.Properties.Items.Count > 0)
                comboBoxEdit2.SelectedIndex = 0;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
            //List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxCoSo);
            //List<Guid> list_loaiphong = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxLoaiPhong);
            List<Guid> list_loaiphong = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit1);
            gridControlPhong.DataSource = Phong_ThongKe.getAll(null, list_loaiphong);
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
    }
}
