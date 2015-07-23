using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMGL.Web.Highcharts
{
    public partial class Frame_Analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tab1.IFrameUrl = "Origin_Analysis.aspx";
                //tab2.IFrameUrl = "Project_Analysis2.aspx";
                tab3.IFrameUrl = "Project_Analysis.aspx";
            }
        }
    }
}