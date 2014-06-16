using QuanLyTaiSan.Libraries;
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
            //: base(Global.local_setting.cached_connection_string)
            : base("Default")
        {
            //Use config file OR use Global setting
        }
        public MyDB(String connection_string):base(connection_string)
        {
            //Dynamic connection String
        }
        public DbSet<CoSo> COSOS { get; set; }
        public DbSet<Phong> PHONGS { get; set; }
        public DbSet<ThietBi> THIETBIS { get; set; }
        public DbSet<CTThietBi> CTTHIETBIS { get; set; }        
        public DbSet<HinhAnh> HINHANHS { get; set; }
        public DbSet<Group> GROUPS { get; set; }
        public DbSet<QuanTriVien> QUANTRIVIENS { get; set; }
        public DbSet<Permission> PERMISSIONS { get; set; }
        public DbSet<LogHeThong> LOGHETHONGS { get; set; }
        public DbSet<LogThietBi> LOGTHIETBIS { get; set; }
        public DbSet<TinhTrang> TINHTRANGS { get; set; }
        public DbSet<NhanVienPT> NHANVIENPTS { get; set; }
        public DbSet<Tang> TANGS { get; set; }
        public DbSet<Dayy> DAYYS { get; set; }
        public DbSet<ViTri> VITRIS { get; set; }
        public DbSet<LoaiThietBi> LOAITHIETBIS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //this.Configuration.LazyLoadingEnabled = false; 
            /*
             * TPC Mapping
             */
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

            modelBuilder.Entity<HinhAnh>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("HINHANHS");
            });

            modelBuilder.Entity<QuanTriVien>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("QUANTRIVIENS");
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

            modelBuilder.Entity<LogThietBi>().Map(x =>
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

            modelBuilder.Entity<NhanVienPT>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("NHANVIENPTS");
            });
            modelBuilder.Entity<Tang>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("TANGS");
            });

            modelBuilder.Entity<Dayy>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("DAYS");
            });

            modelBuilder.Entity<ViTri>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("VITRIS");
            });

            modelBuilder.Entity<LoaiThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("LOAITHIETBIS");
            });

            /*
             * n-n relationship
             */
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
            /*
             * Self-reference relationship
             */
            modelBuilder.Entity<LoaiThietBi>().
            HasOptional(c => c.parent).
            WithMany(c => c.childs).
            HasForeignKey(c => c.parent_id);
        }
    }
}
