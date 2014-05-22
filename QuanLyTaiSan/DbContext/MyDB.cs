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
        public DbSet<DonViTinh> DONVITINHS { get; set; }
        public DbSet<GiaTri> GIATRIS { get; set; }
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
