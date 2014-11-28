using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class TK_TangGiam_TheoLoaiTS : _FilterAbstract<TK_TangGiam_TheoLoaiTS>
    {
        public Guid id_loai { get; set; }
        public String tenloai { get; set; }
        public String donvitinh { get; set; }

        public int sodaunam_soluong { get; set; }
        public long sodaunam_giatri { get; set; }

        public int tangtrongnam_soluong { get; set; }
        public long tangtrongnam_giatri { get; set; }

        public int giamtrongnam_soluong { get; set; }
        public long giamtrongnam_giatri { get; set; }

        public int socuoinam_soluong { get; set; }
        public long socuoinam_giatri { get; set; }
        /// <summary>
        /// vd: muốn thống kê cho năm 2014 thì from=(2014,1,1), to=(2014,12,31)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static List<TK_TangGiam_TheoLoaiTS> getAll(DateTime? from, DateTime? to)
        {
            var list_loaits = LoaiTaiSan.getAll();
            List<TK_TangGiam_TheoLoaiTS> re = new List<TK_TangGiam_TheoLoaiTS>();

            foreach (var item in list_loaits)
            {
                TK_TangGiam_TheoLoaiTS obj = new TK_TangGiam_TheoLoaiTS();
                obj.tenloai = item.ten;
                obj.id_loai = item.id;
                obj.donvitinh = item.donvitinh ==null ? "":item.donvitinh.ten;
                int count=0;
                foreach (var taisan in item.taisans)
                {
                    //Tính số đầu năm
                    foreach (var ctts in taisan.cttaisans.Where(
                        c =>
                            c.soluong > 0
                            &&
                            (
                                (c.ngay != null && c.ngay < from)
                            )
                        )
                    )
                    {
                        obj.sodaunam_soluong += ctts.soluong;
                        obj.sodaunam_giatri += ctts.thanhtien;
                    }
                    var tmp = taisan.cttaisans.Where(
                        c =>
                            c.soluong > 0
                            &&
                            (
                                (c.ngay != null && c.ngay < from)
                            )
                        );
                    obj.sodaunam_soluong = tmp.Sum(x => x.soluong);
                    obj.sodaunam_giatri = tmp.Sum(x => x.thanhtien);


                    var list_log_ctts = taisan.logtanggiamtaisans.Where(c => c.date_create != null && c.date_create >= from && c.date_create <= to && c.soluong > 0);
                    Console.WriteLine("quocdunginfo: " + count++);

                    var tmp_giam = list_log_ctts.Where(x => x.tang_giam == -1);
                    obj.giamtrongnam_soluong = tmp_giam.Sum(x => x.soluong);
                    obj.giamtrongnam_giatri = tmp_giam.Sum(x => x.thanhtien);

                    var tmp_tang = list_log_ctts.Where(x => x.tang_giam == 1);
                    obj.tangtrongnam_soluong = tmp_giam.Sum(x => x.soluong);
                    obj.tangtrongnam_giatri = tmp_giam.Sum(x => x.thanhtien);
                    //Tính tăng/giảm trong năm
                    foreach (var ctts in list_log_ctts.Where(c => c.tang_giam == 1 || c.tang_giam == -1))
                    {
                        if (ctts.tang_giam == 1)
                        {
                            obj.tangtrongnam_soluong += ctts.soluong;
                            obj.tangtrongnam_giatri += ctts.thanhtien;
                        }
                        else if (ctts.tang_giam == -1)
                        {
                            obj.giamtrongnam_soluong += ctts.soluong;
                            obj.giamtrongnam_giatri += ctts.thanhtien;
                        }
                    }
                    //Tính số cuối năm
                    obj.socuoinam_soluong = obj.sodaunam_soluong + obj.tangtrongnam_soluong - obj.giamtrongnam_soluong;
                    obj.socuoinam_giatri = obj.sodaunam_giatri + obj.tangtrongnam_giatri - obj.giamtrongnam_giatri;
                }
                //add to list
                re.Add(obj);
            }
            //final filter, tự động tính tổng cho loại TS cha nếu cần
            //...
            return re;
        }
    }
}
