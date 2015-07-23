using AppBox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XMGL.Web.Code;

namespace XMGL.Web.admin.Savant
{
    public partial class Savant_List : PageBase
    {
        PageBase1 pb = new PageBase1();
        Model.XMGL_ZJB zjb_model = new Model.XMGL_ZJB();
        BLL.XMGL_ZJB zjb_bll = new BLL.XMGL_ZJB();

        Model.XMGL_ZJLXB zjlx_model = new Model.XMGL_ZJLXB();
        BLL.XMGL_ZJLXB zjlx_bll = new BLL.XMGL_ZJLXB();

        Model.XMGL_ZJLYB zjly_model = new Model.XMGL_ZJLYB();
        BLL.XMGL_ZJLYB zjly_bll = new BLL.XMGL_ZJLYB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("至少选择一项！");
                btnNew.OnClientClick = Window1.GetShowReference("Savant_Add.aspx", "新增专家信息");
                BindGrid("");
                LXBind();
                LYBind();
            }
        }

        #region BindGrid

        private void BindGrid(string strWhere)
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = GetTotalCount(strWhere);

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(strWhere);

            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount(string strWhere)
        {
            if (string.IsNullOrEmpty(strWhere))
                return zjb_bll.GetList(" Experts_Mode=1").Tables[0].Rows.Count;
            else
                return zjb_bll.GetList(" Experts_Mode=1" + strWhere).Tables[0].Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(string strWhere)
        {
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataTable table2 = zjb_bll.GetList(" Experts_Mode=1").Tables[0];
            if (!string.IsNullOrEmpty(strWhere))
            {
                table2 = zjb_bll.GetList(" Experts_Mode=1" + strWhere).Tables[0];
            }
            DataView view2 = table2.DefaultView;
            view2.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable table = view2.ToTable();

            DataTable paged = table.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > table.Rows.Count)
            {
                rowend = table.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(table.Rows[i]);
            }

            return paged;
        }

        #endregion

        #region Events

        protected void Button1_Click(object sender, EventArgs e)
        {
            //labResult.Text = HowManyRowsAreSelected(Grid1);
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            if (ViewState["strWhere"] != null)
                BindGrid(ViewState["strWhere"].ToString());
            else
                BindGrid("");
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;

            if (ViewState["strWhere"] != null)
                BindGrid(ViewState["strWhere"].ToString());
            else
                BindGrid("");
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            if (ViewState["strWhere"] != null)
                BindGrid(ViewState["strWhere"].ToString());
            else
                BindGrid("");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                int _id = int.Parse(Grid1.DataKeys[row][0].ToString());
                zjb_model = zjb_bll.GetModel(_id);
                zjb_model.Experts_Mode = 0;
                zjb_model.Experts_OPDID = pb.GetIdentityId();
                zjb_model.Experts_OPDTIME = DateTime.Now;
                zjb_bll.Update(zjb_model);
            }
        }
        
        //筛选查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (Experts_ZJLX.SelectedValue.Trim() != "-1")
            {
                strWhere = " and Experts_ZJLX='" + Experts_ZJLX.SelectedValue.Trim() + "'";
            }
            if (Experts_ZJLY.SelectedValue.Trim() != "-1")
            {
                strWhere += " and Experts_ZJLY='" + Experts_ZJLY.SelectedValue.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Experts_Name.Text.Trim()))
            {
                strWhere += " and Experts_Name like'%" + Experts_Name.Text.Trim() + "%'";
            }
            BindGrid(strWhere);
            ViewState["strWhere"] = strWhere;
        }
        #endregion

        //获取专家类型
        public string GetZJLX(int _id)
        {
            zjlx_model = zjlx_bll.GetModel(_id);
            return zjlx_model.ZJLX_Name;
        }

        //获取专家来源
        public string GetZJLY(int _id)
        {
            zjly_model = zjly_bll.GetModel(_id);
            return zjly_model.ZJLY_Name;
        }
        //绑定专家类型
        private void LXBind()
        {
            DataTable dt = zjlx_bll.GetList(" ZJLX_Mode=1").Tables[0];
            Experts_ZJLX.DataTextField = "ZJLX_Name";
            Experts_ZJLX.DataValueField = "ZJLX_ID";
            Experts_ZJLX.DataSource = dt;
            Experts_ZJLX.DataBind();
            Experts_ZJLX.Items.Insert(0, new FineUI.ListItem("-请选择专家类型-", "-1"));
            Experts_ZJLX.SelectedValue = "-1";
        }

        //绑定专家来源
        private void LYBind()
        {
            DataTable dt = zjly_bll.GetList(" ZJLY_Mode=1").Tables[0];
            Experts_ZJLY.DataTextField = "ZJLY_Name";
            Experts_ZJLY.DataValueField = "ZJLY_ID";
            Experts_ZJLY.DataSource = dt;
            Experts_ZJLY.DataBind();
            Experts_ZJLY.Items.Insert(0, new FineUI.ListItem("-请选择专家来源-", "-1"));
            Experts_ZJLY.SelectedValue = "-1";
        }


        //protected string GetEditUrl(object id)
        //{
        //    return Window1.GetShowReference("Savant_Modify.aspx?id=" + id);
        //}

        //protected string GetViewUrl(object id)
        //{
        //    return Window1.GetShowReference("Savant_Show.aspx?id=" + id);
        //}

    }
}