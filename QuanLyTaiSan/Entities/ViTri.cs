using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("VITRIS")]
    public class ViTri : _EntityAbstract1<ViTri>
    {
        public ViTri():base()
        {
            
        }
        public ViTri(MyDB db)
            : base(db)
        {

        }
        #region Dinh nghia
        public String mota { get; set; }
        
        /*
         * FK
         */
        [Index("nothing", 1, IsUnique = true)]
        public virtual CoSo coso { get; set; }

        [Index("nothing", 2, IsUnique = true)]
        public virtual Dayy day { get; set; }

        [Index("nothing", 3, IsUnique = true)]
        public virtual Tang tang { get; set; }

        public virtual ICollection<Phong> phongs { get; set; }
        #endregion
        #region Nghiệp vụ
        /// <summary>
        /// Hàm dùng tạm để test dũu liệu
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="id3"></param>
        /// <returns></returns>

        public ViTri getBy3Id(int id1, int id2, int id3)
        {
            try
            {
                initDb();
                ViTri obj = null;
                if (id3 != -1)
                {
                    obj = db.Set<ViTri>().Where(c => c.coso.id == id1 && c.day.id == id2 && c.tang.id == id3).FirstOrDefault();
                }
                else if (id2 != -1)
                {
                    obj = db.Set<ViTri>().Where(c => c.coso.id == id1 && c.day.id == id2 && c.tang.id == null).FirstOrDefault();
                }
                else
                {
                    obj = db.Set<ViTri>().Where(c => c.coso.id == id1 && c.day.id == null && c.tang.id == null).FirstOrDefault();
                }
                if (obj != null)
                {
                    obj.DB = db;
                }
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public List<ViTri> search(CoSo coso, Dayy day, Tang tang)
        {
            initDb();
            List<ViTri> tmp = new List<ViTri>(); ;
            if(coso==null && day==null && tang==null)
            {
                tmp = db.VITRIS.Where(c => c.coso==null && c.day==null && c.tang==null).ToList();
            }
            else if(coso!=null && day==null && tang==null)
            {
                tmp = db.VITRIS.Where(c => c.coso.id==coso.id && c.day==null && c.tang==null).ToList();
            }
            else if (coso != null && day != null && tang == null)
            {
                tmp = db.VITRIS.Where(c => c.coso.id == coso.id && c.day.id == day.id && c.tang == null).ToList();
            }
            else if (coso != null && day != null && tang != null)
            {
                tmp = db.VITRIS.Where(c => c.coso.id == coso.id && c.day.id == day.id && c.tang.id == tang.id).ToList();
            }
            if (tmp != null)
            {
                foreach (ViTri item in tmp)
                {
                    item.DB = db;
                }
            }
            return tmp;
        }
        public List<ViTri> search(int coso_id, int day_id, int tang_id)
        {
            initDb();
            List<ViTri> tmp = new List<ViTri>(); ;
            CoSo coso = new CoSo();
            coso = coso.getById(coso_id);
            Dayy day = new Dayy();
            day = day.getById(day_id);
            Tang tang = new Tang();
            tang = tang.getById(tang_id);
            return search(coso, day, tang);
        }


        #endregion
		#region Override method
        public override int update()
        {
            //have to load all [Required] FK object first
            if (coso != null)
            {
                coso.trigger();
            }
			if (day != null)
            {
                day.trigger();
            }
			if (tang != null)
            {
                tang.trigger();
            }
			
            
            //...
            return base.update();
        }

        #endregion
    }
}
