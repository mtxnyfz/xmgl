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
using Aspose.Cells;
using XMGL.BLL;
using ExcelHelp;

namespace XMGL.Web.admin
{
    public partial class XMGL : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnCheckSelection.OnClientClick = Window1.GetShowReference("XMFL.aspx", "填写申报项目")+Window1.GetMaximizeReference();
                if (Request.QueryString["xmld"] != null)
                    ViewState["xmld"] = Request.QueryString[0].ToString().Trim();
                else
                {
                    Alert.Show("非法的请求！", "系统提示", MessageBoxIcon.Warning);
                    return;
                }
                databind();
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
            }
        }

        protected void databind()
        {
            //string sqlstr = "select YLZY.XMBH,'一流专业建设' as XMDL,YLZY.XMMC,YLZY.SQZXJF,YLZY.XXPTJF,YLZY.ZT,XMFJ.XMKXXFXBGWJM,XMFJ.YXXSALWJM from YLZY left join XMFJ  on user_uid='" + pb.GetIdentityId() + "' and SFSC!=1 AND YLZY.XMBH=XMFJ.XMBH order by XMBH";
            string sqlstr = "";
            DataTable dt = null;
            if (ViewState["xmld"] != null)
            {
                if (ViewState["xmld"].ToString().Trim() == "一流专业建设")
                {
                    sqlstr = "  select  a.ID, a.user_uid, a.XMBH,'一流专业建设' as XMDL,a.XMMC,a.SQZXJF,a.XXPTJF,a.ZT,XMFJ.XMKXXFXBGWJM,XMFJ.YXXSALWJM,XMFJ.XMYSMXWJM from ( select * from YLZY where user_uid='" + pb.GetIdentityId() + "' and SFSC!=1) as a left join XMFJ  on   a.XMBH=XMFJ.XMBH order by XMBH";
                    dt = DbHelperSQL.Query(sqlstr).Tables[0];
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                    Grid1.Hidden = false;
                    Grid2.Hidden = true;
                    Grid2_ylfw.Hidden = true;
                }


                else if (ViewState["xmld"].ToString().Trim() == "民族文化传承与创新")
                {
                    sqlstr = "  select a.ID,a.ZYDM,a.ZYMCFX,a.DTR_XM, a.user_uid, a.XMBH,'民族文化传承与创新' as XMDL,a.ZT,XMFJ.XMKXXFXBGWJM,XMFJ.YXXSALWJM,XMFJ.XMYSMXWJM from ( select * from WHCC where user_uid='" + pb.GetIdentityId() + "' and SFSC!=1) as a left join XMFJ  on   a.XMBH=XMFJ.XMBH order by XMBH";
                    dt = DbHelperSQL.Query(sqlstr).Tables[0];
                    Grid2.DataSource = dt;
                    Grid2.DataBind();

                    Grid1.Hidden = true;
                    Grid2.Hidden = false;
                    Grid2_ylfw.Hidden = true;
                }

                else if (ViewState["xmld"].ToString().Trim() == "养老服务类示范专业")
                {
                    sqlstr = "select '养老服务类示范专业' AS YLFW, ID,XMBH,ZYDM,ZYMC,ZYDTRXM,ZT from YLFW where user_uid='" + pb.GetIdentityId() + "' and SFSC!=1  order by XMBH";
                    dt = DbHelperSQL.Query(sqlstr).Tables[0];
                    Grid2_ylfw.DataSource = dt;
                    Grid2_ylfw.DataBind();

                    Grid1.Hidden = true;
                    Grid2.Hidden = true;
                    Grid2_ylfw.Hidden = false;
                }
            }
        }
        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            databind();
            Alert.ShowInTop("操作成功！");
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }
        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
        }
        protected void Grid2_ylfw_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2_ylfw.PageIndex = e.NewPageIndex;
        }
        protected void btnCheckSelection_Click(object sender, EventArgs e)
        {

            ReadOrWriteExcel rw = new ExcelHelp.ReadOrWriteExcel(@"C:\(上海应用技术学院)高职服务平台二级学院基础数据模板.xls");
            DataTable dt = rw.BeginRead("A4", "S4", "学校信息");

            Model.XXJBQKB XXJBQKB_Model = new Model.XXJBQKB();
            BLL.XXJBQKB XXJBQKB_Bll = new XXJBQKB();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XXJBQKB_Model.XXDM = dt.Rows[i][0].ToString().Trim();
                XXJBQKB_Model.XXMC = dt.Rows[i][1].ToString().Trim();
                XXJBQKB_Model.JBF = dt.Rows[i][2].ToString().Trim();
                XXJBQKB_Model.XXXZ = dt.Rows[i][3].ToString().Trim();
                XXJBQKB_Model.TXDZ = dt.Rows[i][4].ToString().Trim();
                XXJBQKB_Model.YB = dt.Rows[i][5].ToString().Trim();
                XXJBQKB_Model.XXWZ = dt.Rows[i][6].ToString().Trim();
                XXJBQKB_Model.FRDBXM = dt.Rows[i][7].ToString().Trim();

                XXJBQKB_Model.FRDBZW = dt.Rows[i][8].ToString().Trim();
                XXJBQKB_Model.FRDBBGSDH = dt.Rows[i][9].ToString().Trim();
                XXJBQKB_Model.FRDBCZ = dt.Rows[i][10].ToString().Trim();
                XXJBQKB_Model.FRDBSJ = dt.Rows[i][11].ToString().Trim();

                XXJBQKB_Model.FRDBDZYX = dt.Rows[i][12].ToString().Trim();
                XXJBQKB_Model.LXRXM = dt.Rows[i][13].ToString().Trim();
                XXJBQKB_Model.LXRZW = dt.Rows[i][14].ToString().Trim();
                XXJBQKB_Model.LXRBGSDH = dt.Rows[i][15].ToString().Trim();

                XXJBQKB_Model.LXRCZ = dt.Rows[i][16].ToString().Trim();
                XXJBQKB_Model.LXRSJ = dt.Rows[i][17].ToString().Trim();
                XXJBQKB_Model.LXRDZYX = dt.Rows[i][18].ToString().Trim();
                XXJBQKB_Bll.Add(XXJBQKB_Model);
            }
          




            //dt = rw.BeginRead("D4", "S4", "学校信息");

            Model.XXJBQK XXJBQK_Model = new Model.XXJBQK();
            BLL.XXJBQK XXJBQK_Bll = new XXJBQK();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XXJBQK_Model.XXDM = dt.Rows[i][0].ToString().Trim();
                XXJBQK_Model.XXMC = dt.Rows[i][1].ToString().Trim();
                XXJBQK_Model.JBF = dt.Rows[i][2].ToString().Trim();
                XXJBQK_Model.XXXZ = dt.Rows[i][3].ToString().Trim();
                XXJBQK_Model.TXDZ = dt.Rows[i][4].ToString().Trim();
                XXJBQK_Model.YB = dt.Rows[i][5].ToString().Trim();
                XXJBQK_Model.XXWZ = dt.Rows[i][6].ToString().Trim();
                XXJBQK_Model.FRDBXM = dt.Rows[i][7].ToString().Trim();

                XXJBQK_Model.FRDBZW = dt.Rows[i][8].ToString().Trim();
                XXJBQK_Model.FRDBBGSDH = dt.Rows[i][9].ToString().Trim();
                XXJBQK_Model.FRDBCZ = dt.Rows[i][10].ToString().Trim();
                XXJBQK_Model.FRDBSJ = dt.Rows[i][11].ToString().Trim();

                XXJBQK_Model.FRDBDZYX = dt.Rows[i][12].ToString().Trim();
                XXJBQK_Model.LXRXM = dt.Rows[i][13].ToString().Trim();
                XXJBQK_Model.LXRZW = dt.Rows[i][14].ToString().Trim();
                XXJBQK_Model.LXRBGSDH = dt.Rows[i][15].ToString().Trim();

                XXJBQK_Model.LXRCZ = dt.Rows[i][16].ToString().Trim();
                XXJBQK_Model.LXRSJ = dt.Rows[i][17].ToString().Trim();
                XXJBQK_Model.LXRDZYX = dt.Rows[i][18].ToString().Trim();
                XXJBQK_Bll.Add(XXJBQK_Model);
            }
           


            dt = rw.BeginRead("A3", "H", "教师信息");
            Model.JSXXB JSXXB_Model = new Model.JSXXB();
            BLL.JSXXB JSXXB_Bll = new JSXXB();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JSXXB_Model.XXDM = dt.Rows[i][0].ToString().Trim();
                JSXXB_Model.JSXM = dt.Rows[i][1].ToString().Trim();
                JSXXB_Model.CSNY = dt.Rows[i][2].ToString().Trim();
                JSXXB_Model.ZZJZ = dt.Rows[i][3].ToString().Trim();
                JSXXB_Model.SFSS = dt.Rows[i][4].ToString().Trim();

                JSXXB_Model.XL = dt.Rows[i][5].ToString().Trim();
                JSXXB_Model.XW = dt.Rows[i][6].ToString().Trim();
                JSXXB_Model.ZCDJ = dt.Rows[i][7].ToString().Trim();
                JSXXB_Bll.Add(JSXXB_Model);
            }


            dt = rw.BeginRead("A4", "Q", "专业信息");
            Model.ZYB1 zyb1_model = new Model.ZYB1();
            BLL.ZYB1 zyb1_bll = new ZYB1();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                zyb1_model.ZYDM = dt.Rows[i][0].ToString().Trim();
                zyb1_model.ZYMC = dt.Rows[i][1].ToString().Trim();
                zyb1_model.ZYFXDM = dt.Rows[i][2].ToString().Trim();
                zyb1_model.ZYFXMC = dt.Rows[i][3].ToString().Trim();
                zyb1_model.XXDM = dt.Rows[i][4].ToString().Trim();
                zyb1_model.XXMC = dt.Rows[i][5].ToString().Trim();
                zyb1_model.ZYSSDL = dt.Rows[i][6].ToString().Trim();
                zyb1_model.ZYSSEJL = dt.Rows[i][7].ToString().Trim();

                zyb1_model.ZYFZR_XM = dt.Rows[i][8].ToString().Trim();
                zyb1_model.ZYFZR_XZZW = dt.Rows[i][9].ToString().Trim();
                zyb1_model.ZYFZR_ZYJSZW = dt.Rows[i][10].ToString().Trim();
                zyb1_model.ZYFZR_ZYZGZS = dt.Rows[i][11].ToString().Trim();
                zyb1_model.ZYFZR_BGSDH = dt.Rows[i][12].ToString().Trim();
                zyb1_model.ZYFZR_CZ = dt.Rows[i][13].ToString().Trim();
                zyb1_model.ZYFZR_SJ = dt.Rows[i][14].ToString().Trim();
                zyb1_model.ZYFZR_DZYX = dt.Rows[i][15].ToString().Trim();
                zyb1_model.ZYDTR_XM = dt.Rows[i][16].ToString().Trim();
                zyb1_bll.Add(zyb1_model);
            }


            dt = rw.BeginRead("A3", "N", "近三年专业招生就业信息");
            Model.ZYZSJYQKB ZYZSJYQKB_Model = new Model.ZYZSJYQKB();
            BLL.ZYZSJYQKB ZYZSJYQKB_BLL = new ZYZSJYQKB();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ZYZSJYQKB_Model.XXDM = dt.Rows[i][0].ToString().Trim();
                ZYZSJYQKB_Model.XXMC = dt.Rows[i][1].ToString().Trim();
                ZYZSJYQKB_Model.ZYDM = dt.Rows[i][2].ToString().Trim();
                ZYZSJYQKB_Model.ZYMC = dt.Rows[i][3].ToString().Trim();
                ZYZSJYQKB_Model.ZYFXDM = dt.Rows[i][4].ToString().Trim();
                ZYZSJYQKB_Model.ZYFXMC = dt.Rows[i][5].ToString().Trim();
                ZYZSJYQKB_Model.NF = dt.Rows[i][6].ToString().Trim();
                try
                {
                    ZYZSJYQKB_Model.SJZSS = int.Parse(dt.Rows[i][7].ToString().Trim());
                }
                catch
                {
                    ZYZSJYQKB_Model.SJZSS = null;
                }

                try
                {
                    ZYZSJYQKB_Model.XSBDL = decimal.Parse(dt.Rows[i][8].ToString().Trim());
                }
                catch
                {
                    ZYZSJYQKB_Model.XSBDL = null;
                }
                try
                {
                    ZYZSJYQKB_Model.QRZZXSS = int.Parse(dt.Rows[i][9].ToString().Trim());
                }
                catch
                {
                    ZYZSJYQKB_Model.QRZZXSS = null;
                }
                try
                {
                    ZYZSJYQKB_Model.DDPYRS = int.Parse(dt.Rows[i][10].ToString().Trim());
                }
                catch
                {
                    ZYZSJYQKB_Model.DDPYRS = null;
                }
                try
                {
                    ZYZSJYQKB_Model.BYSRS = int.Parse(dt.Rows[i][11].ToString().Trim());
                }
                catch
                {
                    ZYZSJYQKB_Model.BYSRS = null;
                }
                try
                {
                    ZYZSJYQKB_Model.CCJYL = decimal.Parse(dt.Rows[i][12].ToString().Trim());
                }
                catch
                {
                    ZYZSJYQKB_Model.CCJYL = null;
                }
                try
                {
                    ZYZSJYQKB_Model.DKL = decimal.Parse(dt.Rows[i][13].ToString().Trim());
                }
                catch
                {
                    ZYZSJYQKB_Model.DKL = null;
                }

                ZYZSJYQKB_BLL.Add(ZYZSJYQKB_Model);
            }


            dt = rw.BeginRead("A3", "M", "近三年专业招生就业信息");
            Model.SJ_ZYDTR SJ_ZYDTR_Model = new Model.SJ_ZYDTR();
            BLL.SJ_ZYDTR SJ_ZYDTR_Bll = new SJ_ZYDTR();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SJ_ZYDTR_Model.ZYDTR_XXDM = dt.Rows[i][0].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_XXMC = dt.Rows[i][1].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_ZYDM = dt.Rows[i][2].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_ZYMC = dt.Rows[i][3].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_XM = dt.Rows[i][4].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_XBM = dt.Rows[i][5].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_CSNY = dt.Rows[i][6].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_XL = dt.Rows[i][7].ToString().Trim();

                SJ_ZYDTR_Model.ZYDTR_XW = dt.Rows[i][8].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_ZYJSZWMC1 = dt.Rows[i][9].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_ZW = dt.Rows[i][10].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_DWDH = dt.Rows[i][11].ToString().Trim();
                SJ_ZYDTR_Model.ZYDTR_DZYX = dt.Rows[i][12].ToString().Trim();

                SJ_ZYDTR_Bll.Add(SJ_ZYDTR_Model);

            }
            //string sqlstr_col = "insert into XXJBQKB(";
            //string sqlstr_val = "";
          
            //        for (int j = 0; j < dt.Columns.Count; j++)
            //        {
            //            if (j != dt.Columns.Count - 1)
            //                sqlstr_col = sqlstr_col + dt.Rows[0][j].ToString().Trim() + ",";
            //            else
            //            {
            //                sqlstr_col = sqlstr_col + dt.Rows[0][j].ToString().Trim() + ") values(";
            //            }
            //        }
             

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (i > 0)
            //    {
            //        sqlstr_val=sqlstr_val+
            //    }

            //}

            //Model.ZYB1 zyb1_model = new Model.ZYB1();
            //BLL.ZYB1 zyb1_BLL = new BLL.ZYB1();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    zyb1_model.XXDM = dt.Rows[i][0].ToString().Trim();
            //    zyb1_model.XXMC = dt.Rows[i][1].ToString().Trim();
            //    zyb1_model.ZYDM = dt.Rows[i][2].ToString().Trim();
            //    zyb1_model.ZYMC = dt.Rows[i][3].ToString().Trim();
            //    zyb1_model.ZYFXDM = dt.Rows[i][4].ToString().Trim();
            //    zyb1_model.ZYFXMC = dt.Rows[i][5].ToString().Trim();
            //    zyb1_model.ZYSSDL = dt.Rows[i][6].ToString().Trim();
            //    zyb1_model.ZYSSEJL = dt.Rows[i][7].ToString().Trim();
            //    zyb1_model.ZYFZR_XM = dt.Rows[i][8].ToString().Trim();
            //    zyb1_model.ZYFZR_XZZW = dt.Rows[i][9].ToString().Trim();
            //    zyb1_model.ZYFZR_ZYJSZW = dt.Rows[i][10].ToString().Trim();
            //    zyb1_model.ZYFZR_ZYZGZS = dt.Rows[i][11].ToString().Trim();
            //    zyb1_model.ZYFZR_BGSDH = dt.Rows[i][12].ToString().Trim();
            //    zyb1_model.ZYFZR_CZ = dt.Rows[i][13].ToString().Trim();
            //    zyb1_model.ZYFZR_SJ = dt.Rows[i][14].ToString().Trim();
            //    zyb1_model.ZYFZR_DZYX = dt.Rows[i][15].ToString().Trim();
            //    zyb1_model.ZYKBSJ = dt.Rows[i][16].ToString().Trim();
            //    zyb1_model.ZYDTR_XM = dt.Rows[i][17].ToString().Trim();
            //    zyb1_BLL.Add(zyb1_model);
               
            //}


            //ReadOrWriteExcel rw = new ExcelHelp.ReadOrWriteExcel(@"C:\专业就业招生new1.xls");
            //DataTable dt = rw.BeginRead("A2", "U", "Sheet1");

            //Model.ZYZSJYQKB ZYZSJYQKB_model = new Model.ZYZSJYQKB();
            //BLL.ZYZSJYQKB ZYZSJYQKB_BLL = new BLL.ZYZSJYQKB();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ZYZSJYQKB_model.XXDM = dt.Rows[i][0].ToString().Trim();
            //    ZYZSJYQKB_model.XXMC = dt.Rows[i][1].ToString().Trim();
            //    ZYZSJYQKB_model.ZYDM = dt.Rows[i][2].ToString().Trim();
            //    ZYZSJYQKB_model.ZYMC = dt.Rows[i][3].ToString().Trim();
            //    ZYZSJYQKB_model.ZYFXDM = dt.Rows[i][4].ToString().Trim();
            //    ZYZSJYQKB_model.ZYFXMC = dt.Rows[i][5].ToString().Trim();
            //    ZYZSJYQKB_model.NF = dt.Rows[i][6].ToString().Trim();
            //    try
            //    {
            //        ZYZSJYQKB_model.SJZSS = int.Parse(dt.Rows[i][7].ToString().Trim());
            //    }
            //    catch
            //    {
            //        ZYZSJYQKB_model.SJZSS = null;
            //    }
            //    try
            //    {

            //        ZYZSJYQKB_model.XSBDL = decimal.Parse(dt.Rows[i][8].ToString().Trim());
            //    }
            //    catch
            //    {
            //        ZYZSJYQKB_model.XSBDL = null;
            //    }
            //    try
            //    {
            //        ZYZSJYQKB_model.QRZZXSS = int.Parse(dt.Rows[i][9].ToString().Trim());
            //    }
            //    catch
            //    {
            //        ZYZSJYQKB_model.QRZZXSS = null;
            //    }
            //    try
            //    {
            //        ZYZSJYQKB_model.DDPYRS = int.Parse(dt.Rows[i][10].ToString().Trim());
            //    }
            //    catch
            //    {
            //        ZYZSJYQKB_model.DDPYRS = null;
            //    }
            //    try
            //    {
            //        ZYZSJYQKB_model.BYSRS = int.Parse(dt.Rows[i][11].ToString().Trim());
            //    }
            //    catch
            //    {
            //        ZYZSJYQKB_model.BYSRS = null;
            //    }
            //    try
            //    {
            //        ZYZSJYQKB_model.CCJYL = decimal.Parse(dt.Rows[i][12].ToString().Trim());
            //    }
            //    catch
            //    {
            //        ZYZSJYQKB_model.CCJYL = null;
            //    }
            //    try
            //    {

            //        ZYZSJYQKB_model.DKL = decimal.Parse(dt.Rows[i][13].ToString().Trim());
            //    }
            //    catch
            //    {
            //        ZYZSJYQKB_model.DKL = null;
            //    }
               
            //    ZYZSJYQKB_BLL.Add(ZYZSJYQKB_model);

            //}



            //string date = DateTime.Now.ToString("yyyy-MM-dd") +"-"+ DateTime.Now.Hour.ToString() +"-"+DateTime.Now.Minute.ToString();
            //Alert.Show(date);
        }
        protected void btnConfirmButton_Click(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string zt = "";
            string date = "";
            string xmqs = "";
            string sqlstr = "";
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
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";
                    zt += Grid1.DataKeys[rowIndex][2].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (zt == "1")
                {
                    sqlstr = "update YLZY set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {
                    Alert.Show("该项目已经提交，无法删除");
                }

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string date = "";
            string xmqs = "";
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
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                //date = date.TrimEnd(',');//去掉最后一个，号
                //xmqs = xmqs.TrimEnd(',');//去掉最后一个，号
                //string date1 = "2013-05-01";
                //DateTime dt = Convert.ToDateTime(date);
                //DateTime dt1 = Convert.ToDateTime(date1);
                ////if (DateTime.Compare(dt, dt1) > 0&&xmqs=="")
                ////PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail2.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));
                //if (xmqs == "2")
                //    PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail2.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));
                //else if (xmqs == "3")
                //    PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));
                //else if (xmqs == "1")
                //    PageContext.RegisterStartupScript(Window1.GetShowReference("XMSBDetail1.aspx?id=" + selectedID + "&guid=" + selectedGuid, "查看申报书"));


                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();
                
                var list = wordBll.GetModelList("XMBH = '" + xmbh + "'");
                if (list.Count > 0)
                {
                    var service = ConfigurationManager.AppSettings["OfficeWebAppsServiceIp"];
                    var server = ConfigurationManager.AppSettings["OfficeWebAppsServerIp"];

                    var str = "http://" + server + "/wv/wordviewerframe.aspx?WOPISrc=http://" + service + "/wopi/files/" + xmbh + "?access_token=" + Guid.NewGuid() + "";
                    PageContext.RegisterStartupScript(Window1.GetShowReference(str, "查看申报书")+Window1.GetMaximizeReference());


                }

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string date = "";
            string xmqs = "";
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
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") +"_"+ViewState["xxdm"]+ ".doc";
                var tmppath = HttpContext.Current.Server.MapPath("~/admin/WordMaster/2015项目申报书(一流专业)141226.doc");
                var savepath = HttpContext.Current.Server.MapPath("~/admin/down/" + filename);

                if (new BuildWord().BuildWord_2015ProjectDeclaration(tmppath, savepath, xmbh))
                    HyperLink1.Text = "导出成功！点击下载：" + filename;
                HyperLink1.NavigateUrl ="down/" + filename;


             
            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }

          
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);
            string xmbh = values[1].ToString().Trim();
            string zt = values[2].ToString().Trim();
            string selectedID = values[0].ToString().Trim();
            if (e.CommandName == "xq")
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();

                var list = wordBll.GetModelList("XMBH = '" + xmbh + "'");
                if (list.Count > 0)
                {
                    var service = ConfigurationManager.AppSettings["OfficeWebAppsServiceIp"];
                    var server = ConfigurationManager.AppSettings["OfficeWebAppsServerIp"];

                    var str = "http://" + server + "/wv/wordviewerframe.aspx?WOPISrc=http://" + service + "/wopi/files/" + xmbh + "?access_token=" + Guid.NewGuid() + "";
                    PageContext.RegisterStartupScript(Window1.GetShowReference(str, "查看申报书") + Window1.GetMaximizeReference());


                }
            }

            else if (e.CommandName == "up")
            {
                if (zt == "1")
                {
                    PageContext.RegisterStartupScript(Window1.GetShowReference("XMGL_Up.aspx?xmbh="+xmbh, "查看申报书") + Window1.GetMaximizeReference());
                }
                else
                {

                    Alert.Show("该项目已经提交，无法修改");
                }
            }

            else if (e.CommandName == "tj")
            {
                if (zt == "1")
                {
                    string sqlstr = "update YLZY set ZT=2 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {

                    Alert.Show("该项目已经提交，无需重复提交");
                }
            }

            else if (e.CommandName == "del")
            {
                if (zt == "1")
                {
                    string sqlstr = "update YLZY set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {
                    Alert.Show("该项目已经提交，无法删除");
                }
            }
        }
        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid2.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);
            string xmbh = values[1].ToString().Trim();
            string zt = values[2].ToString().Trim();
            string selectedID = values[0].ToString().Trim();
            if (e.CommandName == "xq")
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();

                var list = wordBll.GetModelList("XMBH = '" + xmbh + "'");
                if (list.Count > 0)
                {
                    var service = ConfigurationManager.AppSettings["OfficeWebAppsServiceIp"];
                    var server = ConfigurationManager.AppSettings["OfficeWebAppsServerIp"];

                    var str = "http://" + server + "/wv/wordviewerframe.aspx?WOPISrc=http://" + service + "/wopi/files/" + xmbh + "?access_token=" + Guid.NewGuid() + "";
                    PageContext.RegisterStartupScript(Window1.GetShowReference(str, "查看申报书") + Window1.GetMaximizeReference());


                }
            }

            else if (e.CommandName == "up")
            {
                if (zt == "1")
                {
                    PageContext.RegisterStartupScript(Window1.GetShowReference("XMGL_MZWHCC_Up.aspx?xmbh=" + xmbh, "查看申报书") + Window1.GetMaximizeReference());
                }
                else
                {

                    Alert.Show("该项目已经提交，无法修改");
                }
            }

            else if (e.CommandName == "tj")
            {
                if (zt == "1")
                {
                    string sqlstr = "update WHCC set ZT=2 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {

                    Alert.Show("该项目已经提交，无需重复提交");
                }
            }

            else if (e.CommandName == "del")
            {
                if (zt == "1")
                {
                    string sqlstr = "update WHCC set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {
                    Alert.Show("该项目已经提交，无法删除");
                }
            }
        }


        protected void Grid2_ylfw_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid2_ylfw.DataKeys[e.RowIndex];
            //int id = Convert.ToInt32(values[0]);
            string xmbh = values[1].ToString().Trim();
            string zt = values[2].ToString().Trim();
            string selectedID = values[0].ToString().Trim();
            if (e.CommandName == "xq")
            {
                BLL.XMSBSWD wordBll = new BLL.XMSBSWD();

                var list = wordBll.GetModelList("XMBH = '" + xmbh + "'");
                if (list.Count > 0)
                {
                    var service = ConfigurationManager.AppSettings["OfficeWebAppsServiceIp"];
                    var server = ConfigurationManager.AppSettings["OfficeWebAppsServerIp"];

                    var str = "http://" + server + "/wv/wordviewerframe.aspx?WOPISrc=http://" + service + "/wopi/files/" + xmbh + "?access_token=" + Guid.NewGuid() + "";
                    PageContext.RegisterStartupScript(Window1.GetShowReference(str, "查看申报书") + Window1.GetMaximizeReference());


                }
            }

            else if (e.CommandName == "up")
            {
                if (zt == "1")
                {
                    PageContext.RegisterStartupScript(Window1.GetShowReference("XMGL_Up.aspx?xmbh=" + xmbh, "查看申报书") + Window1.GetMaximizeReference());
                }
                else
                {

                    Alert.Show("该项目已经提交，无法修改");
                }
            }

            else if (e.CommandName == "tj")
            {
                if (zt == "1")
                {
                    string sqlstr = "update YLFW set ZT=2 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {

                    Alert.Show("该项目已经提交，无需重复提交");
                }
            }

            else if (e.CommandName == "del")
            {
                if (zt == "1")
                {
                    string sqlstr = "update YLFW set SFSC=1 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {
                    Alert.Show("该项目已经提交，无法删除");
                }
            }
        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label1") as System.Web.UI.WebControls.Label;



            //Alert.Show(lb.Text, "提示", Alert.DefaultMessageBoxIcon);
            if (lb.Text.Trim() == "1")
                lb.Text = "未提交";
            else if (lb.Text.Trim() == "2")
                lb.Text = "院校审核中";
            else if (lb.Text.Trim() == "3")
                lb.Text = "市教委审核中";
            else if (lb.Text.Trim() == "4")
                lb.Text = "院校退回";
            else if (lb.Text.Trim() == "5")
                lb.Text = "评审中";
            else if (lb.Text.Trim() == "6")
                lb.Text = "市教委退回";
            else if (lb.Text.Trim() == "7")
                lb.Text = "评审通过";
            else if (lb.Text.Trim() == "8")
                lb.Text = "评审未通过";
           
        }
        protected void Grid2_RowDataBound(object sender, GridRowEventArgs e)
        {
            GridRow gr = Grid2.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label_WHCC2") as System.Web.UI.WebControls.Label;



            //Alert.Show(lb.Text, "提示", Alert.DefaultMessageBoxIcon);
            if (lb.Text.Trim() == "1")
                lb.Text = "未提交";
            else if (lb.Text.Trim() == "2")
                lb.Text = "院校审核中";
            else if (lb.Text.Trim() == "3")
                lb.Text = "市教委审核中";
            else if (lb.Text.Trim() == "4")
                lb.Text = "院校退回";
            else if (lb.Text.Trim() == "5")
                lb.Text = "评审中";
            else if (lb.Text.Trim() == "6")
                lb.Text = "市教委退回";
            else if (lb.Text.Trim() == "7")
                lb.Text = "评审通过";
            else if (lb.Text.Trim() == "8")
                lb.Text = "评审未通过";

        }

        protected void Grid2_ylfw_RowDataBound(object sender, GridRowEventArgs e)
        {
            GridRow gr = Grid2_ylfw.Rows[e.RowIndex];
            System.Web.UI.WebControls.Label lb = gr.FindControl("Label2") as System.Web.UI.WebControls.Label;



            //Alert.Show(lb.Text, "提示", Alert.DefaultMessageBoxIcon);
            if (lb.Text.Trim() == "1")
                lb.Text = "未提交";
            else if (lb.Text.Trim() == "2")
                lb.Text = "院校审核中";
            else if (lb.Text.Trim() == "3")
                lb.Text = "市教委审核中";
            else if (lb.Text.Trim() == "4")
                lb.Text = "院校退回";
            else if (lb.Text.Trim() == "5")
                lb.Text = "评审中";
            else if (lb.Text.Trim() == "6")
                lb.Text = "市教委退回";
            else if (lb.Text.Trim() == "7")
                lb.Text = "评审通过";
            else if (lb.Text.Trim() == "8")
                lb.Text = "评审未通过";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string xmbh = "";
            string zt = "";
            string date = "";
            string xmqs = "";
            string sqlstr = "";
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
                    xmbh += Grid1.DataKeys[rowIndex][1].ToString() + ",";
                    zt += Grid1.DataKeys[rowIndex][2].ToString() + ",";

                }
                selectedID = selectedID.TrimEnd(',');//去掉最后一个，号
                xmbh = xmbh.TrimEnd(',');//去掉最后一个，号
                zt = zt.TrimEnd(',');//去掉最后一个，号
                if (zt == "1")
                {
                    sqlstr = "update YLZY set ZT=2 where ID=" + Convert.ToInt32(selectedID);
                    if (DbHelperSQL.ExecuteSql(sqlstr) != 0)
                    {
                        databind();
                        Alert.Show("操作成功");
                    }
                    else
                    {
                        databind();
                        Alert.Show("操作失败");
                    }
                }
                else
                {
                    //string[] a=new string[1];
                    //a[0]="13661888094";
                    // SMS.MobileSMS sms= new SMS.MobileSMS();
                    // bool r = true;
                    //  r = sms.SendSms(a, "hello");
                    Alert.Show("该项目已经提交，无需重复提交");
                }

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }
    }
}