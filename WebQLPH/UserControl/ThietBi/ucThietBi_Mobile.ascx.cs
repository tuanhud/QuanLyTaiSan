using DevExpress.Web.ASPxTreeList;
using QuanLyTaiSan.Entities;
using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace WebQLPH.UserControl.ThietBi
{
    public partial class ucThietBi_Mobile : System.Web.UI.UserControl
    {
        Guid idThietBi = Guid.Empty;
        string key = "";
        string p1 = "Thiết bị quản lý theo số lượng";
        string p2 = "Thiết bị quản lý theo cá thể";
        string c1 = "Thiết bị đang được sử dụng";
        string c2 = "Thiết bị chưa được sử dụng";

        List<QuanLyTaiSan.Entities.ThietBi> listThietBi = new List<QuanLyTaiSan.Entities.ThietBi>();
        QuanLyTaiSan.Entities.ThietBi objThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listThietBi = QuanLyTaiSan.Entities.ThietBi.getAll();
            if (listThietBi.Count > 0)
            {
                Panel_Chinh.Visible = true;
                CreateNode();
                if (Request.QueryString["key"] != null)
                {
                    try
                    {
                        key = Request.QueryString["key"].ToString();
                        DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ThietBi.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            node.Focus();
                            LoadFocusedNodeData();
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
                    LoadFocusedNodeData();
                }

                if (Request.QueryString["id"] != null)
                {
                    idThietBi = Guid.Empty;
                    try
                    {
                        idThietBi = GUID.From(Request.QueryString["id"]);
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                        return;
                    }
                    objThietBi = QuanLyTaiSan.Entities.ThietBi.getById(idThietBi);
                    if (objThietBi != null)
                    {
                        Panel_ThongTinObj.Visible = true;
                        Panel_TreeList.Visible = false;
                        Label_ThongTinThietBi.Text = "Thông tin " + objThietBi.ten;
                        Libraries.ImageHelper.LoadImageWeb(objThietBi.hinhanhs.ToList(), ASPxImageSlider_ThietBi);
                        Label_MaThietBi.Text = objThietBi.subId;
                        Session["TenThietBi"] = Label_TenThietBi.Text = objThietBi.ten;
                        Label_LoaiThietBi.Text = objThietBi.loaithietbi != null ? objThietBi.loaithietbi.ten : "";
                        Label_NgayMua.Text = objThietBi.ngaymua != null ? objThietBi.ngaymua.ToString() : "";
                        Label_MoTa.Text = Libraries.StringHelper.ConvertRNToBR(objThietBi.mota);
                    }
                    else
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
                Label_ThongBaoLoi.Text = "Chưa có thiết bị";
            }
        }

        private Boolean FindNodeTreeList(string key)
        {
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ThietBi.FindNodeByKeyValue(key);
            if (node != null)
            {
                node.Focus();
                return true;
            }
            return false;
        }

        public void CreateNode()
        {
            TreeListNode parent1 = ASPxTreeList_ThietBi.AppendNode(1);
            parent1.SetValue("id", 1);
            parent1.SetValue("name", p1);

            TreeListNode parent2 = ASPxTreeList_ThietBi.AppendNode(2);
            parent2.SetValue("id", 2);
            parent2.SetValue("name", p2);

            TreeListNode child1 = ASPxTreeList_ThietBi.AppendNode(3, parent2);
            child1.SetValue("id", 3);
            child1.SetValue("name", c1);

            TreeListNode child2 = ASPxTreeList_ThietBi.AppendNode(4, parent2);
            child2.SetValue("id", 4);
            child2.SetValue("name", c2);
            parent1.Focus();
        }

        private void LoadFocusedNodeData()
        {
            if (listThietBi.Count > 0)
            {
                if (ASPxTreeList_ThietBi.FocusedNode != null && ASPxTreeList_ThietBi.FocusedNode.GetValue("id") != null)
                {
                    try
                    {
                        LoadDanhSachThietBi(Convert.ToInt32(ASPxTreeList_ThietBi.FocusedNode.GetValue("id").ToString()));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void LoadDanhSachThietBi(int loai)
        {
            List<QuanLyTaiSan.Entities.ThietBi> list = null;
            switch (loai)
            {
                case 1:
                    list = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == true).ToList();
                    break;
                case 2:
                    list = QuanLyTaiSan.Entities.ThietBi.getQuery().Where(c => c.loaithietbi.loaichung == false).ToList();
                    break;
                case 3:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiHavePhong(false);
                    break;
                case 4:
                    list = QuanLyTaiSan.Entities.ThietBi.getAllByTypeLoaiNoPhong(false);
                    break;
                default:
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
            }
            var bind = list.Select(item => new
            {
                id = item.id,
                subid = item.subId,
                ten = item.ten,
                loaithietbi = item.loaithietbi != null ? item.loaithietbi.ten : "",
                url = Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "id", item.id.ToString()).ToString()
            }).ToList();
            CollectionPagerDanhSachThietBi.DataSource = bind;
            CollectionPagerDanhSachThietBi.BindToControl = RepeaterThietBi;
            RepeaterThietBi.DataSource = CollectionPagerDanhSachThietBi.DataSourcePaged;
            RepeaterThietBi.DataBind();
        }

        protected void ASPxTreeList_ThietBi_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_ThietBi.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?key=" + key;
            else
                e.Result = Request.Url.AbsolutePath;
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            if (!key.Equals(""))
                Response.Redirect(Libraries.StringHelper.AddParameter(new Uri(Request.Url.AbsoluteUri), "key", key, new List<string>(new string[] { "id" })).ToString());
            else
                Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}