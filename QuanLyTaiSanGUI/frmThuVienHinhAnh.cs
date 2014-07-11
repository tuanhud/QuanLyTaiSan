using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;
using System.Net;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using System.IO;
using QuanLyTaiSan.Libraries;

namespace QuanLyTaiSanGUI
{
    public partial class frmThuVienHinhAnh : DevExpress.XtraEditors.XtraForm
    {
        List<HinhAnh> HinhAnhs = null;
        List<HinhAnh> HinhAnhChons = null;
        
        public frmThuVienHinhAnh()
        {
            InitializeComponent();
            //UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.skin);
            HinhAnhs = HinhAnh.getAllHinhAnhDangDung();
            LoadHinhAnh();
        }

        private void LoadHinhAnh()
        {
            try
            {
                galleryControlImage.Gallery.Groups[0].Items.Clear();
                foreach (HinhAnh hinhanh in HinhAnhs)
                {
                    GalleryItem item = new GalleryItem();
                    item.Image = (Image)hinhanh.IMAGE;
                    item.Tag = hinhanh.path;
                    galleryControlImage.Gallery.Groups[0].Items.Add(item);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Có lỗi trong khi load ảnh!");
            }
        }

        private void btnImageCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<GalleryItem> listitemselected = galleryControlImage.Gallery.GetCheckedItems();
            HinhAnhChons = new List<HinhAnh>();
            foreach (GalleryItem gallery in listitemselected)
            {
                HinhAnh hinhanh = new HinhAnh();
                hinhanh.path = gallery.Tag.ToString();
                HinhAnhChons.Add(hinhanh);
            }
        }

        public List<HinhAnh> getHinhAnhChons()
        {
            return HinhAnhChons;
        }
    }
}
