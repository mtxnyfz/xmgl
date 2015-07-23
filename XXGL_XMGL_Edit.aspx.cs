﻿using AppBox;
using FineUI;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace XMGL.Web.admin
{
    public partial class XXGL_XMGL_Edit : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();

        Model.XXGLPT_XM xm_model = new Model.XXGLPT_XM();
        BLL.XXGLPT_XM xm_bll = new BLL.XXGLPT_XM();

        Model.XXGLPT_XMCY xmcy_model = new Model.XXGLPT_XMCY();
        BLL.XXGLPT_XMCY xmcy_bll = new BLL.XXGLPT_XMCY();

        Model.XXGLPT_XMYSZB yszb_model = new Model.XXGLPT_XMYSZB();
        BLL.XXGLPT_XMYSZB yszb_bll = new BLL.XXGLPT_XMYSZB();

        #region LoadDatg

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

            }
        }

        public void InitData()
        {
            //设置经费预算最小时间
            dpJFYS_XXPTJF_ZXKSSJ.MinDate = DateTime.Now.AddDays(1);
            dpJFYS_ZXJF_ZXKSSJ.MinDate = DateTime.Now.AddDays(1);
            //初始单位名称
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

            //绑定数据
            #region 绑定数据
            string id = Request["id"];
            if (string.IsNullOrEmpty(id))
            {
                Alert.ShowInTop("非法的请求");
                return;
            }
            //加载数据
            xm_model = xm_bll.GetModel(Convert.ToInt32(id));
            if (xm_model == null)
            {
                Alert.ShowInTop("无数据！");
                return;
            }
            //赋值
            ViewState["xmbh"] = xm_model.XMBH;

            txtXMMC.Text = xm_model.XMMC;
            txtDWMC.Text = xm_model.DWMC;

            txtXMFZRXX_XM.Text = xm_model.XMFZRXX_XM;
            txtXMFZRXX_BM.Text = xm_model.XMFZRXX_BM;

            txtXMFZRXX_ZYJSZW.Text = xm_model.XMFZRXX_ZYJSZW;
            txtXMFZRXX_XZZW.Text = xm_model.XMFZRXX_XZZW;

            txtXMFZRXX_BGSDH.Text = xm_model.XMFZRXX_BGSDH;
            txtXMFZRXX_CZ.Text = xm_model.XMFZRXX_CZ;

            txtXMFZRXX_SJ.Text = xm_model.XMFZRXX_SJ;
            txtXMFZRXX_DZYX.Text = xm_model.XMFZRXX_DZYX;

            txtSBXMJSFA_SBLY.Text = xm_model.SBXMJSFA_SBLY;
            txtSBXMJSFA_JSMB.Text = xm_model.SBXMJSFA_JSMB;
            txtSBXMJSFA_JTJC.Text = xm_model.SBXMJSFA_JTJC;
            txtSBXMJSFA_JFAP.Text = xm_model.SBXMJSFA_JFAP;
            txtSBXMJSFA_SSJH.Text = xm_model.SBXMJSFA_SSJH;

            txtJFYS_ZXJF.Text = xm_model.JFYS_ZXJF.ToString();

            dpJFYS_ZXJF_ZXKSSJ.SelectedDate = xm_model.JFYS_ZXJF_ZXKSSJ;
            dpJFYS_ZXJF_ZXJSSJ.SelectedDate = xm_model.JFYS_ZXJF_ZXJSSJ;

            txtJFYS_ZXJF_XTKF_SM.Text = xm_model.JFYS_ZXJF_XTKF_SM;
            txtJFYS_ZXJF_XTKF_JFYS.Text = xm_model.JFYS_ZXJF_XTKF_JFYS.ToString();
            txtJFYS_ZXJF_XTKF_BZ.Text = xm_model.JFYS_ZXJF_XTKF_BZ;

            txtJFYS_ZXJF_YWPX_SM.Text = xm_model.JFYS_ZXJF_YWPX_SM;
            txtJFYS_ZXJF_YWPX_JFYS.Text = xm_model.JFYS_ZXJF_YWPX_JFYS.ToString();
            txtJFYS_ZXJF_YWPX_BZ.Text = xm_model.JFYS_ZXJF_YWPX_BZ;

            txtJFYS_ZXJF_YQSB_SM.Text = xm_model.JFYS_ZXJF_YQSB_SM;
            txtJFYS_ZXJF_YQSB_JFYS.Text = xm_model.JFYS_ZXJF_YQSB_JFYS.ToString();
            txtJFYS_ZXJF_YQSB_BZ.Text = xm_model.JFYS_ZXJF_YQSB_BZ;

            txtJFYS_ZXJF_WPRY_SM.Text = xm_model.JFYS_ZXJF_WPRY_SM;
            txtJFYS_ZXJF_WPRY_JFYS.Text = xm_model.JFYS_ZXJF_WPRY_JFYS.ToString();
            txtJFYS_ZXJF_WPRY_BZ.Text = xm_model.JFYS_ZXJF_WPRY_BZ;

            txtJFYS_ZXJF_YWF_SM.Text = xm_model.JFYS_ZXJF_YWF_SM;
            txtJFYS_ZXJF_YWF_JFYS.Text = xm_model.JFYS_ZXJF_YWF_JFYS.ToString();
            txtJFYS_ZXJF_YWF_BZ.Text = xm_model.JFYS_ZXJF_YWF_BZ;
            //耿春喜备注
            //txtJFYS_ZXJF_JFGSHJ_SM.Text = xm_model.JFYS_ZXJF_JFGSHJ_SM;
            txtJFYS_ZXJF_JFGSHJ_JFYS.Text = xm_model.JFYS_ZXJF_JFGSHJ_JFYS.ToString();
            //txtJFYS_ZXJF_JFGSHJ_BZ.Text = xm_model.JFYS_ZXJF_JFGSHJ_BZ;

            //学校配套
            txtJFYS_XXPTJF.Text = xm_model.JFYS_XXPTJF.ToString();

            dpJFYS_XXPTJF_ZXKSSJ.SelectedDate = xm_model.JFYS_XXPTJF_ZXKSSJ;
            dpJFYS_XXPTJF_ZXJSSJ.SelectedDate = xm_model.JFYS_XXPTJF_ZXJSSJ;

            txtJFYS_XXPTJF_XTKF_SM.Text = xm_model.JFYS_XXPTJF_XTKF_SM;
            txtJFYS_XXPTJF_XTKF_JFYS.Text = xm_model.JFYS_XXPTJF_XTKF_JFYS.ToString();
            txtJFYS_XXPTJF_XTKF_BZ.Text = xm_model.JFYS_XXPTJF_XTKF_BZ;

            txtJFYS_XXPTJF_YWPX_SM.Text = xm_model.JFYS_XXPTJF_YWPX_SM;
            txtJFYS_XXPTJF_YWPX_JFYS.Text = xm_model.JFYS_XXPTJF_YWPX_JFYS.ToString();
            txtJFYS_XXPTJF_YWPX_BZ.Text = xm_model.JFYS_XXPTJF_YWPX_BZ;

            txtJFYS_XXPTJF_YQSB_SM.Text = xm_model.JFYS_XXPTJF_YQSB_SM;
            txtJFYS_XXPTJF_YQSB_JFYS.Text = xm_model.JFYS_XXPTJF_YQSB_JFYS.ToString();
            txtJFYS_XXPTJF_YQSB_BZ.Text = xm_model.JFYS_XXPTJF_YQSB_BZ;

            txtJFYS_XXPTJF_WPRY_SM.Text = xm_model.JFYS_XXPTJF_WPRY_SM;
            txtJFYS_XXPTJF_WPRY_JFYS.Text = xm_model.JFYS_XXPTJF_WPRY_JFYS.ToString();
            txtJFYS_XXPTJF_WPRY_BZ.Text = xm_model.JFYS_XXPTJF_WPRY_BZ;

            txtJFYS_XXPTJF_YWF_SM.Text = xm_model.JFYS_XXPTJF_YWF_SM;
            txtJFYS_XXPTJF_YWF_JFYS.Text = xm_model.JFYS_XXPTJF_YWF_JFYS.ToString();
            txtJFYS_XXPTJF_YWF_BZ.Text = xm_model.JFYS_XXPTJF_YWF_BZ;
            //耿春喜备注
            //txtJFYS_XXPTJF_JFGSHJ_SM.Text = xm_model.JFYS_XXPTJF_JFGSHJ_SM;
            txtJFYS_XXPTJF_JFGSHJ_JFYS.Text = xm_model.JFYS_XXPTJF_JFGSHJ_JFYS.ToString();
            //txtJFYS_XXPTJF_JFGSHJ_BZ.Text = xm_model.JFYS_XXPTJF_JFGSHJ_BZ;
            #endregion

            //绑定Grid
            BindGridXMCY();
            BindGridYSZB();

            btnXMCYXXDel.OnClientClick = GridXMCY.GetNoSelectionAlertReference("请至少选择一项！");
            btnYSZBDel.OnClientClick = GridYSZB.GetNoSelectionAlertReference("请至少选择一项！");
        }

        public void BindGridXMCY()
        {
            GridXMCY.DataSource = xmcy_bll.GetList(string.Format("XMBH='{0}'", ViewState["xmbh"].ToString()));
            GridXMCY.DataBind();
        }
        public void BindGridYSZB()
        {
            GridYSZB.DataSource = yszb_bll.GetList(string.Format("XMBH='{0}' And ZBFL=1", ViewState["xmbh"].ToString()));
            GridYSZB.DataBind();
        }

        #endregion


        protected void Button_step1_Click(object sender, EventArgs e)
        {
            //s1.Visible = true;
            ContentPanel_step1.Hidden = false;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;

            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(1);");
        }

        #region 一 保存项目成员信息
        protected void Button_step2_Click(object sender, EventArgs e)
        {

            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = false;
            SimpleForm_step3.Hidden = true;

            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(2);");
        }

        protected void btnXMCYXXSave_Click(object sender, EventArgs e)
        {
            string xmbh = ViewState["xmbh"].ToString();
            xmcy_model.XMBH = xmbh;
            xmcy_model.XM = txtXM.Text.Trim();
            xmcy_model.BMJZW = txtBMJZW.Text.Trim();
            xmcy_model.RWFG = txtRWFG.Text;
            xmcy_model.SJ = txtSJ.Text.Trim();
            xmcy_model.DZYX = txtDZYX.Text.Trim();
            xmcy_bll.Add(xmcy_model);
            BindGridXMCY();
            FormXMCYXX.Reset();
        }

        protected void btnXMCYXXDel_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(GridXMCY);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                xmcy_bll.Delete(ids[i]);
            }
            BindGridXMCY();
        }

        protected void Button_step3_Click(object sender, EventArgs e)
        {
            if (GridXMCY.Rows.Count <= 0)
            {
                Alert.Show("请添加项目成员信息！");
                return;
            }

            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = false;

            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(3);");
        }
        #endregion

        #region 二 申报项目建设方案
        protected void Button_step4_Click(object sender, EventArgs e)
        {

            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;

            SimpleForm_step7.Hidden = false;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(4);");
        }
        #endregion

        #region 三 项目验收指标
        protected void Button_step7_Click(object sender, EventArgs e)
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;

            SimpleForm_step7.Hidden = false;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(4);");

        }

        protected void btnYSZBSave_Click(object sender, EventArgs e)
        {
            string xmbh = ViewState["xmbh"].ToString();
            yszb_model.XMBH = xmbh;
            yszb_model.JSMB = txtJSMB.Text.Trim();
            yszb_model.YQWCSJ = Convert.ToDateTime(dpYQWCSJ.SelectedDate).ToString("yyyy-MM-dd");
            yszb_model.YSYD = txtYSYD.Text;
            yszb_model.ZBFL = 1;
            yszb_bll.Add(yszb_model);
            BindGridYSZB();
            Panel29.Reset();
            Panel30.Reset();
        }

        protected void btnYSZBDel_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(GridYSZB);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                yszb_bll.Delete(ids[i]);
            }
            BindGridYSZB();
        }

        protected void Button_step8_Click(object sender, EventArgs e)
        {
            //判断是否添加验收指标
            if (GridYSZB.Rows.Count <= 0)
            {
                Alert.Show("请添加验收指标！");
                return;
            }
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;

            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = false;
            SimpleForm_step9.Hidden = true;
            PageContext.RegisterStartupScript("a(5);");

        }
        #endregion

        #region 四 经费预算
        #region 专项经费
        /// <summary>
        /// 1、系统开发经费
        /// 2、业务培训经费
        /// 3、仪器设备经费
        /// 4、外聘人员费用
        /// 5、业务费（包括差旅、印刷、交通、系统维护等）
        /// </summary>
        public void SumZXJf()
        {
            string JFYS_ZXJF_JSFA_JFYS = txtJFYS_ZXJF_XTKF_JFYS.Text.Trim() == "" ? "0" : txtJFYS_ZXJF_XTKF_JFYS.Text.ToString().Trim();
            string JFYS_ZXJF_YWPX_JFYS = txtJFYS_ZXJF_YWPX_JFYS.Text.Trim() == "" ? "0" : txtJFYS_ZXJF_YWPX_JFYS.Text.ToString().Trim();
            string JFYS_ZXJF_YQSB_JFYS = txtJFYS_ZXJF_YQSB_JFYS.Text.Trim() == "" ? "0" : txtJFYS_ZXJF_YQSB_JFYS.Text.ToString().Trim();
            string JFYS_ZXJF_WPRY_JFYS = txtJFYS_ZXJF_WPRY_JFYS.Text.Trim() == "" ? "0" : txtJFYS_ZXJF_WPRY_JFYS.Text.ToString().Trim();
            string JFYS_ZXJF_YWF_JFYS = txtJFYS_ZXJF_YWF_JFYS.Text.Trim() == "" ? "0" : txtJFYS_ZXJF_YWF_JFYS.Text.ToString().Trim();

            float JFYS_ZXJF_JFGSHJ_JFYS = (float.Parse(JFYS_ZXJF_JSFA_JFYS) + float.Parse(JFYS_ZXJF_YWPX_JFYS) + float.Parse(JFYS_ZXJF_YQSB_JFYS) + float.Parse(JFYS_ZXJF_WPRY_JFYS) + float.Parse(JFYS_ZXJF_YWF_JFYS));
            txtJFYS_ZXJF_JFGSHJ_JFYS.Text = String.Format("{0:0.00}", JFYS_ZXJF_JFGSHJ_JFYS);
            txtJFYS_ZXJF.Text = String.Format("{0:0.00}", JFYS_ZXJF_JFGSHJ_JFYS);

        }

        protected void ZXJFSum_TextChanged(object sender, EventArgs e)
        {
            SumZXJf();
        }
        #endregion

        #region 学校配套经费
        public void SumXXPTJf()
        {
            string JFYS_XXPTJF_JSFA_JFYS = txtJFYS_XXPTJF_XTKF_JFYS.Text.Trim() == "" ? "0" : txtJFYS_XXPTJF_XTKF_JFYS.Text.ToString().Trim();
            string JFYS_XXPTJF_YWPX_JFYS = txtJFYS_XXPTJF_YWPX_JFYS.Text.Trim() == "" ? "0" : txtJFYS_XXPTJF_YWPX_JFYS.Text.ToString().Trim();
            string JFYS_XXPTJF_YQSB_JFYS = txtJFYS_XXPTJF_YQSB_JFYS.Text.Trim() == "" ? "0" : txtJFYS_XXPTJF_YQSB_JFYS.Text.ToString().Trim();
            string JFYS_XXPTJF_WPRY_JFYS = txtJFYS_XXPTJF_WPRY_JFYS.Text.Trim() == "" ? "0" : txtJFYS_XXPTJF_WPRY_JFYS.Text.ToString().Trim();
            string JFYS_XXPTJF_YWF_JFYS = txtJFYS_XXPTJF_YWF_JFYS.Text.Trim() == "" ? "0" : txtJFYS_XXPTJF_YWF_JFYS.Text.ToString().Trim();

            float JFYS_XXPTJF_JFGSHJ_JFYS = (float.Parse(JFYS_XXPTJF_JSFA_JFYS) + float.Parse(JFYS_XXPTJF_YWPX_JFYS) + float.Parse(JFYS_XXPTJF_YQSB_JFYS) + float.Parse(JFYS_XXPTJF_WPRY_JFYS) + float.Parse(JFYS_XXPTJF_YWF_JFYS));
            txtJFYS_XXPTJF_JFGSHJ_JFYS.Text = String.Format("{0:0.00}", JFYS_XXPTJF_JFGSHJ_JFYS);
            txtJFYS_XXPTJF.Text = String.Format("{0:0.00}", JFYS_XXPTJF_JFGSHJ_JFYS);

        }

        protected void XXPTJFSum_TextChanged(object sender, EventArgs e)
        {
            SumXXPTJf();
        }
        #endregion
        #endregion
        
        #region 上传附件

        public void UploadAtta3()
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

        protected void FileUpload3_FileSelected(object sender, EventArgs e)
        {
            UploadAtta3();
        }

        protected void Button_step9_Click(object sender, EventArgs e)
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;

            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            SimpleForm_step9.Hidden = false;
            PageContext.RegisterStartupScript("a(6);");
        }

        /// <summary>
        /// 修改保存
        /// </summary>
        /// <returns></returns>
        /// DateTime：2015-03-19 16:50
        /// Author：By risfeng
        /// Author Email：risfeng@126.com
        public bool EditSave()
        {
            try
            {
                string id = Request["id"];
                if (string.IsNullOrEmpty(id))
                {
                    Alert.ShowInTop("非法的请求");
                    return false;
                }
                //加载数据
                xm_model = xm_bll.GetModel(Convert.ToInt32(id));
                if (xm_model == null)
                {
                    Alert.ShowInTop("无数据！");
                    return false;
                }
                //赋值
                xm_model.XMMC = txtXMMC.Text.Trim();
                xm_model.DWMC = txtDWMC.Text.Trim();

                xm_model.XMFZRXX_XM = txtXMFZRXX_XM.Text.Trim();
                xm_model.XMFZRXX_BM = txtXMFZRXX_BM.Text.Trim();
                xm_model.XMFZRXX_ZYJSZW = txtXMFZRXX_ZYJSZW.Text.Trim();
                xm_model.XMFZRXX_XZZW = txtXMFZRXX_XZZW.Text.Trim();
                xm_model.XMFZRXX_BGSDH = txtXMFZRXX_BGSDH.Text.Trim();
                xm_model.XMFZRXX_CZ = txtXMFZRXX_CZ.Text.Trim();
                xm_model.XMFZRXX_SJ = txtXMFZRXX_SJ.Text.Trim();
                xm_model.XMFZRXX_DZYX = txtXMFZRXX_DZYX.Text.Trim();

                xm_model.SBXMJSFA_SBLY = txtSBXMJSFA_SBLY.Text;
                xm_model.SBXMJSFA_JSMB = txtSBXMJSFA_JSMB.Text;
                xm_model.SBXMJSFA_JTJC = txtSBXMJSFA_JTJC.Text;
                xm_model.SBXMJSFA_JFAP = txtSBXMJSFA_JFAP.Text;
                xm_model.SBXMJSFA_SSJH = txtSBXMJSFA_SSJH.Text;

                //专项经费
                xm_model.JFYS_ZXJF = decimal.Parse(txtJFYS_ZXJF.Text);
                xm_model.JFYS_ZXJF_ZXKSSJ = dpJFYS_ZXJF_ZXKSSJ.SelectedDate;
                xm_model.JFYS_ZXJF_ZXJSSJ = dpJFYS_ZXJF_ZXJSSJ.SelectedDate;

                xm_model.JFYS_ZXJF_XTKF_SM = txtJFYS_ZXJF_XTKF_SM.Text;
                xm_model.JFYS_ZXJF_XTKF_JFYS = decimal.Parse(txtJFYS_ZXJF_XTKF_JFYS.Text);
                xm_model.JFYS_ZXJF_XTKF_BZ = txtJFYS_ZXJF_XTKF_BZ.Text;

                xm_model.JFYS_ZXJF_YWPX_SM = txtJFYS_ZXJF_YWPX_SM.Text;
                xm_model.JFYS_ZXJF_YWPX_JFYS = decimal.Parse(txtJFYS_ZXJF_YWPX_JFYS.Text);
                xm_model.JFYS_ZXJF_YWPX_BZ = txtJFYS_ZXJF_YWPX_BZ.Text;

                xm_model.JFYS_ZXJF_YQSB_SM = txtJFYS_ZXJF_YQSB_SM.Text;
                xm_model.JFYS_ZXJF_YQSB_JFYS = decimal.Parse(txtJFYS_ZXJF_YQSB_JFYS.Text);
                xm_model.JFYS_ZXJF_YQSB_BZ = txtJFYS_ZXJF_YQSB_BZ.Text;

                xm_model.JFYS_ZXJF_WPRY_SM = txtJFYS_ZXJF_WPRY_SM.Text;
                xm_model.JFYS_ZXJF_WPRY_JFYS = decimal.Parse(txtJFYS_ZXJF_WPRY_JFYS.Text);
                xm_model.JFYS_ZXJF_WPRY_BZ = txtJFYS_ZXJF_WPRY_BZ.Text;

                xm_model.JFYS_ZXJF_YWF_SM = txtJFYS_ZXJF_YWF_SM.Text;
                xm_model.JFYS_ZXJF_YWF_JFYS = decimal.Parse(txtJFYS_ZXJF_YWF_JFYS.Text);
                xm_model.JFYS_ZXJF_YWF_BZ = txtJFYS_ZXJF_YWF_BZ.Text;

                //xm_model.JFYS_ZXJF_JFGSHJ_SM = txtJFYS_ZXJF_JFGSHJ_SM.Text;
                xm_model.JFYS_ZXJF_JFGSHJ_JFYS = decimal.Parse(txtJFYS_ZXJF_JFGSHJ_JFYS.Text);
                //xm_model.JFYS_ZXJF_JFGSHJ_BZ = txtJFYS_ZXJF_JFGSHJ_BZ.Text;

                //学校配套经费
                xm_model.JFYS_XXPTJF = decimal.Parse(txtJFYS_XXPTJF.Text);
                xm_model.JFYS_XXPTJF_ZXKSSJ = dpJFYS_XXPTJF_ZXKSSJ.SelectedDate;
                xm_model.JFYS_XXPTJF_ZXJSSJ = dpJFYS_XXPTJF_ZXJSSJ.SelectedDate;

                xm_model.JFYS_XXPTJF_XTKF_SM = txtJFYS_XXPTJF_XTKF_SM.Text;
                xm_model.JFYS_XXPTJF_XTKF_JFYS = decimal.Parse(txtJFYS_XXPTJF_XTKF_JFYS.Text);
                xm_model.JFYS_XXPTJF_XTKF_BZ = txtJFYS_XXPTJF_XTKF_BZ.Text;

                xm_model.JFYS_XXPTJF_YWPX_SM = txtJFYS_XXPTJF_YWPX_SM.Text;
                xm_model.JFYS_XXPTJF_YWPX_JFYS = decimal.Parse(txtJFYS_XXPTJF_YWPX_JFYS.Text);
                xm_model.JFYS_XXPTJF_YWPX_BZ = txtJFYS_XXPTJF_YWPX_BZ.Text;

                xm_model.JFYS_XXPTJF_YQSB_SM = txtJFYS_XXPTJF_YQSB_SM.Text;
                xm_model.JFYS_XXPTJF_YQSB_JFYS = decimal.Parse(txtJFYS_XXPTJF_YQSB_JFYS.Text);
                xm_model.JFYS_XXPTJF_YQSB_BZ = txtJFYS_XXPTJF_YQSB_BZ.Text;

                xm_model.JFYS_XXPTJF_WPRY_SM = txtJFYS_XXPTJF_WPRY_SM.Text;
                xm_model.JFYS_XXPTJF_WPRY_JFYS = decimal.Parse(txtJFYS_XXPTJF_WPRY_JFYS.Text);
                xm_model.JFYS_XXPTJF_WPRY_BZ = txtJFYS_XXPTJF_WPRY_BZ.Text;

                xm_model.JFYS_XXPTJF_YWF_SM = txtJFYS_XXPTJF_YWF_SM.Text;
                xm_model.JFYS_XXPTJF_YWF_JFYS = decimal.Parse(txtJFYS_XXPTJF_YWF_JFYS.Text);
                xm_model.JFYS_XXPTJF_YWF_BZ = txtJFYS_XXPTJF_YWF_BZ.Text;

                //xm_model.JFYS_XXPTJF_JFGSHJ_SM = txtJFYS_XXPTJF_JFGSHJ_SM.Text;
                xm_model.JFYS_XXPTJF_JFGSHJ_JFYS = decimal.Parse(txtJFYS_XXPTJF_JFGSHJ_JFYS.Text);
                //xm_model.JFYS_XXPTJF_JFGSHJ_BZ = txtJFYS_XXPTJF_JFGSHJ_BZ.Text;

                return xm_bll.Update(xm_model);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }

        }
        protected void btnSaveEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EditSave())
                {
                    Alert.Show("修改数据保存失败！");
                    return;
                }
                //1、附件
                Model.XMFJ XMFJ_Mode = new Model.XMFJ();
                BLL.XMFJ XMFJ_Bll = new BLL.XMFJ();
                XMFJ_Mode = XMFJ_Bll.GetModelList("XMBH='" + xm_model.XMBH + "'")[0];
                if (ViewState["file3"] != null)
                    XMFJ_Mode.XMYSMXWJM = ViewState["file3"].ToString();
                XMFJ_Bll.Update(XMFJ_Mode);

                //2、生成word 
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"] + ".doc";
                var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015项目申报书(信息管理平台)150228.doc");
                var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

                xm_model = xm_bll.GetModel(ViewState["xmbh"].ToString());//加载项目信息

                if (new BuildWord().BuildWord_2015ProjectDeclaration_XXGLPT(tmppath, savepath, xm_model.XMBH))
                {
                    BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                    Model.XMSBSWD model = null;
                    List<Model.XMSBSWD> l_m = wordBll.GetModelList("XMBH='" + xm_model.XMBH + "'");
                    model = l_m.Count > 0 ? l_m[0] : new Model.XMSBSWD();
                    model.XMBH = xm_model.XMBH;
                    model.XMMC = xm_model.XMMC;
                    model.WDLJ = savepath;
                    if (l_m.Count > 0)
                        wordBll.Update(model);
                    else
                        wordBll.Add(model);
                }
                else
                {
                    Alert.Show("生成Word失败！");
                    return;
                }
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message);
            }
        }
        #endregion

        #region Extend

        private string AutoNumber(string seed)
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM   JSJNJS_XM  WHERE   (XMBH LIKE '" + seed.Trim() + "%') ORDER BY XMBH DESC";
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

        #endregion




    }
}