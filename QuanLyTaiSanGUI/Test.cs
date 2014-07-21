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

namespace QuanLyTaiSanGUI
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            CoSo obj = CoSo.getById(3);
            //List<String> re = FTPHelper.GetFilesInDirectory(Global.remote_setting.ftp_host.getCombinedPath(""), Global.remote_setting.ftp_host.USER_NAME, Global.remote_setting.ftp_host.PASS_WORD).ToList();

            obj.moveUp();
        }
    }
}
