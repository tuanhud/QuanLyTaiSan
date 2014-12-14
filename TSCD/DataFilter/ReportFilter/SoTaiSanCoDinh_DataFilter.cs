using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCD.DataFilter.ReportFilter
{
    public class SoTaiSanCoDinh_DataFilter
    {
        public DateTime? ngay { get; set; }
        public String sohieu_ct { get; set; }
        public String ten { get; set; }
        public String nuocsx { get; set; }
        public long dongia_tang { get; set; }
        public String sohieu_ct_tang { get; set; }
        public DateTime? ngay_ct_tang { get; set; }
        public String sohieu_ct_giam { get; set; }
        public DateTime? ngay_ct_giam { get; set; }
        public String ghichu { get; set; }
        public Double phantramhaomon_32 { get; set; }
        public long sotientrongmotnam { get; set; }
        public long haomon_1nam { get; set; }
        public long giatriconlai_final { get; set; }
        public long haomonluyke { get; set; }
        public long haomonnamtruocchuyensang { get; set; }
    }
}
