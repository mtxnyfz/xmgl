using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;

using System.IO;


namespace XMGL.Web.admin
{
    /// <summary>
    /// upload1 的摘要说明
    /// </summary>
    public class upload1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFileBase file = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[0]);
            String lx = HttpContext.Current.Server.UrlDecode(context.Request.QueryString["lx"]);
            String extensions = HttpContext.Current.Server.UrlDecode(context.Request.QueryString["extensions"]);
            String lxzm = HttpContext.Current.Server.UrlDecode(context.Request.QueryString["up_type_zm"]);
            //String name = context.Request.QueryString["name"];
            //String type = context.Request.QueryString["type"];
            //String lastModifiedDate = context.Request.QueryString["lastModifiedDate"];
            //int size = int.Parse(context.Request.QueryString["size"].ToString());
            context.Response.ContentType = "text/plain";
            var applicationPath = VirtualPathUtility.ToAbsolute("~") == "/" ? "" : VirtualPathUtility.ToAbsolute("~");
            string urlPath = applicationPath + "/upload";
            string filePathName = string.Empty;

            string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, @"admin\upload\教学比武");
            string jsonstr = "[";
            //if (context.Request.Files.Count == 0)
            //{
            //    return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id" });
            //}

            //string ex = Path.GetExtension(file.FileName);


            filePathName = context.Session["xxdm"] + "_" +DateTime.Now.ToString("yyyyMMddHHmmssfff")+"_"+ file.FileName;
            filePathName = filePathName.Replace("|", "");
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            if (extensions == "wmv")
            {
                try
                {
                    file.SaveAs(@"E:\video\" + filePathName);
                    DataTable dt_sp1 = null;
                    if (context.Session["sp1"] == null)
                    {
                        dt_sp1 = new DataTable();
                        dt_sp1.Columns.Add("id");
                        dt_sp1.Columns.Add("filename");
                        dt_sp1.Columns.Add("lx");
                        dt_sp1.Columns.Add("lxzm");
                        DataRow dr = dt_sp1.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["filename"] = filePathName;
                        dr["lx"] = lx;
                        dr["lxzm"] = lxzm;
                        dt_sp1.Rows.Add(dr);
                    }
                    else
                    {
                        dt_sp1 = context.Session["sp1"] as DataTable;
                        DataRow dr = dt_sp1.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["filename"] = filePathName;
                        dr["lx"] = lx;
                        dr["lxzm"] = lxzm;
                        dt_sp1.Rows.Add(dr);
                    }
                    context.Session["sp1"] = dt_sp1;
                }
                catch
                {
                    return;
                }
            }
           //else  if (lx == "sp2")
           // {
           //     try
           //     {
           //         file.SaveAs(@"E:\video\" + filePathName);
           //         DataTable dt_sp1 = null;
           //         if (context.Session["sp2"] == null)
           //         {
           //             dt_sp1 = new DataTable();
           //             dt_sp1.Columns.Add("id");
           //             dt_sp1.Columns.Add("filename");
           //             DataRow dr = dt_sp1.NewRow();
           //             dr["id"] = Guid.NewGuid().ToString();
           //             dr["filename"] = filePathName;
           //             dt_sp1.Rows.Add(dr);
           //         }
           //         else
           //         {
           //             dt_sp1 = context.Session["sp2"] as DataTable;
           //             DataRow dr = dt_sp1.NewRow();
           //             dr["id"] = Guid.NewGuid().ToString();
           //             dr["filename"] = filePathName;
           //             dt_sp1.Rows.Add(dr);
           //         }
           //         context.Session["sp2"] = dt_sp1;
           //     }
           //     catch
           //     {
           //         return;
           //     }
           // }
           // else if (lx == "sp3")
           // {
           //     try
           //     {
           //         file.SaveAs(@"E:\video\" + filePathName);
           //         DataTable dt_sp1 = null;
           //         if (context.Session["sp3"] == null)
           //         {
           //             dt_sp1 = new DataTable();
           //             dt_sp1.Columns.Add("id");
           //             dt_sp1.Columns.Add("filename");
           //             DataRow dr = dt_sp1.NewRow();
           //             dr["id"] = Guid.NewGuid().ToString();
           //             dr["filename"] = filePathName;
           //             dt_sp1.Rows.Add(dr);
           //         }
           //         else
           //         {
           //             dt_sp1 = context.Session["sp3"] as DataTable;
           //             DataRow dr = dt_sp1.NewRow();
           //             dr["id"] = Guid.NewGuid().ToString();
           //             dr["filename"] = filePathName;
           //             dt_sp1.Rows.Add(dr);
           //         }
           //         context.Session["sp3"] = dt_sp1;
           //     }
           //     catch
           //     {
           //         return;
           //     }
           // }
           // else if (lx == "sp4")
           // {
           //     try
           //     {
           //         file.SaveAs(@"E:\video\" + filePathName);
           //         DataTable dt_sp1 = null;
           //         if (context.Session["sp4"] == null)
           //         {
           //             dt_sp1 = new DataTable();
           //             dt_sp1.Columns.Add("id");
           //             dt_sp1.Columns.Add("filename");
           //             DataRow dr = dt_sp1.NewRow();
           //             dr["id"] = Guid.NewGuid().ToString();
           //             dr["filename"] = filePathName;
           //             dt_sp1.Rows.Add(dr);
           //         }
           //         else
           //         {
           //             dt_sp1 = context.Session["sp4"] as DataTable;
           //             DataRow dr = dt_sp1.NewRow();
           //             dr["id"] = Guid.NewGuid().ToString();
           //             dr["filename"] = filePathName;
           //             dt_sp1.Rows.Add(dr);
           //         }
           //         context.Session["sp4"] = dt_sp1;
           //     }
           //     catch
           //     {
           //         return;
           //     }
           // }
            else
            {
                try
                {
                    file.SaveAs(Path.Combine(localPath, filePathName));
                    DataTable dt_sp1 = null;
                    if (context.Session["wd"] == null)
                    {
                        dt_sp1 = new DataTable();
                        dt_sp1.Columns.Add("id");
                        dt_sp1.Columns.Add("filename");
                        dt_sp1.Columns.Add("lx");
                        dt_sp1.Columns.Add("lxzm");
                        DataRow dr = dt_sp1.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["filename"] = filePathName;
                        dr["lx"] = lx;
                        dr["lxzm"] = lxzm;
                        dt_sp1.Rows.Add(dr);
                    }
                    else
                    {
                        dt_sp1 = context.Session["wd"] as DataTable;
                        DataRow dr = dt_sp1.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["filename"] = filePathName;
                        dr["lx"] = lx;
                        dr["lxzm"] = lxzm;
                        dt_sp1.Rows.Add(dr);
                    }
                    context.Session["wd"] = dt_sp1;
                }
                catch
                {
                    return;
                }
            }
            //file.SaveAs(Path.Combine(localPath, filePathName));

            jsonstr = jsonstr + "{\"jsonrpc\":\"2.0\",\"id\":\"id\",\"filePath\":\"" + urlPath + "/" + filePathName + "\"}";
            jsonstr = jsonstr + "]";
            context.Response.ContentType = "text/plain";

            context.Response.Write(jsonstr);
            //return Json(new
            //{
            //    jsonrpc = "2.0",
            //    id = "id",
            //    filePath = urlPath + "/" + filePathName
            //});
            //context.Response.Write("Hello World");
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