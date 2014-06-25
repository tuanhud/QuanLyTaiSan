using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    /// <summary>
    /// Có thêm những thuộc tính nâng cao
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class _EntityAbstract2<T> : _EntityAbstract1<T>, _CRUDInterface<T> where T : _EntityAbstract1<T>
    {
        public _EntityAbstract2():base()
        {
            
        }
        public _EntityAbstract2(OurDBContext db)
            : base(db)
        {
            
        }

        #region Định nghĩa
        public String subId { get; set; }
        public String ten { get; set; }
        public String mota { get; set; }
        /*
         * Ngay record insert vao he thong 
         */
        public DateTime? date_create { get; set; }
        /*
         * Ngay update gan day nhat
         */
        public DateTime? date_modified { get; set; }
        /*
         * FK
         */
        public virtual ICollection<HinhAnh> hinhanhs { get; set; }
        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            //sql server time
            //this.date_create = this.date_modified = ServerTimeHelper.getNow();//Khong can thiet, giam tai
            this.hinhanhs = new List<HinhAnh>();
        }
        /*
         * override Method of interface
         */
        public override int add()
        {
            //update datetime
            date_create = date_modified = ServerTimeHelper.getNow();
            return base.add();
        }

        public override int update()
        {
            //update datetime
            date_modified = ServerTimeHelper.getNow();
            //trigger FK Object
            /*
            if (hinhanh != null)
            {
                hinhanh.trigger();
            }
             **/
            return base.update();
        }
        #endregion
    }
}
