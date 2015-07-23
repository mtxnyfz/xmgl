<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMHZ_SJW.aspx.cs" Inherits="XMGL.Web.admin.XMHZ_SJW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
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
    <f:PageManager ID="PageManager1" runat="server" />
         <f:Panel ID="Panel1" Title="总体项目申报情况汇总表" runat="server" Layout="Fit" Height="200px"  EnableCollapse="true"
             ShowBorder="True"
            ShowHeader="True">
            <%--<Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="Button4" Text="按钮一" runat="server">
                        </f:Button>
                        <f:Button ID="Button5" Text="按钮二" runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>--%>
            <Items>
                <f:Grid ID="Grid1" Title="表格" PageSize="4" ShowBorder="False" ShowHeader="False"
                    runat="server" EnableCheckBoxSelect="False" DataKeyNames="xmldmc" OnRowCommand="Grid1_RowCommand">
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel1_Grid1_ctl07" />
                         <f:BoundField Width="120px" DataField="xmldmc"  HeaderText="项目大类名称" ID="ctl08" ColumnID="Panel1_Grid1_ctl08" />
                        <f:BoundField Width="150px" DataField="sbs" HeaderText="院校项目申报数" ID="ctl09" ColumnID="Panel1_Grid1_ctl09" />
                         <f:BoundField Width="150px" DataField="SQZXJF" HeaderText="院校申报总额(万元)" ID="ctl10" ColumnID="Panel1_Grid1_ctl10" DataFormatString="{0:N2}"/>
                         <f:BoundField Width="150px" DataField="sjwrdje" HeaderText="市教委认定总额(万元)" ID="ctl11" ColumnID="Panel1_Grid1_ctl11" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="150px" DataField="XXPTJF" HeaderText="院校配套总额(万元)" ID="ctl12" ColumnID="Panel1_Grid1_ctl12" DataFormatString="{0:N2}"/>
                         <f:LinkButtonField ColumnID="xq1" CommandName="xq" HeaderText="详情" Text="查看详情" Width="120px" 
                     />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <br />
           <f:Panel ID="Panel2" Title="&nbsp;" runat="server" Layout="Fit" Height="300px"  EnableCollapse="true"
            ShowBorder="True"
            ShowHeader="True">
            <Items>
                <f:Grid ID="Grid2" Title="表格" PageSize="4" ShowBorder="False" ShowHeader="False"
                    runat="server" EnableCheckBoxSelect="False" DataKeyNames="xxdm,XXMC" OnRowCommand="Grid2_RowCommand">
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel2_Grid1_ctl07" />
                         <f:BoundField Width="200px" DataField="XXMC"  HeaderText="院校名称" ID="BoundField1" ColumnID="Panel2_Grid1_ctl08" DataToolTipField="XXMC" />
                        <f:BoundField Width="150px" DataField="sbs" HeaderText="项目申报数" ID="BoundField2" ColumnID="Panel2_Grid1_ctl09" />
                         <f:BoundField Width="150px" DataField="SQZXJF" HeaderText="院校申报总额(万元)" ID="BoundField3" ColumnID="Panel2_Grid1_ctl10" DataFormatString="{0:N2}"/>
                         <f:BoundField Width="150px" DataField="sjwrdje" HeaderText="市教委认定总额(万元)" ID="BoundField4" ColumnID="Panel2_Grid1_ctl11" DataFormatString="{0:N2}" />
                          <f:BoundField Width="150px" DataField="XXPTJF" HeaderText="院校配套总额(万元)" ID="BoundField5" ColumnID="Panel2_Grid1_ctl12" DataFormatString="{0:N2}" />
                         <f:LinkButtonField ColumnID="xq2" CommandName="xq" HeaderText="详情" Text="查看详情" Width="120px" 
                     />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
          <br />
           <f:Panel ID="Panel3" Title="&nbsp;" runat="server" Layout="Fit" Height="300px"  EnableCollapse="true"
            ShowBorder="True"
            ShowHeader="True">
            <Items>
                <f:Grid ID="Grid3" Title="表格" PageSize="4" ShowBorder="False" ShowHeader="False"
                    runat="server" EnableCheckBoxSelect="False" DataKeyNames="XMBH" OnRowCommand="Grid3_RowCommand">
                    <Columns>
                        <f:RowNumberField  ColumnID="Panel3_Grid1_ctl07" />
                         <f:BoundField Width="200px" DataField="XMMC"  HeaderText="项目名称" ID="BoundField6" ColumnID="Panel3_Grid1_ctl08" DataToolTipField="XMMC" />
                       
                       
                         <f:BoundField Width="150px" DataField="SQZXJF" HeaderText="市教委认定总额(万元)" ID="BoundField9" ColumnID="Panel3_Grid1_ctl11" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="150px" DataField="SQZXJF" HeaderText="院校申报总额(万元)" ID="BoundField7"  DataFormatString="{0:N2}"/>
                        <f:GroupField HeaderText="其中(万元)" TextAlign="Center" ID="ctl17" ColumnID="Panel3_Grid3_ctl17">
                    <Columns>
                       
                          
                               <%-- <f:BoundField Width="150px" DataField="SQZXJFKCJCJF" HeaderText="课程教材经费"
                                    TextAlign="Center" DataFormatString="{0:N2}"  ColumnID="Panel3_Grid3_ctl17_ctl20"/>
                                <f:BoundField Width="150px" DataField="SQZXJFSZPXJF"  HeaderText="师资培训经费"
                                    TextAlign="Center" DataFormatString="{0:N2}" ColumnID="Panel3_Grid3_ctl17_ctl21"/>
                                <f:BoundField Width="150px" DataField="SQZXJFYQSBJF" HeaderText="仪器设备经费"
                                    TextAlign="Center" DataFormatString="{0:N2}"  ColumnID="Panel3_Grid3_ctl17_ctl22"/>
                                <f:BoundField Width="150px" DataField="SQZXJFWPRYJF"  HeaderText="外聘人员费用"
                                    TextAlign="Center" DataFormatString="{0:N2}"  ColumnID="Panel3_Grid3_ctl17_ctl23"/>
                                <f:BoundField Width="100px" DataField="SQZXJFYWF"  HeaderText="业务费"
                                    TextAlign="Center" DataFormatString="{0:N2}" ColumnID="Panel3_Grid3_ctl17_ctl24"/>--%>
                          <f:TemplateField TextAlign="Center" Width="120px" HeaderText="年份"  ColumnID="Panel3_Grid3_ctl18_ctl1">
                    <ItemTemplate>
                        <div><%# Eval("NF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                          
                 <f:TemplateField TextAlign="Center" Width="120px" HeaderText="课程教材经费" ColumnID="Panel3_Grid3_ctl18_ctl2">
                    <ItemTemplate>
                        <div><%# Eval("SQZXJFKCJCJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                         <f:TemplateField TextAlign="Center" Width="120px" HeaderText="师资培训经费" ColumnID="Panel3_Grid3_ctl18_ctl3">
                    <ItemTemplate>
                        <div><%# Eval("SQZXJFSZPXJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                         <f:TemplateField TextAlign="Center" Width="120px" HeaderText="仪器设备经费" ColumnID="Panel3_Grid3_ctl18_ctl4">
                    <ItemTemplate>
                        <div><%# Eval("SQZXJFYQSBJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                         <f:TemplateField TextAlign="Center" Width="120px" HeaderText="外聘人员费用" ColumnID="Panel3_Grid3_ctl18_ctl5">
                    <ItemTemplate>
                        <div><%# Eval("SQZXJFWPRYJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                         <f:TemplateField TextAlign="Center" Width="120px" HeaderText="业务费" ColumnID="Panel3_Grid3_ctl18_ctl6">
                    <ItemTemplate>
                        <div><%# Eval("SQZXJFYWF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                        <f:TemplateField TextAlign="Center" Width="120px" HeaderText="合计"  ColumnID="Panel3_Grid3_ctl18_ctl7">
                    <ItemTemplate>
                        <div><%# Eval("SQZXJFJFGSHJ") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>     
                      
                    </Columns>
                </f:GroupField>
                        <f:BoundField Width="150px" DataField="XXPTJF" HeaderText="院校配套总额(万元)" ID="BoundField8"  DataFormatString="{0:N2}"/>
                        <f:GroupField HeaderText="其中(万元)" TextAlign="Center" ID="ctl18" ColumnID="Panel3_Grid3_ctl18">
                    <Columns>
                       
                                
                              <%--  <f:BoundField Width="150px" DataField="XXPTJFKCJCJF" HeaderText="课程教材经费"
                                    TextAlign="Center" DataFormatString="{0:N2}" ID="ctl20" ColumnID="Panel3_Grid3_ctl18_ctl20"/>
                                <f:BoundField Width="150px" DataField="XXPTJFSZPXJF"  HeaderText="师资培训经费"
                                    TextAlign="Center" DataFormatString="{0:N2}" ID="ctl21" ColumnID="Panel3_Grid3_ctl18_ctl21"/>
                                <f:BoundField Width="150px" DataField="XXPTJFSBHCJF" HeaderText="仪器设备经费"
                                    TextAlign="Center" DataFormatString="{0:N2}" ID="ctl22" ColumnID="Panel3_Grid3_ctl18_ctl22"/>
                                <f:BoundField Width="150px" DataField="XXPTJFWPRYJF"  HeaderText="外聘人员费用"
                                    TextAlign="Center" DataFormatString="{0:N2}" ID="ctl23" ColumnID="Panel3_Grid3_ctl18_ctl23"/>
                                <f:BoundField Width="100px" DataField="XXPTJFYWF"  HeaderText="业务费"
                                    TextAlign="Center" DataFormatString="{0:N2}" ID="ctl24" ColumnID="Panel3_Grid3_ctl18_ctl24"/>--%>

                        <f:TemplateField TextAlign="Center" Width="120px" HeaderText="年份"  ColumnID="Panel3_Grid3_ctl18_ctl11">
                    <ItemTemplate>
                        <div><%# Eval("NF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                          
                 <f:TemplateField TextAlign="Center" Width="120px" HeaderText="课程教材经费" ColumnID="Panel3_Grid3_ctl18_ctl22">
                    <ItemTemplate>
                        <div><%# Eval("XXPTJFKCJCJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                          <f:TemplateField TextAlign="Center" Width="120px" HeaderText="师资培训经费" ColumnID="Panel3_Grid3_ctl18_ctl23">
                    <ItemTemplate>
                        <div><%# Eval("XXPTJFSZPXJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                         <f:TemplateField TextAlign="Center" Width="120px" HeaderText="仪器设备经费" ColumnID="Panel3_Grid3_ctl18_ctl24">
                    <ItemTemplate>
                        <div><%# Eval("XXPTJFYQSBJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                         <f:TemplateField TextAlign="Center" Width="120px" HeaderText="外聘人员费用" ColumnID="Panel3_Grid3_ctl18_ctl25">
                    <ItemTemplate>
                        <div><%# Eval("XXPTJFWPRYJF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                         <f:TemplateField TextAlign="Center" Width="120px" HeaderText="业务费" ColumnID="Panel3_Grid3_ctl18_ctl26">
                    <ItemTemplate>
                        <div><%# Eval("XXPTJFYWF") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>
                        <f:TemplateField TextAlign="Center" Width="120px" HeaderText="合计"  ColumnID="Panel3_Grid3_ctl18_ctl27">
                    <ItemTemplate>
                        <div><%# Eval("XXPTJFJFGSHJ") %></div>
                    
                    </ItemTemplate>
                </f:TemplateField>     
                            
                      
                    </Columns>
                </f:GroupField>
                         <f:LinkButtonField ColumnID="xq3" CommandName="xq" HeaderText="查看申报书" Text="查看申报书" Width="120px" 
                     />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
         <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" 
            IsModal="true" Width="1050px" Height="550px">
          
        </f:Window>
    </form>
</body>
</html>
