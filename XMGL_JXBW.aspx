﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_JXBW.aspx.cs" Inherits="XMGL.Web.admin.XMGL_JXBW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" AjaxAspnetControls="LinkButton1" />
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

                                <f:HyperLink ID="HyperLink1" Text="" Target="_blank" NavigateUrl="" runat="server">
                                </f:HyperLink>

                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField ColumnID="Panel7_Grid1_ctl08" HeaderText="" />
                        <f:BoundField Width="100px" DataField="XMBH" HeaderText="项目编号" ColumnID="Panel7_Grid1_ctl09" />
                        <f:BoundField Width="100px" DataField="XXMC" HeaderText="学校名称" ColumnID="Panel7_Grid1_ctl89" DataToolTipField="XXMC" />
                        <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称" ColumnID="Panel7_Grid1_ctl11" DataToolTipField="XMMC" />
                        <f:TemplateField HeaderText="“书面提纲" Width="200px" ColumnID="Panel7_Grid1_ctl15">
                            <ItemTemplate>
                                <div><%# Eval("WORD1")%></div>
                            </ItemTemplate>

                        </f:TemplateField>
                        <f:TemplateField HeaderText="人才培养方案" Width="200px" ColumnID="Panel7_Grid1_ctl16">
                            <ItemTemplate>
                                <div><%# Eval("WORD2")%></div>
                            </ItemTemplate>

                        </f:TemplateField>
                        <f:TemplateField HeaderText="教学计划" Width="200px" ColumnID="Panel7_Grid1_ctl116">
                            <ItemTemplate>
                                <div><%# Eval("WORD3")%></div>
                            </ItemTemplate>

                        </f:TemplateField>
                        <f:TemplateField HeaderText="其他" Width="200px" ColumnID="Panel7_Grid1_ctl118">
                            <ItemTemplate>
                                 <div><%# Eval("WORD4")%></div>
                            </ItemTemplate>

                        </f:TemplateField>

                       
                        <f:TemplateField HeaderText="顶层设计" ColumnID="Panel7_Grid1_ctl18">
                            <ItemTemplate>
                                <div><%# Eval("SP1")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="五年规划" ColumnID="Panel7_Grid1_ctl19">
                            <ItemTemplate>
                                <div><%# Eval("SP2")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="高职教师+课程名称" ColumnID="Panel7_Grid1_ctl20">
                            <ItemTemplate>
                                <div><%# Eval("SP3")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="中职教师+课程名称" ColumnID="Panel7_Grid1_ctl21">
                            <ItemTemplate>
                                <div><%# Eval("SP4")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                       
                         <f:TemplateField HeaderText="状态" ColumnID="Panel7_Grid1_ctl17">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:LinkButtonField ColumnID="up1" CommandName="up" HeaderText="操作" Text='修改' Width="80px" />
                        <f:LinkButtonField ColumnID="xq2" CommandName="tj" HeaderText="操作" Text="提交" Width="80px" ConfirmText="提交后将不能修改，确定提交？" />
                        <f:LinkButtonField ColumnID="xq3" CommandName="del" HeaderText="操作" Text="删除" Width="80px" ConfirmText="确定删除？" />
                    </Columns>
                </f:Grid>

                <f:ContentPanel runat="server" ID="ContentPanel" ShowBorder="false" ShowHeader="false">
                    <center><br /><div id="div1"></div><br /><object id="MediaPlayer" width="600" height="450" classid="CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95"
                        standby="Loading Windows Media Player components..." type="application/x-oleobject">

                        <param name="FileName" value="">

                        <param name="autostart" value="true">

                        <param name="ShowControls" value="true">

                        <param name="ShowStatusBar" value="false">

                        <param name="ShowDisplay" value="false">

                        <embed type="application/x-mplayer2" src="URL to video" name="MediaPlayer"
                            width="192" height="190" showcontrols="1" showstatusbar="0" showdisplay="0" autostart="0"> </embed>

                    </object></center><br />







                </f:ContentPanel>
            </Items>
        </f:Panel>

        <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="1050px" Height="550px">
        </f:Window>

    </form>
    <script type="text/javascript">
        function PlayWmv(url) {
            document.getElementById("div1").innerHTML = url;
            var MediaPlayer1 = document.getElementById('MediaPlayer');
            MediaPlayer1.FileName = 'http://www.gzgz.edu.sh.cn:808/pb/' + url;
        }

    </script>
</body>
</html>