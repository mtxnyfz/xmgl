using AppBox;
using FineUI;
using Maticsoft.DBUtility;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace XMGL.Web.admin
{
    public partial class XXGL_XMGL : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
                string userid = pb.GetIdentityId();
                string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string xxdm = "", xxmc = "";
                if (sdr.Read())
                {
                    xxdm = sdr["xxdm"].ToString().Trim();
                    ViewState["xxdm"] = xxdm;
                }
                sdr.Dispose();
            }
        }

        protected void databind()
        {
            string sqlstr = string.Format("SELECT dbo.XXGLPT_XM.ID, dbo.XXGLPT_XM.XMBH, dbo.XXGLPT_XM.XMMC, dbo.XXGLPT_XM.JFYS_ZXJF, dbo.XXGLPT_XM.JFYS_XXPTJF, dbo.XMFJ.XMYSMXWJM, dbo.XXGLPT_XM.SFSC, dbo.XXGLPT_XM.ZT, dbo.XXGLPT_XM.User_Uid FROM dbo.XXGLPT_XM LEFT JOIN dbo.XMFJ ON dbo.XXGLPT_XM.XMBH = dbo.XMFJ.XMBH WHERE User_Uid = '{0}' AND SFSC != 1", pb.GetIdentityId());
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;

            if (lb.Text.Trim() == "1")
                lb.Text = "未提交";
            else if (lb.Text.Trim() == "2")
                lb.Text = "院校审核中";
            else if (lb.Text.Trim() == "3")
                lb.Text = "市教委审核中";
            else if (lb.Text.Trim() == "4")
                lb.Text = "院校退回";
            else if (lb.Text.Trim() == "5")
                lb.Text = "评审中";
            else if (lb.Text.Trim() == "6")
                lb.Text = "市教委退回";
            else if (lb.Text.Trim() == "7")
                lb.Text = "评审通过";
            else if (lb.Text.Trim() == "8")
                lb.Text = "评审未通过";
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);
            string xmbh = values[1].ToString().Trim();
            string zt = values[2].ToString().Trim();
            string selectedID = values[0].ToString().Trim();
            if (e.CommandName == "xq")
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();

                var list = wordBll.GetModelList("XMBH = '" + xmbh + "'");
                if (list.Count > 0)
                {
                    var service = ConfigurationManager.AppSettings["OfficeWebAppsServiceIp"];
                    var server = ConfigurationManager.AppSettings["OfficeWebAppsServerIp"];

                    var str = "http://" + server + "/wv/wordviewerframe.aspx?WOPISrc=http://" + service + "/wopi/files/" + xmbh + "?access_token=" + Guid.NewGuid() + "";
                    PageContext.RegisterStartupScript(Window1.GetShowReference(str, "查看申报书") + Window1.GetMaximizeReference());
                }
            }
            else if (e.CommandName == "up")
            {
                if (zt == "1" || zt == "4" || zt == "6")
                {
                    PageContext.RegisterStartupScript(Window1.GetShowReference("XXGL_XMGL_Edit.aspx?id=" + selectedID, "修改申报书") + Window1.GetMaximizeReference());
                }
                else
                {

                    Alert.Show("该项目已经提交，无法修改");
                }
            }

            else if (e.CommandName == "tj")
            {
                if (zt == "1" || zt == "4" || zt == "6")
                {
                    string sqlstr = "update XXGLPT_XM set ZT=2 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {

                    Alert.Show("该项目已经提交，无需重复提交");
                }
            }

            else if (e.CommandName == "del")
            {
                if (zt == "1")
                {
                    string sqlstr = "update XXGLPT_XM set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {
                    Alert.Show("该项目已经提交，无法删除");
                }
            }
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            databind();
            Alert.ShowInTop("操作成功！");
        }
    }
}