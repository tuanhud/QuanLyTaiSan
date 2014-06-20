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
    public class FindNode: TreeListOperation
        {
            public const string idColumnName = "id";
            public const string loaiColumnName = "loai";
            private TreeListNode nodeCore;
            private object id;
            private object loai;
            private bool isNullCore;
            public FindNode(object _id, object _loai)
            {
                this.id = _id;
                this.loai = _loai;
                this.nodeCore = null;
                this.isNullCore = TreeListData.IsNull(id) || TreeListData.IsNull(loai);
            }
            public override void Execute(TreeListNode node)
            {
                if (IsLookedFor(node.GetValue(idColumnName), node.GetValue(loaiColumnName)))
                    this.nodeCore = node;
            }
            bool IsLookedFor(object _id, object _loai)
            {
                if (IsNull) return (id == _id && loai == _loai);
                return id.Equals(_id) && loai.Equals(_loai);
            }
            protected bool IsNull { get { return isNullCore; } }
            public override bool CanContinueIteration(TreeListNode node) { return Node == null; }
            public TreeListNode Node { get { return nodeCore; } }
        }
}
