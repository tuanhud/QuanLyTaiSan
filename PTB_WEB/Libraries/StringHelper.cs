using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTB_WEB.Libraries
{
    public class StringHelper
    {
        public static Uri AddParameter(Uri url, string paramName, string paramValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Remove(paramName);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();
            return new Uri(uriBuilder.ToString());
        }

        public static Uri AddParameter(Uri url, List<string> listParamName, List<string> listParamValue)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            for (int i = 0; i < listParamName.Count; i++)
            {
                query.Remove(listParamName.ElementAt(i));
                query[listParamName.ElementAt(i)] = listParamValue.ElementAt(i);
            }
            uriBuilder.Query = query.ToString();
            return new Uri(uriBuilder.ToString());
        }

        public static Uri AddParameter(Uri url, string paramName, string paramValue, List<string> listRemove)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            for (int i = 0; i < listRemove.Count; i++)
                query.Remove(listRemove.ElementAt(i));
            query.Remove(paramName);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();
            return new Uri(uriBuilder.ToString());
        }

        public static Uri RemoveParameter(Uri url, List<string> listRemove)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            for (int i = 0; i < listRemove.Count; i++)
                query.Remove(listRemove.ElementAt(i));
            uriBuilder.Query = query.ToString();
            return new Uri(uriBuilder.ToString());
        }

        public static String ConvertRNToBR(string content)
        {
            try
            {
                if (content.IndexOf("\r\n") != -1)
                    return content.Replace("\r\n", "<br />");
                else
                    return content;
            }
            catch
            {
                return content;
            }
        }

        public static String ConvertBRToRN(string content)
        {
            try
            {
                if (content.IndexOf("<br />") != -1)
                    return content.Replace("<br />", "\r\n");
                else
                    return content;
            }
            catch
            {
                return content;
            }
        }

        public static String SplitCharacter(string content, int number)
        {
            string[] ct = content.Split(' ');
            string str = string.Empty;
            for (int i = 0; i < number - 1; i++)
            {
                str += ct[i] + " ";
            }
            str += ct[number] + "...";
            return str;
        }

        public static String StringViTriPhong(QuanLyTaiSan.Entities.Phong objPhong)
        {
            String strViTri = "";
            if (objPhong.vitri != null)
            {
                if (objPhong.vitri.coso != null)
                {
                    strViTri = string.Format("({0}", objPhong.vitri.coso.ten);
                    if (objPhong.vitri.day != null)
                    {
                        strViTri += string.Format(" - {0}", objPhong.vitri.day.ten);
                        if (objPhong.vitri.tang != null)
                        {
                            strViTri += string.Format(" - {0})", objPhong.vitri.tang.ten);
                        }
                        else
                        {
                            strViTri += ")";
                        }
                    }
                    else
                    {
                        strViTri += ")";
                    }
                }
            }
            return strViTri;
        }

        public static String TitleContent(QuanLyTaiSan.Entities.PhieuMuonPhong objPhieuMuonPhong)
        {
            string Title_Content = QuanLyTaiSan.Global.remote_setting.email_template.DEFAULT_TITLE_TEMPLATE;
            Title_Content = Title_Content.Replace("{NgayTao}", Convert.ToDateTime(objPhieuMuonPhong.date_create).ToString("d/M/yyyy"));
            return Title_Content;
        }

        public static String MailContent(QuanLyTaiSan.Entities.PhieuMuonPhong objPhieuMuonPhong, string tinhtrang)
        {
            string Mail_Content = QuanLyTaiSan.Global.remote_setting.email_template.DEFAULT_CONTENT_TEMPLATE;
            Mail_Content = Mail_Content.Replace("{HoTenNguoiDuyet}", objPhieuMuonPhong.nguoiduyet.hoten);
            Mail_Content = Mail_Content.Replace("{EmailNguoiDuyet}", objPhieuMuonPhong.nguoiduyet.email);
            Mail_Content = Mail_Content.Replace("{HoTenNguoiNhan}", objPhieuMuonPhong.nguoimuon.hoten);
            Mail_Content = Mail_Content.Replace("{EmailNguoiNhan}", objPhieuMuonPhong.nguoimuon.hoten);
            Mail_Content = Mail_Content.Replace("{ThongTinPhieuMuon}", PhieuMuonPhongContent(objPhieuMuonPhong));
            Mail_Content = Mail_Content.Replace("{TinhTrang}", tinhtrang);
            Mail_Content = Mail_Content.Replace("{GhiChu}", PTB_WEB.Libraries.StringHelper.ConvertRNToBR(objPhieuMuonPhong.ghichu));
            return Mail_Content;
        }

        public static String PhieuMuonPhongContent(QuanLyTaiSan.Entities.PhieuMuonPhong objPhieuMuonPhong)
        {
            return String.Format("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr><td>Ng&agrave;y tạo:</td><td><strong>{0}</strong></td></tr><tr><td>Ng&agrave;y mượn:</td><td><strong>{1}</strong></td></tr><tr><td>Thời gian mượn:</td><td><strong>Từ {2} đến {3}</strong></td></tr><tr><td>Số lượng ph&ograve;ng mượn:</td><td><strong>{4}</strong></td></tr><tr><td>Số lượng sinh vi&ecirc;n/ ph&ograve;ng:</td><td><strong>{5}</strong></td></tr><tr><td>Lớp mượn:</td><td><strong>{6}</strong></td></tr><tr><td>L&yacute; do sử dụng:</td><td><strong>{7}</strong></td></tr></tbody></table>", Convert.ToDateTime(objPhieuMuonPhong.date_create).ToString("d/M/yyyy HH\\hmm"), Convert.ToDateTime(objPhieuMuonPhong.ngaymuon).ToString("d/M/yyyy"), Convert.ToDateTime(objPhieuMuonPhong.ngaymuon).ToString("HH\\hmm"), Convert.ToDateTime(objPhieuMuonPhong.ngaytra).ToString("HH\\hmm"), objPhieuMuonPhong.sophong, objPhieuMuonPhong.soluongsv, objPhieuMuonPhong.lop, PTB_WEB.Libraries.StringHelper.ConvertRNToBR(objPhieuMuonPhong.lydomuon));
        }
    }
}