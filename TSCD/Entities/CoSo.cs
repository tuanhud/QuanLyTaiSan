﻿using SHARED.Libraries;
using SHARED;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCD.Entities
{
    [Table("COSOS")]
    public class CoSo:_EntityAbstract1<CoSo>
    {
        public CoSo():base()
        {
            
        }
       
        #region Định nghĩa

        [Index(IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }
        /*
         * FK
         */
        public virtual ICollection<Dayy> days { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }

        #endregion

        #region Nghiệp vụ
        #endregion

        #region Override method
        public override void onAfterAdded()
        {
            this.order = DateTimeHelper.toMilisec(date_create);
            base.onAfterAdded();
        }
        public static new String VNNAME
        {
            get
            {
                return "CƠ SỞ";
            }
        }
        public override string niceName()
        {
            return VNNAME+ " " + ten;
        }
        protected override void init()
        {
            base.init();
            days = new List<Dayy>();
            vitris = new List<ViTri>();
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
