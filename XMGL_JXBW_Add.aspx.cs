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
    public partial class XMGL_JXBW_Add : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        Model.JXBW jxbw_Model = new Model.JXBW();
        BLL.JXBW jxbw_bll = new BLL.JXBW();

        Model.JXBW_XMTDRYXX jxbwxmcy_model = new Model.JXBW_XMTDRYXX();
        BLL.JXBW_XMTDRYXX jxbwxmcy_bll = new BLL.JXBW_XMTDRYXX();



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
                    TextBox_DWMC1.Text = xxmc;
                }
                sdr.Dispose();
                if (Session["sp1"]!=null)
                Session.Remove("sp1");
                if (Session["wd"] != null)
                Session.Remove("wd");
                //生成项目编码
                //ViewState["xmbh"] = AutoNumber("2015-08-");
                //jxbw_Model.XMBH = ViewState["xmbh"].ToString();
                //jxbw_bll.Add(jxbw_Model);
                //sqlstr = "select * from XXJBQKB where XXDM='" + xxdm + "'";
                //sdr = DbHelperSQL.ExecuteReader(sqlstr);
            }
        }
        private string AutoNumber(string seed)
        {
            try
            {
                string sql = "SELECT  TOP (1)   XMBH  FROM  JXBW  WHERE   (XMBH LIKE '" + seed.Trim() + "%')  ORDER BY XMBH DESC";
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
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            grid_smzl_databind();
            grid1_databind();
            //grid2_databind();
            //grid3_databind();
            //grid5_databind();
        }

        protected void grid_smzl_databind()
        {
            if (Session["wd"] != null)
            {
                DataTable dt = Session["wd"] as DataTable;
                DataView dv = dt.DefaultView;
                dv.Sort = "lx";
                Grid_smzl.DataSource = dv;
                Grid_smzl.DataBind();
            }
        }

        protected void grid1_databind()
        {
            if (Session["sp1"] != null)
            {
                DataTable dt = Session["sp1"] as DataTable;
                DataView dv = dt.DefaultView;
                dv.Sort = "lx";
                Grid1.DataSource = dv;
                Grid1.DataBind();
            }
        }

        //protected void grid2_databind()
        //{
        //    if (Session["sp2"] != null)
        //    {
        //        DataTable dt = Session["sp2"] as DataTable;
        //        Grid2.DataSource = dt;
        //        Grid2.DataBind();
        //    }
        //}

        //protected void grid3_databind()
        //{
        //    if (Session["sp3"] != null)
        //    {
        //        DataTable dt = Session["sp3"] as DataTable;
        //        Grid3.DataSource = dt;
        //        Grid3.DataBind();
        //    }
        //}
        //protected void grid5_databind()
        //{
        //    if (Session["sp4"] != null)
        //    {
        //        DataTable dt = Session["sp4"] as DataTable;
        //        Grid5.DataSource = dt;
        //        Grid5.DataBind();
        //    }
        //}
        protected void Button8_Click(object sender, EventArgs e)
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
                string sj = SJ2.Text.Trim();
                string dzyx = DZYX2.Text.Trim();
                if (ViewState["xmbh"] == null)
                {
                    ViewState["xmbh"] = AutoNumber("2015-08-");
                    jxbw_Model.XMBH = ViewState["xmbh"].ToString();
                    jxbw_bll.Add(jxbw_Model);
                }

                jxbwxmcy_model.XMBH = ViewState["xmbh"].ToString();
                jxbwxmcy_model.CYXM = xm;
                jxbwxmcy_model.BMZW = bm;
                jxbwxmcy_model.SJ = sj;
                jxbwxmcy_model.DZYX = dzyx;
                jxbwxmcy_bll.Add(jxbwxmcy_model);
                BindGridXMCY();
            }
            catch (Exception)
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
            }
        }

        public void BindGridXMCY()//绑定项目成员
        {
            Grid4.DataSource = jxbwxmcy_bll.GetList(string.Format("XMBH='{0}'", ViewState["xmbh"].ToString()));
            Grid4.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid4);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                jxbwxmcy_bll.Delete(ids[i]);
            }
            BindGridXMCY();
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
        protected void Button_step9_Click(object sender, EventArgs e)//“下一步”按钮以及所选证书信息顶部导航
        {
            //if (Grid4.Rows.Count <= 0)
            //{
            //    Alert.Show("请添加项目成员信息！");
            //    return;
            //}
            if (!Add_XMFZRXX())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            //ContentPanel_step1.Hidden = true;
            SimpleForm_step2.Hidden = true;
            SimpleForm_step9.Hidden = false;
            //PageContext.RegisterStartupScript("a(3);");
        }

        public bool Add_XMFZRXX()
        {
            try
            {
                if (ViewState["xmbh"] == null)
                {
                    ViewState["xmbh"] = AutoNumber("2015-08-");
                    jxbw_Model.XMBH = ViewState["xmbh"].ToString();
                    jxbw_bll.Add(jxbw_Model);
                }
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                jxbw_Model = jxbw_bll._GetModel(xmbh);
                if (jxbw_Model == null)
                {
                    IsAdd = true;
                    jxbw_Model = new Model.JXBW();
                    ViewState["xmbh"] = AutoNumber("2015-08-");
                    jxbw_Model.XMBH = ViewState["xmbh"].ToString();
                }
                //赋值
               
                jxbw_Model.XXDM = ViewState["xxdm"].ToString();
                jxbw_Model.XMMC = TextBox_xmmc.Text.Trim();
                jxbw_Model.XXMC = TextBox_DWMC1.Text.Trim();
                jxbw_Model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");
                jxbw_Model.XMFZR_XM = XM1.Text.Trim();
                jxbw_Model.XMFZR_BM = BM1.Text.Trim();
                jxbw_Model.XMFZR_ZYJSZW = ZYJSZW1.Text.Trim();
                jxbw_Model.XMFZR_XZZW = XZZW1.Text.Trim();
                jxbw_Model.XMFZR_BGSDH = BGSDH1.Text.Trim();
                jxbw_Model.XMFZR_CZ = CZ1.Text.Trim();
                jxbw_Model.XMFZR_SJ = SJ1.Text.Trim();
                jxbw_Model.XMFZR_DZYX = DZYX1.Text.Trim();
                jxbw_Model.user_uid = pb.GetIdentityId();
                jxbw_Model.ZT = 1;
                jxbw_Model.SFSC = 0;
   
                if (IsAdd)
                {
                    return jxbw_bll.Add(jxbw_Model) > 0;
                }
                else
                {
                    return jxbw_bll.Update(jxbw_Model);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
                return false;
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (!Add_File())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            else
            {
                Session.Remove("sp1");
                Session.Remove("wd");
            }

            string xmbh = ViewState["xmbh"].ToString();
            jxbw_Model = jxbw_bll._GetModel(xmbh);

            //string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ViewState["xxdm"] + ".doc";
            //var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2 2015项目申报书(双证融通)150228(1).docx");
            //var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

            //if (new BuildWord().BuildWord_2015ProjectDeclaration_SZRT(tmppath, savepath, xmbh))
            //{
            //    BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
            //    Model.XMSBSWD model = new Model.XMSBSWD();
            //    model.XMBH = jxbw_Model.XMBH;
            //    model.XMMC = jxbw_Model.XMMC;
            //    model.WDLJ = savepath;
            //    wordBll.Add(model);
            //}

            PageContext.RegisterStartupScript("alert('已成功保存,系统将自动关闭此页面');CloseWebPage();");
        }
        public bool Add_File()
        {
            try
            {
                bool IsAdd = false;
                string xmbh = ViewState["xmbh"].ToString();
                jxbw_Model = jxbw_bll._GetModel(xmbh);
                if (jxbw_Model == null)
                {
                    IsAdd = true;
                    jxbw_Model = new Model.JXBW();
                }

                //if (ViewState["file1"] != null)
                //    jxbw_Model.WORD1 = ViewState["file1"].ToString();
                //if (ViewState["file2"] != null)
                //    jxbw_Model.WORD2 = ViewState["file2"].ToString();
                //if (ViewState["file3"] != null)
                //    jxbw_Model.WORD3 = ViewState["file3"].ToString();
                //if (ViewState["file4"] != null)
                //    jxbw_Model.WORD4 = ViewState["file4"].ToString();
                //if (ViewState["file5"] != null)
                //    jxbw_Model.SP1 = ViewState["file5"].ToString();
                //if (ViewState["file6"] != null)
                //    jxbw_Model.SP2 = ViewState["file6"].ToString();
                //if (ViewState["file7"] != null)
                //    jxbw_Model.SP3 = ViewState["file7"].ToString();
                //if (ViewState["file8"] != null)
                //    jxbw_Model.SP4 = ViewState["file8"].ToString();
                //if (ViewState["file9"] != null)
                //    jxbw_Model.SP5 = ViewState["file9"].ToString();
                //if (ViewState["file10"] != null)
                //    jxbw_Model.SP6 = ViewState["file10"].ToString();
                //if (ViewState["file11"] != null)
                //    jxbw_Model.SP7 = ViewState["file11"].ToString();
                //if (ViewState["file12"] != null)
                //    jxbw_Model.SP8 = ViewState["file12"].ToString();
                //if (ViewState["file13"] != null)
                //    jxbw_Model.SP9 = ViewState["file13"].ToString();
                //if (ViewState["file14"] != null)
                //    jxbw_Model.SP10 = ViewState["file14"].ToString();
                 DataRow[] arrayDR = null;
                 string files = "";
                 DataTable dt = null;
                 if (Session["wd"] != null)
                 {
                     dt = Session["wd"] as DataTable;


                     arrayDR = dt.Select("lxzm='smtg'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.WORD1 = files;
                     }
                     arrayDR = dt.Select("lxzm='zyrcpyfa'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.WORD2 = files;
                     }

                     arrayDR = dt.Select("lxzm='jxjhb'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.WORD3 = files;
                     }

                     arrayDR = dt.Select("lxzm='qt'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.WORD4 = files;
                     }

                 }
                 else
                 {
                     Alert.Show("请上传书面资料！");
                 }
                 if (Session["sp1"] != null)
                 {
                     dt = Session["sp1"] as DataTable;


                     arrayDR = dt.Select("lxzm='dcsj'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.SP1 = files;
                     }
                     arrayDR = dt.Select("lxzm='wngh'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.SP2 = files;
                     }

                     arrayDR = dt.Select("lxzm='gzkcmc'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.SP3 = files;
                     }

                     arrayDR = dt.Select("lxzm='zzkcmc'");
                     if (arrayDR != null)
                     {
                         files = "";
                         for (int j = 0; j < arrayDR.Length; j++)
                         {
                             if (j != arrayDR.Length - 1)
                                 files = files + arrayDR[j]["filename"].ToString().Trim() + "|";
                             else
                                 files = files + arrayDR[j]["filename"].ToString().Trim();
                         }
                         jxbw_Model.SP4 = files;
                     }
                 }
                 else
                 {
                     Alert.Show("请上传视频文件！");
                 }
                jxbw_Model.user_uid = pb.GetIdentityId();
                jxbw_Model.ZT = 1;
                jxbw_Model.SFSC = 0;
                jxbw_Model.TBRQ = DateTime.Now.ToString("yyyy-MM-dd");
                if (IsAdd)
                {
                    return jxbw_bll.Add(jxbw_Model) > 0;
                }
                else
                {
                    return jxbw_bll.Update(jxbw_Model);
                }
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message);
                return false;
            }

        }
        //protected void btnSubmit1_Click(object sender, EventArgs e)//上传附件一
        //{
        //    if (FileUpload1.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload1.ShortFileName;
        //            if (fileName.Contains(".doc") || fileName.Contains(".docx"))
        //            {




        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload1.SaveAs(Server.MapPath("upload/教学比武/" + fileName));
        //                ViewState["file1"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传word格式的文件！");
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}

      
        //protected void btnSubmit5_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload5.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload5.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload5.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file5"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}

        //protected void btnSubmit6_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload6.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload6.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload6.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file6"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit7_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload7.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload7.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload7.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file7"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit8_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload8.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload8.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload8.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file8"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit9_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload9.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload9.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload9.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file9"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit10_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload10.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload10.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload10.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file10"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit11_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload11.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload11.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload11.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file11"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit12_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload12.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload12.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload12.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file12"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit13_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload13.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload13.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload13.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file13"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        //protected void btnSubmit14_Click(object sender, EventArgs e)//上传附件四
        //{
        //    if (FileUpload14.HasFile)
        //    {
        //        try
        //        {
        //            string fileName = FileUpload14.ShortFileName;


        //            if (fileName.Contains("wmv"))
        //            {

        //                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
        //                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

        //                FileUpload14.SaveAs(@"E:\video\" + fileName);
        //                ViewState["file14"] = fileName;
        //                Alert.ShowInTop("上传成功！");
        //            }
        //            else
        //            {
        //                Alert.ShowInTop("请上传wmv格式的文件！");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            Alert.ShowInTop(ex.Message);
        //            return;
        //        }
        //    }
        //}
        protected void Button14_Click(object sender, EventArgs e)
        {
            List<int> ids = GetSelectedDataKeyIDs(Grid4);
            // 执行数据库操作
            for (int i = 0; i < ids.Count; i++)
            {
                jxbwxmcy_bll.Delete(ids[i]);
            }
            BindGridXMCY();
        }

        protected void Button_step9II_Click(object sender, EventArgs e)
        {
            if (!Add_File())
            {
                Alert.Show("数据保存失败，请检查数据正确性！");
                return;
            }
            SimpleForm_step2.Hidden = false;
            SimpleForm_step9.Hidden = true;

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string extensions = "doc,docx,pptx,ppt,pdf,xlsx,xls";
            PageContext.RegisterStartupScript(Window1.GetShowReference("upload.aspx?lx=wd&extensions=" + extensions, "书面资料上传", 700, 450));
        }

        protected void Grid1_Button1_Click(object sender, EventArgs e)
        {
            string extensions = "wmv";
            string script = Window1.GetShowReference("upload.aspx?lx=sp3&extensions=" + extensions, "高职教师+课程名称", 700, 450);
            PageContext.RegisterStartupScript(Window1.GetShowReference("upload.aspx?lx=sp1&extensions=" + extensions, "视频上传", 700, 450));
        }

        protected void Grid2_Button1_Click(object sender, EventArgs e)
        {
            string extensions = "wmv";
            PageContext.RegisterStartupScript(Window1.GetShowReference("upload.aspx?lx=sp2&extensions=" + extensions, "五年规划", 700, 450));
        }

        protected void Grid_smzl_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid_smzl.DataKeys[e.RowIndex];

            string selectedID = values[0].ToString().Trim();
            if (e.CommandName == "del")
            {
                if (Session["wd"] != null)
                {
                    DataTable dt = (DataTable)Session["wd"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            //if (File.Exists(Server.MapPath("upload/教学比武/" + dt.Rows[i][1].ToString())))
                            //{
                            //    File.Delete(Server.MapPath("upload/教学比武/" + dt.Rows[i][1].ToString()));
                            //}
                            dt.Rows.Remove(dt.Rows[i]);

                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid_smzl.DataSource = dt;
                    Grid_smzl.DataBind();
                    Session["wd"] = dt;
                }
            }
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
             object[] values = Grid1.DataKeys[e.RowIndex];
          
            string selectedID = values[0].ToString().Trim();
            if (e.CommandName == "del")
            {
                if (Session["sp1"] != null)
                {
                    DataTable dt = (DataTable)Session["sp1"];
                    //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
                    //foreach (DataRow d in dr)
                    //{
                    //    dt.Rows.Remove(d);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == selectedID)
                        {
                            //if (File.Exists(@"E:\video\" + dt.Rows[i][1].ToString()))
                            //{
                            //    File.Delete(@"E:\video\" + dt.Rows[i][1].ToString());
                            //}
                            dt.Rows.Remove(dt.Rows[i]);
                           
                            break;
                        }
                    }
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "nf asc";
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                    Session["sp1"] = dt;
                }
            }
        }
        //protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        //{
        //    object[] values = Grid2.DataKeys[e.RowIndex];

        //    string selectedID = values[0].ToString().Trim();
        //    if (e.CommandName == "del")
        //    {
        //        if (Session["sp2"] != null)
        //        {
        //            DataTable dt = (DataTable)Session["sp2"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    if (File.Exists(@"E:\video\" + dt.Rows[i][1].ToString()))
        //                    {
        //                        File.Delete(@"E:\video\" + dt.Rows[i][1].ToString());
        //                    }
        //                    dt.Rows.Remove(dt.Rows[i]);

        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            Grid2.DataSource = dt;
        //            Grid2.DataBind();
        //            Session["sp2"] = dt;
        //        }
        //    }
        //}
        //protected void Grid3_RowCommand(object sender, GridCommandEventArgs e)
        //{
        //    object[] values = Grid3.DataKeys[e.RowIndex];

        //    string selectedID = values[0].ToString().Trim();
        //    if (e.CommandName == "del")
        //    {
        //        if (Session["sp3"] != null)
        //        {
        //            DataTable dt = (DataTable)Session["sp3"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    if (File.Exists(@"E:\video\" + dt.Rows[i][1].ToString()))
        //                    {
        //                        File.Delete(@"E:\video\" + dt.Rows[i][1].ToString());
        //                    }
        //                    dt.Rows.Remove(dt.Rows[i]);

        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            Grid3.DataSource = dt;
        //            Grid3.DataBind();
        //            Session["sp3"] = dt;
        //        }
        //    }
        //}
        //protected void Grid5_RowCommand(object sender, GridCommandEventArgs e)
        //{
        //    object[] values = Grid5.DataKeys[e.RowIndex];

        //    string selectedID = values[0].ToString().Trim();
        //    if (e.CommandName == "del")
        //    {
        //        if (Session["sp4"] != null)
        //        {
        //            DataTable dt = (DataTable)Session["sp4"];
        //            //DataRow[] dr = dt.Select("id in(" + selectedID + ")");
        //            //foreach (DataRow d in dr)
        //            //{
        //            //    dt.Rows.Remove(d);
        //            //}
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                if (dt.Rows[i][0].ToString() == selectedID)
        //                {
        //                    if (File.Exists(@"E:\video\" + dt.Rows[i][1].ToString()))
        //                    {
        //                        File.Delete(@"E:\video\" + dt.Rows[i][1].ToString());
        //                    }
        //                    dt.Rows.Remove(dt.Rows[i]);

        //                    break;
        //                }
        //            }
        //            //DataView dv = new DataView(dt);
        //            //dv.Sort = "nf asc";
        //            Grid5.DataSource = dt;
        //            Grid5.DataBind();
        //            Session["sp4"] = dt;
        //        }
        //    }
        //}

        protected void Grid3_Button1_Click(object sender, EventArgs e)
        {
            string extensions = "wmv";
            string script = Window1.GetShowReference("upload.aspx?lx=sp3&extensions=" + extensions, "高职教师+课程名称", 700, 450);
            PageContext.RegisterStartupScript(Window1.GetShowReference("upload.aspx?lx=sp3&extensions=" + extensions, "高职教师+课程名称", 700, 450));
        }

        protected void Grid4_Button1_Click(object sender, EventArgs e)
        {
            string extensions = "wmv";
            PageContext.RegisterStartupScript(Window1.GetShowReference("upload.aspx?lx=sp4&extensions=" + extensions, "中职教师+课程名称", 700, 450));
        }

    }
}