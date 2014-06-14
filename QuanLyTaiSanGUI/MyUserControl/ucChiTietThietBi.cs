using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietThietBi : UserControl
    {
        ucComboBoxPhong uc = new ucComboBoxPhong();
        public ucChiTietThietBi()
        {
            InitializeComponent();
            this.lOAITHIETBISTableAdapter.Fill(this.dataSet1.LOAITHIETBIS);
            this.pHONGSTableAdapter.Fill(this.dataSet1.PHONGS);
            panelControl1.Controls.Add(uc);
        }
        public void LoadData(int _id)
        {
            DataTable dt = this.ctthietbisTableAdapter.GetDataBy1(_id);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                textEdit1.Text = r["ten"].ToString();
                comboBox1.SelectedValue = Convert.ToInt32(r["loaithietbi_id"].ToString());
                comboBox2.SelectedValue = Convert.ToInt32(r["phong_id"].ToString());
                textEdit4.Text = r["mota"].ToString();
                dateEdit1.DateTime = DateTime.Parse(r["ngaymua"].ToString());
                dateEdit2.DateTime = DateTime.Parse(r["ngaylap"].ToString());
                this.lOGTINHTRANGSTableAdapter.FillBy(this.dataSet1.LOGTINHTRANGS, Convert.ToInt32(r["thietbi_id"].ToString()), Convert.ToInt32(r["phong_id"].ToString()));
            }
        }
    }
}
