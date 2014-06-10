using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        }
        private MyDB db;
        private void button_refresh_Click(object sender, EventArgs e)
        {
            int prev_index = listBox1.SelectedIndex;
            
            Permission prev_obj=null;
            if(prev_index>=0)
            {
                prev_obj = ((List<Permission>)listBox1.DataSource).ElementAt(prev_index);
            }
            try
            {

                db = new MyDB();
                listBox1.DisplayMember = "key";
                List<Permission> objs = db.PERMISSIONS.ToList();
                listBox1.DataSource = objs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(msg_error_db_common);
            }
            finally
            {
                db.Dispose();
            }

            if (prev_obj!=null)
            {
                foreach(Permission tmp in ((List<Permission>)listBox1.DataSource))
                {
                    if (tmp.id == prev_obj.id)
                    {
                        listBox1.SelectedItem = tmp;
                        break;
                    }
                }
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                db = new MyDB();
                Permission obj = new Permission { key = textBox_permissionName.Text, mota = textBox_permissionName.Text + "_mota" };
                db.PERMISSIONS.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(msg_error_db_common);
            }
            finally
            {
                db.Dispose();//very importance, because of multiple-tracking exception
                button_refresh.PerformClick();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            //load to global var
            editting_obj = ((List<Permission>)listBox1.DataSource).ElementAt(index);
            textBox_permissionNameEdit.Text = editting_obj.key;
        }
        private Permission editting_obj;//current selected obj, item currently selected in listbox
        private void button_update_Click(object sender, EventArgs e)
        {
            try{

                db = new MyDB();
                editting_obj.key = textBox_permissionNameEdit.Text;

                db.PERMISSIONS.Attach(editting_obj);
                db.Entry(editting_obj).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(msg_db_obj_notfound);
            }
            finally
            {
                db.Dispose();
                button_refresh.PerformClick();
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            //editting obj may be removed somewhere else
            try
            {
                db = new MyDB();
                db.PERMISSIONS.Attach(editting_obj);//must be done before remove
                db.PERMISSIONS.Remove(editting_obj);
                db.SaveChanges();
                db.Dispose();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(msg_db_obj_notfound);
            }
            finally
            {
                button_refresh.PerformClick();
            }
        }
        private String msg_db_obj_notfound = "Obj not found, may be removed somewhere else";
        private void Test_Form_Shown(object sender, EventArgs e)
        {
            button_refresh.PerformClick();
        }

        private void button_generateSample_Click(object sender, EventArgs e)
        {
            db = new MyDB();
            for (int i = 0; i < 10; i++)
            {
                Permission obj = new Permission { key = "ex_" + i, mota = "nothing_" + i };
                db.PERMISSIONS.Add(obj);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(msg_error_db_common);
            }
            finally
            {
                db.Dispose();
                button_refresh.PerformClick();
            }
        }
        private String msg_error_db_common = "Database constrain fail!";
    }
}
