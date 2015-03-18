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
namespace XMGL.Web.admin
{
    public partial class XMHZB_SJW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["px"] = "1";
                ViewState["sbzt"] = "全部";
                databind("xxmc1","全部");
            }
        }


        protected void databind(string pxfs,string sbzt)
        {
            //string sqlstr = "select b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1  and ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
             string sqlstr ="";
            DataTable dt1=null,dt2=null,dt3=null;
            if (sbzt == "全部")
            {
                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1   ) as a,XXJBQKB as b where  a.XXDM=b.XXDM";
                dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH, b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1   ) as a,XXJBQKB as b  where  a.XXDM=b.XXDM";
                dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1   ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
                dt3 = DbHelperSQL.Query(sqlstr).Tables[0];
            }
            else if (sbzt == "1")
            {
                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1 and  ZT>1 and ZT!=4 and ZT!=6   ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
                dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select  a.XMBH as XMBH, b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1  and  ZT>1 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
                dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select  a.XMBH as XMBH,  b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1  and  ZT>1 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
                dt3 = DbHelperSQL.Query(sqlstr).Tables[0];
            }
            else if (sbzt == "3")
            {
                sqlstr = "select  a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6   ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
                dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM";
                dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select  a.XMBH as XMBH, b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM";
                dt3 = DbHelperSQL.Query(sqlstr).Tables[0];
            }

            DataRow dr = null;
            if (dt2 != null)
            {
                for (int i = 0; i<dt2.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {
                        //dr = dt2.NewRow();
                        //for (int j = 0; j < dt2.Columns.Count; j++)
                        //{
                        //    dr[j] = dt2.Rows[i][j];
                        //}
                        //dt1.Rows.Add(dt2.Rows[i]);
                        dt1.ImportRow(dt2.Rows[i]);
                    }
                }
            }

            if (dt3 != null)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {
                        //dr = dt3.NewRow();
                        //for (int j = 0; j < dt3.Columns.Count; j++)
                        //{
                        //    dr[j] = dt3.Rows[i][j];
                        //}
                        //dt1.Rows.Add(dt3.Rows[i]);
                        dt1.ImportRow(dt3.Rows[i]);
                    }
                }
            }

            DataTable dt = null;
            if (pxfs == "xxmc")
            {
               
                DataView dv = dt1.Copy().DefaultView;
                dv.Sort = "XXMC asc,XMDLMC asc";
                dt = dv.ToTable();
                Grid1.DataSource = dt;
                Grid1.DataBind();
                //Grid1.Visible = false;
                //Grid2.Visible = true;
                Grid1.Hidden = false;
                Grid2.Hidden = true;
                //FineUI.BoundField btn1 = Grid1.FindColumn("Panel1_Grid1_ctl07") as FineUI.BoundField;
                //btn1.DataField = "XXMC";
                //btn1.HeaderText = "院校名称";
                //btn1.DataToolTipField = "XXMC";


                //FineUI.BoundField btn2 = Grid1.FindColumn("Panel1_Grid1_ctl08") as FineUI.BoundField;
                //btn2.DataField = "XMDLMC";
                //btn2.HeaderText = "项目类别";
                //btn2.DataToolTipField = "XMDLMC";
            }
            else
            {
                DataView dv = dt1.Copy().DefaultView;
                //dv.Sort = "XMDLMC desc,XXMC desc";
                dv.Sort = "XMDLMC asc";
                dt = dv.ToTable();
                Grid2.DataSource = dt;
                Grid2.DataBind();
                //Grid1.Visible = true;
                //Grid2.Visible = false;
                Grid1.Hidden = true;
                Grid2.Hidden = false;
                //FineUI.BoundField btn1 = Grid1.FindColumn("Panel1_Grid1_ctl07") as FineUI.BoundField;
                //btn1.DataField = "XMDLMC";
                //btn1.HeaderText = "项目类别";
                //btn1.DataToolTipField = "XMDLMC";


                //FineUI.BoundField btn2 = Grid1.FindColumn("Panel1_Grid1_ctl08") as FineUI.BoundField;
                //btn2.DataField = "XXMC";
                //btn2.HeaderText = "院校名称";
                //btn2.DataToolTipField = "XXMC";
            }
            
           
        }


        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }

        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
        }

        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {
            databind("xxmc", ViewState["sbzt"].ToString());
            ViewState["px"] = "1";
        }

        protected void btnConfirmButton_Click(object sender, EventArgs e)
        {
            ViewState["px"] = "2";
            databind("xmlb", ViewState["sbzt"].ToString());
        }

        protected void DropDownList_sbzt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["sbzt"]= DropDownList_sbzt.SelectedValue.Trim();
            if( ViewState["px"].ToString() =="1")
                databind("xxmc", ViewState["sbzt"].ToString());
            else
                databind("xmlb", ViewState["sbzt"].ToString());

        }


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
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

        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid2.DataKeys[e.RowIndex];
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