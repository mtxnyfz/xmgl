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
using ExcelHelp;

namespace XMGL.Web.admin
{
    public partial class XMGL_JXBW : System.Web.UI.Page
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

            string sqlstr = "";
            DataTable dt = null;


            sqlstr = "  select * from JXBW where user_uid='" + pb.GetIdentityId() + "' and SFSC!=1";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            string[] arr = null;
             string tempstr="";;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                arr = dt.Rows[i]["WORD1"].ToString().Split('|');
                tempstr="";
                for (int j = 0; j < arr.Length; j++)
                {
                    if(j!=arr.Length-1)
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";
                    //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                }
                dt.Rows[i]["WORD1"]=tempstr;

                arr = dt.Rows[i]["WORD2"].ToString().Split('|');
                tempstr="";
                for (int j = 0; j < arr.Length; j++)
                {
                    if(j!=arr.Length-1)
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";
                    //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                }
                dt.Rows[i]["WORD2"] = tempstr;

                arr = dt.Rows[i]["WORD3"].ToString().Split('|');
                tempstr = "";
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != arr.Length - 1)
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";
                    //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                }
                dt.Rows[i]["WORD3"] = tempstr;

                arr = dt.Rows[i]["WORD4"].ToString().Split('|');
                tempstr = "";
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != arr.Length - 1)
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";
                    //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                }
                dt.Rows[i]["WORD4"] = tempstr;


                arr = dt.Rows[i]["SP1"].ToString().Split('|');
                tempstr = "";
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != arr.Length - 1)
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";
                   
                }
                dt.Rows[i]["SP1"] = tempstr;

                arr = dt.Rows[i]["SP2"].ToString().Split('|');
                tempstr = "";
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != arr.Length - 1)
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";

                }
                dt.Rows[i]["SP2"] = tempstr;

                arr = dt.Rows[i]["SP3"].ToString().Split('|');
                tempstr = "";
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != arr.Length - 1)
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";

                }
                dt.Rows[i]["SP3"] = tempstr;

                arr = dt.Rows[i]["SP4"].ToString().Split('|');
                tempstr = "";
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != arr.Length - 1)
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a></br>";
                    else
                        tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + arr[j] + "\">" + arr[j] + "</a>";

                }
                dt.Rows[i]["SP4"] = tempstr;
            }
                Grid1.DataSource = dt;
            Grid1.DataBind();
            Grid1.Hidden = false;
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
                string a1 = "upload/教学比武/"+e.CommandArgument;
                //a1 = Button_sp1.Text.Trim();
                PageContext.RegisterStartupScript("PlayWmv('" + a1 + "');");
                


            }

            else if (e.CommandName == "up")
            {
                if (zt == "1" || zt == "4" || zt == "6")
                {
                    PageContext.RegisterStartupScript(Window1.GetShowReference("XMGL_JXBW_Up.aspx?xmbh=" + xmbh, "修改申报书") + Window1.GetMaximizeReference());
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
                    string sqlstr = "update JXBW set ZT=2 where ID=" + Convert.ToInt32(selectedID);
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
                    string sqlstr = "update JXBW set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
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





        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;



            //Alert.Show(lb.Text, "提示", Alert.DefaultMessageBoxIcon);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a1 = "";
            a1 = "upload/教学比武/635699828444961637_01.wmv";
            PageContext.RegisterStartupScript("PlayWmv("+a1+");");
        }



        protected void Button_XXX_Click(object sender, EventArgs e)//“下一步”按钮及项目团队人员信息顶部导航按钮
        {
            string a1 = "upload/教学比武/635699828444961637_01.wmv";
            //a1 = Button_sp1.Text.Trim();
            PageContext.RegisterStartupScript("PlayWmv('" + a1 + "');");
        }




    }


}