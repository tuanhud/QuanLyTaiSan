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

        /*
         * FK
         */

        public int group_id { get; set; }
        [Required]
        [ForeignKey("group_id")]
        public virtual Group group { get; set; }

        public virtual ICollection<LogSuCoPhong> logsucophongs { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }
        public virtual ICollection<Phong> phongs { get; set; }
        public virtual ICollection<PhieuMuonPhong> phieumuonphongs { get; set; }
        #endregion

        #region Hàm nghiệp vụ
        public Boolean hasPermission(string permission_name="")
        {
            if (group == null || permission_name==null)
            {
                return false;
            }
            return group.isHasPermission(permission_name);
        }
        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            logsucophongs = new List<LogSuCoPhong>();
            logthietbis = new List<LogThietBi>();
            phongs = new List<Phong>();
            phieumuonphongs = new List<PhieuMuonPhong>();
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
