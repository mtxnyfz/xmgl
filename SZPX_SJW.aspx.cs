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
    public partial class SZPX_SJW : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Button2.OnClientClick = Window1.GetShowReference("XMGL_Add.aspx", "退回申报项目");
                databind_DropDownList1();
                databind_DropDownList2();
                ViewState["xmld"] = "所有";
                ViewState["xxdm"] = "所有";
                databind();

                //string userid = pb.GetIdentityId();
                //string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
                //SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                //string xxdm = "", xxmc = "";
                //if (sdr.Read())
                //{
                //    xxdm = sdr["xxdm"].ToString().Trim();
                //    ViewState["xxdm"] = xxdm;

                //}
                //sdr.Dispose();
            }
        }

        protected void databind_DropDownList1()
        {


            //DropDownList1.Items.Clear();


            //DataTable dt = DbHelperSQL.Query("select ID, XMSBSMBMC from XMSBSMB").Tables[0];
            //DropDownList1.DataSource = dt;
            //DropDownList1.DataTextField = "XMSBSMBMC";
            //DropDownList1.DataValueField = "ID";
            //DropDownList1.DataBind();

            //DropDownList1.Items.Add("所有", "所有");
            //dp_setvalue(DropDownList1, "所有");





        }

        protected void databind_DropDownList2()
        {

            DropDownList2.Items.Clear();

            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select  xb_dm,xb_mc  FROM xb  order by xb_mc asc").Tables[0];
            DataTable dt = DbHelperSQL.Query("select  XXDM,XXMC  FROM XXJBQKB where xxdm!='000000'  order by XXMC").Tables[0];
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "XXMC";
            DropDownList2.DataValueField = "XXDM";
            DropDownList2.DataBind();
            DropDownList2.Items.Add("所有", "所有");

            dp_setvalue(DropDownList2, "所有");





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

        protected void databind()
        {
            string sqlstr = "";
            if (ViewState["xxdm"].ToString() == "所有")
            //sqlstr = "select * from YLZY  where SFSC!=1  and ZT>=3 and ZT!=4 order by XMBH";
            {
                sqlstr = "   select a.ID,a.XMMC,a.DWMC,a.XMBH,a.TBRQ,a.user_uid,'师资培训' as XMDL, a.ZT,b.XMBH,b.FJYSMX  FROM SZPX_XMSB as a  left join SZPX_FJYSMX as b ON b.XMBH = a.XMBH where a.SFSC!=1  and a.ZT>=3 and a.ZT!=4 and a.ZT!=6   order by a.XMBH";

                
                DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
                Grid1.DataSource = dt;
                Grid1.DataBind();

                Grid1.Hidden = false;




            }
            else
            //sqlstr = "select * from YLZY  where  SFSC!=1 and ZT>=3 and ZT!=4 and XXDM='" + ViewState["xxdm"].ToString() + "' order by XMBH";
            {

                sqlstr = "select a.ID,a.XMMC,a.DWMC,a.XMBH,a.TBRQ,a.user_uid,'师资培训' as XMDL, a.ZT,b.XMBH,b.FJYSMX  FROM SZPX_XMSB as a  left join SZPX_FJYSMX as b ON b.XMBH = a.XMBH    where a.SFSC!=1  and a.ZT>=3 and a.ZT!=4 and a.ZT!=6  and a.user_uid in (select user_uid from Users where xxdm = '" + ViewState["xxdm"].ToString() + "')  order by a.XMBH";

                
                DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
                Grid1.DataSource = dt;
                Grid1.DataBind();




            }

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




       


        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label uidlb = gr.FindControl("Label2") as System.Web.UI.WebControls.Label;

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



            if (!string.IsNullOrWhiteSpace(uidlb.Text.Trim()))
            {
                BLL.XXJBQKB XXJBQKB_BLL = new BLL.XXJBQKB();
                BLL.Users User_BLL= new BLL.Users();

                var User = User_BLL.GetModelList("user_uid = '"+uidlb.Text.Trim()+"'").FirstOrDefault();
                if (User != null)
                {
                    var model = XXJBQKB_BLL.GetModelList("XXDM = '" + User.xxdm + "'").FirstOrDefault();
                    uidlb.Text = model.XXMC;
                }
                else
                {
                    uidlb.Text = "";
                }
            }

        }



       
        protected void Button_sy_Click(object sender, EventArgs e)
        {

            ViewState["xxdm"] = DropDownList2.SelectedValue.Trim();
            databind();
        }


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);
            string xmbh = values[1].ToString().Trim();
            string xmmc = values[3].ToString().Trim();
            string zt = values[2].ToString().Trim();
            string selectedID = values[0].ToString().Trim();
            if (e.CommandName == "view")
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



            else if (e.CommandName == "back")
            {
                if (zt == "3")
                {
                    PageContext.RegisterStartupScript(Window1.GetShowReference("SZPX_YJFK_Add.aspx?xmbh=" + xmbh + "&xmmc=" + xmmc, "退回申报项目", 600, 450));
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
        }
    }
}