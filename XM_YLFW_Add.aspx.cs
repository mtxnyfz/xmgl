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
    public partial class XM_YLFW_Add : System.Web.UI.Page
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
                }
                sdr.Dispose();
                databind_zymc();
                //databind_DropDownList1();
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

            //Grid1.DataSource = dt;
            //Grid1.DataBind();
        }

        //protected void databind_DropDownList1()
        //{
        //    DropDownList1.Items.Clear();

        //    //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select  xb_dm,xb_mc  FROM xb  order by xb_mc asc").Tables[0];
        //    //DataTable dt = DbHelperSQL.Query("select distinct ID, ZYDM,ZYMC  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "'  order by ZYMC").Tables[0];
        //    //DataTable dt = DbHelperSQL.Query("select distinct  ZYDM,ZYMC  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "'  order by ZYMC").Tables[0];
        //    DataTable dt = DbHelperSQL.Query("SELECT distinct [ZYDM]  ,[ZYMC] ,[ZYFXDM] ,[ZYFXMC]  FROM ZYB1 where XXDM='" + ViewState["xxdm"] + "' and ZYDM is not null  order by ZYMC").Tables[0];

        //    //DataTable dt_new = dt.Copy();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (dt.Rows[i]["ZYFXMC"].ToString().Trim() != "")
        //        {
        //            if (dt.Rows[i]["ZYFXDM"].ToString().Trim() == "")
        //            {
        //                dt.Rows[i]["ZYDM"] = dt.Rows[i]["ZYDM"].ToString().Trim() + "," + "@" + i.ToString();
        //            }
        //            else
        //            {
        //                dt.Rows[i]["ZYDM"] = dt.Rows[i]["ZYDM"].ToString().Trim() + "," + dt.Rows[i]["ZYFXDM"].ToString().Trim();
        //            }
        //            dt.Rows[i]["ZYMC"] = dt.Rows[i]["ZYFXMC"].ToString().Trim();

        //        }

        //    }

        //    DropDownList1.DataSource = dt;
        //    DropDownList1.DataTextField = "ZYMC";
        //    DropDownList1.DataValueField = "ZYDM";
        //    DropDownList1.DataBind();
        //    DropDownList1.Items.Add("请选择", "请选择");

        //    dp_setvalue(DropDownList1, "请选择");

        //    //Grid1.DataSource = dt;
        //    //Grid1.DataBind();
        //}

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

        protected void dp_setvalue1(System.Web.UI.WebControls.DropDownList ddl, string value)
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


        protected void ZYMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zydm1 = "",zyfxdm="";
            try
            {
                if (ZYMC.SelectedValue.Trim().Contains("@"))
                {
                    //zyfxdm = ZYMC.SelectedValue.Trim().Split(',')[0];
                }
                else
                    zyfxdm = ZYMC.SelectedValue.Trim().Split(',')[1];

                zydm1 = ZYMC.SelectedValue.Trim().Split(',')[0];

                //string zydm1 = "";
                string sqlstr = "select *  FROM ZYB1 where ZYDM='" + zydm1 + "' and ZYFXDM='"+zyfxdm+"' and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string m = "", d = "", sj = "";
                string zydtrxm = "";

                if (sdr.Read())
                {
                    zydtrxm = sdr["ZYDTR_XM"].ToString().Trim();
                    sj = sdr["ZYKBSJ"].ToString().Trim();
                    ZYDM.Text = zyfxdm;
                    ViewState["ZYDM"] = sdr["ZYDM"].ToString().Trim();
                    ViewState["ZYMC"] = sdr["ZYMC"].ToString().Trim();
                    if (sdr["ZYFXDM"].ToString().Trim() != "")
                    {
                        ViewState["ZYFXDM"] = sdr["ZYFXDM"].ToString().Trim();
                        ViewState["ZYFXMC"] = sdr["ZYFXMC"].ToString().Trim();
                    }
                    else
                    {
                        ViewState["ZYFXDM"] = sdr["ZYDM"].ToString().Trim();
                        ViewState["ZYFXMC"] = sdr["ZYMC"].ToString().Trim();
                       
                    }
                 
                    if (sj.Length == 6)
                    {
                        try
                        {
                            m = sj.Substring(0, 4);
                            d = sj.Substring(4, 2);
                            sj = Convert.ToDateTime(m + "-" + d).ToString("yyyy-MM");
                            TextBox_zyszsj.Text = sj;
                        }
                        catch (Exception ex)
                        {
                            TextBox_zyszsj.Text = "";
                            Alert.ShowInTop(ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        TextBox_zyszsj.Text = "";
                    }

                    bind_zsyjqk(zydm1, zyfxdm);

                }
                else
                {
                    ZYDM.Text = "";
                  
                }
                sdr.Dispose();


                sqlstr = "select *  FROM SJ_ZYDTR where ZYDTR_ZYDM='" + zydm1 + "' and ZYDTR_XM='" + zydtrxm + "' and ZYDTR_XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string csny = "";
                if (sdr.Read())
                {
                    TextBox1_jsxm.Text = sdr["ZYDTR_XM"].ToString().Trim();
                    dp_setvalue1(DropDownList_xb, sdr["ZYDTR_XBM"].ToString().Trim());
                    csny = sdr["ZYDTR_CSNY"].ToString().Trim();
                    if (csny.Length == 8)
                    {
                        try
                        {
                          string   y = csny.Substring(0, 4);
                           m = csny.Substring(4, 2);
                           d = csny.Substring(6, 2);
                            csny = Convert.ToDateTime(y + "-" + m + "-" + d).ToString("yyyy-MM");
                            //ZYKBSJ.Text = sj;
                        }
                        catch (Exception ex)
                        {
                            //ZYKBSJ.Text = "";
                            //Alert.ShowInTop(ex.Message);
                            //return;
                            csny = "";
                        }
                    }
                    DatePicker_csny.Text = csny;
                    DropDownList_xl.Text = sdr["ZYDTR_XL"].ToString().Trim();
                    DropDownList_xw.Text = sdr["ZYDTR_XW"].ToString().Trim();
                    TextBox_zyjszw.Text = sdr["ZYDTR_ZYJSZWMC1"].ToString().Trim();
                    TextBox_zw.Text = sdr["ZYDTR_ZW"].ToString().Trim();
                    TextBox_lxdh.Text = sdr["ZYDTR_DWDH"].ToString().Trim();
                    TextBox_yx.Text = sdr["ZYDTR_DZYX"].ToString().Trim();

                }
                else
                {
                    TextBox1_jsxm.Text ="";
                    dp_setvalue1(DropDownList_xb, "请选择");
                   
                    DatePicker_csny.Text = "";
                    DropDownList_xl.Text = "";
                    DropDownList_xw.Text = "";
                    TextBox_zyjszw.Text = "";
                    TextBox_zw.Text = "";
                    TextBox_lxdh.Text = "";
                    TextBox_yx.Text = "";
                }
                sdr.Dispose();

            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
                return;
            }
        }




        protected void bind_zsyjqk(string zydm,string zyfxdm)
        {
            //string zydm = ZYDM.Text.Trim();
            //string nf = DropDownList_nf.SelectedValue.Trim();
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
                        dt.Columns.Add("SJZSS");
                        dt.Columns.Add("DNBYSS");
                        dt.Columns.Add("YCXJYL");
                        dt.Columns.Add("JYDKL");
                       

                        DataRow dr = dt.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["nf"] = i.ToString();
                        dr["SJZSS"] = sdr["SJZSS"].ToString().Trim();
                        dr["DNBYSS"] = sdr["BYSRS"].ToString().Trim();
                        dr["YCXJYL"] = sdr["CCJYL"].ToString().Trim();
                        dr["JYDKL"] = sdr["DKL"].ToString().Trim();
                      
                        dt.Rows.Add(dr);
                    }
                    else
                    {



                        DataRow dr = dt.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["nf"] = i.ToString();
                        dr["SJZSS"] = sdr["SJZSS"].ToString().Trim();
                        dr["DNBYSS"] = sdr["BYSRS"].ToString().Trim();
                        dr["YCXJYL"] = sdr["CCJYL"].ToString().Trim();
                        dr["JYDKL"] = sdr["DKL"].ToString().Trim();
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
                        dt.Columns.Add("SJZSS");
                        dt.Columns.Add("DNBYSS");
                        dt.Columns.Add("YCXJYL");
                        dt.Columns.Add("JYDKL");

                        DataRow dr = dt.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["nf"] = i.ToString();
                        dr["SJZSS"] = 0;
                        dr["DNBYSS"] = 0;
                        dr["YCXJYL"] = 0;
                        dr["JYDKL"] = 0;
                       
                        dt.Rows.Add(dr);
                    }
                    else
                    {



                        DataRow dr = dt.NewRow();
                        dr["id"] = Guid.NewGuid().ToString();
                        dr["nf"] = i.ToString();
                        dr["SJZSS"] = 0;                     
                        dr["DNBYSS"] = 0;
                        dr["YCXJYL"] = 0;
                        dr["JYDKL"] = 0;
                      
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            int xh = 1;
            //if (DropDownList1.SelectedValue.Trim() == "请选择")
            //{
            //    Alert.ShowInTop("请选择面向专业");
            //    return;
            //}
            //else
            //{
                if (ViewState["xh"] != null)
                {
                    xh = int.Parse(ViewState["xh"].ToString())+1;
                }
                DataTable dt = null;
                if (ViewState["dt3"] == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("id");
                    dt.Columns.Add("xh");
                    dt.Columns.Add("SXJDMC");
                    dt.Columns.Add("ZYMXZY");
                    dt.Columns.Add("QYMC");
                    dt.Columns.Add("HZXS");
                    dt.Columns.Add("JZMJ");
                    dt.Columns.Add("SBS");
                    dt.Columns.Add("SBZZ");
                    dt.Columns.Add("KSSXXMSL");
                    dt.Columns.Add("NSYQKXN");
                    dt.Columns.Add("NSYQKSH");


                    DataRow dr = dt.NewRow();
                    dr["id"] = Guid.NewGuid().ToString();
                    dr["xh"] =xh;
                    dr["SXJDMC"] = TextBox_sxjdmc.Text.Trim();
                    dr["ZYMXZY"] = TextBox_zymxzy.Text.Trim();
                    dr["QYMC"] = TextBox_qymc.Text.Trim();
                    dr["HZXS"] = TextBox_hzxs.Text.Trim();
                    dr["JZMJ"] = NumberBox_jzmj.Text.Trim();
                    dr["SBS"] = NumberBox_sbs.Text.Trim();
                    dr["SBZZ"] = NumberBox_sbzz.Text.Trim();
                    dr["KSSXXMSL"] = NumberBox_kssxxmsl.Text.Trim();
                    dr["NSYQKXN"] = NumberBox_nsyqkxn.Text.Trim();
                    dr["NSYQKSH"] = NumberBox_nsyqksh.Text.Trim();
                    ViewState["xh"] = xh;

                    dt.Rows.Add(dr);
                }
                else
                {
                    //string nf = DropDownList_nf.SelectedValue.Trim();
                    dt = ViewState["dt3"] as DataTable;
                    DataRow dr = dt.NewRow();
                    dr["id"] = Guid.NewGuid().ToString();
                    dr["xh"] = xh;
                    dr["SXJDMC"] = TextBox_sxjdmc.Text.Trim();
                    dr["ZYMXZY"] = TextBox_zymxzy.Text.Trim();
                    dr["QYMC"] = TextBox_qymc.Text.Trim();
                    dr["HZXS"] = TextBox_hzxs.Text.Trim();
                    dr["JZMJ"] = NumberBox_jzmj.Text.Trim();
                    dr["SBS"] = NumberBox_sbs.Text.Trim();
                    dr["SBZZ"] = NumberBox_sbzz.Text.Trim();
                    dr["KSSXXMSL"] = NumberBox_kssxxmsl.Text.Trim();
                    dr["NSYQKXN"] = NumberBox_nsyqkxn.Text.Trim();
                    dr["NSYQKSH"] = NumberBox_nsyqksh.Text.Trim();
                    ViewState["xh"] = xh;
                    dt.Rows.Add(dr);

                }
                dt = dt_px(dt);
                Grid3.DataSource = dt;
                Grid3.DataBind();
                ViewState["dt3"] = dt;
            //}

            //var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/全国职业院校养老服务类示范专业点.doc");
            //var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + "aa.doc");
            //new BuildWord().BuildWord_YLFW(tmppath, savepath, "2015-002");
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
                    dt = dt_px(dt);
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

        protected DataTable dt_px(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["xh"] = i + 1;
            }
            return dt;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Model.YLFW YLFW_Model = new Model.YLFW();
            Model.YLFW_ZYZSJYQK YLFW_ZYZSJYQK_Model = new Model.YLFW_ZYZSJYQK();
            Model.YLFW_SXJDJBQK YLFW_SXJDJBQK_Model = new Model.YLFW_SXJDJBQK();


            BLL.YLFW YLFW_Bll = new BLL.YLFW();
            BLL.YLFW_ZYZSJYQK ZYZSJYQK_Bll = new BLL.YLFW_ZYZSJYQK();
            BLL.YLFW_SXJDJBQK SXJDJBQK_Bll = new BLL.YLFW_SXJDJBQK();

            if (ZYMC.SelectedValue.Trim() == "请选择")
            {
                Alert.Show("请选择专业名称");
                return;
            }
            YLFW_Model.XMBH = AutoNumber("YLFW_2015-");
            YLFW_Model.XXDM = ViewState["xxdm"].ToString();
            YLFW_Model.ZYDM = ViewState["ZYDM"].ToString();
            YLFW_Model.ZYMC = ViewState["ZYMC"].ToString();
            YLFW_Model.ZYFXDM = ViewState["ZYFXDM"].ToString();
            YLFW_Model.ZYFXMC = ViewState["ZYFXMC"].ToString();


            DataTable dt = null;
           
            DataTable dt3 = null;

            if (ViewState["dt1"] != null)
                dt = ViewState["dt1"] as DataTable;
            else
            {
                Alert.Show("没有填写近三年专业招生就业情况");
                return;
            }
            if (ViewState["dt3"] != null)
                dt3 = ViewState["dt3"] as DataTable;
            else
            {
                Alert.Show("没有填写养老服务实训基地基本情况");
                return;
            }
            try
            {
                YLFW_Model.ZYFX = ZYMC.SelectedText.Trim();
                YLFW_Model.LXR = TextBox_lxr.Text.Trim();
                YLFW_Model.LXDH = TextBox_dh.Text.Trim();
                YLFW_Model.XYNX = decimal.Parse(NumberBox_xynx.Text.Trim());
                YLFW_Model.ZYSZSJ = TextBox_zyszsj.Text.Trim();
                YLFW_Model.SJBYSSJ = TextBox_sjbysj.Text.Trim();
                YLFW_Model.ZYZXSS = int.Parse(zyzxss.Text.Trim());
                YLFW_Model.ZYDTRXM = TextBox1_jsxm.Text.Trim();
                YLFW_Model.ZYDTRXB = DropDownList_xb.SelectedItem.Text;
                YLFW_Model.ZYDTRCSNY = DatePicker_csny.Text.Trim();
                YLFW_Model.ZYDTRZGXL = DropDownList_xl.Text.Trim();
                YLFW_Model.ZYDTRXW = DropDownList_xw.Text.Trim();
                YLFW_Model.ZYDTRZYJSZW = TextBox_zyjszw.Text.Trim();
                YLFW_Model.ZYDTRZW = TextBox_zw.Text.Trim();
                YLFW_Model.ZYDTRCSZY = TextBox_cszy.Text.Trim();
                YLFW_Model.ZYDTRLXDH = TextBox_lxdh.Text.Trim();
                YLFW_Model.ZYDTRYX = TextBox_yx.Text.Trim();
                YLFW_Model.JSTDZRJSS = int.Parse(NumberBox_zrjszs.Text.Trim());
                YLFW_Model.ZRJSGJZCRS = int.Parse(NumberBox_gjzc.Text.Trim());
                YLFW_Model.ZRJSGJZCRSBL = decimal.Parse(NumberBox_gjzcbl.Text.Trim());
                YLFW_Model.ZRJSSSXJSRS = int.Parse(NumberBox_ssx.Text.Trim());
                YLFW_Model.ZRJSSSXJSRSBL = decimal.Parse(NumberBox_ssxbl.Text.Trim());
                YLFW_Model.JSTDJZJSS = int.Parse(NumberBox_jzjszrs.Text.Trim());
                YLFW_Model.JZJSGJZCRS = int.Parse(NumberBox_jzjsgjzc.Text.Trim());
                YLFW_Model.JZJSCDKSBL = decimal.Parse(NumberBox_cdksbl.Text.Trim());

                YLFW_Model.ZYDSFZYQK = TextArea_zydsfzyqk.Text.Trim();
                YLFW_Model.ZYDJJ = TextArea_zydjj.Text.Trim();
                YLFW_Model.ZYJSQK = TextArea_zyjsqk.Text.Trim();
                YLFW_Model.XQHZQK = TextArea_xqhzqk.Text.Trim();
                YLFW_Model.RCPYQK = TextArea_rcpyqk.Text.Trim();
                YLFW_Model.XYBZYJSGH = TextArea_xybjsgh.Text.Trim();
                YLFW_Model.SXJDJSJYXQK = TextArea_SXJDJSJYXQK.Text.Trim();



            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
                return;
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                YLFW_ZYZSJYQK_Model.XXDM = ViewState["xxdm"].ToString();
                YLFW_ZYZSJYQK_Model.XMBH = YLFW_Model.XMBH;
                YLFW_ZYZSJYQK_Model.ZYDM = YLFW_Model.ZYDM;
                YLFW_ZYZSJYQK_Model.ZYMC = ZYMC.SelectedText.Trim();
                YLFW_ZYZSJYQK_Model.NF = dt.Rows[i]["nf"].ToString().Trim();
                YLFW_ZYZSJYQK_Model.SJZSS = Convert.ToInt32(dt.Rows[i]["SJZSS"].ToString().Trim());
                //YLFW_ZYZSJYQK_Model.DNBYSS = Convert.ToDecimal(dt.Rows[i]["DNBYSS"].ToString().Trim());
                YLFW_ZYZSJYQK_Model.DNBYSS = Convert.ToInt32(dt.Rows[i]["DNBYSS"].ToString().Trim());
                YLFW_ZYZSJYQK_Model.YCXJYL = Convert.ToDecimal(dt.Rows[i]["YCXJYL"].ToString().Trim());
                YLFW_ZYZSJYQK_Model.JYDKL = Convert.ToDecimal(dt.Rows[i]["JYDKL"].ToString().Trim());
                ZYZSJYQK_Bll.Add(YLFW_ZYZSJYQK_Model);
            }

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                YLFW_SXJDJBQK_Model.XMBH = YLFW_Model.XMBH;
                YLFW_SXJDJBQK_Model.XH = Convert.ToInt32(dt3.Rows[i]["xh"].ToString().Trim());
                YLFW_SXJDJBQK_Model.SXJDMC = dt3.Rows[i]["SXJDMC"].ToString();
                YLFW_SXJDJBQK_Model.ZYMXZY = dt3.Rows[i]["ZYMXZY"].ToString();
                YLFW_SXJDJBQK_Model.QYMC = dt3.Rows[i]["QYMC"].ToString();
                YLFW_SXJDJBQK_Model.HZXS = dt3.Rows[i]["HZXS"].ToString();
                YLFW_SXJDJBQK_Model.JZMJ = Convert.ToDecimal(dt3.Rows[i]["JZMJ"].ToString().Trim());
                YLFW_SXJDJBQK_Model.SBS = Convert.ToInt32(dt3.Rows[i]["SBS"].ToString().Trim());
                YLFW_SXJDJBQK_Model.SBZZ = Convert.ToDecimal(dt3.Rows[i]["SBZZ"].ToString().Trim());
                YLFW_SXJDJBQK_Model.KSSXXMSL = Convert.ToInt32(dt3.Rows[i]["KSSXXMSL"].ToString().Trim());
                YLFW_SXJDJBQK_Model.NSYQKXN = Convert.ToInt32(dt3.Rows[i]["NSYQKXN"].ToString().Trim());
                YLFW_SXJDJBQK_Model.NSYQKSH = Convert.ToInt32(dt3.Rows[i]["NSYQKSH"].ToString().Trim());
                SXJDJBQK_Bll.Add(YLFW_SXJDJBQK_Model);

            }


            YLFW_Model.ZT = 1;
            YLFW_Model.user_uid = pb.GetIdentityId();
            YLFW_Model.SFSC = 0;
            YLFW_Model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");

            if (YLFW_Bll.Add(YLFW_Model) > 0)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"] + ".doc";
                var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/全国职业院校养老服务类示范专业点.doc");
                var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

                if (new BuildWord().BuildWord_YLFW(tmppath, savepath, YLFW_Model.XMBH))
                {
                    BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                    Model.XMSBSWD model = new Model.XMSBSWD();
                    model.XMBH = YLFW_Model.XMBH;
                    model.XMMC = YLFW_Model.XMMC;
                    model.WDLJ = savepath;
                    wordBll.Add(model);
                }
                //Alert.Show("保存成功，请手动关闭该页面");
                PageContext.RegisterStartupScript("alert('已成功保存,系统将自动关闭此页面');CloseWebPage();");
            }

        }

        private string AutoNumber(string seed)
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM   YLFW  WHERE   (XMBH LIKE '" + seed.Trim() + "%') ORDER BY XMBH DESC";
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

        protected void NumberBox_gjzc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string zrjszs = NumberBox_zrjszs.Text.Trim() == "" ? "0" : NumberBox_zrjszs.Text.ToString().Trim();
                string gjzc = NumberBox_gjzc.Text.Trim() == "" ? "0" : NumberBox_gjzc.Text.ToString().Trim();
                double bl = float.Parse(gjzc)*100.00 / float.Parse(zrjszs);
                NumberBox_gjzcbl.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {
               
                //Alert.Show("计算错误：" + ex.Message);
            }
        }

        protected void NumberBox_ssx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string zrjszs = NumberBox_zrjszs.Text.Trim() == "" ? "0" : NumberBox_zrjszs.Text.ToString().Trim();
                string ssx = NumberBox_ssx.Text.Trim() == "" ? "0" : NumberBox_ssx.Text.ToString().Trim();
                double bl = float.Parse(ssx) * 100.00 / float.Parse(zrjszs);
                NumberBox_ssxbl.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {

                //Alert.Show("计算错误：" + ex.Message);
            }
        }

        protected void NumberBox_zrjszs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string zrjszs = NumberBox_zrjszs.Text.Trim() == "" ? "0" : NumberBox_zrjszs.Text.ToString().Trim();
                string gjzc = NumberBox_gjzc.Text.Trim() == "" ? "0" : NumberBox_gjzc.Text.ToString().Trim();
                double bl = float.Parse(gjzc) * 100.00 / float.Parse(zrjszs);
                NumberBox_gjzcbl.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {

                //Alert.Show("计算错误：" + ex.Message);
            }




            try
            {
                string zrjszs = NumberBox_zrjszs.Text.Trim() == "" ? "0" : NumberBox_zrjszs.Text.ToString().Trim();
                string ssx = NumberBox_ssx.Text.Trim() == "" ? "0" : NumberBox_ssx.Text.ToString().Trim();
                double bl = float.Parse(ssx) * 100.00 / float.Parse(zrjszs);
                NumberBox_ssxbl.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {

                //Alert.Show("计算错误：" + ex.Message);
            }
        }
    }
}