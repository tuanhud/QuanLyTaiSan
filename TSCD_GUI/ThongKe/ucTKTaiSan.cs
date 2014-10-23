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
    public partial class ucTKTaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTKTaiSan()
        {
            InitializeComponent();
            ucComboBoxLoaiTS1.showCheck();
            createLayout();
        }

        public void loadData()
        {
            loadLayout();
            gridControlTaiSan.DataSource = null;
            ucComboBoxLoaiTS1.DataSource = null;
            ucComboBoxLoaiTS1.DataSource = LoaiTSHienThi.Convert(LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten));
            checkedComboBoxCoSo.Properties.DataSource = CoSo.getQuery().OrderBy(c => c.order).ToList();
            List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
            DonVi objNULL = new DonVi();
            objNULL.id = Guid.Empty;
            objNULL.ten = "[Đại học Sài Gòn]";
            objNULL.parent = null;
            list.Insert(0, objNULL);
            ucComboBoxDonVi1.DataSource = null;
            ucComboBoxDonVi1.DataSource = list;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
            coldate_create.Visible = false;
            //String str = "";
            //foreach (Guid id in ucComboBoxLoaiTS1.list_loaitaisan)
            //{
            //    str += id;
            //}
            //MessageBox.Show(str);
            List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxCoSo);
            gridControlTaiSan.DataSource = TaiSan_ThongKe.getAll(list_coso, ucComboBoxLoaiTS1.list_loaitaisan, ucComboBoxDonVi1.DonVi);
            //bandedGridViewTaiSan.PopulateColumns();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnThongKeTangGiam_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
            coldate_create.Visible = true;
            //List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxCoSo);
            DonVi obj = ucComboBoxDonVi1.DonVi;
            gridControlTaiSan.DataSource = TaiSan_ThongKe.getTangGiamAll(obj != null ? obj.id : Guid.Empty, null, null);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public void ExpandAllGroups()
        {
            bandedGridViewTaiSan.ExpandAllGroups();
        }

        public void CollapseAllGroups()
        {
            bandedGridViewTaiSan.CollapseAllGroups();
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
                bandedGridViewTaiSan.SaveLayoutToXml(fileMaster);
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
            bandedGridViewTaiSan.SaveLayoutToXml(fileMaster);
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
                    bandedGridViewTaiSan.RestoreLayoutFromXml(fileMaster);
                }
                //if (System.IO.File.Exists(fileDetail))
                //{
                    //bandedGridViewTSKemTheo.RestoreLayoutFromXml(fileDetail);
                //}
            }
        }

        private void ucTKTaiSan_Leave(object sender, EventArgs e)
        {
            saveLayout();
        }
    }
}
