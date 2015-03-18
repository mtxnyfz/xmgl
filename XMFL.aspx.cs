using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Newtonsoft.Json.Linq;
using AppBox;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using AspNet = System.Web.UI.WebControls;


namespace XMGL.Web.admin
{
    public partial class XMFL : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                databind();


            }
        }
        protected void databind()
        {

            string userid = pb.GetIdentityId();
            string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
            string xxdm = "", xxmc = "";
            if (sdr.Read())
            {
                xxdm = sdr["xxdm"].ToString().Trim();
                //ViewState["xxdm"] = xxdm;
                xxmc = sdr["xxmc"].ToString().Trim();
            }
            sdr.Dispose();
            DropDownList_xmfl.Items.Clear();
            DataTable dt = DbHelperSQL.Query("select XMSBSMB.XMSBSMBMC as XMSBSMBMC,SBYM from XMSBSMB_YX,XMSBSMB where XMSBSMB_YX.ID=XMSBSMB.ID and XMSBSMB_YX.XXDM='" + xxdm + "'").Tables[0];
            DropDownList_xmfl.DataSource = dt;
            DropDownList_xmfl.DataTextField = "XMSBSMBMC";
            DropDownList_xmfl.DataValueField = "SBYM";
            DropDownList_xmfl.DataBind();
            if (dt == null || dt.Rows.Count == 0)
            {
                DropDownList_xmfl.Items.Add("您没有可申报的项目大类可选", "您没有可申报的项目大类可选");
            }
            else
            {
                DropDownList_xmfl.Items.Add("请选择", "请选择");
                dp_setvalue(DropDownList_xmfl, "请选择");
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

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("XMGL_Add.aspx");
        }

        protected void DropDownList_xmfl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList_xmfl.SelectedValue.Trim() != "请选择")
                Response.Redirect(DropDownList_xmfl.SelectedValue.Trim());
        }
    }
}