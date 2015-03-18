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
    public partial class user_add : System.Web.UI.Page
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
            DropDownList_xb.Items.Clear();

            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select  xb_dm,xb_mc  FROM xb  order by xb_mc asc").Tables[0];
            DataTable dt = DbHelperSQL.Query("select  XXDM,XXMC  FROM XXJBQKB  order by XXMC").Tables[0];
            DropDownList_xb.DataSource = dt;
            DropDownList_xb.DataTextField = "XXMC";
            DropDownList_xb.DataValueField = "XXDM";
            DropDownList_xb.DataBind();
            DropDownList_xb.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_xb, "请选择");

            //Grid1.DataSource = dt;
            //Grid1.DataBind();
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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string UserId = "", Name = "", Password = "", xxmc = "", xxdm = "", user_uid = "", tel = "", ActualName = "";
            user_uid = Guid.NewGuid().ToString();
            UserId = TextBox_jgh.Text.Trim();
            Name = UserId;
            //ActualName = TextBox_name.Text.Trim();
            Password = "111111";
            xxmc = DropDownList_xb.SelectedText.Trim();
            xxdm = DropDownList_xb.SelectedValue.Trim();
            //tel = TextBox_tel.Text.Trim();
            if (UserId == "")
            {
                Alert.Show("登录帐号为必填项！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }

            //if (ActualName == "")
            //{
            //    Alert.Show("姓名为必填项！", "提示", Alert.DefaultMessageBoxIcon);
            //    return;
            //}
            if (xxmc == "请选择" || xxdm == "")
            {
                Alert.Show("所属院校为必填项！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
            string sqlstr = "select * from Users where UserId='" + UserId + "'";
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
            if (sdr.Read())
            {
                sdr.Dispose();
                Alert.Show("登录帐号已存在！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
            sdr.Dispose();

            sqlstr = "insert into Users(user_uid,UserId,Name,Password,xxdm,xxmc,tel,ActualName) values('" + user_uid + "','" + UserId + "','" + Name + "','111111','" + xxdm + "','" + xxmc + "','" + tel + "','" + ActualName + "')";
            int state = DbHelperSQL.ExecuteSql(sqlstr);
            if (state != 0)
            {
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
        }
    }
}