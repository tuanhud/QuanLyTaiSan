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
    public partial class Test_Form_2 : Form
    {
        public Test_Form_2()
        {
            InitializeComponent();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            DBInstance.reNew();
            //List<Permission> objs = Permission.getAll();
            listBox1.DisplayMember = "key";
            //listBox1.DataSource = objs;
        }
        private Permission current_selected = null;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            //load to global var
            current_selected = ((List<Permission>)listBox1.DataSource).ElementAt(index);
            textBox_permissionNameEdit.Text = current_selected.key;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            current_selected.key = textBox_permissionNameEdit.Text;
            int re = current_selected.update();
            if (re < 0)
            {
                MessageBox.Show(msg_db_fail);
            }
            
            button_refresh.PerformClick();
        }
        

        private void button_add_Click(object sender, EventArgs e)
        {
            Permission obj = new Permission();
            obj.key = textBox_permissionName.Text;
            obj.mota = "chua co";
            int re = obj.add();
            if (re < 0)
            {
                MessageBox.Show(msg_db_fail);
            }

            button_refresh.PerformClick();
        }
        private String msg_db_fail = "Fail";

        private void button_remove_Click(object sender, EventArgs e)
        {
            int re = current_selected.delete();
            if (re < 0)
            {
                MessageBox.Show(msg_db_fail);
            }
            button_refresh.PerformClick();
        }
    }
}
