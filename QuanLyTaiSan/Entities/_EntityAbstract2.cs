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
    /// Có thêm quan hệ 1-n với HinhAnh
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class _EntityAbstract2<T> : _EntityAbstract1<T> /* ,_CRUDInterface<T>*/ where T : _EntityAbstract2<T>
    {
        public _EntityAbstract2():base()
        {
            
        }

        #region Định nghĩa
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
        /// <summary>
        /// Tự động xóa mọi hình ảnh liên quan
        /// </summary>
        /// <returns></returns>
        public override int delete()
        {
            //Tự động xóa hình thuộc object này
            if (hinhanhs != null)//1 số trường hợp gán listHinhAnh vào obj là null, nó bắt lỗi null
            {
                while (hinhanhs.Count > 0)
                {
                    hinhanhs.FirstOrDefault().delete();
                }
            }
            return base.delete();
        }
        #endregion
    }
}
