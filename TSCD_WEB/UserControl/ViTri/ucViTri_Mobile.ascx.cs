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
    public partial class ucViTri_Mobile : System.Web.UI.UserControl
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
                ucTreeViTri.CreateTreeList();
                ucTreeViTri.ASPxTreeList_ViTri.DataSource = listViTriHienThi;
                ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                SearchFunction();
                treevitri.Visible = true;
                if (Request.QueryString["key"] != null)
                {
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
                        node.Focus();
                        ucTreeViTri.FocusAndExpandToNode(node);
                        Guid id = GUID.From(node.GetValue("id"));
                        string type = node.GetValue("loai").ToString();
                        if (type.Equals(typeof(CoSo).Name))
                        {
                            objCoSo = CoSo.getById(id);
                            if (objCoSo != null)
                            {
                                info.Visible = true;
                                Label_ThongTin.Text = "Thông tin " + objCoSo.ten;
                                Label_Ten.Text = objCoSo.ten;
                                ucViTri_BreadCrumb.Label_TenViTri.Text = Label_Ten.Text = objCoSo.ten;
                                Label_Thuoc.Text = "[Đại học Sài Gòn]";
                                Label_MoTa.Text = StringHelper.ConvertRNToBR(objCoSo.mota);
                            }
                            else
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                        }
                        else if (type.Equals(typeof(Dayy).Name))
                        {
                            objDay = Dayy.getById(id);
                            if (objDay != null)
                            {
                                info.Visible = true;
                                Label_ThongTin.Text = "Thông tin " + objDay.ten;
                                Label_Ten.Text = objDay.ten;
                                Label_Thuoc.Text = objDay.coso != null ? objDay.coso.ten : "[Cơ sở]";
                                ucViTri_BreadCrumb.Label_TenViTri.Text = string.Format("{0} ({1})", Label_Ten.Text, Label_Thuoc.Text);
                                Label_MoTa.Text = StringHelper.ConvertRNToBR(objDay.mota);
                            }
                            else
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                        }
                        else if (type.Equals(typeof(Tang).Name))
                        {
                            objTang = Tang.getById(id);
                            if (objTang != null)
                            {
                                info.Visible = true;
                                Label_ThongTin.Text = "Thông tin " + objTang.ten;
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
                        }
                        else
                        {
                            Response.Redirect(Request.Url.AbsolutePath);
                        }
                    }
                    else
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                    node.Focus();
                }
            }
            else
            {
                thongbaoloi.Visible = true;
                ucDanger.LabelInfo.Text = "Chưa có vị trí";
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