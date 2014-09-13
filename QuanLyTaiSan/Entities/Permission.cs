using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
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
        /// true: fixed || cat_wide, false: object_combined
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
        public virtual ICollection<CoSo> cosos { get; set; }
        public virtual ICollection<Dayy> days { get; set; }
        public virtual ICollection<Tang> tangs { get; set; }
        public virtual ICollection<Phong> phongs { get; set; }

        /// <summary>
        /// Các group chứa quyền này
        /// </summary>
        public virtual ICollection<Group> groups { get; set; }
        #endregion
        #region Nghiep vu
        /// <summary>
        /// Chỉ có stand_alone Permission là mới tái sử dụng được object trong CSDL
        /// </summary>
        /// <param name="fixed_permission"></param>
        /// <returns></returns>
        public static Permission request(String fixed_permission = "")
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
        public static Permission request(Boolean stand_alone=false, String key="",  Boolean allow_or_deny=false, Boolean recursive_to_child=false, Boolean can_view=false, Boolean can_edit=false, Boolean can_delete=false, Boolean can_add=false)
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

        public static bool canEdit<T>(T obj) where T: _EntityAbstract1<T>, new()
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canEdit<T>(obj);
        }
        public static bool canView<T>(T obj) where T : _EntityAbstract1<T>, new()
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canView<T>(obj);
        }
        public static bool canDelete<T>(T obj) where T : _EntityAbstract1<T>, new()
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canDelete<T>(obj);
        }
        public static bool canAdd<T>() where T : _EntityAbstract1<T>, new()
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canAdd<T>();
        }
        public static bool canDo(String fixed_permission = "")
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canDo(fixed_permission);
        }
        #endregion

        #region Override
        protected override void init()
        {
            base.init();
            //

            //
            this.cosos = new List<CoSo>();
            this.days = new List<Dayy>();
            this.tangs = new List<Tang>();
            this.phongs = new List<Phong>();

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
                return OurDBContext.permission_entity_list;
            }
        }
        public static String[] STAND_ALONE_LIST = {
            "WEB_MUONPHONG",
            "WEB_QLMUONPHONG",
            "CLIENT_CONFIG",
            "SERVER_CONFIG",
            "ROOT"
            //additional follow here
        };
        /// <summary>
        /// Sử dụng tính năng mượn phòng (tạo yêu cầu) trên WEB
        /// </summary>
        [NotMapped]
        public static String _WEB_MUONPHUONG
        {
            get
            {
                return STAND_ALONE_LIST[0];
            }
        }
        /// <summary>
        /// Sử dụng tính năng quản lý phiếu mượn phòng trên WEB
        /// </summary>
        [NotMapped]
        public static String _WEB_QLMUONPHUONG
        {
            get
            {
                return STAND_ALONE_LIST[1];
            }
        }
        /// <summary>
        /// Quyền cấu máy client
        /// </summary>
        [NotMapped]
        public static String _CLIENT_CONFIG
        {
            get
            {
                return STAND_ALONE_LIST[2];
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
                return STAND_ALONE_LIST[3];
            }
        }
        /// <summary>
        /// Quyền ROOT
        /// </summary>
        [NotMapped]
        public static String _ROOT
        {
            get
            {
                return STAND_ALONE_LIST[4];
            }
        }

        [NotMapped]
        public static int __TYPE_FIXED
        {
            get
            {
                return 0;
            }
        }
        [NotMapped]
        public static int __TYPE_OBJ_COMBINED
        {
            get
            {
                return 1;
            }
        }
        [NotMapped]
        public static int __TYPE_CAT_WIDE
        {
            get
            {
                return 2;
            }
        }
        #endregion

        #region Extended member

        /// <summary>
        /// Hiển thị thông tin chi tiết về quyền này cho người dùng dễ hiểu
        /// </summary>
        [NotMapped]
        public String translated
        {
            get
            {
                String tmp = "";
                tmp += allow_or_deny ? "Cho phép: " : "Cấm: ";
                //Quyền cố định
                //if (stand_alone)
                //{
                //    tmp += mota;
                //    goto done;
                //}
                tmp += can_view ? "Xem, " : "";
                tmp += can_add ? "Thêm, " : "";
                tmp += can_edit ? "Sửa, " : "";
                tmp += can_delete ? "Xóa, " : "";

                tmp += "trên ";
                
                //Cơ sở
                if (key.ToUpper().Equals(CoSo.USNAME))
                {
                    if (cosos.Count == 0)
                    {
                        tmp += "tất cả " + CoSo.VNNAME + " ";
                    }
                    else
                    {
                        tmp += CoSo.VNNAME+ " {";
                        tmp +=String.Join(", ", cosos.Select(c => c.niceName()));//c.ten+" [ID="+c.id+"]"));
                        tmp += "} ";
                    }
                    goto done;
                }
                //Dãy
                if (key.ToUpper().Equals(Dayy.USNAME))
                {
                    if (days.Count == 0)
                    {
                        tmp += "tất cả " + Dayy.VNNAME +" ";
                    }
                    else
                    {
                        tmp += Dayy.VNNAME + " {";
                        tmp += String.Join(", ", days.Select(c => c.niceName()));
                        tmp += "} ";
                    }
                    goto done;
                }
                //Tầng
                if (key.ToUpper().Equals(Tang.USNAME))
                {
                    if (tangs.Count == 0)
                    {
                        tmp += "tất cả "+Tang.VNNAME+" ";
                    }
                    else
                    {
                        tmp += Tang.VNNAME+" {";
                        tmp += String.Join(", ", tangs.Select(c => c.niceName()));
                        tmp += "} ";
                    }
                    goto done;
                }
                //Phòng
                if (key.ToUpper().Equals(Phong.USNAME))
                {
                    if (phongs.Count == 0)
                    {
                        tmp += "tất cả "+Phong.VNNAME+" ";
                    }
                    else
                    {
                        tmp += Phong.VNNAME+" {";
                        tmp += String.Join(", ", phongs.Select(c => c.niceName()));
                        tmp += "} ";
                    }
                    goto done;
                }
                tmp += " "+key+" ";
                return tmp;
                //finish for CoSo, Dayy, Tang, Phong
                done:
                    tmp += recursive_to_child && !stand_alone ? " (và tất cả các đối tượng con cháu)" : "";
                    return tmp;
            }
        }

        #endregion
        
    }
}
