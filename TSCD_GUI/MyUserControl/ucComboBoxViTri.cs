using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using SHARED.Libraries;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using TSCD.Entities;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucComboBoxViTri : DevExpress.XtraEditors.XtraUserControl
    {
        bool chonDay = false;
        bool chonPhong = false;

        public ucComboBoxViTri()
        {
            InitializeComponent();
        }

        public ucComboBoxViTri(bool _chonDay, bool _chonPhong)
        {
            InitializeComponent();
            init(_chonDay, _chonPhong);
        }

        public void init(bool _chonDay, bool _chonPhong)
        {
            chonDay = _chonDay;
            chonPhong = _chonPhong;
        }

        public void loadData(List<ViTriHienThi> _list)
        {
            treeListLookUpViTri.Properties.DataSource = _list;
        }

        public ViTri getViTri()
        {
            try
            {
                TreeListNode node = treeListLookUpViTriTreeList.FindNodeByKeyID(treeListLookUpViTri.EditValue);
                if (node != null)
                {
                    if (node.GetValue(colloai).Equals(typeof(CoSo).Name))
                    {
                        CoSo obj = CoSo.getById(GUID.From(treeListLookUpViTri.EditValue));
                        if (obj != null)
                            return ViTri.request(obj, null, null);
                    }
                    else if (node.GetValue(colloai).Equals(typeof(Dayy).Name))
                    {
                        Dayy obj = Dayy.getById(GUID.From(treeListLookUpViTri.EditValue));
                        if (obj != null)
                            return ViTri.request(null, obj, null);
                    }
                    else if (node.GetValue(colloai).Equals(typeof(Tang).Name))
                    {
                        Tang obj = Tang.getById(GUID.From(treeListLookUpViTri.EditValue));
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
                return Phong.getById(GUID.From(treeListLookUpViTri.EditValue));
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
                    if (obj.tang != null && obj.tang.id != Guid.Empty)
                        treeListLookUpViTri.EditValue = obj.tang.id;
                    else if (obj.day != null && obj.day.id != Guid.Empty)
                        treeListLookUpViTri.EditValue = obj.day.id;
                    else if (obj.coso != null && obj.coso.id != Guid.Empty)
                        treeListLookUpViTri.EditValue = obj.coso.id;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setViTri: " + ex.Message);
            }
        }

        private void treeListLookUpViTri_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            try
            {
                TreeListNode node = treeListLookUpViTriTreeList.FindNodeByKeyID(e.Value);
                if (node != null)
                {
                    if (node.GetValue(colloai).ToString().Equals(typeof(CoSo).Name))
                    {
                        e.DisplayText = node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).ToString().Equals(typeof(Dayy).Name))
                    {
                        e.DisplayText  = node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).ToString().Equals(typeof(Tang).Name))
                    {
                        e.DisplayText = node.ParentNode.ParentNode.GetValue(colten).ToString() +
                            " - " + node.ParentNode.GetValue(colten).ToString() + " - " + node.GetValue(colten).ToString();
                    }
                    else if (node.GetValue(colloai).ToString().Equals(typeof(Phong).Name))
                    {
                        e.DisplayText = node.GetValue(colten).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLookUpViTri_CustomDisplayText: " + ex.Message);
            }
        }

        private void treeListLookUpViTri_QueryCloseUp(object sender, CancelEventArgs e)
        {
            try
            {
                if (treeListLookUpViTriTreeList.FocusedNode != null)
                {
                    TreeListNode node = treeListLookUpViTriTreeList.FocusedNode;
                    if (chonDay)
                    {
                        if (node.GetValue(colloai) != null && node.GetValue(colloai).Equals(typeof(Dayy).Name))
                        { }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    if (chonPhong)
                    {
                        if (node.GetValue(colloai) != null && node.GetValue(colloai).Equals(typeof(Phong).Name))
                        { }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->treeListLookUpViTri_QueryCloseUp: " + ex.Message);
            }
        }
    }
}
