using AppBox;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMGL.Web.admin.Savant
{
    public partial class Savant_Modify : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
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
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            NationBind();
            XLBind();
            XWBind();
            MajorBind(Experts_BYZY);
            MajorBind(Experts_ZYEJDL);
            LXBind();
            LYBind();
            if (Request.QueryString["id"] != null)
            {
                int _id = int.Parse(Request.QueryString["id"]);
                zjb_model = zjb_bll.GetModel(_id);
                Experts_Name.Text = zjb_model.Experts_Name;
                if (!string.IsNullOrEmpty(zjb_model.Experts_Sex))
                {
                    Experts_Sex.SelectedValue = zjb_model.Experts_Sex;
                }
                Experts_Birthday.Text = zjb_model.Experts_Birthday;
                if (!string.IsNullOrEmpty(zjb_model.Experts_Nation.ToString()))
                {
                    Experts_Nation.SelectedValue = zjb_model.Experts_Nation.ToString();
                }
                Experts_Telphone.Text = zjb_model.Experts_Telphone;
                Experts_Mobil.Text = zjb_model.Experts_Mobil;
                Experts_CZ.Text = zjb_model.Experts_CZ;
                Experts_Email.Text = zjb_model.Experts_Email;
                Experts_PostCode.Text = zjb_model.Experts_PostCode;
                if (!string.IsNullOrEmpty(zjb_model.Experts_XL.ToString()))
                {
                    Experts_XL.SelectedValue = zjb_model.Experts_XL.ToString();
                }
                if (!string.IsNullOrEmpty(zjb_model.Experts_XW.ToString()))
                {
                    Experts_XW.SelectedValue = zjb_model.Experts_XW.ToString();
                }
                if (!string.IsNullOrEmpty(zjb_model.Experts_ZJLX.ToString()))
                {
                    Experts_ZJLX.SelectedValue = zjb_model.Experts_ZJLX.ToString();
                }
                if (!string.IsNullOrEmpty(zjb_model.Experts_ZJLY.ToString()))
                {
                    Experts_ZJLY.SelectedValue = zjb_model.Experts_ZJLY.ToString();
                }
                Experts_BYYX.Text = zjb_model.Experts_BYYX;
                if (!string.IsNullOrEmpty(zjb_model.Experts_BYZY.ToString()))
                {
                    Experts_BYZY.SelectedValue = zjb_model.Experts_BYZY.ToString();
                }
                Experts_BYSJ.Text = zjb_model.Experts_BYSJ;
                Experts_SSDW.Text = zjb_model.Experts_SSDW;
                Experts_SSDWDZ.Text = zjb_model.Experts_SSDWDZ;
                Experts_ZW.Text = zjb_model.Experts_ZW;
                Experts_ZC.Text = zjb_model.Experts_ZC;
                //Experts_ZYDL.Text=zjb_model.Experts_ZYDL;
                if (!string.IsNullOrEmpty(zjb_model.Experts_ZYEJDL.ToString()))
                {
                    Experts_ZYEJDL.SelectedValue = zjb_model.Experts_ZYEJDL.ToString();
                }
                Experts_GJCB.Text = zjb_model.Experts_GJCB;
                Experts_DBXCG.Text = zjb_model.Experts_DBXCG;
                Experts_JYJXJL.Text = zjb_model.Experts_JYJXJL;
                Experts_ZJJL.Text = zjb_model.Experts_ZJJL;
                Experts_KTJL.Text = zjb_model.Experts_KTJL;
            }
        }
        //绑定民族
        private void NationBind()
        {
            DataTable dt = mz_bll.GetList(" MZ_Mode=1").Tables[0];
            Experts_Nation.DataTextField = "MZ_Name";
            Experts_Nation.DataValueField = "MZ_ID";
            Experts_Nation.DataSource = dt;
            Experts_Nation.DataBind();
            Experts_Nation.Items.Insert(0, new FineUI.ListItem("-请选择民族-", ""));
            Experts_Nation.SelectedValue = "";
        }

        //绑定学学历
        private void XLBind()
        {
            DataTable dt = xl_bll.GetList(" XL_Mode=1").Tables[0];
            Experts_XL.DataTextField = "XL_Name";
            Experts_XL.DataValueField = "XL_ID";
            Experts_XL.DataSource = dt;
            Experts_XL.DataBind();
            Experts_XL.Items.Insert(0, new FineUI.ListItem("-请选择学历-", ""));
            Experts_XL.SelectedValue = "";
        }

        //绑定学位
        private void XWBind()
        {
            DataTable dt = xw_bll.GetList(" XW_Mode=1").Tables[0];
            Experts_XW.DataTextField = "XW_Name";
            Experts_XW.DataValueField = "XW_ID";
            Experts_XW.DataSource = dt;
            Experts_XW.DataBind();
            Experts_XW.Items.Insert(0, new FineUI.ListItem("-请选择学位-", ""));
            Experts_XW.SelectedValue = "";
        }

        //绑定专业
        private void MajorBind(FineUI.DropDownList _dropdownlist)
        {
            DataTable dt = major_bll.GetList("").Tables[0];
            _dropdownlist.DataTextField = "Majors_Name";
            _dropdownlist.DataValueField = "Majors_ID";
            _dropdownlist.DataSource = dt;
            _dropdownlist.DataBind();
            _dropdownlist.Items.Insert(0, new FineUI.ListItem("-请选择专业-", "-1"));
            _dropdownlist.SelectedValue = "-1";
        }

        //绑定专家类型
        private void LXBind()
        {
            DataTable dt = zjlx_bll.GetList(" ZJLX_Mode=1").Tables[0];
            Experts_ZJLX.DataTextField = "ZJLX_Name";
            Experts_ZJLX.DataValueField = "ZJLX_ID";
            Experts_ZJLX.DataSource = dt;
            Experts_ZJLX.DataBind();
            Experts_ZJLX.Items.Insert(0, new FineUI.ListItem("-请选择专家类型-", "-1"));
            Experts_ZJLX.SelectedValue = "-1";
        }

        //绑定专家来源
        private void LYBind()
        {
            DataTable dt = zjly_bll.GetList(" ZJLY_Mode=1").Tables[0];
            Experts_ZJLY.DataTextField = "ZJLY_Name";
            Experts_ZJLY.DataValueField = "ZJLY_ID";
            Experts_ZJLY.DataSource = dt;
            Experts_ZJLY.DataBind();
            Experts_ZJLY.Items.Insert(0, new FineUI.ListItem("-请选择专家来源-", "-1"));
            Experts_ZJLY.SelectedValue = "-1";
        }

        #endregion

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            if (Experts_ZJLX.SelectedValue == "-1")
            {
                Alert.Show("请选择专家类型！", MessageBoxIcon.Warning);
                return;
            }
            if (Experts_ZJLY.SelectedValue == "-1")
            {
                Alert.Show("请选择专家来源！", MessageBoxIcon.Warning);
                return;
            }
            if (Experts_BYZY.SelectedValue == "-1")
            {
                Alert.Show("请选择毕业专业！", MessageBoxIcon.Warning);
                return;
            }
            if (Experts_ZYEJDL.SelectedValue == "-1")
            {
                Alert.Show("请选择专业领域！", MessageBoxIcon.Warning);
                return;
            }
            if (Request.QueryString["id"] != null)
            {
                int _id = Convert.ToInt32(Request.QueryString["id"]);
                zjb_model = zjb_bll.GetModel(_id);
            }

            zjb_model.Experts_Name = Experts_Name.Text.Trim();
            if (Experts_Sex.SelectedValue == "男" || Experts_Sex.SelectedValue == "女")
            {
                zjb_model.Experts_Sex = Experts_Sex.SelectedValue;
            }
            zjb_model.Experts_Birthday = Experts_Birthday.SelectedDate.HasValue ? Experts_Birthday.SelectedDate.Value.ToString("yyyyMMdd") : "Empty";
            if (!string.IsNullOrEmpty(Experts_Nation.SelectedValue))
            {
                zjb_model.Experts_Nation = int.Parse(Experts_Nation.SelectedValue);
            }
            zjb_model.Experts_Telphone = Experts_Telphone.Text.Trim();
            zjb_model.Experts_Mobil = Experts_Mobil.Text.Trim();
            zjb_model.Experts_CZ = Experts_CZ.Text.Trim();
            zjb_model.Experts_Email = Experts_Email.Text.Trim();
            zjb_model.Experts_PostCode = Experts_PostCode.Text.Trim();
            if (!string.IsNullOrEmpty(Experts_XL.SelectedValue))
            {
                zjb_model.Experts_XL = int.Parse(Experts_XL.SelectedValue);
            }
            if (!string.IsNullOrEmpty(Experts_XW.SelectedValue))
            {
                zjb_model.Experts_XW = int.Parse(Experts_XW.SelectedValue);
            }
            if (Experts_ZJLX.SelectedValue != "-1")
            {
                zjb_model.Experts_ZJLX = int.Parse(Experts_ZJLX.SelectedValue);
            }
            if (Experts_ZJLY.SelectedValue != "-1")
            {
                zjb_model.Experts_ZJLY = int.Parse(Experts_ZJLY.SelectedValue);
            }
            zjb_model.Experts_BYYX = Experts_BYYX.Text.Trim();
            if (Experts_ZJLY.SelectedValue != "-1")
            {
                zjb_model.Experts_BYZY = int.Parse(Experts_BYZY.SelectedValue.Trim());
            }
            zjb_model.Experts_BYSJ = Experts_BYSJ.SelectedDate.HasValue ? Experts_BYSJ.SelectedDate.Value.ToString("yyyyMMdd") : "";
            zjb_model.Experts_SSDW = Experts_SSDW.Text.Trim();
            zjb_model.Experts_SSDWDZ = Experts_SSDWDZ.Text.Trim();
            zjb_model.Experts_ZW = Experts_ZW.Text.Trim();
            zjb_model.Experts_ZC = Experts_ZC.Text.Trim();
            if (Experts_ZYEJDL.SelectedValue != "-1")
            {
                zjb_model.Experts_ZYEJDL = int.Parse(Experts_ZYEJDL.SelectedValue);
                zy_model = zy_bll.GetModel(int.Parse(Experts_ZYEJDL.SelectedValue));
                zjb_model.Experts_ZYDL = zy_model.Majors_ParentID;
            }
            zjb_model.Experts_GJCB = Experts_GJCB.Text.Trim();
            zjb_model.Experts_DBXCG = Experts_DBXCG.Text.Trim();
            zjb_model.Experts_JYJXJL = Experts_JYJXJL.Text.Trim();
            zjb_model.Experts_ZJJL = Experts_ZJJL.Text.Trim();
            zjb_model.Experts_KTJL = Experts_KTJL.Text.Trim();
            zjb_model.Experts_OPUID = pb.GetIdentityId();
            zjb_model.Experts_OPUTIME = DateTime.Now;
            bool _flag = zjb_bll.Update(zjb_model);
            if (_flag)
            {
                Alert.Show("修改成功！", MessageBoxIcon.Information);
                // 2. 关闭本窗体，然后刷新父窗体
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
            else
            {
                Alert.Show("修改失败！", MessageBoxIcon.Warning);
            }

            
        }
    }
}