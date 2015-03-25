<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SZPX_YXGL.aspx.cs" Inherits="XMGL.Web.admin.SZPX_YXGL" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            if (/msie/.test(navigator.userAgent.toLowerCase())) {
                alert('系统暂不支持IE内核模式的浏览器，请使用谷歌，火狐浏览器或遨游，360浏览器的极速模式');
            }

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
    <f:Panel ID="Panel7" runat="server" BodyPadding="5px" Title="申报项目管理" ShowBorder="false"
        ShowHeader="True" Layout="VBox" BoxConfigAlign="Stretch">
        <Toolbars>
            <f:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <%-- <f:DropDownList ID="DropDownList1" runat="server" Label="选择项目大类"></f:DropDownList>
                            
                                <f:Button ID="Button_sy" Text="确定" runat="server" OnClick="Button_sy_Click" >
                                </f:Button>--%>
                    <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                    </f:ToolbarSeparator>
                    <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                    </f:HyperLink>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound"
                OnRowCommand="Grid1_RowCommand">
                <Columns>
                    <f:RowNumberField ColumnID="Panel7_Grid1_ctl08" HeaderText="" />
                    <f:BoundField Width="100px" DataField="XMBH" HeaderText="项目编号" ColumnID="XMBH" />
                    <f:BoundField Width="100px" DataField="XMDL" HeaderText="项目大类" ColumnID="XMDL" />
                    <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称" ColumnID="XMMC"
                        DataToolTipField="XMMC" />
                    <f:BoundField Width="200px" DataField="DWMC" HeaderText="单位名称" ColumnID="DWMC"
                        DataToolTipField="DWMC" />
                    
                    
                     <f:TemplateField HeaderText="附件：项目预算明细" Width="150px" ColumnID="Panel7_Grid1_ctl16">
                        <ItemTemplate>
                            <a href='upload/师资培训_附件/<%# Eval("FJYSMX")%>' target="_blank" title='<%# Eval("FJYSMX")%>'>
                                <%# Eval("FJYSMX").ToString().Substring(Eval("FJYSMX").ToString().IndexOf("_") + 1)%></a>
                        </ItemTemplate>
                    </f:TemplateField>




                    <f:BoundField Width="100px" DataField="TBRQ" HeaderText="填表日期" ColumnID="TBRQ"
                        DataToolTipField="TBRQ" />
                    <f:TemplateField HeaderText="状态" ColumnID="Panel7_Grid1_ctl17">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                        </ItemTemplate>
                    </f:TemplateField>
                    <f:LinkButtonField ColumnID="view" CommandName="view" HeaderText="操作" Text="查看项目申报书"
                        Width="150px" ToolTip="查看项目申报书" />
                    <f:LinkButtonField ColumnID="submit" CommandName="submit" HeaderText="操作" Text="提交到市教委"
                        Width="150px" ToolTip="提交到市教委" ConfirmText="确定提交？" />
                    <f:LinkButtonField ColumnID="back" CommandName="back" HeaderText="操作" Text="退回到项目申报人"
                        Width="150px" ToolTip="退回到项目申报人" ConfirmText="确定退回？" />
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
