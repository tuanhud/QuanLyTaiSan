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

namespace QuanLyTaiSanGUI
{
    public partial class frmHinhAnh : Form
    {
        List<HinhAnh> listhinhanhs = new List<HinhAnh>();
        public frmHinhAnh()
        {
            InitializeComponent();
            LoadHinhAnh();
        }

        private void LoadHinhAnh()
        {
            listhinhanhs = new HinhAnh().getAll();
            try
            {
                foreach (HinhAnh _hinhanh in listhinhanhs)
                {
                    var request = WebRequest.Create(_hinhanh.path);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {

                        Image img = Bitmap.FromStream(stream);
                        GalleryItem it = new GalleryItem();
                        it.Image = img;
                        it.Tag = _hinhanh.id;
                        galleryControl1.Gallery.Groups[0].Items.Add(it);

                    }
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Có lỗi trong khi load ảnh!");
            }
        }
    }
}
