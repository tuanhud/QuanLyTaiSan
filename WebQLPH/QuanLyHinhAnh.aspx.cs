using QuanLyTaiSan.DataFilter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class QuanLyHinhAnh : System.Web.UI.Page
    {
        string url_folder = "/ImageUpload/";
        protected void Page_Load(object sender, EventArgs e)
        {
            ListImage();
        }

        protected void ButtonTaiLen_Click(object sender, EventArgs e)
        {
            foreach (HttpPostedFile imageupload in ImageUpload.PostedFiles)
            {
                if (imageupload.ContentType == "image/jpeg")
                {
                    imageupload.SaveAs(Server.MapPath(Path.Combine(url_folder, imageupload.FileName)));
                }
            }
            ListImage();
        }

        protected void ListImage()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(url_folder));
            List<String> imagefilenames = dirInfo.GetFiles().Select(i => i.Name).ToList();

            RepeaterHinhAnh.DataSource = imagefilenames;
            RepeaterHinhAnh.DataBind();
        }

        protected string Url(string Name)
        {
            return string.Format("{0}/{1}",url_folder, Name);
        }
    }
}