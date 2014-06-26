using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSan
{
    public partial class Test_Area : Form
    {
        /*
         * 
         * Lỗi sau khi get object ra mà Dispose cái Context thì không truy xuất được FK obj => update lỗi kéo theo, do Lazy loading
         * Nếu không Dispose thì dính lỗi Multi Context Tracking (Tìm cách sửa chỗ này)
         * Đã Fix
         * 
         * 
         */
            
        public Test_Area()
        {
            InitializeComponent();
            /*
            Boolean auto_remove = false;
            ThietBi obj = new ThietBi().getById(2);
            //test fk dependency
            int re = obj.delete(auto_remove);
            //Switch to auto remove fk
            auto_remove = true;
            re = obj.delete(auto_remove);
            Console.WriteLine(re);
             */

            //CoSo obj = DBInstance.DB.THIETBIS.Find();
            ////DBInstance.DB.COSOS.Attach(obj);
            //DBInstance.DB.COSOS.Remove(obj);
            //DBInstance.DB.SaveChanges();

            Console.WriteLine("");
        }
        private void reload_obj_theo_dbcontext_hien_tai()
        {
            //Object lấy bởi Context cũ
            QuanTriVien obj = new QuanTriVien().getById(1);
            //Nơi nào đó gọi reNew
            DBInstance.reNew();
            //Group được load ra bởi Context mới
            Group g = new Group().getById(2);
            //Phải reload Object quantrivien theo Context mới do Context đã bị new mới
            //nếu không thì sau khi gán => update sẽ gây lỗi do 2 Object trên khác Context
            obj = obj.reload();
            //gán Group cho QuanTriVien
            obj.group = g;
            //Update
            int re = obj.update();
        }
        private void setting()
        {
            Setting setting = new Setting().getByKey("my_key");
            setting.value = "my_value";
            setting.addOrUpdate();
            Console.WriteLine("Finish");
        }
        private void dichuyen_tb()
        {
            CTThietBi obj = new CTThietBi().getById(18);
            Phong dich = new Phong().getById(4);
            int re = obj.dichuyen(dich, 2, "Chua co mota nao");
            Console.WriteLine(re);
        }
        private void login()
        {
            QuanTriVien obj = new QuanTriVien().getByUserName("admin");
            obj.hashPassword("password");
            Boolean re= obj.checkLoginByUserName();
        }
        private void doi_mat_khau()
        {
            QuanTriVien obj = new QuanTriVien().getByUserName("admin");
            int re = obj.changePassword("123123", "123123");
            Console.WriteLine(re);
        }
        private void AUD_obj_co_khoa_ngoai()
        {
            QuanTriVien obj = new QuanTriVien();//context not init yet
            //init new value
            obj.hoten = "hoten_shudghfgdf";
            obj.password = "password_6t37434";
            obj.username = "admin_ghyty6t734";
            //init new group
            Group gp = new Group();//context created using GET, SET procedure, passing context to Group obj
            //init new value
            gp.key = "admin333";
            gp.ten = "bhsgd6t34";
            gp.mota = "Quarn tri cap cao";
            //assign FK obj
            obj.group = gp;
            //add
            obj.add();//use existing context created before to avoid Exception because of multiple Context tracking, both "obj" and "gp" is under same context
            //update
            obj.update();//use existing context created before to avoid Exception because of multiple Context tracking
            obj.delete();//use existing context created before to avoid Exception because of multiple Context tracking
            Console.WriteLine("Finish");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
        }
    }
}
