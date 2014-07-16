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
        #endregion

    }
}
