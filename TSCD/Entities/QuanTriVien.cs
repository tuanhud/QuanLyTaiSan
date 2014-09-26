using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCD.Entities
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

        /// <summary>
        /// Danh sách phiếu mà Quản trị viên này mượn
        /// </summary>
        
        #endregion

        #region Hàm nghiệp vụ
        public bool canView<T>(T obj) where T : _EntityAbstract1<T>
        {
            return group.canView<T>((T)obj);
        }
        public bool canDelete<T>(T obj) where T : _EntityAbstract1<T>
        {
            return group.canDelete<T>((T)obj);
        }
        public bool canAdd<T>() where T : _EntityAbstract1<T>
        {
            return group.canAdd<T>();
        }
        public Boolean canEdit<T>(T obj) where T:_EntityAbstract1<T>
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
        public static new String VNNAME
        {
            get
            {
                return "QUẢN TRỊ VIÊN";
            }
        }
        public override string niceName()
        {
            return username + hoten==null? "": " (" + hoten + ")";
        }
        protected override void init()
        {
            base.init();
        }
        /// <summary>
        /// Trước khi add phải gọi hashPassword trước
        /// </summary>
        /// <returns></returns>
        public override int add()
        {
            return base.add();
        }
        public override void doTrigger()
        {
            if (group != null)
            {
                group.trigger();
            }
            base.doTrigger();
        }
        /// <summary>
        /// Ho tro query
        /// </summary>
        /// <returns></returns>
        public static new IQueryable<QuanTriVien> getQuery()
        {
            try
            {
                //validate
                db.QUANTRIVIENS.AsQueryable().FirstOrDefault();
                //Ẩn ROOT
                return db.QUANTRIVIENS.Where(c => !c.username.ToLower().Equals("root")).AsQueryable();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new List<QuanTriVien>().AsQueryable();
            }
        }
        /// <summary>
        /// Ho tro day du lieu len san
        /// </summary>
        /// <returns></returns>
        public static new List<QuanTriVien> getAll()
        {
            try
            {
                return db.QUANTRIVIENS.Where(c => !c.username.ToLower().Equals("root")).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new List<QuanTriVien>();
            }
        }
        #endregion
    }
}
