using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMGL.Web.admin.Savant
{
    public partial class Savant_Show : System.Web.UI.Page
    {
        Model.XMGL_MZDMB mz_model = new Model.XMGL_MZDMB();
        BLL.XMGL_MZDMB mz_bll = new BLL.XMGL_MZDMB();

        Model.XMGL_XLDMB xl_model = new Model.XMGL_XLDMB();
        BLL.XMGL_XLDMB xl_bll = new BLL.XMGL_XLDMB();

        Model.XMGL_XWDMB xw_model = new Model.XMGL_XWDMB();
        BLL.XMGL_XWDMB xw_bll = new BLL.XMGL_XWDMB();

        Model.XMGL_ZYDMB major_model = new Model.XMGL_ZYDMB();
        BLL.XMGL_ZYDMB major_bll = new BLL.XMGL_ZYDMB();

        Model.XMGL_ZJLXB zjlx_model = new Model.XMGL_ZJLXB();
        BLL.XMGL_ZJLXB zjlx_bll = new BLL.XMGL_ZJLXB();

        Model.XMGL_ZJLYB zjly_model = new Model.XMGL_ZJLYB();
        BLL.XMGL_ZJLYB zjly_bll = new BLL.XMGL_ZJLYB();

        Model.XMGL_ZJB zjb_model = new Model.XMGL_ZJB();
        BLL.XMGL_ZJB zjb_bll = new BLL.XMGL_ZJB();

        Model.XMGL_ZYDMB zy_model = new Model.XMGL_ZYDMB();
        BLL.XMGL_ZYDMB zy_bll = new BLL.XMGL_ZYDMB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        #region LoadData

        private void LoadData()
        {
            if (Request.QueryString["id"] != null)
            {
                int _id = int.Parse(Request.QueryString["id"]);
                zjb_model = zjb_bll.GetModel(_id);
                Experts_Name.Text = zjb_model.Experts_Name;
                Experts_Sex.Text = zjb_model.Experts_Sex;
                Experts_Birthday.Text = zjb_model.Experts_Birthday;
                int a = Convert.ToInt32(zjb_model.Experts_Nation);
                Experts_Nation.Text = getNation(a);
                Experts_Telphone.Text = zjb_model.Experts_Telphone;
                Experts_Mobil.Text = zjb_model.Experts_Mobil;
                Experts_CZ.Text = zjb_model.Experts_CZ;
                Experts_Email.Text = zjb_model.Experts_Email;
                Experts_PostCode.Text = zjb_model.Experts_PostCode;
                //Experts_Photo.Text = zjb_model.Experts_Photo;
                Experts_XL.Text = getXL(Convert.ToInt32(zjb_model.Experts_XL));
                Experts_XW.Text = getXW(Convert.ToInt32(zjb_model.Experts_XW));
                Experts_ZJLX.Text = getZJLX(Convert.ToInt32(zjb_model.Experts_ZJLX));
                Experts_ZJLY.Text = getZJLX(Convert.ToInt32(zjb_model.Experts_ZJLY));
                Experts_BYYX.Text = zjb_model.Experts_BYYX;
                Experts_BYZY.Text = getMajor(Convert.ToInt32(zjb_model.Experts_BYZY));
                Experts_BYSJ.Text = zjb_model.Experts_BYSJ;
                Experts_SSDW.Text = zjb_model.Experts_SSDW;
                Experts_SSDWDZ.Text = zjb_model.Experts_SSDWDZ;
                Experts_ZW.Text = zjb_model.Experts_ZW;
                Experts_ZC.Text = zjb_model.Experts_ZC;
                Experts_ZYDL.Text=major_bll.GetModel(Convert.ToInt32(zjb_model.Experts_ID)).Majors_Name;
                Experts_ZYEJDL.Text = getMajor(Convert.ToInt32(zjb_model.Experts_ZYEJDL));
                Experts_GJCB.Text = zjb_model.Experts_GJCB;
                Experts_DBXCG.Text = zjb_model.Experts_DBXCG;
                Experts_JYJXJL.Text = zjb_model.Experts_JYJXJL;
                Experts_ZJJL.Text = zjb_model.Experts_ZJJL;
                Experts_KTJL.Text = zjb_model.Experts_KTJL;
            }
        }

        private string getNation(int id)
        {
            mz_model = mz_bll.GetModel(id);
            if (mz_model != null)
            {
                return mz_model.MZ_Name;
            }
            else
                return "";
        }

        private string getXL(int id)
        {
            xl_model = xl_bll.GetModel(id);
            if (xl_model != null)
            {
                return xl_model.XL_Name;
            }
            else
                return "";
        }

        private string getXW(int id)
        {
            xw_model = xw_bll.GetModel(id);
            if (xw_model != null)
                return xw_model.XW_Name;
            else
                return "";
        }

        private string getZJLX(int id)
        {
            zjlx_model = zjlx_bll.GetModel(id);
            if (zjlx_model != null)
                return zjlx_model.ZJLX_Name;
            else
                return "";
        }

        private string getZJLY(int id)
        {
            zjly_model = zjly_bll.GetModel(id);
            if (zjly_model != null)
                return zjly_model.ZJLY_Name;
            else
                return "";
        }

        private string getMajor(int id)
        {
            major_model = major_bll.GetModel(id);
            if (major_model != null)
                return major_model.Majors_Name;
            else
                return "";
        }
        
        #endregion
    }
}