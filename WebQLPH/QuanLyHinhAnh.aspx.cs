using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class QuanLyHinhAnh : System.Web.UI.Page
    {
        string folder_img = "/ImageUpload/";
        string folder_thumb = "Thumb/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Đặt tên để set class, đặt tên in hoa
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "QUANLYHINHANH";

                CreateFolder(folder_img);
                CreateFolder(folder_img + folder_thumb);
                ListImage();
            }
        }

        protected void CreateFolder(string FolderName)
        {
            string FullPathFolderName = Server.MapPath(Path.Combine(FolderName));
            if (!Directory.Exists(FullPathFolderName))
                Directory.CreateDirectory(FullPathFolderName);
        }

        protected void ButtonTaiLen_Click(object sender, EventArgs e)
        {
            PanelThongBao.Visible = false;
            try
            {
                if (ImageUpload.HasFile)
                {
                    string NameFileImage = "", NameFileImageDaCo = "";
                    HttpFileCollection FileNameImages = Request.Files;
                    for (int i = 0; i < FileNameImages.Count; i++)
                    {
                        HttpPostedFile imageupload = FileNameImages[i];
                        if (imageupload.ContentType.Contains("image"))
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(folder_img));
                            if (File.Exists(dirInfo + imageupload.FileName))
                            {
                                NameFileImageDaCo += "<strong>" + imageupload.FileName + "</strong>, ";
                            }
                            else
                            {
                                imageupload.SaveAs(Server.MapPath(Path.Combine(folder_img, imageupload.FileName)));

                                System.Drawing.Image bm = System.Drawing.Image.FromStream(imageupload.InputStream);
                                bm = ResizeBitmap((Bitmap)bm, 75, 75);
                                bm.Save(Server.MapPath(Path.Combine(folder_img + folder_thumb, imageupload.FileName)));

                                NameFileImage += "<strong>" + imageupload.FileName + "</strong>, ";
                            }
                        }
                    }
                    PanelThongBao.Visible = true;
                    if (!NameFileImage.Equals(""))
                    {
                        LabelThongBao.Text = "<div class='alert alert-success' role='alert'>Ảnh " + NameFileImage + "được tải lên thành công</div>";
                        LabelThongBao.Visible = true;
                    }
                    if (!NameFileImageDaCo.Equals(""))
                    {
                        LabelThongBaoAnhDaCo.Text = "<div class='alert alert-warning' role='alert'>Ảnh <strong>" + NameFileImageDaCo + "</strong> đã có trên hệ thống. Vui lòng đổi tên và tải lên lại.</div>";
                        LabelThongBaoAnhDaCo.Visible = true;
                    }                    

                    ListImage();
                }
                else
                {
                    PanelThongBao.Visible = true;
                    LabelThongBao.Text = "<div class='alert alert-warning' role='alert'>Vui lòng chọn ảnh để tải lên</div>";
                    LabelThongBao.Visible = true;
                }
            }
            catch (Exception ex)
            {
                PanelThongBao.Visible = true;
                LabelThongBao.Text = "<div class='alert alert-danger' role='alert'>Có lỗi trong khi tải lên</div>";
                Response.Write(ex);
            }
        }

        protected void ListImage()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(folder_img));
            List<String> imagefilenames = dirInfo.GetFiles().Select(i => i.Name).ToList();

            CollectionPagerQuanLyHinhAnh.DataSource = imagefilenames;
            CollectionPagerQuanLyHinhAnh.BindToControl = RepeaterHinhAnh;
            RepeaterHinhAnh.DataSource = CollectionPagerQuanLyHinhAnh.DataSourcePaged;
            RepeaterHinhAnh.DataBind();
        }

        protected string Url(string Name)
        {
            return folder_img + Name;
        }
        protected string Thumb(string Name)
        {
            string img_thumb = folder_img + folder_thumb + Name;
            if (!File.Exists(img_thumb))
            {
                System.Drawing.Image bm = System.Drawing.Image.FromFile(Server.MapPath(Path.Combine(folder_img, Name)));
                bm = ResizeBitmap((Bitmap)bm, 75, 75);
                bm.Save(Server.MapPath(Path.Combine(folder_img + folder_thumb, Name)));
            }
            return img_thumb;
        }
        protected Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }
    }
}