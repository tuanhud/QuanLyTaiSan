using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class NhanVienPTFilter : FilterAbstract<NhanVienPTFilter>
    {
        public NhanVienPTFilter()
            : base()
        {

        }

        public int id { get; set; }
        public String subId { get; set; }
        public String sodienthoai { get; set; }
        public String hoten { get; set; }
        public String imageURL { get; set; }
        #region Nghiep vu
        public static List<NhanVienPTFilter> getAll()
        {
            List<NhanVienPTFilter> re = db.NHANVIENPTS.Select(
                x => new NhanVienPTFilter
                {
                    id = x.id,
                    subId = x.subId,
                    hoten = x.hoten,
                    sodienthoai = x.sodienthoai,
                    imageURL = x.getAvatar()
                }
            ).ToList();

            return re;
        }
        #endregion
    }
}
