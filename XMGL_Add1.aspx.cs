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
    public partial class XMGL_Add1 : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DatePicker_yqwcsj.MinDate = DateTime.Now.AddDays(1);
                //DatePicker_yqwcsj.MaxDate = DateTime.Now.AddDays(1);
                DatePicker_sqzxjfzxjsrq.MinDate = DateTime.Now.AddDays(1);
                
                //DatePicker_sqzxjfzxksrq.MaxDate = DateTime.Now.AddDays(1);
                DatePicker_xxptjfzxjsrq.MinDate = DateTime.Now.AddDays(1);
                //DatePicker_xxptjfzxjsrq.MaxDate = DateTime.Now.AddDays(1);
               
                //ViewState["xmbh"] = AutoNumber("2015-01-");
                string userid = pb.GetIdentityId();
                string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string xxdm = "", xxmc = "";
                if (sdr.Read())
                {
                    xxdm = sdr["xxdm"].ToString().Trim();
                    ViewState["xxdm"] = xxdm;
                    Session["xxdm"] = xxdm;
                    xxmc = sdr["xxmc"].ToString().Trim();
                }
                sdr.Dispose();
                sqlstr = "select * from XXJBQKB where XXDM='" + xxdm + "'";
                sdr = DbHelperSQL.ExecuteReader(sqlstr);

                if (sdr.Read())
                {
                    TextBox_jbf.Text = sdr["JBF"].ToString().Trim();
                    TextBox_xxzx.Text = sdr["XXXZ"].ToString().Trim();
                    TextBox_txdz.Text = sdr["TXDZ"].ToString().Trim();
                    TextBox_yb.Text = sdr["YB"].ToString().Trim();
                    TextBox_xxwz.Text = sdr["XXWZ"].ToString().Trim();
                    TextBox_frdbxm.Text = sdr["FRDBXM"].ToString().Trim();
                    TextBox_frdbzw.Text = sdr["FRDBZW"].ToString().Trim();
                    TextBox_frdbbgsdh.Text = sdr["FRDBBGSDH"].ToString().Trim();

                    TextBox_frdbcz.Text = sdr["FRDBCZ"].ToString().Trim();
                    TextBox_frdbsj.Text = sdr["FRDBSJ"].ToString().Trim();
                    TextBox_frdbdzyx.Text = sdr["FRDBDZYX"].ToString().Trim();
                    TextBox_LXRXM.Text = sdr["LXRXM"].ToString().Trim();

                    TextBox_LXRZW.Text = sdr["LXRZW"].ToString().Trim();
                    TextBox_LXRBGSDH.Text = sdr["LXRBGSDH"].ToString().Trim();
                    TextBox_LXRCZ.Text = sdr["LXRCZ"].ToString().Trim();
                    LXRSJ.Text = sdr["LXRSJ"].ToString().Trim();
                    LXRDZYX.Text = sdr["LXRDZYX"].ToString().Trim();
                }
                sdr.Dispose();
                TextBox_xxmc.Text = xxmc;
                databind_zymc();
            }
        }

        protected void databind_zymc()
        {
            ZYMC.Items.Clear();

            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select  xb_dm,xb_mc  FROM xb  order by xb_mc asc").Tables[0];
            //DataTable dt = DbHelperSQL.Query("select distinct ID, ZYDM,ZYMC  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "'  order by ZYMC").Tables[0];
            //DataTable dt = DbHelperSQL.Query("select distinct  ZYDM,ZYMC  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "'  order by ZYMC").Tables[0];
            DataTable dt = DbHelperSQL.Query("SELECT distinct [ZYDM]  ,[ZYMC] ,[ZYFXDM] ,[ZYFXMC]  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "' and ZYDM is not null  order by ZYMC").Tables[0];

            //DataTable dt_new = dt.Copy();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ZYFXMC"].ToString().Trim() != "")
                {
                    if (dt.Rows[i]["ZYFXDM"].ToString().Trim() == "")
                    {
                        dt.Rows[i]["ZYDM"] = dt.Rows[i]["ZYDM"].ToString().Trim() + "," +"@"+ i.ToString();
                    }
                    else
                    {
                        dt.Rows[i]["ZYDM"] = dt.Rows[i]["ZYDM"].ToString().Trim() + "," + dt.Rows[i]["ZYFXDM"].ToString().Trim();
                    }
                    dt.Rows[i]["ZYMC"] = dt.Rows[i]["ZYFXMC"].ToString().Trim();
                        
                }
                
            }

            ZYMC.DataSource = dt;
            ZYMC.DataTextField = "ZYMC";
            ZYMC.DataValueField = "ZYDM";
            ZYMC.DataBind();
            ZYMC.Items.Add("请选择", "请选择");

            dp_setvalue(ZYMC, "请选择");

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
        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = null;
            //if (ViewState["dt1"] == null)
            //{
            //    dt = new DataTable();
            //    dt.Columns.Add("id");
            //    dt.Columns.Add("nf");
            //    dt.Columns.Add("NumberBox_sjzss");
            //    dt.Columns.Add("NumberBox_xsbdl");
            //    dt.Columns.Add("NumberBox_qrzzxss");
            //    dt.Columns.Add("NumberBox_ddpyrs");
            //    dt.Columns.Add("NumberBox_byss");
            //    dt.Columns.Add("NumberBox_ccjyl");

            //    DataRow dr = dt.NewRow();
            //    dr["id"] = Guid.NewGuid().ToString();
            //    dr["nf"] = DropDownList_nf.SelectedValue.Trim();
            //    dr["NumberBox_sjzss"] = NumberBox_sjzss.Text;
            //    dr["NumberBox_xsbdl"] = NumberBox_xsbdl.Text;
            //    dr["NumberBox_qrzzxss"] = NumberBox_qrzzxss.Text;
            //    dr["NumberBox_ddpyrs"] = NumberBox_ddpyrs.Text;
            //    dr["NumberBox_byss"] = NumberBox_byss.Text;
            //    dr["NumberBox_ccjyl"] = NumberBox_ccjyl.Text;
            //    dt.Rows.Add(dr);
            //}
            //else
            //{
            //    string nf = DropDownList_nf.SelectedValue.Trim();
            //    dt = ViewState["dt1"] as DataTable;
            //    if (!DataExist(nf))
            //    {


            //        DataRow dr = dt.NewRow();
            //        dr["id"] = Guid.NewGuid().ToString();
            //        dr["nf"] = DropDownList_nf.SelectedValue.Trim();
            //        dr["NumberBox_sjzss"] = NumberBox_sjzss.Text;
            //        dr["NumberBox_xsbdl"] = NumberBox_xsbdl.Text;
            //        dr["NumberBox_qrzzxss"] = NumberBox_qrzzxss.Text;
            //        dr["NumberBox_ddpyrs"] = NumberBox_ddpyrs.Text;
            //        dr["NumberBox_byss"] = NumberBox_byss.Text;
            //        dr["NumberBox_ccjyl"] = NumberBox_ccjyl.Text;
            //        dt.Rows.Add(dr);
            //    }
            //    else
            //    {

            //        Alert.ShowInTop(nf + "年数据已经添加过了，无需重复添加");

            //    }
            //}
            //DataView dv = new DataView(dt);
            //dv.Sort = "nf asc";
            //Grid1.DataSource = dv;
            //Grid1.DataBind();
            //ViewState["dt1"] = dt;

        }

        protected bool DataExist(string nf)
        {
            DataTable dt = ViewState["dt1"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["nf"].ToString().Trim() == nf)
                    return true;
            }
            return false;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            //string zjz = DropDownList_zjz.SelectedValue;
            //string sfss = DropDownList_ss.SelectedValue;
            //string xl = DropDownList_xl1.SelectedValue;
            //string xw = DropDownList_xw1.SelectedValue;
            //string zcdj = DropDownList_zcdj1.SelectedValue;
            string zjz = DropDownList_zjz1.Text.Trim();
            string sfss = DropDownList_ss1.Text.Trim();
            string xl = DropDownList_xl11.Text.Trim();
            string xw = DropDownList_xw11.Text.Trim();
            string zcdj = DropDownList_zcdj11.Text.Trim();
            if (zjz == "专职")
                zjz = "1";
            else if (zjz == "兼职")
                zjz = "2";
            else
                zjz = "5";
            if (sfss == "是")
                sfss = "1";
            else if (sfss == "否")
                sfss = "0";
            else
                sfss = "5";
            //if (zjz == "请选择")
            //{
            //    Alert.ShowInTop("请选择专/兼职");
            //    return;
            //}
            //if (sfss == "请选择")
            //{
            //    Alert.ShowInTop("请选择是否双师");
            //    return;
            //}
            //if (xl == "请选择")
            //{
            //    Alert.ShowInTop("请选择学历");
            //    return;
            //}
            //if (xw == "请选择")
            //{
            //    Alert.ShowInTop("请选择学位");
            //    return;
            //}
            //if (zcdj == "请选择")
            //{
            //    Alert.ShowInTop("请选择职称等级");
            //    return;
            //}

            int _zrjss = 0, _jzjss = 0;
            try
            {
                _zrjss = Convert.ToInt32(ZRJSS.Text.Trim());
            }
            catch
            {
                Alert.ShowInTop("请先填写专任教师数");
                return;
            }
            //if (_zrjss <= 0)
            //{
            //    Alert.ShowInTop("请先填写专任教师数");
            //    return;
            //}
            


            try
            {
                _jzjss = Convert.ToInt32(JZJSS.Text.Trim());
            }
            catch
            {
                Alert.ShowInTop("请先填写兼职教师数");
                return;
            }

            //if (_jzjss <= 0)
            //{
            //    Alert.ShowInTop("请先填写兼职教师数");
            //    return;
            //}

            if (ViewState["dt2"] == null)
            {
                if (zjz == "1")
                {
                    if (_zrjss < 1)
                    {
                        Alert.ShowInTop("您添加的专任教师信息的条数和您输入的专任教师数的人数不一致");
                        return;
                    }
                }

                if (zjz == "2")
                {
                    if (_jzjss < 1)
                    {
                        Alert.ShowInTop("您添加的专任教师信息的条数和您输入的专任教师数的人数不一致");
                        return;
                    }
                }

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
                dt.Rows.Add(dr);
            }
            else
            {
                //string nf = DropDownList_nf.SelectedValue.Trim();
                dt = ViewState["dt2"] as DataTable;
                //int _zrjss = 0,_jzjss=0;
                //try
                //{
                //    _zrjss = Convert.ToInt32(ZRJSS.Text.Trim());
                //}
                //catch
                //{
                //    Alert.ShowInTop("请先填写专任教师数");
                //    return;
                //}

                //try
                //{
                //    _zrjss = Convert.ToInt32(ZRJSS.Text.Trim());
                //}
                //catch
                //{
                //    Alert.ShowInTop("请先填写兼职教师数");
                //    return;
                //}
                if (zjz == "1")
                {
                    if (Getzjzrs("1", dt) >= _zrjss)
                    {
                        Alert.ShowInTop("您添加的专任教师信息的条数和您输入的专任教师数的人数不一致");
                        return;
                    }
                }
                else if (zjz == "2")
                {
                    if (Getzjzrs("2", dt) >= _jzjss)
                    {
                        Alert.ShowInTop("您添加的兼职教师信息的条数和您输入的兼职教师数的人数不一致");
                        return;
                    }
                }
                
               

                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["jsxm"] = TextBox1_jsxm.Text.Trim();
                dr["csny"] = DatePicker_csny.Text;
                dr["zjz"] = zjz;
                dr["sfss"] = sfss;
                dr["xl"] = xl;
                dr["xw"] = xw;
                dr["zcdj"] = zcdj;
                dt.Rows.Add(dr);
                //if (!DataExist(nf))
                //{


                //    DataRow dr = dt.NewRow();
                //    dr["nf"] = DropDownList_nf.SelectedValue.Trim();
                //    dr["NumberBox_sjzss"] = NumberBox_sjzss.Text;
                //    dr["NumberBox_xsbdl"] = NumberBox_xsbdl.Text;
                //    dr["NumberBox_qrzzxss"] = NumberBox_qrzzxss.Text;
                //    dr["NumberBox_ddpyrs"] = NumberBox_ddpyrs.Text;
                //    dr["NumberBox_byss"] = NumberBox_byss.Text;
                //    dr["NumberBox_ccjyl"] = NumberBox_ccjyl.Text;
                //    dt.Rows.Add(dr);
                //}
                //else
                //{

                //    Alert.ShowInTop(nf + "年数据已经添加过了，无需重复添加");

                //}
            }
            Grid2.DataSource = dt;
            Grid2.DataBind();
            ViewState["dt2"] = dt;
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
        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            if (ViewState["dt3"] == null)
            {
                dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("jsmb");
                dt.Columns.Add("yqwcsj");
                dt.Columns.Add("ysyd");


                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["jsmb"] = TextArea_jsmb.Text.Trim();
                dr["yqwcsj"] = DatePicker_yqwcsj.Text.Trim();
                dr["ysyd"] = TextArea_ysyd.Text.Trim();

                dt.Rows.Add(dr);
            }
            else
            {
                //string nf = DropDownList_nf.SelectedValue.Trim();
                dt = ViewState["dt3"] as DataTable;
                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["jsmb"] = TextArea_jsmb.Text.Trim();
                dr["yqwcsj"] = DatePicker_yqwcsj.Text.Trim();
                dr["ysyd"] = TextArea_ysyd.Text.Trim();
                dt.Rows.Add(dr);
               
            }
            Grid3.DataSource = dt;
            Grid3.DataBind();
            ViewState["dt3"] = dt;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            string zytd = "";
            int kszs = 1;
            if (SFKSZS.SelectedIndex == 0)
                kszs = 1;
            else if (SFKSZS.SelectedIndex == 1)
                kszs = 0;
            else
            {
                Alert.Show("是否跨省招生为必选项");
                return;
            }
            if (RadioButtonList_zytd.SelectedIndex >=0)
            {
                zytd = RadioButtonList_zytd.SelectedValue.Trim();
            }
            else
            {
                Alert.Show("专业特点为必选项");
                return;
            }

            //if (CheckBox1.Checked)
            //    zytd = "国际领先型";
            //if (CheckBox2.Checked)
            //{
            //    if (zytd != "")
            //        zytd = zytd + "，民生需求型";
            //    else
            //        zytd = "民生需求型";
            //}
            //if (CheckBox3.Checked)
            //{
            //    if (zytd != "")
            //        zytd = zytd + "，行业特色型";
            //    else
            //        zytd = "行业特色型";
            //}

            //if (zytd == "")
            //{
            //    Alert.Show("请选择专业特点");
            //    return;
            //}

            Model.YLZY YLZY_Model = new Model.YLZY();
            Model.XXJBQK XXJBQK_Model = new Model.XXJBQK();
            Model.ZYZSJYQK ZYZSJYQK_Model = new Model.ZYZSJYQK();
            Model.JSXX JSXX_Model = new Model.JSXX();
            Model.YSZB YSZB_Model = new Model.YSZB();
            Model.JFYS JFYS_Model = new Model.JFYS();

            BLL.YLZY YLZY_Bll = new BLL.YLZY();
            BLL.XXJBQK XXJBQK_Bll = new BLL.XXJBQK();
            BLL.ZYZSJYQK ZYZSJYQK_Bll = new BLL.ZYZSJYQK();
            BLL.JSXX JSXX_Bll = new BLL.JSXX();
            BLL.YSZB YSZB_Bll = new BLL.YSZB();
            BLL.JFYS JFYS_Bll = new BLL.JFYS();

            YLZY_Model.XMBH = AutoNumber("2015-01-");
            ViewState["xmbh"] = YLZY_Model.XMBH;
            YLZY_Model.XXDM = ViewState["xxdm"].ToString();
            YLZY_Model.XMMC = TextBox_xmmc.Text.Trim();

            XXJBQK_Model.JBF = TextBox_jbf.Text.Trim();
            XXJBQK_Model.XXXZ = TextBox_xxzx.Text.Trim();
            XXJBQK_Model.TXDZ = TextBox_txdz.Text.Trim();
            XXJBQK_Model.YB = TextBox_yb.Text.Trim();
            XXJBQK_Model.XXWZ = TextBox_xxwz.Text.Trim();
            XXJBQK_Model.FRDBXM = TextBox_frdbxm.Text.Trim();
            XXJBQK_Model.FRDBZW = TextBox_frdbzw.Text.Trim();
            XXJBQK_Model.FRDBBGSDH = TextBox_frdbbgsdh.Text.Trim();
            XXJBQK_Model.FRDBCZ = TextBox_frdbcz.Text.Trim();
            XXJBQK_Model.FRDBSJ = TextBox_frdbsj.Text.Trim();
            XXJBQK_Model.FRDBDZYX = TextBox_frdbdzyx.Text.Trim();
            XXJBQK_Model.LXRXM = TextBox_LXRXM.Text.Trim();
            XXJBQK_Model.LXRZW = TextBox_LXRZW.Text.Trim();
            XXJBQK_Model.LXRBGSDH = TextBox_LXRBGSDH.Text.Trim();
            XXJBQK_Model.LXRCZ = TextBox_LXRCZ.Text.Trim();
            XXJBQK_Model.LXRSJ = LXRSJ.Text.Trim();
            XXJBQK_Model.LXRDZYX = LXRDZYX.Text.Trim();


            YLZY_Model.ZYDM = ZYDM.Text.Trim();
            YLZY_Model.ZYMC = ZYMC.SelectedText.Trim();
            YLZY_Model.ZYSSDL = ZYSSDL.Text.Trim();
            YLZY_Model.ZYSSEJL = ZYSSEJL.Text.Trim();
            YLZY_Model.ZYFZR_XM = ZYFZR_XM.Text.Trim();
            YLZY_Model.ZYFZR_XZZW = ZYFZR_XZZW.Text.Trim();
            YLZY_Model.ZYFZR_ZYJSZW = ZYFZR_ZYJSZW.Text.Trim();
            YLZY_Model.ZYFZR_ZYZGZS = ZYFZR_ZYZGZS.Text.Trim();
            YLZY_Model.ZYFZR_BGSDH = ZYFZR_BGSDH.Text.Trim();
            YLZY_Model.ZYFZR_CZ = ZYFZR_CZ.Text.Trim();
            YLZY_Model.ZYFZR_SJ = ZYFZR_SJ.Text.Trim();
            YLZY_Model.ZYFZR_DZYX = ZYFZR_DZYX.Text.Trim();
            YLZY_Model.ZYTD = zytd;
            YLZY_Model.ZYKBSJ = ZYKBSJ.Text.Trim();
            YLZY_Model.SFKSZS = kszs;
            YLZY_Model.ZRJSS = Convert.ToInt32(ZRJSS.Text.Trim());
            YLZY_Model.JZJSS = Convert.ToInt32(JZJSS.Text.Trim());
            YLZY_Model.XYZSSXSMJ = Convert.ToDecimal(XYZSSXSMJ.Text.Trim());
            YLZY_Model.XYTYSXSMJ = Convert.ToDecimal(XYTYSXSMJ.Text.Trim());
            YLZY_Model.XYSXSBZZ = Convert.ToDecimal(XYSXSBZZ.Text.Trim());
            YLZY_Model.XYSXYQSB = Convert.ToInt32(XYSXYQSB.Text.Trim());

            YLZY_Model.SBLY = SBLY.Text.Trim();
            YLZY_Model.JSMB = JSMB.Text.Trim();
            YLZY_Model.JTJC = JTJC.Text.Trim();
            YLZY_Model.JFAP = JFAP.Text.Trim();
            YLZY_Model.SSJH = SSJH.Text.Trim();


            YLZY_Model.BGZYYXMC = TextBox1_yxmc.Text.Trim();
            YLZY_Model.BGZYZYMC = TextBox2_zymc.Text.Trim();
            YLZY_Model.XZLY = TextArea_xzly.Text.Trim();
            YLZY_Model.DBFX = TextArea_dbfx.Text.Trim();

            YLZY_Model.SQZXJF = Convert.ToDecimal(NumberBox_sqzxjfhj.Text.Trim());
            YLZY_Model.SQZXJFZXKSSJ = DatePicker_sqzxjfzxksrq.Text.Trim();
            YLZY_Model.SQZXJFZXJSSJ = DatePicker_sqzxjfzxjsrq.Text.Trim();

            //YLZY_Model.SQZXJFKCJCJF = Convert.ToDecimal(NumberBox_sqzxjfkcjcjf.Text.Trim());
            //YLZY_Model.SQZXJFKCJCJFGSYJ = TextArea_sqzxjfkcjcjfgsyj.Text.Trim();
            //YLZY_Model.SQZXJFKCJCJFBZ = TextArea_sqzxjfkcjcjfbz.Text.Trim();

            //YLZY_Model.SQZXJFSZPXJF = Convert.ToDecimal(NumberBox_sqzxjfszpxjf.Text.Trim());
            //YLZY_Model.SQZXJFSZPXJFGSYJ = TextArea_sqzxjfszpxjfgsyj.Text.Trim();
            //YLZY_Model.SQZXJFSZPXJFBZ = TextArea_sqzxjfszpxjfbz.Text.Trim();

            //YLZY_Model.SQZXJFYQSBJF = Convert.ToDecimal(NumberBox_sqzxjfyqsbjf.Text.Trim());
            //YLZY_Model.SQZXJFYQSBJFGSYJ = TextArea_sqzxjfyqsbjfgsyj.Text.Trim();
            //YLZY_Model.SQZXJFYQSBJFBZ = TextArea_sqzxjfyqsbjfbz.Text.Trim();

            //YLZY_Model.SQZXJFWPRYJF = Convert.ToDecimal(NumberBox_sqzxjfwpryfy.Text.Trim());
            //YLZY_Model.SQZXJFWPRYJFGSYJ = TextArea_sqzxjfwpryfygsyj.Text.Trim();
            //YLZY_Model.SQZXJFWPRYJFBZ = TextArea_sqzxjfwpryfybz.Text.Trim();

            //YLZY_Model.SQZXJFYWF = Convert.ToDecimal(NumberBox_sqzxjfywf.Text.Trim());
            //YLZY_Model.SQZXJFYWFGSYJ = TextArea_sqzxjfywfgsyj.Text.Trim();
            //YLZY_Model.SQZXJFYWFBZ = TextArea_sqzxjfywfbz.Text.Trim();
            //YLZY_Model.SQZXJFJFGSHJ = Convert.ToDecimal(NumberBox_sqzxjfgshj.Text.Trim());

          




            YLZY_Model.XXPTJF = Convert.ToDecimal(NumberBox_xxptjfhj.Text.Trim());
            YLZY_Model.XXPTJFZXKSSJ = DatePicker_xxptjfzxksrq.Text.Trim();
            YLZY_Model.XXPTJFZXJSSJ = DatePicker_xxptjfzxjsrq.Text.Trim();

            //YLZY_Model.XXPTJFKCJCJF = Convert.ToDecimal(NumberBox_xxptkcjcjf.Text.Trim());
            //YLZY_Model.XXPTJFKCJCJFGSYJ = TextArea_xxptkcjcjfgsyj.Text.Trim();
            //YLZY_Model.XXPTJFKCJCJFBZ = TextArea_xxptkcjcjfbz.Text.Trim();

            //YLZY_Model.XXPTJFSZPXJF = Convert.ToDecimal(NumberBox_xxptszpxf.Text.Trim());
            //YLZY_Model.XXPTJFSZPXJFGSYJ = TextArea_xxptszpxfgsyj.Text.Trim();
            //YLZY_Model.XXPTJFSZPXJFBZ = TextArea_xxptszpxfbz.Text.Trim();

            //YLZY_Model.XXPTJFSBHCJF = Convert.ToDecimal(NumberBox_xxptyqsbjf.Text.Trim());
            //YLZY_Model.XXPTJFSBHCJFGSYJ = TextArea_xxptyqsbjfgsyj.Text.Trim();
            //YLZY_Model.XXPTJFSBHCJFBZ = TextArea_xxptyqsbjfbz.Text.Trim();

            //YLZY_Model.XXPTJFWPRYJF = Convert.ToDecimal(NumberBox_xxptwpryfy.Text.Trim());
            //YLZY_Model.XXPTJFWPRYJFGSYJ = TextArea_xxptwpryfygsyj.Text.Trim();
            //YLZY_Model.XXPTJFWPRYJFBZ = TextArea_xxptwpryfybz.Text.Trim();

            //YLZY_Model.XXPTJFYWF = Convert.ToDecimal(NumberBox_xxptywf.Text.Trim());
            //YLZY_Model.XXPTJFYWFGSYJ = TextArea_xxptywfgsyj.Text.Trim();
            //YLZY_Model.XXPTJFYWFBZ = TextArea_xxptywfbz.Text.Trim();
            //YLZY_Model.XXPTJFJFGSHJ = Convert.ToDecimal(NumberBox_xxptgshj.Text.Trim());
            YLZY_Model.user_uid = pb.GetIdentityId();
            YLZY_Model.ZT = 1;
            YLZY_Model.SFSC = 0;
            YLZY_Model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");


            DataTable dt = null;
            DataTable dt2 = null;
            DataTable dt3 = null;
            if (ViewState["dt1"] != null)
                dt = ViewState["dt1"] as DataTable;
            else
            {
                Alert.Show("没有填写近三年专业招生就业情况");
                return;
            }
            if (dt.Rows.Count != 3)
            {
                Alert.Show("没有填写完整近三年专业招生就业情况");
                return;
            }

            if (ViewState["dt2"] != null)
            {
                dt2 = ViewState["dt2"] as DataTable;


                int _zrjss = 0, _jzjss = 0;
                try
                {
                    _zrjss = Convert.ToInt32(ZRJSS.Text.Trim());
                }
                catch
                {
                    Alert.ShowInTop("请先填写专任教师数");
                    return;
                }
                //if (_zrjss <= 0)
                //{
                //    Alert.ShowInTop("请先填写专任教师数");
                //    return;
                //}



                try
                {
                    _jzjss = Convert.ToInt32(JZJSS.Text.Trim());
                }
                catch
                {
                    Alert.ShowInTop("请先填写兼职教师数");
                    return;
                }

                if (Getzjzrs("1", dt2) != _zrjss)
                {
                    Alert.ShowInTop("您添加的专任教师信息的条数和您输入的专任教师数的人数不一致");
                    return;
                }

                if (Getzjzrs("2", dt2) != _jzjss)
                {
                    Alert.ShowInTop("您添加的兼职教师信息的条数和您输入的兼职教师数的人数不一致");
                    return;
                }
            }
            else
            {
                Alert.Show("没有填写专业教师基本信息");
                return;
            }


            if (ViewState["dt3"] != null)
                dt3 = ViewState["dt3"] as DataTable;
            else
            {
                Alert.Show("没有填写项目验收指标");
                return;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ZYZSJYQK_Model.XXDM = ViewState["xxdm"].ToString();
                ZYZSJYQK_Model.XMBH = YLZY_Model.XMBH;
                ZYZSJYQK_Model.ZYDM = YLZY_Model.ZYDM;
                ZYZSJYQK_Model.NF = dt.Rows[i]["nf"].ToString().Trim();
                ZYZSJYQK_Model.SJZSS = Convert.ToInt32(dt.Rows[i]["NumberBox_sjzss"].ToString().Trim());
                ZYZSJYQK_Model.XSBDL = Convert.ToDecimal(dt.Rows[i]["NumberBox_xsbdl"].ToString().Trim());
                ZYZSJYQK_Model.QRZZXSS = Convert.ToInt32(dt.Rows[i]["NumberBox_qrzzxss"].ToString().Trim());
                ZYZSJYQK_Model.DDPYRS = Convert.ToInt32(dt.Rows[i]["NumberBox_ddpyrs"].ToString().Trim());
                ZYZSJYQK_Model.BYSRS = Convert.ToInt32(dt.Rows[i]["NumberBox_byss"].ToString().Trim());
                ZYZSJYQK_Model.CCJYL = Convert.ToDecimal(dt.Rows[i]["NumberBox_ccjyl"].ToString().Trim());
                ZYZSJYQK_Bll.Add(ZYZSJYQK_Model);
            }


            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                JSXX_Model.XXDM = ViewState["xxdm"].ToString();
                JSXX_Model.XMBH = YLZY_Model.XMBH;
                JSXX_Model.JSXM = dt2.Rows[i]["jsxm"].ToString().Trim();
                JSXX_Model.CSNY = dt2.Rows[i]["csny"].ToString().Trim();
                JSXX_Model.ZZJZ = Convert.ToInt32(dt2.Rows[i]["zjz"].ToString().Trim());
                JSXX_Model.SFSS = Convert.ToInt32(dt2.Rows[i]["sfss"].ToString().Trim());
                JSXX_Model.XL = dt2.Rows[i]["xl"].ToString().Trim();
                JSXX_Model.XW = dt2.Rows[i]["xw"].ToString().Trim();
                JSXX_Model.ZCDJ = dt2.Rows[i]["zcdj"].ToString().Trim();
                //JSXX_Model = dt.Rows[i]["xw"].ToString().Trim();
                //ZYZSJYQK_Model.NF = dt.Rows[i]["nf"].ToString().Trim();
                //ZYZSJYQK_Model.SJZSS = Convert.ToInt32(dt.Rows[i]["NumberBox_sjzss"].ToString().Trim());
                //ZYZSJYQK_Model.XSBDL = Convert.ToDecimal(dt.Rows[i]["NumberBox_xsbdl"].ToString().Trim());
                //ZYZSJYQK_Model.QRZZXSS = Convert.ToInt32(dt.Rows[i]["NumberBox_qrzzxss"].ToString().Trim());
                //ZYZSJYQK_Model.DDPYRS = Convert.ToInt32(dt.Rows[i]["NumberBox_ddpyrs"].ToString().Trim());
                //ZYZSJYQK_Model.BYSRS = Convert.ToInt32(dt.Rows[i]["NumberBox_byss"].ToString().Trim());
                //ZYZSJYQK_Model.CCJYL = Convert.ToDecimal(dt.Rows[i]["NumberBox_ccjyl"].ToString().Trim());
                JSXX_Bll.Add(JSXX_Model);
            }


            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                YSZB_Model.XMBH = YLZY_Model.XMBH;
                YSZB_Model.JSMB = dt3.Rows[i]["jsmb"].ToString().Trim();
                YSZB_Model.YQWCSJ = dt3.Rows[i]["yqwcsj"].ToString().Trim();
                YSZB_Model.YSYD = dt3.Rows[i]["ysyd"].ToString().Trim();
                YSZB_Bll.Add(YSZB_Model);

            }

            Model.XMFJ XMFJ_Mode = new Model.XMFJ();
            BLL.XMFJ XMFJ_Bll = new BLL.XMFJ();
            XMFJ_Mode.XMBH=ViewState["xmbh"].ToString().Trim();
            if (ViewState["file1"] != null)
                XMFJ_Mode.XMKXXFXBGWJM = ViewState["file1"].ToString();
            if (ViewState["file2"] != null)
                XMFJ_Mode.YXXSALWJM = ViewState["file2"].ToString();
            if (ViewState["file3"] != null)
                XMFJ_Mode.XMYSMXWJM = ViewState["file3"].ToString();

            XMFJ_Bll.Add(XMFJ_Mode);

            if (YLZY_Bll.Add(YLZY_Model) > 0)
            {

                JFYS_Model.NF = "2015";
                JFYS_Model.XMBH = YLZY_Model.XMBH;
                JFYS_Model.SQZXJFJFGSHJ = Convert.ToDecimal(NumberBox_sqzxjfgshj_2015.Text.Trim());
                JFYS_Model.SQZXJFKCJCJF = Convert.ToDecimal(NumberBox_sqzxjfkcjcjf_2015.Text.Trim());
                JFYS_Model.SQZXJFSZPXJF = Convert.ToDecimal(NumberBox_sqzxjfszpxjf_2015.Text.Trim());
                JFYS_Model.SQZXJFYQSBJF = Convert.ToDecimal(NumberBox_sqzxjfyqsbjf_2015.Text.Trim());
                JFYS_Model.SQZXJFWPRYJF = Convert.ToDecimal(NumberBox_sqzxjfwpryfy_2015.Text.Trim());
                JFYS_Model.SQZXJFYWF = Convert.ToDecimal(NumberBox_sqzxjfywf_2015.Text.Trim());

                JFYS_Model.XXPTJFJFGSHJ = Convert.ToDecimal(NumberBox_xxptgshj_2015.Text.Trim());
                JFYS_Model.XXPTJFKCJCJF = Convert.ToDecimal(NumberBox_xxptkcjcjf_2015.Text.Trim());
                JFYS_Model.XXPTJFSZPXJF = Convert.ToDecimal(NumberBox_xxptszpxf_2015.Text.Trim());
                JFYS_Model.XXPTJFYQSBJF = Convert.ToDecimal(NumberBox_xxptyqsbjf_2015.Text.Trim());
                JFYS_Model.XXPTJFWPRYJF = Convert.ToDecimal(NumberBox_xxptwpryfy_2015.Text.Trim());
                JFYS_Model.XXPTJFYWF = Convert.ToDecimal(NumberBox_xxptywf_2015.Text.Trim());

                JFYS_Bll.Add(JFYS_Model);

                JFYS_Model.NF = "2016";
                JFYS_Model.XMBH = YLZY_Model.XMBH;
                JFYS_Model.SQZXJFJFGSHJ = Convert.ToDecimal(NumberBox_sqzxjfgshj_2016.Text.Trim());
                JFYS_Model.SQZXJFKCJCJF = Convert.ToDecimal(NumberBox_sqzxjfkcjcjf_2016.Text.Trim());
                JFYS_Model.SQZXJFSZPXJF = Convert.ToDecimal(NumberBox_sqzxjfszpxjf_2016.Text.Trim());
                JFYS_Model.SQZXJFYQSBJF = Convert.ToDecimal(NumberBox_sqzxjfyqsbjf_2016.Text.Trim());
                JFYS_Model.SQZXJFWPRYJF = Convert.ToDecimal(NumberBox_sqzxjfwpryfy_2016.Text.Trim());
                JFYS_Model.SQZXJFYWF = Convert.ToDecimal(NumberBox_sqzxjfywf_2016.Text.Trim());

                JFYS_Model.XXPTJFJFGSHJ = Convert.ToDecimal(NumberBox_xxptgshj_2016.Text.Trim());
                JFYS_Model.XXPTJFKCJCJF = Convert.ToDecimal(NumberBox_xxptkcjcjf_2016.Text.Trim());
                JFYS_Model.XXPTJFSZPXJF = Convert.ToDecimal(NumberBox_xxptszpxf_2016.Text.Trim());
                JFYS_Model.XXPTJFYQSBJF = Convert.ToDecimal(NumberBox_xxptyqsbjf_2016.Text.Trim());
                JFYS_Model.XXPTJFWPRYJF = Convert.ToDecimal(NumberBox_xxptwpryfy_2016.Text.Trim());
                JFYS_Model.XXPTJFYWF = Convert.ToDecimal(NumberBox_xxptywf_2016.Text.Trim());

                JFYS_Bll.Add(JFYS_Model);



                JFYS_Model.NF = "2017";
                JFYS_Model.XMBH = YLZY_Model.XMBH;
                JFYS_Model.SQZXJFJFGSHJ = Convert.ToDecimal(NumberBox_sqzxjfgshj_2017.Text.Trim());
                JFYS_Model.SQZXJFKCJCJF = Convert.ToDecimal(NumberBox_sqzxjfkcjcjf_2017.Text.Trim());
                JFYS_Model.SQZXJFSZPXJF = Convert.ToDecimal(NumberBox_sqzxjfszpxjf_2017.Text.Trim());
                JFYS_Model.SQZXJFYQSBJF = Convert.ToDecimal(NumberBox_sqzxjfyqsbjf_2017.Text.Trim());
                JFYS_Model.SQZXJFWPRYJF = Convert.ToDecimal(NumberBox_sqzxjfwpryfy_2017.Text.Trim());
                JFYS_Model.SQZXJFYWF = Convert.ToDecimal(NumberBox_sqzxjfywf_2017.Text.Trim());

                JFYS_Model.XXPTJFJFGSHJ = Convert.ToDecimal(NumberBox_xxptgshj_2017.Text.Trim());
                JFYS_Model.XXPTJFKCJCJF = Convert.ToDecimal(NumberBox_xxptkcjcjf_2017.Text.Trim());
                JFYS_Model.XXPTJFSZPXJF = Convert.ToDecimal(NumberBox_xxptszpxf_2017.Text.Trim());
                JFYS_Model.XXPTJFYQSBJF = Convert.ToDecimal(NumberBox_xxptyqsbjf_2017.Text.Trim());
                JFYS_Model.XXPTJFWPRYJF = Convert.ToDecimal(NumberBox_xxptwpryfy_2017.Text.Trim());
                JFYS_Model.XXPTJFYWF = Convert.ToDecimal(NumberBox_xxptywf_2017.Text.Trim());

                JFYS_Bll.Add(JFYS_Model);



                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"] + ".doc";
                var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015项目申报书(一流专业)150127.doc");
                var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

                if (new BuildWord().BuildWord_2015ProjectDeclaration(tmppath, savepath, YLZY_Model.XMBH))
                {
                    BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                    Model.XMSBSWD model = new Model.XMSBSWD();
                    model.XMBH = YLZY_Model.XMBH;
                    model.XMMC = YLZY_Model.XMMC;
                    model.WDLJ = savepath;
                    wordBll.Add(model);
                }
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());


        }

        protected void ZYMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string zydm1 = ZYMC.SelectedValue.Trim().Split(',')[0];

                //string zydm1 = "";
                string sqlstr = "select *  FROM ZYB1 where ZYDM='" + zydm1 + "' and XXDM='" + ViewState["xxdm"].ToString().Trim()+ "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string m="",d="", sj = "";

                if (sdr.Read())
                {
                    ZYDM.Text = sdr["ZYDM"].ToString().Trim();
                    ZYFZR_XM.Text = sdr["ZYFZR_XM"].ToString().Trim();
                    ZYSSDL.Text = sdr["ZYSSDL"].ToString().Trim();
                    ZYSSEJL.Text = sdr["ZYSSEJL"].ToString().Trim();
                    //ZYFZR_XZZW.Text = sdr["ZYFZR_XZZW"].ToString().Trim();
                    ZYFZR_ZYJSZW.Text = sdr["ZYFZR_ZYJSZW"].ToString().Trim();
                    sj=sdr["ZYKBSJ"].ToString().Trim();
                    if (sj.Length == 6)
                    {
                        try
                        {
                            m = sj.Substring(0, 4);
                            d = sj.Substring(4, 2);
                            sj = Convert.ToDateTime(m+"-"+d).ToString("yyyy-MM");
                            ZYKBSJ.Text = sj;
                        }
                        catch (Exception ex)
                        {
                            ZYKBSJ.Text = "";
                            Alert.ShowInTop(ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        ZYKBSJ.Text = "";
                    }

                    bind_zsyjqk();
                    //ZYFZR_ZYZGZS.Text = sdr["ZYFZR_ZYZGZS"].ToString().Trim();
                    //ZYFZR_BGSDH.Text = sdr["ZYFZR_BGSDH"].ToString().Trim();
                    //ZYFZR_CZ.Text = sdr["ZYFZR_CZ"].ToString().Trim();
                    //ZYFZR_SJ.Text = sdr["ZYFZR_SJ"].ToString().Trim();
                    //ZYFZR_DZYX.Text = sdr["ZYFZR_DZYX"].ToString().Trim();
                    //ZYKBSJ.Text = sdr["ZYKBSJ"].ToString().Trim();
                    //if(sdr["SFKSZS"].ToString().Trim()=="1")
                    //    SFKSZS.SelectedIndex=0;
                    //else
                    //    SFKSZS.SelectedIndex = 1;

                    //ZRJSS.Text = sdr["ZRJSS"].ToString().Trim();
                    //JZJSS.Text = sdr["JZJSS"].ToString().Trim();

                }
                else
                {
                    ZYDM.Text =  "";
                    ZYFZR_XM.Text = "";
                    ZYSSDL.Text =  "";
                    ZYSSEJL.Text =  "";
                  
                    ZYFZR_ZYJSZW.Text = "";
                    ZYKBSJ.Text = "";
                    //ZYFZR_XM.Text = "";
                    //ZYFZR_XZZW.Text = "";
                    //ZYFZR_ZYJSZW.Text = "";
                    //ZYFZR_ZYZGZS.Text = "";
                    //ZYFZR_BGSDH.Text = "";
                    //ZYFZR_CZ.Text = "";
                    //ZYFZR_SJ.Text = "";
                    //ZYFZR_DZYX.Text = "";
                    //ZYDM.Text = "";
                }
                sdr.Dispose();
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
                return;
            }



        }
        //protected void DropDownList_nf_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string zydm = ZYDM.Text.Trim();
        //    string nf = DropDownList_nf.SelectedValue.Trim();
        //    if (nf != "请选择")
        //    {
        //        string sqlstr = "select * from ZYZSJYQKB where ZYDM='" + zydm + "' and XXDM='" + ViewState["xxdm"] + "' and NF='" + nf + "'";
        //        SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);

        //        if (sdr.Read())
        //        {
        //            NumberBox_sjzss.Text = sdr["SJZSS"].ToString().Trim();
        //            NumberBox_xsbdl.Text = sdr["XSBDL"].ToString().Trim();
        //            NumberBox_qrzzxss.Text = sdr["QRZZXSS"].ToString().Trim();
        //            NumberBox_ddpyrs.Text = sdr["DDPYRS"].ToString().Trim();
        //            NumberBox_byss.Text = sdr["BYSRS"].ToString().Trim();
        //            NumberBox_ccjyl.Text = sdr["CCJYL"].ToString().Trim();


        //        }
        //        else
        //        {

        //        }
        //        sdr.Dispose();
        //    }
        //    else
        //    {
        //        Alert.Show("请选择年份");
        //    }
        //}


        protected void bind_zsyjqk()
        {
            string zydm = ZYDM.Text.Trim();
            //string nf = DropDownList_nf.SelectedValue.Trim();
            string sqlstr = "";
            DataTable dt = null;
            for (int i = 2012; i < 2015; i++)
            {
                sqlstr = "select * from ZYZSJYQKB where ZYDM='" + zydm + "' and XXDM='" + ViewState["xxdm"] + "' and NF='" + i + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);

                if (sdr.Read())
                {
                   
                  
                    if (i == 2012)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("id");
                        dt.Columns.Add("nf");
                        dt.Columns.Add("NumberBox_sjzss");
                        dt.Columns.Add("NumberBox_xsbdl");
                        dt.Columns.Add("NumberBox_qrzzxss");
                        dt.Columns.Add("NumberBox_ddpyrs");
                        dt.Columns.Add("NumberBox_byss");
                        dt.Columns.Add("NumberBox_ccjyl");

                        DataRow dr = dt.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["nf"] =i.ToString();
                        dr["NumberBox_sjzss"] = sdr["SJZSS"].ToString().Trim();
                        dr["NumberBox_xsbdl"] = sdr["XSBDL"].ToString().Trim();
                        dr["NumberBox_qrzzxss"] = sdr["QRZZXSS"].ToString().Trim();
                        dr["NumberBox_ddpyrs"] = sdr["DDPYRS"].ToString().Trim();
                        dr["NumberBox_byss"] = sdr["BYSRS"].ToString().Trim();
                        dr["NumberBox_ccjyl"] = sdr["CCJYL"].ToString().Trim();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                       


                            DataRow dr = dt.NewRow();
                            dr["id"] = Guid.NewGuid().ToString();
                            dr["nf"] = i.ToString();
                            dr["NumberBox_sjzss"] = sdr["SJZSS"].ToString().Trim();
                            dr["NumberBox_xsbdl"] = sdr["XSBDL"].ToString().Trim();
                            dr["NumberBox_qrzzxss"] = sdr["QRZZXSS"].ToString().Trim();
                            dr["NumberBox_ddpyrs"] = sdr["DDPYRS"].ToString().Trim();
                            dr["NumberBox_byss"] = sdr["BYSRS"].ToString().Trim();
                            dr["NumberBox_ccjyl"] = sdr["CCJYL"].ToString().Trim();
                            dt.Rows.Add(dr);
                      
                    }
                   

                }
                else
                {
                    if (i == 2012)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("id");
                        dt.Columns.Add("nf");
                        dt.Columns.Add("NumberBox_sjzss");
                        dt.Columns.Add("NumberBox_xsbdl");
                        dt.Columns.Add("NumberBox_qrzzxss");
                        dt.Columns.Add("NumberBox_ddpyrs");
                        dt.Columns.Add("NumberBox_byss");
                        dt.Columns.Add("NumberBox_ccjyl");

                        DataRow dr = dt.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["nf"] = i.ToString();
                        dr["NumberBox_sjzss"] = 0;
                        dr["NumberBox_xsbdl"] =0;
                        dr["NumberBox_qrzzxss"] = 0;
                        dr["NumberBox_ddpyrs"] = 0;
                        dr["NumberBox_byss"] = 0;
                        dr["NumberBox_ccjyl"] = 0;
                        dt.Rows.Add(dr);
                    }
                    else
                    {



                        DataRow dr = dt.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["nf"] = i.ToString();
                        dr["NumberBox_sjzss"] = 0;
                        dr["NumberBox_xsbdl"] = 0;
                        dr["NumberBox_qrzzxss"] = 0;
                        dr["NumberBox_ddpyrs"] = 0;
                        dr["NumberBox_byss"] = 0;
                        dr["NumberBox_ccjyl"] = 0;
                        dt.Rows.Add(dr);

                    }
                }
                sdr.Dispose();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 2; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString().Trim() == "")
                        dt.Rows[i][j] = 0;
                }
            }
            DataView dv = new DataView(dt);
            dv.Sort = "nf asc";
            Grid1.DataSource = dv;
            Grid1.DataBind();
            ViewState["dt1"] = dt;
          
        }
        private string AutoNumber(string seed)
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM   YLZY  WHERE   (XMBH LIKE '" + seed.Trim() + "%') ORDER BY XMBH DESC";
                string bm1 = "", bm2 = "", bm = "", tempbm = "";
                SqlDataReader dr = DbHelperSQL.ExecuteReader(sql);
                if (dr.Read())
                {
                    tempbm = dr["XMBH"].ToString().Trim();
                    //bm1 = tempbm.Substring(0, tempbm.Length - seed.Trim().Length);
                    bm1 = seed.Trim();
                    bm2 = tempbm.Substring(tempbm.Length - 3);
                    bm = bm1 + (Convert.ToInt32(bm2) + 1).ToString("#000");
                }
                else
                {
                    bm = seed.Trim() + "001";
                }
                return bm;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void AddHj1()
        {
            try
            {
                string ryjf_2015 = NumberBox_sqzxjfkcjcjf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2015.Text.ToString().Trim();
                string xsbz_2015 = NumberBox_sqzxjfszpxjf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2015.Text.ToString().Trim();
                string jxky_2015 = NumberBox_sqzxjfyqsbjf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2015.Text.ToString().Trim();
                string ywf_2015 = NumberBox_sqzxjfwpryfy_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2015.Text.ToString().Trim();
                string sbgz_2015 = NumberBox_sqzxjfywf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2015.Text.ToString().Trim();
                float hj_2015 = (float.Parse(ryjf_2015) + float.Parse(xsbz_2015) + float.Parse(jxky_2015) + float.Parse(ywf_2015) + float.Parse(sbgz_2015));
                NumberBox_sqzxjfgshj_2015.Text = String.Format("{0:0.00}", hj_2015);

                string ryjf_2016 = NumberBox_sqzxjfkcjcjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2016.Text.ToString().Trim();
                string xsbz_2016 = NumberBox_sqzxjfszpxjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2016.Text.ToString().Trim();
                string jxky_2016 = NumberBox_sqzxjfyqsbjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2016.Text.ToString().Trim();
                string ywf_2016 = NumberBox_sqzxjfwpryfy_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2016.Text.ToString().Trim();
                string sbgz_2016 = NumberBox_sqzxjfywf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2016.Text.ToString().Trim();
                float hj_2016 = (float.Parse(ryjf_2016) + float.Parse(xsbz_2016) + float.Parse(jxky_2016) + float.Parse(ywf_2016) + float.Parse(sbgz_2016));
                NumberBox_sqzxjfgshj_2016.Text = String.Format("{0:0.00}", hj_2016);

                string ryjf_2017 = NumberBox_sqzxjfkcjcjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2017.Text.ToString().Trim();
                string xsbz_2017 = NumberBox_sqzxjfszpxjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2017.Text.ToString().Trim();
                string jxky_2017 = NumberBox_sqzxjfyqsbjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2017.Text.ToString().Trim();
                string ywf_2017 = NumberBox_sqzxjfwpryfy_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2017.Text.ToString().Trim();
                string sbgz_2017 = NumberBox_sqzxjfywf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2017.Text.ToString().Trim();
                float hj_2017 = (float.Parse(ryjf_2017) + float.Parse(xsbz_2017) + float.Parse(jxky_2017) + float.Parse(ywf_2017) + float.Parse(sbgz_2017));
                NumberBox_sqzxjfgshj_2017.Text = String.Format("{0:0.00}", hj_2017);



                NumberBox_sqzxjfhj.Text = String.Format("{0:0.00}", hj_2015 + hj_2016 + hj_2017);
            }
            catch (Exception ex)
            {
                Alert.Show("计费合计错误：" + ex.Message);
            }
        }

        public void AddHj2()
        {
            try
            {
                string ryjf_2015 = NumberBox_xxptkcjcjf_2015.Text.Trim() == "" ? "0" : NumberBox_xxptkcjcjf_2015.Text.ToString().Trim();
                string xsbz_2015 = NumberBox_xxptszpxf_2015.Text.Trim() == "" ? "0" : NumberBox_xxptszpxf_2015.Text.ToString().Trim();
                string jxky_2015 = NumberBox_xxptyqsbjf_2015.Text.Trim() == "" ? "0" : NumberBox_xxptyqsbjf_2015.Text.ToString().Trim();
                string ywf_2015 = NumberBox_xxptwpryfy_2015.Text.Trim() == "" ? "0" : NumberBox_xxptwpryfy_2015.Text.ToString().Trim();
                string sbgz_2015 = NumberBox_xxptywf_2015.Text.Trim() == "" ? "0" : NumberBox_xxptywf_2015.Text.ToString().Trim();
                float hj_2015 = (float.Parse(ryjf_2015) + float.Parse(xsbz_2015) + float.Parse(jxky_2015) + float.Parse(ywf_2015) + float.Parse(sbgz_2015));
                NumberBox_xxptgshj_2015.Text = String.Format("{0:0.00}", hj_2015);


                string ryjf_2016 = NumberBox_xxptkcjcjf_2016.Text.Trim() == "" ? "0" : NumberBox_xxptkcjcjf_2016.Text.ToString().Trim();
                string xsbz_2016 = NumberBox_xxptszpxf_2016.Text.Trim() == "" ? "0" : NumberBox_xxptszpxf_2016.Text.ToString().Trim();
                string jxky_2016 = NumberBox_xxptyqsbjf_2016.Text.Trim() == "" ? "0" : NumberBox_xxptyqsbjf_2016.Text.ToString().Trim();
                string ywf_2016 = NumberBox_xxptwpryfy_2016.Text.Trim() == "" ? "0" : NumberBox_xxptwpryfy_2016.Text.ToString().Trim();
                string sbgz_2016 = NumberBox_xxptywf_2016.Text.Trim() == "" ? "0" : NumberBox_xxptywf_2016.Text.ToString().Trim();
                float hj_2016 = (float.Parse(ryjf_2016) + float.Parse(xsbz_2016) + float.Parse(jxky_2016) + float.Parse(ywf_2016) + float.Parse(sbgz_2016));
                NumberBox_xxptgshj_2016.Text = String.Format("{0:0.00}", hj_2016);


                string ryjf_2017 = NumberBox_xxptkcjcjf_2017.Text.Trim() == "" ? "0" : NumberBox_xxptkcjcjf_2017.Text.ToString().Trim();
                string xsbz_2017 = NumberBox_xxptszpxf_2017.Text.Trim() == "" ? "0" : NumberBox_xxptszpxf_2017.Text.ToString().Trim();
                string jxky_2017 = NumberBox_xxptyqsbjf_2017.Text.Trim() == "" ? "0" : NumberBox_xxptyqsbjf_2017.Text.ToString().Trim();
                string ywf_2017 = NumberBox_xxptwpryfy_2017.Text.Trim() == "" ? "0" : NumberBox_xxptwpryfy_2017.Text.ToString().Trim();
                string sbgz_2017 = NumberBox_xxptywf_2017.Text.Trim() == "" ? "0" : NumberBox_xxptywf_2017.Text.ToString().Trim();
                float hj_2017 = (float.Parse(ryjf_2017) + float.Parse(xsbz_2017) + float.Parse(jxky_2017) + float.Parse(ywf_2017) + float.Parse(sbgz_2017));
                NumberBox_xxptgshj_2017.Text = String.Format("{0:0.00}", hj_2017);



                NumberBox_xxptjfhj.Text = String.Format("{0:0.00}", hj_2015 + hj_2016 + hj_2017);
            }
            catch (Exception ex)
            {
                Alert.Show("计费合计错误：" + ex.Message);
            }
        }

        protected void NumberBox_sqzxjfkcjcjf_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }
        protected void NumberBox_sqzxjfszpxjf_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }
        protected void NumberBox_sqzxjfyqsbjf_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }
        protected void NumberBox_sqzxjfwpryfy_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }
        protected void NumberBox_sqzxjfywf_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }
        protected void NumberBox_xxptkcjcjf_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }
        protected void NumberBox_xxptszpxf_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }
        protected void NumberBox_xxptyqsbjf_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }
        protected void NumberBox_xxptwpryfy_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }
        protected void NumberBox_xxptywf_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            int selectedCount = Grid2.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid2.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid2.AllowPaging && !Grid2.IsDatabasePaging)
                    {
                        rowIndex = Grid2.PageIndex * Grid2.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid2.DataKeys[rowIndex][0].ToString() + ",";


                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

                if (ViewState["dt2"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt2"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows[i].Delete();
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid2.DataSource = dt;
                    Grid2.DataBind();
                    ViewState["dt2"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid2.SelectedRowIndexArray = null; // 清空当前选中的项
            }

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            int selectedCount = Grid3.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid3.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid3.AllowPaging && !Grid3.IsDatabasePaging)
                    {
                        rowIndex = Grid3.PageIndex * Grid3.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid3.DataKeys[rowIndex][0].ToString() + ",";


                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

                if (ViewState["dt3"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt3"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows[i].Delete();
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid3.DataSource = dt;
                    Grid3.DataBind();
                    ViewState["dt3"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid3.SelectedRowIndexArray = null; // 清空当前选中的项
            }

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string selectedID = "";
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


                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

                if (ViewState["dt1"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt1"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows[i].Delete();
                            break;
                        }
                    }
                    DataView dv = new DataView(dt);
                    dv.Sort = "nf asc";
                    Grid1.DataSource = dv;
                    Grid1.DataBind();
                    ViewState["dt1"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
            
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string fileName = FileUpload1.ShortFileName;
                    if (fileName.Contains(".doc") || fileName.Contains(".docx"))
                    {




                        fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                        fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                        FileUpload1.SaveAs(Server.MapPath("upload/项目可行性分析报告/" + fileName));
                        ViewState["file1"] = fileName;
                        Alert.ShowInTop("上传成功！");
                    }
                    else
                    {
                        Alert.ShowInTop("请上传word格式的文件！");
                    }
                }
                catch (Exception ex)
                {

                    Alert.ShowInTop(ex.Message);
                    return;
                }
                //Model.XMFJ XMFJ_Mode = new Model.XMFJ();
                //BLL.XMFJ XMFJ_Bll = new BLL.XMFJ();
                //XMFJ_Mode.XMBH=
                //string aa = "";

                //FileUpload1.ImageUrl = "~/upload/" + fileName;

                // 清空文件上传组件
                //FileUpload1.Reset();
            }
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                try
                {
                    string fileName = FileUpload2.ShortFileName;


                    if (fileName.Contains(".doc") || fileName.Contains(".docx"))
                    {

                        fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                        fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                        FileUpload2.SaveAs(Server.MapPath("upload/优秀学生案例/" + fileName));
                        ViewState["file2"] = fileName;
                        Alert.ShowInTop("上传成功！");
                    }
                    else
                    {
                        Alert.ShowInTop("请上传word格式的文件！");
                    }
                        
                }
                catch (Exception ex)
                {

                    Alert.ShowInTop(ex.Message);
                    return;
                }

                //FileUpload1.ImageUrl = "~/upload/" + fileName;

                // 清空文件上传组件
                //FileUpload1.Reset();
            }
        }

        protected void btnSubmit3_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                try
                {
                    string fileName = FileUpload3.ShortFileName;


                    if (fileName.Contains(".doc") || fileName.Contains(".docx"))
                    {

                        fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                        fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                        FileUpload3.SaveAs(Server.MapPath("upload/项目预算明细/" + fileName));
                        ViewState["file3"] = fileName;
                        Alert.ShowInTop("上传成功！");
                    }
                    else
                    {
                        Alert.ShowInTop("请上传word格式的文件！");
                    }

                }
                catch (Exception ex)
                {

                    Alert.ShowInTop(ex.Message);
                    return;
                }

                //FileUpload1.ImageUrl = "~/upload/" + fileName;

                // 清空文件上传组件
                //FileUpload1.Reset();
            }
        }


        protected void Grid2_RowDataBound(object sender, GridRowEventArgs e)
        {
            GridRow gr = Grid2.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb10 = gr.FindControl("Label10") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lb11 = gr.FindControl("Label11") as System.Web.UI.WebControls.Label;


            //Alert.Show(lb.Text, "提示", Alert.DefaultMessageBoxIcon);
            //if (lb.Text.Trim() == "2")
            //    lb.Text = "未提交";
            //if (lb.Text.Trim() == "3")
            //    lb.Text = "审核";
            if (Label10.Text.Trim() == "1")
                Label10.Text = "专职";
            else if (Label10.Text.Trim() == "2")
            {
                Label10.Text = "兼职";
            }
            else
                Label10.Text = "";

            if (lb11.Text.Trim() == "1")
                lb11.Text = "是";
            else if (lb11.Text.Trim() == "0")
            {
                lb11.Text = "否";
            }
            else
                lb11.Text = "";
            //else if (lb.Text.Trim() == "5")
            //    lb.Text = "审核通过";
           

        }

        protected void Button2_add_Click(object sender, EventArgs e)
        {
            int _zrjss = 0, _jzjss = 0;
            try
            {
                _zrjss = Convert.ToInt32(ZRJSS.Text.Trim());
            }
            catch
            {
                Alert.ShowInTop("请先填写专任教师数");
                return;
            }
            //if (_zrjss <= 0)
            //{
            //    Alert.ShowInTop("请先填写专任教师数");
            //    return;
            //}



            try
            {
                _jzjss = Convert.ToInt32(JZJSS.Text.Trim());
            }
            catch
            {
                Alert.ShowInTop("请先填写兼职教师数");
                return;
            }
            Session["dr"] = null;
            PageContext.RegisterStartupScript(Window1.GetShowReference("jsxx_Add.aspx?_zrjss=" + _zrjss + "&_jzjss=" + _jzjss, "添加教师基本信息", 700, 450));
        }


        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            DataTable dt = null;
            int _zrjss = 0, _jzjss = 0;
            try
            {
                _zrjss = Convert.ToInt32(ZRJSS.Text.Trim());
            }
            catch
            {
                Alert.ShowInTop("请先填写专任教师数");
                return;
            }
            //if (_zrjss <= 0)
            //{
            //    Alert.ShowInTop("请先填写专任教师数");
            //    return;
            //}



            try
            {
                _jzjss = Convert.ToInt32(JZJSS.Text.Trim());
            }
            catch
            {
                Alert.ShowInTop("请先填写兼职教师数");
                return;
            }
            if (ViewState["dt2"] == null)
            {
               

                dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("jsxm");
                dt.Columns.Add("csny");
                dt.Columns.Add("zjz");
                dt.Columns.Add("sfss");
                dt.Columns.Add("xl");
                dt.Columns.Add("xw");
                dt.Columns.Add("zcdj");

                if (Session["dr"] != null)
                {

                    DataRow dr1 = Session["dr"] as DataRow;
                    DataRow dr = dt.NewRow();
                    dr["id"] = dr1["id"];
                    dr["jsxm"] = dr1["jsxm"];
                    dr["csny"] = dr1["csny"];
                    dr["zjz"] = dr1["zjz"];
                    dr["sfss"] = dr1["sfss"];
                    dr["xl"] = dr1["xl"];
                    dr["xw"] = dr1["xw"];
                    dr["zcdj"] = dr1["zcdj"];
                    dt.Rows.Add(dr);
                }
            }
            else
            {
              
                dt = ViewState["dt2"] as DataTable;
                if (Session["dr"] != null)
                {
                    string zjz = "";
                    DataRow dr1 = Session["dr"] as DataRow;
                    DataRow dr = dt.NewRow();
                    dr["id"] = dr1["id"];
                    dr["jsxm"] = dr1["jsxm"];
                    dr["csny"] = dr1["csny"];
                    dr["zjz"] = dr1["zjz"];
                    dr["sfss"] = dr1["sfss"];
                    dr["xl"] = dr1["xl"];
                    dr["xw"] = dr1["xw"];
                    dr["zcdj"] = dr1["zcdj"];
                    zjz = dr["zjz"].ToString().Trim();
                    if (zjz == "1")
                    {
                        if (Getzjzrs(zjz, dt) >= _zrjss)
                        {
                            Alert.ShowInTop("您添加的专任教师信息的条数和您输入的专任教师数的人数不一致");
                            return;
                        }
                    }
                    else
                    {
                        if (Getzjzrs(zjz, dt) >= _jzjss)
                        {
                            Alert.ShowInTop("您添加的兼职教师信息的条数和您输入的兼职教师数的人数不一致");
                            return;
                        }
                    }





                    dt.Rows.Add(dr);
                }
               
            }
            Grid2.DataSource = dt;
            Grid2.DataBind();
            ViewState["dt2"] = dt;
        }
    }
}