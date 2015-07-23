<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Savant_List.aspx.cs" Inherits="XMGL.Web.admin.Savant.Savant_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" Title="专家列表" EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
            AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
            DataKeyNames="Experts_ID,Experts_Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
            AllowSorting="true" SortField="Experts_Name" SortDirection="ASC"
            OnSort="Grid1_Sort">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnNew" Text="新增" Icon="Add" EnablePostBack="false" runat="server"></f:Button>
                        <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" OnClick="btnDelete_Click" runat="server"></f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server"></f:ToolbarFill>
                        <f:DropDownList runat="server" Label="专家类型" ID="Experts_ZJLX" EnableEdit="true" ForceSelection="true" BoxFlex="3"></f:DropDownList>
                        <f:DropDownList runat="server" Label="专家来源" ID="Experts_ZJLY" EnableEdit="true" ForceSelection="true" BoxFlex="3"></f:DropDownList>
                        <f:TextBox ID="Experts_Name" Label="姓名" CssClass="marginr" runat="server">
                        </f:TextBox>
                        <f:Button ID="btnSelect" Text="筛选查询" runat="server" OnClick="btnSelect_Click"
                            CssClass="marginr" />
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField />
                <f:TemplateField Width="100px" SortField="Experts_ZJLX" HeaderText="专家类型">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetZJLX(Eval("Experts_ZJLX")) %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:TemplateField Width="100px" SortField="Experts_ZJLY" HeaderText="专家来源">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# GetZJLY(Eval("Experts_ZJLY")) %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField Width="100px" DataField="Experts_Name" SortField="Experts_Name" DataFormatString="{0}"
                    HeaderText="姓名" />
                <f:BoundField Width="100px" DataField="Experts_Sex" SortField="Experts_Sex" DataFormatString="{0}"
                    HeaderText="性别" />
                <f:BoundField Width="100px" DataField="Experts_Birthday" SortField="Experts_Birthday" DataFormatString="{0}"
                    HeaderText="出生年月" />
                <f:BoundField Width="100px" DataField="Experts_Mobil" SortField="Experts_Mobil" DataFormatString="{0}"
                    HeaderText="手机" />
                <f:BoundField Width="100px" DataField="Experts_Mobil" SortField="Experts_Mobil" DataFormatString="{0}"
                    HeaderText="电子邮箱" />
                <f:WindowField ColumnID="ViewWindowField" Width="50px" WindowID="Window1" HeaderText="查看"
                    Icon="ApplicationViewDetail" ToolTip="查看" DataTextFormatString="{0}" DataIFrameUrlFields="Experts_ID"
                    DataIFrameUrlFormatString="Savant_Show.aspx?id={0}" DataWindowTitleField="Experts_Name"
                    DataWindowTitleFormatString="查看 - {0}" />
                <f:WindowField ColumnID="EditWindowField" Width="50px" WindowID="Window1" HeaderText="编辑"
                    Icon="ApplicationEdit" ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="Experts_ID"
                    DataIFrameUrlFormatString="Savant_Modify.aspx?id={0}" DataWindowTitleField="Experts_Name"
                    DataWindowTitleFormatString="编辑 - {0}" />
                <%--<f:TemplateField HeaderText="查看" Width="60px">
                    <ItemTemplate>
                        <a href="javascript:<%# GetViewUrl(Eval("Experts_ID")) %>">查看</a>
                    </ItemTemplate>
                </f:TemplateField>
                <f:TemplateField HeaderText="编辑" Width="60px">
                    <ItemTemplate>
                        <a href="javascript:<%# GetEditUrl(Eval("Experts_ID")) %>">编辑</a>
                    </ItemTemplate>
                </f:TemplateField>--%>
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" runat="server" Hidden="true"
            WindowPosition="Center" IsModal="true" Title="Popup Window 1" EnableMaximize="true"
            EnableResize="true" Target="Self" EnableIFrame="true"
            Height="700px" Width="700px" OnClose="Window1_Close">
        </f:Window>
    </form>
</body>
</html>
