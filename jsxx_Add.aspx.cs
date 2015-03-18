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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[0] != null)
                {
                    ViewState["ZRJSS"] = Request.QueryString[0];
                    ViewState["JZJSS"] = Request.QueryString[1];
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
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

            int _zrjss = 0, _jzjss = 0;
            //try
            //{
            //    _zrjss = Convert.ToInt32(ViewState["ZRJSS"].ToString().Trim());
            //}
            //catch
            //{
            //    Alert.ShowInTop("请先填写专任教师数");
            //    return;
            //}
          



            //try
            //{
            //    _jzjss = Convert.ToInt32(ViewState["JZJSS"].ToString().Trim());
            //}
            //catch
            //{
            //    Alert.ShowInTop("请先填写兼职教师数");
            //    return;
            //}

          
                //if (zjz == "1")
                //{
                //    if (_zrjss < 1)
                //    {
                //        Alert.ShowInTop("您添加的专任教师信息的条数和您输入的专任教师数的人数不一致");
                //        return;
                //    }
                //}

                //if (zjz == "2")
                //{
                //    if (_jzjss < 1)
                //    {
                //        Alert.ShowInTop("您添加的专任教师信息的条数和您输入的专任教师数的人数不一致");
                //        return;
                //    }
                //}

                string csny = DatePicker_csny.Text.Replace("-","");
                string jsxm=TextBox1_jsxm.Text.Trim();
                string sqlstr = "select JSXM from JSXXB where JSXM='" + jsxm + "' and CSNY like'%" + csny + "%'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);

             
                if (sdr.Read())
                {
                   
                    sdr.Dispose();
                    Alert.ShowInTop("您添加的专任教师信息在数据库中已存在，请在前一个页面中输入姓名后选中即可");
                    return;

                }
                else
               sdr.Dispose();
                

                dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("jsxm");
                dt.Columns.Add("csny");
                dt.Columns.Add("zjz");
                dt.Columns.Add("sfss");
                dt.Columns.Add("xl");
                dt.Columns.Add("xw");
                dt.Columns.Add("zcdj");

                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["jsxm"] = TextBox1_jsxm.Text.Trim();
                dr["csny"] = DatePicker_csny.Text;
                dr["zjz"] = zjz;
                dr["sfss"] = sfss;
                dr["xl"] = xl;
                dr["xw"] = xw;
                dr["zcdj"] = zcdj;
                Session["dr"] = dr;
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        
           
           
        }


        protected int Getzjzrs(string zjz, DataTable dt)
        {
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["zjz"].ToString().Trim() == zjz)
                    count++;
            }
            return count;
        }
    }
}