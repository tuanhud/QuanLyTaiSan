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
        int idobject;
        String loaiobject;
        //String _name = "";
        int GIUNGUYEN = 0, LON = 800, VUA = 400, NHO = 100;
        //GalleryItem currItem = new GalleryItem();
        List<HinhAnh> listhinhanhs = new List<HinhAnh>();
        List<HinhAnh> hinhs = null;
        OurDBContext db = null;

        public frmHinhAnh(int _idobject, List<HinhAnh> _listhinhanh, string _loaiobject)
        {
            //ShowTitle();
            InitializeComponent();
            InitSkins();            
            btnImageDelete.Enabled = false;
            listhinhanhs = _listhinhanh;
            idobject = _idobject;
            loaiobject = _loaiobject;
            if (listhinhanhs != null)
            {
                LoadHinhAnh(listhinhanhs);
            }
            else XtraMessageBox.Show("Không có ảnh để load");
        }

        public frmHinhAnh(List<HinhAnh> _listhinhanh)
        {
            //ShowTitle();
            InitializeComponent();
            InitSkins();
            btnImageDelete.Enabled = false;
            hinhs = _listhinhanh;
            if (hinhs != null)
            {
                LoadHinhAnh(hinhs);
            }
            else XtraMessageBox.Show("Không có ảnh để load");
        }

        private void InitSkins()
        {
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        private void LoadHinhAnh(List<HinhAnh> _hinhanhs)
        {
            try
            {
                foreach (HinhAnh _hinhanh in _hinhanhs)
                {
                    Image img = _hinhanh.getImage();
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
                splashScreenManager.ShowWaitForm();
                foreach (string file in open.FileNames)
                {
                    FileInfo fInfo = new FileInfo(file);
                    string fPath = fInfo.ToString();
                    //DateTime _datetime = ServerTimeHelper.getNow();
                    //String _dt = _datetime.ToString("yyyy-MM-dd-hh-mm-ss-");
                    string file_name = fInfo.Name.ToString();
                    HinhAnh _hinhanh = new HinhAnh();
                    _hinhanh.FILE_NAME = file_name;
                    _hinhanh.IMAGE = (Bitmap)Bitmap.FromFile(fPath);
                    switch (comboBoxEdit1.SelectedIndex)
                    {
                        case 0:
                            _hinhanh.MAX_SIZE = GIUNGUYEN;
                            break;
                        case 1:
                            _hinhanh.MAX_SIZE = LON;
                            break;
                        case 2:
                            _hinhanh.MAX_SIZE = VUA;
                            break;
                        case 3:
                            _hinhanh.MAX_SIZE = NHO;
                            break;
                        default:
                            _hinhanh.MAX_SIZE = GIUNGUYEN;
                            break;
                    }
                    _hinhanh.upload();
                    //_hinhanh.add();
                    hinhs.Add(_hinhanh);

                    GalleryItem it = new GalleryItem();
                    it.Image = (Image)_hinhanh.IMAGE;
                    it.Tag = _hinhanh.path;
                    galleryControlImage.Gallery.Groups[0].Items.Add(it);
                }
                splashScreenManager.CloseWaitForm();
            }
        }

        private void galleryControlImage_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            //currItem = e.Item;
            // _name = e.Item.Tag.ToString();
            //btnImageDelete.Enabled = true;
        }

        private void DeleteImage()
        {
            List<GalleryItem> listItemDelete = galleryControlImage.Gallery.GetCheckedItems();
            String message = "";
            if (listItemDelete.Count > 1)
                message = "Bạn có chắc là xóa hết ảnh không?";
            else
            {
                if (listItemDelete.Count == 1)
                    message = "Bạn có chắc muốn xóa ảnh này?";
                else
                {
                    XtraMessageBox.Show("Chưa chọn ảnh!");
                    return;
                }
            }
            if (MessageBox.Show(message, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    {
		                foreach (GalleryItem gallery in listItemDelete)
                        {
		                    HinhAnh h = hinhs.Where(c => c.path == gallery.Tag.ToString()).FirstOrDefault();
                            hinhs.Remove(h);
                            //h.delete();
                            galleryControlImage.Gallery.Groups[0].Items.Remove(gallery);
                        }
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Có lỗi trong khi xóa!");
                }
            }
        }

        private void btnImageDelete_Click(object sender, EventArgs e)
        {
            DeleteImage();
        }

        private void btnImageCancel_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn thoát. Ảnh tải lên sẽ không được lưu lại.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnImageSelectAll_Click(object sender, EventArgs e)
        {
            btnImageDelete.Enabled = true;
            foreach (GalleryItem item in galleryControlImage.Gallery.Groups[0].Items)
                galleryControlImage.Gallery.SetItemCheck(item, true, false);
        }

        public List<HinhAnh> getHinhAnhs()
        {
            return hinhs;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnThuVienAnh_Click(object sender, EventArgs e)
        {

        }
    }
}
