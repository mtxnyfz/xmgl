using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;

namespace EmptyProjectNet40_FineUI
{
    /// <summary>
    /// search_bykey 的摘要说明
    /// </summary>
    public class search_bykey : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
             String term = context.Request.QueryString["term"];
             if (!String.IsNullOrEmpty(term))
             {
                 //term = term.ToLower();
                 string xmbh = "";
                 if (context.Session["xmbh"] != null)
                 {

                     xmbh = context.Session["xmbh"].ToString();

                 }
                 string jsonstr = "[";
                 string sqlstr = "select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX and Experts_Name like'%"+term+"%' and Experts_ID not in(select ZJID from XM_ZJSZ where XMBH='" + xmbh + "')";
                 DataTable dt1 = DbHelperSQL.Query(sqlstr).Tables[0];
                
                 for (int i = 0;i< dt1.Rows.Count; i++)
                 {
                     jsonstr = jsonstr + "{\"key\":\"" + dt1.Rows[i]["Experts_Name"].ToString().Trim() + "\"},";
                 }
                 //for (int i = 0; i < dt2.Rows.Count; i++)
                 //{
                 //    jsonstr = jsonstr + "{\"key\":\"" + dt2.Rows[i][0].ToString().Trim() + "\"},";
                 //}
                 //for (int i = 0; i < dt3.Rows.Count; i++)
                 //{
                 //    jsonstr = jsonstr + "{\"key\":\"" + dt3.Rows[i][0].ToString().Trim() + "\"},";
                 //}
                 jsonstr = jsonstr.Trim();
                 if(dt1.Rows.Count>0)
                 jsonstr = jsonstr.Remove(jsonstr.Length - 1, 1);
                 jsonstr = jsonstr + "]";

                 context.Response.ContentType = "text/plain";
                
                 context.Response.Write(jsonstr);
             }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}