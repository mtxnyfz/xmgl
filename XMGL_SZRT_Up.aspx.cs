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
        Model.SZRT szrt_Model = new Model.SZRT();
        BLL.SZRT szrt_bll = new BLL.SZRT();

        Model.SZRT_XMTDRYXX szrtxmcy_model = new Model.SZRT_XMTDRYXX();
        BLL.SZRT_XMTDRYXX szrtxmcy_bll = new BLL.SZRT_XMTDRYXX();


        Model.SZRT_RTKCSZ SZRT_RTKCSZ_Model = new Model.SZRT_RTKCSZ();
        Model.SZRT_SBXMYSMB SZRT_SBXMYSMB_Model = new Model.SZRT_SBXMYSMB();
        Model.SZRT_ZYJSXX SZRT_ZYJSXX_Model = new Model.SZRT_ZYJSXX();



        BLL.SZRT_RTKCSZ SZRT_RTKCSZ_Bll = new BLL.SZRT_RTKCSZ();
        BLL.SZRT_SBXMYSMB SZRT_SBXMYSMB_Bll = new BLL.SZRT_SBXMYSMB();

        BLL.SZRT_ZYJSXX SZRT_ZYJSXX_Bll = new BLL.SZRT_ZYJSXX();
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
            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[CYXM] as CYXM,[BMZW] as BMZW,[RWFG] as RWFG,[SJ] as SJ,[DZYX] as DZYX from [SZRT_XMTDRYXX] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid4.DataSource = dt;
            Grid4.DataBind();
            ViewState["dt_wh1"] = dt;

            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[RTKC_MC] as RTKC_MC,[RTKC_NR] as RTKC_NR,[RTKC_KCDYZS] as RTKC_KCDYZS,[RTKC_KHFS] as RTKC_KHFS from [SZRT_RTKCSZ] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
            ViewState["dt_wh2"] = dt;

            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[XM] as XM,[ZC] as ZC,[ZJKC] as ZJKC,[ZYZGZS] as ZYZGZS,[ZJZ] as ZJZ from [SZRT_ZYJSXX] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid2.DataSource = dt;
            Grid2.DataBind();
            ViewState["dt_wh3"] = dt;

            sqlstr = "select  CAST([ID] as nvarchar(50)) as id,[JSMB] as JSMB,[JHYSRQ] as JHYSRQ,[YSYD] as YSYD from [SZRT_SBXMYSMB] where [XMBH]='" + ViewState["xmbh"].ToString() + "'";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid3.DataSource = dt;
            Grid3.DataBind();
            ViewState["dt_wh4"] = dt;
        }

        #region 一、单位承诺及填表说明
        protected void Button_step1_Click(object sender, EventArgs e)//单位承诺及填表说明顶部导航
        {
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
        protected void Button_step2_Click(object sender, EventArgs e)//下一步按钮以及
        {
            step2();
        }
        #endregion

        #region 二、项目团队人员信息
        protected void Button1_Click(object sender, EventArgs e)//“确定”按钮，增加项目成员
        {
            try
            {
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
                string xm = XM2.Text.Trim();
                string bm = BM2.Text.Trim();
                string rwfg = RWFG2.Text.Trim();
                string sj = SJ2.Text.Trim();
                string dzyx = DZYX2.Text.Trim();

                szrtxmcy_model.XMBH = ViewState["xmbh"].ToString();
                szrtxmcy_model.CYXM = xm;
                szrtxmcy_model.BMZW = bm;
                szrtxmcy_model.RWFG = rwfg;
                szrtxmcy_model.SJ = sj;
                szrtxmcy_model.DZYX = dzyx;
                szrtxmcy_bll.Add(szrtxmcy_model);
                BindGridXMCY();
            }
            catch (Exception)
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
            }
        }

        public void BindGridXMCY()//绑定项目成员
        {
            Grid4.DataSource = szrtxmcy_bll.GetList(string.Format("XMBH='{0}'", ViewState["xmbh"].ToString()));
            Grid4.DataBind();
        }

        protected void Button14_Click(object sender, EventArgs e)//删除项目成员信息
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid4);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                szrtxmcy_bll.Delete(ids[i]);
            }
            BindGridXMCY();
        }

        public bool Add_XMFZRXX()
        {
            try
            {
                if (TextBox_xmmc.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“申报项目名称”为必填项");
                    return false;
                }
                if (TextBox_DWMC1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“单位名称”为必填项");
                    return false;
                }
                if (XM1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“姓名”为必填项");
                    return false;
                }
                if (BM1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“部门”为必填项");
                    return false;
                }
                if (ZYJSZW1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“专业技术职务”为必填项");
                    return false;
                }
                if (XZZW1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“行政职务”为必填项");
                    return false;
                }
                if (BGSDH1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“办公室电话”为必填项");
                    return false;
                }
                if (CZ1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“传真”为必填项");
                    return false;
                }
                if (SJ1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“手机”为必填项");
                    return false;
                }
                if (DZYX1.Text.Trim() == "")
                {
                    step2();
                    Alert.Show("“电子邮箱”为必填项");
                    return false;
                }
                string xmbh = ViewState["xmbh"].ToString();
                szrt_Model = szrt_bll._GetModel(xmbh);
                //赋值
                szrt_Model.XMBH = xmbh;
                szrt_Model.XMMC = TextBox_xmmc.Text.Trim();
                szrt_Model.DWMC = TextBox_DWMC1.Text.Trim();
                szrt_Model.TBRQ = DateTime.Now.ToString();
                szrt_Model.XMFZR_XM = XM1.Text.Trim();
                szrt_Model.XMFZR_BM = BM1.Text.Trim();
                szrt_Model.XMFZR_ZYJSZW = ZYJSZW1.Text.Trim();
                szrt_Model.XMFZR_XZZW = XZZW1.Text.Trim();
                szrt_Model.XMFZR_BGSDH = BGSDH1.Text.Trim();
                szrt_Model.XMFZR_CZ = CZ1.Text.Trim();
                szrt_Model.XMFZR_SJ = SJ1.Text.Trim();
                szrt_Model.XMFZR_DZYX = DZYX1.Text.Trim();

                return szrt_bll.Update(szrt_Model);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        protected void Button_step3_Click(object sender, EventArgs e)
        {
            if (Grid4.Rows.Count <= 0)
            {
                Alert.Show("请添加项目成员信息！");
                return;
            }
            if (!Add_XMFZRXX())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            step3();
        }
        #endregion

        #region 三、所选证书信息

        public bool Add_ZSXX()
        {
            try
            {
                if (ZSMC1.Text.Trim() == "")
                {
                    step3();
                    Alert.Show("“证书名称”为必填项");
                    return false;
                }
                if (ZSDJ1.Text.Trim() == "")
                {
                    step3();
                    Alert.Show("“证书等级”为必填项");
                    return false;
                }
                if (BFBM1.Text.Trim() == "")
                {
                    step3();
                    Alert.Show("“颁发部门”为必填项");
                    return false;
                }
                if (KZSJ1.Text.Trim() == "")
                {
                    step3();
                    Alert.Show("“考证时间”为必填项");
                    return false;
                }
                if (MNKKCS1.Text.Trim() == "")
                {
                    step3();
                    Alert.Show("“每年可考次数”为必填项");
                    return false;
                }
                if (XZZSYY1.Text.Trim() == "")
                {
                    step3();
                    Alert.Show("“选择该证书的原因说明”为必填项");
                    return false;
                }
                //if (SXKHTJ1.Text.Trim() == "")
               // {
                 //   step3();
                // //   Alert.Show("“选择理由”为必填项");
                //    return false;
               /// }
                string xmbh = ViewState["xmbh"].ToString();
                szrt_Model = szrt_bll._GetModel(xmbh);

                //赋值
                szrt_Model.XMBH = xmbh;
                szrt_Model.ZS_MC = ZSMC1.Text.Trim();
                szrt_Model.ZS_DJ = ZSDJ1.Text.Trim();
                szrt_Model.ZS_BFBM = BFBM1.Text.Trim();
                szrt_Model.ZS_KZSJ = KZSJ1.Text.Trim();
                szrt_Model.ZS_MNKKCS = int.Parse(MNKKCS1.Text.Trim());
                szrt_Model.ZS_XZYY = XZZSYY1.Text.Trim();
                return szrt_bll.Update(szrt_Model);

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        protected void Button_step4_Click(object sender, EventArgs e)
        {
            if (!Add_ZSXX())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            step4();
        }
        #endregion

        #region 四、融通课程设置

        public bool Add_RTKC()
        {
            try
            {
                if (KCMC1.Text.Trim() == "")
                {
                    Alert.Show("“课程名称”为必填项");
                    return false;
                }
                if (KCZYNR1.Text.Trim() == "")
                {
                    Alert.Show("“课程主要内容”为必填项");
                    return false;
                }
                if (KCDYZS1.Text.Trim() == "")
                {
                    Alert.Show("“课程对应的证书能力模块”为必填项");
                    return false;
                }
                if (KHFS1.Text.Trim() == "")
                {
                    Alert.Show("“考核方式”为必填项");
                    return false;
                }
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                SZRT_RTKCSZ_Model = SZRT_RTKCSZ_Bll._GetModel(xmbh, KCMC1.Text.Trim());
                if (SZRT_RTKCSZ_Model == null)
                {
                    IsAdd = true;
                    SZRT_RTKCSZ_Model = new Model.SZRT_RTKCSZ();
                }

                //赋值
                SZRT_RTKCSZ_Model.XMBH = xmbh;
                SZRT_RTKCSZ_Model.RTKC_MC = KCMC1.Text.Trim();
                SZRT_RTKCSZ_Model.RTKC_NR = KCZYNR1.Text.Trim();
                SZRT_RTKCSZ_Model.RTKC_KCDYZS = KCDYZS1.Text.Trim();
                SZRT_RTKCSZ_Model.RTKC_KHFS = KHFS1.Text.Trim();
                if (IsAdd)
                {
                    return SZRT_RTKCSZ_Bll.Add(SZRT_RTKCSZ_Model) > 0;
                }
                else
                {
                    return SZRT_RTKCSZ_Bll.Update(SZRT_RTKCSZ_Model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        public void BindGridRTKC()//绑定课程设置
        {
            Grid1.DataSource = SZRT_RTKCSZ_Bll.GetList(string.Format("XMBH='{0}'", ViewState["xmbh"].ToString()));
            Grid1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)//删除融通课程
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid1);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                SZRT_RTKCSZ_Bll.Delete(ids[i]);
            }
            BindGridRTKC();

        }

        protected void Button121_Click(object sender, EventArgs e)//"确定"按钮
        {
            if (!Add_RTKC())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            BindGridRTKC();
        }

        protected void Button_step5_Click(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count < 3)
            {
                Alert.Show("至少填报3门融通课程！");
                return;
            }
            step5();

        }


        #endregion

        #region 五、专业教师信息

        public bool Add_ZYJSXX()
        {
            try
            {
                if (XM3.Text.Trim() == "")
                {
                    Alert.Show("“姓名”为必填项");
                    return false;
                }
                if (ZC3.Text.Trim() == "")
                {
                    Alert.Show("“职称”为必填项");
                    return false;
                }
                if (ZJKC3.Text.Trim() == "")
                {
                    Alert.Show("“主讲课程”为必填项");
                    return false;
                }
                if (ZYZG3.Text.Trim() == "")
                {
                    Alert.Show("“职业资格证书”为必填项");
                    return false;
                }
                if (ZJZ3.SelectedItem.Text.Trim() == "请选择")
                {
                    Alert.Show("“专/兼职”为必选项");
                    return false;
                }
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                SZRT_ZYJSXX_Model = SZRT_ZYJSXX_Bll._GetModel(xmbh, XM3.Text.Trim());
                if (SZRT_ZYJSXX_Model == null)
                {
                    IsAdd = true;
                    SZRT_ZYJSXX_Model = new Model.SZRT_ZYJSXX();
                }

                //赋值
                SZRT_ZYJSXX_Model.XMBH = xmbh;
                SZRT_ZYJSXX_Model.XM = XM3.Text.Trim();
                SZRT_ZYJSXX_Model.ZC = ZC3.Text.Trim();
                SZRT_ZYJSXX_Model.ZJKC = ZJKC3.Text.Trim();
                SZRT_ZYJSXX_Model.ZYZGZS = ZYZG3.Text.Trim();
                SZRT_ZYJSXX_Model.ZJZ = ZJZ3.SelectedItem.Text.Trim();
                if (IsAdd)
                {
                    return SZRT_ZYJSXX_Bll.Add(SZRT_ZYJSXX_Model) > 0;
                }
                else
                {
                    return SZRT_ZYJSXX_Bll.Update(SZRT_ZYJSXX_Model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        public void BindGridZYJS()//绑定专业教师信息
        {
            Grid2.DataSource = SZRT_ZYJSXX_Bll.GetList(string.Format("XMBH='{0}'", ViewState["xmbh"].ToString()));
            Grid2.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)//确定按钮
        {
            if (!Add_ZYJSXX())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            BindGridZYJS();
        }

        protected void Button5_Click(object sender, EventArgs e)//删除按钮
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid2);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                SZRT_ZYJSXX_Bll.Delete(ids[i]);
            }
            BindGridZYJS();
        }

        protected void Button_step6_Click(object sender, EventArgs e)
        {
            step6();

        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindGridZYJS();
        }
        #endregion

        #region 六、实训考核条件
        public bool Add_SXKHTJ()
        {
            try
            {
                string xmbh = ViewState["xmbh"].ToString();
                szrt_Model = szrt_bll._GetModel(xmbh);

                //赋值
                szrt_Model.XMBH = xmbh;
                szrt_Model.SXKHTJ = SXKHTJ1.Text.Trim();
                return szrt_bll.Update(szrt_Model);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        protected void Button_step7_Click(object sender, EventArgs e)
        {
            if (!Add_SXKHTJ())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            step7();

        }
        #endregion

        #region 七、报项目验收指标
        public bool Add_YSZB()
        {
            try
            {
                if (jsmb1.Text.Trim() == "")
                {
                    Alert.Show("“建设目标”为必填项");
                    return false;
                }
                if (jhysrq1.Text.Trim() == "")
                {
                    Alert.Show("“计划验收日期”为必填项");
                    return false;
                }
                if (ysyd1.Text.Trim() == "")
                {
                    Alert.Show("“验收要点”为必填项");
                    return false;
                }
                string xmbh = ViewState["xmbh"].ToString();
                SZRT_SBXMYSMB_Model = new Model.SZRT_SBXMYSMB();

                //赋值
                SZRT_SBXMYSMB_Model.XMBH = xmbh;
                SZRT_SBXMYSMB_Model.JSMB = jsmb1.Text.Trim();
                SZRT_SBXMYSMB_Model.JHYSRQ = jhysrq1.Text.Trim();
                SZRT_SBXMYSMB_Model.YSYD = ysyd1.Text.Trim();
                return SZRT_SBXMYSMB_Bll.Add(SZRT_SBXMYSMB_Model) > 0;
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        public void BindGridYSZB()//绑定课程设置
        {
            Grid3.DataSource = SZRT_SBXMYSMB_Bll.GetList(string.Format("XMBH='{0}'", ViewState["xmbh"].ToString()));
            Grid3.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)//确定按钮
        {
            if (!Add_YSZB())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            BindGridYSZB();
        }

        protected void Button6_Click(object sender, EventArgs e)//删除按钮
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid3);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                SZRT_SBXMYSMB_Bll.Delete(ids[i]);
            }
            BindGridYSZB();
        }

        protected void Button_step8_Click(object sender, EventArgs e)
        {
            step8();

        }

        #endregion

        #region 八、经费预算
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

        protected void KCJCJFJE1_TextChanged(object sender, EventArgs e)
        {
            AddHj1();
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

        public bool Add_JFYS()//添加经费预算
        {
            try
            {
                if (ZXKSRQ1.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“执行开始日期”为必填项");
                    return false;
                }
                if (ZXKSRQ1.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“执行结束日期”为必填项");
                    return false;
                }
                if (KCJCJFGSYJ1.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“课程教材经费概算依据”为必填项");
                    return false;
                }
                if (YQSBJFGSYJ1.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“仪器设备经费概算依据”为必填项");
                    return false;
                }
                if (WPRYJFGSYJ1.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“外聘人员费用概算依据”为必填项");
                    return false;
                }
                if (YWFGSYJ1.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“业务费（包括会议、差旅、印刷、交通等）概算依据”为必填项");
                    return false;
                }
                if (ZXKSRQ2.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“执行开始日期”为必填项");
                    return false;
                }
                if (ZXJSRQ2.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“执行结束日期”为必填项");
                    return false;
                }
                if (KCJCJFGSYJ2.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“课程教材经费概算依据”为必填项");
                    return false;
                }
                if (YQSBJFGSYJ2.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“仪器设备经费概算依据”为必填项");
                    return false;
                }
                if (WPRYJFGSYJ2.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“外聘人员费用概算依据”为必填项");
                    return false;
                }
                if (YWFGSYJ2.Text.Trim() == "")
                {
                    step8();
                    Alert.Show("“业务费（包括会议、差旅、印刷、交通等）概算依据”为必填项");
                    return false;
                }
                string xmbh = ViewState["xmbh"].ToString();
                szrt_Model = szrt_bll._GetModel(xmbh);
                //赋值
                szrt_Model.JFYS_SQJF = Convert.ToDecimal(SQZXJF1.Text.Trim());
                szrt_Model.JFYS_ZXQX_1 = ZXKSRQ1.Text.Trim();
                szrt_Model.JFYS_ZXQX_2 = ZXJSRQ1.Text.Trim();
                szrt_Model.JFYS_KCJCJF_JE = Convert.ToDecimal(KCJCJFJE1.Text.Trim());
                szrt_Model.JFYS_KCJCJF_GSYJ = KCJCJFGSYJ1.Text.Trim();
                szrt_Model.JFYS_KCJCJF_BZ = KCJCJFBZ1.Text.Trim();
                szrt_Model.JFYS_YQSBJF_JE = Convert.ToDecimal(YQSBJE1.Text.Trim());
                szrt_Model.JFYS_YQSBJF_GSYJ = YQSBJFGSYJ1.Text.Trim();
                szrt_Model.JFYS_YQSBJF_BZ = YQSBJFBZ1.Text.Trim();
                szrt_Model.JFYS_WPRYJF_JE = Convert.ToDecimal(WPRYFYJE1.Text.Trim());
                szrt_Model.JFYS_WPRYJF_GSYJ = WPRYJFGSYJ1.Text.Trim();
                szrt_Model.JFYS_WPRYJF_BZ = WPRYFYBZ1.Text.Trim();
                szrt_Model.JFYS_YWF_JE = Convert.ToDecimal(YWFJE1.Text.Trim());
                szrt_Model.JFYS_YWF_GSYJ = YWFGSYJ1.Text.Trim();
                szrt_Model.JFYS_YWF_BZ = YWFBZ1.Text.Trim();

                szrt_Model.JFYS_JFHJ = Convert.ToDecimal(JFHJ1.Text.Trim());


                szrt_Model.JFYS_XXPTJF = Convert.ToDecimal(SQZXJF2.Text.Trim());
                szrt_Model.JFYS_ZXQX3 = ZXKSRQ2.Text.Trim();
                szrt_Model.JFYS_ZXQX4 = ZXJSRQ2.Text.Trim();
                szrt_Model.JFYS_KCJCJF_JE2 = Convert.ToDecimal(KCJCJFJE2.Text.Trim());
                szrt_Model.JFYS_KCJCJF_GSYJ2 = KCJCJFGSYJ2.Text.Trim();
                szrt_Model.JFYS_KCJCJF_BZ2 = KCJCJFBZ2.Text.Trim();
                szrt_Model.JFYS_YQSBJF_JE2 = Convert.ToDecimal(YQSBJE2.Text.Trim());
                szrt_Model.JFYS_YQSBJF_GSYJ2 = YQSBJFGSYJ2.Text.Trim();
                szrt_Model.JFYS_YQSBJF_BZ2 = YQSBJFBZ2.Text.Trim();
                szrt_Model.JFYS_WPRYFY_JE2 = Convert.ToDecimal(WPRYFYJE2.Text.Trim());
                szrt_Model.JFYS_WPRYFY_GSYJ2 = WPRYJFGSYJ2.Text.Trim();
                szrt_Model.JFYS_WPRYFY_BZ2 = WPRYFYBZ2.Text.Trim();
                szrt_Model.JFYS_YWF_JE2 = Convert.ToDecimal(YWFJE2.Text.Trim());
                szrt_Model.JFYS_YWF_GSYJ2 = YWFGSYJ2.Text.Trim();
                szrt_Model.JFYS_YWF_BZ2 = YWFBZ2.Text.Trim();
                szrt_Model.JFYS_JFHJ2 = Convert.ToDecimal(JFHJ2.Text.Trim());
                return szrt_bll.Update(szrt_Model);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }


        }

        protected void Button_step9_Click(object sender, EventArgs e)//下一步按钮以及附件管理顶部导航
        {
            if (!Add_JFYS())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            step9();
        }

        #endregion

        #region 九、附件管理
        public bool Add_File()
        {
            try
            {
                string xmbh = ViewState["xmbh"].ToString();
                szrt_Model = szrt_bll._GetModel(xmbh);
                if (szrt_Model != null)
                {
                    if (ViewState["file1"] != null)
                        szrt_Model.FJ1 = ViewState["file1"].ToString();
                    if (ViewState["file2"] != null)
                        szrt_Model.FJ2 = ViewState["file2"].ToString();
                    if (ViewState["file3"] != null)
                        szrt_Model.FJ3 = ViewState["file3"].ToString();

                    szrt_Model.user_uid = pb.GetIdentityId();
                    szrt_Model.ZT = 1;
                    szrt_Model.SFSC = 0;
                    szrt_Model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");
                    return szrt_bll.Update(szrt_Model);
                }
                else
                {
                    szrt_Model = new Model.SZRT();
                    szrt_Model.XMBH = xmbh;
                    if (ViewState["file1"] != null)
                        szrt_Model.FJ1 = ViewState["file1"].ToString();
                    if (ViewState["file2"] != null)
                        szrt_Model.FJ2 = ViewState["file2"].ToString();
                    if (ViewState["file3"] != null)
                        szrt_Model.FJ3 = ViewState["file3"].ToString();

                    szrt_Model.user_uid = pb.GetIdentityId();
                    szrt_Model.ZT = 1;
                    szrt_Model.SFSC = 0;
                    szrt_Model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");
                    return szrt_bll.Add(szrt_Model)>0;
                }
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message);
                return false;
            }

        }

        protected void btnSubmit1_Click(object sender, EventArgs e)//上传附件一
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

                        FileUpload1.SaveAs(Server.MapPath("upload/“双证融通”培养模式人才改革方案/" + fileName));
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

        protected void btnSubmit2_Click(object sender, EventArgs e)//上传附件二
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

                        FileUpload2.SaveAs(Server.MapPath("upload/本专业现行人才培养方案/" + fileName));
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

        protected void btnSubmit3_Click(object sender, EventArgs e)//上传附件三
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (!Add_File())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            string xmbh = ViewState["xmbh"].ToString();
            szrt_Model = szrt_bll._GetModel(xmbh);

            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"] + ".doc";
            var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2 2015项目申报书(双证融通)150228(1).docx");
            var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

            if (new BuildWord().BuildWord_2015ProjectDeclaration_SZRT(tmppath, savepath, szrt_Model.XMBH))
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                Model.XMSBSWD model = new Model.XMSBSWD();
                model = wordBll._GetModel(szrt_Model.XMBH );
                if (model!=null)
                {
                    model.XMMC = szrt_Model.XMMC;
                    model.WDLJ = savepath;
                    wordBll.Update(model);
                }
                else
                {
                    model = new Model.XMSBSWD();
                    model.XMBH = xmbh;
                    model.XMMC = szrt_Model.XMMC;
                    model.WDLJ = savepath;
                    wordBll.Add(model);
                }
               
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        protected void step2()
        {
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
    }



}