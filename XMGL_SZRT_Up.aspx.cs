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
    public partial class XMGL_SZRT_Up : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string xmbh = "";
                if (Request.QueryString["xmbh"] != null)
                {
                    xmbh = Request.QueryString["xmbh"].ToString().Trim();
                    ViewState["xmbh"] = xmbh;
                }
                else
                {

                    Alert.ShowInTop("非法的请求");
                    return;
                }


                jhysrq1.MinDate = DateTime.Now.AddDays(1);
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



                databind_ZJZ();
                datatablebind();

                BLL.SZRT SZRT_Bll = new BLL.SZRT();
                Model.SZRT SZRT_Model = null;
                sqlstr = "select * from SZRT where XMBH='" + xmbh + "'";
                sdr = DbHelperSQL.ExecuteReader(sqlstr);

                if (sdr.Read())
                {
                    SZRT_Model = SZRT_Bll.GetModel(Convert.ToInt32(sdr["ID"].ToString().Trim()));
                    ViewState["ID"] = SZRT_Model.ID;
                    TextBox_xmmc.Text = sdr["XMMC"].ToString().Trim();
                    TextBox_DWMC1.Text = sdr["DWMC"].ToString().Trim();
                    XM1.Text = sdr["XMFZR_XM"].ToString().Trim();
                    BM1.Text = sdr["XMFZR_BM"].ToString().Trim();
                    ZYJSZW1.Text = sdr["XMFZR_ZYJSZW"].ToString().Trim();
                    XZZW1.Text = sdr["XMFZR_XZZW"].ToString().Trim();
                    BGSDH1.Text = sdr["XMFZR_BGSDH"].ToString().Trim();
                    CZ1.Text = sdr["XMFZR_CZ"].ToString().Trim();
                    SJ1.Text = sdr["XMFZR_SJ"].ToString().Trim();
                    DZYX1.Text = sdr["XMFZR_DZYX"].ToString().Trim();

                    ZSMC1.Text = sdr["ZS_MC"].ToString().Trim();
                    ZSDJ1.Text = sdr["ZS_DJ"].ToString().Trim();
                    BFBM1.Text = sdr["ZS_BFBM"].ToString().Trim();
                    KZSJ1.Text = sdr["ZS_KZSJ"].ToString().Trim();
                    MNKKCS1.Text = sdr["ZS_MNKKCS"].ToString().Trim();
                    XZZSYY1.Text = sdr["ZS_XZYY"].ToString().Trim();
                    SXKHTJ1.Text = sdr["SXKHTJ"].ToString().Trim();

                    SQZXJF1.Text = sdr["JFYS_SQJF"].ToString().Trim();
                    ZXKSRQ1.Text = sdr["JFYS_ZXQX_1"].ToString().Trim();
                    ZXJSRQ1.Text = sdr["JFYS_ZXQX_2"].ToString().Trim();
                    KCJCJFJE1.Text = sdr["JFYS_KCJCJF_JE"].ToString().Trim();
                    KCJCJFGSYJ1.Text = sdr["JFYS_KCJCJF_GSYJ"].ToString().Trim();
                    KCJCJFBZ1.Text = sdr["JFYS_KCJCJF_BZ"].ToString().Trim();
                    YQSBJE1.Text = sdr["JFYS_YQSBJF_JE"].ToString().Trim();
                    YQSBJFGSYJ1.Text = sdr["JFYS_YQSBJF_GSYJ"].ToString().Trim();
                    YQSBJFBZ1.Text = sdr["JFYS_YQSBJF_BZ"].ToString().Trim();
                    WPRYFYJE1.Text = sdr["JFYS_WPRYJF_JE"].ToString().Trim();
                    WPRYJFGSYJ1.Text = sdr["JFYS_WPRYJF_GSYJ"].ToString().Trim();
                    WPRYFYBZ1.Text = sdr["JFYS_WPRYJF_BZ"].ToString().Trim();
                    YWFJE1.Text = sdr["JFYS_YWF_JE"].ToString().Trim();
                    YWFGSYJ1.Text = sdr["JFYS_YWF_GSYJ"].ToString().Trim();
                    YWFBZ1.Text = sdr["JFYS_YWF_BZ"].ToString().Trim();
                    JFHJ1.Text = sdr["JFYS_JFHJ"].ToString().Trim();

                    SQZXJF2.Text = sdr["JFYS_XXPTJF"].ToString().Trim();
                    ZXKSRQ2.Text = sdr["JFYS_ZXQX3"].ToString().Trim();
                    ZXJSRQ2.Text = sdr["JFYS_ZXQX4"].ToString().Trim();
                    KCJCJFJE2.Text = sdr["JFYS_KCJCJF_JE2"].ToString().Trim();
                    KCJCJFGSYJ2.Text = sdr["JFYS_KCJCJF_GSYJ2"].ToString().Trim();
                    KCJCJFBZ2.Text = sdr["JFYS_KCJCJF_BZ2"].ToString().Trim();
                    YQSBJE2.Text = sdr["JFYS_YQSBJF_JE2"].ToString().Trim();
                    YQSBJFGSYJ2.Text = sdr["JFYS_YQSBJF_GSYJ2"].ToString().Trim();
                    YQSBJFBZ2.Text = sdr["JFYS_YQSBJF_BZ2"].ToString().Trim();
                    WPRYFYJE2.Text = sdr["JFYS_WPRYFY_JE2"].ToString().Trim();
                    WPRYJFGSYJ2.Text = sdr["JFYS_WPRYFY_GSYJ2"].ToString().Trim();
                    WPRYFYBZ2.Text = sdr["JFYS_WPRYFY_BZ2"].ToString().Trim();
                    YWFJE2.Text = sdr["JFYS_YWF_JE2"].ToString().Trim();
                    YWFGSYJ2.Text = sdr["JFYS_YWF_GSYJ2"].ToString().Trim();
                    YWFBZ2.Text = sdr["JFYS_YWF_BZ2"].ToString().Trim();
                    JFHJ2.Text = sdr["JFYS_JFHJ2"].ToString().Trim();
                    FileUpload1.EmptyText = sdr["FJ1"].ToString().Trim();
                    FileUpload2.EmptyText = sdr["FJ2"].ToString().Trim();
                    FileUpload3.EmptyText = sdr["FJ3"].ToString().Trim();

                }
                sdr.Dispose();
            }
        }
        protected void datatablebind()
        {
            string sqlstr = "";
            DataTable dt = new DataTable();
            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[CYXM] as xm,[BMZW] as bm,[RWFG] as rwfg,[SJ] as sj,[DZYX] as dzyx from [SZRT_XMTDRYXX] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid4.DataSource = dt;
            Grid4.DataBind();
            ViewState["dt_wh1"] = dt;

            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[RTKC_MC] as kcmc,[RTKC_NR] as kczynr,[RTKC_KCDYZS] as kcdyzs,[RTKC_KHFS] as khfs from [SZRT_RTKCSZ] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
            ViewState["dt_wh2"] = dt;

            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[XM] as xm,[ZC] as zc,[ZJKC] as zjkc,[ZYZGZS] as zyzgzs,[ZJZ] as zjz from [SZRT_ZYJSXX] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid2.DataSource = dt;
            Grid2.DataBind();
            ViewState["dt_wh3"] = dt;

            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[JSMB] as jsmb,[JHYSRQ] as jhysrq,[YSYD] as ysyd from [SZRT_SBXMYSMB] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid3.DataSource = dt;
            Grid3.DataBind();
            ViewState["dt_wh4"] = dt;
        }


 

        protected void Button4_Click(object sender, EventArgs e)
        {
            Model.SZRT SZRT_Model = new Model.SZRT();
            Model.SZRT_RTKCSZ SZRT_RTKCSZ_Model = new Model.SZRT_RTKCSZ();
            Model.SZRT_SBXMYSMB SZRT_SBXMYSMB_Model = new Model.SZRT_SBXMYSMB();
            Model.SZRT_XMTDRYXX SZRT_XMTDRYXX_Model = new Model.SZRT_XMTDRYXX();
            Model.SZRT_ZYJSXX SZRT_ZYJSXX_Model = new Model.SZRT_ZYJSXX();


            BLL.SZRT SZRT_Bll = new BLL.SZRT();
            BLL.SZRT_RTKCSZ SZRT_RTKCSZ_Bll = new BLL.SZRT_RTKCSZ();
            BLL.SZRT_SBXMYSMB SZRT_SBXMYSMB_Bll = new BLL.SZRT_SBXMYSMB();
            BLL.SZRT_XMTDRYXX SZRT_XMTDRYXX_Bll = new BLL.SZRT_XMTDRYXX();
            BLL.SZRT_ZYJSXX SZRT_ZYJSXX_Bll = new BLL.SZRT_ZYJSXX();
            SZRT_Model = SZRT_Bll.GetModel(Convert.ToInt32(ViewState["ID"].ToString().Trim()));



            if (TextBox_xmmc.Text.Trim() == "")
            {
                step2();
                Alert.Show("“申报项目名称”为必填项");
                return;
            }
            if (TextBox_DWMC1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“单位名称”为必填项");
                return;
            }
            if (XM1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“姓名”为必填项");
                return;
            }
            if (BM1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“部门”为必填项");
                return;
            }
            if (ZYJSZW1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“专业技术职务”为必填项");
                return;
            }
            if (XZZW1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“行政职务”为必填项");
                return;
            }
            if (BGSDH1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“办公室电话”为必填项");
                return;
            }
            if (CZ1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“传真”为必填项");
                return;
            }
            if (SJ1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“手机”为必填项");
                return;
            }
            if (DZYX1.Text.Trim() == "")
            {
                step2();
                Alert.Show("“电子邮箱”为必填项");
                return;
            }
            if (ZSMC1.Text.Trim() == "")
            {
                step3();
                Alert.Show("“证书名称”为必填项");
                return;
            }
            if (ZSDJ1.Text.Trim() == "")
            {
                step3();
                Alert.Show("“证书等级”为必填项");
                return;
            }
            if (BFBM1.Text.Trim() == "")
            {
                step3();
                Alert.Show("“颁发部门”为必填项");
                return;
            }
            if (KZSJ1.Text.Trim() == "")
            {
                step3();
                Alert.Show("“考证时间”为必填项");
                return;
            }
            if (MNKKCS1.Text.Trim() == "")
            {
                step3();
                Alert.Show("“每年可考次数”为必填项");
                return;
            }
            if (XZZSYY1.Text.Trim() == "")
            {
                step3();
                Alert.Show("“选择该证书的原因说明”为必填项");
                return;
            }
            if (SXKHTJ1.Text.Trim() == "")
            {
                step6();
                Alert.Show("“选择理由”为必填项");
                return;
            }
            if (ZXKSRQ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“执行开始日期”为必填项");
                return;
            }
            if (ZXKSRQ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“执行结束日期”为必填项");
                return;
            }
            if (KCJCJFGSYJ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“课程教材经费概算依据”为必填项");
                return;
            }
            if (KCJCJFBZ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“课程教材经费备注”为必填项");
                return;
            }
            if (YQSBJFGSYJ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“仪器设备经费概算依据”为必填项");
                return;
            }
            if (YQSBJFBZ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“仪器设备经费备注”为必填项");
                return;
            }
            if (WPRYJFGSYJ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“外聘人员费用概算依据”为必填项");
                return;
            }
            if (WPRYFYBZ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“外聘人员费用备注”为必填项");
                return;
            }
            if (YWFGSYJ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“业务费（包括会议、差旅、印刷、交通等）概算依据”为必填项");
                return;
            }
            if (YWFBZ1.Text.Trim() == "")
            {
                step8();
                Alert.Show("“业务费（包括会议、差旅、印刷、交通等）备注”为必填项");
                return;
            }
            if (ZXKSRQ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“执行开始日期”为必填项");
                return;
            }
            if (ZXJSRQ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“执行结束日期”为必填项");
                return;
            }
            if (KCJCJFGSYJ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“课程教材经费概算依据”为必填项");
                return;
            }
            if (KCJCJFBZ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“课程教材经费备注”为必填项");
                return;
            }
            if (YQSBJFGSYJ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“仪器设备经费概算依据”为必填项");
                return;
            }
            if (YQSBJFBZ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“仪器设备经费备注”为必填项");
                return;
            }
            if (WPRYJFGSYJ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“外聘人员费用概算依据”为必填项");
                return;
            }
            if (WPRYFYBZ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“外聘人员费用备注”为必填项");
                return;
            }
            if (YWFGSYJ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“业务费（包括会议、差旅、印刷、交通等）概算依据”为必填项");
                return;
            }
            if (YWFBZ2.Text.Trim() == "")
            {
                step8();
                Alert.Show("“业务费（包括会议、差旅、印刷、交通等）备注”为必填项");
                return;
            }

            DataTable dt = null;
            DataTable dt2 = null;
            DataTable dt3 = null;
            DataTable dt4 = null;
            if (ViewState["dt_wh1"] != null)
                dt = ViewState["dt_wh1"] as DataTable;
            else
            {
                step2();
                Alert.Show("没有添加项目成员");
                return;
            }
            if (ViewState["dt_wh2"] != null)
                dt2 = ViewState["dt_wh2"] as DataTable;
            else
            {
                step4();
                Alert.Show("没有添加融通课程");
                return;
            }
            if (ViewState["dt_wh3"] != null)
                dt3 = ViewState["dt_wh3"] as DataTable;
            else
            {
                step5();
                Alert.Show("没有添加专业教师信息");
                return;
            }
            if (ViewState["dt_wh4"] != null)
                dt4 = ViewState["dt_wh4"] as DataTable;
            else
            {
                step7();
                Alert.Show("没有添加专业教师信息");
                return;
            }
            try
            {
                SZRT_Model.XMBH = ViewState["xmbh"].ToString().Trim();
                SZRT_Model.XMMC = TextBox_xmmc.Text.Trim();
                //ViewState["xmbh"] = SZRT_Model.XMBH;
                SZRT_Model.XXDM = ViewState["xxdm"].ToString().Trim();
                SZRT_Model.DWMC = TextBox_DWMC1.Text.Trim();

                SZRT_Model.XMFZR_XM = XM1.Text.Trim();
                SZRT_Model.XMFZR_BM = BM1.Text.Trim();
                SZRT_Model.XMFZR_ZYJSZW = ZYJSZW1.Text.Trim();
                SZRT_Model.XMFZR_XZZW = XZZW1.Text.Trim();
                SZRT_Model.XMFZR_BGSDH = BGSDH1.Text.Trim();
                SZRT_Model.XMFZR_CZ = CZ1.Text.Trim();
                SZRT_Model.XMFZR_SJ = SJ1.Text.Trim();
                SZRT_Model.XMFZR_DZYX = DZYX1.Text.Trim();


                SZRT_Model.ZS_MC = ZSMC1.Text.Trim();
                SZRT_Model.ZS_DJ = ZSDJ1.Text.Trim();
                SZRT_Model.ZS_BFBM = BFBM1.Text.Trim();
                SZRT_Model.ZS_KZSJ = KZSJ1.Text.Trim();
                SZRT_Model.ZS_MNKKCS = Convert.ToInt32(MNKKCS1.Text.Trim());
                SZRT_Model.ZS_XZYY = XZZSYY1.Text.Trim();

                SZRT_Model.SXKHTJ = SXKHTJ1.Text.Trim();

                //SZRT_Model.JFYS_SQJF = Convert.ToInt32(SQZXJF1.Text.Trim());
                SZRT_Model.JFYS_SQJF = Convert.ToDecimal(SQZXJF1.Text.Trim());
                SZRT_Model.JFYS_ZXQX_1 = ZXKSRQ1.Text.Trim();
                SZRT_Model.JFYS_ZXQX_2 = ZXJSRQ1.Text.Trim();
                SZRT_Model.JFYS_KCJCJF_JE = Convert.ToDecimal(KCJCJFJE1.Text.Trim());
                SZRT_Model.JFYS_KCJCJF_GSYJ = KCJCJFGSYJ1.Text.Trim();
                SZRT_Model.JFYS_KCJCJF_BZ = KCJCJFBZ1.Text.Trim();
                SZRT_Model.JFYS_YQSBJF_JE = Convert.ToDecimal(YQSBJE1.Text.Trim());
                SZRT_Model.JFYS_YQSBJF_GSYJ = YQSBJFGSYJ1.Text.Trim();
                SZRT_Model.JFYS_YQSBJF_BZ = YQSBJFBZ1.Text.Trim();
                SZRT_Model.JFYS_WPRYJF_JE = Convert.ToDecimal(WPRYFYJE1.Text.Trim());
                SZRT_Model.JFYS_WPRYJF_GSYJ = WPRYJFGSYJ1.Text.Trim();
                SZRT_Model.JFYS_WPRYJF_BZ = WPRYFYBZ1.Text.Trim();
                SZRT_Model.JFYS_YWF_JE = Convert.ToDecimal(YWFJE1.Text.Trim());
                SZRT_Model.JFYS_YWF_GSYJ = YWFGSYJ1.Text.Trim();
                SZRT_Model.JFYS_YWF_BZ = YWFBZ1.Text.Trim();
                //SZRT_Model.JFYS_JFHJ = Convert.ToInt32(JFHJ1.Text.Trim());
                SZRT_Model.JFYS_JFHJ = Convert.ToDecimal(JFHJ1.Text.Trim());


                //SZRT_Model.JFYS_XXPTJF = Convert.ToInt32(SQZXJF2.Text.Trim());
                SZRT_Model.JFYS_XXPTJF = Convert.ToDecimal(SQZXJF2.Text.Trim());
                SZRT_Model.JFYS_ZXQX3 = ZXKSRQ2.Text.Trim();
                SZRT_Model.JFYS_ZXQX4 = ZXJSRQ2.Text.Trim();
                SZRT_Model.JFYS_KCJCJF_JE2 = Convert.ToDecimal(KCJCJFJE2.Text.Trim());
                SZRT_Model.JFYS_KCJCJF_GSYJ2 = KCJCJFGSYJ2.Text.Trim();
                SZRT_Model.JFYS_KCJCJF_BZ2 = KCJCJFBZ2.Text.Trim();
                SZRT_Model.JFYS_YQSBJF_JE2 = Convert.ToDecimal(YQSBJE2.Text.Trim());
                SZRT_Model.JFYS_YQSBJF_GSYJ2 = YQSBJFGSYJ2.Text.Trim();
                SZRT_Model.JFYS_YQSBJF_BZ2 = YQSBJFBZ2.Text.Trim();
                SZRT_Model.JFYS_WPRYFY_JE2 = Convert.ToDecimal(WPRYFYJE2.Text.Trim());
                SZRT_Model.JFYS_WPRYFY_GSYJ2 = WPRYJFGSYJ2.Text.Trim();
                SZRT_Model.JFYS_WPRYFY_BZ2 = WPRYFYBZ2.Text.Trim();
                SZRT_Model.JFYS_YWF_JE2 = Convert.ToDecimal(YWFJE2.Text.Trim());
                SZRT_Model.JFYS_YWF_GSYJ2 = YWFGSYJ2.Text.Trim();
                SZRT_Model.JFYS_YWF_BZ2 = YWFBZ2.Text.Trim();
                SZRT_Model.JFYS_JFHJ2 = Convert.ToDecimal(JFHJ2.Text.Trim());


                if (ViewState["file1"] != null)
                    SZRT_Model.FJ1 = ViewState["file1"].ToString();
                if (ViewState["file2"] != null)
                    SZRT_Model.FJ2 = ViewState["file2"].ToString();
                if (ViewState["file3"] != null)
                    SZRT_Model.FJ3 = ViewState["file3"].ToString();

                SZRT_Model.user_uid = pb.GetIdentityId();
                SZRT_Model.ZT = 1;
                SZRT_Model.SFSC = 0;
                SZRT_Model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");


                SZRT_Bll.Update(SZRT_Model);
            }
            catch (Exception ex)
            {
                Alert.Show("不合法的数据：" + ex.Message);
                return;
            }
            string sqlstr1 = "delete from SZRT_XMTDRYXX where XMBH='" + SZRT_Model.XMBH + "'";
            DbHelperSQL.ExecuteSql(sqlstr1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SZRT_XMTDRYXX_Model.XMBH = SZRT_Model.XMBH;
                SZRT_XMTDRYXX_Model.CYXM = dt.Rows[i]["xm"].ToString().Trim();
                SZRT_XMTDRYXX_Model.BMZW = dt.Rows[i]["bm"].ToString().Trim();
                SZRT_XMTDRYXX_Model.RWFG = dt.Rows[i]["rwfg"].ToString().Trim();
                SZRT_XMTDRYXX_Model.SJ = dt.Rows[i]["sj"].ToString().Trim();
                SZRT_XMTDRYXX_Model.DZYX = dt.Rows[i]["dzyx"].ToString().Trim();
                SZRT_XMTDRYXX_Bll.Add(SZRT_XMTDRYXX_Model);
            }


            string sqlstr2 = "delete from SZRT_RTKCSZ where XMBH='" + SZRT_Model.XMBH + "'";
            DbHelperSQL.ExecuteSql(sqlstr2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {

                SZRT_RTKCSZ_Model.XMBH = SZRT_Model.XMBH;
                SZRT_RTKCSZ_Model.RTKC_MC = dt2.Rows[i]["kcmc"].ToString().Trim();
                SZRT_RTKCSZ_Model.RTKC_NR = dt2.Rows[i]["kczynr"].ToString().Trim();
                SZRT_RTKCSZ_Model.RTKC_KCDYZS = dt2.Rows[i]["kcdyzs"].ToString().Trim();
                SZRT_RTKCSZ_Model.RTKC_KHFS = dt2.Rows[i]["khfs"].ToString().Trim();
                SZRT_RTKCSZ_Bll.Add(SZRT_RTKCSZ_Model);
            }



            string sqlstr3 = "delete from SZRT_ZYJSXX where XMBH='" + SZRT_Model.XMBH + "'";
            DbHelperSQL.ExecuteSql(sqlstr3);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                SZRT_ZYJSXX_Model.XMBH = SZRT_Model.XMBH;
                SZRT_ZYJSXX_Model.XM = dt3.Rows[i]["xm"].ToString().Trim();
                SZRT_ZYJSXX_Model.ZC = dt3.Rows[i]["zc"].ToString().Trim();
                SZRT_ZYJSXX_Model.ZJKC = dt3.Rows[i]["zjkc"].ToString().Trim();
                SZRT_ZYJSXX_Model.ZYZGZS = dt3.Rows[i]["zyzgzs"].ToString().Trim();
                SZRT_ZYJSXX_Model.ZJZ = dt3.Rows[i]["zjz"].ToString().Trim();
                SZRT_ZYJSXX_Bll.Add(SZRT_ZYJSXX_Model);
            }

            string sqlstr4 = "delete from SZRT_SBXMYSMB where XMBH='" + SZRT_Model.XMBH + "'";
            DbHelperSQL.ExecuteSql(sqlstr4);
            for (int i = 0; i < dt4.Rows.Count; i++)
            {

                SZRT_SBXMYSMB_Model.XMBH = SZRT_Model.XMBH;
                SZRT_SBXMYSMB_Model.JSMB = dt4.Rows[i]["jsmb"].ToString().Trim();
                SZRT_SBXMYSMB_Model.JHYSRQ = dt4.Rows[i]["jhysrq"].ToString().Trim();
                SZRT_SBXMYSMB_Model.YSYD = dt4.Rows[i]["ysyd"].ToString().Trim();
                SZRT_SBXMYSMB_Bll.Add(SZRT_SBXMYSMB_Model);
            }


            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"] + ".doc";
            var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2 2015项目申报书(双证融通)150228(1).docx");
            var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

            if (new BuildWord().BuildWord_2015ProjectDeclaration_SZRT(tmppath, savepath, SZRT_Model.XMBH))
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                Model.XMSBSWD model = new Model.XMSBSWD();
                model = wordBll.GetModelList("XMBH='" + SZRT_Model.XMBH + "'")[0];
                model.XMMC = SZRT_Model.XMMC;
                model.WDLJ = savepath;
                wordBll.Update(model);
            }





            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
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
        protected void Button_step3_Click(object sender, EventArgs e)
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
        protected void Button_step4_Click(object sender, EventArgs e)
        {
            //div1.InnerHtml = "<script>var str=\"alert('1')\";eval(str);</script>";
            //div1.InnerHtml = "<script>$(document).ready(function(){$('#li4').addClass('current');})</script>";
            //PageContext.RegisterStartupScript("<script src=\"../res/js/jquery.min.js\" type=\"text/javascript\"></script>alert('');");
            //PageContext.RegisterStartupScript("alert($('#li4').attr('id'));");
            //PageContext.RegisterStartupScript("$('#li1').addClass('current');");
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
        protected void Button_step6_Click(object sender, EventArgs e)
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
        protected void Button_step7_Click(object sender, EventArgs e)
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
        protected void Button_step8_Click(object sender, EventArgs e)
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

        protected void Button_step9_Click(object sender, EventArgs e)
        {
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
            //div1.InnerHtml = "<script>var str=\"alert('1')\";eval(str);</script>";
            //div1.InnerHtml = "<script>$(document).ready(function(){$('#li4').addClass('current');})</script>";
            //PageContext.RegisterStartupScript("<script src=\"../res/js/jquery.min.js\" type=\"text/javascript\"></script>alert('');");
            //PageContext.RegisterStartupScript("alert($('#li4').attr('id'));");
            //PageContext.RegisterStartupScript("$('#li1').addClass('current');");
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

        protected void step9()
        {
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

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            DataTable dt = null;
            int _zrjss = 0, _jzjss = 0;
            string zjz = "";





           
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
                    zjz = dr1["zjz"].ToString().Trim();
                    dt.Rows.Add(dr);
                }
            }
            else
            {

                dt = ViewState["dt2"] as DataTable;
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

                    zjz = dr1["zjz"].ToString().Trim();
                    

                    dt.Rows.Add(dr);
                }

            }

            Grid2.DataSource = dt;
            Grid2.DataBind();
            ViewState["dt2"] = dt;
        }
        protected void databind_ZJZ()
        {
            ZJZ3.Items.Clear();

            ZJZ3.Items.Add("请选择", "请选择");
            ZJZ3.Items.Add("专职", "专职");
            ZJZ3.Items.Add("兼职", "兼职");
            dp_setvalue(ZJZ3, "请选择");

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


        private string AutoNumber(string seed)
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM  SZRT  WHERE   (XMBH LIKE '" + seed.Trim() + "%') ORDER BY XMBH DESC";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            if (XM2.Text.Trim() == "")
            {
                Alert.Show("“项目成员姓名”为必填项");
                return;
            }
            if (BM2.Text.Trim() == "")
            {
                Alert.Show("“部门及职务”为必填项");
                return;
            }
            if (RWFG2.Text.Trim() == "")
            {
                Alert.Show("“任务分工”为必填项");
                return;
            }
            if (SJ2.Text.Trim() == "")
            {
                Alert.Show("“手机”为必填项");
                return;
            }
            if (DZYX2.Text.Trim() == "")
            {
                Alert.Show("“电子邮箱”为必填项");
                return;
            }
            //string zjz = DropDownList_zjz1.Text.Trim();
            string xm = XM2.Text.Trim();
            //string sfss = DropDownList_ss1.Text.Trim();
            string bm = BM2.Text.Trim();
            //string xl = DropDownList_xl11.Text.Trim();
            string rwfg = RWFG2.Text.Trim();
            //string xw = DropDownList_xw11.Text.Trim();
            string sj = SJ2.Text.Trim();
            //string zcdj = DropDownList_zcdj11.Text.Trim();
            string dzyx = DZYX2.Text.Trim();



            int _zrjss = 0, _jzjss = 0;



            if (ViewState["dt_wh1"] == null)
            {


                dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("xm");
                dt.Columns.Add("bm");
                dt.Columns.Add("rwfg");
                dt.Columns.Add("xl");
                dt.Columns.Add("sj");
                dt.Columns.Add("dzyx");

                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["xm"] = xm;
                //dr["csny"] = DatePicker_csny.Text;
                dr["bm"] = bm;
                dr["rwfg"] = rwfg;
                dr["sj"] = sj;
                dr["dzyx"] = dzyx;
                dt.Rows.Add(dr);
            }
            else
            {

                dt = ViewState["dt_wh1"] as DataTable;


                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["xm"] = xm;
                //dr["csny"] = DatePicker_csny.Text;
                dr["bm"] = bm;
                dr["rwfg"] = rwfg;
                dr["sj"] = sj;
                dr["dzyx"] = dzyx;
                dt.Rows.Add(dr);

            }
            Grid4.DataSource = dt;
            Grid4.DataBind();
            ViewState["dt_wh1"] = dt;
        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            int selectedCount = Grid4.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid4.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid4.AllowPaging && !Grid4.IsDatabasePaging)
                    {
                        rowIndex = Grid4.PageIndex * Grid4.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += Grid4.DataKeys[rowIndex][0].ToString() + ",";


                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

                if (ViewState["dt_wh1"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt_wh1"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            //dt.Rows.Remove(dt.Rows[i]);
                            dt.Rows.Remove(dt.Rows[i]);
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid4.DataSource = dt;
                    Grid4.DataBind();
                    ViewState["dt_wh1"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid4.SelectedRowIndexArray = null; // 清空当前选中的项
            }

        }

        protected void Button121_Click(object sender, EventArgs e)
        {
            if (KCMC1.Text.Trim() == "")
            {
                Alert.Show("“课程名称”为必填项");
                return;
            }
            if (KCZYNR1.Text.Trim() == "")
            {
                Alert.Show("“课程主要内容”为必填项");
                return;
            }
            if (KCDYZS1.Text.Trim() == "")
            {
                Alert.Show("“课程对应的证书能力模块”为必填项");
                return;
            }
            if (KHFS1.Text.Trim() == "")
            {
                Alert.Show("“考核方式”为必填项");
                return;
            }

            DataTable dt = null;
            string kcmc = KCMC1.Text.Trim();
            string kczynr = KCZYNR1.Text.Trim();
            string kcdyzs = KCDYZS1.Text.Trim();
            string khfs = KHFS1.Text.Trim();
            if (ViewState["dt_wh2"] == null)
            {


                dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("kcmc");
                dt.Columns.Add("kczynr");
                dt.Columns.Add("kcdyzs");
                dt.Columns.Add("khfs");


                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["kcmc"] = KCMC1.Text.Trim();
                dr["kczynr"] = KCZYNR1.Text.Trim();
                dr["kcdyzs"] = KCDYZS1.Text.Trim();
                dr["khfs"] = KHFS1.Text.Trim();
                dt.Rows.Add(dr);
            }
            else
            {

                dt = ViewState["dt_wh2"] as DataTable;


                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["kcmc"] = KCMC1.Text.Trim();
                dr["kczynr"] = KCZYNR1.Text.Trim();
                dr["kcdyzs"] = KCDYZS1.Text.Trim();
                dr["khfs"] = KHFS1.Text.Trim();
                dt.Rows.Add(dr);

            }
            Grid1.DataSource = dt;
            Grid1.DataBind();
            ViewState["dt_wh2"] = dt;

    
        }

        protected void Button2_Click(object sender, EventArgs e)
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

                if (ViewState["dt_wh2"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt_wh2"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                    ViewState["dt_wh2"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }

        }



        protected void Button7_Click(object sender, EventArgs e)
        {
            if (XM3.Text.Trim() == "")
            {
                Alert.Show("“姓名”为必填项");
                return;
            }
            if (ZC3.Text.Trim() == "")
            {
                Alert.Show("“职称”为必填项");
                return;
            }
            if (ZJKC3.Text.Trim() == "")
            {
                Alert.Show("“主讲课程”为必填项");
                return;
            }
            if (ZYZG3.Text.Trim() == "")
            {
                Alert.Show("“职业资格证书”为必填项");
                return;
            }
            if (ZJZ3.SelectedItem.Text.Trim() == "请选择")
            {
                Alert.Show("“专/兼职”为必选项");
                return;
            }
            DataTable dt = null;

            if (ViewState["dt_wh3"] == null)
            {


                dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("xm");
                dt.Columns.Add("zc");
                dt.Columns.Add("zjkc");
                dt.Columns.Add("zyzgzs");
                dt.Columns.Add("zjz");

                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["xm"] = XM3.Text.Trim();
                dr["zc"] = ZC3.Text.Trim();
                dr["zjkc"] = ZJKC3.Text.Trim();
                dr["zyzgzs"] = ZYZG3.Text.Trim();
                dr["zjz"] = ZJZ3.SelectedItem.Text.Trim();
                dt.Rows.Add(dr);
            }
            else
            {

                dt = ViewState["dt_wh3"] as DataTable;

                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["xm"] = XM3.Text.Trim();
                dr["zc"] = ZC3.Text.Trim();
                dr["zjkc"] = ZJKC3.Text.Trim();
                dr["zyzgzs"] = ZYZG3.Text.Trim();
                dr["zjz"] = ZJZ3.SelectedItem.Text.Trim();
                dt.Rows.Add(dr);

            }
            Grid2.DataSource = dt;
            Grid2.DataBind();
            ViewState["dt_wh3"] = dt;


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

                if (ViewState["dt_wh3"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt_wh3"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid2.DataSource = dt;
                    Grid2.DataBind();
                    ViewState["dt_wh3"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid2.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (jsmb1.Text.Trim() == "")
            {
                Alert.Show("“建设目标”为必填项");
                return;
            }
            if (jhysrq1.Text.Trim() == "")
            {
                Alert.Show("“计划验收日期”为必填项");
                return;
            }
            if (ysyd1.Text.Trim() == "")
            {
                Alert.Show("“验收要点”为必填项");
                return;
            }

            DataTable dt = null;
            if (ViewState["dt_wh4"] == null)
            {
                dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("jsmb");
                dt.Columns.Add("jhysrq");
                dt.Columns.Add("ysyd");


                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["jsmb"] = jsmb1.Text.Trim();
                dr["jhysrq"] = jhysrq1.Text.Trim();
                dr["ysyd"] = ysyd1.Text.Trim();

                dt.Rows.Add(dr);
            }
            else
            {
                dt = ViewState["dt_wh4"] as DataTable;
                DataRow dr = dt.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["jsmb"] = jsmb1.Text.Trim();
                dr["jhysrq"] = jhysrq1.Text.Trim();
                dr["ysyd"] = ysyd1.Text.Trim();
                dt.Rows.Add(dr);

            }
            Grid3.DataSource = dt;
            Grid3.DataBind();
            ViewState["dt_wh4"] = dt;
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

                if (ViewState["dt_wh4"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dt_wh4"];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                            break;
                        }
                    }
                    Grid3.DataSource = dt;
                    Grid3.DataBind();
                    ViewState["dt_wh4"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid3.SelectedRowIndexArray = null; // 清空当前选中的项
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

                //FileUpload1.ImageUrl = "~/upload/" + fileName;

                // 清空文件上传组件
                //FileUpload1.Reset();
            }
        }

        protected void KCJCJFJE1_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }
        public void AddHj1()
        {
            try
            {
                string KCJCJFJE_HJ = KCJCJFJE1.Text.Trim() == "" ? "0" : KCJCJFJE1.Text.ToString().Trim();
                string YQSBJE_HJ = YQSBJE1.Text.Trim() == "" ? "0" : YQSBJE1.Text.ToString().Trim();
                string WPRYFYJE_HJ = WPRYFYJE1.Text.Trim() == "" ? "0" : WPRYFYJE1.Text.ToString().Trim();
                string YWFJE_HJ = YWFJE1.Text.Trim() == "" ? "0" : YWFJE1.Text.ToString().Trim();
                float HJ1 = (float.Parse(KCJCJFJE_HJ) + float.Parse(YQSBJE_HJ) + float.Parse(WPRYFYJE_HJ) + float.Parse(YWFJE_HJ));
                //Hidden1.Text = String.Format("{0:0.00}", HJ1);
                //Hidden2.Text = String.Format("{0:0.00}", HJ1);
                JFHJ1.Text = String.Format("{0:0.00}", HJ1);
                SQZXJF1.Text = String.Format("{0:0.00}", HJ1);


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
                string KCJCJFJE_HJ = KCJCJFJE2.Text.Trim() == "" ? "0" : KCJCJFJE2.Text.ToString().Trim();
                string YQSBJE_HJ = YQSBJE2.Text.Trim() == "" ? "0" : YQSBJE2.Text.ToString().Trim();
                string WPRYFYJE_HJ = WPRYFYJE2.Text.Trim() == "" ? "0" : WPRYFYJE2.Text.ToString().Trim();
                string YWFJE_HJ = YWFJE2.Text.Trim() == "" ? "0" : YWFJE2.Text.ToString().Trim();
                float HJ1 = (float.Parse(KCJCJFJE_HJ) + float.Parse(YQSBJE_HJ) + float.Parse(WPRYFYJE_HJ) + float.Parse(YWFJE_HJ));
                //Hidden3.Text = String.Format("{0:0.00}", HJ1);
                //Hidden4.Text = String.Format("{0:0.00}", HJ1);
                JFHJ2.Text = String.Format("{0:0.00}", HJ1);
                SQZXJF2.Text = String.Format("{0:0.00}", HJ1);


            }
            catch (Exception ex)
            {
                Alert.Show("计费合计错误：" + ex.Message);
            }
        }

        protected void YWFJE2_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }

        protected void WPRYFYJE2_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }

        protected void YQSBJE2_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }

        protected void KCJCJFJE2_TextChanged(object sender, EventArgs e)
        {
            AddHj2();
        }

        protected void YWFJE1_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }

        protected void WPRYFYJE1_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }

        protected void YQSBJE1_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
        }


    }



}