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
    public partial class frmThuVienHinhAnh : Form
    {
        
        List<HinhAnh> listhinhanhs = new List<HinhAnh>();
        public frmThuVienHinhAnh()
        {
            InitializeComponent();
            LoadHinhAnh();
        }
        private void LoadHinhAnh()
        {
            HinhAnh _hinhanhs = new HinhAnh();
            listhinhanhs = _hinhanhs.getAll();
            try
            {
                foreach (HinhAnh _hinhanh in listhinhanhs)
                {
                    Image img =  _hinhanh.IMAGE;
                    GalleryItem it = new GalleryItem();
                    it.Image = img;
                    it.Tag = _hinhanh.path;
                    galleryControlImage.Gallery.Groups[0].Items.Add(it);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Có lỗi trong khi load ảnh!");
            }
        }
    }
}
