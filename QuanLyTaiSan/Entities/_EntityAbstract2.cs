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
    public abstract class _EntityAbstract2<T> : _EntityAbstract1<T> /* ,_CRUDInterface<T>*/ where T : _EntityAbstract1<T>
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
        public override int delete()
        {
            //Tự động xóa hình thuộc object này
            if (hinhanhs != null)//1 số trường hợp gán listHinhAnh vào obj là null, nó bắt lỗi null
            {
                db.HINHANHS.RemoveRange(hinhanhs);//Việc xóa sẽ được thực thi thực sự ngay khi gọi save change
            }
            return base.delete();
        }
        public override void onBeforeDeleted()
        {
            base.onBeforeDeleted();
            //Tự động xóa hết hình ảnh
            //db.HINHANHS.RemoveRange(this.hinhanhs);
        }
        #endregion
    }
}
