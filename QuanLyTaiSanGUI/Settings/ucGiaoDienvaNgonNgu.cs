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
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSan;

namespace QuanLyTaiSanGUI.Settings
{
    public partial class ucGiaoDienvaNgonNgu : UserControl, _ourUcInterface
    {
        string GiaoDien = Global.local_setting.ApplicationSkinName;
        GalleryItem _item = null;
        bool Changed = false;
        public ucGiaoDienvaNgonNgu()
        {
            InitializeComponent();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(galleryControlGiaoDien, true);
            _item = galleryControlGiaoDien.Gallery.GetItemByCaption(GiaoDien);
        }


        private void galleryControlGallery1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            GiaoDien = e.Item.Tag.ToString();
            Changed = true;
        }

        private void simpleButtonLuuGiaoDien_Click(object sender, EventArgs e)
        {
            Global.local_setting.ApplicationSkinName = GiaoDien;
            Global.local_setting.Save();
            _item = galleryControlGiaoDien.Gallery.GetItemByCaption(GiaoDien);
            XtraMessageBox.Show("Đã lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButtonHuyGiaoDien_Click(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Global.local_setting.ApplicationSkinName;
            galleryControlGiaoDien.Gallery.SetItemCheck(_item, true);
            Changed = false;
        }

        private void ucGiaoDienvaNgonNgu_Validating(object sender, CancelEventArgs e)
        {
            //e.Cancel = true;
        }

        public void reLoad()
        {
            throw new NotImplementedException();
        }
    }
}
