using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using TSCD_GUI.QLViTri;
using TSCD_GUI.QLPhong;
using TSCD_GUI.QLDonVi;
using TSCD_GUI.QLLoaiTaiSan;
using TSCD_GUI.QLTaiSan;
using TSCD.Entities;

namespace TSCD_GUI
{
    public partial class RibbonFormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ucQuanLyViTri _ucQuanLyViTri = null;
        ucQuanLyPhong _ucQuanLyPhong = null;
        ucQuanLyDonVi _ucQuanLyDonVi = null;
        ucQuanLyLoaiTS _ucQuanLyLoaiTS = null;
        ucQuanLyTaiSan _ucQuanLyTaiSan = null;
        ucQuanLyDonVi_TaiSan _ucQuanLyDonVi_TaiSan = null;

        const String rbnPageViTri = "rbnPageViTri";
        const String rbnPagePhong = "rbnPagePhong";
        const String rbnPageDonVi = "rbnPageDonVi";
        const String rbnPageLoaiTS = "rbnPageLoaiTS";
        const String rbnPageTaiSan = "rbnPageTaiSan";
        const String rbnPageDonVi_TaiSan = "rbnPageDonVi_TaiSan";

        bool drawEnd = false;

        public RibbonFormMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            _ucQuanLyViTri = new ucQuanLyViTri();
            _ucQuanLyPhong = new ucQuanLyPhong();
            _ucQuanLyDonVi = new ucQuanLyDonVi();
            _ucQuanLyLoaiTS = new ucQuanLyLoaiTS();
            _ucQuanLyTaiSan = new ucQuanLyTaiSan();
            _ucQuanLyDonVi_TaiSan = new ucQuanLyDonVi_TaiSan();

            _ucQuanLyViTri.Dock = DockStyle.Fill;
            _ucQuanLyPhong.Dock = DockStyle.Fill;
            _ucQuanLyDonVi.Dock = DockStyle.Fill;
            _ucQuanLyLoaiTS.Dock = DockStyle.Fill;
            _ucQuanLyTaiSan.Dock = DockStyle.Fill;
            _ucQuanLyDonVi_TaiSan.Dock = DockStyle.Fill;

            addRibbonPage(_ucQuanLyViTri.getRibbonControl());
            addRibbonPage(_ucQuanLyPhong.getRibbonControl());
            addRibbonPage(_ucQuanLyDonVi.getRibbonControl());
            addRibbonPage(_ucQuanLyLoaiTS.getRibbonControl());
            addRibbonPage(_ucQuanLyTaiSan.getRibbonControl());
            addRibbonPage(_ucQuanLyDonVi_TaiSan.getRibbonControl());

            drawEnd = true;
        }

        private void addRibbonPage(RibbonControl ribbon)
        {
            for (int i = 0; i < ribbon.Pages.Count; i++)
            {
                ribbonMain.Pages.Add(ribbon.Pages[i]);
            }
        }

        private void ribbonMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if (drawEnd)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
                //DBInstance.reNew();
                if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName(rbnPageViTri)))
                {
                    _ucQuanLyViTri.loadData();
                    panelControlMain.Controls.Clear();
                    panelControlMain.Controls.Add(_ucQuanLyViTri);
                }
                else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName(rbnPagePhong)))
                {
                    _ucQuanLyPhong.loadData();
                    panelControlMain.Controls.Clear();
                    panelControlMain.Controls.Add(_ucQuanLyPhong);
                }
                else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName(rbnPageDonVi)))
                {
                    _ucQuanLyDonVi.loadData();
                    panelControlMain.Controls.Clear();
                    panelControlMain.Controls.Add(_ucQuanLyDonVi);
                }
                else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName(rbnPageLoaiTS)))
                {
                    _ucQuanLyLoaiTS.loadData();
                    panelControlMain.Controls.Clear();
                    panelControlMain.Controls.Add(_ucQuanLyLoaiTS);
                }
                else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName(rbnPageTaiSan)))
                {
                    _ucQuanLyTaiSan.loadData();
                    panelControlMain.Controls.Clear();
                    panelControlMain.Controls.Add(_ucQuanLyTaiSan);
                }
                else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName(rbnPageDonVi_TaiSan)))
                {
                    _ucQuanLyDonVi_TaiSan.loadData();
                    panelControlMain.Controls.Clear();
                    panelControlMain.Controls.Add(_ucQuanLyDonVi_TaiSan);
                }
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }
    }
}