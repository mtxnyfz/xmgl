﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMFL.aspx.cs" Inherits="XMGL.Web.admin.XMFL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
    
    <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="SimpleForm" LabelWidth="100px" Width="300px" >
        
        <Rows>
          
            <%--  <f:FormRow ID="FormRow3" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_name" runat="server" Label="姓名" Text="" Required="true" ShowRedStar="true">
                </f:TextBox>
                  
             </Items>
            </f:FormRow>--%>

          <%--  <f:FormRow ID="FormRow7" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_tel" runat="server" Label="联系电话" Text="" Required="true" ShowRedStar="true">
                </f:TextBox>
                  
             </Items>
             </f:FormRow>--%>
             <f:FormRow ID="FormRow5" runat="server">
            <Items>
                 
                <f:DropDownList ID="DropDownList_xmfl" runat="server" Label="选择项目大类" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_xmfl_SelectedIndexChanged" 
                    >
                     
                   <%-- <f:ListItem Text="请选择" Value="请选择" />
                    <f:ListItem Text="一流专业" Value="一流专业" />--%>
                     
                </f:DropDownList>
               
            </Items>
                
            </f:FormRow>

          


             

        </Rows>
        
    </f:Form>
   <f:HiddenField ID="HiddenField_bm" runat="server">
    </f:HiddenField>
   
    </form>
</body>
</html>
