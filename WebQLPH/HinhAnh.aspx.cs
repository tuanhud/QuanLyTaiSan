using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH
{
    public partial class HinhAnh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Guid id = GUID.From(Request.QueryString["id"]);
                switch (Request.QueryString["TYPE"])
                {
                    case "SUCOPHONG":
                        QuanLyTaiSan.Entities.SuCoPhong objSuCoPhong = QuanLyTaiSan.Entities.SuCoPhong.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objSuCoPhong.hinhanhs != null ? objSuCoPhong.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "NHANVIEN":
                        QuanLyTaiSan.Entities.NhanVienPT objNhanVienPT = QuanLyTaiSan.Entities.NhanVienPT.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objNhanVienPT.hinhanhs != null ? objNhanVienPT.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "PHONG":
                        QuanLyTaiSan.Entities.Phong objPhong = QuanLyTaiSan.Entities.Phong.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objPhong.hinhanhs != null ? objPhong.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "THIETBI":
                        QuanLyTaiSan.Entities.ThietBi objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs != null ? objThietBi.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "COSO":
                        QuanLyTaiSan.Entities.CoSo objCoSo = QuanLyTaiSan.Entities.CoSo.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objCoSo.hinhanhs != null ? objCoSo.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "DAY":
                        QuanLyTaiSan.Entities.Dayy objDay = QuanLyTaiSan.Entities.Dayy.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objDay.hinhanhs != null ? objDay.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "TANG":
                        QuanLyTaiSan.Entities.Tang objTang = QuanLyTaiSan.Entities.Tang.getById(id);
                        QuanLyTaiSan.Libraries.ImageHelper.LoadImageWeb(objTang.hinhanhs != null ? objTang.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx");
                Console.Write(ex);
            }
        }
    }
}