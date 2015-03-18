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
            DataTable dt1=null,dt2=null,dt3=null;
              sqlstr = "select  a.XMBH as XMBH,  b.XXMC AS XXMC, '一流专业建设' as XMDLMC,a.XMMC as XMMC,a.ZYFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6   ) as a,XXJBQKB as b where a.XXDM=b.XXDM";
                dt1 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select a.XMBH as XMBH,  b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM";
                dt2 = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select  a.XMBH as XMBH, b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM";
                dt3 = DbHelperSQL.Query(sqlstr).Tables[0];
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