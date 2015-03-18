using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMGL.Web.admin
{
    public partial class XM_YLFW_TBSM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                div2.Style["display"] = "none";
                div1.Style["display"] = "block";
            }
        }

        protected void button_ServerClick(object sender, EventArgs e)
        {
            div1.Style["display"] = "none";
            div2.Style["display"] = "block";
        }

        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("XM_YLFW_Add.aspx");
        }
    }
}