using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCD.DataFilter.ReportFilter
{
    public class SoTheoDoiTaiSanCoDinhTaiNoiSuDung_DataFilter
    {
        public String sohieu_ct { get; set; }
        public DateTime? ngay_ct { get; set; }
        public String ten { get; set; }
        public String donvitinh { get; set; }
        public int? soluong_tang { get; set; }
        public long? dongia_tang { get; set; }
        public long? thanhtien_tang { get; set; }
        public int? soluong_giam { get; set; }
        public long? dongia_giam { get; set; }
        public long? thanhtien_giam { get; set; }
        public String ghichu { get; set; }
    }
}
