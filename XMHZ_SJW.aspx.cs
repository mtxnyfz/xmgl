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

namespace XMGL.Web.admin
{
    public partial class XMHZ_SJW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid1_databind();
            }
        }

        protected void Grid1_databind()
        {
            string sqlstr = "select '一流专业建设' as xmldmc, count(XMBH) as sbs,sum(SQZXJF) as SQZXJF,sum(SQZXJF) as sjwrdje,sum(XXPTJF) as XXPTJF from YLZY where  SFSC!=1  and ZT>=3 and ZT!=4 and ZT!=6";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected void Grid2_databind()
        {
            string sqlstr = "select a.sbs,a.SQZXJF, a.sjwrdje,a.XXPTJF,b.XXMC,b.XXDM from (select XXDM,  count(XMBH) as sbs,sum(SQZXJF) as SQZXJF,sum(SQZXJF) as sjwrdje,sum(XXPTJF) as XXPTJF from YLZY where  SFSC!=1  and ZT>=3 and ZT!=4 and ZT!=6  group by XXDM) as a,XXJBQKB as b where a.XXDM=b.XXDM";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid2.DataSource = dt;
            Grid2.DataBind();
        }

        protected void Grid3_databind(string xxdm)
        {
            //string sqlstr = "select XMBH,XMMC,SQZXJF,SQZXJF,SQZXJFKCJCJF,SQZXJFSZPXJF,SQZXJFYQSBJF,SQZXJFWPRYJF,SQZXJFYWF, XXPTJF,XXPTJFKCJCJF,XXPTJFSZPXJF,XXPTJFSBHCJF,XXPTJFWPRYJF,XXPTJFYWF from YLZY where XXDM='" + xxdm + "' and    SFSC!=1  and ZT>=3 and ZT!=4 and ZT!=6";
            string sqlstr = "select XMBH,XMMC,SQZXJF,SQZXJF, XXPTJF,'' as 'NF','' as 'SQZXJFJFGSHJ','' as 'SQZXJFKCJCJF','' as 'SQZXJFSZPXJF','' as 'SQZXJFWPRYJF','' as 'SQZXJFYQSBJF','' as 'SQZXJFYWF' ,'' as 'XXPTJFJFGSHJ','' as 'XXPTJFKCJCJF','' as 'XXPTJFSZPXJF','' as 'XXPTJFWPRYJF','' as 'XXPTJFYQSBJF','' as 'XXPTJFYWF' from YLZY where XXDM='" + xxdm + "' and    SFSC!=1  and ZT>=3 and ZT!=4 and ZT!=6";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            DataTable dt_mx = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sqlstr = "select * from JFYS where XMBH='" + dt.Rows[i]["XMBH"].ToString().Trim() + "'";
                dt_mx = DbHelperSQL.Query(sqlstr).Tables[0];
                
                for (int j = 0; j < dt_mx.Rows.Count; j++)
                {
                    dt.Rows[i]["NF"] = dt.Rows[i]["NF"].ToString() + dt_mx.Rows[j]["NF"] + "<br>";
                    dt.Rows[i]["SQZXJFJFGSHJ"] = dt.Rows[i]["SQZXJFJFGSHJ"].ToString() + dt_mx.Rows[j]["SQZXJFJFGSHJ"] + "<br>";
                    dt.Rows[i]["SQZXJFKCJCJF"] = dt.Rows[i]["SQZXJFKCJCJF"].ToString() +  dt_mx.Rows[j]["SQZXJFKCJCJF"] + "<br>";
                    dt.Rows[i]["SQZXJFSZPXJF"] = dt.Rows[i]["SQZXJFSZPXJF"].ToString() +  dt_mx.Rows[j]["SQZXJFSZPXJF"] + "<br>";
                    dt.Rows[i]["SQZXJFWPRYJF"] = dt.Rows[i]["SQZXJFWPRYJF"].ToString() + dt_mx.Rows[j]["SQZXJFWPRYJF"] + "<br>";
                    dt.Rows[i]["SQZXJFYQSBJF"] = dt.Rows[i]["SQZXJFYQSBJF"].ToString() + dt_mx.Rows[j]["SQZXJFYQSBJF"] + "<br>";
                    dt.Rows[i]["SQZXJFYWF"] = dt.Rows[i]["SQZXJFYWF"].ToString() + dt_mx.Rows[j]["SQZXJFYWF"] + "<br>";


                    dt.Rows[i]["XXPTJFJFGSHJ"] = dt.Rows[i]["XXPTJFJFGSHJ"].ToString() + dt_mx.Rows[j]["XXPTJFJFGSHJ"] + "<br>";
                    dt.Rows[i]["XXPTJFKCJCJF"] = dt.Rows[i]["XXPTJFKCJCJF"].ToString() + dt_mx.Rows[j]["XXPTJFKCJCJF"] + "<br>";
                    dt.Rows[i]["XXPTJFSZPXJF"] = dt.Rows[i]["XXPTJFSZPXJF"].ToString() + dt_mx.Rows[j]["XXPTJFSZPXJF"] + "<br>";
                    dt.Rows[i]["XXPTJFWPRYJF"] = dt.Rows[i]["XXPTJFWPRYJF"].ToString() + dt_mx.Rows[j]["XXPTJFWPRYJF"] + "<br>";
                    dt.Rows[i]["XXPTJFYQSBJF"] = dt.Rows[i]["XXPTJFYQSBJF"].ToString() + dt_mx.Rows[j]["XXPTJFYQSBJF"] + "<br>";
                    dt.Rows[i]["XXPTJFYWF"] = dt.Rows[i]["XXPTJFYWF"].ToString() + dt_mx.Rows[j]["XXPTJFYWF"] + "<br>";
                }
            }

                Grid3.DataSource = dt;
            Grid3.DataBind();
        }


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);



            if (e.CommandName == "xq")
            {
                Grid2_databind();
                Panel2.Title = values[0].ToString();
                //string sqlstr = "delete jfsyqk where Id=" + id;
                //int state = DataExecute.ExecuteNonQuery(DataExecute.CONN_DataSTRING, CommandType.Text, sqlstr);
                //if (state != 0)
                //{
                   
                //    Alert.Show("删除成功！", "提示", Alert.DefaultMessageBoxIcon);
                //}
                //else
                //{
                //    Alert.Show("删除失败！", "提示", Alert.DefaultMessageBoxIcon);
                //    return;
                //}
            }
        }

        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid2.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);



            if (e.CommandName == "xq")
            {
                Grid3_databind(values[0].ToString().Trim());
                Panel3.Title = values[1].ToString();
                //string sqlstr = "delete jfsyqk where Id=" + id;
                //int state = DataExecute.ExecuteNonQuery(DataExecute.CONN_DataSTRING, CommandType.Text, sqlstr);
                //if (state != 0)
                //{

                //    Alert.Show("删除成功！", "提示", Alert.DefaultMessageBoxIcon);
                //}
                //else
                //{
                //    Alert.Show("删除失败！", "提示", Alert.DefaultMessageBoxIcon);
                //    return;
                //}
            }
        }


        protected void Grid3_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid3.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);



            if (e.CommandName == "xq")
            {
               string xmbh = values[0].ToString();
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
        }

    }
}