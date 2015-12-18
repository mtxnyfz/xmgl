using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;
using System.Data.SqlClient;
using System.Data;
using AppBox;
using Maticsoft.DBUtility;
using XMGL.Model;

namespace XMGL.Web.admin
{
    public partial class XMGL_Add : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        Model.JSXX jsxx_model = new Model.JSXX();
        BLL.JSXX JSXX_bll = new BLL.JSXX();

        Model.YLZY ylzy_model = new Model.YLZY();
        BLL.YLZY ylzy_bll = new BLL.YLZY();

        Model.ZYZSJYQK zyzsjyqk_model = new Model.ZYZSJYQK();
        BLL.ZYZSJYQK zyzsjyqk_bll = new BLL.ZYZSJYQK();

        Model.YSZB yszb_model = new Model.YSZB();
        BLL.YSZB yszb_bll = new BLL.YSZB();

        Model.JFYS jfys_model = new Model.JFYS();
        BLL.JFYS jfys_bll = new BLL.JFYS();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DatePicker_yqwcsj.MinDate = DateTime.Now.AddDays(1);
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
                sqlstr = " delete from [YLZY] where XMMC is null or XMMC=''";
                DbHelperSQL.ExecuteSql(sqlstr);
                ViewState["xmbh"] = AutoNumber("2015-01-");
                //直接将编号插入数据库
                ylzy_model.XMBH = ViewState["xmbh"].ToString();
                ylzy_bll.Add(ylzy_model);

                BindTextZRJS();
            }
        }

        #region 一、单位承诺

        protected void Button_step1_Click(object sender, EventArgs e)//顶部导航按钮：单位承诺
        {
            ContentPanel_step1.Hidden = false;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            PageContext.RegisterStartupScript("a(1);");
        }

        protected void Button_step2_Click(object sender, EventArgs e)//底部“下一步”按钮
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
            PageContext.RegisterStartupScript("a(2);");
        }

        #endregion

        #region 二、申报学校基本信息
        //已经在Page_Load事件中读取出来
        #endregion

        #region 三、申报专业基本情况

        protected void Button_step3_Click(object sender, EventArgs e)//顶部导航
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = false;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step6.Hidden = true;
            SimpleForm_step7.Hidden = true;
            SimpleForm_step8.Hidden = true;
            PageContext.RegisterStartupScript("a(3);");
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

        protected void databind_zymc()//绑定专业名称
        {
            ZYMC.Items.Clear();
            DataTable dt = DbHelperSQL.Query("SELECT distinct [ZYDM]  ,[ZYMC] ,[ZYFXDM] ,[ZYFXMC]  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "' and ZYDM is not null  order by ZYMC").Tables[0];

            //DataTable dt_new = dt.Copy();
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

            ZYMC.DataSource = dt;
            ZYMC.DataTextField = "ZYMC";
            ZYMC.DataValueField = "ZYDM";
            ZYMC.DataBind();
            ZYMC.Items.Add("请选择", "请选择");

            dp_setvalue(ZYMC, "请选择");
        }

        protected void ZYMC_SelectedIndexChanged(object sender, EventArgs e)//专业名称：内容更换时，获取专业明细
        {
            string zydm1 = "", zyfxdm = "";
            try
            {
                if (ZYMC.SelectedValue.Trim().Contains("@"))
                {
                }
                else
                    zyfxdm = ZYMC.SelectedValue.Trim().Split(',')[1];

                zydm1 = ZYMC.SelectedValue.Trim().Split(',')[0];
                string sqlstr = "select *  FROM ZYB1 where ZYDM='" + zydm1 + "' and ZYFXDM='" + zyfxdm + "' and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string m = "", d = "", sj = "";
                if (sdr.Read())
                {
                    if (sdr["ZYFXDM"].ToString().Trim() != "")
                        ZYDM.Text = sdr["ZYFXDM"].ToString().Trim();
                    else
                        ZYDM.Text = sdr["ZYDM"].ToString().Trim();
                    ZYFZR_XM.Text = sdr["ZYFZR_XM"].ToString().Trim();
                    ZYSSDL.Text = sdr["ZYSSDL"].ToString().Trim();
                    ZYSSEJL.Text = sdr["ZYSSEJL"].ToString().Trim();
                    ZYFZR_ZYJSZW.Text = sdr["ZYFZR_ZYJSZW"].ToString().Trim();
                    sj = sdr["ZYKBSJ"].ToString().Trim();

                    ZYKBSJ.Text = sj;

                    bind_zsyjqk(zydm1, zyfxdm);
                }
                else
                {
                    ZYDM.Text = "";
                    ZYFZR_XM.Text = "";
                    ZYSSDL.Text = "";
                    ZYSSEJL.Text = "";

                    ZYFZR_ZYJSZW.Text = "";
                    ZYKBSJ.Text = "";
                }
                sdr.Dispose();
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
                return;
            }

        }

        protected void bind_zsyjqk(string zydm, string zyfxdm)//绑定Grid1:读取专业近三年招生就业情况，需要在点击“下一步”按钮时保存数据到表
        {
            string sqlstr = "";
            DataTable dt = null;
            for (int i = 2012; i < 2015; i++)
            {
                sqlstr = "select * from ZYZSJYQKB where ZYDM='" + zydm + "' and ZYFXDM='" + zyfxdm + "' and XXDM='" + ViewState["xxdm"] + "' and NF='" + i + "'";
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
                        dr["nf"] = i.ToString();
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
                        dr["NumberBox_xsbdl"] = 0;
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
                dt.Rows[i]["NumberBox_xsbdl"] = String.Format("{0:N2}", decimal.Parse(dt.Rows[i]["NumberBox_xsbdl"].ToString().Trim()));
                dt.Rows[i]["NumberBox_ccjyl"] = String.Format("{0:N2}", decimal.Parse(dt.Rows[i]["NumberBox_ccjyl"].ToString().Trim()));
            }
            DataView dv = new DataView(dt);
            dv.Sort = "nf asc";
            Grid1.DataSource = dv;
            Grid1.DataBind();
            ViewState["dt1"] = dt;

        }

        public void BindGridJSXX()//绑定页面上gird2教师信息列表
        {
            Grid2.DataSource = JSXX_bll.GetList(string.Format("XMBH='{0}' and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'", ViewState["xmbh"].ToString()));
            Grid2.DataBind();
        }

        protected void Grid2_RowDataBound(object sender, GridRowEventArgs e)//绑定数据时，修改专兼职和双师素质内容
        {
            GridRow gr = Grid2.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb10 = gr.FindControl("Label10") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lb11 = gr.FindControl("Label11") as System.Web.UI.WebControls.Label;
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
        }

        public void BindTextZRJS()//绑定页面上专任教师数合计
        {
            List<JSXX> ds = JSXX_bll.GetModelList(string.Format("XMBH='{0}' and ZZJZ={1} and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'", ViewState["xmbh"].ToString(), 1));
            ZRJSS.Text = ds.Count().ToString();
        }

        public void BindTextJZJS()//绑定页面上兼职教师数合计
        {
            List<JSXX> ds = JSXX_bll.GetModelList(string.Format("XMBH='{0}' and ZZJZ={1} and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'", ViewState["xmbh"].ToString(), 2));
            JZJSS.Text = ds.Count().ToString();
        }

        protected void Button222_Click(object sender, EventArgs e)//页面上“确定”按钮：保存教师信息：
        {
            try
            {

                string jsxm = TextBox1_jsxm.Text.Trim();
                if (jsxm == "")
                {
                    Alert.Show("教师姓名为必选项");
                    return;
                }
                jsxx_model = JSXX_bll.GetModel(ViewState["xmbh"].ToString(), jsxm);
                bool IsAdd = false;
                if (jsxx_model == null)//新增
                {
                    IsAdd = true;
                    jsxx_model = new Model.JSXX();
                }
                string zjz = HiddenField_zjz.Text.Trim();
                string sfss = HiddenField_ss.Text.Trim();
                string xl = HiddenField_xl.Text.Trim();
                string xw = HiddenField_xw.Text.Trim();
                string zcdj = HiddenField_zcdj.Text.Trim();
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

                jsxx_model.XXDM = Session["xxdm"].ToString();
                jsxx_model.XMBH = ViewState["xmbh"].ToString();
                jsxx_model.JSXM = jsxm;
                jsxx_model.CSNY = HiddenField_csny.Text;
                jsxx_model.ZZJZ = int.Parse(zjz);
                jsxx_model.SFSS = int.Parse(sfss);
                jsxx_model.XL = xl;
                jsxx_model.XW = xw;
                jsxx_model.ZCDJ = zcdj;
                if (IsAdd)
                {
                    //return JSXX_bll.Add(jsxx_model) > 0;
                    if (JSXX_bll.Add(jsxx_model) > 0)
                    {
                        ylzy_model = new Model.YLZY();
                        ylzy_model.XMBH = ViewState["xmbh"].ToString();
                        ylzy_model.XXDM = Session["xxdm"].ToString();
                        ylzy_bll.Add(ylzy_model);
                        Alert.Show("添加成功");
                    }

                }
                else
                {
                    //return JSXX_bll.Update(jsxx_model);
                    if (JSXX_bll.Update(jsxx_model) == true)
                        Alert.Show("添加成功");

                }
                BindGridJSXX();
                BindTextZRJS();
                BindTextJZJS();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                //return false;
            }
        }

        protected void Button2_add_Click(object sender, EventArgs e)//页面上“添加新的专业教师基本信息”按钮：弹出新增窗体
        {
            PageContext.RegisterStartupScript(Window1.GetShowReference("jsxx_Add.aspx?XMBH=" + ViewState["xmbh"].ToString(), "添加教师基本信息", 700, 450));
        }

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)//窗体关闭时更新grid2、专任教师数、兼职教师数
        {
            BindGridJSXX();
            BindTextZRJS();
            BindTextJZJS();
        }

        protected void Button5_Click(object sender, EventArgs e)//删除教师信息
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid2);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                JSXX_bll.Delete(ids[i]);
            }
            BindGridJSXX();
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

        protected void Button_step4_Click(object sender, EventArgs e)//下一步保存以及“申报专业与标杆专业对比分析”顶部导航按钮
        {
            if (Grid2.Rows.Count <= 0)
            {
                Alert.Show("请添加项目成员信息！");
                return;
            }
            if (!Add_YLZY())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
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
            PageContext.RegisterStartupScript("a(4);");
        }

        ///// <summary>
        ///// 申报学校基本情况
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        public bool Add_YLZY()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                string xxdm = ViewState["xxdm"].ToString();
                ylzy_model = ylzy_bll.GetModel(xxdm, xmbh);
                if (ylzy_model == null)
                {
                    IsAdd = true;
                    ylzy_model = new Model.YLZY();
                }
                //赋值
                ylzy_model.XMBH = xmbh;
                ylzy_model.XXDM = xxdm;
                ylzy_model.XMMC = TextBox_xmmc.Text.Trim();
                ViewState["XMMC"] = TextBox_xmmc.Text.Trim();
                ylzy_model.ZYDM = ZYDM.Text.Trim();
                if (ylzy_model.ZYDM == "")
                {
                    Alert.Show("“专业代码”为必选项");
                    return false;
                }
                ylzy_model.ZYMC = ZYMC.SelectedText.Trim();
                ylzy_model.ZYSSDL = ZYSSDL.Text.Trim();
                ylzy_model.ZYSSEJL = ZYSSEJL.Text.Trim();
                ylzy_model.ZYFZR_XM = ZYFZR_XM.Text.Trim();
                ylzy_model.ZYFZR_XZZW = ZYFZR_XZZW.Text.Trim();
                if (ylzy_model.ZYFZR_XZZW == "")
                {
                    Alert.Show("“专业负责人行政职务”为必填项");
                    return false;
                }
                ylzy_model.ZYFZR_ZYJSZW = ZYFZR_ZYJSZW.Text.Trim();
                if (ylzy_model.ZYFZR_ZYJSZW == "")
                {
                    Alert.Show("“专业负责人专业技术职务”为必填项");
                    return false;
                }
                ylzy_model.ZYFZR_ZYZGZS = ZYFZR_ZYZGZS.Text.Trim();
                if (ylzy_model.ZYFZR_ZYZGZS == "")
                {
                    Alert.Show("“专业负责人职业资格证书”为必填项");
                    return false;
                }
                ylzy_model.ZYFZR_BGSDH = ZYFZR_BGSDH.Text.Trim();
                if (ylzy_model.ZYFZR_BGSDH == "")
                {
                    Alert.Show("“专业负责人办公室电话”为必填项");
                    return false;
                }
                ylzy_model.ZYFZR_CZ = ZYFZR_CZ.Text.Trim();
                if (ylzy_model.ZYFZR_CZ == "")
                {
                    Alert.Show("“专业负责人传真”为必填项");
                    return false;
                }
                ylzy_model.ZYFZR_SJ = ZYFZR_SJ.Text.Trim();
                if (ylzy_model.ZYFZR_SJ == "")
                {
                    Alert.Show("“专业负责人手机”为必填项");
                    return false;
                }
                ylzy_model.ZYFZR_DZYX = ZYFZR_DZYX.Text.Trim();
                if (ylzy_model.ZYFZR_DZYX == "")
                {
                    Alert.Show("“专业负责人电子邮箱”为必填项");
                    return false;
                }
                string zytd = "";
                if (RadioButtonList_zytd.SelectedIndex >= 0)
                {
                    zytd = RadioButtonList_zytd.SelectedValue.Trim();
                }
                else
                {
                    Alert.Show("专业建设定位类型为必选项");
                    return false;
                }
                ylzy_model.ZYTD = zytd;
                ylzy_model.ZYKBSJ = ZYKBSJ.Text.Trim();
                if (ylzy_model.ZYKBSJ == "")
                {
                    Alert.Show("“专业开办时间”为必填项");
                    return false;
                }
                int kszs = 1;//是否跨省招生
                if (SFKSZS.SelectedIndex == 0)
                    kszs = 1;
                else if (SFKSZS.SelectedIndex == 1)
                    kszs = 0;
                else
                {
                    Alert.Show("是否跨省招生为必选项");
                    return false;
                }
                ylzy_model.SFKSZS = kszs;
                ylzy_model.ZRJSS = Convert.ToInt32(ZRJSS.Text.Trim());
                ylzy_model.JZJSS = Convert.ToInt32(JZJSS.Text.Trim());

                if (XYZSSXSMJ.Text.Trim() == "")
                {
                    Alert.Show("“现有专属实训室面积”为必填项");
                    return false;
                }
                ylzy_model.XYZSSXSMJ = Convert.ToDecimal(XYZSSXSMJ.Text.Trim());
                if (XYTYSXSMJ.Text.Trim() == "")
                {
                    Alert.Show("“现有通用实训室面积”为必填项");
                    return false;
                }
                ylzy_model.XYTYSXSMJ = Convert.ToDecimal(XYTYSXSMJ.Text.Trim());
                if (XYSXSBZZ.Text.Trim() == "")
                {
                    Alert.Show("“现有实训设备总值”为必填项");
                    return false;
                }
                ylzy_model.XYSXSBZZ = Convert.ToDecimal(XYSXSBZZ.Text.Trim());
                if (XYSXYQSB.Text.Trim() == "")
                {
                    Alert.Show("“现有实训仪器设备”为必填项");
                    return false;
                }
                ylzy_model.XYSXYQSB = Convert.ToInt32(XYSXYQSB.Text.Trim());
                ylzy_model.user_uid = pb.GetIdentityId();
                ylzy_model.TBRQ = DateTime.Now.ToShortDateString();
                if (IsAdd)
                {
                    if (ZYSNZSJY(xxdm, xmbh, ZYDM.Text.Trim()) == false)
                    {
                        return false;
                    }
                    else
                    {
                        return ylzy_bll.Add(ylzy_model) > 0;
                    }
                }
                else
                {
                    if (ZYSNZSJY(xxdm, xmbh, ZYDM.Text.Trim()) == false)
                    {
                        return false;
                    }
                    else
                    {
                        return ylzy_bll.Update(ylzy_model);
                    }
                }

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        public bool ZYSNZSJY(string XXDM, string XMBH, string ZYDM)
        {
            try
            {
                //添加近三年专业招生就业数据到数据库
                bool _IsAdd = false;
                zyzsjyqk_model = zyzsjyqk_bll.GetModel(XXDM, XMBH, ZYDM);
                if (zyzsjyqk_model == null)
                {
                    _IsAdd = true;
                    zyzsjyqk_model = new Model.ZYZSJYQK();
                }
                DataTable dt = ViewState["dt1"] as DataTable;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        zyzsjyqk_model.XXDM = XXDM;
                        zyzsjyqk_model.XMBH = XMBH;
                        zyzsjyqk_model.ZYDM = ZYDM;
                        zyzsjyqk_model.NF = dt.Rows[i]["nf"].ToString();
                        zyzsjyqk_model.SJZSS = int.Parse(dt.Rows[i]["NumberBox_sjzss"].ToString());
                        zyzsjyqk_model.XSBDL = decimal.Parse(dt.Rows[i]["NumberBox_xsbdl"].ToString());
                        zyzsjyqk_model.QRZZXSS = int.Parse(dt.Rows[i]["NumberBox_qrzzxss"].ToString());
                        zyzsjyqk_model.DDPYRS = int.Parse(dt.Rows[i]["NumberBox_ddpyrs"].ToString());
                        zyzsjyqk_model.BYSRS = int.Parse(dt.Rows[i]["NumberBox_byss"].ToString());
                        zyzsjyqk_model.CCJYL = decimal.Parse(dt.Rows[i]["NumberBox_ccjyl"].ToString());
                        if (_IsAdd)
                        {
                            zyzsjyqk_bll.Add(zyzsjyqk_model);
                        }
                        else
                        {
                            zyzsjyqk_bll.Update(zyzsjyqk_model);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }


        #endregion

        #region 四、申报专业与标杆专业对比分析

        /// <summary>
        /// 申报专业与标杆专业对比分析保存
        /// </summary>
        /// Write by 耿春喜
        /// 2015-4-17
        public bool Add_DBFX()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                string xxdm = ViewState["xxdm"].ToString();
                ylzy_model = ylzy_bll.GetModel(xxdm, xmbh);
                if (ylzy_model == null)
                {
                    IsAdd = true;
                    ylzy_model = new Model.YLZY();
                }
                ylzy_model.BGZYYXMC = TextBox1_yxmc.Text.Trim();
                if (ylzy_model.BGZYYXMC == "")
                {
                    step4();
                    Alert.Show("“标杆专业院校名称”为必填项");
                }
                ylzy_model.BGZYZYMC = TextBox2_zymc.Text.Trim();
                if (ylzy_model.BGZYZYMC == "")
                {
                    step4();
                    Alert.Show("“标杆专业专业名称”为必填项");
                }
                ylzy_model.XZLY = TextArea_xzly.Text.Trim();
                if (ylzy_model.XZLY == "")
                {
                    step4();
                    Alert.Show("“选择标杆专业的理由”为必填项");
                }
                ylzy_model.DBFX = TextArea_dbfx.Text.Trim();
                if (ylzy_model.DBFX == "")
                {
                    step4();
                    Alert.Show("“对比分析”为必填项");
                }

                if (IsAdd)
                {
                    return ylzy_bll.Add(ylzy_model) > 0;
                }
                else
                {
                    return ylzy_bll.Update(ylzy_model);
                }

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        protected void Button_step5_Click(object sender, EventArgs e)//“申报专业与标杆专业对比分析”下一步保存以及“申报项目建设方案”顶部导航
        {
            if (!Add_DBFX())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            step5();
        }

        #endregion

        #region 五、申报项目建设方案
        // <summary>
        /// 申报项目建设方案
        /// </summary>
        /// Write by 耿春喜
        /// 2015-4-17
        public bool Add_SBXMJSFA()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                string xxdm = ViewState["xxdm"].ToString();
                ylzy_model = ylzy_bll.GetModel(xxdm, xmbh);
                if (ylzy_model == null)
                {
                    IsAdd = true;
                    ylzy_model = new Model.YLZY();
                }
                ylzy_model.SBLY = SBLY.Text.Trim();
                if (ylzy_model.SBLY == "")
                {
                    step5();
                    Alert.Show("“申报理由”为必填项");
                }
                ylzy_model.JSMB = JSMB.Text.Trim();
                if (ylzy_model.JSMB == "")
                {
                    step5();
                    Alert.Show("“建设目标”为必填项");
                }
                ylzy_model.JTJC = JTJC.Text.Trim();
                if (ylzy_model.JTJC == "")
                {
                    step5();
                    Alert.Show("“具体举措”为必填项");
                }
                ylzy_model.JFAP = JFAP.Text.Trim();
                if (ylzy_model.JFAP == "")
                {
                    step5();
                    Alert.Show("“经费安排”为必填项");
                }
                ylzy_model.SSJH = SSJH.Text.Trim();
                if (ylzy_model.SSJH == "")
                {
                    step5();
                    Alert.Show("“实施计划”为必填项");
                }

                if (IsAdd)
                {
                    return ylzy_bll.Add(ylzy_model) > 0;
                }
                else
                {
                    return ylzy_bll.Update(ylzy_model);
                }

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        protected void Button_step6_Click(object sender, EventArgs e)//"申报项目建设方案"下一步保存以及“项目验收指标”顶部导航
        {
            if (!Add_SBXMJSFA())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            step6();
        }
        #endregion

        #region 六、项目验收指标
        protected void Button3_Click(object sender, EventArgs e)//"添加到项目验收指标列表"按钮
        {
            try
            {
                string xmbh = ViewState["xmbh"].ToString();
                string jsmb = TextArea_jsmb.Text.Trim();
                if (jsmb == "")
                {
                    Alert.Show("建设目标为必填项");
                    return;
                }
                string yqwcsj = DatePicker_yqwcsj.Text.Trim();
                if (yqwcsj == "")
                {
                    Alert.Show("计划验收日期为必填项");
                    return;
                }
                string ysyd = TextArea_ysyd.Text.Trim();
                if (ysyd == "")
                {
                    Alert.Show("验收要点为必填项");
                    return;
                }
                yszb_model = new Model.YSZB();
                yszb_model.XMBH = xmbh;
                yszb_model.JSMB = jsmb;
                yszb_model.YQWCSJ = yqwcsj;
                yszb_model.YSYD = ysyd;

                if (yszb_bll.Add(yszb_model) > 0)
                {
                    BindGridYSZB();
                    Alert.Show("添加成功");
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        public void BindGridYSZB()//绑定页面上gird3项目验收指标列表
        {
            Grid3.DataSource = yszb_bll.GetList(string.Format("XMBH='{0}'", ViewState["xmbh"].ToString()));
            Grid3.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)//删除验收指标列表中数据
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid3);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                yszb_bll.Delete(ids[i]);
            }
            BindGridYSZB();
        }

        #endregion

        #region 七、经费预算

        protected void Button_step7_Click(object sender, EventArgs e)//经费预算顶部导航
        {
            step7();
        }

        #region 申请专项经费自动合计
        public void AddHj1(NumberBox nb)//申请专项经费自动合计
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
                if (hj_2015 > 150)
                {
                    NumberBox_sqzxjfgshj_2015.Text = String.Format("{0:0.00}", hj_2015 - float.Parse(nb.Text.Trim()));
                    nb.Text = "0";
                    Alert.Show("每年经费合计不能超过150万：");
                    return;
                }

                string ryjf_2016 = NumberBox_sqzxjfkcjcjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2016.Text.ToString().Trim();
                string xsbz_2016 = NumberBox_sqzxjfszpxjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2016.Text.ToString().Trim();
                string jxky_2016 = NumberBox_sqzxjfyqsbjf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2016.Text.ToString().Trim();
                string ywf_2016 = NumberBox_sqzxjfwpryfy_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2016.Text.ToString().Trim();
                string sbgz_2016 = NumberBox_sqzxjfywf_2016.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2016.Text.ToString().Trim();
                float hj_2016 = (float.Parse(ryjf_2016) + float.Parse(xsbz_2016) + float.Parse(jxky_2016) + float.Parse(ywf_2016) + float.Parse(sbgz_2016));
                NumberBox_sqzxjfgshj_2016.Text = String.Format("{0:0.00}", hj_2016);

                if (hj_2016 > 150)
                {
                    NumberBox_sqzxjfgshj_2016.Text = String.Format("{0:0.00}", hj_2016 - float.Parse(nb.Text.Trim()));
                    nb.Text = "0";
                    Alert.Show("每年经费合计不能超过150万：");
                    return;
                }

                string ryjf_2017 = NumberBox_sqzxjfkcjcjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfkcjcjf_2017.Text.ToString().Trim();
                string xsbz_2017 = NumberBox_sqzxjfszpxjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfszpxjf_2017.Text.ToString().Trim();
                string jxky_2017 = NumberBox_sqzxjfyqsbjf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfyqsbjf_2017.Text.ToString().Trim();
                string ywf_2017 = NumberBox_sqzxjfwpryfy_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfwpryfy_2017.Text.ToString().Trim();
                string sbgz_2017 = NumberBox_sqzxjfywf_2017.Text.Trim() == "" ? "0" : NumberBox_sqzxjfywf_2017.Text.ToString().Trim();
                float hj_2017 = (float.Parse(ryjf_2017) + float.Parse(xsbz_2017) + float.Parse(jxky_2017) + float.Parse(ywf_2017) + float.Parse(sbgz_2017));
                NumberBox_sqzxjfgshj_2017.Text = String.Format("{0:0.00}", hj_2017);

                if (hj_2017 > 150)
                {
                    NumberBox_sqzxjfgshj_2017.Text = String.Format("{0:0.00}", hj_2017 - float.Parse(nb.Text.Trim()));
                    nb.Text = "0";
                    Alert.Show("每年经费合计不能超过150万：");
                    return;
                }



                NumberBox_sqzxjfhj.Text = String.Format("{0:0.00}", hj_2015 + hj_2016 + hj_2017);
                if ((hj_2015 + hj_2016 + hj_2017) > 450)
                {
                    NumberBox_sqzxjfhj.Text = String.Format("{0:0.00}", hj_2015 + hj_2016 + hj_2017 - float.Parse(nb.Text.Trim()));
                    nb.Text = "0";
                    Alert.Show("三年经费合计不能超过450万：");
                    return;
                }

            }
            catch (Exception ex)
            {
                Alert.Show("计费合计错误：" + ex.Message);
            }
        }

        protected void NumberBox_sqzxjfkcjcjf_TextChanged(object sender, EventArgs e)
        {
            NumberBox nb = sender as NumberBox;
            AddHj1(nb);
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
        #endregion

        #region 学校配套经费自动合计
        public void AddHj2()//项目配套经费合计
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
        #endregion

        #region 保存经费预算
        public void Add_XMJF()
        {
            string nf = "";
            string xmbh = ViewState["xmbh"].ToString();
            try
            {
                nf = "2015";
                bool IsAdd = false;
                jfys_model = jfys_bll._GetModel(string.Format("XMBH='{0}' and NF='{1}'", xmbh, nf));
                if (jfys_model == null)//新增
                {
                    IsAdd = true;
                    jfys_model = new Model.JFYS();
                }
                jfys_model.NF = nf;
                jfys_model.XMBH = xmbh;
                jfys_model.SQZXJFJFGSHJ = Convert.ToDecimal(NumberBox_sqzxjfgshj_2015.Text.Trim());
                jfys_model.SQZXJFKCJCJF = Convert.ToDecimal(NumberBox_sqzxjfkcjcjf_2015.Text.Trim());
                jfys_model.SQZXJFSZPXJF = Convert.ToDecimal(NumberBox_sqzxjfszpxjf_2015.Text.Trim());
                jfys_model.SQZXJFYQSBJF = Convert.ToDecimal(NumberBox_sqzxjfyqsbjf_2015.Text.Trim());
                jfys_model.SQZXJFWPRYJF = Convert.ToDecimal(NumberBox_sqzxjfwpryfy_2015.Text.Trim());
                jfys_model.SQZXJFYWF = Convert.ToDecimal(NumberBox_sqzxjfywf_2015.Text.Trim());

                jfys_model.XXPTJFJFGSHJ = Convert.ToDecimal(NumberBox_xxptgshj_2015.Text.Trim());
                jfys_model.XXPTJFKCJCJF = Convert.ToDecimal(NumberBox_xxptkcjcjf_2015.Text.Trim());
                jfys_model.XXPTJFSZPXJF = Convert.ToDecimal(NumberBox_xxptszpxf_2015.Text.Trim());
                jfys_model.XXPTJFYQSBJF = Convert.ToDecimal(NumberBox_xxptyqsbjf_2015.Text.Trim());
                jfys_model.XXPTJFWPRYJF = Convert.ToDecimal(NumberBox_xxptwpryfy_2015.Text.Trim());
                jfys_model.XXPTJFYWF = Convert.ToDecimal(NumberBox_xxptywf_2015.Text.Trim());
                if (IsAdd)
                {
                    jfys_bll.Add(jfys_model);
                }
                else
                {
                    jfys_bll.Update(jfys_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
            try
            {
                nf = "2016";
                bool IsAdd = false;
                jfys_model = jfys_bll._GetModel(string.Format("XMBH='{0}' and NF='{1}'", xmbh, nf));
                if (jfys_model == null)//新增
                {
                    IsAdd = true;
                    jfys_model = new Model.JFYS();
                }
                jfys_model.NF = nf;
                jfys_model.XMBH = xmbh;
                jfys_model.SQZXJFJFGSHJ = Convert.ToDecimal(NumberBox_sqzxjfgshj_2016.Text.Trim());
                jfys_model.SQZXJFKCJCJF = Convert.ToDecimal(NumberBox_sqzxjfkcjcjf_2016.Text.Trim());
                jfys_model.SQZXJFSZPXJF = Convert.ToDecimal(NumberBox_sqzxjfszpxjf_2016.Text.Trim());
                jfys_model.SQZXJFYQSBJF = Convert.ToDecimal(NumberBox_sqzxjfyqsbjf_2016.Text.Trim());
                jfys_model.SQZXJFWPRYJF = Convert.ToDecimal(NumberBox_sqzxjfwpryfy_2016.Text.Trim());
                jfys_model.SQZXJFYWF = Convert.ToDecimal(NumberBox_sqzxjfywf_2016.Text.Trim());

                jfys_model.XXPTJFJFGSHJ = Convert.ToDecimal(NumberBox_xxptgshj_2016.Text.Trim());
                jfys_model.XXPTJFKCJCJF = Convert.ToDecimal(NumberBox_xxptkcjcjf_2016.Text.Trim());
                jfys_model.XXPTJFSZPXJF = Convert.ToDecimal(NumberBox_xxptszpxf_2016.Text.Trim());
                jfys_model.XXPTJFYQSBJF = Convert.ToDecimal(NumberBox_xxptyqsbjf_2016.Text.Trim());
                jfys_model.XXPTJFWPRYJF = Convert.ToDecimal(NumberBox_xxptwpryfy_2016.Text.Trim());
                jfys_model.XXPTJFYWF = Convert.ToDecimal(NumberBox_xxptywf_2016.Text.Trim());

                if (IsAdd)
                {
                    jfys_bll.Add(jfys_model);
                }
                else
                {
                    jfys_bll.Update(jfys_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }

            try
            {
                nf = "2017";
                bool IsAdd = false;
                jfys_model = jfys_bll._GetModel(string.Format("XMBH='{0}' and NF='{1}'", xmbh, nf));
                if (jfys_model == null)//新增
                {
                    IsAdd = true;
                    jfys_model = new Model.JFYS();
                }
                jfys_model.NF = nf;
                jfys_model.XMBH = xmbh;
                jfys_model.SQZXJFJFGSHJ = Convert.ToDecimal(NumberBox_sqzxjfgshj_2017.Text.Trim());
                jfys_model.SQZXJFKCJCJF = Convert.ToDecimal(NumberBox_sqzxjfkcjcjf_2017.Text.Trim());
                jfys_model.SQZXJFSZPXJF = Convert.ToDecimal(NumberBox_sqzxjfszpxjf_2017.Text.Trim());
                jfys_model.SQZXJFYQSBJF = Convert.ToDecimal(NumberBox_sqzxjfyqsbjf_2017.Text.Trim());
                jfys_model.SQZXJFWPRYJF = Convert.ToDecimal(NumberBox_sqzxjfwpryfy_2017.Text.Trim());
                jfys_model.SQZXJFYWF = Convert.ToDecimal(NumberBox_sqzxjfywf_2017.Text.Trim());

                jfys_model.XXPTJFJFGSHJ = Convert.ToDecimal(NumberBox_xxptgshj_2017.Text.Trim());
                jfys_model.XXPTJFKCJCJF = Convert.ToDecimal(NumberBox_xxptkcjcjf_2017.Text.Trim());
                jfys_model.XXPTJFSZPXJF = Convert.ToDecimal(NumberBox_xxptszpxf_2017.Text.Trim());
                jfys_model.XXPTJFYQSBJF = Convert.ToDecimal(NumberBox_xxptyqsbjf_2017.Text.Trim());
                jfys_model.XXPTJFWPRYJF = Convert.ToDecimal(NumberBox_xxptwpryfy_2017.Text.Trim());
                jfys_model.XXPTJFYWF = Convert.ToDecimal(NumberBox_xxptywf_2017.Text.Trim());

                if (IsAdd)
                {
                    jfys_bll.Add(jfys_model);
                }
                else
                {
                    jfys_bll.Update(jfys_model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        public void Add_JFYSHJ()
        {
            string xmbh = ViewState["xmbh"].ToString();
            string xxdm = ViewState["xxdm"].ToString();
            ylzy_model = ylzy_bll.GetModel(xxdm, xmbh);
            if (ylzy_model != null)
            {
                try
                {
                    ylzy_model.SQZXJF = Convert.ToDecimal(NumberBox_sqzxjfhj.Text.Trim());
                }
                catch (Exception ex)
                {
                    step7();
                    Alert.Show("不合法的数据：" + ex.Message);
                    return;
                }
                ylzy_model.SQZXJFZXKSSJ = DatePicker_sqzxjfzxksrq.Text.Trim();
                if (ylzy_model.SQZXJFZXKSSJ == "")
                {
                    step7();
                    Alert.Show("“执行开始时间”为必填项");
                    return;
                }
                ylzy_model.SQZXJFZXJSSJ = DatePicker_sqzxjfzxjsrq.Text.Trim();
                if (ylzy_model.SQZXJFZXJSSJ == "")
                {
                    step7();
                    Alert.Show("“执行结束时间”为必填项");
                    return;
                }
                try
                {
                    ylzy_model.XXPTJF = Convert.ToDecimal(NumberBox_xxptjfhj.Text.Trim());
                }
                catch (Exception ex)
                {
                    step7();
                    Alert.Show("不合法的数据：" + ex.Message);
                    return;
                }
                ylzy_model.XXPTJFZXKSSJ = DatePicker_xxptjfzxksrq.Text.Trim();
                if (ylzy_model.XXPTJFZXKSSJ == "")
                {
                    step7();
                    Alert.Show("“执行开始时间”为必填项");
                    return;
                }
                ylzy_model.XXPTJFZXJSSJ = DatePicker_xxptjfzxjsrq.Text.Trim();
                if (ylzy_model.XXPTJFZXJSSJ == "")
                {
                    step7();
                    Alert.Show("“执行结束时间”为必填项");
                    return;
                }
                ylzy_model.user_uid = pb.GetIdentityId();
                ylzy_model.ZT = 1;
                ylzy_model.SFSC = 0;
                ylzy_model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");
                ylzy_bll.Update(ylzy_model);
            }
        }

        protected void Button_step8_Click(object sender, EventArgs e)//“下一步”按钮保存
        {
            Add_XMJF();//添加经费预算明细
            Add_JFYSHJ();//添加经费预算合计
            step8();

        }
        #endregion

        #endregion

        #region 八、附件管理
        protected void btnSubmit1_Click(object sender, EventArgs e)//附件一上传
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

        protected void btnSubmit2_Click(object sender, EventArgs e)//附件二上传
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

        protected void btnSubmit3_Click(object sender, EventArgs e)//附件三上传
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

        protected void Button4_Click(object sender, EventArgs e)//最后一步“保存”
        {
            string xmbh = ViewState["xmbh"].ToString();
            SaveFile(xmbh, ViewState["file1"].ToString().Trim(), ViewState["file2"].ToString().Trim(), ViewState["file3"].ToString().Trim());//保存附件一
            //SaveFile(xmbh, ViewState["file2"].ToString().Trim());//保存附件二
            //SaveFile(xmbh, ViewState["file3"].ToString().Trim());//保存附件三


            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"].ToString() + ".doc";
            var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015项目申报书(一流专业建设)150226.doc");
            var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

            if (new BuildWord().BuildWord_2015ProjectDeclaration(tmppath, savepath, xmbh))
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                Model.XMSBSWD model = new Model.XMSBSWD();
                model.XMBH = xmbh;
                model.XMMC = ViewState["XMMC"].ToString();
                model.WDLJ = savepath;
                wordBll.Add(model);
            }
            PageContext.RegisterStartupScript("alert('已成功保存,系统将自动关闭此页面');CloseWebPage();");


        }
        #endregion

        private string AutoNumber(string seed)//生成项目编号
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM   YLZY  WHERE   (XMBH LIKE '" + seed.Trim() + "%') ORDER BY XMBH DESC";
                string bm1 = "", bm2 = "", bm = "", tempbm = "";
                SqlDataReader dr = DbHelperSQL.ExecuteReader(sql);
                if (dr.Read())
                {
                    tempbm = dr["XMBH"].ToString().Trim();
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

        protected void Button7_Click(object sender, EventArgs e)//近三年专业招生就业情况：删除【暂时不用】
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
                            //dt.Rows[i].Delete();
                            dt.Rows.Remove(dt.Rows[i]);
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

        private void SaveFile(string XMBH, string FileName1, string FileName2,string FileName3)//保存附件、关联项目
        {
            bool IsAdd = false;
            Model.XMFJ XMFJ_Mode = new Model.XMFJ();
            BLL.XMFJ XMFJ_Bll = new BLL.XMFJ();
            XMFJ_Mode = XMFJ_Bll._GetModel(XMBH);
            if (XMFJ_Mode == null)
            {
                IsAdd = true;
                XMFJ_Mode = new Model.XMFJ();
            }
            XMFJ_Mode.XMBH = XMBH.Trim();
            if (FileName1 != null)
                XMFJ_Mode.XMKXXFXBGWJM = FileName1.ToString();
            if (FileName2 != null)
                XMFJ_Mode.YXXSALWJM = FileName2.ToString();
            if (FileName3 != null)
                XMFJ_Mode.XMYSMXWJM = FileName3.ToString();
            if (IsAdd)
            {
                XMFJ_Bll.Add(XMFJ_Mode);
            }
            else
            {
                XMFJ_Bll.Update(XMFJ_Mode);
            }
        }


















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
            PageContext.RegisterStartupScript("a(8);");

        }


        protected void Button9_s2_Click(object sender, EventArgs e)
        {
            //ContentPanel_step1.Hidden = true;
            //SimpleForm_step2.Hidden = false;
            //SimpleForm_step3.Hidden = true;
            //SimpleForm_step4.Hidden = true;
            //SimpleForm_step5.Hidden = true;
            //SimpleForm_step6.Hidden = true;
            //SimpleForm_step7.Hidden = true;
            //SimpleForm_step8.Hidden = true;
            PageContext.RegisterStartupScript("a(2);");
            //Alert.ShowInTop("4");
        }


    }
}