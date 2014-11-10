using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxTreeList;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB.UserControl.LoaiTaiSan
{
    public partial class ucLoaiTaiSan_Web : System.Web.UI.UserControl
    {
        List<TSCD.Entities.LoaiTaiSan> listLoaiTaiSan = new List<TSCD.Entities.LoaiTaiSan>();
        TSCD.Entities.LoaiTaiSan objLoaiTaiSan = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucTreeViTri.Label_TenViTri.Text = "Loại tài sản";
            }
        }
        public void LoadData()
        {
            listLoaiTaiSan = TSCD.Entities.LoaiTaiSan.getAll();

            if (listLoaiTaiSan.Count > 0)
            {
                infotr.Visible = true;
                ucTreeViTri.CreateTreeList();
                //if (!IsPostBack)
                //{
                //    //TreeListDataColumn coldonvitinh = new TreeListDataColumn("donvitinh.ten", "Đơn vị tính");
                //    //ucTreeViTri.ASPxTreeList_ViTri.Columns.Add(coldonvitinh);

                //    //TreeListCheckColumn colloaitaisanhuuhinh = new TreeListCheckColumn();
                //    //colloaitaisanhuuhinh.FieldName = "huuhinh";
                //    //colloaitaisanhuuhinh.Caption = "Loại tài sản hữu hình";
                //    //ucTreeViTri.ASPxTreeList_ViTri.Columns.Add(colloaitaisanhuuhinh);
                //}
                //ucTreeViTri.ASPxTreeList_ViTri.Settings.ShowColumnHeaders = true;
                //ucTreeViTri.ASPxTreeList_ViTri.SettingsBehavior.ColumnResizeMode = ColumnResizeMode.Control;
                //ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.Mode = TreeListPagerMode.ShowPager;
                //ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.PageSize = 10;
                //ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.NextPageButton.Visible = false;
                //ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.LastPageButton.Visible = false;

                ucTreeViTri.ASPxTreeList_ViTri.DataSource = listLoaiTaiSan;
                ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                SearchFunction();
                ClearData();
                if (Request.QueryString["key"] != null)
                {
                    infotd.Visible = true;
                    string key = "";
                    try
                    {
                        key = Request.QueryString["key"].ToString();
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                    if (node != null)
                    {
                        ucTreeViTri.FocusAndExpandToNode(node);
                        LoadFocusedNodeData();
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    ChuaChon.Visible = true;
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                    node.Focus();
                    ucWarning_ChuaChon.LabelInfo.Text = "Chưa chọn loại tài sản";
                }
            }
            else
            {
                KhongCoDuLieu.Visible = true;
                ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có loại tài sản";
            }
        }

        private void ClearData()
        {
            Label_ThongTin.Text = "Thông tin";
            Label_Ma.Text = "";
            Label_Ten.Text = "";
            Label_DonViTinh.Text = "";
            Label_Thuoc.Text = "";
            Label_MoTa.Text = "";
        }
        private void LoadDataObj(Guid id)
        {
            objLoaiTaiSan = TSCD.Entities.LoaiTaiSan.getById(id);
            if (objLoaiTaiSan != null)
            {
                Label_ThongTin.Text = string.Format("Thông tin {0}", objLoaiTaiSan.ten);
                Label_Ma.Text = objLoaiTaiSan.subId;
                ucLoaiTaiSan_BreadCrumb.Label_Ten.Text = Label_Ten.Text = objLoaiTaiSan.ten;
                Label_DonViTinh.Text = objLoaiTaiSan.donvitinh == null ? "[Chưa có đơn vị]" : objLoaiTaiSan.donvitinh.ten;
                Label_Loai.Text = objLoaiTaiSan.huuhinh == true ? "Loại tài sản hữu hình" : "Loại tài sản vô hình";
                Label_Thuoc.Text = objLoaiTaiSan.parent == null ? "[Không thuộc loại nào]" : objLoaiTaiSan.parent.ten;
                Label_MoTa.Text = StringHelper.ConvertRNToBR(objLoaiTaiSan.mota);
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadFocusedNodeData()
        {
            if (listLoaiTaiSan.Count > 0)
            {
                if (ucTreeViTri.ASPxTreeList_ViTri.FocusedNode != null && GUID.From(ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    LoadDataObj(GUID.From(ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")));
                }
            }
        }

        private void SearchFunction()
        {
            if (Request.QueryString["Search"] != null)
            {
                Guid SearchID = Guid.Empty;
                try
                {
                    SearchID = GUID.From(Request.QueryString["Search"]);
                }
                catch
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                }
                DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.GetAllNodes().Where(item => Object.Equals(item.GetValue("id").ToString(), SearchID.ToString())).FirstOrDefault();
                if (node != null)
                {
                    Response.Redirect(string.Format("{0}?key={1}", Request.Url.AbsolutePath, node.Key.ToString()));
                }
                else
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                }
            }
            else
            {
                return;
            }
        }
    }
}