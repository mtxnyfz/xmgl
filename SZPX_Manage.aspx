<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SZPX_Manage.aspx.cs" Inherits="XMGL.Web.admin.SZPX_Manage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../res/js/jquery.min.js" type="text/javascript"></script>
   <%-- <script type="text/javascript">
        $(function () {

            if (/msie/.test(navigator.userAgent.toLowerCase())) {

            }
            else {
                alert('为了能正常播放视频，请使用支持兼容模式的浏览器，如遨游，360等浏览器');
            }

        })
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
    <f:Panel ID="Panel7" runat="server" BodyPadding="5px" Title="申报项目管理" ShowBorder="false"
        ShowHeader="True" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound"
                OnRowCommand="Grid1_RowCommand">
                <Toolbars>
                    <f:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </f:ToolbarSeparator>
                            <%--   <f:Button ID="btnCheckSelection" Text="申报项目" runat="server" OnClick="btnCheckSelection_Click">
                                </f:Button>--%>
                            <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </f:ToolbarSeparator>
                            <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                            </f:HyperLink>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Columns>
                    <f:RowNumberField ColumnID="Panel7_Grid1_ctl08" HeaderText="" />
                    <f:BoundField Width="100px" DataField="XMBH" HeaderText="项目编号" ColumnID="XMBH" />
                    <f:BoundField Width="100px" DataField="XMDL" HeaderText="项目大类" ColumnID="XMDL" />
                    <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称" ColumnID="XMMC" DataToolTipField="XMMC" />
                    <f:BoundField Width="200px" DataField="DWMC" HeaderText="单位名称" ColumnID="DWMC" DataToolTipField="DWMC" />
                    <f:TemplateField HeaderText="附件：项目预算明细" Width="150px" ColumnID="Panel7_Grid1_ctl16">
                        <ItemTemplate>
                            <a href='upload/师资培训_附件/<%# Eval("FJYSMX")%>' target="_blank" title='<%# Eval("FJYSMX")%>'>
                                <%# Eval("FJYSMX").ToString().Substring(Eval("FJYSMX").ToString().IndexOf("_") + 1)%></a>
                        </ItemTemplate>
                    </f:TemplateField>
                    
                    <f:BoundField Width="100px" DataField="TBRQ" HeaderText="填表日期" ColumnID="TBRQ" DataToolTipField="TBRQ" />
                    <f:TemplateField HeaderText="状态" ColumnID="ZT">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                        </ItemTemplate>
                    </f:TemplateField>
                    <f:LinkButtonField ColumnID="view" CommandName="view" HeaderText="操作" Text="查看项目申报书"
                        ToolTip="查看项目申报书" Width="150px" />
                    <f:LinkButtonField ColumnID="update" CommandName="update" HeaderText="操作" Text="修改"
                        Width="80px" />
                    <f:LinkButtonField ColumnID="submit" CommandName="submit" HeaderText="操作" Text="提交"
                        Width="80px" ConfirmText="提交后将不能修改，确定提交？" />
                    <f:LinkButtonField ColumnID="delete" CommandName="delete" HeaderText="操作" Text="删除"
                        Width="80px" ConfirmText="确定删除？" />
                </Columns>
            </f:Grid>
        </Items>
    </f:Panel>
    <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true" EnableMaximize="true"
        Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close" IsModal="true"
        Width="1050px" Height="550px">
    </f:Window>
    </form>
</body>
</html>
