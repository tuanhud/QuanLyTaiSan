using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHARED.Libraries;
using TSCD.Entities;

namespace TSCD.DataFilter.SearchFilter
{
    public class CTTaiSanSF:_SearchFilterAbstract<CTTaiSan>
    {
        public static List<CTTaiSanSF> searchByDonvi(string key_word, List<DonVi> donvis)
        {
            List<CTTaiSanSF> re = new List<CTTaiSanSF>();
            List<CTTaiSan> tmp = new List<CTTaiSan>();
            try
            {
                foreach (var item in donvis)
                {
                    tmp.AddRange(
                        item.cttaisans.Where(c => c.taisan.ten.ToLower().Contains(key_word))
                    );
                }
                foreach (var item in tmp)
                {
                    CTTaiSanSF obj = new CTTaiSanSF();
                    obj.obj = item;
                    obj.match_field.Add("taisan.ten");
                    re.Add(obj);
                }
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return re;
            }
        }
        /// <summary>
        /// Hàm tìm kiếm dạng QueryAble, sau khi lấy kết quả có thể 
        /// lọc lần 2 bằng Where rồi gọi .ToList(); sẽ ra được kết quả sau cùng
        /// </summary>
        /// <param name="tenTaiSan">(null||blank)=>ignore</param>
        /// <param name="loaiTaiSan">null=>ignore</param>
        /// <param name="timTheoDonViQL">false=>ignore</param>
        /// <param name="donViQuanLy"></param>
        /// <param name="timTheoDonViSD">false=>ignore</param>
        /// <param name="donViSuDung"></param>
        /// <returns></returns>
        public static IQueryable<CTTaiSan> search(
            String tenTaiSan="", 
            LoaiTaiSan loaiTaiSan=null,
            Boolean timTheoDonViQL=false,
            DonVi donViQuanLy=null,
            Boolean timTheoDonViSD=false,
            DonVi donViSuDung=null,
            Boolean timTheoViTri=false,
            ViTri vitri=null,
            Boolean timTheoPhong=false,
            Phong phong=null,
            List<Guid> tinhtrangs = null,
            String equation = null, 
            long? dongia = null,
            String equation_ngay = null,
            DateTime? ngay_sd = null
            )
        {
            var query = CTTaiSan.getQuery();
            query = query.Where(c => c.soluong > 0);
            if(tenTaiSan!=null && !tenTaiSan.Equals(""))
            {
                query = query.Where(c => c.taisan.ten.ToLower().Contains(tenTaiSan.ToLower()));
            }
            if (loaiTaiSan != null)
            {
                //tim kiem de quy cho loai tai san
                List<LoaiTaiSan> list = loaiTaiSan.getAllChildsRecursive(true);
                List<Guid> list_id = list.Select(c => c.id).ToList();

                query = query.Where(c=>list_id.Contains(c.taisan.loaitaisan.id));
            }
            if (timTheoDonViQL)
            {
                if (donViQuanLy == null)
                {
                    query = query.Where(c => c.donviquanly == null);
                }
                else
                {
                    //tim kiem de quy cho dvquanly
                    List<DonVi> list = donViQuanLy.getAllChildsRecursive();
                    List<Guid> list_id = list.Select(c => c.id).ToList();

                    query = query.Where(c => (c.donviquanly != null) && (list_id.Contains(c.donviquanly.id)));
                }
            }
            if (timTheoDonViSD)
            {
                if (donViSuDung == null)
                {
                    query = query.Where(c => c.donvisudung == null);
                }
                else
                {
                     //tim kiem de quy cho dvquanly
                    List<DonVi> list = donViSuDung.getAllChildsRecursive();
                    List<Guid> list_id = list.Select(c => c.id).ToList();

                    query = query.Where(c => (c.donvisudung != null) && (list_id.Contains(c.donvisudung.id)));
                }
            }
            if (timTheoViTri)
            {
                if (vitri == null)
                {
                    query = query.Where(c => c.vitri == null);
                }
                else
                {
                    query = query.Where(c =>
                        //Tìm chính xác theo vị trí
                        (c.vitri != null && c.vitri.id == vitri.id)
                        ||
                        //Tìm luôn record có phòng thuộc vitri
                        (c.phong!=null && c.phong.vitri !=null && c.phong.vitri.id == vitri.id)
                        );
                }
            }
            if (timTheoPhong)
            {
                if (phong == null)
                {
                    query = query.Where(c => c.phong == null);
                }
                else
                {
                    query = query.Where(c =>
                        (c.phong != null && c.phong.id == phong.id)
                    );
                }
            }
            if (tinhtrangs != null && tinhtrangs.Count > 0)
            {
                query = query.Where(c => c.tinhtrang == null || tinhtrangs.Contains(c.tinhtrang.id));
            }

            //DONGIA
            if ((equation != null && (equation.Equals("=") || equation.Equals(">=") || equation.Equals(">") || equation.Equals("<=") || equation.Equals("<"))) && dongia != null && dongia >= 0)
            {
                if (equation.Equals("="))
                    query = query.Where(x => x.taisan.dongia == dongia);
                else if (equation.Equals(">="))
                    query = query.Where(x => x.taisan.dongia >= dongia);
                else if (equation.Equals(">"))
                    query = query.Where(x => x.taisan.dongia > dongia);
                else if (equation.Equals("<="))
                    query = query.Where(x => x.taisan.dongia <= dongia);
                else if (equation.Equals("<"))
                    query = query.Where(x => x.taisan.dongia < dongia);
            }

            //NGAYSUDUNG
            if ((equation_ngay != null && (equation_ngay.Equals("=") || equation_ngay.Equals(">=") || equation_ngay.Equals(">") || equation_ngay.Equals("<=") || equation_ngay.Equals("<"))) && ngay_sd != null)
            {
                if (equation_ngay.Equals("="))
                    query = query.Where(x => x.ngay == null || x.ngay == ngay_sd);
                else if (equation_ngay.Equals(">="))
                    query = query.Where(x => x.ngay == null || x.ngay >= ngay_sd);
                else if (equation_ngay.Equals(">"))
                    query = query.Where(x => x.ngay == null || x.ngay > ngay_sd);
                else if (equation_ngay.Equals("<="))
                    query = query.Where(x => x.ngay == null || x.ngay <= ngay_sd);
                else if (equation_ngay.Equals("<"))
                    query = query.Where(x => x.ngay == null || x.ngay < ngay_sd);
            }
            return query;
        }
    }
}
