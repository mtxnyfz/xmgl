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
    public partial class jsxx_Add : System.Web.UI.Page
    {
        Model.JSXX jsxx_model = new Model.JSXX();
        BLL.JSXX jsxx_bll = new BLL.JSXX();

        Model.YLZY ylzy_model = new Model.YLZY();
        BLL.YLZY ylzy_bll = new BLL.YLZY();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[0] != null)
                {
                    //ViewState["ZRJSS"] = Request.QueryString[0];
                    //ViewState["JZJSS"] = Request.QueryString[1];
                    ViewState["XMBH"] = Request.QueryString[0];
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsAdd = false;
                string jsxm = TextBox1_jsxm.Text.Trim();
                if (jsxm == "")
                {
                    Alert.Show("教师姓名为必选项");
                    return;
                }
                jsxx_model = jsxx_bll.GetModel(ViewState["XMBH"].ToString(), jsxm);
                if (jsxx_model == null)//新增
                {
                    IsAdd = true;
                    jsxx_model = new Model.JSXX();
                }
                string zjz = DropDownList_zjz.SelectedValue;
                string sfss = DropDownList_ss.SelectedValue;
                string xl = DropDownList_xl1.SelectedValue;
                string xw = DropDownList_xw1.SelectedValue;
                string zcdj = DropDownList_zcdj1.SelectedValue;
                if (zjz == "请选择")
                {
                    Alert.ShowInTop("请选择专/兼职");
                    return;
                }
                if (sfss == "请选择")
                {
                    Alert.ShowInTop("请选择是否双师");
                    return;
                }
                if (xl == "请选择")
                {
                    Alert.ShowInTop("请选择学历");
                    return;
                }
                if (xw == "请选择")
                {
                    Alert.ShowInTop("请选择学位");
                    return;
                }
                if (zcdj == "请选择")
                {
                    Alert.ShowInTop("请选择职称等级");
                    return;
                }

                jsxx_model.XXDM = Session["xxdm"].ToString();
                jsxx_model.XMBH = ViewState["XMBH"].ToString();
                jsxx_model.JSXM = jsxm;
                jsxx_model.CSNY = DatePicker_csny.Text.Replace("-", "");
                jsxx_model.ZZJZ =int.Parse( zjz);
                jsxx_model.SFSS = int.Parse(sfss);
                jsxx_model.XL = xl;
                jsxx_model.XW = xw;
                jsxx_model.ZCDJ = zcdj;
                if (IsAdd)
                {
                    if (jsxx_bll.Add(jsxx_model) > 0)
                    {
                        ylzy_model = ylzy_bll.GetModel(Session["xxdm"].ToString(), ViewState["XMBH"].ToString());
                        if (ylzy_model == null)
                        {
                            ylzy_model = new Model.YLZY();
                            ylzy_model.XMBH = ViewState["xmbh"].ToString();
                            ylzy_model.XXDM = Session["xxdm"].ToString();
                            ylzy_bll.Add(ylzy_model);
                        }
                        Alert.Show("添加成功");
                    }
                        
                }
                else
                {
                    if ( jsxx_bll.Update(jsxx_model)==true)
                        Alert.Show("添加成功");
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                //return false;
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        //protected int Getzjzrs(string zjz, DataTable dt)
        //{
        //    int count = 0;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (dt.Rows[i]["zjz"].ToString().Trim() == zjz)
        //            count++;
        //    }
        //    return count;
        //}
    }
}