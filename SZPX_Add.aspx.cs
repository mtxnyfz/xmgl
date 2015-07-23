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
using Maticsoft.Common;

namespace XMGL.Web.admin
{
    public partial class SZPX_Add : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    XMSB_DWMC.Text = xxmc;
                    XMSB_DWMC.Enabled = false;
                    XMSB_DWMC.Readonly = true;
                }
                sdr.Dispose();
            }
        }





        protected void NumberBox_PTJF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string PTJF_KCJCJZLF_JFYS_value = PTJF_KCJCJZLF_JFYS.Text.Trim() == "" ? "0" : PTJF_KCJCJZLF_JFYS.Text.ToString().Trim();
                string PTJF_YQSBJHCF_JFYS_value = PTJF_YQSBJHCF_JFYS.Text.Trim() == "" ? "0" : PTJF_YQSBJHCF_JFYS.Text.ToString().Trim();
                string PTJF_WPRYJF_JFYS_value = PTJF_WPRYJF_JFYS.Text.Trim() == "" ? "0" : PTJF_WPRYJF_JFYS.Text.ToString().Trim();
                string PTJF_CDF_JFYS_value = PTJF_CDF_JFYS.Text.Trim() == "" ? "0" : PTJF_CDF_JFYS.Text.ToString().Trim();
                string PTJF_CYF_JFYS_value = PTJF_CYF_JFYS.Text.Trim() == "" ? "0" : PTJF_CYF_JFYS.Text.ToString().Trim();

                string PTJF_ZSF_JFYS_value = PTJF_ZSF_JFYS.Text.Trim() == "" ? "0" : PTJF_ZSF_JFYS.Text.ToString().Trim();
                string PTJF_JTF_JFYS_value = PTJF_JTF_JFYS.Text.Trim() == "" ? "0" : PTJF_JTF_JFYS.Text.ToString().Trim();

                float sum = (float.Parse(PTJF_KCJCJZLF_JFYS_value) + float.Parse(PTJF_YQSBJHCF_JFYS_value) + float.Parse(PTJF_WPRYJF_JFYS_value) + float.Parse(PTJF_CDF_JFYS_value) + float.Parse(PTJF_CYF_JFYS_value) + float.Parse(PTJF_ZSF_JFYS_value) + float.Parse(PTJF_JTF_JFYS_value));



                PTJF_JFHJ_JFYS.Text = String.Format("{0:0.00}", sum);
                PTJF_JFYS.Text = String.Format("{0:0.00}", sum);
            }
            catch (Exception ex)
            {
                Alert.Show("计费合计错误：" + ex.Message);
            }
        }


        protected void NumberBox_SQZXJF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string ZXJF_KCJCJZLF_JFYS_value = ZXJF_KCJCJZLF_JFYS.Text.Trim() == "" ? "0" : ZXJF_KCJCJZLF_JFYS.Text.ToString().Trim();
                string ZXJF_YQSBJHCF_JFYS_value = ZXJF_YQSBJHCF_JFYS.Text.Trim() == "" ? "0" : ZXJF_YQSBJHCF_JFYS.Text.ToString().Trim();
                string ZXJF_WPRYJF_JFYS_value = ZXJF_WPRYJF_JFYS.Text.Trim() == "" ? "0" : ZXJF_WPRYJF_JFYS.Text.ToString().Trim();
                string ZXJF_CDF_JFYS_value = ZXJF_CDF_JFYS.Text.Trim() == "" ? "0" : ZXJF_CDF_JFYS.Text.ToString().Trim();
                string ZXJF_CYF_JFYS_value = ZXJF_CYF_JFYS.Text.Trim() == "" ? "0" : ZXJF_CYF_JFYS.Text.ToString().Trim();

                string ZXJF_ZSF_JFYS_value = ZXJF_ZSF_JFYS.Text.Trim() == "" ? "0" : ZXJF_ZSF_JFYS.Text.ToString().Trim();
                string ZXJF_JTF_JFYS_value = ZXJF_JTF_JFYS.Text.Trim() == "" ? "0" : ZXJF_JTF_JFYS.Text.ToString().Trim();

                float sum = (float.Parse(ZXJF_KCJCJZLF_JFYS_value) + float.Parse(ZXJF_YQSBJHCF_JFYS_value) + float.Parse(ZXJF_WPRYJF_JFYS_value) + float.Parse(ZXJF_CDF_JFYS_value) + float.Parse(ZXJF_CYF_JFYS_value) + float.Parse(ZXJF_ZSF_JFYS_value) + float.Parse(ZXJF_JTF_JFYS_value));



                ZXJF_JFHJ_JFYS.Text = String.Format("{0:0.00}", sum);
                ZXJF_JFYS.Text = String.Format("{0:0.00}", sum);
            }
            catch (Exception ex)
            {
                Alert.Show("计费合计错误：" + ex.Message);
            }
        }



        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {

        }

        protected void SZPX_XMCY_add_Click(object sender, EventArgs e)
        {
            string XMCY_CY_CYXM_value = XMCY_CY_CYXM.Text.Trim();
            string XMCY_CY_BMJZW_value = XMCY_CY_BMJZW.Text.Trim();
            string XMCY_CY_RWFG_value = XMCY_CY_RWFG.Text.Trim();
            string XMCY_CY_SJ_value = XMCY_CY_SJ.Text.Trim();
            string XMCY_CY_DZYX_value = XMCY_CY_DZYX.Text.Trim();


            #region CheckInfo
            if (string.IsNullOrWhiteSpace(XMCY_CY_CYXM_value))
            {
                Alert.ShowInTop("请填写项目成员姓名");
                return;
            }
            if (XMCY_CY_CYXM_value.Length >= 8)
            {
                Alert.ShowInTop("项目成员姓名过长，请重新填写");
                return;
            }



            if (string.IsNullOrWhiteSpace(XMCY_CY_BMJZW_value))
            {
                Alert.ShowInTop("请填写项目成员部门及职务");
                return;
            }
            if (string.IsNullOrWhiteSpace(XMCY_CY_RWFG_value))
            {
                Alert.ShowInTop("请填写项目成员任务分工");
                return;
            }

            if (XMCY_CY_BMJZW_value.Length >= 150)
            {
                Alert.ShowInTop("您填写的项目成员所属部门及职务过长，请重新填写");
                return;
            }
            if (XMCY_CY_RWFG_value.Length >= 2000)
            {
                Alert.ShowInTop("您填写的项目成员任务分工过长，请重新填写");
                return;
            }



            if (string.IsNullOrWhiteSpace(XMCY_CY_SJ_value))
            {
                Alert.ShowInTop("请填写项目成员手机号码");
                return;
            }
            if (string.IsNullOrWhiteSpace(XMCY_CY_DZYX_value))
            {
                Alert.ShowInTop("请填写项目成员电子邮箱地址");
                return;
            }


            if (!Common.DataValidate.ValidateMobile(XMCY_CY_SJ_value))
            {
                Alert.ShowInTop("请正确填写项目成员的手机号码");
                return;
            }
            if (!PageValidate.IsEmail(XMCY_CY_DZYX_value))
            {
                Alert.ShowInTop("请正确填写项目成员的电子邮箱地址");
                return;
            }



            #endregion


            #region AddList
            if (ViewState["XMCY_CY_list"] == null)
            {
                var dt = new DataTable();
                dt.Columns.Add("UID");
                dt.Columns.Add("XMCY_CY_CYXM");
                dt.Columns.Add("XMCY_CY_BMJZW");
                dt.Columns.Add("XMCY_CY_RWFG");
                dt.Columns.Add("XMCY_CY_SJ");
                dt.Columns.Add("XMCY_CY_DZYX");
                DataRow dr = dt.NewRow();
                dr["UID"] = Guid.NewGuid().ToString();
                dr["XMCY_CY_CYXM"] = XMCY_CY_CYXM_value;
                dr["XMCY_CY_BMJZW"] = XMCY_CY_BMJZW_value;
                dr["XMCY_CY_RWFG"] = XMCY_CY_RWFG_value;
                dr["XMCY_CY_SJ"] = XMCY_CY_SJ_value;
                dr["XMCY_CY_DZYX"] = XMCY_CY_DZYX_value;
                dt.Rows.Add(dr);
                ViewState["XMCY_CY_list"] = dt;
            }
            else
            {
                var dt = ViewState["XMCY_CY_list"] as DataTable;
                DataRow dr = dt.NewRow();
                dr["UID"] = Guid.NewGuid().ToString();
                dr["XMCY_CY_CYXM"] = XMCY_CY_CYXM_value;
                dr["XMCY_CY_BMJZW"] = XMCY_CY_BMJZW_value;
                dr["XMCY_CY_RWFG"] = XMCY_CY_RWFG_value;
                dr["XMCY_CY_SJ"] = XMCY_CY_SJ_value;
                dr["XMCY_CY_DZYX"] = XMCY_CY_DZYX_value;

                dt.Rows.Add(dr);
                ViewState["XMCY_CY_list"] = dt;
            }
            XMCY_CY_List_Grid.DataSource = ViewState["XMCY_CY_list"] as DataTable;
            XMCY_CY_List_Grid.DataBind();
            #endregion

        }

        protected void SZPX_XMCY_delete_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            int selectedCount = XMCY_CY_List_Grid.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = XMCY_CY_List_Grid.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (XMCY_CY_List_Grid.AllowPaging && !XMCY_CY_List_Grid.IsDatabasePaging)
                    {
                        rowIndex = XMCY_CY_List_Grid.PageIndex * XMCY_CY_List_Grid.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += XMCY_CY_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

                if (ViewState["XMCY_CY_list"] != null)
                {
                    DataTable dt = (DataTable)ViewState["XMCY_CY_list"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    XMCY_CY_List_Grid.DataSource = dt;
                    XMCY_CY_List_Grid.DataBind();
                    ViewState["XMCY_CY_list"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                XMCY_CY_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void YSZB_add_Click(object sender, EventArgs e)
        {
            string JSMB = TextArea_jsmb.Text.Trim();
            string YQWCSJ = DatePicker_yqwcsj.Text.Trim();
            string YSYD = TextArea_ysyd.Text.Trim();


            #region CheckInfo
            if (string.IsNullOrWhiteSpace(JSMB))
            {
                Alert.ShowInTop("请填写建设目标");
                return;
            }
            if (JSMB.Length >= 700)
            {
                Alert.ShowInTop("您填写的建设目标过长，请重新填写");
                return;
            }



            if (string.IsNullOrWhiteSpace(YQWCSJ))
            {
                Alert.ShowInTop("请选择预期完成时间");
                return;
            }
            if (string.IsNullOrWhiteSpace(YSYD))
            {
                Alert.ShowInTop("请填写验收要点");
                return;
            }
            if (YSYD.Length >= 700)
            {
                Alert.ShowInTop("您填写的验收要点过长，请重新填写");
                return;
            }

            #endregion


            #region AddList
            if (ViewState["YSZB_list"] == null)
            {
                var dt = new DataTable();
                dt.Columns.Add("UID");
                dt.Columns.Add("YSZB_JSMB");
                dt.Columns.Add("YSZB_YQWCSJ");
                dt.Columns.Add("YSZB_YSYD");

                DataRow dr = dt.NewRow();
                dr["UID"] = Guid.NewGuid().ToString();
                dr["YSZB_JSMB"] = JSMB;
                dr["YSZB_YQWCSJ"] = YQWCSJ;
                dr["YSZB_YSYD"] = YSYD;

                dt.Rows.Add(dr);
                ViewState["YSZB_list"] = dt;
            }
            else
            {
                var dt = ViewState["YSZB_list"] as DataTable;
                DataRow dr = dt.NewRow();
                dr["UID"] = Guid.NewGuid().ToString();
                dr["YSZB_JSMB"] = JSMB;
                dr["YSZB_YQWCSJ"] = YQWCSJ;
                dr["YSZB_YSYD"] = YSYD;

                dt.Rows.Add(dr);
                ViewState["YSZB_list"] = dt;
            }
            YSZB_list_Grid.DataSource = ViewState["YSZB_list"] as DataTable;
            YSZB_list_Grid.DataBind();
            #endregion
        }

        protected void YSZB_delete_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            int selectedCount = YSZB_list_Grid.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = YSZB_list_Grid.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (YSZB_list_Grid.AllowPaging && !YSZB_list_Grid.IsDatabasePaging)
                    {
                        rowIndex = YSZB_list_Grid.PageIndex * YSZB_list_Grid.PageSize + rowIndex;//获取翻页后的行号
                    }
                    selectedID += YSZB_list_Grid.DataKeys[rowIndex][0].ToString() + ",";


                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

                if (ViewState["YSZB_list"] != null)
                {
                    DataTable dt = (DataTable)ViewState["YSZB_list"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            dt.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    YSZB_list_Grid.DataSource = dt;
                    YSZB_list_Grid.DataBind();
                    ViewState["YSZB_list"] = dt;
                }


            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                YSZB_list_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void SMSB_add_Click(object sender, EventArgs e)
        {

            var FJYSMX_BLL = new BLL.SZPX_FJYSMX();

            try
            {
                if (ViewState["XMSB_MODEL_XMBH"] == null)
                { }
                else
                {

                    string xmbh = ViewState["XMSB_MODEL_XMBH"].ToString();


                    var FJYSMX_Model = FJYSMX_BLL.GetModelList("XMBH = '" + xmbh + "'").FirstOrDefault();

                    if (FJYSMX_Model != null)
                    {
                        if (ViewState["uploadfile1"] != null)
                        {
                            FJYSMX_Model.FJYSMX = ViewState["uploadfile1"].ToString();
                        }
                        FJYSMX_BLL.Update(FJYSMX_Model);
                    }
                    else
                    {
                        var New_FJYSMX_Model = new Model.SZPX_FJYSMX();


                        New_FJYSMX_Model.XMBH = xmbh;

                        if (ViewState["uploadfile1"] != null)
                            New_FJYSMX_Model.FJYSMX = ViewState["uploadfile1"].ToString();


                        FJYSMX_BLL.Add(New_FJYSMX_Model);

                    }

                    var xxdm = ViewState["xxdm"].ToString();
                    string filename = xxdm + "_" + xmbh + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".doc";
                    var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015项目申报书(师资培训)150124.doc");
                    var savepath = HttpContext.Current.Server.MapPath("~/admin/down/SZPX/" + filename);

                    if (new BuildWord().BuildWord_2015ProjectDeclaration_SZPX(tmppath, savepath, xmbh))
                    {
                        BLL.XMSBSWD wordBll = new BLL.XMSBSWD();

                        var model = wordBll.GetModelList("XMBH='" + xmbh + "'").FirstOrDefault();
                        if (model != null)
                        {
                            model.XMMC = ViewState["XMSB_MODEL_XMMC"].ToString();
                            model.WDLJ = savepath;
                            wordBll.Update(model);
                        }
                        else
                        {
                            Model.XMSBSWD word_model = new Model.XMSBSWD()
                            {
                                XMBH = xmbh,
                                XMMC = ViewState["XMSB_MODEL_XMMC"].ToString(),
                                WDLJ = savepath
                            };

                            wordBll.Add(word_model);
                        }
                    }



                    Alert.Show("申报成功！", "系统提示", MessageBoxIcon.Information);





                }





                
            }
            catch (Exception ex)
            {
                Alert.ShowInTop("添加失败");
                return;
            }
        }

        private string GetNumber()
        {
            try
            {
                string Num = "";

                var NowYear = DateTime.Now.Year;
                var NowMonth = DateTime.Now.Month;


                string sql = "SELECT XMBH  FROM   SZPX_XMSB  WHERE   (XMBH LIKE '2015-04-%') ORDER BY XMBH DESC";

                DataSet ds = DbHelperSQL.Query(sql);

                int i = 0;
                var dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    i = dt.Rows.Count;
                }

                i++;

                Num = "2015-04-" + (i >= 1000 ? i.ToString() : i.ToString("#000"));

                return Num;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void Button_step1_Click(object sender, EventArgs e)
        {
            //s1.Visible = true;
            ContentPanel_step1.Hidden = false;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
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
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(2);");
        }
        protected void Button_step3_Click(object sender, EventArgs e)
        {

            BLL.SZPX_XMSB XmsbBLL = new BLL.SZPX_XMSB();
            BLL.SZPX_XMCY XmcyBLL = new BLL.SZPX_XMCY();

            if (ViewState["XMSB_MODEL_XMBH"] == null)
            {


                #region XMSB
                Model.SZPX_XMSB XmsbModel = new Model.SZPX_XMSB();
                XmsbModel.XMMC = XMSB_XMMC.Text.Trim();
                XmsbModel.DWMC = XMSB_DWMC.Text.Trim();
                XmsbModel.TBRQ = DateTime.Now;
                XmsbModel.XMBH = GetNumber();
                XmsbModel.user_uid = pb.GetIdentityId();
                XmsbModel.SFSC = 0;
                XmsbModel.ZT = 1;




                #endregion

                if (XmsbBLL.Add(XmsbModel) > 0)
                {
                    ViewState["XMSB_MODEL_XMBH"] = XmsbModel.XMBH;
                    ViewState["XMSB_MODEL_XMMC"] = XmsbModel.XMMC;
                    #region 项目成员
                    //负责人
                    Model.SZPX_XMCY Xmcy_FZR_Model = new Model.SZPX_XMCY();
                    Xmcy_FZR_Model.XMBH = XmsbModel.XMBH;
                    Xmcy_FZR_Model.CYLX = "FZR";
                    Xmcy_FZR_Model.CYXM = XMCY_FZR_CYXM.Text.Trim();
                    Xmcy_FZR_Model.BM = XMCY_FZR_BM.Text.Trim();
                    Xmcy_FZR_Model.ZYJSZW = XMCY_FZR_ZYJSZW.Text.Trim();
                    Xmcy_FZR_Model.XZZW = XMCY_FZR_XZZW.Text.Trim();
                    Xmcy_FZR_Model.BGSDH = XMCY_FZR_BGSDH.Text.Trim();
                    Xmcy_FZR_Model.CZ = XMCY_FZR_CZ.Text.Trim();
                    Xmcy_FZR_Model.SJ = XMCY_FZR_SJ.Text.Trim();
                    Xmcy_FZR_Model.DZYX = XMCY_FZR_DZYX.Text.Trim();

                    XmcyBLL.Add(Xmcy_FZR_Model);

                    //成员
                    if (ViewState["XMCY_CY_list"] != null)
                    {
                        var dt = ViewState["XMCY_CY_list"] as DataTable;
                        foreach (DataRow item in dt.Rows)
                        {
                            Model.SZPX_XMCY Xmcy_CY_Model = new Model.SZPX_XMCY();
                            Xmcy_CY_Model.XMBH = XmsbModel.XMBH;
                            Xmcy_CY_Model.CYLX = "CY";
                            Xmcy_CY_Model.CYXM = item["XMCY_CY_CYXM"].ToString();
                            Xmcy_CY_Model.BMJZW = item["XMCY_CY_BMJZW"].ToString();
                            Xmcy_CY_Model.RWFG = item["XMCY_CY_RWFG"].ToString();
                            Xmcy_CY_Model.SJ = item["XMCY_CY_SJ"].ToString();
                            Xmcy_CY_Model.DZYX = item["XMCY_CY_DZYX"].ToString();

                            XmcyBLL.Add(Xmcy_CY_Model);
                        }
                    }
                    #endregion
                };
            }
            else
            {


                string xxbh = ViewState["XMSB_MODEL_XMBH"].ToString();
                #region XMSB
                var XmsbModel = XmsbBLL.GetModelList("XMBH = '" + xxbh + "'").FirstOrDefault();

                XmsbModel.XMMC = XMSB_XMMC.Text.Trim();
                XmsbModel.DWMC = XMSB_DWMC.Text.Trim();


                XmsbBLL.Update(XmsbModel);
                #endregion

                #region 项目成员


                //负责人

                var Xmcy_FZR_Model = XmcyBLL.GetModelList("XMBH = '" + xxbh + "' and CYLX='FZR' ").FirstOrDefault();

                Xmcy_FZR_Model.CYXM = XMCY_FZR_CYXM.Text.Trim();
                Xmcy_FZR_Model.BM = XMCY_FZR_BM.Text.Trim();
                Xmcy_FZR_Model.ZYJSZW = XMCY_FZR_ZYJSZW.Text.Trim();
                Xmcy_FZR_Model.XZZW = XMCY_FZR_XZZW.Text.Trim();
                Xmcy_FZR_Model.BGSDH = XMCY_FZR_BGSDH.Text.Trim();
                Xmcy_FZR_Model.CZ = XMCY_FZR_CZ.Text.Trim();
                Xmcy_FZR_Model.SJ = XMCY_FZR_SJ.Text.Trim();
                Xmcy_FZR_Model.DZYX = XMCY_FZR_DZYX.Text.Trim();

                XmcyBLL.Update(Xmcy_FZR_Model);



                string xmcy_delete_sql_str = "delete from SZPX_XMCY where XMBH = '" + xxbh + "' and CYLX='CY' ";


                if (DbHelperSQL.ExecuteSql(xmcy_delete_sql_str) > 0)
                {
                    //成员
                    if (ViewState["XMCY_CY_list"] != null)
                    {
                        var dt = ViewState["XMCY_CY_list"] as DataTable;
                        foreach (DataRow item in dt.Rows)
                        {
                            Model.SZPX_XMCY Xmcy_CY_Model = new Model.SZPX_XMCY();
                            Xmcy_CY_Model.XMBH = XmsbModel.XMBH;
                            Xmcy_CY_Model.CYLX = "CY";
                            Xmcy_CY_Model.CYXM = item["XMCY_CY_CYXM"].ToString();
                            Xmcy_CY_Model.BMJZW = item["XMCY_CY_BMJZW"].ToString();
                            Xmcy_CY_Model.RWFG = item["XMCY_CY_RWFG"].ToString();
                            Xmcy_CY_Model.SJ = item["XMCY_CY_SJ"].ToString();
                            Xmcy_CY_Model.DZYX = item["XMCY_CY_DZYX"].ToString();

                            XmcyBLL.Add(Xmcy_CY_Model);
                        }
                    }
                }
                #endregion



            }



            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = false;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(3);");
        }
        protected void Button_step4_Click(object sender, EventArgs e)
        {
            BLL.SZPX_JSFA JsfaBLL = new BLL.SZPX_JSFA();

            if (ViewState["XMSB_MODEL_XMBH"] == null)
            {
            }
            else
            {
                string xmbh = ViewState["XMSB_MODEL_XMBH"].ToString();
                var JsfaModel = JsfaBLL.GetModelList("XMBH = '" + xmbh + "'").FirstOrDefault();

                if (JsfaModel != null)
                {
                    JsfaModel.SBLY = JSFA_SBLY.Text.Trim();
                    JsfaModel.JSMB = JSFA_JSMB.Text.Trim();
                    JsfaModel.JTJC = JSFA_JTJC.Text.Trim();
                    JsfaModel.JFAP = JSFA_JFAP.Text.Trim();
                    JsfaModel.SSJH = JSFA_SSJH.Text.Trim();

                    JsfaBLL.Update(JsfaModel);
                }
                else
                {
                    #region 建设方案
                    Model.SZPX_JSFA New_JsfaModel = new Model.SZPX_JSFA();
                    New_JsfaModel.XMBH = xmbh;
                    New_JsfaModel.SBLY = JSFA_SBLY.Text.Trim();
                    New_JsfaModel.JSMB = JSFA_JSMB.Text.Trim();
                    New_JsfaModel.JTJC = JSFA_JTJC.Text.Trim();
                    New_JsfaModel.JFAP = JSFA_JFAP.Text.Trim();
                    New_JsfaModel.SSJH = JSFA_SSJH.Text.Trim();

                    JsfaBLL.Add(New_JsfaModel);

                    #endregion
                }
            }





            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = false;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(4);");
            //Alert.ShowInTop("4");
        }
        protected void Button_step5_Click(object sender, EventArgs e)
        {
            BLL.SZPX_YSZB YszbBLL = new BLL.SZPX_YSZB();


            if (ViewState["XMSB_MODEL_XMBH"] == null)
            {


            }
            else
            {
                string xmbh = ViewState["XMSB_MODEL_XMBH"].ToString();

                string yszb_delete_sql_str = "delete from SZPX_YSZB where XMBH = '" + xmbh + "' ";
                if (DbHelperSQL.ExecuteSql(yszb_delete_sql_str) > 0)
                {
                    if (ViewState["YSZB_list"] != null)
                    {
                        var dt = ViewState["YSZB_list"] as DataTable;
                        foreach (DataRow item in dt.Rows)
                        {
                            Model.SZPX_YSZB YSZB_Model = new Model.SZPX_YSZB();
                            YSZB_Model.XMBH = xmbh;

                            YSZB_Model.JSMB = item["YSZB_JSMB"].ToString();
                            YSZB_Model.JHYSRQ = Convert.ToDateTime(item["YSZB_YQWCSJ"].ToString());
                            YSZB_Model.YSYD = item["YSZB_YSYD"].ToString();

                            YszbBLL.Add(YSZB_Model);
                        }
                    }
                }
                else
                {
                    #region 验收指标
                    if (ViewState["YSZB_list"] != null)
                    {
                        var dt = ViewState["YSZB_list"] as DataTable;
                        foreach (DataRow item in dt.Rows)
                        {
                            Model.SZPX_YSZB YSZB_Model = new Model.SZPX_YSZB();
                            YSZB_Model.XMBH = xmbh;

                            YSZB_Model.JSMB = item["YSZB_JSMB"].ToString();
                            YSZB_Model.JHYSRQ = Convert.ToDateTime(item["YSZB_YQWCSJ"].ToString());
                            YSZB_Model.YSYD = item["YSZB_YSYD"].ToString();

                            YszbBLL.Add(YSZB_Model);
                        }
                    }

                    #endregion
                }

            }






            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = false;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(5);");

        }
        protected void Button_step6_Click(object sender, EventArgs e)
        {
            BLL.SZPX_JFYS JfysBLL = new BLL.SZPX_JFYS();

            if (ViewState["XMSB_MODEL_XMBH"] == null)
            {
            }
            else
            {
                string xmbh = ViewState["XMSB_MODEL_XMBH"].ToString();

                #region 经费预算




                //专项经费
                Model.SZPX_JFYS ZXJF_JfysModel = JfysBLL.GetModelList("XMBH = '" + xmbh + "' and JFLX='ZXJF'").FirstOrDefault();
                if (ZXJF_JfysModel != null)
                {
                    ZXJF_JfysModel.JFYS = ZXJF_JFYS.Text.Trim();
                    ZXJF_JfysModel.ZXKSSJ = Convert.ToDateTime(ZXJF_ZXKSSJ.Text.Trim());
                    ZXJF_JfysModel.ZXJSSJ = Convert.ToDateTime(ZXJF_ZXJSSJ.Text.Trim());

                    ZXJF_JfysModel.KCJCJZLF_SYSM = ZXJF_KCJCJZLF_SYSM.Text.Trim();
                    ZXJF_JfysModel.KCJCJZLF_JFYS = ZXJF_KCJCJZLF_JFYS.Text.Trim();
                    ZXJF_JfysModel.KCJCJZLF_BZ = ZXJF_KCJCJZLF_BZ.Text.Trim();

                    ZXJF_JfysModel.YQSBJHCF_SYSM = ZXJF_YQSBJHCF_SYSM.Text.Trim();
                    ZXJF_JfysModel.YQSBJHCF_JFYS = ZXJF_YQSBJHCF_JFYS.Text.Trim();
                    ZXJF_JfysModel.YQSBJHCF_BZ = ZXJF_YQSBJHCF_BZ.Text.Trim();

                    ZXJF_JfysModel.WPRYJF_SYSM = ZXJF_WPRYJF_SYSM.Text.Trim();
                    ZXJF_JfysModel.WPRYJF_JFYS = ZXJF_WPRYJF_JFYS.Text.Trim();
                    ZXJF_JfysModel.WPRYJF_BZ = ZXJF_WPRYJF_BZ.Text.Trim();

                    ZXJF_JfysModel.CDF_SYSM = ZXJF_CDF_SYSM.Text.Trim();
                    ZXJF_JfysModel.CDF_JFYS = ZXJF_CDF_JFYS.Text.Trim();
                    ZXJF_JfysModel.CDF_BZ = ZXJF_CDF_BZ.Text.Trim();

                    ZXJF_JfysModel.CYF_SYSM = ZXJF_CYF_SYSM.Text.Trim();
                    ZXJF_JfysModel.CYF_JFYS = ZXJF_CYF_JFYS.Text.Trim();
                    ZXJF_JfysModel.CYF_BZ = ZXJF_CYF_BZ.Text.Trim();

                    ZXJF_JfysModel.ZSF_SYSM = ZXJF_ZSF_SYSM.Text.Trim();
                    ZXJF_JfysModel.ZSF_JFYS = ZXJF_ZSF_JFYS.Text.Trim();
                    ZXJF_JfysModel.ZSF_BZ = ZXJF_ZSF_BZ.Text.Trim();

                    ZXJF_JfysModel.JTF_SYSM = ZXJF_JTF_SYSM.Text.Trim();
                    ZXJF_JfysModel.JTF_JFYS = ZXJF_JTF_JFYS.Text.Trim();
                    ZXJF_JfysModel.JTF_BZ = ZXJF_JTF_BZ.Text.Trim();
                    //耿春喜备注
                    //ZXJF_JfysModel.JFHJ_SYSM = ZXJF_JFHJ_SYSM.Text.Trim();
                    ZXJF_JfysModel.JFHJ_JFYS = ZXJF_JFHJ_JFYS.Text.Trim();
                    //ZXJF_JfysModel.JFHJ_BZ = ZXJF_JFHJ_BZ.Text.Trim();

                    JfysBLL.Update(ZXJF_JfysModel);
                }
                else
                {
                    //专项经费
                    Model.SZPX_JFYS New_ZXJF_JfysModel = new Model.SZPX_JFYS();
                    New_ZXJF_JfysModel.XMBH = xmbh;
                    New_ZXJF_JfysModel.JFLX = "ZXJF";
                    New_ZXJF_JfysModel.JFYS = ZXJF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.ZXKSSJ = Convert.ToDateTime(ZXJF_ZXKSSJ.Text.Trim());
                    New_ZXJF_JfysModel.ZXJSSJ = Convert.ToDateTime(ZXJF_ZXJSSJ.Text.Trim());

                    New_ZXJF_JfysModel.KCJCJZLF_SYSM = ZXJF_KCJCJZLF_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.KCJCJZLF_JFYS = ZXJF_KCJCJZLF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.KCJCJZLF_BZ = ZXJF_KCJCJZLF_BZ.Text.Trim();

                    New_ZXJF_JfysModel.YQSBJHCF_SYSM = ZXJF_YQSBJHCF_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.YQSBJHCF_JFYS = ZXJF_YQSBJHCF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.YQSBJHCF_BZ = ZXJF_YQSBJHCF_BZ.Text.Trim();

                    New_ZXJF_JfysModel.WPRYJF_SYSM = ZXJF_WPRYJF_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.WPRYJF_JFYS = ZXJF_WPRYJF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.WPRYJF_BZ = ZXJF_WPRYJF_BZ.Text.Trim();

                    New_ZXJF_JfysModel.CDF_SYSM = ZXJF_CDF_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.CDF_JFYS = ZXJF_CDF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.CDF_BZ = ZXJF_CDF_BZ.Text.Trim();

                    New_ZXJF_JfysModel.CYF_SYSM = ZXJF_CYF_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.CYF_JFYS = ZXJF_CYF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.CYF_BZ = ZXJF_CYF_BZ.Text.Trim();

                    New_ZXJF_JfysModel.ZSF_SYSM = ZXJF_ZSF_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.ZSF_JFYS = ZXJF_ZSF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.ZSF_BZ = ZXJF_ZSF_BZ.Text.Trim();

                    New_ZXJF_JfysModel.JTF_SYSM = ZXJF_JTF_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.JTF_JFYS = ZXJF_JTF_JFYS.Text.Trim();
                    New_ZXJF_JfysModel.JTF_BZ = ZXJF_JTF_BZ.Text.Trim();
                    //耿春喜备注
                    //New_ZXJF_JfysModel.JFHJ_SYSM = ZXJF_JFHJ_SYSM.Text.Trim();
                    New_ZXJF_JfysModel.JFHJ_JFYS = ZXJF_JFHJ_JFYS.Text.Trim();
                    //New_ZXJF_JfysModel.JFHJ_BZ = ZXJF_JFHJ_BZ.Text.Trim();

                    JfysBLL.Add(New_ZXJF_JfysModel);
                }


                //配套经费
                Model.SZPX_JFYS PTJF_JfysModel = JfysBLL.GetModelList("XMBH = '" + xmbh + "' and JFLX='PTJF'").FirstOrDefault();
                if (PTJF_JfysModel != null)
                {
                    PTJF_JfysModel.JFYS = PTJF_JFYS.Text.Trim();
                    PTJF_JfysModel.ZXKSSJ = Convert.ToDateTime(PTJF_ZXKSSJ.Text.Trim());
                    PTJF_JfysModel.ZXJSSJ = Convert.ToDateTime(PTJF_ZXJSSJ.Text.Trim());

                    PTJF_JfysModel.KCJCJZLF_SYSM = PTJF_KCJCJZLF_SYSM.Text.Trim();
                    PTJF_JfysModel.KCJCJZLF_JFYS = PTJF_KCJCJZLF_JFYS.Text.Trim();
                    PTJF_JfysModel.KCJCJZLF_BZ = PTJF_KCJCJZLF_BZ.Text.Trim();

                    PTJF_JfysModel.YQSBJHCF_SYSM = PTJF_YQSBJHCF_SYSM.Text.Trim();
                    PTJF_JfysModel.YQSBJHCF_JFYS = PTJF_YQSBJHCF_JFYS.Text.Trim();
                    PTJF_JfysModel.YQSBJHCF_BZ = PTJF_YQSBJHCF_BZ.Text.Trim();

                    PTJF_JfysModel.WPRYJF_SYSM = PTJF_WPRYJF_SYSM.Text.Trim();
                    PTJF_JfysModel.WPRYJF_JFYS = PTJF_WPRYJF_JFYS.Text.Trim();
                    PTJF_JfysModel.WPRYJF_BZ = PTJF_WPRYJF_BZ.Text.Trim();

                    PTJF_JfysModel.CDF_SYSM = PTJF_CDF_SYSM.Text.Trim();
                    PTJF_JfysModel.CDF_JFYS = PTJF_CDF_JFYS.Text.Trim();
                    PTJF_JfysModel.CDF_BZ = PTJF_CDF_BZ.Text.Trim();

                    PTJF_JfysModel.CYF_SYSM = PTJF_CYF_SYSM.Text.Trim();
                    PTJF_JfysModel.CYF_JFYS = PTJF_CYF_JFYS.Text.Trim();
                    PTJF_JfysModel.CYF_BZ = PTJF_CYF_BZ.Text.Trim();

                    PTJF_JfysModel.ZSF_SYSM = PTJF_ZSF_SYSM.Text.Trim();
                    PTJF_JfysModel.ZSF_JFYS = PTJF_ZSF_JFYS.Text.Trim();
                    PTJF_JfysModel.ZSF_BZ = PTJF_ZSF_BZ.Text.Trim();

                    PTJF_JfysModel.JTF_SYSM = PTJF_JTF_SYSM.Text.Trim();
                    PTJF_JfysModel.JTF_JFYS = PTJF_JTF_JFYS.Text.Trim();
                    PTJF_JfysModel.JTF_BZ = PTJF_JTF_BZ.Text.Trim();

                    //PTJF_JfysModel.JFHJ_SYSM = PTJF_JFHJ_SYSM.Text.Trim();
                    PTJF_JfysModel.JFHJ_JFYS = PTJF_JFHJ_JFYS.Text.Trim();
                    //PTJF_JfysModel.JFHJ_BZ = PTJF_JFHJ_BZ.Text.Trim();

                    JfysBLL.Update(PTJF_JfysModel);
                }
                else
                {

                    //配套经费
                    Model.SZPX_JFYS New_PTJF_JfysModel = new Model.SZPX_JFYS();
                    New_PTJF_JfysModel.XMBH = xmbh;
                    New_PTJF_JfysModel.JFLX = "PTJF";
                    New_PTJF_JfysModel.JFYS = PTJF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.ZXKSSJ = Convert.ToDateTime(PTJF_ZXKSSJ.Text.Trim());
                    New_PTJF_JfysModel.ZXJSSJ = Convert.ToDateTime(PTJF_ZXJSSJ.Text.Trim());

                    New_PTJF_JfysModel.KCJCJZLF_SYSM = PTJF_KCJCJZLF_SYSM.Text.Trim();
                    New_PTJF_JfysModel.KCJCJZLF_JFYS = PTJF_KCJCJZLF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.KCJCJZLF_BZ = PTJF_KCJCJZLF_BZ.Text.Trim();

                    New_PTJF_JfysModel.YQSBJHCF_SYSM = PTJF_YQSBJHCF_SYSM.Text.Trim();
                    New_PTJF_JfysModel.YQSBJHCF_JFYS = PTJF_YQSBJHCF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.YQSBJHCF_BZ = PTJF_YQSBJHCF_BZ.Text.Trim();

                    New_PTJF_JfysModel.WPRYJF_SYSM = PTJF_WPRYJF_SYSM.Text.Trim();
                    New_PTJF_JfysModel.WPRYJF_JFYS = PTJF_WPRYJF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.WPRYJF_BZ = PTJF_WPRYJF_BZ.Text.Trim();

                    New_PTJF_JfysModel.CDF_SYSM = PTJF_CDF_SYSM.Text.Trim();
                    New_PTJF_JfysModel.CDF_JFYS = PTJF_CDF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.CDF_BZ = PTJF_CDF_BZ.Text.Trim();

                    New_PTJF_JfysModel.CYF_SYSM = PTJF_CYF_SYSM.Text.Trim();
                    New_PTJF_JfysModel.CYF_JFYS = PTJF_CYF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.CYF_BZ = PTJF_CYF_BZ.Text.Trim();

                    New_PTJF_JfysModel.ZSF_SYSM = PTJF_ZSF_SYSM.Text.Trim();
                    New_PTJF_JfysModel.ZSF_JFYS = PTJF_ZSF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.ZSF_BZ = PTJF_ZSF_BZ.Text.Trim();

                    New_PTJF_JfysModel.JTF_SYSM = PTJF_JTF_SYSM.Text.Trim();
                    New_PTJF_JfysModel.JTF_JFYS = PTJF_JTF_JFYS.Text.Trim();
                    New_PTJF_JfysModel.JTF_BZ = PTJF_JTF_BZ.Text.Trim();

                    //New_PTJF_JfysModel.JFHJ_SYSM = PTJF_JFHJ_SYSM.Text.Trim();
                    New_PTJF_JfysModel.JFHJ_JFYS = PTJF_JFHJ_JFYS.Text.Trim();
                    //New_PTJF_JfysModel.JFHJ_BZ = PTJF_JFHJ_BZ.Text.Trim();

                    JfysBLL.Add(New_PTJF_JfysModel);
                }
                #endregion


            }




            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step9.Hidden = false;

            PageContext.RegisterStartupScript("a(6);");

        }


        protected void Back_step2_Click(object sender, EventArgs e)
        {
            //s1.Visible = false;
            //s2.Visible = true;
            ContentPanel_step1.Hidden = false;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(1);");
        }
        protected void Back_step3_Click(object sender, EventArgs e)
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = false;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(2);");
        }
        protected void Back_step4_Click(object sender, EventArgs e)
        {
            //div1.InnerHtml = "<script>var str=\"alert('1')\";eval(str);</script>";
            //div1.InnerHtml = "<script>$(document).ready(function(){$('#li4').addClass('current');})</script>";
            //PageContext.RegisterStartupScript("<script src=\"../res/js/jquery.min.js\" type=\"text/javascript\"></script>alert('');");
            //PageContext.RegisterStartupScript("alert($('#li4').attr('id'));");
            //PageContext.RegisterStartupScript("$('#li1').addClass('current');");
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = false;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(3);");
            //Alert.ShowInTop("4");
        }
        protected void Back_step5_Click(object sender, EventArgs e)
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = false;
            SimpleForm_step5.Hidden = true;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(4);");

        }
        protected void Back_step6_Click(object sender, EventArgs e)
        {
            ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step3.Hidden = true;
            SimpleForm_step4.Hidden = true;
            SimpleForm_step5.Hidden = false;
            SimpleForm_step9.Hidden = true;

            PageContext.RegisterStartupScript("a(5);");

        }

        protected void btnUpload_Click(object sender, EventArgs e)
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

                        FileUpload1.SaveAs(Server.MapPath("upload/师资培训_附件/" + fileName));
                        ViewState["uploadfile1"] = fileName;
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

        //protected void KCJCJZLF_add_Click(object sender, EventArgs e)
        //{
        //    string KCJCJZLF_JD_value = KCJCJZLF_JD.Text.Trim();
        //    string KCJCJZLF_KCJCZLMC_value = KCJCJZLF_KCJCZLMC.Text.Trim();
        //    string KCJCJZLF_YSJF_value = KCJCJZLF_YSJF.Text.Trim();
        //    string KCJCJZLF_BZ_value = KCJCJZLF_BZ.Text.Trim();


        //    #region Check
        //    if (string.IsNullOrWhiteSpace(KCJCJZLF_JD_value))
        //    {
        //        Alert.ShowInTop("请选择季度");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(KCJCJZLF_KCJCZLMC_value))
        //    {
        //        Alert.ShowInTop("请填写课程/教材/资料名称");
        //        return;
        //    }
        //    if (KCJCJZLF_KCJCZLMC_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的课程/教材/资料名称过长，请重新填写");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(KCJCJZLF_YSJF_value))
        //    {
        //        Alert.ShowInTop("请填写预算经费");
        //        return;
        //    }
        //    if (KCJCJZLF_YSJF_value.Length >= 50)
        //    {
        //        Alert.ShowInTop("预算经费过长，请重新填写");
        //        return;
        //    }
        //    #endregion


        //    #region AddList
        //    if (ViewState["FJYSMX_KCJCJZLF_list"] == null)
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UID");
        //        dt.Columns.Add("KCJCJZLF_JD");
        //        dt.Columns.Add("KCJCJZLF_KCJCZLMC");
        //        dt.Columns.Add("KCJCJZLF_YSJF");
        //        dt.Columns.Add("KCJCJZLF_BZ");

        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["KCJCJZLF_JD"] = KCJCJZLF_JD_value;
        //        dr["KCJCJZLF_KCJCZLMC"] = KCJCJZLF_KCJCZLMC_value;
        //        dr["KCJCJZLF_YSJF"] = KCJCJZLF_YSJF_value;
        //        dr["KCJCJZLF_BZ"] = KCJCJZLF_BZ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_KCJCJZLF_list"] = dt;
        //    }
        //    else
        //    {
        //        var dt = ViewState["FJYSMX_KCJCJZLF_list"] as DataTable;
        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["KCJCJZLF_JD"] = KCJCJZLF_JD_value;
        //        dr["KCJCJZLF_KCJCZLMC"] = KCJCJZLF_KCJCZLMC_value;
        //        dr["KCJCJZLF_YSJF"] = KCJCJZLF_YSJF_value;
        //        dr["KCJCJZLF_BZ"] = KCJCJZLF_BZ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_KCJCJZLF_list"] = dt;
        //    }
        //    KCJCJZLF_List_Grid.DataSource = ViewState["FJYSMX_KCJCJZLF_list"] as DataTable;
        //    KCJCJZLF_List_Grid.DataBind();
        //    #endregion

        //}
        //protected void KCJCJZLF_delete_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = KCJCJZLF_List_Grid.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = KCJCJZLF_List_Grid.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (KCJCJZLF_List_Grid.AllowPaging && !KCJCJZLF_List_Grid.IsDatabasePaging)
        //            {
        //                rowIndex = KCJCJZLF_List_Grid.PageIndex * KCJCJZLF_List_Grid.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += KCJCJZLF_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["FJYSMX_KCJCJZLF_list"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["FJYSMX_KCJCJZLF_list"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    dt.Rows.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            KCJCJZLF_List_Grid.DataSource = dt;
        //            KCJCJZLF_List_Grid.DataBind();
        //            ViewState["FJYSMX_KCJCJZLF_list"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        KCJCJZLF_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}



        //protected void YQSBJHCF_add_Click(object sender, EventArgs e)
        //{
        //    string YQSBJHCF_JD_value = YQSBJHCF_JD.Text.Trim();
        //    string YQSBJHCF_CPMC_value = YQSBJHCF_CPMC.Text.Trim();
        //    string YQSBJHCF_GGXH_value = YQSBJHCF_GGXH.Text.Trim();
        //    string YQSBJHCF_SL_value = YQSBJHCF_SL.Text.Trim();
        //    string YQSBJHCF_DW_value = YQSBJHCF_DW.Text.Trim();
        //    string YQSBJHCF_DJ_value = YQSBJHCF_DJ.Text.Trim();
        //    string YQSBJHCF_HJ_value = YQSBJHCF_HJ.Text.Trim();



        //    #region Check
        //    if (string.IsNullOrWhiteSpace(YQSBJHCF_JD_value))
        //    {
        //        Alert.ShowInTop("请选择季度");
        //        return;
        //    }

        //    if (string.IsNullOrWhiteSpace(YQSBJHCF_CPMC_value))
        //    {
        //        Alert.ShowInTop("请填写产品名称");
        //        return;
        //    }
        //    if (YQSBJHCF_CPMC_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的产品名称过长，请重新填写");
        //        return;
        //    }


        //    if (string.IsNullOrWhiteSpace(YQSBJHCF_GGXH_value))
        //    {
        //        Alert.ShowInTop("请填写规格型号");
        //        return;
        //    }
        //    if (YQSBJHCF_GGXH_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的规格型号过长，请重新填写");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(YQSBJHCF_SL_value))
        //    {
        //        Alert.ShowInTop("请填写数量");
        //        return;

        //    }
        //    if (string.IsNullOrWhiteSpace(YQSBJHCF_DW_value))
        //    {
        //        Alert.ShowInTop("请填写单位");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(YQSBJHCF_DJ_value))
        //    {
        //        Alert.ShowInTop("请填写单价");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(YQSBJHCF_HJ_value))
        //    {
        //        Alert.ShowInTop("请填写合计");
        //        return;
        //    }

        //    #endregion


        //    #region AddList
        //    if (ViewState["FJYSMX_YQSBJHCF_list"] == null)
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UID");
        //        dt.Columns.Add("YQSBJHCF_JD");
        //        dt.Columns.Add("YQSBJHCF_CPMC");
        //        dt.Columns.Add("YQSBJHCF_GGXH");
        //        dt.Columns.Add("YQSBJHCF_SL");
        //        dt.Columns.Add("YQSBJHCF_DW");
        //        dt.Columns.Add("YQSBJHCF_DJ");
        //        dt.Columns.Add("YQSBJHCF_HJ");


        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["YQSBJHCF_JD"] = YQSBJHCF_JD_value;
        //        dr["YQSBJHCF_CPMC"] = YQSBJHCF_CPMC_value;
        //        dr["YQSBJHCF_GGXH"] = YQSBJHCF_GGXH_value;
        //        dr["YQSBJHCF_SL"] = YQSBJHCF_SL_value;
        //        dr["YQSBJHCF_DW"] = YQSBJHCF_DW_value;
        //        dr["YQSBJHCF_DJ"] = YQSBJHCF_DJ_value;
        //        dr["YQSBJHCF_HJ"] = YQSBJHCF_HJ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_YQSBJHCF_list"] = dt;
        //    }
        //    else
        //    {
        //        var dt = ViewState["FJYSMX_YQSBJHCF_list"] as DataTable;
        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["YQSBJHCF_JD"] = YQSBJHCF_JD_value;
        //        dr["YQSBJHCF_CPMC"] = YQSBJHCF_CPMC_value;
        //        dr["YQSBJHCF_GGXH"] = YQSBJHCF_GGXH_value;
        //        dr["YQSBJHCF_SL"] = YQSBJHCF_SL_value;
        //        dr["YQSBJHCF_DW"] = YQSBJHCF_DW_value;
        //        dr["YQSBJHCF_DJ"] = YQSBJHCF_DJ_value;
        //        dr["YQSBJHCF_HJ"] = YQSBJHCF_HJ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_YQSBJHCF_list"] = dt;
        //    }
        //    YQSBJHCF_List_Grid.DataSource = ViewState["FJYSMX_YQSBJHCF_list"] as DataTable;
        //    YQSBJHCF_List_Grid.DataBind();
        //    #endregion
        //}
        //protected void YQSBJHCF_delete_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = YQSBJHCF_List_Grid.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = YQSBJHCF_List_Grid.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (YQSBJHCF_List_Grid.AllowPaging && !YQSBJHCF_List_Grid.IsDatabasePaging)
        //            {
        //                rowIndex = YQSBJHCF_List_Grid.PageIndex * YQSBJHCF_List_Grid.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += YQSBJHCF_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["FJYSMX_YQSBJHCF_list"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["FJYSMX_YQSBJHCF_list"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    dt.Rows.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            YQSBJHCF_List_Grid.DataSource = dt;
        //            YQSBJHCF_List_Grid.DataBind();
        //            ViewState["FJYSMX_YQSBJHCF_list"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        YQSBJHCF_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}



        //protected void WPRYJF_add_Click(object sender, EventArgs e)
        //{
        //    string WPRYJF_JD_value = WPRYJF_JD.Text.Trim();
        //    string WPRYJF_XMMC_value = WPRYJF_XMMC.Text.Trim();
        //    string WPRYJF_WPRS_value = WPRYJF_WPRS.Text.Trim();
        //    string WPRYJF_YSJF_value = WPRYJF_YSJF.Text.Trim();
        //    string WPRYJF_BZ_value = WPRYJF_BZ.Text.Trim();



        //    #region Check
        //    if (string.IsNullOrWhiteSpace(WPRYJF_JD_value))
        //    {
        //        Alert.ShowInTop("请选择季度");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(WPRYJF_XMMC_value))
        //    {
        //        Alert.ShowInTop("请填写项目名称");
        //        return;
        //    }
        //    if (WPRYJF_XMMC_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的项目名称过长，请重新填写");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(WPRYJF_WPRS_value))
        //    {
        //        Alert.ShowInTop("请填写外聘人数");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(WPRYJF_YSJF_value))
        //    {
        //        Alert.ShowInTop("请填写预算经费");
        //        return;
        //    }



        //    #endregion

        //    #region AddList
        //    if (ViewState["FJYSMX_WPRYJF_list"] == null)
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UID");
        //        dt.Columns.Add("WPRYJF_JD");
        //        dt.Columns.Add("WPRYJF_XMMC");
        //        dt.Columns.Add("WPRYJF_WPRS");
        //        dt.Columns.Add("WPRYJF_YSJF");
        //        dt.Columns.Add("WPRYJF_BZ");

        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["WPRYJF_JD"] = WPRYJF_JD_value;
        //        dr["WPRYJF_XMMC"] = WPRYJF_XMMC_value;
        //        dr["WPRYJF_WPRS"] = WPRYJF_WPRS_value;
        //        dr["WPRYJF_YSJF"] = WPRYJF_YSJF_value;
        //        dr["WPRYJF_BZ"] = WPRYJF_BZ_value;


        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_WPRYJF_list"] = dt;
        //    }
        //    else
        //    {
        //        var dt = ViewState["FJYSMX_WPRYJF_list"] as DataTable;
        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["WPRYJF_JD"] = WPRYJF_JD_value;
        //        dr["WPRYJF_XMMC"] = WPRYJF_XMMC_value;
        //        dr["WPRYJF_WPRS"] = WPRYJF_WPRS_value;
        //        dr["WPRYJF_YSJF"] = WPRYJF_YSJF_value;
        //        dr["WPRYJF_BZ"] = WPRYJF_BZ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_WPRYJF_list"] = dt;
        //    }
        //    WPRYJF_List_Grid.DataSource = ViewState["FJYSMX_WPRYJF_list"] as DataTable;
        //    WPRYJF_List_Grid.DataBind();
        //    #endregion

        //}
        //protected void WPRYJF_delete_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = WPRYJF_List_Grid.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = WPRYJF_List_Grid.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (WPRYJF_List_Grid.AllowPaging && !WPRYJF_List_Grid.IsDatabasePaging)
        //            {
        //                rowIndex = WPRYJF_List_Grid.PageIndex * WPRYJF_List_Grid.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += WPRYJF_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["FJYSMX_WPRYJF_list"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["FJYSMX_WPRYJF_list"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    dt.Rows.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            WPRYJF_List_Grid.DataSource = dt;
        //            WPRYJF_List_Grid.DataBind();
        //            ViewState["FJYSMX_WPRYJF_list"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        WPRYJF_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}



        //protected void CDF_add_Click(object sender, EventArgs e)
        //{
        //    string CDF_JD_value = CDF_JD.Text.Trim();
        //    string CDF_CDMC_value = CDF_CDMC.Text.Trim();
        //    string CDF_YSJF_value = CDF_YSJF.Text.Trim();
        //    string CDF_BZ_value = CDF_BZ.Text.Trim();



        //    #region Check
        //    if (string.IsNullOrWhiteSpace(CDF_JD_value))
        //    {
        //        Alert.ShowInTop("请选择季度");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(CDF_CDMC_value))
        //    {
        //        Alert.ShowInTop("请填写场地名称");
        //        return;
        //    }
        //    if (CDF_CDMC_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的场地名称过长，请重新填写");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(CDF_YSJF_value))
        //    {
        //        Alert.ShowInTop("请填写预算经费");
        //        return;
        //    }




        //    #endregion



        //    #region AddList
        //    if (ViewState["FJYSMX_CDF_list"] == null)
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UID");
        //        dt.Columns.Add("CDF_JD");
        //        dt.Columns.Add("CDF_CDMC");
        //        dt.Columns.Add("CDF_YSJF");
        //        dt.Columns.Add("CDF_BZ");


        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["CDF_JD"] = CDF_JD_value;
        //        dr["CDF_CDMC"] = CDF_CDMC_value;
        //        dr["CDF_YSJF"] = CDF_YSJF_value;
        //        dr["CDF_BZ"] = CDF_BZ_value;



        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_CDF_list"] = dt;
        //    }
        //    else
        //    {
        //        var dt = ViewState["FJYSMX_CDF_list"] as DataTable;
        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["CDF_JD"] = CDF_JD_value;
        //        dr["CDF_CDMC"] = CDF_CDMC_value;
        //        dr["CDF_YSJF"] = CDF_YSJF_value;
        //        dr["CDF_BZ"] = CDF_BZ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_CDF_list"] = dt;
        //    }
        //    CDF_List_Grid.DataSource = ViewState["FJYSMX_CDF_list"] as DataTable;
        //    CDF_List_Grid.DataBind();
        //    #endregion

        //}
        //protected void CDF_delete_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = CDF_List_Grid.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = CDF_List_Grid.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (CDF_List_Grid.AllowPaging && !CDF_List_Grid.IsDatabasePaging)
        //            {
        //                rowIndex = CDF_List_Grid.PageIndex * CDF_List_Grid.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += CDF_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["FJYSMX_CDF_list"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["FJYSMX_CDF_list"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    dt.Rows.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            CDF_List_Grid.DataSource = dt;
        //            CDF_List_Grid.DataBind();
        //            ViewState["FJYSMX_CDF_list"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        CDF_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}



        //protected void CYF_add_Click(object sender, EventArgs e)
        //{
        //    string CYF_JD_value = CYF_JD.Text.Trim();
        //    string CYF_XMMC_value = CYF_XMMC.Text.Trim();
        //    string CYF_YSJF_value = CYF_YSJF.Text.Trim();
        //    string CYF_BZ_value = CYF_BZ.Text.Trim();

        //    #region Check
        //    if (string.IsNullOrWhiteSpace(CYF_JD_value))
        //    {
        //        Alert.ShowInTop("请选择季度");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(CYF_XMMC_value))
        //    {
        //        Alert.ShowInTop("请填写项目名称");
        //        return;
        //    }
        //    if (CYF_XMMC_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的项目名称过长，请重新填写");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(CYF_YSJF_value))
        //    {
        //        Alert.ShowInTop("请填写预算经费");
        //        return;
        //    }




        //    #endregion


        //    #region AddList
        //    if (ViewState["FJYSMX_CYF_list"] == null)
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UID");
        //        dt.Columns.Add("CYF_JD");
        //        dt.Columns.Add("CYF_XMMC");
        //        dt.Columns.Add("CYF_YSJF");
        //        dt.Columns.Add("CYF_BZ");


        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["CYF_JD"] = CYF_JD_value;
        //        dr["CYF_XMMC"] = CYF_XMMC_value;
        //        dr["CYF_YSJF"] = CYF_YSJF_value;
        //        dr["CYF_BZ"] = CYF_BZ_value;



        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_CYF_list"] = dt;
        //    }
        //    else
        //    {
        //        var dt = ViewState["FJYSMX_CYF_list"] as DataTable;
        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["CYF_JD"] = CYF_JD_value;
        //        dr["CYF_XMMC"] = CYF_XMMC_value;
        //        dr["CYF_YSJF"] = CYF_YSJF_value;
        //        dr["CYF_BZ"] = CYF_BZ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_CYF_list"] = dt;
        //    }
        //    CYF_List_Grid.DataSource = ViewState["FJYSMX_CYF_list"] as DataTable;
        //    CYF_List_Grid.DataBind();
        //    #endregion
        //}
        //protected void CYF_delete_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = CYF_List_Grid.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = CYF_List_Grid.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (CYF_List_Grid.AllowPaging && !CYF_List_Grid.IsDatabasePaging)
        //            {
        //                rowIndex = CYF_List_Grid.PageIndex * CYF_List_Grid.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += CYF_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["FJYSMX_CYF_list"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["FJYSMX_CYF_list"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    dt.Rows.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            CYF_List_Grid.DataSource = dt;
        //            CYF_List_Grid.DataBind();
        //            ViewState["FJYSMX_CYF_list"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        CYF_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}



        //protected void ZSF_add_Click(object sender, EventArgs e)
        //{
        //    string ZSF_JD_value = ZSF_JD.Text.Trim();
        //    string ZSF_XMMC_value = ZSF_XMMC.Text.Trim();
        //    string ZSF_YSJF_value = ZSF_YSJF.Text.Trim();
        //    string ZSF_BZ_value = ZSF_BZ.Text.Trim();

        //    #region Check
        //    if (string.IsNullOrWhiteSpace(ZSF_JD_value))
        //    {
        //        Alert.ShowInTop("请选择季度");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(ZSF_XMMC_value))
        //    {
        //        Alert.ShowInTop("请填写项目名称");
        //        return;
        //    }
        //    if (ZSF_XMMC_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的项目名称过长，请重新填写");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(ZSF_YSJF_value))
        //    {
        //        Alert.ShowInTop("请填写预算经费");
        //        return;
        //    }




        //    #endregion


        //    #region AddList
        //    if (ViewState["FJYSMX_ZSF_list"] == null)
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UID");
        //        dt.Columns.Add("ZSF_JD");
        //        dt.Columns.Add("ZSF_XMMC");
        //        dt.Columns.Add("ZSF_YSJF");
        //        dt.Columns.Add("ZSF_BZ");


        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["ZSF_JD"] = ZSF_JD_value;
        //        dr["ZSF_XMMC"] = ZSF_XMMC_value;
        //        dr["ZSF_YSJF"] = ZSF_YSJF_value;
        //        dr["ZSF_BZ"] = ZSF_BZ_value;



        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_ZSF_list"] = dt;
        //    }
        //    else
        //    {
        //        var dt = ViewState["FJYSMX_ZSF_list"] as DataTable;
        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["ZSF_JD"] = ZSF_JD_value;
        //        dr["ZSF_XMMC"] = ZSF_XMMC_value;
        //        dr["ZSF_YSJF"] = ZSF_YSJF_value;
        //        dr["ZSF_BZ"] = ZSF_BZ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_ZSF_list"] = dt;
        //    }
        //    ZSF_List_Grid.DataSource = ViewState["FJYSMX_ZSF_list"] as DataTable;
        //    ZSF_List_Grid.DataBind();
        //    #endregion
        //}
        //protected void ZSF_delete_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = ZSF_List_Grid.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = ZSF_List_Grid.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (ZSF_List_Grid.AllowPaging && !ZSF_List_Grid.IsDatabasePaging)
        //            {
        //                rowIndex = ZSF_List_Grid.PageIndex * ZSF_List_Grid.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += ZSF_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["FJYSMX_ZSF_list"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["FJYSMX_ZSF_list"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    dt.Rows.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            ZSF_List_Grid.DataSource = dt;
        //            ZSF_List_Grid.DataBind();
        //            ViewState["FJYSMX_ZSF_list"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        ZSF_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}




        //protected void JTF_add_Click(object sender, EventArgs e)
        //{
        //    string JTF_JD_value = JTF_JD.Text.Trim();
        //    string JTF_XMMC_value = JTF_XMMC.Text.Trim();
        //    string JTF_YSJF_value = JTF_YSJF.Text.Trim();
        //    string JTF_BZ_value = JTF_BZ.Text.Trim();

        //    #region Check
        //    if (string.IsNullOrWhiteSpace(JTF_JD_value))
        //    {
        //        Alert.ShowInTop("请选择季度");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(JTF_XMMC_value))
        //    {
        //        Alert.ShowInTop("请填写项目名称");
        //        return;
        //    }
        //    if (JTF_XMMC_value.Length >= 500)
        //    {
        //        Alert.ShowInTop("填写的项目名称过长，请重新填写");
        //        return;
        //    }
        //    if (string.IsNullOrWhiteSpace(JTF_YSJF_value))
        //    {
        //        Alert.ShowInTop("请填写预算经费");
        //        return;
        //    }




        //    #endregion



        //    #region AddList
        //    if (ViewState["FJYSMX_JTF_list"] == null)
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UID");
        //        dt.Columns.Add("JTF_JD");
        //        dt.Columns.Add("JTF_XMMC");
        //        dt.Columns.Add("JTF_YSJF");
        //        dt.Columns.Add("JTF_BZ");


        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["JTF_JD"] = JTF_JD_value;
        //        dr["JTF_XMMC"] = JTF_XMMC_value;
        //        dr["JTF_YSJF"] = JTF_YSJF_value;
        //        dr["JTF_BZ"] = JTF_BZ_value;



        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_JTF_list"] = dt;
        //    }
        //    else
        //    {
        //        var dt = ViewState["FJYSMX_JTF_list"] as DataTable;
        //        DataRow dr = dt.NewRow();
        //        dr["UID"] = Guid.NewGuid().ToString();
        //        dr["JTF_JD"] = JTF_JD_value;
        //        dr["JTF_XMMC"] = JTF_XMMC_value;
        //        dr["JTF_YSJF"] = JTF_YSJF_value;
        //        dr["JTF_BZ"] = JTF_BZ_value;

        //        dt.Rows.Add(dr);
        //        ViewState["FJYSMX_JTF_list"] = dt;
        //    }
        //    JTF_List_Grid.DataSource = ViewState["FJYSMX_JTF_list"] as DataTable;
        //    JTF_List_Grid.DataBind();
        //    #endregion



        //}
        //protected void JTF_delete_Click(object sender, EventArgs e)
        //{
        //    string selectedID = "";
        //    int selectedCount = JTF_List_Grid.SelectedRowIndexArray.Length;
        //    if (selectedCount > 0 && selectedCount < 2)
        //    {
        //        for (int i = 0; i < selectedCount; i++)
        //        {
        //            int rowIndex = JTF_List_Grid.SelectedRowIndexArray[i];
        //            // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
        //            if (JTF_List_Grid.AllowPaging && !JTF_List_Grid.IsDatabasePaging)
        //            {
        //                rowIndex = JTF_List_Grid.PageIndex * JTF_List_Grid.PageSize + rowIndex;//获取翻页后的行号
        //            }
        //            selectedID += JTF_List_Grid.DataKeys[rowIndex][0].ToString() + ",";


        //        }
        //        selectedID = selectedID.TrimEnd(',');//去掉最后一个，号

        //        if (ViewState["FJYSMX_JTF_list"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["FJYSMX_JTF_list"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    dt.Rows.RemoveAt(i);
        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            JTF_List_Grid.DataSource = dt;
        //            JTF_List_Grid.DataBind();
        //            ViewState["FJYSMX_JTF_list"] = dt;
        //        }


        //    }
        //    else
        //    {
        //        Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
        //        JTF_List_Grid.SelectedRowIndexArray = null; // 清空当前选中的项
        //    }
        //}

    }
}