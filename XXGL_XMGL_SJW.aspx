<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XXGL_XMGL_SJW.aspx.cs" Inherits="XMGL.Web.admin.XXGL_XMGL_SJW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="申报项目管理(信息管理平台)" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
             <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                              
                                <f:DropDownList ID="DropDownList2" runat="server" Label="选择学校"></f:DropDownList>
                                <f:Button ID="Button_sy" Text="确定" runat="server" OnClick="Button_sy_Click" >
                                </f:Button>
                              
                                 <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                                </f:HyperLink>
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
            <Items>
                 
                <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                    DataKeyNames="ID,XMBH,ZT,XMMC" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound" OnRowCommand="Grid1_RowCommand">
                  
                    <Columns>
                       <f:RowNumberField ColumnID="Panel7_Grid1_ctl08" HeaderText="" />
                        <f:BoundField Width="100px" DataField="XMBH" HeaderText="项目编号" ColumnID="Panel7_Grid1_ctl09" />
                         <f:BoundField Width="100px" DataField="XMDL"  HeaderText="项目大类"  ColumnID="Panel7_Grid1_ctl12" />
                       <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称" ColumnID="Panel7_Grid1_ctl11" DataToolTipField="XMMC" />
                        <f:BoundField Width="150px" DataField="JFYS_ZXJF" HeaderText="申请专项经费(万元)" ColumnID="Panel7_Grid1_ctl13" DataFormatString="{0:N2}" />
                        <f:BoundField Width="150px" DataField="JFYS_XXPTJF" HeaderText="学校配套经费(万元)" ColumnID="Panel7_Grid1_ctl14" DataFormatString="{0:N2}" />
                        <f:TemplateField HeaderText="项目预算明细附件" Width="150px" ColumnID="Panel7_Grid1_ctl116">
                            <ItemTemplate>
                                <a href='upload/项目预算明细/<%# Eval("XMYSMXWJM")%>' target="_blank" title='<%# Eval("XMYSMXWJM")%>'><%# Eval("XMYSMXWJM").ToString().Substring( Eval("XMYSMXWJM").ToString().IndexOf("_")+1)%></a>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="状态" ColumnID="Panel7_Grid1_ctl17">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                      
                    </Columns>
                </f:Grid>


               
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="600px" Height="450px">
          
        </f:Window>

    </form>
</body>
</html>
