using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace QuanLyTaiSanGUI.MyUC
{
    class GetCheckedNodes : TreeListOperation
    {
        String type = "";
        public List<TreeListNode> CheckedNodes = new List<TreeListNode>();
        public GetCheckedNodes(String _type) : base() 
        {
            type = _type;
        }
        public override void Execute(TreeListNode node)
        {
            if (node.CheckState != CheckState.Unchecked && node.GetValue(2).Equals(type))
                CheckedNodes.Add(node);
        }
    }
}
