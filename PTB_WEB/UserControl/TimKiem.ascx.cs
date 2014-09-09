using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

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
                var ten_nhanvienpts = NhanVienPT.getQuery().Where(c => c.hoten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (NhanVienPT ten_nhanvienpt in ten_nhanvienpts)
                    Searchs.Add(new DoSearch(ten_nhanvienpt.id, ten_nhanvienpt.hoten, "TENNHANVIENPT"));

                var sdt_nhanvienpts = NhanVienPT.getQuery().Where(c => c.sodienthoai.Contains(request)).Take(5).ToList();
                foreach (NhanVienPT sdt_nhanvienpt in sdt_nhanvienpts)
                    Searchs.Add(new DoSearch(sdt_nhanvienpt.id, sdt_nhanvienpt.sodienthoai, "SDTNHANVIENPT"));

                var ten_cosos = CoSo.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (CoSo ten_coso in ten_cosos)
                    Searchs.Add(new DoSearch(ten_coso.id, ten_coso.ten, "COSO"));

                var ten_days = Dayy.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (Dayy ten_day in ten_days)
                    Searchs.Add(new DoSearch(ten_day.id, ten_day.ten, "DAY"));

                var ten_tangs = Tang.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (Tang ten_tang in ten_tangs)
                    Searchs.Add(new DoSearch(ten_tang.id, ten_tang.ten, "TANG"));

                var ten_phongs = QuanLyTaiSan.Entities.Phong.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (QuanLyTaiSan.Entities.Phong ten_phong in ten_phongs)
                    Searchs.Add(new DoSearch(ten_phong.id, ten_phong.ten, "PHONG"));

                var ten_thietbis = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (QuanLyTaiSan.Entities.ThietBi ten_thietbi in ten_thietbis)
                    Searchs.Add(new DoSearch(ten_thietbi.id, ten_thietbi.ten, "THIETBI"));

                var ten_loaithietbis = QuanLyTaiSan.Entities.LoaiThietBi.getQuery().Where(c => c.ten.ToUpper().Contains(request)).Take(5).ToList();
                foreach (QuanLyTaiSan.Entities.LoaiThietBi ten_loaithietbi in ten_loaithietbis)
                    Searchs.Add(new DoSearch(ten_loaithietbi.id, ten_loaithietbi.ten, "LOAITHIETBI"));
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
                case "TENNHANVIENPT":
                    name = "Tên nhân viên phụ trách";
                    url = "/NhanVien.aspx?Search=";
                    break;
                case "SDTNHANVIENPT":
                    name = "Điện thoại nhân viên phụ trách";
                    url = "/NhanVien.aspx?Search=";
                    break;
                case "COSO":
                    name = "Cơ sở";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "DAY":
                    name = "Dãy";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "TANG":
                    name = "Tầng";
                    url = "/ViTri.aspx?Search=";
                    break;
                case "PHONG":
                    name = "Phòng";
                    url = "/Phong.aspx?Search=";
                    break;
                case "THIETBI":
                    name = "Thiết bị";
                    url = "/ThietBis.aspx?Search=";
                    break;
                case "LOAITHIETBI":
                    name = "Loại thiết bị";
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