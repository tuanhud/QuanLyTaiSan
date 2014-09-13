using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("QUANTRIVIENS")]
    public class QuanTriVien : _EntityAbstract3<QuanTriVien>
    {
        
        public QuanTriVien():base()
        {

        }
        
        #region Định nghĩa thuộc tính
        /// <summary>
        /// Dơn vị mà quản trị viên này trực thuộc
        /// ,có thể là: Phòng Ban, Khoa, Đơn vị,... nào đó
        /// </summary>
        public String donvi { get; set; }
        /// <summary>
        /// email dùng để cấp lại mật khẩu hoặc để thông báo thông tin
        /// </summary>
        public String email { get; set; }
        /*
         * FK
         */

        public Guid group_id { get; set; }
        [Required]
        [ForeignKey("group_id")]
        public virtual Group group { get; set; }

        public virtual ICollection<LogSuCoPhong> logsucophongs { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }
        /// <summary>
        /// DS Phòng được phân công là người phụ trách
        /// </summary>
        public virtual ICollection<Phong> phongs { get; set; }

        /// <summary>
        /// Danh sách phiếu mà Quản trị viên này mượn
        /// </summary>
        
        public virtual ICollection<PhieuMuonPhong> phieudamuons { get; set; }
        public virtual ICollection<PhieuMuonPhong> phieudaduyets { get; set; }
        #endregion

        #region Hàm nghiệp vụ
        /// <summary>
        /// Kiểm tra obj hiện tại được phép sử dụng this.username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private Boolean canUseUserName()
        {
            //Kiểm tra trùng này nọ các thứ
            return db.QUANTRIVIENS.Where(c => (c.id != this.id) && (c.username.ToUpper().Equals(this.username.ToUpper()))).Count<QuanTriVien>() == 0;
        }

        public bool canView<T>(T obj) where T : _EntityAbstract1<T>, new()
        {
            return group.canView<T>((T)obj);
        }
        public bool canDelete<T>(T obj) where T : _EntityAbstract1<T>, new()
        {
            return group.canDelete<T>((T)obj);
        }
        public bool canAdd<T>() where T : _EntityAbstract1<T>, new()
        {
            return group.canAdd<T>();
        }
        public Boolean canEdit<T>(T obj) where T:_EntityAbstract1<T>, new()
        {
            return group.canEdit<T>((T)obj);
        }
        /// <summary>
        /// vd: obj.canDo("DB_CONFIG")
        /// </summary>
        /// <param name="fixed_permission"></param>
        /// <returns></returns>

        public Boolean canDo(string fixed_permission="")
        {
            return group.canDo(fixed_permission);
        }
        #endregion

        #region Override method
        public override string niceName()
        {
            return username + " (" + hoten + ")";
        }
        protected override void init()
        {
            base.init();
            logsucophongs = new List<LogSuCoPhong>();
            logthietbis = new List<LogThietBi>();
            phongs = new List<Phong>();
            phieudamuons = new List<PhieuMuonPhong>();
            phieudaduyets = new List<PhieuMuonPhong>();
        }
        public override void onBeforeDeleted()
        {
            if (isRoot())
            {
                throw new Exception("Không thể xóa tài khoản \"root\"");
            }
            base.onBeforeDeleted();
        }

        private bool isRoot()
        {
            return username.ToLower().Equals("root");
        }
        public override int delete()
        {
            if (isRoot())
            {
                return -1;
            }
            return base.delete();
        }
        /// <summary>
        /// -7: trùng username đã có
        /// </summary>
        /// <returns></returns>
        public override int update()
        {
            if (!canUseUserName())
            {
                return -7;
            }

            return base.update();
        }
        /// <summary>
        /// Trước khi add phải gọi hashPassword trước,
        /// </summary>
        /// <returns>-7: trùng username đã có</returns>
        public override int add()
        {
            //Kiểm tra trùng này nọ các thứ
            if (!canUseUserName())
            {
                return -7;
            }
            return base.add();
        }
        public static new IQueryable<QuanTriVien> getQuery()
        {
            try
            {
                db.QUANTRIVIENS.AsQueryable().FirstOrDefault();
                //Ẩn ROOT
                return db.QUANTRIVIENS.Where(c=>!c.username.ToLower().Equals("root")).AsQueryable();
            }
            catch (Exception)
            {
                return new List<QuanTriVien>().AsQueryable();
            }
        }
        public static new List<QuanTriVien> getAll()
        {
            return db.QUANTRIVIENS.Where(c => !c.username.ToLower().Equals("root")).ToList();
        }
        #endregion
    }
}
