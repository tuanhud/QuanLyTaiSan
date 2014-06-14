using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    public partial class ucQuanLyCoSo : UserControl
    {
        public ucQuanLyCoSo()
        {
            InitializeComponent();
        }

        private void ucQuanLyCoSo_Load(object sender, EventArgs e)
        {

        }

        private void CreateNode(TreeList tl)
        {
            DataTable dt = this.cososTableAdapter1.GetData();
            tl.BeginUnboundLoad();
            // Create a root node
            TreeListNode parentForRootNodes = null;
            foreach (DataRow r in dt.Rows)
            {

            }

            tl.EndUnboundLoad();
        }
    }
}
