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
using TSCD.DataFilter.SearchFilter;

namespace TSCD_GUI.ThongKe
{
    public partial class ucTKHaoMon : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTKHaoMon()
        {
            InitializeComponent();
            init();
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
            dateNgayTK.DateTime = DateTime.Now;
            checkedCbxTinhTrang.EditValue = null;
            ucComboBoxLoaiTS1.EditValue = null;
            checkLoaiTS.Checked = false;
            ucComboBoxDonVi1.DonVi = null;
            checkDonVi.Checked = false;
            ucComboBoxViTri1.EditValue = Guid.Empty;
            checkViTri.Checked = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            try
            {
                //String ten = checkTen.Checked ? txtTen.Text : null;
                //String ten = txtTen.Text;
                LoaiTaiSan loai = checkLoaiTS.Checked ? ucComboBoxLoaiTS1.LoaiTS : null;
                DonVi DVQL = ucComboBoxDonVi1.DonVi;
                ViTri vitri = ucComboBoxViTri1.ViTri;
                Phong phong = ucComboBoxViTri1.Phong;
                bool isViTri = true;
                if (vitri == null)
                    isViTri = false;
                List<TaiSanHienThi> list = TaiSanHienThi.Convert(CTTaiSanSF.search(null, loai, checkDonVi.Checked, DVQL, false, null, isViTri && checkViTri.Checked, vitri, !isViTri && checkViTri.Checked, phong));
                gridControlHaoMon.DataSource = list;

                //saveSearchXml(this.Name);
                //ucGridControlTaiSan1.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->Search:" + ex.Message);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public void ExpandAllGroups()
        {
            gridViewHaoMon.ExpandAllGroups();
        }

        public void CollapseAllGroups()
        {
            gridViewHaoMon.CollapseAllGroups();
        }
    }
}
