using DevExpress.Web.ASPxTreeList;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSCD.DataFilter;

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
            if (!IsPostBack)
            {
                DevExpress.Web.ASPxTreeList.TreeListTextColumn _TreeListTextColumn = new DevExpress.Web.ASPxTreeList.TreeListTextColumn();
                _ucTreeViTri.Label_TenViTri.Text = "Đơn vị";
            }
        }
        public void LoadData()
        {
            listCTTaiSan = TSCD.Entities.CTTaiSan.getAll();
            if (listCTTaiSan.Count > 0)
            {
                infotr.Visible = true;
                listDonVi = TSCD.Entities.DonVi.getAll().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                if (listDonVi.Count > 0)
                {
                    _ucTreeViTri.CreateTreeList();
                    if (!IsPostBack)
                    {
                        TreeListDataColumn colloaidonvi = new TreeListDataColumn("loaidonvi.ten", "Loại đơn vị");
                        _ucTreeViTri.ASPxTreeList_ViTri.Columns.Add(colloaidonvi);

                    }
                    _ucTreeViTri.ASPxTreeList_ViTri.Settings.ShowColumnHeaders = true;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataSource = listDonVi;
                    _ucTreeViTri.ASPxTreeList_ViTri.DataBind();
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

                        DevExpress.Web.ASPxTreeList.TreeListNode node = _ucTreeViTri.ASPxTreeList_ViTri.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            _ucTreeViTri.FocusAndExpandToNode(node);
                            LoadFocusedNodeData();
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                        if (Request.QueryString["id"] != null)
                        {
                            ThongTinPhong.Visible = true;
                            thongtin.Visible = true;
                            idCTTaiSan = Guid.Empty;
                            try
                            {
                                idCTTaiSan = GUID.From(Request.QueryString["id"]);
                            }
                            catch
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }

                            objCTTaiSan = TSCD.Entities.CTTaiSan.getById(idCTTaiSan);
                            if (objCTTaiSan != null)
                            {
                                Label_ThongTin.Text = "Thông tin tài sản " + objCTTaiSan.taisan.ten;

                            }
                            else
                            {
                                Response.Redirect(Request.Url.AbsolutePath);
                            }
                        }
                        else
                        {
                            ClearData();
                        }
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
            else
            {
                KhongCoDuLieu.Visible = true;
                ucDanger_KhongCoDuLieu.LabelInfo.Text = "Chưa có đơn vị";
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
            //listCTTaiSan = TSCD.Entities.CTTaiSan.getQuery().Where(c => c.donviquanly_id == id || c.donvisudung_id == id).ToList();

            TSCD.Entities.DonVi objDonVi = TSCD.Entities.DonVi.getById(id);
            List<TaiSanHienThi> listCTTaiSan = TaiSanHienThi.Convert(objDonVi.getAllCTTaiSanRecursive());

            ASPxGridView.Styles.Header.HorizontalAlign = HorizontalAlign.Center;
            ASPxGridView.DataSource = listCTTaiSan;
            ASPxGridView.DataBind();
        }
        private void ClearData()
        {

        }
    }
}