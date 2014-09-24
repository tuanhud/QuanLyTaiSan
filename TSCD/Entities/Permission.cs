using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCD.Entities
{
    [Table("PERMISSIONS")]
    public class Permission : _EntityAbstract1<Permission>
    {
        public Permission():base()
        {
            
        }
        #region Dinh nghia
        /// <summary>
        /// COSO, DAY, TANG, PHONG => stand_alone = false
        /// </summary>
        public String key { get; set; }

        /// <summary>
        /// Quyền cố định,
        /// vd: CONFIG, ROOT
        /// </summary>
        public Boolean stand_alone { get; set; }
        /// <summary>
        /// Cấp quyền hay hạn chế quyền,
        /// true: allow,
        /// false: deny
        /// </summary>
        public Boolean allow_or_deny { get; set; }
        
        /// <summary>
        /// Quyền bao hàm cho mọi thứ thuộc obj_id_array
        /// </summary>
        public Boolean recursive_to_child { get; set; }

        /// <summary>
        /// Quyền xem
        /// </summary>
        public Boolean can_view { get; set; }
        /// <summary>
        /// Quyền sửa
        /// </summary>
        public Boolean can_edit { get; set; }
        /// <summary>
        /// Quyền xóa
        /// </summary>
        public Boolean can_delete { get; set; }
        /// <summary>
        /// Quyền thêm
        /// </summary>
        public Boolean can_add { get; set; }

        /*
         * FK
         */
        public virtual ICollection<DonVi> donvis { get; set; }

        /// <summary>
        /// Các group chứa quyền này
        /// </summary>
        public virtual ICollection<Group> groups { get; set; }
        #endregion
        #region Nghiep vu

        #endregion

        #region Override
        protected override void init()
        {
            base.init();
        }
        #endregion

        #region Standalone Permission constant
        /// <summary>
        /// Sử dụng trong ds quyền trên hạng mục
        /// </summary>
        [NotMapped]
        public static String[] ENTITY_LIST
        {
            get
            {
                return OurDBContext.entity_list;
            }
        }
        public static String[] STAND_ALONE_LIST = {
            "CLIENT_CONFIG",
            "SERVER_CONFIG",
            "SUPER_ADMIN"//version 1.1
        };
        /// <summary>
        /// Quyền cấu máy client
        /// </summary>
        [NotMapped]
        public static String _CLIENT_CONFIG
        {
            get
            {
                return STAND_ALONE_LIST[0];
            }
        }
        /// <summary>
        /// Quyền cấu hình máy server
        /// </summary>
        [NotMapped]
        public static String _SERVER_CONFIG
        {
            get
            {
                return STAND_ALONE_LIST[1];
            }
        }
        /// <summary>
        /// Quyền ROOT
        /// </summary>
        [NotMapped]
        public static String _SUPER_ADMIN
        {
            get
            {
                return STAND_ALONE_LIST[2];
            }
        }
        #endregion

        #region NotMapped

        /// <summary>
        /// Hiển thị thông tin chi tiết về quyền này cho người dùng dễ hiểu
        /// </summary>
        [NotMapped]
        public String translated
        {
            get
            {
                return "";
            }
        }

        #endregion




        public static bool canDo(string p)
        {
            return true;
        }

        /// <summary>
        /// Chỉ có stand_alone Permission là mới tái sử dụng được object trong CSDL
        /// </summary>
        /// <param name="fixed_permission"></param>
        /// <returns></returns>
        public static Permission request(String fixed_permission = "")
        {
            try
            {
                if (fixed_permission == null || fixed_permission.Equals(""))
                {
                    return null;
                }
                Permission tmp = db.PERMISSIONS.Where(c =>
                    Permission.STAND_ALONE_LIST.Contains(fixed_permission.ToUpper())
                    &&
                    c.allow_or_deny
                    &&
                    c.stand_alone
                    &&
                    c.key.ToUpper().Equals(fixed_permission.ToUpper())
                ).FirstOrDefault();
                if (tmp == null)
                {
                    tmp = new Permission();
                    tmp.key = fixed_permission.ToUpper();
                    tmp.stand_alone = true;
                    tmp.recursive_to_child = true;
                    tmp.allow_or_deny = true;
                }
                return tmp;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        public static Permission request(Boolean stand_alone = false, String key = "", Boolean allow_or_deny = false, Boolean recursive_to_child = false, Boolean can_view = false, Boolean can_edit = false, Boolean can_delete = false, Boolean can_add = false)
        {
            if (key == null || key.Equals(""))
            {
                return null;
            }
            Permission tmp = new Permission();
            tmp.key = key.ToUpper();
            tmp.stand_alone = stand_alone;
            tmp.recursive_to_child = recursive_to_child;
            tmp.allow_or_deny = allow_or_deny;
            tmp.can_add = can_add;
            tmp.can_delete = can_delete;
            tmp.can_edit = can_edit;
            tmp.can_view = can_view;
            return tmp;
        }
    }
}
