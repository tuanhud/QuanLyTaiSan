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
        String coltype = "";
        bool haveCol = false;
        public List<TreeListNode> CheckedNodes = new List<TreeListNode>();
        public GetCheckedNodes(String _coltype, String _type) : base() 
        {
            coltype = _coltype;
            type = _type;
            haveCol = true;
        }
        public GetCheckedNodes(): base() { }
        public override void Execute(TreeListNode node)
        {
            if (haveCol)
            {
                if (node.CheckState != CheckState.Unchecked && node.GetValue(coltype).Equals(type))
                    CheckedNodes.Add(node);
            }
            else
            {
                if (node.CheckState != CheckState.Unchecked)
                    CheckedNodes.Add(node);
            }
        }
    }
}
