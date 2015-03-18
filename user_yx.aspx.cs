﻿using System;
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
    public partial class user_yx : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        string ModuleName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ModuleName = pb.GetModuleName()["用户信息管理"].ToString();
                ModuleName = "用户信息管理(院校)";
                ViewState["dt_Power"] = pb.GetIdentityRolePower(pb.GetIdentityId(), pb.GetIdentityRoleId(), ModuleName);

                Grid1_databind();


            }
        }

        protected void Grid1_databind()
        {

            //string jgh = pb.GetIdentityId();

            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select * FROM Users  order by Name").Tables[0];

            string userid = pb.GetIdentityId();
            string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
            string xxdm = "", xxmc = "";
            if (sdr.Read())
            {
                xxdm = sdr["xxdm"].ToString().Trim();
                ViewState["xxdm"] = xxdm;
                xxmc = sdr["xxmc"].ToString().Trim();
            }
            sdr.Dispose();

            //string sqlstr = "";
            DataTable dt_Power = ViewState["dt_Power"] as DataTable;
            if (pb.GetIdentityRoleId().Trim() != "1" & pb.GetIdentityRoleId().Trim() != "5")
                sqlstr = "select * FROM Users where user_uid='" + pb.GetIdentityId() + "'  order by Name";
            else

                sqlstr = "select * FROM Users where xxdm='"+xxdm+"'  order by Name";

            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            //dt = pb.GetnewDataTable(dt, dt_Power, "xm_id");
            Grid1.DataSource = dt;
            Grid1.DataBind();

        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            string addUrl = "~/admin/user_add_yx.aspx";

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "添加用户"));
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            Grid1_databind();
        }
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            Grid1_databind();
            Alert.Show("操作成功！", "提示", Alert.DefaultMessageBoxIcon);
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            string user_uid = values[0].ToString().Trim();



            if (e.CommandName == "Delete")
            {
                string sqlstr = "delete Users where user_uid='" + user_uid + "'";
                int state = DbHelperSQL.ExecuteSql(sqlstr);
                if (state != 0)
                {
                    Grid1_databind();
                    Alert.Show("删除成功！", "提示", Alert.DefaultMessageBoxIcon);
                }
                else
                {
                    Alert.Show("删除失败！", "提示", Alert.DefaultMessageBoxIcon);
                    return;
                }
            }
        }
        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            DataTable dt = ViewState["dt_Power"] as DataTable;
            if (dt.Rows.Count != 0)
            {
                JObject otherPowerObj = JObject.Parse(dt.Rows[0]["Others"].ToString().Trim());
                JProperty jp1 = otherPowerObj.Property("Del");
                if (jp1 != null)
                {
                    if (jp1.Value.ToString() == "True")
                    {
                        pb.CheckPower_GridLinkButtonField(Grid1, "deleteField", true);
                    }
                    else
                    {
                        pb.CheckPower_GridLinkButtonField(Grid1, "deleteField", false);
                    }
                }
                else
                {
                    pb.CheckPower_GridLinkButtonField(Grid1, "deleteField", false);
                }

                jp1 = otherPowerObj.Property("Edit");
                if (jp1 != null)
                {
                    if (jp1.Value.ToString() == "True")
                    {
                        pb.CheckPower_GridLinkWindowField(Grid1, "upuser", true);
                    }
                    else
                    {
                        pb.CheckPower_GridLinkWindowField(Grid1, "upuser", false);
                    }
                }
                else
                {
                    pb.CheckPower_GridLinkWindowField(Grid1, "upuser", false);
                }


                jp1 = otherPowerObj.Property("New");
                if (jp1 != null)
                {
                    if (jp1.Value.ToString() == "True")
                    {
                        pb.CheckPowerWithButton(btnNew, true);
                    }
                    else
                    {
                        pb.CheckPowerWithButton(btnNew, false);
                    }
                }
                else
                {
                    pb.CheckPowerWithButton(btnNew, false);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserId = "", Name = "", Password = "", xxmc = "", xxdm = "", user_uid = "", tel = "", ActualName = "";

            string sqlstr = "select XXDM,XXMC,LXRXM,LXRSJ from XXJBQKB where XXMC!='上海市教委'";
            DataTable dt=DbHelperSQL.Query(sqlstr).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sqlstr = "delete from Users where xxdm='" + dt.Rows[i]["XXDM"].ToString().Trim() + "' and Name='" + dt.Rows[i]["LXRXM"].ToString().Trim() + "'";
                DbHelperSQL.ExecuteSql(sqlstr);
                user_uid = Guid.NewGuid().ToString();
                Password = dt.Rows[i]["LXRSJ"].ToString().Trim();
                if (Password == "")
                {
                    Password = "111111";
                }
                sqlstr = "insert into Users(user_uid,UserId,Name,Password,xxdm,xxmc,tel,ActualName) values('" + user_uid + "','" + dt.Rows[i]["LXRXM"].ToString().Trim() + "','" + dt.Rows[i]["LXRXM"].ToString().Trim() + "','" + Password + "','" + dt.Rows[i]["XXDM"].ToString().Trim() + "','" + dt.Rows[i]["XXMC"].ToString().Trim() + "','" + tel + "','" + ActualName + "')";
                int state = DbHelperSQL.ExecuteSql(sqlstr);
            }
            Grid1_databind();
            Alert.Show("操作成功！", "提示", Alert.DefaultMessageBoxIcon);

        }
    }
}