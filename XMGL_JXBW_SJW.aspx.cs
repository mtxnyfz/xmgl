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
    public partial class XMGL_JXBW_SJW : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                //string userid = pb.GetIdentityId();
                //string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
                //SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                //string xxdm = "", xxmc = "";
                //if (sdr.Read())
                //{
                //    xxdm = sdr["xxdm"].ToString().Trim();
                //    ViewState["xxdm"] = xxdm;
                //    xxmc = sdr["xxmc"].ToString().Trim();
                //    ViewState["xxmc"] = xxmc;
                //}
                //sdr.Dispose();
               
                databind();

               
            }
        }

        //protected void databind_DropDownList1()
        //{

           
        //    DropDownList1.Items.Clear();

        //    DataTable dt = DbHelperSQL.Query("select XMSBSMB.ID AS ID, XMSBSMB.XMSBSMBMC as XMSBSMBMC from XMSBSMB_YX,XMSBSMB where XMSBSMB_YX.ID=XMSBSMB.ID and XMSBSMB_YX.XXDM='" + ViewState["xxdm"].ToString() + "'").Tables[0];
         
        //    DropDownList1.DataSource = dt;
        //    DropDownList1.DataTextField = "XMSBSMBMC";
        //    DropDownList1.DataValueField = "ID";
        //    DropDownList1.DataBind();

        //    DropDownList1.Items.Add("所有", "所有");
        //    dp_setvalue(DropDownList1, "所有");
            




        //}

        //protected void databind_DropDownList2()
        //{

        //    DropDownList2.Items.Clear();

        //    //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select  xb_dm,xb_mc  FROM xb  order by xb_mc asc").Tables[0];
        //    DataTable dt = DbHelperSQL.Query("select  XXDM,XXMC  FROM XXJBQKB where xxdm!='000000'  order by XXMC").Tables[0];
        //    DropDownList2.DataSource = dt;
        //    DropDownList2.DataTextField = "XXMC";
        //    DropDownList2.DataValueField = "XXDM";
        //    DropDownList2.DataBind();
        //    DropDownList2.Items.Add("所有", "所有");

        //    dp_setvalue(DropDownList2, "所有");





        //}

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

        protected void databind()
        {
            string sqlstr = "";
          
          
                //sqlstr = "  select  a.ID, a.user_uid, a.XMBH,'一流专业建设' as XMDL,a.XMMC,a.SQZXJF,a.XXPTJF,a.ZT,XMFJ.XMKXXFXBGWJM,XMFJ.YXXSALWJM,XMFJ.XMYSMXWJM from ( select * from YLZY where  SFSC!=1 and ZT>=2 and XXDM='" + ViewState["xxdm"].ToString() + "') as a left join XMFJ  on   a.XMBH=XMFJ.XMBH order by XMBH";
            //sqlstr = "  select * from SZRT where SFSC!=1 and ZT>=2 and XXDM='" + ViewState["xxdm"].ToString() + "'";
            sqlstr = "select * from JXBW WHERE  SFSC =0 and ZT>=3 and ZT!=4 and ZT!=6"; 
                DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
                string[] arr = null;
                string[] arr_temp = null;
                string tempstr = "";
                string title = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arr = dt.Rows[i]["WORD1"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a>";
                        //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                    }
                    dt.Rows[i]["WORD1"] = tempstr;

                    arr = dt.Rows[i]["WORD2"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a>";
                        //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                    }
                    dt.Rows[i]["WORD2"] = tempstr;

                    arr = dt.Rows[i]["WORD3"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a>";
                        //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                    }
                    dt.Rows[i]["WORD3"] = tempstr;

                    arr = dt.Rows[i]["WORD4"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"upload/教学比武/" + arr[j] + "\" target=\"_blank\" title=\"" + title + "\">" + title + "</a>";
                        //dt.Rows[i]["WORD1"]=dt.Rows[i]["WORD1"]
                    }
                    dt.Rows[i]["WORD4"] = tempstr;


                    arr = dt.Rows[i]["SP1"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a>";

                    }
                    dt.Rows[i]["SP1"] = tempstr;

                    arr = dt.Rows[i]["SP2"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a>";

                    }
                    dt.Rows[i]["SP2"] = tempstr;

                    arr = dt.Rows[i]["SP3"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a>";

                    }
                    dt.Rows[i]["SP3"] = tempstr;

                    arr = dt.Rows[i]["SP4"].ToString().Split('|');
                    tempstr = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        title = "";
                        if (arr[j].Trim() != "")
                        {
                            arr_temp = arr[j].Split('_');
                            title = arr[j].Substring(arr_temp[0].Length + arr_temp[1].Length + 2);
                        }
                        if (j != arr.Length - 1)
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a></br>";
                        else
                            tempstr = tempstr + "<a href=\"#\" onclick=\"PlayWmv('" + arr[j] + "')\" title=\"" + title + "\">" + title + "</a>";

                    }
                    dt.Rows[i]["SP4"] = tempstr;
                }
                Grid1.DataSource = dt;
                Grid1.DataBind();
                Grid1.Hidden = false;
             
        }
        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
           
            Alert.ShowInTop("操作成功！");
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }
     
        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {

        }
        protected void btnConfirmButton_Click(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string zt = "";
            string date = "";
            string xmqs = "";
            string sqlstr = "";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";
                    zt += Grid1.DataKeys[rowIndex][2].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (zt == "1")
                {
                    sqlstr = "update JXBW set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
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
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string date = "";
            string xmqs = "";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                //date = date.TrimEnd(',');//去掉最后一个，号
                //xmqs = xmqs.TrimEnd(',');//去掉最后一个，号
                //string date1 = "2013-05-01";
                //DateTime dt = Convert.ToDateTime(date);
                //DateTime dt1 = Convert.ToDateTime(date1);
                ////if (DateTime.Compare(dt, dt1) > 0&&xmqs=="")
                ////PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail2.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));
                //if (xmqs == "2")
                //    PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail2.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));
                //else if (xmqs == "3")
                //    PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));
                //else if (xmqs == "1")
                //    PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail1.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));


                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                
                var list = wordBll.GetModelList("XMBH = '" + xmbh + "'");
                if (list.Count > 0)
                {
                    var service = ConfigurationManager.AppSettings["OfficeWebAppsServiceIp"];
                    var server = ConfigurationManager.AppSettings["OfficeWebAppsServerIp"];

                    var str = "http://" + server + "/wv/wordviewerframe.aspx?WOPISrc=http://" + service + "/wopi/files/" + xmbh + "?access_token=" + Guid.NewGuid() + "";
                    PageContext.RegisterStartupScript(Window1.GetShowReference(str, "查看申报书")+Window1.GetMaximizeReference());


                }

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string date = "";
            string xmqs = "";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") +"_"+ViewState["xxdm"]+ ".doc";
                var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015项目申报书(一流专业)141226.doc");
                var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

                if (new BuildWord().BuildWord_2015ProjectDeclaration(tmppath, savepath, xmbh))
                    HyperLink1.Text = "导出成功！点击下载：" + filename;
                HyperLink1.NavigateUrl ="down/" + filename;


             
            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }

          
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
                    string sqlstr = "update JXBW set ZT=3 where ID=" + Convert.ToInt32(selectedID);
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
                    string sqlstr = "update JXBW set ZT=4 where ID=" + Convert.ToInt32(selectedID);
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




            if (lb.Text.Trim() == "3")
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

     

        protected void Button2_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string zt = "";
            string date = "";
            string xmqs = "";
            string sqlstr = "";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";
                    zt += Grid1.DataKeys[rowIndex][2].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (Convert.ToInt32(zt)==2)
                {
                    sqlstr = "update JXBW set ZT=4 where ID=" + Convert.ToInt32(selectedID);
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
                    //string[] a=new string[1];
                    //a[0]="13661888094";
                    // SMS.MobileSMS sms= new SMS.MobileSMS();
                    // bool r = true;
                    //  r = sms.SendSms(a, "hello");
                    Alert.Show("项目已审核，无法退回");
                }

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        //protected void Button_sy_Click(object sender, EventArgs e)
        //{
        //    ViewState["xmld"] = DropDownList1.SelectedText.Trim();
           
        //    databind();
        //}

        protected void Buttont_tj_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string zt = "";
            string date = "";
            string xmqs = "";
            string sqlstr = "";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";
                    zt += Grid1.DataKeys[rowIndex][2].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (Convert.ToInt32(zt)==2)
                {
                    sqlstr = "update JXBW set ZT=3 where ID=" + Convert.ToInt32(selectedID);
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
                    //string[] a=new string[1];
                    //a[0]="13661888094";
                    // SMS.MobileSMS sms= new SMS.MobileSMS();
                    // bool r = true;
                    //  r = sms.SendSms(a, "hello");
                    Alert.Show("该项目已经提交，无需重复提交");
                }

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }
    }
}