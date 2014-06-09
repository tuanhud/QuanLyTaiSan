using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSan
{
    public partial class Test_Form : Form
    {
        public Test_Form()
        {
            InitializeComponent();
            //test Code first
            MyDB db = new MyDB();
            /*
            foreach(ThietBi item in db.PHONGS.Where(p => p.id > 0).FirstOrDefault().thietbis)
            {
                
            }
            
            Group gp = db.GROUPS.Where(p => p.id > 0).FirstOrDefault();
            foreach (Permission item in gp.permissions)
            {
                if(item.isInGroup(gp))
                Console.WriteLine(item.key);
            }
            */
        }
    }
}
