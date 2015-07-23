using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
namespace XMGL.Web.admin
{
    public partial class upload : System.Web.UI.Page
    {
        public  string lx ="";
        public string extensions = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["lx"] != null)
                {
                    lx = Request.QueryString["lx"].ToString();
                    extensions = Request.QueryString["extensions"].ToString();
                }
            }
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}