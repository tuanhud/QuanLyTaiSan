using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using QuanLyTaiSan.DataFilter.SearchFilter;

namespace PTB_WEB.UserControl
{
    public partial class TimKiem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static List<DoSearch> DoSearch(string request)
        {
            List<DoSearch> Searchs = new List<DoSearch>();
            try
            {
                List<NhanVienPTSF> ListNhanVienPTSFs = NhanVienPTSF.search(request);
                foreach (NhanVienPTSF ListNhanVienPTSF in ListNhanVienPTSFs)
                {
                    if (ListNhanVienPTSF.match_field.FirstOrDefault().Equals("hoten"))
                        Searchs.Add(new DoSearch(ListNhanVienPTSF.obj.id, ListNhanVienPTSF.obj.hoten, "TENNHANVIENPT"));
                    else if (ListNhanVienPTSF.match_field.FirstOrDefault().Equals("sodienthoai"))
                        Searchs.Add(new DoSearch(ListNhanVienPTSF.obj.id, ListNhanVienPTSF.obj.sodienthoai, "SDTNHANVIENPT"));                        
                    else
                        Searchs.Add(new DoSearch(ListNhanVienPTSF.obj.id, ListNhanVienPTSF.obj.subId, "MANHANVIENPT"));
                }

                List<CoSoSF> ListCoSoSFs = CoSoSF.search(request);
                foreach (CoSoSF ListCoSoSF in ListCoSoSFs)
                {
                    if (ListCoSoSF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(ListCoSoSF.obj.id, ListCoSoSF.obj.ten, "TENCOSO"));
                    else
                        Searchs.Add(new DoSearch(ListCoSoSF.obj.id, ListCoSoSF.obj.subId, "MACOSO"));
                }

                List<DayySF> ListDayySFs = DayySF.search(request);
                foreach (DayySF ListDayySF in ListDayySFs)
                {
                    if (ListDayySF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(ListDayySF.obj.id, string.Format("{0} ({1})", ListDayySF.obj.ten, ListDayySF.obj.coso != null ? ListDayySF.obj.coso.ten : "[Cơ sở]"), "TENDAY"));
                    else
                        Searchs.Add(new DoSearch(ListDayySF.obj.id, string.Format("{0} ({1})", ListDayySF.obj.subId, ListDayySF.obj.coso != null ? ListDayySF.obj.coso.ten : "[Cơ sở]"), "MADAY"));
                }

                List<TangSF> ListTangSFs = TangSF.search(request);
                foreach (TangSF ListTangSF in ListTangSFs)
                {
                    if (ListTangSF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(ListTangSF.obj.id, string.Format("{0} ({1} - {2})", ListTangSF.obj.ten, ListTangSF.obj.day != null ? ListTangSF.obj.day.coso != null ? ListTangSF.obj.day.coso.ten : "[Cơ sở]" : "[Cơ sở]", ListTangSF.obj.day != null ? ListTangSF.obj.day.ten : "[Dãy]"), "TENTANG"));
                    else
                        Searchs.Add(new DoSearch(ListTangSF.obj.id, string.Format("{0} ({1} - {2})", ListTangSF.obj.subId, ListTangSF.obj.day != null ? ListTangSF.obj.day.coso != null ? ListTangSF.obj.day.coso.ten : "[Cơ sở]" : "[Cơ sở]", ListTangSF.obj.day != null ? ListTangSF.obj.day.ten : "[Dãy]"), "MATANG"));
                }

                List<PhongSF> ListPhongSFs = PhongSF.search(request);
                foreach (PhongSF ListPhongSF in ListPhongSFs)
                {
                    string strViTri = Libraries.StringHelper.StringViTriPhong(ListPhongSF.obj);
                    if (ListPhongSF.match_field.FirstOrDefault().Equals("ten"))
                    {
                        Searchs.Add(new DoSearch(ListPhongSF.obj.id, string.Format("{0}{1}", ListPhongSF.obj.ten, !Object.Equals(strViTri, "") ? " " + strViTri : ""), "TENPHONG"));
                    }
                    else
                        Searchs.Add(new DoSearch(ListPhongSF.obj.id, string.Format("{0}{1}", ListPhongSF.obj.subId, !Object.Equals(strViTri, "") ? " " + strViTri : ""), "MAPHONG"));
                }

                var ten_thietbis = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (QuanLyTaiSan.Entities.ThietBi ten_thietbi in ten_thietbis)
                    Searchs.Add(new DoSearch(ten_thietbi.id, ten_thietbi.ten, "TENTHIETBI"));

                var ten_loaithietbis = QuanLyTaiSan.Entities.LoaiThietBi.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (QuanLyTaiSan.Entities.LoaiThietBi ten_loaithietbi in ten_loaithietbis)
                    Searchs.Add(new DoSearch(ten_loaithietbi.id, ten_loaithietbi.ten, "TENLOAITHIETBI"));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return Searchs;
        }

        protected string Convert(string value, string loai)
        {
            string name = string.Empty;
            string url = string.Empty;
            switch (value)
            {
                case "MANHANVIENPT":
                    name = "Mã nhân viên phụ trách";
                    url = "/NhanVien.aspx?Search=";
                    break;
                case "TENNHANVIENPT":
                    name = "Tên nhân viên phụ trách";
                    url = "/NhanVien.aspx?Search=";
                    break;
                case "SDTNHANVIENPT":
                    name = "Điện thoại nhân viên phụ trách";
                    url = "/NhanVien.aspx?Search=";
                    break;
                case "MACOSO":
                    name = "Mã cơ sở";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "TENCOSO":
                    name = "Tên cơ sở";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "MADAY":
                    name = "Mã dãy";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "TENDAY":
                    name = "Tên dãy";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "MATANG":
                    name = "Mã tầng";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "TENTANG":
                    name = "Tên tầng";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "MAPHONG":
                    name = "Mã phòng";
                    url = "/Phong.aspx?Search=";
                    break;
                case "TENPHONG":
                    name = "Tên phòng";
                    url = "/Phong.aspx?Search=";
                    break;
                case "MATHIETBI":
                    name = "Mã thiết bị";
                    url = "/ThietBis.aspx?Search=";
                    break;
                case "TENTHIETBI":
                    name = "Tên thiết bị";
                    url = "/ThietBis.aspx?Search=";
                    break;
                case "MALOAITHIETBI":
                    name = "Mã loại thiết bị";
                    url = "/LoaiThietBis.aspx?Search=";
                    break;
                case "TENLOAITHIETBI":
                    name = "Tên loại thiết bị";
                    url = "/LoaiThietBis.aspx?Search=";
                    break;
            }
            if (loai.Equals("name"))
                return name;
            return url;
        }

        //static List<string[]> SplitRequests(string request)
        //{
        //    var words = request.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        //    var result = new List<string[]>();
        //    foreach (var word in words)
        //    {
        //        var resultWord = PrepareWord(word);
        //        var synonymList = Synonyms.FirstOrDefault(list => list.Any(s => MatchWord(resultWord, s)));
        //        var wordSynonyms = new List<string>() { resultWord };
        //        if (synonymList != null)
        //            wordSynonyms.AddRange(synonymList.Where(s => !MatchWord(resultWord, s)));
        //        result.Add(wordSynonyms.Distinct().ToArray());
        //    }
        //    return result;
        //}

        protected void SearchPopup_WindowCallback(object source, DevExpress.Web.ASPxPopupControl.PopupWindowCallbackArgs e)
        {
            var text = e.Parameter;
            var results = DoSearch(text);
            var resultsPanel = SearchPopup.FindControl("ResultsPanel");
            var noResultsPanel = SearchPopup.FindControl("NoResultsPanel");
            if (results.Count > 0)
            {
                resultsPanel.Visible = true;
                noResultsPanel.Visible = false;
                var grouppedResults = results.GroupBy(c => c.loai);
                foreach (var Group in grouppedResults)
                {
                    var info = Group.Key;
                    var group = SearchResultsNavBar.Groups.Add(Convert(info, "name"), string.Empty, string.Empty, string.Empty);
                    foreach (var res in Group)
                    {
                        group.Items.Add(res.ten, string.Empty, string.Empty, Convert(res.loai, "url") + res.id);
                    }
                }
            }
            else
            {
                resultsPanel.Visible = false;
                noResultsPanel.Visible = true;
                var requestText = noResultsPanel.FindControl("RequestText") as HtmlGenericControl;
                requestText.InnerHtml = text;
            }
        }
    }
}