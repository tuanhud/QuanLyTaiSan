using DevExpress.XtraTreeList.Data;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCD_GUI.MyUserControl
{
    public class findNode: TreeListOperation
        {
            private object columnName = "";
            private TreeListNode nodeCore;
            private object id;
            private object loai;
            private bool isNullCore;
            public findNode(object _id, object _columnName)
            {
                this.id = _id;
                this.columnName = _columnName;
                this.nodeCore = null;
                this.isNullCore = TreeListData.IsNull(id);
            }
            public override void Execute(TreeListNode node)
            {
                if (IsLookedFor(node.GetValue(columnName)))
                    this.nodeCore = node;
            }
            bool IsLookedFor(object _id)
            {
                if (IsNull)
                    return (id == _id);
                return id.Equals(_id);
            }
            protected bool IsNull { get { return isNullCore; } }
            public override bool CanContinueIteration(TreeListNode node) { return Node == null; }
            public TreeListNode Node { get { return nodeCore; } }
        }
}
