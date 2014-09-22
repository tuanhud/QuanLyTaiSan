﻿using System;
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
using DevExpress.XtraGrid.Views.BandedGrid;
using SHARED.Libraries;

namespace TSCD_GUI.QLTaiSan
{
    public partial class ucQuanLyDonVi_TaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyDonVi_TaiSan()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlDonVi_TaiSan.Parent = null;
            ucTreeDonVi1.focusedNodeChanged = new MyUserControl.ucTreeDonVi.FocusedNodeChanged(reloadData);
        }

        public void loadData()
        {
            try
            {
                ucTreeDonVi1.DataSource = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                reloadData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void reloadAndFocused(Guid _id)
        {
            try
            {
                reloadData();
                ucGridControlTaiSan1.reloadAndFocused(_id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadAndFocused: " + ex.Message);
            }
        }

        public void reloadData()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            try
            {
                DonVi obj = ucTreeDonVi1.DonVi;
                //gridControlTaiSan.DataSource = TaiSanHienThi.getAllByDonVi(obj);
                if (obj != null)
                {
                    List<TaiSanHienThi> list = TaiSanHienThi.Convert(obj.getAllCTTaiSanRecursive());
                    ucGridControlTaiSan1.DataSource = list;

                    bool isEnabled = list.Count > 0;
                    barBtnSuaTaiSan.Enabled = isEnabled;
                    barBtnXoaTaiSan.Enabled = isEnabled;
                }
                else
                    ucGridControlTaiSan1.DataSource = null;
                ucGridControlTaiSan1.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadData: " + ex.Message);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlDonVi_TaiSan;
        }

        private void barBtnThemTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddTaiSanExist frm = new frmAddTaiSanExist(ucTreeDonVi1.DonVi);
            frm.reloadAndFocused = new frmAddTaiSanExist.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void barBtnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //bandedGridViewTaiSan.ShowRibbonPrintPreview();
        }

        private void barBtnChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInputViTri_DonVi frm = new frmInputViTri_DonVi(ucGridControlTaiSan1.CTTaiSan);
            frm.reloadAndFocused = new frmInputViTri_DonVi.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void barBtnSuaTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddTaiSan frm = new frmAddTaiSan(ucGridControlTaiSan1.CTTaiSan, true);
            frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
            frm.ShowDialog();
        }

        private void barBtnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLogTaiSan frm = new frmLogTaiSan(ucGridControlTaiSan1.CTTaiSan);
            frm.ShowDialog();
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
                if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportDonVi(open.FileName, "DonVi", "TaiSan"))
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
