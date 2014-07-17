using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.Settings
{
    public partial class ucGiaoDienvaNgonNgu : UserControl
    {
        string GiaoDien = Properties.Settings.Default["ApplicationSkinName"].ToString();
        public ucGiaoDienvaNgonNgu()
        {
            InitializeComponent();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(galleryControlGiaoDien, true);
        }

        private void galleryControlGallery1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            GiaoDien = e.Item.Tag.ToString();
        }

        private void simpleButtonLuuGiaoDien_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["ApplicationSkinName"] = GiaoDien;
            Properties.Settings.Default.Save();
            XtraMessageBox.Show("Đã lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButtonHuyGiaoDien_Click(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default["ApplicationSkinName"].ToString();
            //galleryControlGiaoDien.Tag = Properties.Settings.Default["ApplicationSkinName"].ToString();
        }
    }
}
