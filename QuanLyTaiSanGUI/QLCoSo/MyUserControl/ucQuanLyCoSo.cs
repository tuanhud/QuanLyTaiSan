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
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    public partial class ucQuanLyCoSo : UserControl
    {
        ucTreeViTri _ucTreeViTri = new ucTreeViTri();
        List<CoSo> listCoSos = new List<CoSo>();
        List<Dayy> listDays = new List<Dayy>();
        List<Tang> listTangs = new List<Tang>();
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
            CoSo obj = new CoSo();
            listCoSos = obj.getAll();
            foreach (CoSo _coso in listCoSos)
            {
                TreeListNode rootNode = tl.AppendNode(new object[] { _coso.id, _coso.ten, "coso" }, parentForRootNodes);
                // Create a child of the rootNode
                Dayy obj2 = new Dayy();
                listDays = obj2.GetByCoSoId(_coso.id);
                foreach (Dayy _day in listDays)
                {
                    TreeListNode rootNode2 = tl.AppendNode(new object[] { _day.id, _day.ten, "day" }, rootNode);
                    // Create a child of the rootNode
                    Tang obj3 = new Tang();
                    listTangs = obj3.GetByDayId(_day.id);
                    foreach (Tang _tang in listTangs)
                    {
                        tl.AppendNode(new object[] { _tang.id, _tang.ten, "tang" }, rootNode2);
                        // Creating more nodes
                        // ...
                    }
                }
            }
            tl.EndUnboundLoad();
        }
    }
}
