using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PTB_WEB
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterRouters(RouteCollection routers)
        {
            routers.MapPageRoute("Vi Tri", "vi-tri", "~/ViTri.aspx");
            routers.MapPageRoute("Phong", "phong", "~/Phong.aspx");
            routers.MapPageRoute("Phong Thiet Bi", "phong-thiet-bi", "~/PhongThietBi.aspx");
            routers.MapPageRoute("Thiet Bi", "thiet-bi", "~/ThietBis.aspx");
            routers.MapPageRoute("Loai Thiet Bi", "loai-thiet-bi", "~/LoaiThietBis.aspx");
            routers.MapPageRoute("Nhan Vien", "nhan-vien", "~/NhanVien.aspx");
            routers.MapPageRoute("Su Co", "su-co", "~/SuCo.aspx");
            routers.MapPageRoute("Muon Phong", "muon-phong", "~/MuonPhong.aspx");
            routers.MapPageRoute("Quan Ly Hinh Anh", "quan-ly-hinh-anh", "~/QuanLyHinhAnh.aspx");
            routers.MapPageRoute("Thong Tin", "thong-tin", "~/ThongTin.aspx");
            routers.MapPageRoute("Lien He", "lien-he", "~/LienHe.aspx");

            routers.MapPageRoute("Noi Dung Vi Tri", "vi-tri/{ten}/{key}", "~/ViTri.aspx");
            routers.MapPageRoute("Noi Dung Phong", "phong/{ten}/{key}", "~/Phong.aspx");
            routers.MapPageRoute("Noi Dung Phong Thiet Bi", "phong-thiet-bi/{ten}/{key}", "~/PhongThietBi.aspx");
            routers.MapPageRoute("Noi Dung Thiet Bi", "thiet-bi/{ten}/{key}", "~/ThietBis.aspx");
            routers.MapPageRoute("Noi Dung Loai Thiet Bi", "loai-thiet-bi/{ten}/{key}", "~/LoaiThietBis.aspx");
            routers.MapPageRoute("Noi Dung Nhan Vien", "nhan-vien/{ten}/{key}", "~/NhanVien.aspx");
            routers.MapPageRoute("Noi Dung Su Co", "su-co/{ten}/{key}", "~/SuCo.aspx");
            routers.MapPageRoute("Noi Dung Muon Phong", "muon-phong/{ten}/{key}", "~/MuonPhong.aspx");
            routers.MapPageRoute("Noi Dung Quan Ly Hinh Anh", "quan-ly-hinh-anh/{ten}/{key}", "~/QuanLyHinhAnh.aspx");
            routers.MapPageRoute("Noi Dung Thong Tin", "thong-tin/{ten}/{key}", "~/ThongTin.aspx");
            routers.MapPageRoute("Noi Dung Lien He", "lien-he/{ten}/{key}", "~/LienHe.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRouters(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}