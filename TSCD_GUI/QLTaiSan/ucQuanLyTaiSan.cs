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
        }

        public void loadData()
        {
            try
            {
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
                //gridControlTaiSan.DataSource = TaiSanHienThi.getAllNoDonVi();
                //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                ucComboBoxLoaiTS1.DataSource = LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                DonVi objNULL = new DonVi();
                objNULL.id = Guid.Empty;
                objNULL.ten = "[Không có đơn vị]";
                objNULL.parent = null;
                list.Insert(0, objNULL);
                ucComboBoxDonVi1.DataSource = list;
                ucComboBoxDonVi2.DataSource = list;
                ucComboBoxDonVi1.DonVi = objNULL;
                ucComboBoxDonVi2.DonVi = objNULL;

                barBtnSuaTaiSan.Enabled = false;
                barBtnXoaTaiSan.Enabled = false;
                btnSua_r.Enabled = false;
                btnXoa_r.Enabled = false;
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
                String ten = checkTen.Checked ? txtTen.Text : null;
                LoaiTaiSan loai = checkLoai.Checked ? ucComboBoxLoaiTS1.LoaiTS : null;
                DonVi DVQL = ucComboBoxDonVi1.DonVi;
                DonVi DVSD = ucComboBoxDonVi2.DonVi;
                List<TaiSanHienThi> list = TaiSanHienThi.Convert(CTTaiSanSF.search(ten, loai, checkDVQL.Checked, DVQL, checkDVSD.Checked, DVSD));
                ucGridControlTaiSan1.DataSource = list;
                ucGridControlTaiSan1.ExpandAllGroups();

                bool isEnabled = list.Count > 0;
                barBtnSuaTaiSan.Enabled = isEnabled;
                barBtnXoaTaiSan.Enabled = isEnabled;
                btnSua_r.Enabled = isEnabled;
                btnXoa_r.Enabled = isEnabled;
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
            frmAddTaiSan frm = new frmAddTaiSan(ucGridControlTaiSan1.CTTaiSan);
            frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
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
            frmAddTaiSan frm = new frmAddTaiSan(ucGridControlTaiSan1.CTTaiSan);
            frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void btnXoa_r_Click(object sender, EventArgs e)
        {

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
                if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportTaiSan(open.FileName, "Import"))
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
    }
}
