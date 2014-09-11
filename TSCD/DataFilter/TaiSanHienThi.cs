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
        public DateTime? ngayghi { get; set; }
        public String sohieu_ct { get; set; }
        public DateTime? ngay_ct { get; set; }
        public String ten { get; set; }
        public String loaits { get; set; }
        public String donvitinh { get; set; }
        public int soluong { get; set; }
        public long dongia { get; set; }
        public long thanhtien { get; set; }
        public String nguongoc { get; set; }
        public String tinhtrang { get; set; }
        public String ghichu { get; set; }
        public String phong { get; set; }
        public String vitri { get; set; }
        public String dvquanly { get; set; }
        public String dvsudung { get; set; }
        public ICollection<CTTaiSan> childs { get; set; }
        public CTTaiSan obj { get; set; }

        public static List<TaiSanHienThi> getAllNoDonVi()
        {
            List<TaiSanHienThi> re =
                (from ct in db.CTTAISANS
                 where (ct.donviquanly == null && ct.donvisudung == null)
                 select new TaiSanHienThi
                 {
                    id = ct.id,
                    ngayghi = ct.ngay,
                    sohieu_ct = ct.chungtu_sohieu,
                    ngay_ct = ct.chungtu_ngay,
                    ten = ct.taisan.ten,
                    loaits = ct.taisan.loaitaisan.ten,
                    donvitinh = ct.taisan.loaitaisan.donvitinh.ten,
                    soluong = ct.soluong,
                    dongia = ct.taisan.dongia,
                    thanhtien = ct.soluong*ct.taisan.dongia,
                    nguongoc = ct.nguongoc,
                    tinhtrang = ct.tinhtrang.value,
                    ghichu = ct.mota,
                    childs = ct.childs,
                    obj = ct,
                 }).ToList();
            return re;
        }

        public static List<TaiSanHienThi> getAllByDonVi(DonVi obj)
        {
            if (obj == null || obj.id == Guid.Empty)
                return null;
            List<TaiSanHienThi> re =
                (from ct in db.CTTAISANS
                 where (ct.donviquanly.id == obj.id || ct.donvisudung.id == obj.id)
                 select new TaiSanHienThi
                 {
                     id = ct.id,
                     ngayghi = ct.ngay,
                     sohieu_ct = ct.chungtu_sohieu,
                     ngay_ct = ct.chungtu_ngay,
                     ten = ct.taisan.ten,
                     loaits = ct.taisan.loaitaisan.ten,
                     donvitinh = ct.taisan.loaitaisan.donvitinh.ten,
                     soluong = ct.soluong,
                     dongia = ct.taisan.dongia,
                     thanhtien = ct.soluong * ct.taisan.dongia,
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

        public static List<TaiSanHienThi> getAllByParentIDForDonVi(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            List<TaiSanHienThi> re =
                (from ct in db.CTTAISANS
                 where (ct.parent.id == id)
                 select new TaiSanHienThi
                 {
                     id = ct.id,
                     ngayghi = ct.ngay,
                     sohieu_ct = ct.chungtu_sohieu,
                     ngay_ct = ct.chungtu_ngay,
                     ten = ct.taisan.ten,
                     loaits = ct.taisan.loaitaisan.ten,
                     donvitinh = ct.taisan.loaitaisan.donvitinh.ten,
                     soluong = ct.soluong,
                     dongia = ct.taisan.dongia,
                     thanhtien = ct.soluong * ct.taisan.dongia,
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

        public static List<TaiSanHienThi> getAllByParentId(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            List<TaiSanHienThi> re =
                (from ct in db.CTTAISANS
                 where (ct.parent.id == id)
                 select new TaiSanHienThi
                 {
                     id = ct.id,
                     ngayghi = ct.ngay,
                     sohieu_ct = ct.chungtu_sohieu,
                     ngay_ct = ct.chungtu_ngay,
                     ten = ct.taisan.ten,
                     loaits = ct.taisan.loaitaisan.ten,
                     donvitinh = ct.taisan.loaitaisan.donvitinh.ten,
                     soluong = ct.soluong,
                     dongia = ct.taisan.dongia,
                     thanhtien = ct.soluong * ct.taisan.dongia,
                     nguongoc = ct.nguongoc,
                     tinhtrang = ct.tinhtrang.value,
                     ghichu = ct.mota,
                     childs = ct.childs,
                     obj = ct,
                 }).ToList();
            return re;
        }

        public static List<TaiSanHienThi> Convert(List<CTTaiSan> list)
        {
            if (list == null || list.Count == 0)
                return null;
            List<TaiSanHienThi> re =
            list.Select(ct => new TaiSanHienThi 
            {
                id = ct.id,
                ngayghi = ct.ngay,
                sohieu_ct = ct.chungtu_sohieu,
                ngay_ct = ct.chungtu_ngay,
                ten = ct.taisan.ten,
                loaits = ct.taisan.loaitaisan.ten,
                donvitinh = ct.taisan.loaitaisan.donvitinh.ten,
                soluong = ct.soluong,
                dongia = ct.taisan.dongia,
                thanhtien = ct.soluong * ct.taisan.dongia,
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
    }
}
