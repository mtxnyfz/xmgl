<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HZBLXR_AddorUp.aspx.cs" Inherits="XMGL.Web.admin.HZBLXR_AddorUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="../res/js/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
   <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
         <f:Panel ID="Panel1" runat="server" BodyPadding="5px"
            Title="生成项目汇总表" ShowBorder="false" ShowHeader="true"
            AutoScroll="true" Height="500px"  BoxConfigAlign="Stretch">
            <Items>
                 <f:SimpleForm  ID="Form2"  BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server">
                    <Items>
                         <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                <f:TextBox ID="TextBox_lxr" Label="联系人" Margin="0 5 2 2" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server">
                                </f:TextBox>
                                 <f:TextBox ID="TextBox_dh" Label="电话" Margin="0 5 2 0" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_sj" Label="手机" Margin="0 5 2 0" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Regex="^1[3|4|5|8][0-9]\d{8}$" RegexMessage="请填写正确的手机号码">
                                </f:TextBox>
                                 <f:TextBox ID="TextBox_cz" Label="传真" Margin="0 5 2 0" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server">
                                </f:TextBox>
                            </Items>
                        </f:Panel>
                         <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                <f:TextBox ID="TextBox1" Label="电子邮箱" Margin="0 5 2 2" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" RegexPattern="EMAIL">
                                </f:TextBox>
                                 <f:TextBox ID="TextBox2" Label="地址" Margin="0 5 2 0" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox3" Label="邮编" Margin="0 5 2 0" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server" >
                                </f:TextBox>
                               
                            </Items>
                        </f:Panel>
                        </Items>
                       <Toolbars>
                <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button2" Text="保存并生成项目汇总表" ValidateForms="Form2" ValidateMessageBox="true" runat="server" OnClick="Button2_Click">
                        </f:Button>
                        <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                                </f:HyperLink>
                    </Items>
                </f:Toolbar>
            </Toolbars>
                        </f:SimpleForm>
            </Items>
             </f:Panel>
    </form>
     <script type="text/javascript">

         function CloseWebPage() {
             if (navigator.userAgent.indexOf("MSIE") > 0) {
                 if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {
                     window.opener = null;
                     window.close();
                 } else {
                     window.open('', '_top');
                     window.top.close();
                 }
             }
             else if (navigator.userAgent.indexOf("Firefox") > 0) {
                 window.location.href = 'about:blank ';
             } else {
                 window.opener = null;
                 window.open('', '_self', '');
                 window.close();
             }

         }
    </script>
</body>
</html>
