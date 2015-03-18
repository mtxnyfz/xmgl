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
    public partial class XMGL_MZWHCC : System.Web.UI.Page
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
                sqlstr = "select * from XXJBQKB where XXDM='" + xxdm + "'";
                sdr = DbHelperSQL.ExecuteReader(sqlstr);

                if (sdr.Read())
                {
                    TextBox_xxmc1.Text = xxmc;
                    TextBox_xxmc1.Enabled = false;
                    TextBox_lxr.Text = sdr["LXRXM"].ToString().Trim();
                    TextBox_lxr.Enabled = false;
                    TextBox_lxdh1.Text = sdr["LXRSJ"].ToString().Trim();
                    TextBox_lxdh1.Enabled = false;
                }
                sdr.Dispose();
                //TextBox_xxmc.Text = xxmc;
                databind_zymc();
                databind_whycxm1();
                databind_ywccr1();
                databind_xb1();
                databind_zsjb1();


                TextBox_zydm1.Enabled = false;
                TextBox_zyfx1.Enabled = false;
                TextBox_ZYMCFX1.Enabled = false;
                TextBox_ZYDM2.Enabled = false;
                ZYSZSJ1.Enabled = false;
                ZYDT_XM1.Enabled = false;
                ZYDT_CSNY1.Enabled = false;
                ZYFZR_ZGXL1.Enabled = false;
                ZYFZR_XW1.Enabled = false;
                ZYDTR_ZYJSZW2.Enabled = false;
                ZYDTR_ZW1.Enabled = false;
                ZYDTR_LXDH1.Enabled = false;
                ZYDTR_YX1.Enabled = false;
                NUM_ZYZSRS1.Enabled = false;
                NUM_ZYZXSS1.Enabled = false;
                ZYDT_XB1.Enabled = false;
                JS_GJZCBL1.Enabled = false;
                ZYFZR_ZYZGZS1.Enabled = false;


                CCR_XM1.Enabled = false;
                CCR_XB1.Enabled = false;
                JS_GJZCBL2.Enabled = false;
                JS_FWZYCMC1.Enabled = false;
                CCR_ZSJB1.Enabled = false;
                ZYFZR_ZSHDRQ1.Enabled = false;
            }
        }



        protected void databind_zymc()
        {
            DROP_zymc1.Items.Clear();

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

            DROP_zymc1.DataSource = dt;
            DROP_zymc1.DataTextField = "ZYMC";
            DROP_zymc1.DataValueField = "ZYDM";
            DROP_zymc1.DataBind();
            DROP_zymc1.Items.Add("请选择", "请选择");

            dp_setvalue(DROP_zymc1, "请选择");

            //Grid1.DataSource = dt;
            //Grid1.DataBind();
        }

        protected void databind_whycxm1()
        {
            DROP_WHYCXM1.Items.Clear();
            DROP_WHYCXM1.Items.Add( "请选择", "请选择" );
            DROP_WHYCXM1.Items.Add( "国家级", "国家级" );
            DROP_WHYCXM1.Items.Add( "省级", "省级" );
            DROP_WHYCXM1.Items.Add( "无", "无" );
            dp_setvalue(DROP_WHYCXM1, "请选择");
        }

        protected void databind_ywccr1()
        {
            ZYDT_YWCCR1.Items.Clear();
            ZYDT_YWCCR1.Items.Add( "请选择", "请选择" );
            ZYDT_YWCCR1.Items.Add( "有", "有" );
            ZYDT_YWCCR1.Items.Add( "无", "无" );
            dp_setvalue(ZYDT_YWCCR1, "请选择");
        }

        protected void databind_xb1()
        {
            ZYDT_XB1.Items.Clear();
            ZYDT_XB1.Items.Add( "请选择", "请选择" );
            ZYDT_XB1.Items.Add( "男", "男" );
            ZYDT_XB1.Items.Add( "女", "女" );
            dp_setvalue(ZYDT_XB1, "请选择");
            CCR_XB1.Items.Clear();
            CCR_XB1.Items.Add( "请选择", "请选择" );
            CCR_XB1.Items.Add( "男", "男" );
            CCR_XB1.Items.Add( "女", "女" );
            dp_setvalue(CCR_XB1, "请选择");
        }

        protected void databind_zsjb1()
        {
            CCR_ZSJB1.Items.Clear();
            CCR_ZSJB1.Items.Add( "请选择", "请选择" );
            CCR_ZSJB1.Items.Add( "国家级", "国家级" );
            CCR_ZSJB1.Items.Add( "省级", "省级" );
            CCR_ZSJB1.Items.Add( "其他", "其他" );
            dp_setvalue(CCR_ZSJB1, "请选择");

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

        protected void Button4_Click(object sender, EventArgs e)
        {




            if (DROP_zymc1.SelectedText.Trim() == "请选择")
            {
                Alert.Show("专业为必选项");
                return;
            }
            if (DROP_WHYCXM1.SelectedItem.Text.Trim() == "请选择")
            {
                Alert.Show("该专业所对应非物质文化遗产项目为必选项");
                return;
            }
            if (ZYDT_XB1.SelectedItem.Text.Trim() == "请选择")
            {
                Alert.Show("专业带头人性别为必选项");
                return;
            }
            if (ZYDT_YWCCR1.SelectedItem.Text.Trim() == "请选择")
            {
                Alert.Show("有无非物质文化遗产传承人为必选项");
                return;
            }
            if ( ZYDT_YWCCR1.SelectedItem.Text.Trim() == "有" )
            {
                if ( CCR_XB1.SelectedItem.Text.Trim() == "请选择" )
                {
                    Alert.Show( "非物质文化遗产传承人性别为必选项" );
                    return;
                }
                if ( CCR_ZSJB1.SelectedItem.Text.Trim() == "请选择" )
                {
                    Alert.Show( "非物质文化遗产传承项目证书级别为必选项" );
                    return;
                }
                if ( CCR_XM1.Text.Trim() == "" )
                {
                    Alert.Show( "非物质文化遗产传承人姓名为必填项" );
                    return;
                }
                if ( JS_GJZCBL2.Text.Trim() == "" )
                {
                    Alert.Show( "非物质文化遗产传承人出生年月为必填项" );
                    return;
                }
                if ( JS_FWZYCMC1.Text.Trim() == "" )
                {
                    Alert.Show( "非物质文化遗产传承项目名称为必填项" );
                    return;
                }
                if ( ZYFZR_ZSHDRQ1.Text.Trim() == "" )
                {
                    Alert.Show( "非物质文化遗产传承项目证书获得日期为必填项" );
                    return;
                }
            }




            //Model.YLZY YLZY_Model = new Model.YLZY();
            Model.WHCC WHCC_Model = new Model.WHCC();
            BLL.WHCC WHCC_Bll = new BLL.WHCC();
            WHCC_Model.XMBH = AutoNumber("WHCC_2015-");
            WHCC_Model.XMMC = TextBox_xxmc1.Text.Trim();
            WHCC_Model.XXDM = ViewState["xxdm"].ToString().Trim();
            WHCC_Model.ZYDM = TextBox_zydm1.Text.Trim();
            WHCC_Model.ZYMC = DROP_zymc1.SelectedItem.Text.Trim();
            WHCC_Model.ZYJNFX = TextBox_zyfx1.Text.Trim();
            WHCC_Model.LXR = TextBox_lxr.Text.Trim();
            WHCC_Model.LXDH = TextBox_lxdh1.Text.Trim();
            WHCC_Model.ZYMCFX = TextBox_ZYMCFX1.Text.Trim();
            WHCC_Model.ZYDM2 = TextBox_ZYDM2.Text.Trim();
            WHCC_Model.XYNX = TextBox_XYNX1.Text.Trim();
            WHCC_Model.ZYSZSJ = ZYSZSJ1.Text.Trim();
            WHCC_Model.SJBYSSJ = TextBox_SJBYSSJ1.Text.Trim();
            WHCC_Model.JSNLJBYSS =Convert.ToInt32( NUM_SNBYSZS1.Text.Trim());
            WHCC_Model.ZYZSRS = Convert.ToInt32(NUM_ZYZSRS1.Text.Trim());
            WHCC_Model.ZYZXSS = Convert.ToInt32(NUM_ZYZXSS1.Text.Trim());
            WHCC_Model.WHYCXM = DROP_WHYCXM1.SelectedItem.Text.Trim();
            WHCC_Model.WHYCMC = TextBox_WHYCXMMC1.Text.Trim();
            WHCC_Model.DTR_XM = ZYDT_XM1.Text.Trim();
            WHCC_Model.DTR_XB = ZYDT_XB1.SelectedItem.Text.Trim();
            WHCC_Model.DTR_CSNY = ZYDT_CSNY1.Text.Trim();
            WHCC_Model.DTR_ZHXL = ZYFZR_ZGXL1.Text.Trim();
            WHCC_Model.DTR_XW = ZYFZR_XW1.Text.Trim();
            WHCC_Model.DTR_ZYJSZW = ZYDTR_ZYJSZW2.Text.Trim();
            WHCC_Model.DTR_ZW = ZYDTR_ZW1.Text.Trim();
            WHCC_Model.DTR_LXDH = ZYDTR_LXDH1.Text.Trim();
            WHCC_Model.DTR_YX = ZYDTR_YX1.Text.Trim();
            WHCC_Model.ZRJSZS = Convert.ToInt32(JS_ZRJSZS.Text.Trim());
            WHCC_Model.GJZCRS = Convert.ToInt32(JS_GJZCRS1.Text.Trim());
            WHCC_Model.GJZCBL = JS_GJZCBL1.Text.Trim();
            WHCC_Model.SSRS = Convert.ToInt32(JS_SHXRS1.Text.Trim());
            WHCC_Model.SSBL = ZYFZR_ZYZGZS1.Text.Trim();
            WHCC_Model.JZJSZS = Convert.ToInt32(JS_JZJSZRS1.Text.Trim());
            WHCC_Model.JZJSGJZCRS = Convert.ToInt32(JS_GJZCRS2.Text.Trim());
            WHCC_Model.ZYZKSBL = ZYFZR_ZKSBL1.Text.Trim();
            WHCC_Model.YWWHCCR = ZYDT_YWCCR1.SelectedItem.Text.Trim();
            WHCC_Model.CCR_XM = CCR_XM1.Text.Trim();
            WHCC_Model.CCR_XB = CCR_XB1.SelectedItem.Text.Trim();
            WHCC_Model.CCR_CSNY = JS_GJZCBL2.Text.Trim();
            WHCC_Model.WHYCCCXMMC = JS_FWZYCMC1.Text.Trim();
            WHCC_Model.ZSJB = CCR_ZSJB1.SelectedItem.Text.Trim();
            WHCC_Model.ZSHDRQ = ZYFZR_ZSHDRQ1.Text.Trim();
            WHCC_Model.ZYDSFZYQK = TextArea_ZYDSFZYQK1.Text.Trim();
            WHCC_Model.ZYJJ = TextArea_ZYJJ1.Text.Trim();
            WHCC_Model.ZYJSQK = TextArea_ZYJSQK1.Text.Trim();
            WHCC_Model.RCPYQK = TextArea_RCPYQK1.Text.Trim();
            WHCC_Model.ZYJSGH = TextArea_ZYJSGH1.Text.Trim();
            WHCC_Model.user_uid = pb.GetIdentityId();
            WHCC_Model.ZT = 1;
            WHCC_Model.SFSC = 0;
            WHCC_Bll.Add(WHCC_Model);

            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"] + ".doc";
            var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/附件1： 教育部办公厅 文化部办公厅 国家民委办公厅关于遴选第二批全国职业院校民族文化传承与创新示范专业点的通知.doc");
            var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

            if (new BuildWord().BuildWord_2015ProjectDeclaration_WHCC(tmppath, savepath, WHCC_Model.XMBH))
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                Model.XMSBSWD model = new Model.XMSBSWD();
                model.XMBH = WHCC_Model.XMBH;
                //model.XMMC = WHCC_Model.XMMC;
                model.WDLJ = savepath;
                wordBll.Add(model);
            }


            PageContext.RegisterStartupScript("alert('已成功保存,系统将自动关闭此页面');CloseWebPage();");
        }

        private string AutoNumber(string seed)
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM   WHCC  WHERE   (XMBH LIKE '" + seed.Trim() + "%') ORDER BY XMBH DESC";
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

        protected void DROP_zymc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string zydm1 = DROP_zymc1.SelectedValue.Trim().Split(',')[0];
                string zyfxmc1 = DROP_zymc1.SelectedItem.Text.Trim();
                //string zydm1 = "";
                string sqlstr = "select *  FROM ZYB1 where ZYFXMC='" + zyfxmc1 + "' and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string m = "", d = "", sj = "";

                if (sdr.Read())
                {
                    TextBox_zydm1.Text = sdr["ZYDM"].ToString().Trim();
                    TextBox_zyfx1.Text = sdr["ZYFXMC"].ToString().Trim();
                    TextBox_ZYMCFX1.Text = sdr["ZYFXMC"].ToString().Trim();
                    TextBox_ZYDM2.Text = sdr["ZYDM"].ToString().Trim();
                    sj = sdr [ "ZYKBSJ" ].ToString().Trim();
                    if ( sj.Length == 6 )
                    {
                        try
                        {
                            m = sj.Substring( 0, 4 );
                            d = sj.Substring( 4, 2 );
                            sj = Convert.ToDateTime( m + "-" + d ).ToString( "yyyy-MM" );
                            ZYSZSJ1.Text = sj;
                        }
                        catch ( Exception ex )
                        {
                            ZYSZSJ1.Text = "";
                            Alert.ShowInTop( ex.Message );
                            return;
                        }
                    }
                    else
                    {
                        ZYSZSJ1.Text = "";
                    }
                    ZYDT_XM1.Text = sdr [ "ZYDTR_XM" ].ToString().Trim();
                    string sqlstr_dtr = "select * from SJ_ZYDTR where ZYDTR_XM='" + sdr [ "ZYDTR_XM" ].ToString().Trim() + "' and ZYDTR_ZYDM='" + sdr [ "ZYDM" ].ToString().Trim() + "' and ZYDTR_JLTJSJ1='2014'";
                    SqlDataReader sdr_dtr = DbHelperSQL.ExecuteReader(sqlstr_dtr);
                    if ( sdr_dtr.Read() )
                    {
                        dp_setvalue( ZYDT_XB1, sdr_dtr [ "ZYDTR_XBM" ].ToString().Trim() );
                        sj = sdr_dtr [ "ZYDTR_CSNY" ].ToString().Trim();
                        if ( sj.Length == 8 )
                        {
                            try
                            {
                                m = sj.Substring( 0, 4 );
                                d = sj.Substring( 4, 2 );
                                sj = Convert.ToDateTime( m + "-" + d ).ToString( "yyyy-MM" );
                                ZYDT_CSNY1.Text = sj;
                            }
                            catch ( Exception ex )
                            {
                                ZYDT_CSNY1.Text = "";
                                Alert.ShowInTop( ex.Message );
                                return;
                            }
                        }
                        else
                        {
                            ZYDT_CSNY1.Text = "";
                        }
                        ZYFZR_ZGXL1.Text = sdr_dtr [ "ZYDTR_XL" ].ToString().Trim();
                        ZYFZR_XW1.Text = sdr_dtr [ "ZYDTR_XW" ].ToString().Trim();
                        ZYDTR_ZYJSZW2.Text=sdr_dtr [ "ZYDTR_ZYJSZWMC1" ].ToString().Trim();
                        ZYDTR_ZW1.Text = sdr_dtr [ "ZYDTR_ZW" ].ToString().Trim();
                        ZYDTR_LXDH1.Text = sdr_dtr [ "ZYDTR_DWDH" ].ToString().Trim();
                        ZYDTR_YX1.Text = sdr_dtr [ "ZYDTR_DZYX" ].ToString().Trim();
                    }
                    else
                    {
 
                    }
                    sdr_dtr.Dispose();
                    //ZYDTR_ZYJSZW2.Text = sdr["ZYFZR_ZYJSZW"].ToString().Trim();
                    //ZYDTR_ZYJSZW2.Enabled = false;
                    //ZYDTR_ZW1.Text = sdr["ZYFZR_XZZW"].ToString().Trim();
                    //ZYDTR_ZW1.Enabled = false;
                    //ZYDTR_LXDH1.Text = sdr["ZYFZR_SJ"].ToString().Trim();
                    //ZYDTR_LXDH1.Enabled = false;
                    //ZYDTR_YX1.Text = sdr["ZYFZR_DZYX"].ToString().Trim();
                    //ZYDTR_YX1.Enabled = false;
                }
                else
                {
                    TextBox_zydm1.Text = "";
                    TextBox_zyfx1.Text = "";
                    TextBox_ZYMCFX1.Text = "";
                    TextBox_ZYDM2.Text = "";
                    ZYSZSJ1.Text = "";
                    ZYDT_XM1.Text = "";




                }
                sdr.Dispose();
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
                return;
            }



            try
            {
                string zydm2 = DROP_zymc1.SelectedValue.Trim().Split(',')[0];
                string sqlstr2 = "select *  FROM ZYZSJYQKB where ZYDM='" + zydm2 + "' and XXDM='" + ViewState["xxdm"].ToString().Trim() + "'";
                SqlDataReader sdr2 = DbHelperSQL.ExecuteReader(sqlstr2);


                if (sdr2.Read())
                {

                    NUM_ZYZSRS1.Text = sdr2["SJZSS"].ToString().Trim();
                    NUM_ZYZSRS1.Enabled = false;
                    NUM_ZYZXSS1.Text = sdr2["QRZZXSS"].ToString().Trim();
                    NUM_ZYZXSS1.Enabled = false;
                }
                else
                {
                    NUM_ZYZSRS1.Text = "";
                    NUM_ZYZXSS1.Text = "";
 

                }
                sdr2.Dispose();
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
                return;
            }
        }

        protected void test(object sender, EventArgs e)
        {
            Alert.Show(DROP_zymc1.SelectedIndex.ToString());
        }

        protected void ZYDT_YWCCR1_SelectedIndexChanged ( object sender, EventArgs e )
        {
            if ( ZYDT_YWCCR1.SelectedItem.Text.Trim() == "有" )
            {
                CCR_XM1.Enabled = true;
                CCR_XB1.Enabled = true;
                JS_GJZCBL2.Enabled = true;
                JS_FWZYCMC1.Enabled = true;
                CCR_ZSJB1.Enabled = true;
                ZYFZR_ZSHDRQ1.Enabled = true;


            }
            else
            {
                CCR_XM1.Enabled = false;
                CCR_XB1.Enabled = false;
                JS_GJZCBL2.Enabled = false;
                JS_FWZYCMC1.Enabled = false;
                CCR_ZSJB1.Enabled = false;
                ZYFZR_ZSHDRQ1.Enabled = false;


            }
        }

        protected void JS_ZRJSZS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string zrjszs = JS_ZRJSZS.Text.Trim() == "" ? "0" : JS_ZRJSZS.Text.ToString().Trim();
                string gjzc = JS_GJZCRS1.Text.Trim() == "" ? "0" : JS_GJZCRS1.Text.ToString().Trim();
                double bl = float.Parse(gjzc) * 100.00 / float.Parse(zrjszs);
                JS_GJZCBL1.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {

                //Alert.Show("计算错误：" + ex.Message);
            }



            try
            {
                string zrjszs = JS_ZRJSZS.Text.Trim() == "" ? "0" : JS_ZRJSZS.Text.ToString().Trim();
                string shxjs = JS_SHXRS1.Text.Trim() == "" ? "0" : JS_SHXRS1.Text.ToString().Trim();
                double bl = float.Parse(shxjs) * 100.00 / float.Parse(zrjszs);
                ZYFZR_ZYZGZS1.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {

                //Alert.Show("计算错误：" + ex.Message);
            }


        }

        protected void JS_GJZCRS1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string zrjszs = JS_ZRJSZS.Text.Trim() == "" ? "0" : JS_ZRJSZS.Text.ToString().Trim();
                string gjzc = JS_GJZCRS1.Text.Trim() == "" ? "0" : JS_GJZCRS1.Text.ToString().Trim();
                double bl = float.Parse(gjzc) * 100.00 / float.Parse(zrjszs);
                JS_GJZCBL1.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {

                //Alert.Show("计算错误：" + ex.Message);
            }
        }

        protected void JS_SHXRS1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string zrjszs = JS_ZRJSZS.Text.Trim() == "" ? "0" : JS_ZRJSZS.Text.ToString().Trim();
                string shxjs = JS_SHXRS1.Text.Trim() == "" ? "0" : JS_SHXRS1.Text.ToString().Trim();
                double bl = float.Parse(shxjs) * 100.00 / float.Parse(zrjszs);
                ZYFZR_ZYZGZS1.Text = String.Format("{0:0.00}", bl);



            }
            catch (Exception ex)
            {

                //Alert.Show("计算错误：" + ex.Message);
            }
        }
    }
}