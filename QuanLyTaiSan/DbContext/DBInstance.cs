using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class DBInstance
    {
        private static OurDBContext db = null;
        public static OurDBContext DB
        {
            get
            {
                if (db == null)
                {
                    db = new OurDBContext();
                }
                return db;
            }
        }
        /// <summary>
        /// Bắt buộc phải gọi mới thấy được sự thay đổi CSDL do nơi khác chỉnh sửa,
        /// Tất cả Object get ra bởi DBInstace cũ sẽ phải reload mới có thể tiếp tục sử dụng lại được,
        /// Nếu không Object cũ sẽ vẫn phải chịu sự giám sát của DbContext cũ
        /// </summary>
        public static void reNew()
        {
            db = new OurDBContext();
        }
        public static void TaoDuLieuMau()
        {
            //Cơ sở
            List<CoSo> list_coso = new List<CoSo>();
            CoSo coso = new CoSo();
            coso.mota = "Chưa có";
            coso.subId = "CSC";
            coso.ten = "Cơ sở chính";
            list_coso.Add(coso);

            coso = new CoSo();
            coso.mota = "Chưa có";
            coso.subId = "CS1";
            coso.ten = "Cơ sở 1";
            list_coso.Add(coso);

            coso = new CoSo();
            coso.mota = "Chưa có";
            coso.subId = "CS2";
            coso.ten = "Cơ sở 2";
            list_coso.Add(coso);

            foreach (CoSo item in list_coso)
            {
                CoSo tmp = DB.COSOS.FirstOrDefault(c => c.subId.ToUpper().Equals(item.subId.ToUpper()));
                if (tmp == null)
                {
                    item.add();
                }
            }
            coso = DB.COSOS.FirstOrDefault(c=>c.subId.ToUpper().Equals("CSC"));
            //Dãy
            List<Dayy> list_day = new List<Dayy>();
            Dayy day = new Dayy();
            day.mota = "Chưa có";
            day.subId = "DAYA";
            day.ten = "Dãy A";
            day.coso = coso;
            list_day.Add(day);

            day = new Dayy();
            day.mota = "Chưa có";
            day.subId = "DAYB";
            day.ten = "Dãy B";
            day.coso = coso;
            list_day.Add(day);

            day = new Dayy();
            day.mota = "Chưa có";
            day.subId = "DAYC";
            day.ten = "Dãy C";
            day.coso = coso;
            list_day.Add(day);
            
            foreach (Dayy item in list_day)
            {
                Dayy tmp = DB.DAYYS.FirstOrDefault(c => c.subId.ToUpper().Equals(item.subId.ToUpper()) && c.coso.id == item.coso.id);
                if (tmp == null)
                {
                    item.add();
                }
            }
            day = DB.DAYYS.FirstOrDefault(c => c.subId.ToUpper().Equals("DAYA") && c.coso.subId.Equals("CSC"));
            //Tầng
            List<Tang> list_tang = new List<Tang>();
            Tang tang = new Tang();
            tang.mota = "Chưa có";
            tang.subId = "TANG1";
            tang.day = day;
            tang.ten = "Tầng 1";
            list_tang.Add(tang);

            tang = new Tang();
            tang.mota = "Chưa có";
            tang.subId = "TANG2";
            tang.day = day;
            tang.ten = "Tầng 2";
            list_tang.Add(tang);

            tang = new Tang();
            tang.mota = "Chưa có";
            tang.subId = "TANG3";
            tang.day = day;
            tang.ten = "Tầng 3";
            list_tang.Add(tang);

            foreach (Tang item in list_tang)
            {
                Tang tmp = DB.TANGS.FirstOrDefault(c => c.subId.ToUpper().Equals(item.subId.ToUpper()) && c.day.id == item.day.id);
                if (tmp == null)
                {
                    item.add();
                }
            }
            tang = DB.TANGS.FirstOrDefault(c=>c.subId.ToUpper().Equals("TANG1") && c.day.subId.ToUpper().Equals("DAYA") && c.day.coso.subId.ToUpper().Equals("CSC"));
            //Vị trí
            List<ViTri> list_vitri = new List<ViTri>();
            ViTri vitri = new ViTri();
            vitri.coso = coso;
            vitri.day = day;
            vitri.tang = tang;
            list_vitri.Add(vitri);

            foreach (ViTri item in list_vitri)
            {
                ViTri tmp = DB.VITRIS.FirstOrDefault(c=>c.coso.id == item.coso.id && c.day.id == item.day.id && c.tang.id ==item.tang.id);
                if (tmp == null)
                {
                    item.add();
                }
            }

            
        }
    }
}
