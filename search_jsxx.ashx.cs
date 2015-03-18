using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;
namespace XMGL.Web.admin
{
    /// <summary>
    /// search_jsxx 的摘要说明
    /// </summary>
    public class search_jsxx : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String term = context.Request.QueryString["term"];
            if (!String.IsNullOrEmpty(term))
            {
                //term = term.ToLower();

                string xxdm = "";
                if (context.Session["xxdm"] != null)
                {

                   xxdm = context.Session["xxdm"].ToString();

                }
                string sqlstr = "select * from JSXXB where XXDM='" + xxdm + "' and JSXM like'%" + term.Trim() + "%'", key = "";
                string jsxm = "", csny = "", zzjz = "", sfss = "", xl = "", xw = "", zcdj = "";
                string y="", m = "", d = "";
                string jsonstr = "[";
                DataTable dt = null;
                try
                {
                    dt = DbHelperSQL.Query(sqlstr).Tables[0];
                }
                catch
                {
                    jsonstr = jsonstr + "]";

                    context.Response.ContentType = "text/plain";
                    string aa = jsonstr;
                    context.Response.Write(jsonstr);
                    return;
                }
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    csny = dt.Rows[i]["CSNY"].ToString().Trim();
                    zzjz = dt.Rows[i]["ZZJZ"].ToString().Trim();
                    sfss = dt.Rows[i]["SFSS"].ToString().Trim();
                    xl = dt.Rows[i]["XL"].ToString().Trim();
                    xw = dt.Rows[i]["XW"].ToString().Trim();
                    zcdj = dt.Rows[i]["ZCDJ"].ToString().Trim();
                    //if (csny.Length ==8)
                    //{
                    //    try
                    //    {
                    //        y = csny.Substring(0, 4);
                    //        m = csny.Substring(4, 2);
                    //        d = csny.Substring(6, 2);
                    //        csny = Convert.ToDateTime(y + "-" + m+"-"+d).ToString("yyyy-MM");
                          
                    //    }
                    //    catch (Exception ex)
                    //    {
                          
                    //        csny = "";
                    //    }
                    //}
                    //else
                    //    csny = "";
                    if (zzjz.Contains("专"))
                        zzjz = "专职";
                    else if (zzjz.Contains("兼"))
                        zzjz = "兼职";
                    else
                        zzjz = "";



                    if (i < dt.Rows.Count - 1)
                        jsonstr = jsonstr + "{\"jsxm\":\"" + dt.Rows[i]["JSXM"].ToString().Trim() + "\",\"csny\":\"" + csny + "\",\"zzjz\":\"" + zzjz + "\",\"sfss\":\"" + dt.Rows[i]["SFSS"].ToString().Trim() + "\",\"xl\":\"" + dt.Rows[i]["XL"].ToString().Trim() + "\",\"xw\":\"" + dt.Rows[i]["XW"].ToString().Trim() + "\",\"zcdj\":\"" + dt.Rows[i]["ZCDJ"].ToString().Trim() + "\"},";
                    else
                        jsonstr = jsonstr + "{\"jsxm\":\"" + dt.Rows[i]["JSXM"].ToString().Trim() + "\",\"csny\":\"" + csny + "\",\"zzjz\":\"" + zzjz + "\",\"sfss\":\"" + dt.Rows[i]["SFSS"].ToString().Trim() + "\",\"xl\":\"" + dt.Rows[i]["XL"].ToString().Trim() + "\",\"xw\":\"" + dt.Rows[i]["XW"].ToString().Trim() + "\",\"zcdj\":\"" + dt.Rows[i]["ZCDJ"].ToString().Trim() + "\"}";

                    //if (i < dt.Rows.Count - 1)
                    //    jsonstr = jsonstr + "{\"label\":\"项目名称：" + dt.Rows[i]["XMLB_MC"] + "\",\"value\":\"" + dt.Rows[i]["XMLB_MC"] + "\",\"xmbh\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"fzr\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"ye\":\"" + dt.Rows[i]["XMLB_RYJFYE"] + "\"},";
                    //else
                    //    jsonstr = jsonstr + "{\"label\":\"项目名称：" + dt.Rows[i]["XMLB_MC"] + "\",\"value\":\"" + dt.Rows[i]["XMLB_MC"] + "\",\"xmbh\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"fzr\":\"" + dt.Rows[i]["XMLB_BH"] + "\",\"ye\":\"" + dt.Rows[i]["XMLB_RYJFYE"] + "\"}";
                }
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