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
        public override string niceName()
        {
            return username + " (" + hoten + ")";
        }
        protected override void init()
        {
            base.init();
        }
        public override int update()
        {
            //have to load all [Required] FK object first
            if (group != null)
            {
                group.trigger();
            }
            
            //...
            return base.update();
        }
        /// <summary>
        /// Trước khi add phải gọi hashPassword trước
        /// </summary>
        /// <returns></returns>
        public override int add()
        {
            return base.add();
        }
        #endregion
    }
}
