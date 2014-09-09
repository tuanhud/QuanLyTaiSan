using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace PTB_WEB.UserControl.LoaiThietBis
{
    public partial class ucLoaiThietBi_Mobile : System.Web.UI.UserControl
    {
        List<QuanLyTaiSan.Entities.LoaiThietBi> listLoaiThietBi = new List<QuanLyTaiSan.Entities.LoaiThietBi>();
        QuanLyTaiSan.Entities.LoaiThietBi objLoaiThietBi = null;
        string key = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listLoaiThietBi = QuanLyTaiSan.Entities.LoaiThietBi.getAll();
            if (listLoaiThietBi.Count > 0)
            {
                ASPxTreeList_LoaiThietBi.DataSource = listLoaiThietBi;
                ASPxTreeList_LoaiThietBi.DataBind();
                SearchFunction();
                Panel_Chinh.Visible = true;
                if (Request.QueryString["key"] != null)
                {
                    try
                    {
                        key = Request.QueryString["key"].ToString();
                        DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_LoaiThietBi.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            node.Focus();
                            LoadFocusedNodeData();
                            Panel_ThongTinObj.Visible = true;
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    Panel_TreeList.Visible = true;
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có loại thiết bị";
            }
        }

        private void LoadDataObj(Guid id)
        {
            objLoaiThietBi = QuanLyTaiSan.Entities.LoaiThietBi.getById(id);
            if (objLoaiThietBi != null)
            {
                Label_ThongTin.Text = string.Format("Thông tin {0}", objLoaiThietBi.ten);
                ucLoaiThietBi_BreadCrumb.Label_TenLoaiThietBi.Text = Label_TenLoai.Text = objLoaiThietBi.ten;
                Label_KieuQuanLy.Text = objLoaiThietBi.loaichung == true ? "Theo số lượng" : "Theo cá thể";
                Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objLoaiThietBi.mota);
                Label_Thuoc.Text = objLoaiThietBi.parent_id.Equals(null) ? "[Không thuộc loại nào]" : objLoaiThietBi.parent.ten;
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadFocusedNodeData()
        {
            if (listLoaiThietBi.Count > 0)
            {
                if (ASPxTreeList_LoaiThietBi.FocusedNode != null && GUID.From(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    LoadDataObj(GUID.From(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")));
                }
            }
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void ASPxTreeList_LoaiThietBi_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_LoaiThietBi.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?key=" + key;
            else
                e.Result = Request.Url.AbsolutePath;
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
                DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_LoaiThietBi.GetAllNodes().Where(item => Object.Equals(item.GetValue("id").ToString(), SearchID.ToString())).FirstOrDefault();
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