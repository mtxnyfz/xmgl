<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_JXBW_YXGL.aspx.cs" Inherits="XMGL.Web.admin.XMGL_JXBW_YXGL" %>

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
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="申报项目管理(教学比武)" ShowBorder="false" ShowHeader="True" Layout="Fit"
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
                    DataKeyNames="ID,XMBH,ZT" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound" OnRowCommand="Grid1_RowCommand">
                   
                    <Columns>
                       <f:RowNumberField ColumnID="Panel7_Grid1_ctl08" HeaderText="" />
                         <f:BoundField Width="100px" DataField="XMBH" HeaderText="项目编号" ColumnID="Panel7_Grid1_ctl09" />
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
                         <f:TemplateField HeaderText="状态" ColumnID="Panel7_Grid1_ctl17">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <%-- <f:LinkButtonField ColumnID="xq1" CommandName="xq" HeaderText="操作" Text="查看项目申报书"  Width="150px" ToolTip="查看项目申报书"  />--%>
                         <f:LinkButtonField ColumnID="xq2" CommandName="tj" HeaderText="操作" Text="提交到市教委" Width="150px" ToolTip="提交到市教委"   ConfirmText="确定提交？"/>
                        <f:LinkButtonField ColumnID="xq3" CommandName="th" HeaderText="操作" Text="退回到项目申报人"  Width="150px" ToolTip="退回到项目申报人"  ConfirmText="确定退回？"/>
                    </Columns>
                </f:Grid>
               <%--  <f:ContentPanel runat="server" ID="ContentPanel" ShowBorder="false" ShowHeader="false">
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







                </f:ContentPanel>--%>

                  
            </Items>
        </f:Panel>



        <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="600px" Height="450px">
          
        </f:Window>

    </form>
     <script type="text/javascript">
         function PlayWmv(url) {
             //document.getElementById("div1").innerHTML = url;
             //var MediaPlayer1 = document.getElementById('MediaPlayer');
             //MediaPlayer1.FileName = 'http://www.gzgz.edu.sh.cn:808/pb/' + url;
             var arr = url.split("_")
             var title = url.substring(arr[0].length + arr[1].length + 2)

             F('Window1').f_show('/admin/videopaly.aspx?filename=' + url, title, 700, 600);
         }

    </script>
</body>
</html>
