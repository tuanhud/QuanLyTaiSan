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
        private void onDBConnectionChanged(Boolean connectionOK)
        {
            label1.Text = "Connection " + (connectionOK?"OK":"FAIL") + DateTime.Now.ToShortTimeString();
        }
        public Test()
        {
            InitializeComponent();

            Global.working_database.use_internal_config = true;

            QuanTriVien obj = QuanTriVien.getByUserName("admin");
            List<Permission> pp = obj.group.permissions.ToList();
            
            Boolean re = obj.canEdit<CoSo>(CoSo.getById(7));
            re = obj.canEdit<Phong>(Phong.getById(1));
            re = obj.canEdit<Phong>(Phong.getById(3));
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

        private void button1_Click(object sender, EventArgs e)
        {
            CoSo t = CoSo.getQuery().FirstOrDefault();
        }
    }
}
