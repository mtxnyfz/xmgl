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
    public partial class XM_ZJSZ : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["xmbh"] != null)
                {
                    ViewState["xmbh"] = Request.QueryString["xmbh"].ToString().Trim();
                    Session["xmbh"] = Request.QueryString["xmbh"].ToString().Trim();
                    ViewState["xmmc"] = Request.QueryString["xmmc"].ToString().Trim();
                    ViewState["key1"] = "all";
                    ViewState["key2"] = "all";
                    DatePicker_ksrq.Text = DateTime.Now.ToString("yy-MM-dd");
                    databind();

                }
            }
        }
        protected void databind()
        {
            string sqlstr = "";
            DataTable dt = null;
            if (ViewState["key1"].ToString() == "all" && ViewState["key2"].ToString() == "all")
                sqlstr = "select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX and Experts_ID not in(select ZJID from XM_ZJSZ where XMBH='" + ViewState["xmbh"].ToString() + "')";
            else if (ViewState["key1"].ToString() == "all" && ViewState["key2"].ToString() != "all")
            {
                sqlstr = "select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX and Experts_ID not in(select ZJID from XM_ZJSZ where XMBH='" + ViewState["xmbh"].ToString() + "') and XMGL_ZJB.Experts_ZJLX=" + ViewState["key2"];
            }
            else if (ViewState["key1"].ToString() != "all" && ViewState["key2"].ToString() == "all")
            {
                sqlstr = "select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX and Experts_ID not in(select ZJID from XM_ZJSZ where XMBH='" + ViewState["xmbh"].ToString() + "') and XMGL_ZJB.Experts_ZJLY=" + ViewState["key1"];
            }
            else
            {
                sqlstr = "select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX and Experts_ID not in(select ZJID from XM_ZJSZ where XMBH='" + ViewState["xmbh"].ToString() + "') and XMGL_ZJB.Experts_ZJLY=" + ViewState["key1"] + "  and XMGL_ZJB.Experts_ZJLX=" + ViewState["key2"];
            }
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
            pb.UpdateSelectedRowIndexArray(hfSelectedIDS1, Grid1);
        }


        protected void databind1()
        {
            string sqlstr = "";
            DataTable dt = null;
            if (TextBox_key.Text.Trim() != "")
            {
                sqlstr = "select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX and Experts_Name like'%" + TextBox_key.Text.Trim() + "%' and Experts_ID not in(select ZJID from XM_ZJSZ where XMBH='" + ViewState["xmbh"].ToString() + "')";

                dt = DbHelperSQL.Query(sqlstr).Tables[0];
                Grid1.DataSource = dt;
                Grid1.DataBind();
                pb.UpdateSelectedRowIndexArray(hfSelectedIDS1, Grid1);
            }
        }

        protected void databind2()
        {
            string sqlstr = "";
            DataTable dt = null;

            sqlstr = "select a.Experts_ID,a.Experts_Name,a.Experts_Sex,a.Experts_Mobil,a.ZJLX_Name,b.JSRQ from (select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX) as a,XM_ZJSZ as b where a.Experts_ID=b.ZJID and b.XMBH='" + ViewState["xmbh"].ToString() + "'";
            
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid2.DataSource = dt;
            Grid2.DataBind();
            pb.UpdateSelectedRowIndexArray(hfSelectedIDS2, Grid2);
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            Grid1.PageIndex = e.NewPageIndex;
          
            databind();
        }
        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS2, Grid2);
            Grid2.PageIndex = e.NewPageIndex;

            databind2();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);



            if (e.CommandName == "xq")
            {
                string Experts_ID = values[0].ToString();
                string Experts_Name = values[1].ToString();
                PageContext.RegisterStartupScript(Window1.GetShowReference("Savant/Savant_Show.aspx?id=" + Experts_ID, Experts_Name));

            }
        }
        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid2.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);



            if (e.CommandName == "xq")
            {
                string Experts_ID = values[0].ToString();
                string Experts_Name = values[1].ToString();
                PageContext.RegisterStartupScript(Window1.GetShowReference("Savant/Savant_Show.aspx?id=" + Experts_ID, Experts_Name));

            }
        }

        private void SyncSelectedRowIndexArrayToHiddenField(FineUI.HiddenField hd, FineUI.Grid grid)
        {
            // 重新绑定表格数据之前，将当前表格页选中行的数据同步到隐藏字段中
            pb.SyncSelectedRowIndexArrayToHiddenField(hd, grid);
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
        protected void TabStrip1_TabIndexChanged(object sender, EventArgs e)
        {
            if (TabStrip1.ActiveTabIndex == 0)
            {
                databind();
            }
            else if (TabStrip1.ActiveTabIndex == 1)
            {
                databind2();
            }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Trim() != "请选择")
                ViewState["key1"] = DropDownList1.SelectedValue.Trim();
            else
                ViewState["key1"] ="all";

            databind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue.Trim() != "请选择")
                ViewState["key2"] = DropDownList2.SelectedValue.Trim();
            else
                ViewState["key2"] = "all";
            databind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetShowReference("Savant/Savant_Add.aspx"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string date1 = DatePicker_ksrq.Text.Trim();
            string date2 = DatePicker_jsrq.Text.Trim();
            if (date1 == "")
            {
                Alert.Show("登录账号生效日期不能为空", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
            if (date2 == "")
            {
                Alert.Show("登录账号失效日期不能为空", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
            //DateTime nowdate = Convert.ToDateTime(DateTime.Now.ToString("yy-MM-dd"));
            if (DateTime.Compare(Convert.ToDateTime(date1), Convert.ToDateTime(date2)) > 0)
            {
                Alert.Show("登录账号生效日期不能大于登录账号失效日期", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
           
            List<string> ids = null;
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS1, Grid1);
            ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS1);
            string sqlstr = "";
            string user_uid = "", Password = "", Name="",mobile="";
            SqlDataReader sdr = null;
            int flag = 1, ysh = 0, state=0;
            if (ids != null)
            {
                if (ids.Count > 0)
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        user_uid = ids[i];
                        sqlstr = "select Experts_ID,Experts_Name,Experts_Mobil from XMGL_ZJB where Experts_ID=" + int.Parse(ids[i]);
                        sdr = DbHelperSQL.ExecuteReader(sqlstr);
                        if (sdr.Read())
                        {
                            Name = sdr["Experts_Name"].ToString().Trim();
                            mobile = sdr["Experts_Mobil"].ToString().Trim();
                          
                           
                            //sdr.Close();

                        }
                        sdr.Dispose();

                        sqlstr = "delete from XM_ZJSZ where ZJID='" + user_uid + "' and XMBH='" + ViewState["xmbh"].ToString() + "'";
                        state = DbHelperSQL.ExecuteSql(sqlstr);
                        sqlstr = "insert into XM_ZJSZ(ZJID,XMBH,KSRQ,JSRQ,ZT) values('" + user_uid + "','" + ViewState["xmbh"].ToString() + "','" + date1 + "','" + date2 + "',0)";
                        state = DbHelperSQL.ExecuteSql(sqlstr);
                        if (state < 1)
                        {
                            databind();
                            Alert.Show("姓名为：" + Name + "的专家分配到该项目失败", "提示", Alert.DefaultMessageBoxIcon);
                            return;
                        }
                        sqlstr = "select * from Users where user_uid='" + user_uid + "'";
                        sdr = DbHelperSQL.ExecuteReader(sqlstr);
                        if (sdr.Read())
                        {
                          

                        }
                        else
                        {

                            Password = "111111";
                            if (Password == "")
                            {
                                Password = "111111";
                            }
                            sqlstr = "insert into Users(user_uid,UserId,Name,Password,ActualName,mobile) values('" + user_uid + "','" + Name + "','" + Name + "','" + Password + "','" + Name + "','" + mobile + "')";
                             state = DbHelperSQL.ExecuteSql(sqlstr);
                            if (state < 1)
                            {
                                hfSelectedIDS1.Text = "";
                                databind();
                                Alert.Show("姓名为：" + Name+"的专家添加失败", "提示", Alert.DefaultMessageBoxIcon);
                                return;
                            }

                            sqlstr = "insert into RoleUser(RoleId,UserId) values('3','" + user_uid + "')";
                            state = DbHelperSQL.ExecuteSql(sqlstr);
                            if (state < 1)
                            {
                              
                              
                                Alert.Show("姓名为：" + Name + "的专家添加到“评审专家”角色中失败", "提示", Alert.DefaultMessageBoxIcon);
                                return;
                            }
                        }
                        sdr.Dispose();

                        
                    }
                    Alert.Show("操作成功", "提示", Alert.DefaultMessageBoxIcon);
                    hfSelectedIDS1.Text = "";
                    databind();
                   

                }
                else
                {
                    Alert.Show("没有选择数据");
                }

            }
            else
            {
                Alert.Show("没有选择数据");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> ids = null;
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS2, Grid2);
            ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS2);
            string sqlstr = "";
            string user_uid = "", Password = "", Name = "", mobile = "";
            SqlDataReader sdr = null;
            int flag = 1, ysh = 0, state = 0;
            if (ids != null)
            {
                if (ids.Count > 0)
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        user_uid = ids[i];

                        sqlstr = "select Experts_ID,Experts_Name,Experts_Mobil from XMGL_ZJB where Experts_ID=" + int.Parse(ids[i]);
                        sdr = DbHelperSQL.ExecuteReader(sqlstr);
                        if (sdr.Read())
                        {
                            Name = sdr["Experts_Name"].ToString().Trim();
                            mobile = sdr["Experts_Mobil"].ToString().Trim();


                            //sdr.Close();

                        }
                        sdr.Dispose();
                        sqlstr = "delete from XM_ZJSZ where ZJID='" + user_uid + "' and XMBH='" + ViewState["xmbh"].ToString() + "'";
                        state = DbHelperSQL.ExecuteSql(sqlstr);
                      
                        if (state < 1)
                        {
                            hfSelectedIDS2.Text = "";
                            databind2();
                           
                            Alert.Show("姓名为：" + Name + "的专家从该项目中移除失败", "提示", Alert.DefaultMessageBoxIcon);
                            return;
                        }
                       

                    }
                    Alert.Show("操作成功", "提示", Alert.DefaultMessageBoxIcon);
                    hfSelectedIDS2.Text = "";
                    databind2();


                }
                else
                {
                    Alert.Show("没有选择数据");
                }

            }
            else
            {
                Alert.Show("没有选择数据");
            }
        }


        protected void Grid2_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            string name= Grid2.DataKeys[e.RowIndex][1].ToString();
            DateTime jsrq = Convert.ToDateTime(Grid2.DataKeys[e.RowIndex][2].ToString()).AddDays(1);
            div1.InnerHtml = name + "专家，您好！现有“" + ViewState["xmmc"].ToString() + "”项目需要您参与相关的评审工作，请使用用户名：" + name + ",及登记的手机号：" + Grid2.DataKeys[e.RowIndex][3].ToString() + "，于" + jsrq.ToString("yyyy-MM-dd") + "前登录“http://www.gzgz.edu.sh.cn/login_zj.aspx”,完成相关工作。过时将不能登录系统评审。感谢您对我们工作的支持。(上海市教委高教处)";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            List<string> ids = null;
            SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS2, Grid2);
            ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS2);
            string sqlstr = "";
            DataTable dt = null;
            string user_uid = "", Password = "", Name = "", mobile = "";
            SqlDataReader sdr = null;
            int flag = 1, ysh = 0, state = 0;
            if (ids != null)
            {
                if (ids.Count > 0)
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        user_uid = ids[i];
                    }
                }
                else
                {

                }
            }
            else
            {
               

                sqlstr = "select a.Experts_ID,a.Experts_Name,a.Experts_Sex,a.Experts_Mobil,a.ZJLX_Name,b.JSRQ from (select Experts_ID, Experts_Name,Experts_Sex,Experts_Mobil,ZJLX_Name from XMGL_ZJB,XMGL_ZJLXB where XMGL_ZJLXB.ZJLX_ID=XMGL_ZJB.Experts_ZJLX) as a,XM_ZJSZ as b where a.Experts_ID=b.ZJID and b.XMBH='" + ViewState["xmbh"].ToString() + "'";

                dt = DbHelperSQL.Query(sqlstr).Tables[0];
            }
            Alert.Show("开发中。。。");
        }

        protected void TextBox_key_TextChanged(object sender, EventArgs e)
        {
            databind1();
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            databind();
            Alert.Show("添加成功");
        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            GridRow gr = Grid1.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;
            string ZJID = values[0].ToString().Trim();
            string nowdate = DateTime.Now.ToString("yyyy-MM-dd");
            string jjcs = "0";
            string sqlstr = "  select count(*) from (select  ZJID,JSRQ FROM [XM_ZJSZ] where ZJID='"+ZJID+"' and(ZT is null or ZT=0) and jsrq<'"+nowdate+"' group by ZJID,JSRQ) as a";
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
            if (sdr.Read())
            {
                jjcs=sdr[0].ToString();
            }
            sdr.Close();
            lb.Text = jjcs;
        }
    }
}