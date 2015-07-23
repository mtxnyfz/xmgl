using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using ExcelHelp;
using System.Data.SqlClient;
using System.Data;
using AppBox;
using System.Web.Security;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Maticsoft.DBUtility;
using Aspose.Cells;
using XMGL.BLL;

namespace XMGL.Web.admin
{
    public partial class JSJNJS_XMGL_YXGL : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                string userid = pb.GetIdentityId();
                string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string xxdm = "", xxmc = "";
                if (sdr.Read())
                {
                    xxdm = sdr["xxdm"].ToString().Trim();
                    ViewState["xxdm"] = xxdm;
                    xxmc = sdr["xxmc"].ToString().Trim();
                    ViewState["xxmc"] = xxmc;
                }
                sdr.Dispose();
                databind();
            }
        }

        protected void databind()
        {
            string sqlstr = "SELECT dbo.JSJNJS_XM.ID, dbo.JSJNJS_XM.XMBH, dbo.JSJNJS_XM.XMMC, dbo.JSJNJS_XM.JFYS_ZXJF, dbo.JSJNJS_XM.JFYS_XXPTJF, dbo.XMFJ.XMYSMXWJM, dbo.JSJNJS_XM.SFSC, dbo.JSJNJS_XM.ZT, dbo.JSJNJS_XM.User_Uid FROM dbo.JSJNJS_XM LEFT JOIN dbo.XMFJ ON dbo.JSJNJS_XM.XMBH = dbo.XMFJ.XMBH WHERE  SFSC != 1 and ZT>=2 and DWMC='" + ViewState["xxmc"].ToString() + "'";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();

        }
        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            databind();
            Alert.ShowInTop("操作成功！");
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
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

            else if (e.CommandName == "tj")
            {
                if (Convert.ToInt32(zt) == 2 || Convert.ToInt32(zt) == 4 || Convert.ToInt32(zt) == 6)
                {
                    string sqlstr = "update JSJNJS_XM set ZT=3 where ID=" + Convert.ToInt32(selectedID);
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

            else if (e.CommandName == "th")
            {
                if (Convert.ToInt32(zt) == 2)
                {
                    string sqlstr = "update JSJNJS_XM set ZT=4 where ID=" + Convert.ToInt32(selectedID);
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

                    Alert.Show("项目已提交或审核，无法退回");
                }
            }
        }
        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
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
    }
}