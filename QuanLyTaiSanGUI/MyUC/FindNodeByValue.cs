using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Data;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace QuanLyTaiSanGUI.MyUC
{
    class FindNodeByValue: TreeListOperation
    {
        public object col;
        private TreeListNode nodeCore;
        private object value;
        private bool isNullCore;
        public FindNodeByValue(object _col, object _value)
        {
            this.col = _col;
            this.value = _value;
            this.nodeCore = null;
            this.isNullCore = TreeListData.IsNull(value);
        }
        public override void Execute(TreeListNode node)
        {
            if (IsLookedFor(node.GetValue(col)))
                this.nodeCore = node;
        }
        bool IsLookedFor(object _value)
        {
            if (IsNull) 
                return (value == _value);
            return value.Equals(_value);
        }
        protected bool IsNull { get { return isNullCore; } }
        public override bool CanContinueIteration(TreeListNode node) { return Node == null; }
        public TreeListNode Node { get { return nodeCore; } }
    }
}
