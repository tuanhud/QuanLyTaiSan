using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.Libraries
{
    public class PermissionHelper
    {
        public static bool QuyenMuonPhong()
        {
            return Permission.canDo(Permission._WEB_MUONPHUONG);
        }

        public static bool QuyenQuanLyMuonPhong()
        {
            return Permission.canDo(Permission._WEB_QLMUONPHUONG);
        }

        public static bool QuyenHienThiQuanTriVien()
        {
            return Permission.canView<QuanTriVien>(null);
        }

        public static bool QuyenThemQuanTriVien()
        {
            return Permission.canAdd<QuanTriVien>();
        }

        public static bool QuyenSuaQuanTriVien()
        {
            return Permission.canEdit<QuanTriVien>(null);
        }

        public static bool QuyenXoaQuanTriVien()
        {
            return Permission.canDelete<QuanTriVien>(null);
        }

        public static bool QuyenConfigEmailTemplate()
        {
            return Permission.canDo(Permission._SERVER_CONFIG);
        }

        public static bool QuyenThemHinhAnh()
        {
            return Permission.canAdd<HinhAnh>();
        }

        public static bool QuyenXoaHinhAnh()
        {
            return Permission.canDelete<HinhAnh>(null);
        }
    }
}
