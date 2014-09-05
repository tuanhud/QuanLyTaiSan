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
        /*
         * Manual method
         */
        public Boolean isInGroup(Group obj)
        {
            if(obj==null || obj.permissions==null)
            {
                return false;
            }
            return obj.permissions.Where(c => c.key.ToUpper().Equals(this.key.ToUpper())).FirstOrDefault() != null;
        }

        public List<T> getObjList<T>()
        {
            return null;
        }
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

                //Đơn vị
                if (key.ToUpper().Equals("DONVI"))
                {
                    if (donvis.Count == 0)
                    {
                        tmp += "tất cả Đơn vị ";
                    }
                    else
                    {
                        tmp += "Đơn vị {";
                        tmp += String.Join(", ", donvis.Select(c => c.ten + " [ID=" + c.id + "]"));
                        tmp += "} ";
                    }
                    goto done;
                }
                
                //
                if (key.ToUpper().Equals("QUANTRIVIEN"))
                {
                    tmp += "tất cả Quản trị viên ";
                }
                
                //
                if (key.ToUpper().Equals("GROUP"))
                {
                    tmp += "tất cả Group ";
                }
                //finish
                done:
                    tmp += recursive_to_child && !stand_alone ? "(và tất cả các đối tượng con cháu)" : "";
                    return tmp;
            }
        }

        #endregion
        
    }
}
