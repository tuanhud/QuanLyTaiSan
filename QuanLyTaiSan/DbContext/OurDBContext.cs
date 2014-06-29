using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class OurDBContext:DbContext
    {
        public OurDBContext()
            //: base(Global.local_setting.cached_connection_string)
            : base("Default")
            //: base(@"Data Source=C:\Users\quocdunginfo\Documents\GitHub\QuanLyTaiSan\ProvisionClient\local_db.sdf")
        {
            //Use config file OR use Global setting
        }
        public OurDBContext(String connection_string):base(connection_string)
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
        public DbSet<Setting> SETTINGS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //CONFIG
            //AUTO DELETE ON CASCADE
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //this.Configuration.LazyLoadingEnabled = false; 
            /*
             * TPC Mapping, Inheritance
             */
            modelBuilder.Entity<CoSo>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("COSOS");
            });

            modelBuilder.Entity<Phong>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("PHONGS");
            });

            modelBuilder.Entity<ThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("THIETBIS");
            });

            modelBuilder.Entity<HinhAnh>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("HINHANHS");
            });

            modelBuilder.Entity<QuanTriVien>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("QUANTRIVIENS");
            });

            modelBuilder.Entity<Group>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("GROUPS");
            });

            modelBuilder.Entity<Permission>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("PERMISSIONS");
            });
            modelBuilder.Entity<LogHeThong>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("LOGHETHONGS");
            });

            modelBuilder.Entity<LogThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("LOGTHIETBIS");
            });

            modelBuilder.Entity<CTThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("CTTHIETBIS");
            });

            modelBuilder.Entity<TinhTrang>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("TINHTRANGS");
            });

            modelBuilder.Entity<NhanVienPT>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("NHANVIENPTS");
            });
            modelBuilder.Entity<Tang>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("TANGS");
            });

            modelBuilder.Entity<Dayy>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("DAYS");
            });

            modelBuilder.Entity<ViTri>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("VITRIS");
            });

            modelBuilder.Entity<LoaiThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("LOAITHIETBIS");
            });

            modelBuilder.Entity<Setting>().Map(x =>
            {
                x.MapInheritedProperties();
                //x.ToTable("SETTINGS");
            });
            /*
             * n-n relationship GROUP~PERMISSION
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
        }
        public int SaveChanges()
        {
            IEnumerable<DbEntityEntry> changedEntities = ChangeTracker.Entries().Where(c=>c.State==EntityState.Added || c.State==EntityState.Modified);
            int r = 0;
            foreach (DbEntityEntry changedEntity in changedEntities)
            {
                Console.WriteLine(r++);
                if (changedEntity.Entity is _EFEventRegisterInterface)
                {
                    _EFEventRegisterInterface entity = (_EFEventRegisterInterface)changedEntity.Entity;

                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.onBeforeAdded();
                            break;

                        case EntityState.Modified:
                            entity.onBeforeUpdated();
                            break;

                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
