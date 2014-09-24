using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter.SearchFilter
{
    public class CTTaiSanSF:_SearchFilterAbstract<CTTaiSanSF>
    {
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
        public static IQueryable<CTTaiSan> search(String tenTaiSan="", LoaiTaiSan loaiTaiSan=null, Boolean timTheoDonViQL=false, DonVi donViQuanLy=null, Boolean timTheoDonViSD=false, DonVi donViSuDung=null)
        {
            var query = CTTaiSan.getQuery();
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
            return query;
        }
    }
}
