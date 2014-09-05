using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    /// <summary>
    /// Cá nhân, đơn vị, tổ chức có vai trò quản lý, sử dụng tài sản cố định
    /// </summary>
    [Table("DONVIS")]
    public class DonVi : _EntityAbstract1<DonVi>
    {
        public DonVi()
            : base()
        {

        }
        #region Định nghĩa
        /// <summary>
        /// Tên gọi của đơn vị
        /// </summary>
        [Required]
        public String ten { get; set; }

        /*
         * FK
         */
        public Guid? parent_id { get; set; }
        /// <summary>
        /// đơn vị cha
        /// </summary>
        [ForeignKey("parent_id")]
        public virtual DonVi parent { get; set; }

        public Guid loaidonvi_id { get; set; }
        /// <summary>
        /// Loại đơn vị: Cá nhấn, tổ chức, phòng ban, ...
        /// </summary>
        [Required]
        [ForeignKey("loaidonvi_id")]
        public virtual LoaiDonVi loaidonvi { get; set; }

        /// <summary>
        /// DS đơn vị con
        /// </summary>
        public virtual ICollection<DonVi> childs { get; set; }

        public virtual ICollection<Permission> permissions { get; set; }
        /// <summary>
        /// DS CT tài sản mà đơn vị này đống vai trò là đơn vị quản lý
        /// </summary>
        public virtual ICollection<CTTaiSan> cttaisan_dangquanlys { get; set; }

        /// <summary>
        /// DS CT tài sản mà đơn vị này đống vai trò là đơn vị trực tiếp sử dụng
        /// </summary>
        public virtual ICollection<CTTaiSan> cttaisan_dangsudungs { get; set; }

        
        public virtual ICollection<LogTaiSan> logtaisan_dangquanlys { get; set; }
        public virtual ICollection<LogTaiSan> logtaisan_dangsudungs { get; set; }
        #endregion

        #region Nghiệp vụ
        /// <summary>
        /// Lấy tất cả đám con cháu dưới root
        /// </summary>
        /// <param name="root"></param>
        /// <param name="included_root_in_result"></param>
        /// <returns></returns>
        public List<DonVi> getAllRecursive(DonVi root, Boolean included_root_in_result=true)
        {
            List<DonVi> tmp = new List<DonVi>();
            if (root != null)
            {
                if (included_root_in_result)
                {
                    tmp.Add(root);
                }
                if (childs != null)
                {
                    foreach (DonVi item in childs)
                    {
                        tmp.AddRange(getAllRecursive(item));
                    }
                }
            }
            else
            {
                foreach (DonVi item in DonVi.getAll())
                {
                    tmp.AddRange(getAllRecursive(item));
                }
            }
            return tmp;
        }
        #endregion

        #region Override
        public override string niceName()
        {
            return loaidonvi.ten + ": " + ten;
        }
        protected override void init()
        {
            base.init();
        }
        #endregion
    }
}
