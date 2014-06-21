namespace QuanLyTaiSan.Migrations
{
    using QuanLyTaiSan.Entities;
    using QuanLyTaiSan.Libraries;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyTaiSan.Entities.OurDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OurDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //DateTime now = ServerTimeHelper.getNow();
            ////Tình trạng
            //context.TINHTRANGS.AddOrUpdate(
            //    p => p.key,
            //    new TinhTrang { key = "MOI", value = "Mới" },
            //    new TinhTrang { key = "DANGSUDUNG", value = "Đang sử dụng" },
            //    new TinhTrang { key = "DANGSUACHUA", value = "Đang sửa chữa" },
            //    new TinhTrang { key = "HONG", value = "Hỏng" }
            //    );
            //context.SaveChanges();
            ////Cơ sở
            //context.COSOS.AddOrUpdate(
            //    p => p.ten,
            //    new CoSo { subId = "CSC", ten = "Cơ sở chính", date_create = now, date_modified = now },
            //    new CoSo { subId = "CS1", ten = "Cơ sở 1", date_create = now, date_modified = now },
            //    new CoSo { subId = "CS2", ten = "Cơ sở 2", date_create = now, date_modified = now },
            //    new CoSo { subId = "CS3", ten = "Cơ sở 3", date_create = now, date_modified = now }
            //    );
            //context.SaveChanges();
            ////Dãy
            //CoSo coso_ = context.COSOS.FirstOrDefault(c=>c.subId.ToUpper().Equals("CSC"));
            //context.DAYYS.AddOrUpdate(
            //    p => p.ten,
            //    new Dayy { subId = "DAYA", ten = "Dãy A", coso=coso_, date_create = now, date_modified = now },
            //    new Dayy { subId = "DAYB", ten = "Dãy B", coso=coso_, date_create = now, date_modified = now },
            //    new Dayy { subId = "DAYC", ten = "Dãy C", coso=coso_, date_create = now, date_modified = now },
            //    new Dayy { subId = "DAYD", ten = "Dãy D", coso=coso_, date_create = now, date_modified = now }
            //    );
            //context.SaveChanges();
            ////Tầng
            //Dayy day_ = context.DAYYS.FirstOrDefault(c => c.subId.ToUpper().Equals("DAYA") && c.coso.id == coso_.id);
            //context.TANGS.AddOrUpdate(
            //    p => p.ten,
            //    new Tang { subId = "TANG1", ten = "Tầng 1", day=day_, date_create = now, date_modified = now },
            //    new Tang { subId = "TANG2", ten = "Tầng 2", day=day_, date_create = now, date_modified = now },
            //    new Tang { subId = "TANG3", ten = "Tầng 3", day=day_, date_create = now, date_modified = now },
            //    new Tang { subId = "TANG4", ten = "Tầng 4", day=day_, date_create = now, date_modified = now }
            //    );
            //context.SaveChanges();
            ////Phong
            //Tang tang_ = context.TANGS.FirstOrDefault(c=>c.subId.ToUpper().Equals("TANG1") && c.day.id == day_.id);
            //ViTri vitri_ = new ViTri { coso=coso_, day = day_, tang=tang_ };
            //CoSo cs = context.COSOS.Where(p => p.subId.Equals("CSC")).FirstOrDefault();
            //context.PHONGS.AddOrUpdate(
            //    p => p.subId,
            //    new Phong { subId = "C.A101", ten = "Phòng A101", vitri=vitri_, date_create = now, date_modified = now },
            //    new Phong { subId = "C.A102", ten = "Phòng A102", vitri=vitri_, date_create = now, date_modified = now },
            //    new Phong { subId = "C.A103", ten = "Phòng A103", vitri=vitri_, date_create = now, date_modified = now }
            //    );
            //context.SaveChanges();
            ////Group
            //List<Group> gp = new List<Group>();
            //gp.Add(new Group { key="ADMIN",  ten = "Quản trị cap cấp" });

            //foreach (Group item in gp)
            //{
            //    context.GROUPS.AddOrUpdate(
            //        p => p.ten,
            //        item
            //        );
            //}
            //context.SaveChanges();
            ////Permission
            //List<Permission> pe = new List<Permission>();
            //String[] class_names = {

            //                        typeof(QuanTriVien).Name.ToUpper(),
            //                        typeof(CoSo).Name.ToUpper(),
            //                        typeof(Dayy).Name.ToUpper(),
            //                        typeof(Tang).Name.ToUpper(),
            //                        typeof(ViTri).Name.ToUpper(),
            //                        typeof(Setting).Name.ToUpper(),
            //                        typeof(ThietBi).Name.ToUpper(),
            //                        typeof(Group).Name.ToUpper(),
            //                        typeof(LoaiThietBi).Name.ToUpper(),
            //                        typeof(NhanVienPT).Name.ToUpper(),
            //                        typeof(CTThietBi).Name.ToUpper(),
            //                        typeof(Phong).Name.ToUpper(),
            //                        typeof(HinhAnh).Name.ToUpper(),
            //                       };
            //foreach (String class_name in class_names)
            //{
            //    pe.Add(new Permission { key = "DELETE_" + class_name, mota = "Xóa " + class_name });
            //    pe.Add(new Permission { key = "ADD_" + class_name, mota = "Thêm " + class_name });
            //    pe.Add(new Permission { key = "EDIT_" + class_name, mota = "Sửa " + class_name });
            //    pe.Add(new Permission { key = "VIEW_" + class_name, mota = "Xem " + class_name });
            //}

            //foreach (Permission item in pe)
            //{
            //    context.PERMISSIONS.AddOrUpdate(
            //        p => p.key,
            //        item
            //        );
            //}
            //context.SaveChanges();

            ////add QunTriVien
            //Group gpp = context.GROUPS.Where(p => p.key.Equals("ADMIN")).FirstOrDefault();
            //List<QuanTriVien> nvs = new List<QuanTriVien>();
            //QuanTriVien qtr = new QuanTriVien
            //{
            //    username = "admin",
            //    hoten = "Quản Trị Viên 1",
            //    date_create = now,
            //    date_modified = now,
            //    group = gpp
            //};
            //qtr.hashPassword("admin");
            //nvs.Add(qtr);

            //foreach (QuanTriVien item in nvs)
            //{
            //    context.QUANTRIVIENS.AddOrUpdate(
            //        p=>p.username,
            //        item
            //        );
            //}
            //context.SaveChanges();
            ////Loại TB
            //context.LOAITHIETBIS.AddOrUpdate(
            //    c => c.ten,
            //    new LoaiThietBi
            //    {
            //        date_create = now,
            //        date_modified = now,
            //        loaichung = false,
            //        ten = "Máy chiếu",
            //        parent = null,

            //    },
            //    new LoaiThietBi
            //    {
            //        date_create = now,
            //        date_modified = now,
            //        loaichung = true,
            //        ten = "Đèn",
            //        parent = null,

            //    }
            //);
            //context.SaveChanges();
            ////Thiết bị mẫu
            //Phong phong_ = context.PHONGS.Where(p => p.subId.ToUpper().Equals("C.A101") && p.vitri.id==vitri_.id).FirstOrDefault();
            //context.THIETBIS.AddOrUpdate(
            //    p => p.subId,
            //    new ThietBi
            //    {
            //        subId = "CAM102346TY",
            //        date_create = now,
            //        date_modified = now,
            //        mota = "Chưa có mô tả",
            //        ngaylap = now,
            //        ngaymua = now,
            //        ten = "Máy chiếu Camnong"
            //    }
            //);
            //context.SaveChanges();

            ////Chi tiết thiết bị
            //ThietBi tb_ = context.THIETBIS.FirstOrDefault(c => c.subId.ToUpper().Equals("CAM102346TY"));
            //TinhTrang tinhtrang_ = context.TINHTRANGS.FirstOrDefault(c=>c.key.ToUpper().Equals("DANGSUDUNG"));
            //CTThietBi cttb = new CTThietBi
            //{
            //    phong = phong_,
            //    soluong = 1,
            //    thietbi = tb_,
            //    tinhtrang = tinhtrang_
            //};
            //context.CTTHIETBIS.AddOrUpdate(
            //    cttb
            //);
            //context.SaveChanges();
            ////Log Thiet bi
            //LogThietBi logtb = new LogThietBi
            //{
            //    mota = "Chưa có mô tả",
            //    ngay = now,
            //    phong = phong_,
            //    soluong = 1,
            //    thietbi = tb_,
            //    tinhtrang = tinhtrang_
            //};
            //context.LOGTHIETBIS.AddOrUpdate(
            //    logtb
            //);
            //context.SaveChanges();
            ///*
            // * Khu vuc co the phat sinh loi, dat cuoi cung 
            // */
            ////Them permission mac dinh cho group
            //foreach (Permission item in pe)
            //{
            //    //if(!item.isInGroup(gpp))
            //    {
            //        gpp.permissions.Add(item);//nếu CSDL đã có rồi sẽ bị lỗi, nhưng không sao, không vẫn đề
            //        //An error occurred while updating the entries. See the inner exception for details.
            //    }
            //}
            //context.SaveChanges();
        }
    }
}
