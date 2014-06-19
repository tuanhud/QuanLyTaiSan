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
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreePhong : UserControl
    {
        List<CoSo> listCoSos = new List<CoSo>();
        public ucTreePhong(List<CoSo> _list)
        {
            InitializeComponent();
            listCoSos = _list;
            CreateNodes(treeListPhong);
        }
        private void CreateNodes(TreeList tl)
        {
            try
            {
                List<Dayy> listDays = new List<Dayy>();
                List<Tang> listTangs = new List<Tang>();
                List<Phong> listPhongs = new List<Phong>();
                tl.BeginUnboundLoad();
                // Create a root node .
                TreeListNode parentForRootNodes = null;
                listCoSos = new CoSo().getAll();
                foreach (CoSo _coso in listCoSos)
                {
                    TreeListNode rootNode = tl.AppendNode(new object[] { _coso.id, _coso.ten, "coso" }, parentForRootNodes);
                    // Create a child of the rootNode
                    listDays = _coso.days.ToList();
                    foreach (Dayy _day in listDays)
                    {
                        TreeListNode rootNode2 = tl.AppendNode(new object[] { _day.id, _day.ten, "day" }, rootNode);
                        // Create a child of the rootNode
                        listTangs = _day.tangs.ToList();
                        foreach (Tang _tang in listTangs)
                        {
                            TreeListNode rootNode3 = tl.AppendNode(new object[] { _tang.id, _tang.ten, "tang" }, rootNode2);
                            ViTri obj2 = new ViTri().getBy3Id(_coso.id, _day.id, _tang.id);
                            if (obj2 != null)
                            {
                                listPhongs = obj2.phongs.ToList();
                                foreach (Phong _phong in listPhongs)
                                {
                                    tl.AppendNode(new object[] { _phong.id, _phong.ten, "phong" }, rootNode3);
                                }
                            }
                        }
                        ViTri obj3 = new ViTri().getBy3Id(_coso.id, _day.id, -1);
                        if (obj3 != null)
                        {
                            listPhongs = obj3.phongs.ToList();
                            foreach (Phong _phong in listPhongs)
                            {
                                tl.AppendNode(new object[] { _phong.id, _phong.ten, "phong" }, rootNode2);
                            }
                        }
                    }
                    ViTri obj = new ViTri().getBy3Id(_coso.id, -1, -1);
                    if (obj != null)
                    {
                        listPhongs = obj.phongs.ToList();
                        foreach (Phong _phong in listPhongs)
                        {
                            tl.AppendNode(new object[] { _phong.id, _phong.ten, "phong" }, rootNode);
                        }
                    }

                }
                tl.EndUnboundLoad();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }

        private void treeListPhong_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                int phongid = -1;
                int cosoid = -1;
                int dayid = -1;
                int tangid = -1;
                if(e.Node.GetValue(2)!= null)
                {
                    switch (e.Node.GetValue(2).ToString())
                    {
                        case "coso":
                            cosoid = Convert.ToInt32(e.Node.GetValue(0));
                            break;
                        case "day":
                            dayid = Convert.ToInt32(e.Node.GetValue(0));
                            cosoid = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                            break;
                        case "tang":
                            tangid = Convert.ToInt32(e.Node.GetValue(0));
                            dayid = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                            cosoid = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                            break;
                        case "phong":
                            phongid = Convert.ToInt32(e.Node.GetValue(0));
                            break;
                    }
                    if (this.ParentForm != null)
                    {
                        frmMain frm = this.ParentForm as frmMain;
                        frm.treePhongFocusedNodeChanged(phongid, cosoid, dayid, tangid);
                    }
                }
            }
            catch (Exception ex)
            { }
            finally
            { }
        }
    }
}
