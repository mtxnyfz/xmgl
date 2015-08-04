<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_JXBW_ZJ.aspx.cs" Inherits="XMGL.Web.admin.XMGL_JXBW_ZJ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            if (/msie/.test(navigator.userAgent.toLowerCase())) {

            }
            else {
                //alert('为了能正常播放视频，请使用支持兼容模式的浏览器，如遨游，360等浏览器');
            }

        })
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1"  runat="server"  AutoSizePanelID="Panel7"/>
        <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="申报项目查看(教学比武)" ShowBorder="false" ShowHeader="True"   Layout="Fit" 
            BoxConfigAlign="Stretch">
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
                    DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound" OnRowCommand="Grid1_RowCommand" >
                   
                    <Columns>
                       <f:RowNumberField ColumnID="Panel7_Grid1_ctl08" HeaderText="" />
                       <%--  <f:BoundField Width="100px" DataField="XMBH" HeaderText="项目编号" ColumnID="Panel7_Grid1_ctl09" />--%>
                        <f:BoundField Width="100px" DataField="XXMC" HeaderText="学校名称" ColumnID="Panel7_Grid1_ctl89" DataToolTipField="XXMC" />
                        <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称" ColumnID="Panel7_Grid1_ctl11" DataToolTipField="XMMC" />
                        <f:TemplateField HeaderText="书面提交材料" Width="200px" ColumnID="Panel7_Grid1_ctl15">
                            <ItemTemplate>
                                <div><%# Eval("WORD1")%></div>
                            </ItemTemplate>

                        </f:TemplateField>
                        <f:TemplateField HeaderText="人才培养方案" Width="200px" ColumnID="Panel7_Grid1_ctl16">
                            <ItemTemplate>
                                <div><%# Eval("WORD2")%></div>
                            </ItemTemplate>

                        </f:TemplateField>
                      <%--  <f:TemplateField HeaderText="教学计划" Width="200px" ColumnID="Panel7_Grid1_ctl116">
                            <ItemTemplate>
                                <div><%# Eval("WORD3")%></div>
                            </ItemTemplate>

                        </f:TemplateField>
                        <f:TemplateField HeaderText="其他" Width="200px" ColumnID="Panel7_Grid1_ctl118">
                            <ItemTemplate>
                                 <div><%# Eval("WORD4")%></div>
                            </ItemTemplate>

                        </f:TemplateField>--%>

                        <f:GroupField HeaderText="视 频" TextAlign="Center" ID="ctl18" ColumnID="Panel3_Grid3_ctl18">
                    <Columns>
                        <f:TemplateField HeaderText="顶层设计" Width="200px" ColumnID="Panel7_Grid1_ctl18">
                            <ItemTemplate>
                                <div><%# Eval("SP1")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="五年规划" Width="200px" ColumnID="Panel7_Grid1_ctl19">
                            <ItemTemplate>
                                <div><%# Eval("SP2")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="高职教师课程" Width="200px" ColumnID="Panel7_Grid1_ctl20">
                            <ItemTemplate>
                                <div><%# Eval("SP3")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField HeaderText="中职教师课程" Width="200px" ColumnID="Panel7_Grid1_ctl21">
                            <ItemTemplate>
                                <div><%# Eval("SP4")%></div>
                            </ItemTemplate>
                        </f:TemplateField>
                         </Columns>
                </f:GroupField>
                         <f:TemplateField HeaderText="状态" ColumnID="Panel7_Grid1_ctl17" Hidden="true">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <%-- <f:LinkButtonField ColumnID="xq1" CommandName="xq" HeaderText="操作" Text="查看项目申报书"  Width="150px" ToolTip="查看项目申报书"  />--%>
                        
                        
                       <%-- <f:LinkButtonField ColumnID="xq3" CommandName="th" HeaderText="操作" Text="退回到项目申报人" ToolTip="退回到项目申报人"  Width="150px"/>--%>
                    </Columns>
                </f:Grid>
                

                  
            </Items>
        </f:Panel>
       <%--  <f:Panel ID="Panel2" Title="面板三（Layout=Fit）" runat="server" Layout="Fit" Height="500px"  EnableCollapse="true"
            BodyPadding="5px"  ShowBorder="false"
            ShowHeader="false">
             <Items>
         <f:ContentPanel runat="server" ID="ContentPanel" ShowBorder="false" ShowHeader="false">
                    <center><br /><div id="div1"></div><br />
                         <object id="player" height="450" width="650" classid="CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6" > 
<param name="AutoStart" value="true"/> <param name="url" value=""/><param name="enabled" value="true"/><param name="CurrentPosition" value="0"/><param name="uiMode" value="Full"/><param name="SendMouseClickEvents " value="true"/></object>
                    </center><br />







                </f:ContentPanel>
                 </Items>
             </f:Panel>--%>

        <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="800px" Height="650px">
          
        </f:Window>

    </form>
     <script type="text/javascript">
         function PlayWmv(url) {
             
             var arr = url.split("_")
             var title = url.substring(arr[0].length + arr[1].length + 2)
          
             F('Window1').f_show('/admin/videopaly.aspx?filename=' + url, title, 700, 600);
         }

    </script>
</body>
</html>
