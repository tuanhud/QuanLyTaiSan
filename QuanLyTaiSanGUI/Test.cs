using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace QuanLyTaiSanGUI
{
    interface vdthoi{
        void reLoad();
    }
    public partial class Test : Form, vdthoi
    {
        public Test()
        {
            InitializeComponent();
            //Dictionary<String, String> i = new Dictionary<string, string>();
            //i.Add("Username","quocdunginfo");
            //i.Add("IP", "125.4567.78~!@#$%^&*()_+{}|:");
            //var json = new JavaScriptSerializer().Serialize(i.ToDictionary(item => item.Key.ToString(), item => item.Value.ToString()));
            //Console.WriteLine(json);

            OurDBContext db=new OurDBContext();
            QuanTriVien obj = db.QUANTRIVIENS.Find(5);
            obj.username = "what the hell";
            obj = obj.reload();
            obj = obj.reload();
            obj = obj.reload();
            String m = obj.username;
        }

        private void ucThemSuaXoaButton1_ButtonThemClick(object sender, EventArgs e)
        {
            MessageBox.Show("them click");
            ucThemSuaXoaButton1.btnSua.Hide();
        }

        public void reLoad()
        {
            MessageBox.Show("wtf");
        }
    }
}
