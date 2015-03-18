<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_SJW.aspx.cs" Inherits="XMGL.Web.admin.XMGL_SJW" %>

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
            Title="申报项目管理" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
             <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                               <f:DropDownList ID="DropDownList1" runat="server" Label="选择项目大类"></f:DropDownList>
                                <f:DropDownList ID="DropDownList2" runat="server" Label="选择学校"></f:DropDownList>
                                <f:Button ID="Button_sy" Text="确定" runat="server" OnClick="Button_sy_Click" >
                                </f:Button>
                                <%--<f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                                 <f:Button ID="Button3" Text="在线查看项目申报书" runat="server" OnClick="Button3_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button4" Text="导出成word文件" runat="server"  OnClick="Button4_Click" Icon="PageWord"  Hidden="true">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                </f:ToolbarSeparator>
                              
                                <f:Button ID="Button2" Text="退回" runat="server" OnClick="Button2_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                </f:ToolbarSeparator>--%>
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
                        <f:RowNumberField  ColumnID="Panel7_Grid1_ctl08"  HeaderText=""/>
                         <f:BoundField Width="150px" DataField="XXMC"  HeaderText="学校名称"  ColumnID="Panel7_Grid1_ctl07"  DataToolTipField="XXMC"/>
                        <f:BoundField Width="100px" DataField="XMBH"  HeaderText="项目编号"  ColumnID="Panel7_Grid1_ctl09" />
                      
                      <f:BoundField Width="100px" DataField="XMDL"  HeaderText="项目大类"  ColumnID="Panel7_Grid1_ctl12" />
                        <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称"  ColumnID="Panel7_Grid1_ctl11" DataToolTipField="XMLB_MC" />
                   <%--    <f:BoundField Width="130px" DataField="ZYMC" HeaderText="专业名称"  ColumnID="Panel7_Grid1_ctl12" />--%>
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
                         <f:LinkButtonField ColumnID="xq1" CommandName="xq" HeaderText="操作" Text="查看项目申报书"  Width="150px" ToolTip="查看项目申报书"  />
                        
                        <f:LinkButtonField ColumnID="xq3" CommandName="th" HeaderText="操作" Text="退回到项目申报人" ToolTip="退回到项目申报人"  Width="150px"/>
                    </Columns>
                </f:Grid>


                   <f:Grid ID="Grid2_ylfw" Title="Grid2_ylfw" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableMultiSelect="false"
                    DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid2_ylfw_PageIndexChange" OnRowDataBound="Grid2_ylfw_RowDataBound" OnRowCommand="Grid2_ylfw_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                           <Items>
                              
                                

                             <%--  <f:DropDownList ID="DropDownList3" runat="server" Label="选择项目大类"></f:DropDownList>
                                <f:DropDownList ID="DropDownList4" runat="server" Label="选择学校"></f:DropDownList>
                                <f:Button ID="Button1" Text="确定" runat="server" OnClick="Button_sy_Click" >
                                </f:Button>--%>
                                <%--<f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                                 <f:Button ID="Button3" Text="在线查看项目申报书" runat="server" OnClick="Button3_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button4" Text="导出成word文件" runat="server"  OnClick="Button4_Click" Icon="PageWord"  Hidden="true">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                </f:ToolbarSeparator>
                              
                                <f:Button ID="Button2" Text="退回" runat="server" OnClick="Button2_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                </f:ToolbarSeparator>--%>
                               <%--  <f:HyperLink ID="HyperLink2" Text="" Target="_blank" NavigateUrl="" runat="server">
                                </f:HyperLink>--%>
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel7_Grid2_ylfw_ctl08"  HeaderText=""/>
                         <f:BoundField Width="150px" DataField="XXMC"  HeaderText="学校名称"  ColumnID="Panel7_Grid2_ylfw_ctl07"  DataToolTipField="XXMC"/>
                        <f:BoundField Width="100px" DataField="XMBH"  HeaderText="项目编号"  ColumnID="Panel7_Grid2_ylfw_ctl09" />
                      
                      <f:BoundField Width="100px" DataField="XMDL"  HeaderText="项目大类"  ColumnID="Panel7_Grid2_ylfw_ctl10" />
                         <f:BoundField Width="100px" DataField="ZYDM"  HeaderText="专业代码"  ColumnID="Panel7_Grid2_ylfw_ctl12" />
                        <f:BoundField Width="200px" DataField="ZYMC" HeaderText="专业名称"  ColumnID="Panel7_Grid2_ylfw_ctl11" DataToolTipField="ZYMC" />
                   <f:BoundField Width="150px" DataField="ZYDTRXM" HeaderText="专业带头人姓名"  ColumnID="Panel7_Grid2_ylfw_ctl13"  />
                     <f:TemplateField HeaderText="状态"  ColumnID="Panel7_Grid2_ylfw_ctl17">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                         <f:LinkButtonField ColumnID="xq11" CommandName="xq" HeaderText="操作" Text="查看项目申报书"  Width="150px" ToolTip="查看项目申报书"  />
                        
                        <f:LinkButtonField ColumnID="xq31" CommandName="th" HeaderText="操作" Text="退回到项目申报人" ToolTip="退回到项目申报人"  Width="150px"/>
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
