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
    public partial class XMGL_SZRT : System.Web.UI.Page
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


            sqlstr = "  select * from SZRT where user_uid='" + pb.GetIdentityId() + "' and SFSC!=1";
                    dt = DbHelperSQL.Query(sqlstr).Tables[0];
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
                    sqlstr = "update SZRT set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
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

            else if (e.CommandName == "up")
            {
                if (zt == "1" || zt == "4" || zt == "6")
                {
                    PageContext.RegisterStartupScript(Window1.GetShowReference("XMGL_SZRT_Up.aspx?xmbh="+xmbh, "查看申报书") + Window1.GetMaximizeReference());
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
                    string sqlstr = "update SZRT set ZT=2 where ID=" + Convert.ToInt32(selectedID);
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
                    string sqlstr = "update SZRT set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
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
                if (zt == "1")
                {
                    sqlstr = "update SZRT set ZT=2 where ID=" + Convert.ToInt32(selectedID);
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