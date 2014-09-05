using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraTreeList.Nodes;
using QuanLyTaiSan.Entities;
using SHARED.Libraries;

namespace QuanLyTaiSanGUI.MyUC
{
    public partial class ucTreeListLookUpViTri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTreeListLookUpViTri()
        {
            InitializeComponent();
        }

        public void loadData(List<ViTriHienThi> _list)
        {
            treeListLookUpViTri.Properties.DataSource = null;
            treeListLookUpViTri.Properties.DataSource = _list;
        }

        private void treeListLookUpViTri_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            TreeListNode node = treeListLookUpViTriTreeList.FindNodeByKeyID(e.Value);
            if (node != null)
            {
                if (node.GetValue(colloai).Equals(typeof(CoSo).Name))
                {
                    e.DisplayText = node.GetValue(colten).ToString();
                }
                else if (node.GetValue(colloai).ToString().Equals(typeof(Dayy).Name))
                {
                    e.DisplayText = node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                }
                else if (node.GetValue(colloai).Equals(typeof(Tang).Name))
                {
                    e.DisplayText = node.ParentNode.ParentNode.GetValue(colten).ToString() + " - " + node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                }
                else if (node.GetValue(colloai).Equals(typeof(Phong).Name))
                {
                    e.DisplayText = node.GetValue(colten).ToString();
                }
            }
        }

        public ViTri getViTri()
        {
            try
            {
                TreeListNode node = treeListLookUpViTriTreeList.FocusedNode;
                if (node != null)
                {
                    if (node.GetValue(colloai).Equals(typeof(CoSo).Name))
                    {
                        CoSo obj = CoSo.getById(GUID.From(node.GetValue(colid)));
                        if (obj != null)
                            return ViTri.request(obj, null, null);
                    }
                    else if (node.GetValue(colloai).Equals(typeof(Dayy).Name))
                    {
                        Dayy obj = Dayy.getById(GUID.From(node.GetValue(colid)));
                        if (obj != null)
                            return ViTri.request(null, obj, null);
                    }
                    else if (node.GetValue(colloai).Equals(typeof(Tang).Name))
                    {
                        Tang obj = Tang.getById(GUID.From(node.GetValue(colid)));
                        if (obj != null)
                            return ViTri.request(null, null, obj);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getViTri: " + ex.Message);
                return null;
            }
        }

        public Phong getPhong()
        {
            try
            {
                TreeListNode node = treeListLookUpViTriTreeList.FocusedNode;
                if (node != null)
                {
                    if (node.GetValue(colloai).Equals(typeof(Phong).Name))
                    {
                        Phong obj = node.GetValue(colphong) as Phong;
                        if (obj != null)
                            return obj;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getPhong: " + ex.Message);
                return null;
            }
        }

        public void setPhong(Phong obj)
        {
            try
            {
                if (obj != null && !obj.id.Equals(Guid.Empty))
                {
                    treeListLookUpViTri.EditValue = obj.id;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setPhong: " + ex.Message);
            }
        }

        public void setReadOnly(bool b)
        {
            treeListLookUpViTri.Properties.ReadOnly = b;
        }

        public void setViTri(ViTri obj)
        {
            try
            {
                if (obj != null)
                {
                    if (obj.tang != null && !obj.tang.id.Equals(Guid.Empty))
                    {
                        treeListLookUpViTri.EditValue = obj.tang.id;
                    }
                    else if (obj.day != null && !obj.day.id.Equals(Guid.Empty))
                    {
                        treeListLookUpViTri.EditValue = obj.day.id;
                    }
                    else if (obj.coso != null && !obj.coso.id.Equals(Guid.Empty))
                    {
                        treeListLookUpViTri.EditValue = obj.coso.id;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setViTri: " + ex.Message);
            }
        }
    }
}
