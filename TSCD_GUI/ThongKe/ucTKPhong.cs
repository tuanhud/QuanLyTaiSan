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
using System.IO;

namespace TSCD_GUI.ThongKe
{
    public partial class ucTKPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTKPhong()
        {
            InitializeComponent();
            createLayout();
        }

        public void loadData()
        {
            loadLayout();
            gridControlPhong.DataSource = null;
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

        private void ucTKPhong_Leave(object sender, EventArgs e)
        {
            saveLayout();
        }
    }
}
