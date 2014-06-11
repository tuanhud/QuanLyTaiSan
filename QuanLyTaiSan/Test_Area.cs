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
         * Đang dính lỗi sau khi get object ra mà Dispose cái Context thì không truy xuất được FK obj => update lỗi kéo theo, do Lazy loading
         * Nếu không Dispose thì dính lỗi Multi Context Tracking (Tìm cách sửa chỗ này)
         * 
         * 
         * 
         */
        public Test_Area()
        {
            InitializeComponent();
            /*
            QuanLyTaiSan.Entities.Day obj = new QuanLyTaiSan.Entities.Day();
            obj = obj.getById(1);
            obj.mota = "wtf";
            Console.WriteLine(obj.coso.ten);
            obj.update();
            */
            
            QuanTriVien obj = new QuanTriVien();
            obj = obj.getById(2);
            Console.WriteLine(obj.hoten);
            Console.WriteLine(obj.group.key);
            obj.hoten = "nmnmnm";

            //int re = obj.update();
            //obj.update();

            //obj.hoten = "78";
            //int re = obj.update();
            //int re = obj.changePassword("admin2", "admin2");

            /*
            obj.username = "admin";
            obj.password = "admin2";
             * */
            //Console.WriteLine(obj.group.key);
            
        }
    }
}
