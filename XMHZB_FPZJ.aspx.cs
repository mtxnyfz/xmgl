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
using ICSharpCode.SharpZipLib.Zip;
namespace XMGL.Web.admin
{
    public partial class XMHZB_FPZJ : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["px"] = "1";
                ViewState["pxfs"] = "xxmc";
                ViewState["zt"] = "全部";
                databind("xxmc", "3");
                //dp_setvalue(DropDownList_sbzt, "3");
            }
        }
        protected void dp_setvalue(FineUI.DropDownList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.Trim() == value)    //与数据库中查询出来的那条一样.
                {

                    ddl.SelectedIndex = i;      //这样就可以显示出来了.

                    break;        //选中一条后,跳出循环.
                }
            }

        }

        protected void databind(string pxfs,string sbzt)
        {
            //string sqlstr = "select b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1  and ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
             string sqlstr ="";
             DataTable dt1 = null, dt2 = null, dt3 = null, dt4 = null, dt4_t1 = null, dt4_t2 = null, dt4_t3 = null, dt5 = null, dt6 = null, dt7 = null;
            //if (sbzt == "全部")
            //{
            //    sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1   ) as a,XXJBQKB as b where  a.XXDM=b.XXDM";
            //    dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

            //    sqlstr = "select a.XMBH as XMBH, b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1   ) as a,XXJBQKB as b  where  a.XXDM=b.XXDM";
            //    dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

            //    sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1   ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
            //    dt3 = DbHelperSQL.Query(sqlstr).Tables[0];



            //    sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '通用类' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from TYL_XM where  SFSC!=1   ) as a,XXJBQKB as b where a.DWMC=b.XXMC";
            //    dt7 = DbHelperSQL.Query(sqlstr).Tables[0];
            //}
            //else if (sbzt == "1")
            //{
            //    sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1 and  ZT>1 and ZT!=4 and ZT!=6   ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
            //    dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

            //    sqlstr = "select  a.XMBH as XMBH, b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1  and  ZT>1 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
            //    dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

            //    sqlstr = "select  a.XMBH as XMBH,  b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1  and  ZT>1 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
            //    dt3 = DbHelperSQL.Query(sqlstr).Tables[0];

            //    sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '通用类' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from TYL_XM where   SFSC!=1  and  ZT>1 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.DWMC=b.XXMC";
            //    dt4 = DbHelperSQL.Query(sqlstr).Tables[0];
            //}
          
                sqlstr = "select  a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6   ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
                dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM";
                dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select  a.XMBH as XMBH, b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM";
                dt3 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH,a.DWMC AS XXMC,a.XMDLMC,a.XMMC,'' as ZYFZR_XM,a.SQZXJF,a.XXPTJF,a.XMZJF from (select SZPX_XMSB.XMBH,SZPX_XMSB.DWMC,'师资培训' as XMDLMC ,SZPX_XMSB.XMMC,SZPX_JFYS.JFYS as SQZXJF ,0.0 as XXPTJF,SZPX_JFYS.JFYS as XMZJF from SZPX_XMSB,SZPX_JFYS where SZPX_XMSB.XMBH=SZPX_JFYS.XMBH and SZPX_JFYS.JFLX='ZXJF' and SZPX_XMSB.SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC";
                dt4 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '技术技能竞赛' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from JSJNJS_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC";
                dt5 = DbHelperSQL.Query(sqlstr).Tables[0];
                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '信息管理平台' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from XXGLPT_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC";
                dt6 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '通用类' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from TYL_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.DWMC=b.XXMC";
                dt7 = DbHelperSQL.Query(sqlstr).Tables[0];
            

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

            if (dt4 != null)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt4.Rows[i]);
                    }
                }
            }

            if (dt5 != null)
            {
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt5.Rows[i]);
                    }
                }
            }

            if (dt6 != null)
            {
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt6.Rows[i]);
                    }
                }
            }

            if (dt7 != null)
            {
                for (int i = 0; i < dt7.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt7.Rows[i]);
                    }
                }
            }
            dt1=NweDataTable(dt1, ViewState["zt"].ToString());

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataView view1 = dt1.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            Grid1.DataSource = view1;
            Grid1.DataBind();
            //DataTable dt = null;
            //if (pxfs == "xxmc")
            //{
               
            //    DataView dv = dt1.Copy().DefaultView;
            //    dv.Sort = "XXMC asc,XMDLMC asc";
            //    dt = dv.ToTable();
            //    Grid1.DataSource = dt;
            //    Grid1.DataBind();
              
            //    Grid1.Hidden = false;
            //    Grid2.Hidden = true;
            //    pb.UpdateSelectedRowIndexArray(hfSelectedIDS1, Grid1);
               
            //}
            //else
            //{
            //    DataView dv = dt1.Copy().DefaultView;
             
            //    dv.Sort = "XMDLMC asc";
            //    dt = dv.ToTable();
            //    Grid2.DataSource = dt;
            //    Grid2.DataBind();
              
            //    Grid1.Hidden = true;
            //    Grid2.Hidden = false;
            //    pb.UpdateSelectedRowIndexArray(hfSelectedIDS2, Grid2);
               
            //}
            
           
        }

        protected DataTable NweDataTable(DataTable dt,string key)
        {
           string sqlstr = "";
           SqlDataReader sdr = null;
           int rows = dt.Rows.Count;
            if (key == "1")
            {
                for (int i = rows-1; i>=0; i--)
                {
                    sqlstr = "select ZJID from XM_ZJSZ where XMBH='" + dt.Rows[i]["XMBH"].ToString().Trim() + "'";
                     sdr = DbHelperSQL.ExecuteReader(sqlstr);
                     if (sdr.Read())
                     {

                     }
                     else
                     {
                         dt.Rows.Remove(dt.Rows[i]);
                     }
                    sdr.Close();
                }
            }
            else if (key == "0")
            {
                for (int i = rows - 1; i >= 0; i--)
                {
                    sqlstr = "select ZJID from XM_ZJSZ where XMBH='" + dt.Rows[i]["XMBH"].ToString().Trim() + "'";
                    sdr = DbHelperSQL.ExecuteReader(sqlstr);
                    if (sdr.Read())
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                    else
                    {
                       
                    }
                    sdr.Close();
                }
            }
            
            return dt;
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            //SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            Grid1.PageIndex = e.NewPageIndex;
            databind("","");
        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            GridRow gr = Grid1.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;
            string XMBH = values[0].ToString().Trim();
            string nowdate = DateTime.Now.ToString("yyyy-MM-dd");
            string zjs = "0";
            string sqlstr = "select  count(ZJID) FROM [XM_ZJSZ] where XMBH='" + XMBH + "'";
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
            if (sdr.Read())
            {
                zjs = sdr[0].ToString();
            }
            sdr.Close();
            lb.Text = zjs;
        }

       

        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {
            databind("xxmc", ViewState["sbzt"].ToString());
            ViewState["px"] = "1";
            ViewState["pxfs"] = "xxmc";
        }

        protected void btnConfirmButton_Click(object sender, EventArgs e)
        {
            ViewState["px"] = "2";
            databind("xmlb", ViewState["sbzt"].ToString());
            ViewState["pxfs"] = "xmlb";
        }

        //protected void DropDownList_sbzt_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ViewState["sbzt"]= DropDownList_sbzt.SelectedValue.Trim();
        //    if( ViewState["px"].ToString() =="1")
        //        databind("xxmc", ViewState["sbzt"].ToString());
        //    else
        //        databind("xmlb", ViewState["sbzt"].ToString());

        //}


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);



            if (e.CommandName == "zj")
            {
                string xmbh = values[0].ToString();
                string xmmc = values[1].ToString();
                PageContext.RegisterStartupScript(Window1.GetShowReference("XM_ZJSZ.aspx?xmbh="+xmbh+"&xmmc="+xmmc, xmmc));
                
                //}
            }
        }

        //protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        //{
        //    object[] values = Grid2.DataKeys[e.RowIndex];
        //    //int id = Convert.ToInt32(values[0]);



        //    if (e.CommandName == "xq")
        //    {
        //        string xmbh = values[0].ToString();
        //        BLL.XMSBSWD wordBll = new BLL.XMSBSWD();

        //        var list = wordBll.GetModelList("XMBH = '" + xmbh + "'");
        //        if (list.Count > 0)
        //        {
        //            var service = ConfigurationManager.AppSettings["OfficeWebAppsServiceIp"];
        //            var server = ConfigurationManager.AppSettings["OfficeWebAppsServerIp"];

        //            var str = "http://" + server + "/wv/wordviewerframe.aspx?WOPISrc=http://" + service + "/wopi/files/" + xmbh + "?access_token=" + Guid.NewGuid() + "";
        //            PageContext.RegisterStartupScript(Window1.GetShowReference(str, "查看申报书") + Window1.GetMaximizeReference());


        //        }
        //    }
        //}




        private void SyncSelectedRowIndexArrayToHiddenField(FineUI.HiddenField hd,FineUI.Grid grid)
        {
            // 重新绑定表格数据之前，将当前表格页选中行的数据同步到隐藏字段中
            pb.SyncSelectedRowIndexArrayToHiddenField(hd, grid);
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            List<string> ids = null;
            string xmbh = "";
            if (ViewState["pxfs"].ToString() == "xxmc")
            {
                SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
                ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS1);
            }
            else
            {
                //SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS2, Grid2);
                //ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS2);
            }
            if (ids != null)
            {
                if (ids.Count > 0)
                {
                    string sqlstr = "select WDLJ from XMSBSWD where ";
                    for (int i = 0; i < ids.Count; i++)
                    {
                        xmbh = xmbh + ids[i] + ",";
                        if (i != ids.Count - 1)
                            sqlstr = sqlstr + " XMBH='" + ids[i] + "' or ";
                        else
                            sqlstr = sqlstr + " XMBH='" + ids[i] + "'";

                    }

                    DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
                    string err = "";
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".zip";
                    string savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);
                    if (ZipFile(dt, savepath, out err) == true)
                    {
                        //HyperLink1.Text = "打包成功！点击下载：" + filename;
                        //HyperLink1.NavigateUrl = "down/" + filename;
                        //Alert.Show("已成功生成打包文件，请点击文件名下载");
                    }
                    else
                        Alert.Show("生成压缩包失败，无法下载");
                    //for(int i=0;i<dt.Rows.Count;i++)
                    //{
                    //    if (File.Exists(dt.Rows[i]["WDLJ"].ToString().Trim()))
                    //    {

                    //    }
                    //}
                }
                else
                {
                    Alert.Show("没有勾选行数据");
                }
            }
            else
            {
                Alert.Show("没有勾选行数据");
            }
        }



        #region 加压解压方法
        /// <summary>
        /// 功能：压缩文件（暂时只压缩文件夹下一级目录中的文件，文件夹及其子级被忽略）
        /// </summary>
        /// <param name="dirPath">被压缩的文件夹夹路径</param>
        /// <param name="zipFilePath">生成压缩文件的路径，为空则默认与被压缩文件夹同一级目录，名称为：文件夹名+.zip</param>
        /// <param name="err">出错信息</param>
        /// <returns>是否压缩成功</returns>
        //public bool ZipFile(string dirPath, string zipFilePath, out string err)
        //{
        //    err = "";
        //    if (dirPath == string.Empty)
        //    {
        //        err = "要压缩的文件夹不能为空！";
        //        return false;
        //    }
        //    if (!Directory.Exists(dirPath))
        //    {
        //        err = "要压缩的文件夹不存在！";
        //        return false;
        //    }
        //    //压缩文件名为空时使用文件夹名＋.zip
        //    if (zipFilePath == string.Empty)
        //    {
        //        if (dirPath.EndsWith("\\"))
        //        {
        //            dirPath = dirPath.Substring(0, dirPath.Length - 1);
        //        }
        //        zipFilePath = dirPath + ".zip";
        //    }

        //    try
        //    {
        //        string[] filenames = Directory.GetFiles(dirPath);
        //        using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
        //        {
        //            s.SetLevel(9);
        //            byte[] buffer = new byte[4096];
        //            foreach (string file in filenames)
        //            {
        //                ZipEntry entry = new ZipEntry(Path.GetFileName(file));
        //                entry.DateTime = DateTime.Now;
        //                s.PutNextEntry(entry);
        //                using (FileStream fs = File.OpenRead(file))
        //                {
        //                    int sourceBytes;
        //                    do
        //                    {
        //                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
        //                        s.Write(buffer, 0, sourceBytes);
        //                    } while (sourceBytes > 0);
        //                }
        //            }
        //            s.Finish();
        //            s.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        err = ex.Message;
        //        return false;
        //    }
        //    return true;
        //}
        #endregion



        public bool ZipFile(DataTable dt, string zipFilePath, out string err)
        {
            err = "";
           
           

            try
            {
                //string[] filenames = Directory.GetFiles(dirPath);
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    s.SetLevel(9);
                    byte[] buffer = new byte[4096];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (File.Exists(dt.Rows[i]["WDLJ"].ToString().Trim()))
                        {
                            ZipEntry entry = new ZipEntry(Path.GetFileName("@"+dt.Rows[i]["WDLJ"].ToString().Trim()));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);
                            using (FileStream fs = File.OpenRead(dt.Rows[i]["WDLJ"].ToString().Trim()))
                            {
                                int sourceBytes;
                                do
                                {
                                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                    s.Write(buffer, 0, sourceBytes);
                                } while (sourceBytes > 0);
                            }
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }


        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;

            databind("xxmc", "3");
        }

        protected void DropDownList_zt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["zt"]=DropDownList_zt.SelectedValue.Trim();
            databind("xxmc", "");
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            databind("xxmc", "");
        }

    }
}