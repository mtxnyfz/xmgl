﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMHZB_YLZY.aspx.cs" Inherits="XMGL.Web.admin.XMHZB_YLZY" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel ID="Panel1" Title="总体项目申报情况汇总表" runat="server"   EnableCollapse="true"
             ShowBorder="True"
            ShowHeader="True" >
           <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="btnCheckSelection" Text="按学校名称排序" runat="server" OnClick="btnCheckSelection_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="btnConfirmButton" Text="按项目类别排序" runat="server" OnClick="btnConfirmButton_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                                 <f:DropDownList ID="DropDownList_sbzt" runat="server" Label="申报状态" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList_sbzt_SelectedIndexChanged">
                     
                    <f:ListItem Text="院校申报用户已填报" Value="全部" />
                    <f:ListItem Text="院校申报用户已提交" Value="1" />
                     <f:ListItem Text="院校系统管理员已提交" Value="3" />
                </f:DropDownList>
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                </f:ToolbarSeparator>
                                 <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="World" OnClick="btnSaveClose_Click"
                        runat="server" Text="下载勾选的申报书">
                    </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                </f:ToolbarSeparator>
                                 <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                                </f:HyperLink>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
            <Items>
                <f:Grid ID="Grid1" Title="表格" PageSize="20" ShowBorder="False" ShowHeader="False"
                    runat="server" EnableCheckBoxSelect="true" AllowPaging="true"  ClearSelectedRowsAfterPaging="false" OnPageIndexChange="Grid1_PageIndexChange" DataKeyNames="XMBH" OnRowCommand="Grid1_RowCommand">
                   
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel1_Grid1_ctl05" />
                         <f:BoundField Width="180px" DataField="XXMC"  HeaderText="单位名称" ID="BoundField1" ColumnID="Panel1_Grid1_ctl07" DataToolTipField="XXMC" />
                         <f:BoundField Width="120px" DataField="XMDLMC"  HeaderText="项目类别" ID="ctl08" ColumnID="Panel1_Grid1_ctl08" />
                         <f:BoundField Width="120px" DataField="XMMC"  HeaderText="项目名称" ID="BoundField2" ColumnID="Panel1_Grid1_ctl06"  DataToolTipField="XMMC"/>
                        <f:BoundField Width="150px" DataField="ZYFZR_XM" HeaderText="项目负责人" ID="ctl09" ColumnID="Panel1_Grid1_ctl09" />
                         <f:BoundField Width="150px" DataField="XMZJF" HeaderText="项目总经费(万元)" ID="ctl10" ColumnID="Panel1_Grid1_ctl10" DataFormatString="{0:N2}"/>
                         <f:BoundField Width="150px" DataField="SQZXJF" HeaderText="申请经费(万元)" ID="ctl11" ColumnID="Panel1_Grid1_ctl11" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="150px" DataField="XXPTJF" HeaderText="自筹经费(万元)" ID="ctl12" ColumnID="Panel1_Grid1_ctl12" DataFormatString="{0:N2}"/>
                      <f:LinkButtonField ColumnID="xq1" CommandName="xq" HeaderText="查看申报书" Text="查看申报书" Width="120px"  />
                    
                    </Columns>
                </f:Grid>

                   <f:Grid ID="Grid2" Title="表格" PageSize="20" ShowBorder="False" ShowHeader="False"
                    runat="server" EnableCheckBoxSelect="true" AllowPaging="true"  ClearSelectedRowsAfterPaging="false" OnPageIndexChange="Grid2_PageIndexChange" DataKeyNames="XMBH" OnRowCommand="Grid2_RowCommand">
                   
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel1_Grid2_ctl05" />
                        
                         <f:BoundField Width="120px" DataField="XMDLMC"  HeaderText="项目类别" ID="BoundField4" ColumnID="Panel1_Grid2_ctl08" />
                         <f:BoundField Width="180px" DataField="XXMC"  HeaderText="院校名称" ID="BoundField3" ColumnID="Panel1_Grid2_ctl07" DataToolTipField="XXMC" />
                         <f:BoundField Width="120px" DataField="XMMC"  HeaderText="项目名称" ID="BoundField5" ColumnID="Panel1_Grid2_ctl06"  DataToolTipField="XMMC"/>
                        <f:BoundField Width="150px" DataField="ZYFZR_XM" HeaderText="项目负责人" ID="BoundField6" ColumnID="Panel1_Grid2_ctl09" />
                         <f:BoundField Width="150px" DataField="XMZJF" HeaderText="项目总经费(万元)" ID="BoundField7" ColumnID="Panel1_Grid2_ctl10" DataFormatString="{0:N2}"/>
                         <f:BoundField Width="150px" DataField="SQZXJF" HeaderText="申请经费(万元)" ID="BoundField8" ColumnID="Panel1_Grid2_ctl11" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="150px" DataField="XXPTJF" HeaderText="自筹经费(万元)" ID="BoundField9" ColumnID="Panel1_Grid2_ctl12" DataFormatString="{0:N2}"/>
                     <f:LinkButtonField ColumnID="xq2" CommandName="xq" HeaderText="查看申报书" Text="查看申报书" Width="120px"  />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
         <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" 
            IsModal="true" Width="1050px" Height="550px">
          
        </f:Window>
         <f:HiddenField ID="hfSelectedIDS1" runat="server">
    </f:HiddenField>
          <f:HiddenField ID="hfSelectedIDS2" runat="server">
    </f:HiddenField>
    </form>
</body>
</html>
