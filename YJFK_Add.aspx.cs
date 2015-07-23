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

namespace XMGL.Web.admin
{
    public partial class YJFK_Add : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[1] != null)
                {
                    Label_xmmc.Text = Request.QueryString[1].ToString();
                    ViewState["xmbh"] = Request.QueryString[0].ToString();
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Model.SHYJ SHYJ_Model = new Model.SHYJ();
            SHYJ_Model.XMBH = ViewState["xmbh"].ToString();
            SHYJ_Model.YJ = TextArea_yj.Text.Trim();
            SHYJ_Model.SHRID = pb.GetIdentityId();
            SHYJ_Model.SHRSF = "市教委";
            BLL.SHYJ SHYJ_Bll = new BLL.SHYJ();
          
            try
            {
                if (SHYJ_Bll.Add(SHYJ_Model) > 0)
                {
                    string sqlstr = "";
                    if (ViewState["xmbh"].ToString().Contains("2015-01"))
                    {
                        sqlstr = "update YLZY set SFSC=0, ZT=6 where XMBH='" + ViewState["xmbh"].ToString() + "'";
                    }
                    else if (ViewState["xmbh"].ToString().Contains("2015-02"))
                    {
                        sqlstr = "update SZRT set SFSC=0, ZT=6 where XMBH='" + ViewState["xmbh"].ToString() + "'";
                    }
                    else if (ViewState["xmbh"].ToString().Contains("2015-03"))
                    {
                        sqlstr = "update CJYXTJD_XM set SFSC=0, ZT=6 where XMBH='" + ViewState["xmbh"].ToString() + "'";
                    }
                    else if (ViewState["xmbh"].ToString().Contains("2015-05"))
                    {
                        sqlstr = "update JSJNJS_XM set SFSC=0, ZT=6 where XMBH='" + ViewState["xmbh"].ToString() + "'";
                    }
                    else if (ViewState["xmbh"].ToString().Contains("2015-06"))
                    {
                        sqlstr = "update XXGLPT_XM set SFSC=0, ZT=6 where XMBH='" + ViewState["xmbh"].ToString() + "'";
                    }
                    else if (ViewState["xmbh"].ToString().Contains("2015-07"))
                    {
                        sqlstr = "update TYL_XM set SFSC=0, ZT=6 where XMBH='" + ViewState["xmbh"].ToString() + "'";
                    }
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                       
                       
                    }
                    else
                    {
                       
                        Alert.Show("操作失败");
                        return;
                    }
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }
                else
                {

                    Alert.ShowInTop("操作失败");
                    return;
                }
            }
            catch (Exception ex)
            {
               
                Alert.ShowInTop(ex.Message);
                return;
            }

        }
    }
}