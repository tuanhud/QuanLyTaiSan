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
            return Global.current_quantrivien_login.canDo(Permission._WEB_MUONPHUONG);
        }

        public static bool QuyenQuanLyMuonPhong()
        {
            //return Permission.can
            return Global.current_quantrivien_login.canDo(Permission._WEB_QLMUONPHUONG);
        }

        public static bool QuyenHienThiQuanTriVien()
        {
            return true;
        }

        public static bool QuyenThemQuanTriVien()
        {
            return Global.current_quantrivien_login.canAdd<QuanTriVien>();
        }

        public static bool QuyenSuaQuanTriVien(QuanTriVien _QuanTriVien)
        {
            return true;
            //return Global.current_quantrivien_login.canEdit<QuanTriVien>(_QuanTriVien);
        }

        public static bool QuyenXoaQuanTriVien(QuanTriVien _QuanTriVien)
        {
            return Global.current_quantrivien_login.canDelete<QuanTriVien>(_QuanTriVien);
        }

        public static bool QuyenConfigEmailTemplate()
        {
            return true;
        }
    }
}
