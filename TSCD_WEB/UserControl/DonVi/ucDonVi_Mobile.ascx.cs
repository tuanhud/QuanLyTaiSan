using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSCD_WEB.UserControl.DonVi
{
    public partial class ucDonVi_Mobile : System.Web.UI.UserControl
    {
        List<TSCD.Entities.DonVi> listDonVi = new List<TSCD.Entities.DonVi>();
        TSCD.Entities.DonVi objDonVi = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucTreeViTri.Label_TenViTri.Text = "Đơn vị";
            }
        }

        public void LoadData()
        {
            listDonVi = TSCD.Entities.DonVi.getAll();
            if (listDonVi.Count > 0)
            {
                ucTreeViTri.CreateTreeList();
                ucTreeViTri.ASPxTreeList_ViTri.DataSource = listDonVi;
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
                        objDonVi = TSCD.Entities.DonVi.getById(id);
                        if (objDonVi != null)
                        {
                            info.Visible = true;
                            Label_ThongTin.Text = string.Format("Thông tin {0}", objDonVi.ten);
                            Label_Ma.Text = objDonVi.subId;
                            ucDonVi_BreadCrumb.Label_TenDonVi.Text = Label_Ten.Text = objDonVi.ten;
                            Label_Loai.Text = objDonVi.loaidonvi.ten;
                            Label_Thuoc.Text = objDonVi.parent == null ? "[Đại học Sài Gòn]" : objDonVi.parent.ten;
                            Label_MoTa.Text = StringHelper.ConvertRNToBR(objDonVi.mota);
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
                ucDanger.LabelInfo.Text = "Chưa có đơn vị";
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