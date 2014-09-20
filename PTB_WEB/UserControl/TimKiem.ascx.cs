using PTB.DataFilter;
using PTB.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using PTB.DataFilter.SearchFilter;

namespace PTB_WEB.UserControl
{
    public partial class TimKiem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public static List<DoSearch> DoSearch(string request)
        {
            int limit = 100;
            Boolean isMobile = MobileDetect.fBrowserIsMobile();
            if (isMobile)
                limit = 3;

            List<DoSearch> Searchs = new List<DoSearch>();
            try
            {
                List<CoSoSF> ListCoSoSF = CoSoSF.search(request).Take(limit).ToList();
                foreach (CoSoSF _CoSoSF in ListCoSoSF)
                {
                    if (_CoSoSF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(_CoSoSF.obj.id, _CoSoSF.obj.ten, "TENCOSO"));
                    else
                        Searchs.Add(new DoSearch(_CoSoSF.obj.id, _CoSoSF.obj.subId, "MACOSO"));
                }

                List<DayySF> ListDayySF = DayySF.search(request).Take(limit).ToList();
                foreach (DayySF _DayySF in ListDayySF)
                {
                    if (_DayySF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(_DayySF.obj.id, string.Format("{0} ({1})", _DayySF.obj.ten, _DayySF.obj.coso != null ? _DayySF.obj.coso.ten : "[Cơ sở]"), "TENDAY"));
                    else
                        Searchs.Add(new DoSearch(_DayySF.obj.id, string.Format("{0} ({1})", _DayySF.obj.subId, _DayySF.obj.coso != null ? _DayySF.obj.coso.ten : "[Cơ sở]"), "MADAY"));
                }

                List<TangSF> ListTangSF = TangSF.search(request).Take(limit).ToList();
                foreach (TangSF _TangSF in ListTangSF)
                {
                    if (_TangSF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(_TangSF.obj.id, string.Format("{0} ({1} - {2})", _TangSF.obj.ten, _TangSF.obj.day != null ? _TangSF.obj.day.coso != null ? _TangSF.obj.day.coso.ten : "[Cơ sở]" : "[Cơ sở]", _TangSF.obj.day != null ? _TangSF.obj.day.ten : "[Dãy]"), "TENTANG"));
                    else
                        Searchs.Add(new DoSearch(_TangSF.obj.id, string.Format("{0} ({1} - {2})", _TangSF.obj.subId, _TangSF.obj.day != null ? _TangSF.obj.day.coso != null ? _TangSF.obj.day.coso.ten : "[Cơ sở]" : "[Cơ sở]", _TangSF.obj.day != null ? _TangSF.obj.day.ten : "[Dãy]"), "MATANG"));
                }

                List<PhongSF> ListPhongSF = PhongSF.search(request).Take(limit).ToList();
                foreach (PhongSF _PhongSF in ListPhongSF)
                {
                    string strViTri = Libraries.StringHelper.StringViTriPhong(_PhongSF.obj);
                    if (_PhongSF.match_field.FirstOrDefault().Equals("ten"))
                    {
                        Searchs.Add(new DoSearch(_PhongSF.obj.id, string.Format("{0}{1}", _PhongSF.obj.ten, !Object.Equals(strViTri, "") ? " " + strViTri : ""), "TENPHONG"));
                    }
                    else
                        Searchs.Add(new DoSearch(_PhongSF.obj.id, string.Format("{0}{1}", _PhongSF.obj.subId, !Object.Equals(strViTri, "") ? " " + strViTri : ""), "MAPHONG"));
                }

                List<ThietBiSF> ListThietBiSF = ThietBiSF.search(request).Take(limit).ToList();
                foreach (ThietBiSF _ThietBiSF in ListThietBiSF)
                {
                    if (_ThietBiSF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(_ThietBiSF.obj.id, _ThietBiSF.obj.ten, "TENTHIETBI"));
                    else
                        Searchs.Add(new DoSearch(_ThietBiSF.obj.id, _ThietBiSF.obj.subId, "MATHIETBI"));
                }

                List<LoaiThietBiSF> ListLoaiThietBiSF = LoaiThietBiSF.search(request).Take(limit).ToList();
                foreach (LoaiThietBiSF _LoaiThietBiSF in ListLoaiThietBiSF)
                {
                    if (_LoaiThietBiSF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(_LoaiThietBiSF.obj.id, _LoaiThietBiSF.obj.ten, "TENLOAITHIETBI"));
                    else
                        Searchs.Add(new DoSearch(_LoaiThietBiSF.obj.id, _LoaiThietBiSF.obj.subId, "MALOAITHIETBI"));
                }

                List<NhanVienPTSF> ListNhanVienPTSF = NhanVienPTSF.search(request).Take(limit).ToList();
                foreach (NhanVienPTSF _NhanVienPTSF in ListNhanVienPTSF)
                {
                    if (_NhanVienPTSF.match_field.FirstOrDefault().Equals("hoten"))
                        Searchs.Add(new DoSearch(_NhanVienPTSF.obj.id, _NhanVienPTSF.obj.hoten, "TENNHANVIENPT"));
                    else if (_NhanVienPTSF.match_field.FirstOrDefault().Equals("sodienthoai"))
                        Searchs.Add(new DoSearch(_NhanVienPTSF.obj.id, _NhanVienPTSF.obj.sodienthoai, "SDTNHANVIENPT"));
                    else
                        Searchs.Add(new DoSearch(_NhanVienPTSF.obj.id, _NhanVienPTSF.obj.subId, "MANHANVIENPT"));
                }

                List<SuCoPhongSF> ListSuCoPhongSF = SuCoPhongSF.search(request).Take(limit).ToList();
                foreach (SuCoPhongSF _SuCoPhongSF in ListSuCoPhongSF)
                {
                    if (_SuCoPhongSF.match_field.FirstOrDefault().Equals("ten"))
                        Searchs.Add(new DoSearch(_SuCoPhongSF.obj.id, _SuCoPhongSF.obj.ten, "TENSUCO"));
                    else
                        Searchs.Add(new DoSearch(_SuCoPhongSF.obj.id, _SuCoPhongSF.obj.mota, "MOTASUCO"));
                }
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
                case "MOTASUCO":
                    name = "Mô tả sự cố";
                    url = "/SuCo.aspx?Search=";
                    break;
                case "TENSUCO":
                    name = "Tên sự cố";
                    url = "/SuCo.aspx?Search=";
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