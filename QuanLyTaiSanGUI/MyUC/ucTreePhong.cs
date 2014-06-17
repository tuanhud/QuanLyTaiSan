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
        List<Dayy> listDays = new List<Dayy>();
        List<Tang> listTangs = new List<Tang>();
        List<Phong> listPhongs = new List<Phong>();
        public ucTreePhong()
        {
            InitializeComponent();
            CreateNodes(treeListPhong);
        }
        private void CreateNodes(TreeList tl)
        {
            try
            {
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
                            //TreeListNode rootNode3 = tl.AppendNode(new object[] { _tang.id, _tang.ten, "tang" }, rootNode2);
                            //ViTri obj2 = new ViTri();
                            //obj2.coso = _coso;
                            //obj2.day = _day;
                            //obj2.tang = _tang;
                            //listPhongs = obj2.phongs.ToList();
                            //foreach (Phong _phong in listPhongs)
                            //{
                            //    tl.AppendNode(new object[] { _phong.id, _phong.ten, "phong" }, rootNode3);
                            //}
                        }
                        //ViTri obj3 = new ViTri();
                        //obj3.coso = _coso;
                        //obj3.day = _day;
                        //listPhongs = obj3.phongs.ToList();
                        //foreach (Phong _phong in listPhongs)
                        //{
                        //    tl.AppendNode(new object[] { _phong.id, _phong.ten, "phong" }, rootNode2);
                        //}
                    }
                    //ViTri obj = new ViTri();
                    //obj.coso=_coso;
                    //listPhongs = obj.phongs.ToList();
                    //foreach (Phong _phong in listPhongs)
                    //{
                    //    tl.AppendNode(new object[] { _phong.id, _phong.ten, "phong" }, rootNode);
                    //}

                }
                tl.EndUnboundLoad();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }
    }
}
