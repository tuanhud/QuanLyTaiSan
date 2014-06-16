﻿using System;
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
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.QLCoSo.MyUserControl
{
    public partial class ucQuanLyCoSo : UserControl
    {
        ucTreeViTri _ucTreeViTri = new ucTreeViTri(false);
        List<CoSo> listCoSos = new List<CoSo>();
        List<Dayy> listDays = new List<Dayy>();
        List<Tang> listTangs = new List<Tang>();
        String type = "";
        public ucQuanLyCoSo()
        {
            InitializeComponent();
        }

        private void ucQuanLyCoSo_Load(object sender, EventArgs e)
        {
            CreateNodes(treeListViTri);
            //_ucTreeViTri.Dock = DockStyle.Left;
            //panelControl1.Controls.Add(_ucTreeViTri);
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

        private void treeListViTri_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.GetValue(2).ToString().Equals("coso"))
                {
                    CoSo objCoSo = new CoSo().getById(Convert.ToInt32(e.Node.GetValue(0)));
                    txtTen.Text = objCoSo.ten;
                    txtMoTa.Text = objCoSo.mota;
                    panelControl1.Controls.Clear();
                    LabelControl lbl = new LabelControl();
                    lbl.Text = "Đại học Sài Gòn";
                    lbl.Dock = DockStyle.Left;
                    panelControl1.Controls.Add(lbl);
                    type = "coso";
                }
                else if (e.Node.GetValue(2).ToString().Equals("day"))
                {
                    panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucTreeViTri);
                    Dayy objDay = new Dayy().getById(Convert.ToInt32(e.Node.GetValue(0)));
                    txtTen.Text = objDay.ten;
                    txtMoTa.Text = objDay.mota;
                    ViTri objViTri = new ViTri();
                    objViTri.coso = objDay.coso;
                    _ucTreeViTri.setViTri(objViTri);
                    type = "day";
                }
                else if (e.Node.GetValue(2).ToString().Equals("tang"))
                {
                    panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucTreeViTri);
                    Tang objTang = new Tang().getById(Convert.ToInt32(e.Node.GetValue(0)));
                    txtTen.Text = objTang.ten;
                    txtMoTa.Text = objTang.mota;
                    ViTri objViTri = new ViTri();
                    objViTri.day = objTang.day;
                    objViTri.coso = objTang.day.coso;
                    _ucTreeViTri.setViTri(objViTri);
                    type = "tang";
                }
            }
        }

        public void enableEdit(bool _enable)
        {
            if (_enable)
            {
                btnImage.Visible = true;
                btnOK.Visible = true;
                btnHuy.Visible = true;
                txtTen.Properties.ReadOnly = false;
                txtMoTa.Properties.ReadOnly = false;
                _ucTreeViTri.setReadOnly(false);
            }
            else
            {
                btnImage.Visible = false;
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtTen.Properties.ReadOnly = true;
                txtMoTa.Properties.ReadOnly = true;
                _ucTreeViTri.setReadOnly(true);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
