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
    [Table("COSOS")]
    public class CoSo:_EntityAbstract2<CoSo>
    {
        public CoSo():base()
        {
            this.days = new List<Dayy>();
        }
       
        #region Định nghĩa
        /// <summary>
        /// Dùng để sắp xếp CoSo, mặc định khi thêm mới thì sẽ bật trigger để tự lấy id qua
        /// </summary>
        public int? order { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }

        /// <summary>
        /// Địa chỉ phục vụ GOOGLE MAP
        /// </summary>
        public String diachi { get; set; }
        /*
         * FK
         */
        public virtual ICollection<Dayy> days { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
        #endregion

        #region Nghiệp vụ
        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            days = new List<Dayy>();
            vitris = new List<ViTri>();
        }
        public override int add()
        {
            int re = base.add();
            if (re > 0)
            {
                //tự động chỉnh trường order theo id
                order = this.id;
                return update();
            }
            return re;
        }
        /// <summary>
        /// -2: dính phòng, -3: dính dãy
        /// </summary>
        /// <returns></returns>
        public override int delete()
        {
            //Nếu có ít nhất 1 phòng sử dụng vị trí chứa CS này thì KHÔNG cho xóa
            if (vitris.Where(c => c.phongs.Count > 0).FirstOrDefault() != null)
            {
                return -2;
            }
            //Kiểm tra có dãy KHÔNG cho xóa
            if (days.Count > 0)
            {
                return -3;
            }
            //======================================================
            //Xóa tất cả vị trí liên quan
            if (vitris != null)
            {
                while (vitris.Count > 0)
                {
                    vitris.FirstOrDefault().delete();
                }
            }

            return base.delete();
        }
        #endregion

    }
}
