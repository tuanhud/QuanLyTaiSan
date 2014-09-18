using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucLogHeThong : UserControl
    {
        public ucLogHeThong()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            barEditGioiHan.EditValue = 1000;
            ribbonLogHeThong.Parent = null;
        }

        public void loadData()
        {
            barBtnViewLog.Enabled = Permission.canView<LogHeThong>(null);
            gridControlLogHeThong.DataSource = null;
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbon()
        {
            return ribbonLogHeThong;
        }

        private void barBtnViewLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                DateTime? tuNgay = barEditTuNgay.EditValue != null ? DateTime.Parse(barEditTuNgay.EditValue.ToString()) : (DateTime?)null;
                DateTime? denNgay = barEditDenNgay.EditValue != null ? DateTime.Parse(barEditDenNgay.EditValue.ToString()) : (DateTime?)null;
                int gioiHan = Convert.ToInt32(barEditGioiHan.EditValue.ToString());
                gridControlLogHeThong.DataSource = LogHeThong.getAllByDK(tuNgay, denNgay, gioiHan);
            }
            catch
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
            finally
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }
    }
}
