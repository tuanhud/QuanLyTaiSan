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
using QuanLyTaiSan.DataFilter;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreePhong : UserControl
    {
        int phongid = -1;
        int cosoid = -1;
        int dayid = -1;
        int tangid = -1;
        public ucTreePhong(List<ViTriFilter> _list)
        {
            InitializeComponent();
            loadData(_list);
        }

        private void loadData(List<ViTriFilter> _list)
        {
            treeListPhong.BeginUnboundLoad();
            treeListPhong.DataSource = _list;
            treeListPhong.EndUnboundLoad();
        }

        private void treeListPhong_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                phongid = -1;
                cosoid = -1;
                dayid = -1;
                tangid = -1;
                if(e.Node.GetValue(2)!= null)
                {
                    switch (e.Node.GetValue(2).ToString())
                    {
                        case "CoSo":
                            cosoid = Convert.ToInt32(e.Node.GetValue(0));
                            break;
                        case "Dayy":
                            dayid = Convert.ToInt32(e.Node.GetValue(0));
                            cosoid = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                            break;
                        case "Tang":
                            tangid = Convert.ToInt32(e.Node.GetValue(0));
                            dayid = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                            cosoid = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                            break;
                        case "Phong":
                            phongid = Convert.ToInt32(e.Node.GetValue(0));
                            tangid = Convert.ToInt32(e.Node.ParentNode.GetValue(0));
                            dayid = Convert.ToInt32(e.Node.ParentNode.ParentNode.GetValue(0));
                            cosoid = Convert.ToInt32(e.Node.ParentNode.ParentNode.ParentNode.GetValue(0));
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

        public ViTri getVitri(MyDB db)
        {
            ViTri obj = new ViTri(db);
            obj.coso = new CoSo(db).getById(cosoid);
            obj.day = new Dayy(db).getById(dayid);
            obj.tang = new Tang(db).getById(tangid);
            return obj;
        }
    }
}
