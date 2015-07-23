<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_SZRT_YXGL.aspx.cs" Inherits="XMGL.Web.admin.XMGL_SZRT_YXGL" %>

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
            Title="申报项目管理" ShowBorder="false" ShowHeader="True" Layout="VBox"
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
                        <f:RowNumberField  ColumnID="Panel7_Grid1_ctl08"  HeaderText=""/>
                        <f:BoundField Width="100px" DataField="XMBH"  HeaderText="项目编号"  ColumnID="Panel7_Grid1_ctl09" />
                      
                       <f:BoundField Width="100px"  DataField="XMMC" ColumnID="Panel7_Grid1_ctl12" />
                        <f:BoundField Width="200px" DataField="XMMC" HeaderText="项目名称"  ColumnID="Panel7_Grid1_ctl11" DataToolTipField="XMMC" />
                     <%--  <f:BoundField Width="130px" DataField="ZYMC" HeaderText="专业名称"  ColumnID="Panel7_Grid1_ctl12" />--%>
                          <f:BoundField Width="150px" DataField="JFYS_SQJF" HeaderText="申请专项经费(万元)"  ColumnID="Panel7_Grid1_ctl13" DataFormatString="{0:N2}"/>
                           <f:BoundField Width="150px" DataField="JFYS_XXPTJF" HeaderText="学校配套经费(万元)"  ColumnID="Panel7_Grid1_ctl14" DataFormatString="{0:N2}"/>
                         <f:TemplateField HeaderText="“双证融通”培养模式人才改革方案" Width="150px"  ColumnID="Panel7_Grid1_ctl15" >
                    <ItemTemplate>
                       <a href='upload/“双证融通”培养模式人才改革方案/<%# Eval("FJ1")%>' target="_blank" title='<%# Eval("FJ1")%>'><%# Eval("FJ1").ToString().Substring( Eval("FJ1").ToString().IndexOf("_")+1)%></a>
                    </ItemTemplate>

                </f:TemplateField>
                         <f:TemplateField HeaderText="本专业现行人才培养方案"  Width="150px"  ColumnID="Panel7_Grid1_ctl16">
                    <ItemTemplate>
                      <a href='upload/本专业现行人才培养方案/<%# Eval("FJ2")%>' target="_blank" title='<%# Eval("FJ2")%>'><%# Eval("FJ2").ToString().Substring( Eval("FJ2").ToString().IndexOf("_")+1)%></a>
                    </ItemTemplate>

                </f:TemplateField >
                         <f:TemplateField HeaderText="项目预算明细"  Width="150px"  ColumnID="Panel7_Grid1_ctl116">
                    <ItemTemplate>
                       <a href='upload/项目预算明细/<%# Eval("FJ3")%>' target="_blank" title='<%# Eval("FJ3")%>'><%# Eval("FJ3").ToString().Substring( Eval("FJ3").ToString().IndexOf("_")+1)%></a>
                    </ItemTemplate>

                </f:TemplateField >
                     <f:TemplateField HeaderText="状态"  ColumnID="Panel7_Grid1_ctl17">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ZT")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                         <f:LinkButtonField ColumnID="xq1" CommandName="xq" HeaderText="操作" Text="查看项目申报书"  Width="150px" ToolTip="查看项目申报书"  />
                         <f:LinkButtonField ColumnID="xq2" CommandName="tj" HeaderText="操作" Text="提交到市教委" Width="150px" ToolTip="提交到市教委"   ConfirmText="确定提交？"/>
                        <f:LinkButtonField ColumnID="xq3" CommandName="th" HeaderText="操作" Text="退回到项目申报人"  Width="150px" ToolTip="退回到项目申报人"  ConfirmText="确定退回？"/>
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
