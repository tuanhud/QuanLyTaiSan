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
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OurDBContext context)
        {
            //DATETIME
            DateTime now = DateTime.Now;
            String mota = "Hệ thống tự động tạo";

            //PERMISSION
            List<Permission> pers = new List<Permission>();
            Permission per = null;
            foreach (String item in Permission.STAND_ALONE_LIST)
            {
                per = new Permission();
                per.stand_alone = true;
                per.allow_or_deny = true;
                per.key = item;

                if (
                    context.PERMISSIONS.Where(
                    c =>
                        c.key.ToUpper().Equals(item.ToUpper())
                    ).FirstOrDefault() == null
                )
                {
                    pers.Add(per);
                    context.PERMISSIONS.Add(per);
                }
            }

            //GROUP
            Group gp = new Group();
            gp.mota = mota;
            gp.key = "admin";
            gp.subId = gp.key;
            gp.ten = gp.key;
            gp.date_create = gp.date_modified = now;
            gp.permissions.Add(pers.Where(c => c.key.ToUpper().Equals(Permission._ROOT)).FirstOrDefault());
            //ADD
            if (
                context.GROUPS.Where(c => c.ten.ToUpper().Equals(gp.ten)).FirstOrDefault() == null
                )
            {
                context.GROUPS.Add(gp);
            }

            //QUANTRIVIEN
            QuanTriVien qtv = new QuanTriVien();
            qtv.username = "admin";
            qtv.hashPassword(qtv.username);
            qtv.hoten = "Quản trị viên cấp cao";
            qtv.mota = mota;
            qtv.subId = qtv.username;
            qtv.date_create = qtv.date_modified = now;
            qtv.group = gp;
            //ADD
            if (
                context.QUANTRIVIENS.Where(c => c.username.ToUpper().Equals(qtv.username)).FirstOrDefault() == null
                )
            {
                context.QUANTRIVIENS.Add(qtv);
            }

            //TINHTRANG
            List<TinhTrang> tinhtrangs = new List<TinhTrang>();

            TinhTrang tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "dangsudung";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Đang sử dụng";
            //ADD
            tinhtrangs.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "khongsudung";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Không sử dụng";
            //ADD
            tinhtrangs.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "bihu";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Bị hư";
            //ADD
            tinhtrangs.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "khac";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Khác";
            //ADD
            tinhtrangs.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "dangsua";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Đang sửa";
            //ADD
            tinhtrangs.Add(tinhtrang);
            //LIST ADD
            foreach (TinhTrang item in tinhtrangs)
            {
                if (context.TINHTRANGS.Where(c => c.value.ToUpper().Equals(item.value.ToUpper())).FirstOrDefault() == null)
                {
                    context.TINHTRANGS.Add(item);
                }
            }

            //call parent
            base.Seed(context);
        }
    }
}
