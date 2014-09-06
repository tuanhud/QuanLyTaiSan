using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSCD.Entities;

namespace TSCD
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            Global.current_quantrivien_login = QuanTriVien.getByUserName("admin");


            //LoaiTaiSan lts = new LoaiTaiSan();
            //lts.ten = "Loai 1";
            //lts.sonamsudung = 5;
            //lts.phantramhaomon = 20;

            //TaiSan ts = new TaiSan();
            //ts.ten = "Ten ts";
            //ts.dongia = 676542222;
            //ts.loaitaisan = lts;
            //ts.subId = "TREWWWSS$####";
            

            //CTTaiSan obj = new CTTaiSan();
            
            //obj.taisan = ts;
            //obj.chungtu_ngay = DateTime.Now;
            //obj.chungtu_sohieu = "RT45644";
            //obj.ngay = DateTime.Now;
            //obj.nguongoc = "UBND Tang";
            //obj.soluong = 40;
            //obj.tinhtrang = TinhTrang.getQuery().FirstOrDefault();


            CTTaiSan obj = CTTaiSan.getById(GUID.From("801C27FE-7435-E411-96A8-001F16338B1E"));
            obj.chuyenDoi(obj.donviquanly, obj.donvisudung, TinhTrang.getById(GUID.From("C3DEB899-7435-E411-96A8-001F16338B1E")), obj.vitri, obj.phong, null , DateTime.Now, "54367859", -1, "CHuyển hết luôn dot 2", DateTime.Now);

            
            int re = DBInstance.commit();

        }
    }
}
