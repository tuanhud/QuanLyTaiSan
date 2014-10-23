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
using TSCD.Entities;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using TSCD_GUI.Libraries;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucGridControlTaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public String fileName = "";

        public ucGridControlTaiSan()
        {
            InitializeComponent();
        }

        public Object DataSource
        {
            set
            {
                gridControlTaiSan.DataSource = value;
            }
        }

        public bool AlwaysVisibleFindPanel
        {
            set
            {
                gridViewTaiSan.OptionsFind.AlwaysVisible = value;
            }
        }

        public CTTaiSan CTTaiSan
        {
            get
            {
                GridView view = gridControlTaiSan.FocusedView as GridView;
                if (view.GetFocusedRow() != null)
                {
                    return (view.GetFocusedRow() as TaiSanHienThi).obj;
                }
                else
                    return null;
            }
        }

        public void ExpandAllGroups()
        {
            //bandedGridViewTaiSan.ExpandAllGroups();
            gridViewTaiSan.ExpandAllGroups();
        }

        public void CollapseAllGroups()
        {
            //bandedGridViewTaiSan.ExpandAllGroups();
            gridViewTaiSan.CollapseAllGroups();
        }

        public void reloadAndFocused(Guid _id)
        {
            try
            {
                //if (_id != Guid.Empty)
                //{
                //    int rowHandle = bandedGridViewTaiSan.LocateByValue(colid.FieldName, _id);
                //    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                //        bandedGridViewTaiSan.FocusedRowHandle = rowHandle;
                //}
                if (_id != Guid.Empty)
                {
                    int rowHandle = gridViewTaiSan.LocateByValue(colid.FieldName, _id);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        gridViewTaiSan.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadAndFocused:" + ex.Message);
            }
        }

        private void bandedGridViewTaiSan_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            try
            {
                //TaiSanHienThi c = (TaiSanHienThi)bandedGridViewTaiSan.GetRow(e.RowHandle);
                //e.IsEmpty = c.childs == null || c.childs.Count == 0;
                TaiSanHienThi c = (TaiSanHienThi)gridViewTaiSan.GetRow(e.RowHandle);
                e.IsEmpty = c.childs == null || c.childs.Count == 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->bandedGridViewTaiSan_MasterRowEmpty: " + ex.Message);
            }
        }

        private void bandedGridViewTaiSan_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void bandedGridViewTaiSan_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Tài sản kèm theo";
        }

        private void bandedGridViewTaiSan_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            try
            {
                //TaiSanHienThi c = (TaiSanHienThi)bandedGridViewTaiSan.GetRow(e.RowHandle);
                //e.ChildList = TaiSanHienThi.Convert(c.childs);
                TaiSanHienThi c = (TaiSanHienThi)gridViewTaiSan.GetRow(e.RowHandle);
                e.ChildList = TaiSanHienThi.Convert(c.childs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->bandedGridViewTaiSan_MasterRowGetChildList: " + ex.Message);
            }
        }

        public void createLayout()
        {
            String currentPath = Directory.GetCurrentDirectory();
            String path = Path.Combine(currentPath, "Layout");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            String fileMaster = path + "//" + fileName + "_Master_Default.xml";
            String fileDetail = path + "//" + fileName + "_Detail_Default.xml";
            //if (!System.IO.File.Exists(fileMaster))
            //{
            //    bandedGridViewTaiSan.SaveLayoutToXml(fileMaster);
            //}
            //if (!System.IO.File.Exists(fileDetail))
            //{
            //    bandedGridViewTSKemTheo.SaveLayoutToXml(fileDetail);
            //}
            if (!System.IO.File.Exists(fileMaster))
            {
                gridViewTaiSan.SaveLayoutToXml(fileMaster);
            }
            if (!System.IO.File.Exists(fileDetail))
            {
                gridViewTaiSanKemTheo.SaveLayoutToXml(fileDetail);
            }
        }

        public void saveLayout()
        {
            String currentPath = Directory.GetCurrentDirectory();
            String path = Path.Combine(currentPath, "Layout");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            String fileMaster = path + "//" + fileName + "_Master_Current.xml";
            String fileDetail = path + "//" + fileName + "_Detail_Current.xml";
            //bandedGridViewTaiSan.SaveLayoutToXml(fileMaster);
            //bandedGridViewTSKemTheo.SaveLayoutToXml(fileDetail);
            gridViewTaiSan.SaveLayoutToXml(fileMaster);
            gridViewTaiSanKemTheo.SaveLayoutToXml(fileDetail);
        }

        public void loadLayout(bool Default = false)
        {
            String currentPath = Directory.GetCurrentDirectory();
            String path = Path.Combine(currentPath, "Layout");
            if (Directory.Exists(path))
            {
                String fileMaster = "";
                String fileDetail = "";
                if (Default)
                {
                    fileMaster = path + "//" + fileName + "_Master_Default.xml";
                    fileDetail = path + "//" + fileName + "_Detail_Default.xml";
                }
                else
                {
                    fileMaster = path + "//" + fileName + "_Master_Current.xml";
                    fileDetail = path + "//" + fileName + "_Detail_Current.xml";
                }
                //if (System.IO.File.Exists(fileMaster))
                //{
                //    bandedGridViewTaiSan.RestoreLayoutFromXml(fileMaster);
                //}
                //if (System.IO.File.Exists(fileDetail))
                //{
                //    bandedGridViewTSKemTheo.RestoreLayoutFromXml(fileDetail);
                //}
                if (System.IO.File.Exists(fileMaster))
                {
                    gridViewTaiSan.RestoreLayoutFromXml(fileMaster);
                }
                if (System.IO.File.Exists(fileDetail))
                {
                    gridViewTaiSanKemTheo.RestoreLayoutFromXml(fileDetail);
                }
            }
        }

        private void ucGridControlTaiSan_Leave(object sender, EventArgs e)
        {
            saveLayout();
        }

        private void ucGridControlTaiSan_Load(object sender, EventArgs e)
        {
            loadLayout();
        }


        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.ListSourceRow >= 0 && !String.IsNullOrEmpty(view.FindFilterText))
                {
                    String text = view.GetRowCellValue(e.ListSourceRow, colten).ToString();
                    String find = view.FindFilterText;
                    if (find.Equals(StringHelper.CoDauThanhKhongDau(find)))
                    {
                        if (StringHelper.CoDauThanhKhongDau(text.ToUpper()).Contains(StringHelper.CoDauThanhKhongDau(find.ToUpper())))
                        {
                            e.Visible = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Visible = false;
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (text.ToUpper().Contains(find.ToUpper()))
                        {
                            e.Visible = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Visible = false;
                            e.Handled = true;
                        }
                    }
                }
            }
            catch { };
        }

        private void gridViewTaiSan_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DevExpress.XtraGrid.Menu.GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                //Erasing the default menu items 
                foreach (DXMenuItem item in menu.Items)
                {
                    if (item.Caption.Equals("Show Find Panel"))
                    {
                        item.Visible = false;
                        break;
                    }
                }

            }
        }

        private void gridViewTaiSan_ColumnFilterChanged(object sender, EventArgs e)
        {
            gridViewTaiSan.ExpandAllGroups();
        }
    }
}
