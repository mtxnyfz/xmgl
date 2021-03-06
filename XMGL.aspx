﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL.aspx.cs" Inherits="XMGL.Web.admin.XMGL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="申报项目管理" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                
                <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                    DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound" OnRowCommand="Grid1_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                             <%--   <f:Button ID="btnCheckSelection" Text="申报项目" runat="server" OnClick="btnCheckSelection_Click">
                                </f:Button>--%>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                               <%-- <f:Button ID="btnConfirmButton" Text="修改项目" runat="server" OnClick="btnConfirmButton_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                                 <f:Button ID="Button3" Text="在线查看项目申报书" runat="server" OnClick="Button3_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button4" Text="导出成word文件" runat="server"  OnClick="Button4_Click" Icon="PageWord" Hidden="true">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button1" Text="删除项目" runat="server" OnClick="Button1_Click" ConfirmText="确定删除？">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button2" Text="提交" runat="server" OnClick="Button2_Click" ConfirmText="确定提交？">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                </f:ToolbarSeparator>--%>
                                 <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                                </f:HyperLink>
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel7_Grid1_ctl08"  HeaderText=""/>
                        <f:BoundField Width="100px" DataField="XMBH"  HeaderText="项目编号"  ColumnID="Panel7_Grid1_ctl09" />
                      
                       <f:BoundField Width="100px" DataField="XMDL"  HeaderText="项目大类"  ColumnID="Panel7_Grid1_ctl12" />
                        <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称"  ColumnID="Panel7_Grid1_ctl11" DataToolTipField="XMMC" />
                     <%--  <f:BoundField Width="130px" DataField="ZYMC" HeaderText="专业名称"  ColumnID="Panel7_Grid1_ctl12" />--%>
                          <f:BoundField Width="150px" DataField="SQZXJF" HeaderText="申请专项经费(万元)"  ColumnID="Panel7_Grid1_ctl13" DataFormatString="{0:N2}"/>
                           <f:BoundField Width="150px" DataField="XXPTJF" HeaderText="学校配套经费(万元)"  ColumnID="Panel7_Grid1_ctl14" DataFormatString="{0:N2}"/>
                         <f:TemplateField HeaderText="项目可行性分析报告" Width="150px"  ColumnID="Panel7_Grid1_ctl15" >
                    <ItemTemplate>
                      <a href='upload/项目可行性分析报告/<%# Eval("XMKXXFXBGWJM")%>' target="_blank" title='<%# Eval("XMKXXFXBGWJM")%>'><%# Eval("XMKXXFXBGWJM").ToString().Substring( Eval("XMKXXFXBGWJM").ToString().IndexOf("_")+1)%></a>
                    </ItemTemplate>

                </f:TemplateField>
                         <f:TemplateField HeaderText="优秀学生案例"  Width="150px"  ColumnID="Panel7_Grid1_ctl16">
                    <ItemTemplate>
                       <a href='upload/优秀学生案例/<%# Eval("YXXSALWJM")%>' target="_blank" title='<%# Eval("YXXSALWJM")%>'><%# Eval("YXXSALWJM").ToString().Substring( Eval("YXXSALWJM").ToString().IndexOf("_")+1)%></a>
                    </ItemTemplate>

                </f:TemplateField >
                         <f:TemplateField HeaderText="项目预算明细"  Width="150px"  ColumnID="Panel7_Grid1_ctl116">
                    <ItemTemplate>
                       <a href='upload/项目预算明细/<%# Eval("XMYSMXWJM")%>' target="_blank" title='<%# Eval("XMYSMXWJM")%>'><%# Eval("XMYSMXWJM").ToString().Substring( Eval("XMYSMXWJM").ToString().IndexOf("_")+1)%></a>
                    </ItemTemplate>

                </f:TemplateField >
                     <f:TemplateField HeaderText="状态"  ColumnID="Panel7_Grid1_ctl17">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                         <f:LinkButtonField ColumnID="xq1" CommandName="xq" HeaderText="操作" Text="查看项目申报书" ToolTip="查看项目申报书"   Width="150px"/>
                          <f:LinkButtonField ColumnID="up1" CommandName="up" HeaderText="操作" Text="修改"   Width="80px"/>
                         <f:LinkButtonField ColumnID="xq2" CommandName="tj" HeaderText="操作" Text="提交" Width="80px" ConfirmText="提交后将不能修改，确定提交？"/>
                        <f:LinkButtonField ColumnID="xq3" CommandName="del" HeaderText="操作" Text="删除" Width="80px" ConfirmText="确定删除？"/>
                    </Columns>
                </f:Grid>

                <f:Grid ID="Grid2" Title="Grid2" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                    DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid2_PageIndexChange" OnRowDataBound="Grid2_RowDataBound" OnRowCommand="Grid2_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar_WHCC1" runat="server">
                           <Items>
                                 <f:HyperLink ID="HyperLink_WHCC2" Text="" Target="_blank" NavigateUrl="" runat="server">
                                </f:HyperLink>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel7_WHCC1"  HeaderText=""/>
                        <f:BoundField Width="100px" DataField="XMBH"  HeaderText="项目编号"  ColumnID="Panel7_WHCC2" />
                       <f:BoundField Width="100px" DataField="XMDL"  HeaderText="项目大类"  ColumnID="Panel7_WHCC3" />
                         
                       <f:BoundField Width="100px" DataField="ZYDM"  HeaderText="专业代码"  ColumnID="Panel7_WHCC_ctl12" />
                        <f:BoundField Width="200px" DataField="ZYMCFX" HeaderText="专业名称"  ColumnID="Panel7_WHCC_ctl11" DataToolTipField="ZYMC" />
                   <f:BoundField Width="150px" DataField="DTR_XM" HeaderText="专业带头人姓名"  ColumnID="Panel7_WHCC_ctl13"  />
                     <f:TemplateField HeaderText="状态"  ColumnID="Panel7_WHCC7">
                    <ItemTemplate>
                        <asp:Label ID="Label_WHCC2" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                         <f:LinkButtonField ColumnID="WHCC_xq1" CommandName="xq" HeaderText="操作" Text="查看项目申报书" ToolTip="查看项目申报书"   Width="150px"/>
                          <f:LinkButtonField ColumnID="WHCC_up1" CommandName="up" HeaderText="操作" Text="修改"   Width="80px"/>
                         <f:LinkButtonField ColumnID="WHCC_xq2" CommandName="tj" HeaderText="操作" Text="提交" Width="80px" ConfirmText="提交后将不能修改，确定提交？"/>
                        <f:LinkButtonField ColumnID="WHCC_xq3" CommandName="del" HeaderText="操作" Text="删除" Width="80px" ConfirmText="确定删除？"/>
                    </Columns>
                </f:Grid>

                  <f:Grid ID="Grid2_ylfw" Title="Grid2_ylfw" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                    DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid2_ylfw_PageIndexChange" OnRowDataBound="Grid2_ylfw_RowDataBound" OnRowCommand="Grid2_ylfw_RowCommand">
                   
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel7_Grid2_ylfw_ctl08"  HeaderText=""/>
                         <f:BoundField Width="200px" DataField="YLFW"  HeaderText="项目大类"  ColumnID="Panel7_Grid2_ylfw_ctl14" />
                        <f:BoundField Width="100px" DataField="XMBH"  HeaderText="项目编号"  ColumnID="Panel7_Grid2_ylfw_ctl09" />
                      
                       <f:BoundField Width="100px" DataField="ZYDM"  HeaderText="专业代码"  ColumnID="Panel7_Grid2_ylfw_ctl12" />
                        <f:BoundField Width="200px" DataField="ZYMC" HeaderText="专业名称"  ColumnID="Panel7_Grid2_ylfw_ctl11" DataToolTipField="ZYMC" />
                   <f:BoundField Width="150px" DataField="ZYDTRXM" HeaderText="专业带头人姓名"  ColumnID="Panel7_Grid2_ylfw_ctl13"  />
                       

              
                     <f:TemplateField HeaderText="状态"  ColumnID="Panel7_Grid2_ylfw_ctl17">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                         <f:LinkButtonField ColumnID="xq11" CommandName="xq" HeaderText="操作" Text="查看项目申报书" ToolTip="查看项目申报书"   Width="150px"/>
                          <f:LinkButtonField ColumnID="up11" CommandName="up" HeaderText="操作" Text="修改"   Width="80px"/>
                         <f:LinkButtonField ColumnID="xq21" CommandName="tj" HeaderText="操作" Text="提交" Width="80px" ConfirmText="提交后将不能修改，确定提交？"/>
                        <f:LinkButtonField ColumnID="xq31" CommandName="del" HeaderText="操作" Text="删除" Width="80px" ConfirmText="确定删除？"/>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="1050px" Height="550px" >
          
        </f:Window>

    </form>
</body>
</html>
