using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using System.Data.SqlClient;
using System.Data;
using AppBox;
using Maticsoft.DBUtility;
using FineUI;
namespace XMGL.Web.admin
{
    public partial class HZBLXR_AddorUp : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnCheckSelection.OnClientClick = Window1.GetShowReference("XMFL.aspx", "填写申报项目")+Window1.GetMaximizeReference();
              
                string userid = pb.GetIdentityId();
                string sqlstr = "select xxdm,xxmc from Users where user_uid='" + userid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string xxdm = "", xxmc = "";
                if (sdr.Read())
                {
                    xxdm = sdr["xxdm"].ToString().Trim();
                    ViewState["xxdm"] = xxdm;
                    xxmc = sdr["xxmc"].ToString().Trim();
                    ViewState["xxmc"] = xxmc;

                }
                sdr.Dispose();
                sqlstr = "select * from HZBLXR where XXDM='" + xxdm + "'";
                sdr = DbHelperSQL.ExecuteReader(sqlstr);
                if (sdr.Read())
                {
                    TextBox_lxr.Text = sdr["LXR"].ToString().Trim();
                    TextBox_dh.Text = sdr["DH"].ToString().Trim();
                    TextBox_sj.Text = sdr["SJ"].ToString().Trim();
                    TextBox_cz.Text = sdr["CZ"].ToString().Trim();
                    TextBox1.Text = sdr["DZYX"].ToString().Trim();
                    TextBox2.Text = sdr["DZ"].ToString().Trim();
                    TextBox3.Text = sdr["YB"].ToString().Trim();
                }
                sdr.Dispose();

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Model.HZBLXR HZBLXR_Model = new Model.HZBLXR();          
            BLL.HZBLXR HZBLXR_Bll = new BLL.HZBLXR();
            HZBLXR_Model.XXDM = ViewState["xxdm"].ToString().Trim();
            HZBLXR_Model.LXR = TextBox_lxr.Text.Trim();
            HZBLXR_Model.DH = TextBox_dh.Text.Trim();
            HZBLXR_Model.SJ = TextBox_sj.Text.Trim();
            HZBLXR_Model.CZ = TextBox_cz.Text.Trim();
            HZBLXR_Model.DZYX = TextBox1.Text.Trim();
            HZBLXR_Model.DZ = TextBox2.Text.Trim();
            HZBLXR_Model.YB = TextBox3.Text.Trim();

              string sqlstr ="";
              DataTable dt1 = null, dt2 = null, dt3 = null, dt4 = null, dt4_t1 = null, dt4_t2 = null, dt4_t3 = null, dt5 = null, dt6 = null, dt7 = null;
            sqlstr = "select  a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6   ) as a,XXJBQKB as b where a.XXDM=b.XXDM and a.XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM and a.XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select  a.XMBH as XMBH, b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM and a.XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                dt3 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH,a.DWMC AS XXMC,a.XMDLMC,a.XMMC,'' as ZYFZR_XM,a.SQZXJF,a.XXPTJF,a.XMZJF from (select SZPX_XMSB.XMBH,SZPX_XMSB.DWMC,'师资培训' as XMDLMC ,SZPX_XMSB.XMMC,SZPX_JFYS.JFYS as SQZXJF ,0.0 as XXPTJF,SZPX_JFYS.JFYS as XMZJF from SZPX_XMSB,SZPX_JFYS where SZPX_XMSB.XMBH=SZPX_JFYS.XMBH and SZPX_JFYS.JFLX='ZXJF' and SZPX_XMSB.SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC and a.DWMC='" + ViewState["xxmc"].ToString().Trim() + "'";
                dt4 = DbHelperSQL.Query(sqlstr).Tables[0];
                sqlstr = "select a.XMBH,a.JFYS from (select SZPX_XMSB.XMBH,SZPX_JFYS.JFYS ,SZPX_XMSB.DWMC from SZPX_XMSB,SZPX_JFYS where SZPX_XMSB.XMBH=SZPX_JFYS.XMBH and SZPX_JFYS.JFLX='PTJF' and SZPX_XMSB.SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC and a.DWMC='" + ViewState["xxmc"].ToString().Trim() + "'";
                dt4_t2 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH,a.CYXM from (select SZPX_XMCY.CYXM ,SZPX_XMSB.DWMC,SZPX_XMSB.XMBH from SZPX_XMCY,SZPX_XMSB where SZPX_XMCY.XMBH=SZPX_XMSB.XMBH and SZPX_XMCY.CYLX='FZR' and SZPX_XMSB.SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC and a.DWMC='" + ViewState["xxmc"].ToString().Trim() + "'";
                dt4_t3 = DbHelperSQL.Query(sqlstr).Tables[0];
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    for (int j = 0; j < dt4_t2.Rows.Count; j++)
                    {
                        if (dt4.Rows[i]["XMBH"].ToString().Trim() == dt4_t2.Rows[j]["XMBH"].ToString().Trim())
                        {
                            dt4.Rows[i]["XXPTJF"] = dt4_t2.Rows[j]["JFYS"];
                            dt4.Rows[i]["XMZJF"] = Convert.ToDouble(dt4.Rows[i]["XMZJF"]) + Convert.ToDouble(dt4_t2.Rows[j]["JFYS"]);
                        }
                    }

                    for (int k = 0; k < dt4_t3.Rows.Count; k++)
                    {
                        if (dt4.Rows[i]["XMBH"].ToString().Trim() == dt4_t3.Rows[k]["XMBH"].ToString().Trim())
                        {
                            dt4.Rows[i]["ZYFZR_XM"] = dt4_t3.Rows[k]["CYXM"];

                        }
                    }
                }

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '技术技能竞赛' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from JSJNJS_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC and a.DWMC='" + ViewState["xxmc"].ToString().Trim() + "'";
                dt5 = DbHelperSQL.Query(sqlstr).Tables[0];
                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '信息管理平台' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from XXGLPT_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC and a.DWMC='" + ViewState["xxmc"].ToString().Trim() + "'";
                dt6 = DbHelperSQL.Query(sqlstr).Tables[0];
                sqlstr = "select  a.XMBH as XMBH, b.XXMC AS XXMC, '通用类' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from TYL_XM where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.DWMC=b.XXMC and a.DWMC='" + ViewState["xxmc"].ToString().Trim() + "'";
                dt7 = DbHelperSQL.Query(sqlstr).Tables[0];
              DataRow dr = null;
            if (dt2 != null)
            {
                for (int i = 0; i<dt2.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {
                      
                        dt1.ImportRow(dt2.Rows[i]);
                    }
                }
            }

            if (dt3 != null)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {
                      
                        dt1.ImportRow(dt3.Rows[i]);
                    }
                }
            }

            if (dt4 != null)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt4.Rows[i]);
                    }
                }
            }

            if (dt5 != null)
            {
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt5.Rows[i]);
                    }
                }
            }

            if (dt6 != null)
            {
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt6.Rows[i]);
                    }
                }
            }

            if (dt7 != null)
            {
                for (int i = 0; i < dt7.Rows.Count; i++)
                {
                    if (dt1 != null)
                    {

                        dt1.ImportRow(dt7.Rows[i]);
                    }
                }
            }

            HZBLXR_Model.HZBWDLJ = "";
            sqlstr = "delete from HZBLXR where XXDM='" + ViewState["xxdm"].ToString() + "'";
            DbHelperSQL.ExecuteSql(sqlstr);
            HZBLXR_Bll.Add(HZBLXR_Model);

              string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"].ToString() + ".doc";
                var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015年上海高等职业教育提升计划项目申报汇总表.docx");
                var savepath = HttpContext.Current.Server.MapPath("~/admin/down/汇总表/" + filename);
                if (dt1.Rows.Count != 0)
                {

                    if (new BuildWord().BuildWord_HZB_YX(tmppath, savepath, ViewState["xxdm"].ToString(), dt1))
                    {
                        HZBLXR_Model.HZBWDLJ = savepath;
                        sqlstr = "delete from HZBLXR where XXDM='" + ViewState["xxdm"].ToString() + "'";
                        DbHelperSQL.ExecuteSql(sqlstr);
                        HZBLXR_Bll.Add(HZBLXR_Model);
                        PageContext.RegisterStartupScript("alert('已成功保存,系统将自动关闭此页面后,请刷新首页后方可查看');CloseWebPage();");
                    }
                    else
                    {
                        Alert.Show("保存失败");
                        return;
                    }
                }
                else
                {
                  
                    Alert.Show("没有汇总数据");
                    return;
                }
          



          

        }
    }
}