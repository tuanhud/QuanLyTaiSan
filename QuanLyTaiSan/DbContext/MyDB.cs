using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class MyDB:DbContext
    {
        public MyDB()
            : base("Default")
        {
            
        }
        public DbSet<CoSo> COSOS { get; set; }
        public DbSet<Phong> PHONGS { get; set; }
        public DbSet<ThietBi> THIETBIS { get; set; }
        public DbSet<CTThietBi> CTTHIETBIS { get; set; }
        public DbSet<DonViTinh> DONVITINHS { get; set; }
        public DbSet<GiaTri> GIATRIS { get; set; }
        public DbSet<HinhAnh> HINHANHS { get; set; }
        public DbSet<Group> GROUPS { get; set; }
        public DbSet<NhanVien> NHANVIENS { get; set; }
        public DbSet<Permission> PERMISSIONS { get; set; }
        public DbSet<LogHeThong> LOGHETHONGS { get; set; }
        public DbSet<LogTinhTrang> LOGTINHTRANGS { get; set; }
        public DbSet<TinhTrang> TINHTRANGS { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoSo>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("COSOS");
            });

            modelBuilder.Entity<Phong>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("PHONGS");
            });

            modelBuilder.Entity<ThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("THIETBIS");
            });

            
            modelBuilder.Entity<DonViTinh>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("DONVITINHS");
            });

            modelBuilder.Entity<GiaTri>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("GIATRIS");
            });

            modelBuilder.Entity<HinhAnh>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("HINHANHS");
            });

            modelBuilder.Entity<NhanVien>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("NHANVIENS");
            });

            modelBuilder.Entity<Group>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("GROUPS");
            });

            modelBuilder.Entity<Permission>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("PERMISSIONS");
            });
            modelBuilder.Entity<LogHeThong>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("LOGHETHONGS");
            });

            modelBuilder.Entity<LogTinhTrang>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("LOGTINHTRANGS");
            });

            modelBuilder.Entity<CTThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("CTTHIETBIS");
            });

            modelBuilder.Entity<TinhTrang>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("TINHTRANGS");
            });

            modelBuilder.Entity<Group>().
            HasMany(c => c.permissions).
            WithMany(p => p.groups).
            Map(
                m =>
                {
                    m.MapLeftKey("group_id");
                    m.MapRightKey("permission_id");
                    m.ToTable("GROUP_PERMISSION");
                });
            
        }
    }
}
