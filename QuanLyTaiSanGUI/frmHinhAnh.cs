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
    public partial class frmHinhAnh : Form
    {
        public static Size HoverSkinImageSize = new Size(116, 86);
        public static Size SkinImageSize = new Size(58, 43);

        List<HinhAnh> listhinhanhs = new List<HinhAnh>();

        //public frmHinhAnh(List<HinhAnh> list)
        public frmHinhAnh()
        {
            InitializeComponent();
            InitSkins();
            //listhinhanhs = list;
            String at = StringHelper.LocKyTuDacBiet("Nguyen Hoang Thanh _ -  ~!@#$%^&*()");
            XtraMessageBox.Show(at);
            //LoadHinhAnh();
        }

        private void InitSkins()
        {
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
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
                        galleryControlImage.Gallery.Groups[0].Items.Add(it);
                    }
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Có lỗi trong khi load ảnh!");
            }
        }

        private void galleryControlGallery_CustomDrawItemImage(object sender, GalleryItemCustomDrawEventArgs e)
        {
            
            ////if (!MarkedItems.Contains(e.Item)) return;
            //e.Cache.Graphics.DrawImage(e.Item.Image, ((GalleryItemViewInfo)e.ItemInfo).ImageContentBounds);
            ////DrawMarkedIcon(e.Cache, ((GalleryItemViewInfo)e.ItemInfo).ImageContentBounds);
            //e.Handled = true;

        }

        private void btnImageUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Hình ảnh(*.png,*.bmp,*.jpg,*.jpeg)|*.png;*.bmp;*.jpg;*.jpeg";
            open.Title = "My Image Browser";
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in open.FileNames)
                {
                    FileInfo fInfo = new FileInfo(file);
                    string filePath = fInfo.ToString();
                    DateTime _datetime = ServerTimeHelper.getNow();
                    String _dt = _datetime.ToString("yyyy-MM-dd-hh-mm-ss-");
                    string fileName = _dt + fInfo.Name.ToString();
                    string username = "qlts@hoangthanhit.com";
                    string password = "quanlytaisan";
                    string remote_path = "ftp://hoangthanhit.com/";
                    string hostview = "http://hoangthanhit.com/qlts/";

                    Bitmap image = FTPHelper.LoadPicture(filePath);
                    FTPHelper.uploadImage(image, remote_path, username, password);
                    image = HTTPHelper.getImage(hostview + fileName);

                    GalleryItem it = new GalleryItem();
                    it.Image = (Image)image;
                    galleryControlImage.Gallery.Groups[0].Items.Add(it);
                    
                    //FTPHelper.FTPUpload(username, password, filePath, fileName, hostupload);

                    //var request = WebRequest.Create(hostview + fileName);
                    //using (var response = request.GetResponse())
                    //using (var stream = response.GetResponseStream())
                    //{
                    //    Image img = Bitmap.FromStream(stream);
                    //    GalleryItem it = new GalleryItem();
                    //    it.Image = img;
                    //    //it.Tag = "http://cicc.byethost10.com/img/" + fileName;
                    //    //Đưa hình ảnh vào Gallery
                    //    galleryControlImage.Gallery.Groups[0].Items.Add(it);
                    //    //Lưu hình ảnh vào cơ sở dữ liệu
                    //    //it.Tag = id().ToString();
                    //    //add_db("http://cicc.byethost10.com/img/" + fileName);
                    //}
                }
            }
        }


    }
}
