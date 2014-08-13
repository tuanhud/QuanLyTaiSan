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

            //CoSo obj = CoSo.getById(1);
            //List<HinhAnh> k = obj.hinhanhs;

            //k.Add(new HinhAnh {path="tttt" });

            //DBInstance.commit();
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
