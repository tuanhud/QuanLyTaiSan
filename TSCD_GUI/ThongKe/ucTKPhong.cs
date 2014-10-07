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
using TSCD_GUI.Libraries;

namespace TSCD_GUI.ThongKe
{
    public partial class ucTKPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTKPhong()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            checkedComboBoxCoSo.Properties.DataSource = CoSo.getAll();
            checkedComboBoxLoaiPhong.Properties.DataSource = LoaiPhong.getAll();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
            List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxCoSo);
            List<Guid> list_loaiphong = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxLoaiPhong);
            gridControlPhong.DataSource = Phong_ThongKe.getAll(list_coso, list_loaiphong);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public void ExpandAllGroups()
        {
            gridViewPhong.ExpandAllGroups();
        }

        public void CollapseAllGroups()
        {
            gridViewPhong.CollapseAllGroups();
        }
    }
}
