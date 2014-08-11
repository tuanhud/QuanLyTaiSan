using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using QuanLyTaiSan.Entities;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace QuanLyTaiSan.Entities
{
    internal class _OurDBInit : CreateDatabaseIfNotExists<OurDBContext>
    {
        private Boolean create_sample_data = false;
        public _OurDBInit(Boolean create_sample_data=false)
        {
            this.create_sample_data = create_sample_data;
        }
        protected override void Seed(OurDBContext context) 
        {
            /*
             * Create Sample Data here
             */
            if (!create_sample_data)
            {
                base.Seed(context);
                return;
            }
            //DATETIME
            DateTime now = DateTime.Now;
            String mota = "Hệ thống tự động tạo";
            //GROUP
            Group gp = new Group();
            gp.mota = mota;
            gp.key = "admin";
            gp.subId = gp.key;
            gp.ten = gp.key;
            gp.date_create = gp.date_modified = now;
            //ADD
            context.GROUPS.Add(gp);

            //QUANTRIVIEN
            QuanTriVien qtv = new QuanTriVien();
            qtv.username = "admin";
            qtv.password = StringHelper.SHA1_Salt("admin");
            qtv.hoten = "Quản trị viên cấp cao";
            qtv.mota = mota;
            qtv.subId = qtv.username;
            qtv.date_create = qtv.date_modified = now;
            qtv.group = gp;
            //ADD
            context.QUANTRIVIENS.Add(qtv);

            //TINHTRANG
            TinhTrang tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "dangsudung";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Đang sử dụng";
            //ADD
            context.TINHTRANGS.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "khongsudung";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Không sử dụng";
            //ADD
            context.TINHTRANGS.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "bihu";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Bị hư";
            //ADD
            context.TINHTRANGS.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "khac";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Khác";
            //ADD
            context.TINHTRANGS.Add(tinhtrang);

            tinhtrang = new TinhTrang();
            tinhtrang.date_create = tinhtrang.date_modified = now;
            tinhtrang.key = "dangsua";
            tinhtrang.mota = mota;
            tinhtrang.subId = tinhtrang.key;
            tinhtrang.value = "Đang sửa";
            //ADD
            context.TINHTRANGS.Add(tinhtrang);
            
            //call parent
            base.Seed(context);
        } 
 
    }
    public class OurDBContext:DbContext
    {
        public OurDBContext()
            : base("Default")
        {
            //Create sample data if indicated
            IDatabaseInitializer<OurDBContext> initializer = new _OurDBInit(false);

            //Auto create DB if not exist
            Database.SetInitializer<OurDBContext>(initializer);
        }
        public OurDBContext(String connection_string="Default", Boolean create_sample_data = true)
            : base(connection_string)
        {
            //Create sample data if indicated
            IDatabaseInitializer<OurDBContext> initializer = new _OurDBInit(create_sample_data);

            //Auto create DB if not exist
            Database.SetInitializer<OurDBContext>(initializer);

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
        public DbSet<SuCoPhong> SUCOPHONGS { get; set; }
        public DbSet<LogSuCoPhong> LOGSUCOPHONGS { get; set; }
        public DbSet<TinhTrang> TINHTRANGS { get; set; }
        public DbSet<NhanVienPT> NHANVIENPTS { get; set; }
        public DbSet<Tang> TANGS { get; set; }
        public DbSet<Dayy> DAYYS { get; set; }
        public DbSet<ViTri> VITRIS { get; set; }
        public DbSet<LoaiThietBi> LOAITHIETBIS { get; set; }
        public DbSet<Setting> SETTINGS { get; set; }
        public DbSet<GiangVien> GIANGVIENS { get; set; }
        public DbSet<PhieuMuonPhong> PHIEUMUONPHONGS { get; set; }
        #region STATIC
        /// <summary>
        /// for SYNC
        /// </summary>
        public static String[] tracking_tables
        {
            //UNDEPENDENT (bản thân không có bất kỳ FK nào)
            //TABLES HAVE TO BE IN RIGHT ORDER FOR FK CONSTRAIN
            get
            {
                return new String[] {
                    "__MigrationHistory",//UNDEPENDENT

                    "COSOS",//UNDEPENDENT
                    "DAYS",
                    "TANGS",
                    "VITRIS",
                    "NHANVIENPTS",//UNDEPENDENT
                    "PHONGS",
                    
                    "LOAITHIETBIS",
                    "TINHTRANGS",//UNDEPENDENT
                    "THIETBIS",
                    "CTTHIETBIS",
                    
                    "GROUPS",//UNDEPENDENT
                    "PERMISSIONS",//UNDEPENDENT
                    "GROUP_PERMISSION",
                    "QUANTRIVIENS",

                    "LOGTHIETBIS",

                    "SUCOPHONGS",//UNDEPENDENT
                    "LOGSUCOPHONGS",
                    "HINHANHS",
                    "SETTINGS",//UNDEPENDENT
                    "LOGHETHONGS",//UNDEPENDENT
                    "GIANGVIENS",//UNDEPENDENT
                    "PHIEUMUONPHONGS"
                };
            }
        }
        #endregion
        #region Manual
        /// <summary>
        /// Lấy danh sách lỗi sau khi add/update được gọi,
        /// dùng để phục vụ mục đích hiển thị lỗi
        /// </summary>
        public ICollection<DbValidationError> ERRORs
        {
            get
            {
                List<DbValidationError> re = new List<DbValidationError>();
                foreach (DbEntityValidationResult tmp in DBInstance.DB.GetValidationErrors())
                {
                    re.AddRange(tmp.ValidationErrors);
                }
                return re;
            }
        }
        /// <summary>
        /// Kiem tra model backing changed
        /// </summary>
        /// <returns></returns>
        public bool isValidModel()
        {
            try
            {
                COSOS.Find(1);
                DAYYS.Find(1);
                TANGS.Find(1);
                VITRIS.Find(1);
                PHONGS.Find(1);
                THIETBIS.Find(1);
                CTTHIETBIS.Find(1);
                HINHANHS.Find(1);
                QUANTRIVIENS.Find(1);
                NHANVIENPTS.Find(1);
                LOGHETHONGS.Find(1);
                LOGSUCOPHONGS.Find(1);
                LOGTHIETBIS.Find(1);
                LOAITHIETBIS.Find(1);
                SETTINGS.Find(1);
                TINHTRANGS.Find(1);
                PERMISSIONS.Find(1);
                SUCOPHONGS.Find(1);
                GROUPS.Find(1);
                GIANGVIENS.Find(1);
                PHIEUMUONPHONGS.Find(1);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        private void sync()
        {
            Debug.WriteLine("======Location: OurDBConText======");
            Debug.WriteLine("======Start sync when insert in new Thread======");
            Global.client_database.start_sync();
            Debug.WriteLine("======End sync when insert in new Thread======");
        }
        #endregion
        #region Override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //CONFIG
            //AUTO DELETE ON CASCADE
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            this.Configuration.LazyLoadingEnabled = true;
            /*
             * TPC Mapping, Inheritance
             */
            modelBuilder.Entity<CoSo>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<Phong>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<ThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<HinhAnh>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<QuanTriVien>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<Group>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<Permission>().Map(x =>
            {
                x.MapInheritedProperties();
            });
            modelBuilder.Entity<LogHeThong>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<LogThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<CTThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<TinhTrang>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<NhanVienPT>().Map(x =>
            {
                x.MapInheritedProperties();
            });
            modelBuilder.Entity<Tang>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<Dayy>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<ViTri>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<LoaiThietBi>().Map(x =>
            {
                x.MapInheritedProperties();
            });
            
            modelBuilder.Entity<SuCoPhong>().Map(x =>
            {
                x.MapInheritedProperties();
            });
            
            modelBuilder.Entity<LogSuCoPhong>().Map(x =>
            {
                x.MapInheritedProperties();
            });


            modelBuilder.Entity<Setting>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<GiangVien>().Map(x =>
            {
                x.MapInheritedProperties();
            });

            modelBuilder.Entity<PhieuMuonPhong>().Map(x =>
            {
                x.MapInheritedProperties();
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
        public override int SaveChanges()
        {
            IEnumerable<DbEntityEntry> changedEntities = ChangeTracker.Entries().Where(c=>c.State==EntityState.Added || c.State==EntityState.Modified || c.State==EntityState.Deleted);
            ICollection<_EFEventRegisterInterface> Added_Callbacks = new List<_EFEventRegisterInterface>();
            ICollection<_EFEventRegisterInterface> Modified_Callbacks = new List<_EFEventRegisterInterface>();
            ICollection<_EFEventRegisterInterface> Deleted_Callbacks = new List<_EFEventRegisterInterface>();
            Boolean need_to_sync = false;
            //Before
                foreach (DbEntityEntry item in changedEntities)
                {
                    need_to_sync = true;
                    if (item.Entity is _EFEventRegisterInterface)
                    {
                        _EFEventRegisterInterface entity = (_EFEventRegisterInterface)item.Entity;
                        switch (item.State)
                        {
                            case EntityState.Added:
                                Added_Callbacks.Add(entity);
                                entity.onBeforeAdded();
                                break;

                            case EntityState.Modified:
                                Modified_Callbacks.Add(entity);
                                entity.onBeforeUpdated();
                                break;

                            case EntityState.Deleted:
                                Deleted_Callbacks.Add(entity);
                                entity.onBeforeDeleted();
                                break;
                        }
                    }
                }
            //SaveChange lần 1
            int result = base.SaveChanges();
            //After
                foreach (_EFEventRegisterInterface item in Added_Callbacks)
                {
                    item.onAfterAdded();
                }
                foreach (_EFEventRegisterInterface item in Modified_Callbacks)
                {
                    item.onAfterUpdated();
                }

            result = base.SaveChanges();

            //clear RAM
                Added_Callbacks = null;
                Modified_Callbacks = null;
                changedEntities = null;

            //Auto Sync
            if (need_to_sync)
            {
                //call sync for insert Confliction in new background thread
                Thread thread = new Thread(new ThreadStart(sync));
                //thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

            return result;
        }
        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            //if (entityEntry.Entity is CoSo && entityEntry.State == EntityState.Deleted)
            //{
                
            //    return true;
            //}
            return base.ShouldValidateEntity(entityEntry);
        }
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            //Khai báo Validation
            List<DbValidationError> list = new List<DbValidationError>();
            ////Kiểm tra CoSo
            //if (entityEntry.Entity is CoSo && entityEntry.State == EntityState.Deleted)
            //{
            //    CoSo tmp = (CoSo)entityEntry.Entity;
            //    CoSo tmp2 = this.COSOS.AsNoTracking().Where(c => c.id == tmp.id).FirstOrDefault();
            //    //check Dãy
            //    if(tmp2.days.Count>0)
            //    {
            //        list.Add(new DbValidationError("error", "Cơ sở có chứa dãy"));
            //        return new DbEntityValidationResult(entityEntry, list);
            //    }
            //    //check Phòng
            //    if (tmp2.vitris.Where(c=>c.phongs.Count>0).FirstOrDefault()!=null)
            //    {
            //        list.Add(new DbValidationError("error", "Cơ sở có chứa phòng"));
            //        return new DbEntityValidationResult(entityEntry, list);
            //    }
            //}
            //Kiểm tra QuanTriVien
            if (entityEntry.Entity is QuanTriVien && entityEntry.State == EntityState.Added)
            {
                QuanTriVien tmp = (QuanTriVien)entityEntry.Entity;
                if (this.QUANTRIVIENS.Where(c => c.username.ToUpper().Equals(tmp.username.ToUpper())).FirstOrDefault() != null)
                {
                    list.Add(new DbValidationError("username", "Tên đăng nhập đã có"));

                    return new DbEntityValidationResult(entityEntry, list);
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }
        #endregion
        
    }
}
