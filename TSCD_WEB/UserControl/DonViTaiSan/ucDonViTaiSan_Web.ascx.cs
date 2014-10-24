using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxTreeList;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.DataFilter;
using TSCD.Entities;
using TSCD_WEB.UserControl.DangNhap;
namespace TSCD_WEB.UserControl.DonViTaiSan
{
    public partial class ucDonViTaiSan_Web : System.Web.UI.UserControl
    {
        public Guid idCTTaiSan = Guid.Empty;
        List<TSCD.Entities.DonVi> listDonVi = new List<TSCD.Entities.DonVi>();
        List<TSCD.Entities.CTTaiSan> listCTTaiSan = new List<TSCD.Entities.CTTaiSan>();
        public TSCD.Entities.CTTaiSan objCTTaiSan = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {
            if (Convert.ToString(Session["Username"]).Equals(String.Empty))
            {
                DangNhap.Visible = true;
            }
            else
            {
                DangNhap.Visible = false;
                listDonVi = Permission.getAll<TSCD.Entities.DonVi>(Permission._VIEW).OrderBy(c => c.ten).ToList();
                if (listDonVi.Count > 0)
                {
                    infotr.Visible = true;
                    _ucTreeViTri.CreateTreeList();
                    if (!IsPostBack)
                    {
                        TreeListTextColumn _TreeListTextColumn = new TreeListTextColumn();
                        _ucTreeViTri.Label_TenViTri.Text = "Danh sách đơn vị";

                        TreeListDataColumn colDonvi = new TreeListDataColumn("ten", "Đơn vị");
                        _ucTreeViTri.ASPxTreeList_ViTri.Columns.Add(colDonvi);
                        //TreeListDataColumn colloaidonvi = new TreeListDataColumn("loaidonvi.ten", "Loại đơn vị");
                        //_ucTreeViTri.ASPxTreeList_ViTri.Columns.Add(colloaidonvi);
                    }
                    //_ucTreeViTri.ASPxTreeList_ViTri.Settings.ShowColumnHeaders = true;
                    _ucTreeViTri.ASPxTreeList_ViTri.SettingsBehavior.ColumnResizeMode = ColumnResizeMode.Control;
                    _ucTreeViTri.ASPxTreeList_ViTri.Width = Unit.Percentage(100);
                    //_ucTreeViTri.ASPxTreeList_ViTri.Settings.GridLines = GridLines.Vertical;
                    //_ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.Mode = TreeListPagerMode.ShowPager;
                    //_ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.PageSize = 10;
                    //_ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.NextPageButton.Visible = false;
                    //_ucTreeViTri.ASPxTreeList_ViTri.SettingsPager.LastPageButton.Visible = false;

                    //_ucTreeViTri.ASPxTreeList_ViTri.Settings.ShowColumnHeaders = true;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listDonVi;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
                    if (Request.QueryString["key"] != null)
                    {
                        if (Session["DangMo"] != null)
                        {
                            LinkButton_ThuLai.Visible = true;
                            LinkButton_MoRa.Visible = false;
                            tdvitri.Visible = true;
                        }
                        else
                        {
                            LinkButton_ThuLai.Visible = false;
                            LinkButton_MoRa.Visible = true;
                            tdvitri.Visible = false;
                        }
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

                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            _ucTreeViTri.FocusAndExpandToNode(node);
                            LoadFocusedNodeData();
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    else
                    {
                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue("");
                        node.Focus();
                        ChuaChonViTri.Visible = true;
                        ucWarning_ChuaChon.LabelInfo.Text = "Chưa chọn đơn vị";
                        ClearData();
                    }
                }
                else
                {
                    KhongCoDuLieu.Visible = true;
                    ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có đơn vị";
                }
            }
        }

        private void LoadFocusedNodeData()
        {
            if (listDonVi.Count > 0)
            {
                if (_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode != null && GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    LoadDanhSachTaiSan(GUID.From(_ucTreeViTri.ASPxTreeList_ViTri.FocusedNode.GetValue("id")));
                    ClearData();
                }
                else
                    Response.Redirect(Request.Url.AbsolutePath);
            }
        }
        private void LoadDanhSachTaiSan(Guid id)
        {
            TSCD.Entities.DonVi objDonVi = TSCD.Entities.DonVi.getById(id);
            ucDonViTaiSan_BreadCrumb.Label_Ten.Text = objDonVi.ten;
            List<TaiSanHienThi> listCTTaiSan = TaiSanHienThi.Convert(objDonVi.getAllCTTaiSanRecursive());

            ASPxGridView.Styles.Header.HorizontalAlign = HorizontalAlign.Center;
            ASPxGridView.DataSource = listCTTaiSan;
            ASPxGridView.DataBind();
        }
        private void ClearData()
        {

        }

        protected void ASPxButton_Click(object sender, EventArgs e)
        {
            string[] values = "nuocsx;nguongoc;phong;vitri;dvquanly;dvsudung;ghichu".Split(';');
            foreach (string val in values)
            {
                ASPxGridView.Columns[val].Visible = false;
            }

            values = HiddenField.Value.Split(';');
            foreach (string val in values)
            {
                ASPxGridView.Columns[val].Visible = true;
            }
        }

        protected void LinkButton_ThuLai_Click(object sender, EventArgs e)
        {
            Session["DangMo"] = null;
            tdvitri.Visible = false;
            LinkButton_ThuLai.Visible = false;
            LinkButton_MoRa.Visible = true;
        }

        protected void LinkButton_MoRa_Click(object sender, EventArgs e)
        {
            Session["DangMo"] = 1;
            tdvitri.Visible = true;
            LinkButton_ThuLai.Visible = true;
            LinkButton_MoRa.Visible = false;
        }

        protected void LinkButton_Expand_Click(object sender, EventArgs e)
        {
            ASPxGridView.ExpandAll();
        }

        protected void LinkButton_Collapse_Click(object sender, EventArgs e)
        {
            ASPxGridView.CollapseAll();
        }
    }
}