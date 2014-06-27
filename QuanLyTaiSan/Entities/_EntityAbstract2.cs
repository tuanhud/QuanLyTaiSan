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

        #region Định nghĩa

        public String ten { get; set; }
        /*
         * FK
         */
        public virtual ICollection<HinhAnh> hinhanhs { get; set; }
        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            this.hinhanhs = new List<HinhAnh>();
        }

        public override int update()
        {
            //trigger FK Object
            //...
            return base.update();
        }
        #endregion
    }
}
