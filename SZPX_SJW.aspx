<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SZPX_SJW.aspx.cs" Inherits="XMGL.Web.admin.SZPX_SJW" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
    <f:Panel ID="Panel7" runat="server" BodyPadding="5px" Title="申报项目管理(师资培训)" ShowBorder="false"
        ShowHeader="True" Layout="VBox" BoxConfigAlign="Stretch">
        <Toolbars>
            <f:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <f:DropDownList ID="DropDownList2" runat="server" Label="选择学校">
                    </f:DropDownList>
                    <f:Button ID="Button_sy" Text="确定" runat="server" OnClick="Button_sy_Click">
                    </f:Button>
                    <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                    </f:HyperLink>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                DataKeyNames="ID,XMBH,ZT,XMMC" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound"
                OnRowCommand="Grid1_RowCommand">
                <Columns>
                    <f:RowNumberField ColumnID="Panel7_Grid1_ctl08" HeaderText="" />
                    <f:BoundField Width="100px" DataField="XMBH" HeaderText="项目编号" ColumnID="XMBH" />
                    <f:BoundField Width="100px" DataField="XMDL" HeaderText="项目大类" ColumnID="XMDL" />
                    <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称" ColumnID="XMMC" DataToolTipField="XMMC" />


                    
                    <f:TemplateField HeaderText="学校名称" ColumnID="XXMC">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("user_uid")%>'></asp:Label>
                        </ItemTemplate>
                    </f:TemplateField>





                    <f:BoundField Width="200px" DataField="DWMC" HeaderText="单位名称" ColumnID="DWMC" DataToolTipField="DWMC" />


                     <f:TemplateField HeaderText="附件：项目预算明细" Width="150px" ColumnID="Panel7_Grid1_ctl16">
                        <ItemTemplate>
                            <a href='upload/师资培训_附件/<%# Eval("FJYSMX")%>' target="_blank" title='<%# Eval("FJYSMX")%>'>
                                <%# Eval("FJYSMX").ToString().Substring(Eval("FJYSMX").ToString().IndexOf("_") + 1)%></a>
                        </ItemTemplate>
                    </f:TemplateField>


                    <f:BoundField Width="100px" DataField="TBRQ" HeaderText="填表日期" ColumnID="TBRQ" DataToolTipField="TBRQ" />
                    <f:TemplateField HeaderText="状态" ColumnID="Panel7_Grid1_ctl17">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                        </ItemTemplate>
                    </f:TemplateField>
                    <f:LinkButtonField ColumnID="view" CommandName="view" HeaderText="操作" Text="查看项目申报书"
                        Width="150px" ToolTip="查看项目申报书" />
                    <f:LinkButtonField  ColumnID="back"  CommandName="back" HeaderText="操作" Text="退回到项目申报人"
                        ToolTip="退回到项目申报人" Width="150px" />
                </Columns>
            </f:Grid>
        </Items>
    </f:Panel>
    <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true" EnableMaximize="true"
        Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close" IsModal="true"
        Width="600px" Height="450px">
    </f:Window>
    </form>
</body>
</html>
