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
        public static bool canEdit<T>(T obj) where T: _EntityAbstract1<T>
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canEdit<T>(obj);
        }
        public static bool canView<T>(T obj) where T : _EntityAbstract1<T>
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canView<T>(obj);
        }
        public static bool canDelete<T>(T obj) where T : _EntityAbstract1<T>
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canDelete<T>(obj);
        }
        public static bool canAdd<T>() where T : _EntityAbstract1<T>
        {
            return Global.current_quantrivien_login != null && Global.current_quantrivien_login.canAdd<T>();
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
            "WEB_MUONPHONG",//
            "WEB_QLMUONPHONG",
            "CLIENT_CONFIG",
            "SERVER_CONFIG",
            "ROOT"//version 1.1
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
                String tmp = "";
                tmp += allow_or_deny ? "Cho phép: " : "Cấm: ";
                //Quyền cố định
                if (stand_alone)
                {
                    tmp += mota;
                    goto done;
                }
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
