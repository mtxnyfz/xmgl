<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YJFK_Add.aspx.cs" Inherits="XMGL.Web.admin.YJFK_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
    
    <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="SimpleForm" LabelWidth="100px" 
        Width="600px" >
        
        <Rows>
           
              <f:FormRow ID="FormRow3" runat="server">
            <Items>
                 
                <f:Label ID="Label_xmmc" runat="server" Label="项目名称" Text="">
                </f:Label>
                  
             </Items>
            </f:FormRow>
           
            

             <f:FormRow ID="FormRow4" runat="server">
            <Items>
                   <f:TextArea ID="TextArea_yj" runat="server" Height="150px" Label="意见1" 
                   
                       Width="550px">
                 </f:TextArea>
                  
             </Items>
            </f:FormRow>


             

        </Rows>
         <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server" >
                <Items>
                  
                 
                    <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                        runat="server" Text="确定退回">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
    </f:Form>
   <f:HiddenField ID="hd_xmfkyj_id" runat="server">
    </f:HiddenField>
    <f:HiddenField ID="hd_xmfkyj_fzr" runat="server">
    </f:HiddenField>
    
   
    </form>
</body>
</html>
