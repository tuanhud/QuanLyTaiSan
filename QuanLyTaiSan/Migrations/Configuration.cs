namespace QuanLyTaiSan.Migrations
{
    using QuanLyTaiSan.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyTaiSan.Entities.MyDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDB context)
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

            //Tình trạng
            context.TINHTRANGS.AddOrUpdate(
                p=>p.key,
                new TinhTrang { key="MOI", value="Mới" },
                new TinhTrang { key = "DANGSUDUNG", value = "Đang sử dụng" },
                new TinhTrang { key = "DANGSUACHUA", value = "Đang sửa chữa" },
                new TinhTrang { key = "HONG", value = "Hỏng" }
                );
            context.SaveChanges();
            //Đơn vị tính
            context.DONVITINHS.AddOrUpdate(
                p => p.key,
                new DonViTinh { key="VND", ten="VNĐ" },
                new DonViTinh { key="USD", ten="USD" },
                new DonViTinh { key = "M", ten = "mét" },
                new DonViTinh { key = "M2", ten = "mét vuông" }
                );
            context.SaveChanges();
            //Cơ sở
            context.COSOS.AddOrUpdate(
                p => p.ten,
                new CoSo { subId = "CSC", ten="Cơ sở chính", diachi="273 An Dương Vương", date_create=DateTime.Now, date_modified=DateTime.Now},
                new CoSo { subId = "CS1", ten = "Cơ sở 1", diachi = "105 Bà Huyện Thanh Quan", date_create = DateTime.Now, date_modified = DateTime.Now },
                new CoSo { subId = "CS2", ten = "Cơ sở 2", diachi = "Tôn Đức Thắng", date_create = DateTime.Now, date_modified = DateTime.Now },
                new CoSo { subId = "CS3", ten="Cơ sở 3", diachi="20 Ngô Thời Nhiệm", date_create=DateTime.Now, date_modified=DateTime.Now}
                );
            context.SaveChanges();
            //Phong
            CoSo cs = context.COSOS.Where(p => p.subId.Equals("CSC")).FirstOrDefault();
            context.PHONGS.AddOrUpdate(
                p => p.subId,
                new Phong { subId = "C.A101", ten = "Phòng A101", date_create = DateTime.Now, date_modified = DateTime.Now }
                );
            context.SaveChanges();
            //Group
            List<Group> gp = new List<Group>();
            gp.Add(new Group {ten="Quản trị"});
            
            foreach(Group item in gp)
            {
                context.GROUPS.AddOrUpdate(
                    p => p.ten,
                    item
                    );
            }
            context.SaveChanges();
            //Permission
            List<Permission> pe = new List<Permission>();
            String[] class_names = {
                                    typeof(NhanVien).Name.ToUpper(),
                                    typeof(CoSo).Name.ToUpper(),
                                    typeof(ThietBi).Name.ToUpper(),
                                    typeof(Group).Name.ToUpper(),
                                    typeof(DonViTinh).Name.ToUpper(),
                                    typeof(CTThietBi).Name.ToUpper(),
                                    typeof(Phong).Name.ToUpper(),
                                   };
            foreach (String class_name in class_names)
            {
                pe.Add(new Permission { key = "DELETE_" + class_name, mota = "Xóa " + class_name });
                pe.Add(new Permission { key = "ADD_" + class_name, mota = "Thêm " + class_name });
                pe.Add(new Permission { key = "EDIT_" + class_name, mota = "Sửa "+class_name });
                pe.Add(new Permission { key = "VIEW_" + class_name, mota = "Xem " + class_name });
            }
            
            foreach (Permission item in pe)
            {
                context.PERMISSIONS.AddOrUpdate(
                    p => p.key,
                    item
                    );
            }
            context.SaveChanges();
            
            //add NhanVien
            Group gpp = context.GROUPS.Where(p => p.ten.Equals("Quản trị")).FirstOrDefault();
            List<NhanVien> nvs = new List<NhanVien>();
            nvs.Add(new NhanVien { username = "admin", password = "21232f297a57a5a743894a0e4a801fc3",
                hoten="Quản Trị Viên",
                date_create = DateTime.Now,
                date_modified = DateTime.Now,
                group = gpp
            });
            foreach (NhanVien item in nvs)
            {
                context.NHANVIENS.AddOrUpdate(item);
            }
            context.SaveChanges();
            //Thiết bị mẫu
            
            DonViTinh dvt = context.DONVITINHS.Where(p => p.key.Equals("VND")).FirstOrDefault();
            Phong phong = context.PHONGS.Where(p => p.subId.Equals("C.A101")).FirstOrDefault();
            context.THIETBIS.AddOrUpdate(
                p => p.subId,
                new ThietBi
                {
                    subId = "CAM102346TY",
                    date_create = DateTime.Now,
                    date_modified = DateTime.Now,
                    giatri = new GiaTri { donvitinh = dvt, value = 12720000},
                    mota = "Chưa có mô tả",
                    ngaylap = DateTime.Now,
                    ngaymua = DateTime.Now,
                    phong = phong,
                    baohanh = 12,
                    ten = "Máy chiếu Camnong"
                }
                );
            context.SaveChanges();
            /*
             * Khu vuc co the phat sinh loi, dat cuoi cung 
             */
            //Them permission mac dinh cho group
            foreach (Permission item in pe)
            {
                //if(!item.isInGroup(gpp))
                {
                    gpp.permissions.Add(item);//nếu CSDL đã có rồi sẽ bị lỗi, nhưng không sao, không vẫn đề
                    //An error occurred while updating the entries. See the inner exception for details.
                }
            }
            context.SaveChanges();
        }
    }
}
