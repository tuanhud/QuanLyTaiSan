using PTB.Libraries;

using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
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
                        PTB.Entities.SuCoPhong objSuCoPhong = PTB.Entities.SuCoPhong.getById(id);
                        Libraries.ImageHelper.LoadImageWeb(objSuCoPhong.hinhanhs != null ? objSuCoPhong.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "NHANVIEN":
                        PTB.Entities.NhanVienPT objNhanVienPT = PTB.Entities.NhanVienPT.getById(id);
                        Libraries.ImageHelper.LoadImageWeb(objNhanVienPT.hinhanhs != null ? objNhanVienPT.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "PHONG":
                        PTB.Entities.Phong objPhong = PTB.Entities.Phong.getById(id);
                        Libraries.ImageHelper.LoadImageWeb(objPhong.hinhanhs != null ? objPhong.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "THIETBI":
                        PTB.Entities.ThietBi objThietBi = PTB.Entities.ThietBi.getById(id);
                        Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs != null ? objThietBi.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "COSO":
                        PTB.Entities.CoSo objCoSo = PTB.Entities.CoSo.getById(id);
                        Libraries.ImageHelper.LoadImageWeb(objCoSo.hinhanhs != null ? objCoSo.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "DAY":
                        PTB.Entities.Dayy objDay = PTB.Entities.Dayy.getById(id);
                        Libraries.ImageHelper.LoadImageWeb(objDay.hinhanhs != null ? objDay.hinhanhs.ToList() : null, ASPxImageSlider);
                        break;
                    case "TANG":
                        PTB.Entities.Tang objTang = PTB.Entities.Tang.getById(id);
                        Libraries.ImageHelper.LoadImageWeb(objTang.hinhanhs != null ? objTang.hinhanhs.ToList() : null, ASPxImageSlider);
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