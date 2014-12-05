using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class TaiSanHienThi : _FilterAbstract<TaiSanHienThi>
    {
        public Guid id { get; set; }
        public DateTime? ngay { get; set; }
        public String sohieu_ct { get; set; }
        public DateTime? ngay_ct { get; set; }
        public String ten { get; set; }
        public String loaits { get; set; }
        public String donvitinh { get; set; }
        public int soluong { get; set; }
        public long dongia { get; set; }
        public long thanhtien { get; set; }
        public String nuocsx { get; set; }
        public String nguongoc { get; set; }
        public String tinhtrang { get; set; }
        public String ghichu { get; set; }
        public String phong { get; set; }
        public String vitri { get; set; }
        public String dvquanly { get; set; }
        public String dvsudung { get; set; }
        public ICollection<CTTaiSan> childs { get; set; }
        public CTTaiSan obj { get; set; }
        
        /// <summary>
        /// phan tram hao mon theo QD 351
        /// </summary>
        public double phantramhaomon_351
        {
            get
            {
                try
                {
                    return obj.taisan.loaitaisan.phantramhaomon_351;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return 1;
                    
                }
            }
        }
        /// <summary>
        /// phan tram hao mon theo QD 32
        /// </summary>
        public double phantramhaomon_32
        {
            get
            {
                try
                {
                    return obj.taisan.loaitaisan.phantramhaomon_32;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return 1;
                    
                }
            }
        }
        /// <summary>
        /// Lay YEAR cua ngay su dung
        /// </summary>
        public int namsudung
        {
            get
            {
                return ngay==null?0:ngay.Value.Year;
            }
        }
        /// <summary>
        /// Số năm đã sử dụng tính đến cuối 2008
        /// </summary>
        public int sonamdasudung_cuoi2008
        {
            get
            {
                try
                {
                    return (2008 - namsudung < 0 ? 0 : 2008 - namsudung);
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                    return 0;
                }
            }
        }
        /// <summary>
        /// so nam su dung theo quyet dinh 351
        /// </summary>
        public int sonamsudung_351
        {
            get
            {
                return obj.taisan.loaitaisan.sonamsudung_351;
            }
        }
        /// <summary>
        /// so nam su dung theo quyet dinh 32
        /// </summary>
        public int sonamsudung_32
        {
            get
            {
                return obj.taisan.loaitaisan.sonamsudung_32;
            }
        }
        /// <summary>
        /// so nam su dung con lai theo quyet dinh 351
        /// </summary>
        public int sonamsudungconlai_351
        {
            get
            {
                return sonamsudung_351 - sonamdasudung_cuoi2008 > 0?  sonamsudung_351 - sonamdasudung_cuoi2008:0;
            }
        }
        /// <summary>
        /// so nam su dung con lai theo quyet dinh 32
        /// </summary>
        public int sonamsudungconlai_32
        {
            get
            {
                return sonamsudung_32 - sonamdasudung_cuoi2008 > 0 ? sonamsudung_32 - sonamdasudung_cuoi2008 : 0;
            }
        }
        /// <summary>
        /// so nam su dung con lai theo quyet dinh 32
        /// </summary>
        public long giatriconlai_351
        {
            get
            {
                return (long)(thanhtien * phantramhaomon_351 * sonamsudungconlai_351);
            }
        }
        /// <summary>
        /// so nam su dung con lai theo quyet dinh 32
        /// </summary>
        public long giatriconlai_32
        {
            get
            {
                if (sonamsudungconlai_32 > 0)
                {
                    return giatriconlai_351;
                }
                else
                {
                    return 0;
                }
            }
        }
        public long giatriconlai_final { get; set; }
        public int sonamsudungconlai_final { get; set; }

        public static List<TaiSanHienThi> Convert(ICollection<CTTaiSan> list)
        {
            try
            {
                if (list == null || list.Count == 0)
                    return null;
                List<TaiSanHienThi> re =
                list.Select(ct => new TaiSanHienThi
                {
                    id = ct.id,
                    ngay = ct.ngay,
                    sohieu_ct = ct.chungtu != null ? ct.chungtu.sohieu : "",
                    ngay_ct = ct.chungtu != null ? ct.chungtu.ngay : null,
                    ten = ct.taisan.ten,
                    loaits = ct.taisan.loaitaisan.ten,
                    donvitinh = ct.taisan.loaitaisan.donvitinh != null ? ct.taisan.loaitaisan.donvitinh.ten : "",
                    soluong = ct.soluong,
                    dongia = ct.taisan.dongia,
                    thanhtien = ct.soluong * ct.taisan.dongia,
                    nuocsx = ct.taisan.nuocsx,
                    nguongoc = ct.nguongoc,
                    tinhtrang = ct.tinhtrang.value,
                    ghichu = ct.mota,
                    childs = ct.childs,
                    phong = ct.phong != null ? ct.phong.ten : "",
                    vitri = ct.vitri != null ? (ct.vitri.coso != null ? ct.vitri.coso.ten + (ct.vitri.day != null ? " - " +
                    ct.vitri.day.ten + (ct.vitri.tang != null ? " - " + ct.vitri.tang.ten : "") : "") : "") : "",
                    dvquanly = ct.donviquanly != null ? ct.donviquanly.ten : "",
                    dvsudung = ct.donvisudung != null ? ct.donvisudung.ten : "",
                    obj = ct,
                }).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TaiSanHienThi->Convert:" + ex.Message);
                return null;
            }
        }

        public static List<TaiSanHienThi> ConvertUsingSearch(IQueryable<CTTaiSan> list, string request)
        {
            try
            {
                request = SHARED.Libraries.StringHelper.CoDauThanhKhongDau(request).ToUpper();
                if (list == null)
                    return null;
                List<TaiSanHienThi> re =
                list.Select(ct => new TaiSanHienThi
                {
                    id = ct.id,
                    ten = ct.taisan.ten,
                    obj = ct
                }).Where(c => c.ten.ToUpper().Contains(request)).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TaiSanHienThi->Convert:" + ex.Message);
                return null;
            }
        }

        public static List<TaiSanHienThi> Convert(IQueryable<CTTaiSan> list)
        {
            try
            {
                if (list == null)
                    return null;
                List<TaiSanHienThi> re =
                list.Select(ct => new TaiSanHienThi
                {
                    id = ct.id,
                    ngay = ct.ngay,
                    sohieu_ct = ct.chungtu != null ? ct.chungtu.sohieu : "",
                    ngay_ct = ct.chungtu != null ? ct.chungtu.ngay : null,
                    ten = ct.taisan.ten,
                    loaits = ct.taisan.loaitaisan.ten,
                    donvitinh = ct.taisan.loaitaisan.donvitinh != null ? ct.taisan.loaitaisan.donvitinh.ten : "",
                    soluong = ct.soluong,
                    dongia = ct.taisan.dongia,
                    thanhtien = ct.soluong * ct.taisan.dongia,
                    nuocsx = ct.taisan.nuocsx,
                    nguongoc = ct.nguongoc,
                    tinhtrang = ct.tinhtrang.value,
                    ghichu = ct.mota,
                    childs = ct.childs,
                    phong = ct.phong != null ? ct.phong.ten : "",
                    vitri = ct.vitri != null ? (ct.vitri.coso != null ? ct.vitri.coso.ten + (ct.vitri.day != null ? " - " +
                    ct.vitri.day.ten + (ct.vitri.tang != null ? " - " + ct.vitri.tang.ten : "") : "") : "") : "",
                    dvquanly = ct.donviquanly != null ? ct.donviquanly.ten : "",
                    dvsudung = ct.donvisudung != null ? ct.donvisudung.ten : "",
                    obj = ct,
                }).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TaiSanHienThi->Convert:" + ex.Message);
                return null;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="nam">nam>=2009</param>
        /// <returns></returns>
        public static List<TaiSanHienThi> Convert(List<TaiSanHienThi> list, int nam)
        {
            var re = new List<TaiSanHienThi>();
            foreach(var item in list)
            {
                if(item.namsudung>2008 && item.namsudung<=nam)
                {
                    long haomon_trennam = item.thanhtien / item.sonamsudung_32;
                    long tongHaoMon = haomon_trennam * (nam - item.namsudung);
                    item.giatriconlai_final = item.thanhtien - tongHaoMon > 0?item.thanhtien-tongHaoMon:0;
                    item.sonamsudungconlai_final = item.sonamsudung_32 - (nam - item.namsudung);
                }
                else
                {
                    if (item.namsudung > nam)
                    {
                        //ignore
                    }
                    else if (item.giatriconlai_32 <= 0 || item.sonamsudungconlai_32 <= 0)
                    {
                        item.giatriconlai_final = 0;
                        item.sonamsudungconlai_final = 0;
                        re.Add(item);
                    }
                    else
                    {
                        //tinh ngay nam 2008 thi gia tri con lai chinh la theo uyet dinh 32
                        if (nam == 2008)
                        {
                            item.giatriconlai_final = item.giatriconlai_32;
                            item.sonamsudungconlai_final = item.sonamsudungconlai_final;
                        }
                        //khong tinh gia tri con lai duoc
                        else if (nam - 2008 < 0)
                        {
                            item.giatriconlai_final = -1;
                            item.sonamsudungconlai_final = item.sonamsudungconlai_32 + (2008 - nam);
                        }
                        else
                        {
                            long haomon_tren1nam = item.giatriconlai_32 / item.sonamsudungconlai_32;
                            long tonghaomon = (nam - 2008) * haomon_tren1nam;
                            item.giatriconlai_final = item.giatriconlai_32 - tonghaomon;
                            item.sonamsudungconlai_final = item.sonamsudungconlai_32 - (nam - 2008);
                        }
                        re.Add(item);
                    }
                }
            }

            return re;
        }
    }

}
