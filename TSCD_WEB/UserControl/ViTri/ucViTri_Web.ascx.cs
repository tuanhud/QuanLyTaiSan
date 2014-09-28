using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.DataFilter;
using TSCD.Entities;

namespace TSCD_WEB.UserControl.ViTri
{
    public partial class ucViTri_Web : System.Web.UI.UserControl
    {
        List<ViTriHienThi> listViTriHienThi = new List<ViTriHienThi>();
        CoSo objCoSo = null;
        Dayy objDay = null;
        Tang objTang = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucTreeViTri.Label_TenViTri.Text = "Vị Trí";
            }
        }
        public void LoadData()
        {
            listViTriHienThi = ViTriHienThi.getAll();

            if (listViTriHienThi.Count > 0)
            {
                infotr.Visible = true;
                ucTreeViTri.CreateTreeList();
                ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
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
                    ChuaChonViTri.Visible = true;
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                    node.Focus();
                    ucWarning_ChuaChonViTri.LabelInfo.Text = "Chưa chọn vị trí";
                }
            }
            else
            {
                KhongCoDuLieu.Visible = true;
                ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có vị trí";
            }
        }

        private void ClearData()
        {
            Label_ThongTin.Text = "Thông tin";
            Label_Ten.Text = "";
            Label_Thuoc.Text = "";
            Label_MoTa.Text = "";
        }
        private void LoadDataObj(Guid id, int type)
        {
            switch (type)
            {
                case 1:
                    objCoSo = CoSo.getById(id);
                    if (objCoSo != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objCoSo.ten);
                        ucViTri_BreadCrumb.Label_TenViTri.Text = Label_Ten.Text = objCoSo.ten;
                        Label_Thuoc.Text = "[Đại học Sài Gòn]";
                        Label_MoTa.Text = StringHelper.ConvertRNToBR(objCoSo.mota);
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    break;
                case 2:
                    objDay = Dayy.getById(id);
                    if (objDay != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objDay.ten);
                        Label_Ten.Text = objDay.ten;
                        Label_Thuoc.Text = objDay.coso != null ? objDay.coso.ten : "[Cơ sở]";
                        ucViTri_BreadCrumb.Label_TenViTri.Text = string.Format("{0} ({1})", Label_Ten.Text, Label_Thuoc.Text);
                        Label_MoTa.Text = StringHelper.ConvertRNToBR(objDay.mota);
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    break;
                case 3:
                    objTang = Tang.getById(id);
                    if (objTang != null)
                    {
                        Label_ThongTin.Text = string.Format("Thông tin {0}", objTang.ten);
                        Label_Ten.Text = objTang.ten;
                        if (objTang.day != null)
                        {
                            if (objTang.day.coso != null)
                            {
                                Label_Thuoc.Text = objTang.day.coso.ten + " - " + objTang.day.ten;
                            }
                            else
                            {
                                Label_Thuoc.Text = "[Cơ sở] - " + objTang.day.ten;
                            }
                        }
                        else
                        {
                            Label_Thuoc.Text = "[Cơ sở] - [Dãy]";
                        }
                        ucViTri_BreadCrumb.Label_TenViTri.Text = string.Format("{0} ({1})", Label_Ten.Text, Label_Thuoc.Text);
                        Label_MoTa.Text = StringHelper.ConvertRNToBR(objTang.mota);
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
            }
        }

        private void LoadFocusedNodeData()
        {
            if (listViTriHienThi.Count > 0)
            {
                if (ucTreeViTri.ASPxTreeList_ViTri.FocusedNode != null && ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai") != null && GUID.From(ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    if (ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(CoSo).Name))
                    {
                        LoadDataObj(GUID.From(ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 1);
                    }
                    else if (ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Dayy).Name))
                    {
                        LoadDataObj(GUID.From(ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 2);
                    }
                    else if (ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("loai").ToString().Equals(typeof(Tang).Name))
                    {
                        LoadDataObj(GUID.From(ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")), 3);
                    }
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