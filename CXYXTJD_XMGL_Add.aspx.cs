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
    public partial class CXYXTJD_XMGL_Add : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        Model.CJYXTJD_JDYTZYQK ytzy_model = new Model.CJYXTJD_JDYTZYQK();
        BLL.CJYXTJD_JDYTZYQK ytzy_bll = new BLL.CJYXTJD_JDYTZYQK();

        Model.CJYXTJD_XMYSZB yszb_model = new Model.CJYXTJD_XMYSZB();
        BLL.CJYXTJD_XMYSZB yszb_bll = new BLL.CJYXTJD_XMYSZB();

        Model.CJYXTJD_XM xm_model = new Model.CJYXTJD_XM();
        BLL.CJYXTJD_XM xm_bll = new BLL.CJYXTJD_XM();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                DatePicker_sqzxjfzxjsrq.MinDate = DateTime.Now.AddDays(1);
                DatePicker_xxptjfzxjsrq.MinDate = DateTime.Now.AddDays(1);

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

                txt_xxmc.Text = xxmc;
                txt_xxdm.Text = xxdm;
                databind_zymc();
                ViewState["xmbh"] = AutoNumber("2015-03-");
                //直接将编号插入数据库
                xm_model.XMBH = ViewState["xmbh"].ToString();
                xm_bll.Add(xm_model);

                BindYTZYGrid();//绑定依托专业grid
                BindJSHCPGrid();//技术和产品指标
                BindSXSXGrid();//实习实训指标
                BindJNDSGrid();//技能大师指标

                btnDelWTZY.OnClientClick = grid_YTZY.GetNoSelectionAlertReference("请至少选择一项！");
                btnDelJNDS.OnClientClick = grid_JNDS.GetNoSelectionAlertReference("请至少选择一项！");
                btnDelJSGYHCPKFZB.OnClientClick = grid_JSHCP.GetNoSelectionAlertReference("请至少选择一项！");
                btnDelSXSXPT.OnClientClick = grid_SXSXPT.GetNoSelectionAlertReference("请至少选择一项！");


            }
        }

        protected void databind_zymc()
        {
            ddlZYMC.Items.Clear();
            DataTable dt = DbHelperSQL.Query("SELECT distinct [ZYDM]  ,[ZYMC] ,[ZYFXDM] ,[ZYFXMC]  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "' and ZYDM is not null  order by ZYMC").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ZYFXMC"].ToString().Trim() != "")
                {
                    if (dt.Rows[i]["ZYFXDM"].ToString().Trim() == "")
                    {
                        dt.Rows[i]["ZYDM"] = dt.Rows[i]["ZYDM"].ToString().Trim() + "," + "@" + i.ToString();
                    }
                    else
                    {
                        dt.Rows[i]["ZYDM"] = dt.Rows[i]["ZYDM"].ToString().Trim() + "," + dt.Rows[i]["ZYFXDM"].ToString().Trim();
                    }
                    dt.Rows[i]["ZYMC"] = dt.Rows[i]["ZYFXMC"].ToString().Trim();
                }
            }
            ddlZYMC.DataSource = dt;
            ddlZYMC.DataTextField = "ZYMC";
            ddlZYMC.DataValueField = "ZYDM";
            ddlZYMC.DataBind();
            ddlZYMC.Items.Insert(0, new FineUI.ListItem("--请选择--", "--请选择--"));
            dp_setvalue(ddlZYMC, "--请选择--");

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


        private string AutoNumber(string seed)
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM   CJYXTJD_XM  WHERE   (XMBH LIKE '" + seed.Trim() + "%') ORDER BY XMBH DESC";
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
                dr.Dispose();
                return bm;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void AddHj1(NumberBox nb)
        {
            //bool result = true;
            try
            {
                string ryjf_2015 = NumberBox_sqzxjfkcjcjf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2015.Text.ToString().Trim();
                string xsbz_2015 = NumberBox_sqzxjfszpxjf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2015.Text.ToString().Trim();
                string jxky_2015 = NumberBox_sqzxjfyqsbjf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2015.Text.ToString().Trim();
                string ywf_2015 = NumberBox_sqzxjfwpryfy_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2015.Text.ToString().Trim();
                string sbgz_2015 = NumberBox_sqzxjfywf_2015.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2015.Text.ToString().Trim();
                float hj_2015 = (float.Parse(ryjf_2015) + float.Parse(xsbz_2015) + float.Parse(jxky_2015) + float.Parse(ywf_2015) + float.Parse(sbgz_2015));
                NumberBox_sqzxjfgshj_2015.Text = String.Format("{0:0.00}", hj_2015);
                //if ( hj_2015 >= 200 )
                //{
                //    NumberBox_sqzxjfgshj_2015.Text = String.Format( "{0:0.00}", hj_2015 - float.Parse( nb.Text.Trim() ) );
                //    nb.Text = "0";
                //    Alert.Show( "每年经费合计不能超过200万：" );
                //    return;
                //}

                string ryjf_2016 = NumberBox_sqzxjfkcjcjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2016.Text.ToString().Trim();
                string xsbz_2016 = NumberBox_sqzxjfszpxjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2016.Text.ToString().Trim();
                string jxky_2016 = NumberBox_sqzxjfyqsbjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2016.Text.ToString().Trim();
                string ywf_2016 = NumberBox_sqzxjfwpryfy_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2016.Text.ToString().Trim();
                string sbgz_2016 = NumberBox_sqzxjfywf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2016.Text.ToString().Trim();
                float hj_2016 = (float.Parse(ryjf_2016) + float.Parse(xsbz_2016) + float.Parse(jxky_2016) + float.Parse(ywf_2016) + float.Parse(sbgz_2016));
                NumberBox_sqzxjfgshj_2016.Text = String.Format("{0:0.00}", hj_2016);

                //if ( hj_2016 >= 200 )
                //{
                //    NumberBox_sqzxjfgshj_2016.Text = String.Format( "{0:0.00}", hj_2016 - float.Parse( nb.Text.Trim() ) );
                //    nb.Text = "0";
                //    Alert.Show( "每年经费合计不能超过200万：" );
                //    return;
                //}

                string ryjf_2017 = NumberBox_sqzxjfkcjcjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2017.Text.ToString().Trim();
                string xsbz_2017 = NumberBox_sqzxjfszpxjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2017.Text.ToString().Trim();
                string jxky_2017 = NumberBox_sqzxjfyqsbjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2017.Text.ToString().Trim();
                string ywf_2017 = NumberBox_sqzxjfwpryfy_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2017.Text.ToString().Trim();
                string sbgz_2017 = NumberBox_sqzxjfywf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2017.Text.ToString().Trim();
                float hj_2017 = (float.Parse(ryjf_2017) + float.Parse(xsbz_2017) + float.Parse(jxky_2017) + float.Parse(ywf_2017) + float.Parse(sbgz_2017));
                NumberBox_sqzxjfgshj_2017.Text = String.Format("{0:0.00}", hj_2017);

                //if ( hj_2017 >= 200 )
                //{
                //    NumberBox_sqzxjfgshj_2017.Text = String.Format( "{0:0.00}", hj_2017 - float.Parse( nb.Text.Trim() ) );
                //    nb.Text = "0";
                //    Alert.Show( "每年经费合计不能超过200万：" );
                //    return;
                //}



                NumberBox_sqzxjfhj.Text = String.Format("{0:0.00}", hj_2015 + hj_2016 + hj_2017);
                //if ( ( hj_2015 + hj_2016 + hj_2017 ) > 500 )
                //{
                //    NumberBox_sqzxjfhj.Text = String.Format( "{0:0.00}", hj_2015 + hj_2016 + hj_2017 - float.Parse( nb.Text.Trim() ) );
                //    nb.Text = "0";
                //    Alert.Show( "三年经费合计不能超过500万：" );
                //    return;
                //}

            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
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
                //NumberBox_xxptjfhj.Text = "0";
                Alert.Show("计费合计错误：" + ex.Message);
            }
        }

        protected void NumberBox_sqzxjfkcjcjf_TextChanged(object sender, EventArgs e)
        {
            NumberBox nb = sender as NumberBox;
            AddHj1(nb);
            //Alert.Show(nb.Text);
        }
        protected void NumberBox_sqzxjfszpxjf_TextChanged(object sender, EventArgs e)
        {
            NumberBox nb = sender as NumberBox;
            AddHj1(nb);
        }
        protected void NumberBox_sqzxjfyqsbjf_TextChanged(object sender, EventArgs e)
        {
            NumberBox nb = sender as NumberBox;
            AddHj1(nb);
        }
        protected void NumberBox_sqzxjfwpryfy_TextChanged(object sender, EventArgs e)
        {
            NumberBox nb = sender as NumberBox;
            AddHj1(nb);
        }
        protected void NumberBox_sqzxjfywf_TextChanged(object sender, EventArgs e)
        {
            NumberBox nb = sender as NumberBox;
            AddHj1(nb);
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

                        FileUpload2.SaveAs(Server.MapPath("upload/校企合作优秀案例/" + fileName));
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

            }
        }

        protected void btnSubmit3_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
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

            }
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {

        }

        protected void Button_step1_Click(object sender, EventArgs e)
        {
            //s1.Visible = true;
            ContentPanel_step1.Hidden = false;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(1);");
        }
        protected void Button_step2_Click(object sender, EventArgs e)
        {
            //s1.Visible = false;
            //s2.Visible = true;
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = false;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(2);");
        }
        /// <summary>
        /// 保存实习实训情况
        /// </summary>
        /// <returns></returns>
        /// DateTime：2015-03-25 18:17
        /// Author：By risfeng
        /// Author Email：risfeng@126.com
        public bool Save_SXSXQK()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                xm_model = xm_bll.GetModel(xmbh);
                if (xm_model == null)
                {
                    IsAdd = true;
                    xm_model = new Model.CJYXTJD_XM();
                }
                //赋值
                xm_model.XMBH = ViewState["xmbh"].ToString();
                xm_model.JDMC = TextBox_jdmc.Text;
                xm_model.XXMC = txt_xxmc.Text;
                xm_model.XXDM = txt_xxdm.Text;
                xm_model.TBRQ = DateTime.Now;
                xm_model.SXSXQK_SXSXCSSZMJ = decimal.Parse(txt_SXSXQK_SXSXCSSZMJ.Text);
                xm_model.SXSXQK_SXSXCSJZMJ = decimal.Parse(txt_SXSXQK_SXSXCSJZMJ.Text);
                xm_model.SXSXQK_XYSXSBZZ = decimal.Parse(txt_SXSXQK_XYSXSBZZ.Text);
                xm_model.SXSXQK_XYSXYQSB = int.Parse(txt_SXSXQK_XYSXYQSB.Text);
                xm_model.SXSXQK_SBSJ = decimal.Parse(txt_SXSXQK_SBSJ.Text);
                xm_model.SXSXQK_SXSXKCMS = int.Parse(txt_SXSXQK_SXSXKCMS.Text);
                xm_model.SXSXQK_JSNNJPXRS = int.Parse(txt_SXSXQK_JSNNJPXRS.Text);

                xm_model.User_Uid = pb.GetIdentityId();
                if (IsAdd)
                {
                    return xm_bll.Add(xm_model) > 0;
                }
                else
                {
                    return xm_bll.Update(xm_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }

        }
        protected void Button_step3_Click(object sender, EventArgs e)
        {
            if (!Save_SXSXQK())
            {
                Alert.Show("实习实训情况数据保存失败，请检查数据正确性！");
                return;
            }
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = false;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(3);");
        }

        /// <summary>
        /// 保存基地负责人信息
        /// </summary>
        /// <returns></returns>
        /// DateTime：2015-03-25 18:17
        /// Author：By risfeng
        /// Author Email：risfeng@126.com
        public bool Save_JDFZRXX()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                xm_model = xm_bll.GetModel(xmbh);
                if (xm_model == null)
                {
                    IsAdd = true;
                    xm_model = new Model.CJYXTJD_XM();
                }
                //赋值
                xm_model.XMBH = ViewState["xmbh"].ToString();
                xm_model.JDFZRXX_XM = txt_JDFZRXX_XM.Text;
                xm_model.JDFZRXX_BMJZF = txt_JDFZRXX_BMJZF.Text;
                xm_model.JDFZRXX_ZYJSZW = txt_JDFZRXX_ZYJSZW.Text;
                xm_model.JDFZRXX_ZYZGZS = txt_JDFZRXX_ZYZGZS.Text;
                xm_model.JDFZRXX_BGDH = txt_JDFZRXX_BGDH.Text;
                xm_model.JDFZRXX_CZ = txt_JDFZRXX_CZ.Text;
                xm_model.JDFZRXX_SJ = txt_JDFZRXX_SJ.Text;
                xm_model.JDFZRXX_DZYX = txt_JDFZRXX_DZYX.Text;
                xm_model.JDFZRXX_JSYFYFW = txt_JDFZRXX_JSYFYFW.Text;
                xm_model.JDFZRXX_BRZHYQYJZ = txt_JDFZRXX_BRZHYQYJZ.Text;
                if (IsAdd)
                {
                    return xm_bll.Add(xm_model) > 0;
                }
                else
                {
                    return xm_bll.Update(xm_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }

        }
        protected void Button_step4_Click(object sender, EventArgs e)
        {
            if (!Save_JDFZRXX())
            {
                Alert.Show("基地负责人信息数据保存失败，请检查数据正确性！");
                return;
            }

            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = false;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(4);");
            //Alert.ShowInTop("4");
        }

        protected void Button_step5_Click(object sender, EventArgs e)
        {
            //判断是否添加了依托专业
            if (grid_YTZY.Rows.Count <= 0)
            {
                Alert.Show("请至少添加一个基地依托专业情况！");
                return;
            }
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = false;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            PageContext.RegisterStartupScript("a(5);");

        }

        /// <summary>
        /// 保存基地组织构架设想
        /// </summary>
        /// <returns></returns>
        /// DateTime：2015-03-25 18:17
        /// Author：By risfeng
        /// Author Email：risfeng@126.com
        public bool Save_JDZZJGSX()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                xm_model = xm_bll.GetModel(xmbh);
                if (xm_model == null)
                {
                    IsAdd = true;
                    xm_model = new Model.CJYXTJD_XM();
                }
                //赋值
                xm_model.XMBH = ViewState["xmbh"].ToString();
                xm_model.JDZZGJSX = txt_JDZZGJSX.Text;
                if (ViewState["file_zzjg"] != null)
                    xm_model.JDZZGJSXTP = ViewState["file_zzjg"].ToString().Trim();
                if (IsAdd)
                {
                    return xm_bll.Add(xm_model) > 0;
                }
                else
                {
                    return xm_bll.Update(xm_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }

        }
        protected void Button_step6_Click(object sender, EventArgs e)
        {
            if (!Save_JDZZJGSX())
            {
                Alert.Show("基地组织构架设想数据保存失败，请检查数据正确性！");
                return;
            }
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = false;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(6);");

        }

        /// <summary>
        /// 保存基地建设方案
        /// </summary>
        /// <returns></returns>
        /// DateTime：2015-03-25 18:17
        /// Author：By risfeng
        /// Author Email：risfeng@126.com
        public bool Save_JDJSFA()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                xm_model = xm_bll.GetModel(xmbh);
                if (xm_model == null)
                {
                    IsAdd = true;
                    xm_model = new Model.CJYXTJD_XM();
                }
                //赋值
                xm_model.XMBH = ViewState["xmbh"].ToString();

                xm_model.JDJSFA_SBLY = txt_JDJSFA_SBLY.Text;
                xm_model.JSGYHCPKF_PTMC = txt_JSGYHCPKF_PTMC.Text;
                xm_model.JSGYHCPKF_XM = txt_JSGYHCPKF_XM.Text;
                xm_model.JSGYHCPKF_BMJXZZF = txt_JSGYHCPKF_BMJXZZF.Text;
                xm_model.JSGYHCPKF_ZYJSZW = txt_JSGYHCPKF_ZYJSZW.Text;
                xm_model.JSGYHCPKF_ZYZGZS = txt_JSGYHCPKF_ZYZGZS.Text;
                xm_model.JSGYHCPKF_BGDH = txt_JSGYHCPKF_BGDH.Text;
                xm_model.JSGYHCPKF_CZ = txt_JSGYHCPKF_CZ.Text;
                xm_model.JSGYHCPKF_SJ = txt_JSGYHCPKF_SJ.Text;
                xm_model.JSGYHCPKF_DZYX = txt_JSGYHCPKF_DZYX.Text;

                xm_model.JSGYHCPKF_QYMC1 = txt_JSGYHCPKF_QYMC1.Text;
                xm_model.JSGYHCPKF_LXRXMJZW1 = txt_JSGYHCPKF_LXRXMJZW1.Text;
                xm_model.JSGYHCPKF_LXFS1 = txt_JSGYHCPKF_LXFS1.Text;
                xm_model.JSGYHCPKF_QYMC2 = txt_JSGYHCPKF_QYMC2.Text;
                xm_model.JSGYHCPKF_LXRXMJZW2 = txt_JSGYHCPKF_LXRXMJZW2.Text;
                xm_model.JSGYHCPKF_LXFS2 = txt_JSGYHCPKF_LXFS2.Text;
                xm_model.JSGYHCPKF_QYMC3 = txt_JSGYHCPKF_QYMC3.Text;
                xm_model.JSGYHCPKF_LXRXMJZW3 = txt_JSGYHCPKF_LXRXMJZW3.Text;
                xm_model.JSGYHCPKF_LXFS3 = txt_JSGYHCPKF_LXFS3.Text;

                //研发领域-选项（用|分隔）
                List<string> kfly_xx_list = new List<string>();
                foreach (var cbl in cbl_JSGYHCPKF_YFLY_XX.Items)
                {
                    if (cbl.Selected)
                    {
                        kfly_xx_list.Add(cbl.Value);
                    }
                }
                xm_model.JSGYHCPKF_YFLY_XX = string.Join("|", kfly_xx_list.ToArray());

                xm_model.JSGYHCPKF_YFLY_QT = txt_JSGYHCPKF_YFLY_QT.Text;
                xm_model.JSGYHCPKF_PTGNJJ = txt_JSGYHCPKF_PTGNJJ.Text;
                xm_model.JSGYHCPKF_PTWLGYHJJZB = txt_JSGYHCPKF_PTWLGYHJJZB.Text;
                xm_model.SXSXPT_PTMC = txt_SXSXPT_PTMC.Text;
                xm_model.SXSXPT_XM = txt_SXSXPT_XM.Text;
                xm_model.SXSXPT_BMJXZZW = txt_SXSXPT_BMJXZZW.Text;
                xm_model.SXSXPT_ZYJSZW = txt_SXSXPT_ZYJSZW.Text;
                xm_model.SXSXPT_ZYZGZS = txt_SXSXPT_ZYZGZS.Text;
                xm_model.SXSXPT_BGDH = txt_SXSXPT_BGDH.Text;
                xm_model.SXSXPT_CZ = txt_SXSXPT_CZ.Text;
                xm_model.SXSXPT_SJ = txt_SXSXPT_SJ.Text;
                xm_model.SXSXPT_DZYX = txt_SXSXPT_DZYX.Text;
                xm_model.SXSXPT_PTGNJJ = txt_SXSXPT_PTGNJJ.Text;
                xm_model.SXSXPT_PTWLSNJSMB = txt_SXSXPT_PTWLSNJSMB.Text;
                xm_model.JNDSGZS_GZSMC = txt_JNDSGZS_GZSMC.Text;
                xm_model.JNDSGZS_XM = txt_JNDSGZS_XM.Text;
                xm_model.JNDSGZS_XB = rbtn_JNDSGZS_XB.SelectedValue;
                xm_model.JNDSGZS_MZ = txt_JNDSGZS_MZ.Text;
                xm_model.JNDSGZS_CSNY = dp_JNDSGZS_CSNY.SelectedDate;
                xm_model.JNDSGZS_CJGZSJ = dp_JNDSGZS_CJGZSJ.SelectedDate;
                xm_model.JNDSGZS_ZZMM = txt_JNDSGZS_ZZMM.Text;
                xm_model.JNDSGZS_CSSY = txt_JNDSGZS_CSSY.Text;
                xm_model.JNDSGZS_ZYJNDJ = txt_JNDSGZS_ZYJNDJ.Text;
                xm_model.JNDSGZS_SJ = txt_JNDSGZS_SJ.Text;
                xm_model.JNDSGZS_YX = txt_JNDSGZS_YX.Text;
                xm_model.JNDSGZS_GZDWJZW = txt_JNDSGZS_GZDWJZW.Text;

                xm_model.JNDSGZS_GEJL = txt_JNDSGZS_GEJL.Text;
                xm_model.JNDSGZS_HSBJYSJLHGJZL = txt_JNDSGZS_HSBJYSJLHGJZL.Text;
                xm_model.JNDSGZS_ZYCXFMCG = txt_JNDSGZS_ZYCXFMCG.Text;
                xm_model.JNDSGZS_GZSJJ = txt_JNDSGZS_GZSJJ.Text;
                xm_model.JNDSGZS_GZSWLSNJSRW = txt_JNDSGZS_GZSWLSNJSRW.Text;
                xm_model.JTCS = txt_JTCS.Text;
                xm_model.JFAP = txt_JFAP.Text;
                xm_model.SSJH = txt_SSJH.Text;

                if (IsAdd)
                {
                    return xm_bll.Add(xm_model) > 0;
                }
                else
                {
                    return xm_bll.Update(xm_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }

        }
        protected void Button_step7_Click(object sender, EventArgs e)
        {
            if (!Save_JDJSFA())
            {
                Alert.Show("基地建设方案数据保存失败，请检查数据正确性！");
                return;
            }
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = false;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(7);");

        }
        protected void Button_step8_Click(object sender, EventArgs e)
        {
            //判断是否添加验收指标
            if (grid_JSHCP.Rows.Count <= 0 || grid_SXSXPT.Rows.Count <= 0 || grid_JNDS.Rows.Count <= 0)
            {
                Alert.Show("请确保每平台都已填写验收指标！");
                return;
            }
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = false;
            PageContext.RegisterStartupScript("a(8);");

        }


        protected void step2()
        {
            //s1.Visible = false;
            //s2.Visible = true;
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = false;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(2);");
        }
        protected void step3()
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = false;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(3);");
        }
        protected void step4()
        {

            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = false;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(4);");

        }
        protected void step5()
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = false;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(5);");

        }
        protected void step6()
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = false;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(6);");

        }
        protected void step7()
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = false;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(7);");

        }
        protected void step8()
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = false;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(8);");

        }


        protected void Button9_s2_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript("a(2);");
        }

        protected void ddlZYMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zydm1 = "", zyfxdm = "";
            try
            {
                if (ddlZYMC.SelectedValue.Trim().Contains("--请选择--"))
                {
                    txt_ZYKSNF.Text = "";
                    txt_ZYDM.Text = "";
                    return;
                }
                if (ddlZYMC.SelectedValue.Trim().Contains("@"))
                {
                    //zyfxdm = ZYMC.SelectedValue.Trim().Split(',')[0];
                }
                else
                    zyfxdm = ddlZYMC.SelectedValue.Trim().Split(',')[1];
                zydm1 = ddlZYMC.SelectedValue.Trim().Split(',')[0];

                string sqlstr = "select *  FROM ZYB1 where ZYDM='" + zydm1 + "' and ZYFXDM='" + zyfxdm + "' and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string m = "", d = "", sj = "";

                if (sdr.Read())
                {

                    txt_ZYDM.Text = sdr["ZYDM"].ToString().Trim();
                    sj = sdr["ZYKBSJ"].ToString().Trim();
                    //if (sj.Length == 6)
                    //{
                    //    try
                    //    {
                    //        m = sj.Substring(0, 4);
                    //        d = sj.Substring(4, 2);
                    //        sj = Convert.ToDateTime(m + "-" + d).ToString("yyyy");
                    //        txt_ZYKSNF.Text = sj;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        txt_ZYKSNF.Text = "";
                    //        Alert.ShowInTop(ex.Message);
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    txt_ZYKSNF.Text = "";
                    //}

                    txt_ZYKSNF.Text = sj;

                }

                sdr.Dispose();
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
                return;
            }

        }

        protected void btnSaveYTZY_Click(object sender, EventArgs e)
        {

            try
            {
                string zydm1 = "", zyfxdm = "", zybID = "";
                if (ddlZYMC.SelectedValue.Trim().Contains("@"))
                {
                    //zyfxdm = ZYMC.SelectedValue.Trim().Split(',')[0];
                }
                else
                    zyfxdm = ddlZYMC.SelectedValue.Trim().Split(',')[1];
                zydm1 = ddlZYMC.SelectedValue.Trim().Split(',')[0];

                string sqlstr = "select *  FROM ZYB1 where ZYDM='" + zydm1 + "' and ZYFXDM='" + zyfxdm + "' and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                if (sdr.Read())
                {
                    zybID = sdr["ID"].ToString();
                }
                sdr.Dispose();

                ytzy_model.XMBH = ViewState["xmbh"].ToString();
                ytzy_model.ZYB_ID = Convert.ToInt32(zybID);
                ytzy_model.NZSJHRS2015 = Convert.ToInt32(txt_NZSJHRS2015.Text.Trim());
                ytzy_model.ZXSRS = Convert.ToInt32(txt_ZXSRS.Text.Trim());
                ytzy_model.JSNPJJYL = Convert.ToDecimal(txt_JSNPJJYL.Text.Trim());
                ytzy_model.JSNZXSHDZGZSBL = Convert.ToDecimal(txt_JSNZXSHDZGZSBL.Text.Trim());
                ytzy_model.SFW085GCZDZY = cbx_SFW085GCZDZY.Checked ? 1 : 0;
                ytzy_model.XZSJ = DateTime.Now;
                ytzy_bll.Add(ytzy_model);

                BindYTZYGrid();

                form_ytzy.Reset();

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }

        }
        public void BindYTZYGrid()
        {
            string Sql = string.Format("SELECT  dbo.CJYXTJD_JDYTZYQK.ID, dbo.CJYXTJD_JDYTZYQK.ZYB_ID, dbo.CJYXTJD_JDYTZYQK.XMBH, dbo.CJYXTJD_JDYTZYQK.NZSJHRS2015, dbo.CJYXTJD_JDYTZYQK.ZXSRS, dbo.CJYXTJD_JDYTZYQK.JSNPJJYL, dbo.CJYXTJD_JDYTZYQK.JSNZXSHDZGZSBL, dbo.CJYXTJD_JDYTZYQK.SFW085GCZDZY, dbo.CJYXTJD_JDYTZYQK.XZSJ, dbo.ZYB1.ZYDM, dbo.ZYB1.ZYMC, dbo.ZYB1.ZYFXMC,dbo.ZYB1.ZYKBSJ FROM dbo.CJYXTJD_JDYTZYQK INNER JOIN dbo.ZYB1 ON dbo.CJYXTJD_JDYTZYQK.ZYB_ID = dbo.ZYB1.ID WHERE XMBH='{0}'", ViewState["xmbh"].ToString());
            DataSet ds = DbHelperSQL.Query(Sql);
            grid_YTZY.DataSource = ds;
            grid_YTZY.DataBind();

        }
        protected void btnDelWTZY_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(grid_YTZY);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                ytzy_bll.Delete(ids[i]);
            }
            BindYTZYGrid();

        }
        /// <summary>
        /// 获取表格选中项DataKeys的第一个值，并转化为整型列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        protected List<int> GetSelectedDataKeyIDs(Grid grid)
        {
            List<int> ids = new List<int>();
            foreach (int rowIndex in grid.SelectedRowIndexArray)
            {
                int RowIndex = rowIndex;
                // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                if (grid.AllowPaging && !grid.IsDatabasePaging)
                {
                    RowIndex = grid.PageIndex * grid.PageSize + RowIndex;
                }
                ids.Add(Convert.ToInt32(grid.DataKeys[RowIndex][0]));
            }

            return ids;
        }

        /// <summary>
        /// 保存经费预算
        /// </summary>
        /// <returns></returns>
        /// DateTime：2015-03-25 18:17
        /// Author：By risfeng
        /// Author Email：risfeng@126.com
        public bool Save_JFYS()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                xm_model = xm_bll.GetModel(xmbh);
                if (xm_model == null)
                {
                    IsAdd = true;
                    xm_model = new Model.CJYXTJD_XM();
                }
                //赋值
                xm_model.XMBH = ViewState["xmbh"].ToString();

                //专项经费
                xm_model.ZXJF_SQZXJF = decimal.Parse(NumberBox_sqzxjfhj.Text);
                xm_model.ZXJF_ZXKSSJ = DatePicker_sqzxjfzxksrq.SelectedDate;
                xm_model.ZXJF_ZXJSSJ = DatePicker_sqzxjfzxjsrq.SelectedDate;


                xm_model.ZXJF_KCJCJF2015 = decimal.Parse(NumberBox_sqzxjfkcjcjf_2015.Text);
                xm_model.ZXJF_KCJCJF2016 = decimal.Parse(NumberBox_sqzxjfkcjcjf_2016.Text);
                xm_model.ZXJF_KCJCJF2017 = decimal.Parse(NumberBox_sqzxjfkcjcjf_2017.Text);

                xm_model.ZXJF_SZJSJF2015 = decimal.Parse(NumberBox_sqzxjfszpxjf_2015.Text);
                xm_model.ZXJF_SZJSJF2016 = decimal.Parse(NumberBox_sqzxjfszpxjf_2016.Text);
                xm_model.ZXJF_SZJSJF2017 = decimal.Parse(NumberBox_sqzxjfszpxjf_2017.Text);

                xm_model.ZXJF_YQSBJF2015 = decimal.Parse(NumberBox_sqzxjfyqsbjf_2015.Text);
                xm_model.ZXJF_YQSBJF2016 = decimal.Parse(NumberBox_sqzxjfyqsbjf_2016.Text);
                xm_model.ZXJF_YQSBJF2017 = decimal.Parse(NumberBox_sqzxjfyqsbjf_2017.Text);

                xm_model.ZXJF_WPRYFY2015 = decimal.Parse(NumberBox_sqzxjfwpryfy_2015.Text);
                xm_model.ZXJF_WPRYFY2016 = decimal.Parse(NumberBox_sqzxjfwpryfy_2016.Text);
                xm_model.ZXJF_WPRYFY2017 = decimal.Parse(NumberBox_sqzxjfwpryfy_2017.Text);


                xm_model.ZXJF_YWF2015 = decimal.Parse(NumberBox_sqzxjfywf_2015.Text);
                xm_model.ZXJF_YWF2016 = decimal.Parse(NumberBox_sqzxjfywf_2016.Text);
                xm_model.ZXJF_YWF2017 = decimal.Parse(NumberBox_sqzxjfywf_2017.Text);

                xm_model.ZXJF_JFGSHJ2015 = decimal.Parse(NumberBox_sqzxjfgshj_2015.Text);
                xm_model.ZXJF_JFGSHJ2016 = decimal.Parse(NumberBox_sqzxjfgshj_2016.Text);
                xm_model.ZXJF_JFGSHJ2017 = decimal.Parse(NumberBox_sqzxjfgshj_2017.Text);


                //学校经费
                xm_model.XXPTJF_XXPTJF = decimal.Parse(NumberBox_xxptjfhj.Text);
                xm_model.XXPTJF_ZXKSSJ = DatePicker_xxptjfzxksrq.SelectedDate;
                xm_model.XXPTJF_ZXJSSJ = DatePicker_xxptjfzxjsrq.SelectedDate;


                xm_model.XXPTJF_KCJCJF2015 = decimal.Parse(NumberBox_xxptkcjcjf_2015.Text);
                xm_model.XXPTJF_KCJCJF2016 = decimal.Parse(NumberBox_xxptkcjcjf_2016.Text);
                xm_model.XXPTJF_KCJCJF2017 = decimal.Parse(NumberBox_xxptkcjcjf_2017.Text);

                xm_model.XXPTJF_SZJSJF2015 = decimal.Parse(NumberBox_xxptszpxf_2015.Text);
                xm_model.XXPTJF_SZJSJF2016 = decimal.Parse(NumberBox_xxptszpxf_2016.Text);
                xm_model.XXPTJF_SZJSJF2017 = decimal.Parse(NumberBox_xxptszpxf_2017.Text);

                xm_model.XXPTJF_YQSBJF2015 = decimal.Parse(NumberBox_xxptyqsbjf_2015.Text);
                xm_model.XXPTJF_YQSBJF2016 = decimal.Parse(NumberBox_xxptyqsbjf_2016.Text);
                xm_model.XXPTJF_YQSBJF2017 = decimal.Parse(NumberBox_xxptyqsbjf_2017.Text);

                xm_model.XXPTJF_WPRYJF2015 = decimal.Parse(NumberBox_xxptwpryfy_2015.Text);
                xm_model.XXPTJF_WPRYJF2016 = decimal.Parse(NumberBox_xxptwpryfy_2016.Text);
                xm_model.XXPTJF_WPRYJF2017 = decimal.Parse(NumberBox_xxptwpryfy_2017.Text);


                xm_model.XXPTJF_YWF2015 = decimal.Parse(NumberBox_xxptywf_2015.Text);
                xm_model.XXPTJF_YWF2016 = decimal.Parse(NumberBox_xxptywf_2016.Text);
                xm_model.XXPTJF_YWF2017 = decimal.Parse(NumberBox_xxptywf_2017.Text);

                xm_model.XXPTJF_JFGSHJ2015 = decimal.Parse(NumberBox_xxptgshj_2015.Text);
                xm_model.XXPTJF_JFGSHJ2016 = decimal.Parse(NumberBox_xxptgshj_2016.Text);
                xm_model.XXPTJF_JFGSHJ2017 = decimal.Parse(NumberBox_xxptgshj_2017.Text);

                if (IsAdd)
                {
                    return xm_bll.Add(xm_model) > 0;
                }
                else
                {
                    return xm_bll.Update(xm_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }

        }
        protected void Button_step9_Click(object sender, EventArgs e)
        {
            if (!Save_JFYS())
            {
                Alert.Show("经费预算保存失败，请检查数据正确性！");
                return;
            }
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = false;
            PageContext.RegisterStartupScript("a(9);");
        }

        protected void btnDelJSGYHCPKFZB_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(grid_JSHCP);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                yszb_bll.Delete(ids[i]);
            }
            BindJSHCPGrid();

        }

        protected void btnSaveJSHCP_Click(object sender, EventArgs e)
        {
            yszb_model.XMBH = ViewState["xmbh"].ToString();
            yszb_model.JSMB = txt_JSHCP_JSMB.Text;
            yszb_model.YQWCSJ = dp_JSHCP_YQWCSJ.SelectedDate.ToString();
            yszb_model.YSYD = txt_JSHCP_YSYD.Text;
            yszb_model.ZBFL = 1;//指标分类(1-技术工艺和产品开发平台 2-实习实训平台 3-技能大师工作室）

            yszb_bll.Add(yszb_model);

            BindJSHCPGrid();

            GroupPanel28.Reset();

        }

        protected void btnSaveSXSXPT_Click(object sender, EventArgs e)
        {
            yszb_model.XMBH = ViewState["xmbh"].ToString();
            yszb_model.JSMB = txt_SXSXPT_JSMB.Text;
            yszb_model.YQWCSJ = dp_SXSXPT_YQWCSJ.SelectedDate.ToString();
            yszb_model.YSYD = txt_SXSXPT_YSYD.Text;
            yszb_model.ZBFL = 2;//指标分类(1-技术工艺和产品开发平台 2-实习实训平台 3-技能大师工作室）

            yszb_bll.Add(yszb_model);

            BindSXSXGrid();
            GroupPanel29.Reset();

        }

        protected void btnDelSXSXPT_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(grid_SXSXPT);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                yszb_bll.Delete(ids[i]);
            }
            BindSXSXGrid();

        }

        protected void btnSaveJNDS_Click(object sender, EventArgs e)
        {
            yszb_model.XMBH = ViewState["xmbh"].ToString();
            yszb_model.JSMB = txt_JNDS_JSMB.Text;
            yszb_model.YQWCSJ = dp_JNDS_YQWCSJ.SelectedDate.ToString();
            yszb_model.YSYD = txt_JNDS_YSYD.Text;
            yszb_model.ZBFL = 3;//指标分类(1-技术工艺和产品开发平台 2-实习实训平台 3-技能大师工作室）

            yszb_bll.Add(yszb_model);

            BindJNDSGrid();

            GroupPanel30.Reset();

        }

        protected void btnDelJNDS_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(grid_JNDS);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                yszb_bll.Delete(ids[i]);
            }
            BindJNDSGrid();

        }
        public void BindJSHCPGrid()
        {
            string Sql = string.Format("SELECT dbo.CJYXTJD_XMYSZB.ID, dbo.CJYXTJD_XMYSZB.XMBH, dbo.CJYXTJD_XMYSZB.JSMB, dbo.CJYXTJD_XMYSZB.YQWCSJ, dbo.CJYXTJD_XMYSZB.YSYD, dbo.CJYXTJD_XMYSZB.ZBFL FROM dbo.CJYXTJD_XMYSZB WHERE XMBH ='{0}' AND ZBFL = 1", ViewState["xmbh"].ToString());
            DataSet ds = DbHelperSQL.Query(Sql);
            grid_JSHCP.DataSource = ds;
            grid_JSHCP.DataBind();

        }
        public void BindSXSXGrid()
        {
            string Sql = string.Format("SELECT dbo.CJYXTJD_XMYSZB.ID, dbo.CJYXTJD_XMYSZB.XMBH, dbo.CJYXTJD_XMYSZB.JSMB, dbo.CJYXTJD_XMYSZB.YQWCSJ, dbo.CJYXTJD_XMYSZB.YSYD, dbo.CJYXTJD_XMYSZB.ZBFL FROM dbo.CJYXTJD_XMYSZB WHERE XMBH ='{0}' AND ZBFL = 2", ViewState["xmbh"].ToString());
            DataSet ds = DbHelperSQL.Query(Sql);
            grid_SXSXPT.DataSource = ds;
            grid_SXSXPT.DataBind();

        }
        public void BindJNDSGrid()
        {
            string Sql = string.Format("SELECT dbo.CJYXTJD_XMYSZB.ID, dbo.CJYXTJD_XMYSZB.XMBH, dbo.CJYXTJD_XMYSZB.JSMB, dbo.CJYXTJD_XMYSZB.YQWCSJ, dbo.CJYXTJD_XMYSZB.YSYD, dbo.CJYXTJD_XMYSZB.ZBFL FROM dbo.CJYXTJD_XMYSZB WHERE XMBH ='{0}' AND ZBFL = 3", ViewState["xmbh"].ToString());
            DataSet ds = DbHelperSQL.Query(Sql);
            grid_JNDS.DataSource = ds;
            grid_JNDS.DataBind();

        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            try
            {
                //附件
                Model.XMFJ XMFJ_Mode = new Model.XMFJ();
                BLL.XMFJ XMFJ_Bll = new BLL.XMFJ();
                XMFJ_Mode.XMBH = ViewState["xmbh"].ToString().Trim();
                if (ViewState["file1"] != null)
                    XMFJ_Mode.XMKXXFXBGWJM = ViewState["file1"].ToString();
                if (ViewState["file2"] != null)
                    XMFJ_Mode.YXXSALWJM = ViewState["file2"].ToString();
                if (ViewState["file3"] != null)
                    XMFJ_Mode.XMYSMXWJM = ViewState["file3"].ToString();

                XMFJ_Bll.Add(XMFJ_Mode);

                //文档管理
                string filename = string.Format("{0}_{1}_{2}.doc", ViewState["xxdm"], ViewState["xmbh"], DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015项目申报书(产教研协同基地)150226.doc");
                var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

                xm_model = xm_bll.GetModel(ViewState["xmbh"].ToString());//加载项目信息

                if (new BuildWord().BuildWord_2015ProjectDeclaration_CJYXTJD(tmppath, savepath, xm_model.XMBH))
                {
                    BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                    Model.XMSBSWD model = new Model.XMSBSWD();
                    model.XMBH = xm_model.XMBH;
                    model.XMMC = xm_model.JDMC;
                    model.WDLJ = savepath;
                    wordBll.Add(model);

                }
                else
                {
                    Alert.Show("生成Word失败！");
                    return;
                }
                PageContext.RegisterStartupScript("alert('已成功保存,系统将自动关闭此页面');CloseWebPage();");

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (FileUpload4.HasFile)
            {
                try
                {
                    string fileName = FileUpload4.ShortFileName;


                    //if (fileName.Contains(".jpg") || fileName.Contains(".jpeg"))
                    //{

                    fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                    fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                    FileUpload4.SaveAs(Server.MapPath("upload/组织构架设想图片/" + fileName));
                    ViewState["file_zzjg"] = fileName;
                    Alert.ShowInTop("上传成功！");
                    //}
                    //else
                    //{
                    //    Alert.ShowInTop("请上传word格式的文件！");
                    //}

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

    }
}