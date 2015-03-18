using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_WordMaster_test : System.Web.UI.Page
{
    public static string str { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var tmppath = HttpContext.Current.Server.MapPath("test.doc");
        var savepath = HttpContext.Current.Server.MapPath("1.docx");

        new BuildWord().BuildWord_2015ProjectDeclaration(tmppath, savepath, "2015-01-001");


       

        str = "http://192.168.98.13/wv/wordviewerframe.aspx?WOPISrc=http://" + HttpContext.Current.Request.Url.Authority + "/wopi/files/"+savepath+"?access_token="+Guid.NewGuid()+"";
    }
}