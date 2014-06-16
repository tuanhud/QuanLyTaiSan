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
    /*
     * Không thể đặt tên là Day vì trùng class Day của Winform
     */
    [Table("DAYYS")]
    public class Dayy:_EntityAbstract2<Dayy>
    {
        public Dayy():base()
        {
            
        }
        public Dayy(MyDB db)
            : base(db)
        {
            
        }
        
        //Lấy list dãy theo cơ sở id
        /// <summary>
        /// Sử dụng CoSo.dayys thay vì viết hàm riêng giống như vậy
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Dayy> GetByCoSoId(int id)
        {
            try
            {
                initDb();
                List<Dayy> objs = db.Set<Dayy>().Where(c => c.coso.id == id).ToList();
                foreach (Dayy item in objs)
                {
                    item.DB = db;//importance
                }
                return objs;
            }
            catch (Exception ex)
            {
                return new List<Dayy>();
            }
            finally
            {

            }
        }
        protected override void init()
        {
            base.init();
            vitris = new List<ViTri>();
            tangs = new List<Tang>();
        }
        /*
         * FK
         */
        [Required]
        public virtual CoSo coso { get; set; }
        public virtual ICollection<Tang> tangs { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
    }
}
