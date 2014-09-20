using PTB.Entities;
using PTB.Libraries;
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
using PTB_GUI.Report;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using SHARED.Libraries;
using PTB.DataFilter.SearchFilter;

namespace PTB_GUI
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
            SHARED.Global.USE_APP_CONFIG = true;

            //for (int i = 0; i < 100; i++)
            //{
            //    NhanVienPT obj = new NhanVienPT();
            //    obj.hoten = "Hoten " + i;
            //    obj.mota = "Mo ta " + i;
            //    obj.sodienthoai = "SĐT " + i;
            //    obj.add();
            //}
            //DBInstance.commit();

            var re = NhanVienPTSF.search("123.4");
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

            XtraReport1 report = new XtraReport1();
            //// Add bounded labels to the Detail band of the report. 
            report._bindData();
            report._group();
            report.DataSource = NhanVienPT.getAll();

            ReportPrintTool printTool = new ReportPrintTool(report);
            
            printTool.ShowRibbonPreview();
        }

        private void button1_EnabledChanged(object sender, EventArgs e)
        {
            Button tmp = sender as Button;
        }
    }
}
