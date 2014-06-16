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
using QuanLyTaiSanGUI.MyUC;

namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    public partial class ucQuanLyCoSo : UserControl
    {
        ucTreeViTri _ucTreeViTri = new ucTreeViTri();
        public ucQuanLyCoSo()
        {
            InitializeComponent();
        }

        private void ucQuanLyCoSo_Load(object sender, EventArgs e)
        {
            CreateNodes(treeListViTri);
            //_ucTreeViTri.Dock = DockStyle.Left;
            panelControl1.Controls.Add(_ucTreeViTri);
        }

        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            DataTable dtCoSo = this.cososTableAdapter1.GetData();
            foreach(DataRow row in dtCoSo.Rows)
            {
                TreeListNode rootNode = tl.AppendNode(new object[] { row["id"], row["ten"], "coso" }, parentForRootNodes);
                // Create a child of the rootNode
                DataTable dtDay = this.daysTableAdapter1.GetDataBy1((int)row["id"]);
                foreach (DataRow row2 in dtDay.Rows)
                {
                    TreeListNode rootNode2 = tl.AppendNode(new object[] { row2["id"], row2["ten"], "day" }, rootNode);
                    // Create a child of the rootNode
                    DataTable dtTang = this.tangsTableAdapter1.GetDataBy1((int)row2["id"]);
                    foreach (DataRow row3 in dtTang.Rows)
                    {
                        tl.AppendNode(new object[] { row3["id"], row3["ten"], "tang" }, rootNode2);
                        // Creating more nodes
                        // ...
                    }
                }
            }
            tl.EndUnboundLoad();
        }
    }
}
