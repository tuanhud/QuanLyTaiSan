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
    public partial class frmHinhAnh : DevExpress.XtraEditors.XtraForm
    {
        public static Size HoverSkinImageSize = new Size(116, 86);
        public static Size SkinImageSize = new Size(58, 43);
        
        int GIUNGUYEN = 0, LON = 800, VUA = 400, NHO = 100;
        List<HinhAnh> listTemp = new List<HinhAnh>();
        List<HinhAnh> listHinhs = new List<HinhAnh>();

        public frmHinhAnh(List<HinhAnh> list)
        {
            InitializeComponent();
            //UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.skin);
            comboBoxEdit1.SelectedIndex = 2;
            btnImageDelete.Enabled = false;
            if (list != null)
            {
                listHinhs = list;
                foreach(HinhAnh hinh in list)
                {
                    listTemp.Add(hinh);
                }
                LoadHinhAnh(list);
            }
            //else
            //    XtraMessageBox.Show("Không có ảnh để load!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void LoadHinhAnh(List<HinhAnh> list)
        {
            try
            {
                galleryControlImage.Gallery.Groups[0].Items.Clear();
                foreach (HinhAnh hinhanh in list)
                {
                    GalleryItem it = new GalleryItem();
                    it.Image = (Image)hinhanh.getImage();
                    it.Tag = hinhanh.path;
                    galleryControlImage.Gallery.Groups[0].Items.Add(it);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Có lỗi trong khi load ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void galleryControlGallery_CustomDrawItemImage(object sender, GalleryItemCustomDrawEventArgs e)
        {
            //if (!MarkedItems.Contains(e.Item)) return;
            //e.Cache.Graphics.DrawImage(e.Item.Image, ((GalleryItemViewInfo)e.ItemInfo).ImageContentBounds);
            //DrawMarkedIcon(e.Cache, ((GalleryItemViewInfo)e.ItemInfo).ImageContentBounds);
            //e.Handled = true;
        }

        private void btnImageUpload_Click(object sender, EventArgs e)
        {
            try
            {
                List<HinhAnh> listHinhAnh = new List<HinhAnh>();
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Hình ảnh(*.png,*.bmp,*.jpg,*.jpeg)|*.png;*.bmp;*.jpg;*.jpeg";
                open.Title = "My Image Browser";
                open.Multiselect = true;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    List<FileInfo> listFileInfoDaCo = new List<FileInfo>();
                    List<HinhAnh> listHinhAnhDaCo = new List<HinhAnh>();
                    List<FileInfo> listHinhAnhSeUpload = new List<FileInfo>();
                    Boolean coUploadHinhAnhDaCo = false;
                    //listHinhAnh = HinhAnh.getAll();

                    foreach (string file in open.FileNames)
                    {
                        FileInfo fileinfo = new FileInfo(file);
                        Path.GetFileNameWithoutExtension(fileinfo.Name);
                        //HinhAnh hinhanhcheck = listHinhAnh.Where(h => h.path == (fileinfo.Name.ToString() + ".JPEG")).FirstOrDefault();
                        HinhAnh hinhanhcheck = HinhAnh.getQuery().Where(h => h.path == (fileinfo.Name.ToString() + ".JPEG")).FirstOrDefault();
                        if (hinhanhcheck == null)
                        {
                            listHinhAnhSeUpload.Add(fileinfo);
                        }
                        else
                        {
                            listFileInfoDaCo.Add(fileinfo);
                            listHinhAnhDaCo.Add(hinhanhcheck);
                        }
                    }
                    if (listFileInfoDaCo.Count > 0)
                    {
                        if (XtraMessageBox.Show(String.Format("Có {0} ảnh đã có trên Host, bạn có muốn dùng ảnh cũ?", listFileInfoDaCo.Count), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            coUploadHinhAnhDaCo = false;
                            foreach (HinhAnh hinhanh in listHinhAnhDaCo)
                            {
                                HinhAnh hinhanhADD = new HinhAnh();
                                hinhanhADD.path = hinhanh.path;
                                listTemp.Add(hinhanhADD);

                                GalleryItem it = new GalleryItem();
                                it.Image = (Image)hinhanh.IMAGE;
                                it.Tag = hinhanh.path;
                                galleryControlImage.Gallery.Groups[0].Items.Add(it);
                            }
                        }
                        else
                        {
                            coUploadHinhAnhDaCo = true;
                        }
                    }
                    splashScreenManager.ShowWaitForm();
                    foreach (FileInfo fileinfo in listHinhAnhSeUpload)
                    {
                        UploadHinhAnh(fileinfo, false);
                    }
                    splashScreenManager.CloseWaitForm();
                    if (coUploadHinhAnhDaCo)
                    {
                        foreach (FileInfo fileinfo in listFileInfoDaCo)
                        {
                            UploadHinhAnh(fileinfo, true);
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnImageUpload_Click: " + ex.Message);
            }
        }

        private void galleryControlImage_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            btnImageDelete.Enabled = true;
        }

        private void DeleteImage()
        {
            List<GalleryItem> listItemDelete = galleryControlImage.Gallery.GetCheckedItems();
            String message = "";
            if (listItemDelete.Count > 1)
                message = "Bạn có chắc là xóa những ảnh này không?";
            else
            {
                if (listItemDelete.Count == 1)
                    message = "Bạn có chắc muốn xóa ảnh này?";
                else
                {
                    XtraMessageBox.Show("Chưa chọn ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (MessageBox.Show(message, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (GalleryItem gallery in listItemDelete)
                    {
                        HinhAnh h = listTemp.Where(c => c.path == gallery.Tag.ToString()).FirstOrDefault();
                        listTemp.Remove(h);
                        galleryControlImage.Gallery.Groups[0].Items.Remove(gallery);
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Có lỗi trong khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (galleryControlImage.Gallery.GetCheckedItems().Count == 0)
                btnImageDelete.Enabled = false;
        }

        private void UploadHinhAnh(FileInfo fileinfo, Boolean coDoiTenHinhAnh)
        {
            try
            {
                string fPath = fileinfo.ToString();
                string file_name = fileinfo.Name.ToString();
                if (coDoiTenHinhAnh)
                {
                    //file_name = StringHelper.RandomName(15);
                    MyForm.frmDoiTenHinh frm = new MyForm.frmDoiTenHinh(fileinfo.Name.ToString());
                    if (frm.ShowDialog().Equals(DialogResult.No))
                    {
                        return;
                    }
                    else
                    {
                        file_name = frm.name;
                    }
                }
                HinhAnh hinhanh = new HinhAnh();
                hinhanh.FILE_NAME = file_name;
                hinhanh.IMAGE = (Bitmap)Bitmap.FromFile(fPath);
                switch (comboBoxEdit1.SelectedIndex)
                {
                    case 0:
                        hinhanh.MAX_SIZE = GIUNGUYEN;
                        break;
                    case 1:
                        hinhanh.MAX_SIZE = LON;
                        break;
                    case 2:
                        hinhanh.MAX_SIZE = VUA;
                        break;
                    case 3:
                        hinhanh.MAX_SIZE = NHO;
                        break;
                    default:
                        hinhanh.MAX_SIZE = GIUNGUYEN;
                        break;
                }
                hinhanh.upload();
                listTemp.Add(hinhanh);

                GalleryItem it = new GalleryItem();
                it.Image = (Image)hinhanh.IMAGE;
                it.Tag = hinhanh.path;
                galleryControlImage.Gallery.Groups[0].Items.Add(it);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->UploadHinhAnh: " + ex.Message);
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
            foreach (GalleryItem item in galleryControlImage.Gallery.Groups[0].Items)
                galleryControlImage.Gallery.SetItemCheck(item, true, false);
            if (galleryControlImage.Gallery.GetCheckedItems().Count > 0)
                btnImageDelete.Enabled = true;
        }

        public List<HinhAnh> getlistHinhs()
        {
            return listHinhs;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            listHinhs = listTemp;
            this.Close();
        }

        private void btnThuVienAnh_Click(object sender, EventArgs e)
        {
            try
            {
                frmThuVienHinhAnh frm = new frmThuVienHinhAnh();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    int count = 0;
                    List<HinhAnh> listHinhAnhDaCo = new List<HinhAnh>();
                    foreach (HinhAnh hinhanh in frm.getHinhAnhChons())
                    {
                        if (listTemp.Where(h => h.path == hinhanh.path).FirstOrDefault() == null)
                        {
                            HinhAnh hinhanhADD = new HinhAnh();
                            hinhanhADD.path = hinhanh.path;
                            listTemp.Add(hinhanhADD);
                            count++;
                        }
                        else
                            listHinhAnhDaCo.Add(hinhanh);
                    }
                    if (listHinhAnhDaCo.Count > 0)
                    {
                        if (XtraMessageBox.Show(String.Format("Có {0} ảnh đã có, bạn có muốn thêm vào không", listHinhAnhDaCo.Count), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            foreach (HinhAnh hinhanh in listHinhAnhDaCo)
                            {
                                HinhAnh hinhanhADD = new HinhAnh();
                                hinhanhADD.path = hinhanh.path;
                                listTemp.Add(hinhanhADD);
                                count++;
                            }
                        }
                    }
                    LoadHinhAnh(listTemp);
                    if (count > 0)
                        XtraMessageBox.Show(String.Format("Đã thêm {0} ảnh", count), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnThuVienAnh_Click: " + ex.Message);
            }
        }
    }
}
