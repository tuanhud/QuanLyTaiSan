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

            addRibbonPage(_ucQuanLyViTri.getRibbonControl());
            addRibbonPage(_ucQuanLyPhong.getRibbonControl());
            addRibbonPage(_ucQuanLyDonVi.getRibbonControl());
            addRibbonPage(_ucQuanLyLoaiTS.getRibbonControl());
            addRibbonPage(_ucQuanLyTaiSan.getRibbonControl());
            addRibbonPage(_ucQuanLyDonVi_TaiSan.getRibbonControl());
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

        }
    }
}