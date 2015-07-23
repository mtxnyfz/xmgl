<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XM_ZJSZ.aspx.cs" Inherits="XMGL.Web.admin.XM_ZJSZ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/theme-start/theme.css" />
  
    <script src="../res/js/jquery.min.js" type="text/javascript"></script>
     <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
    <style>
        .ui-autocomplete-loading {
            background: white url('../res/images/ui-anim_basic_16x16.gif') right center no-repeat;
        }

        .autocomplete-item-title {
            font-weight: bold;
        }

        .ui-autocomplete {
            max-height: 200px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }

        .auto-style1 {
            width: 100%;
        }

        .wz {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server"  AjaxAspnetControls="div1"/>
        <f:TabStrip ID="TabStrip1"  AutoScroll="false" 
            AutoPostBack="true" OnTabIndexChanged="TabStrip1_TabIndexChanged"
            ShowBorder="true" ActiveTabIndex="0" runat="server">
            <Tabs>
                <f:Tab ID="Tab1" Title="项目评审专家设置" BodyPadding="5px"
                    Layout="Fit" runat="server">
                    <Items>
                         <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="申报项目管理" ShowBorder="True" ShowHeader="false" Layout="VBox"
            BoxConfigAlign="Stretch" AutoScroll="false">
             <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server" Margin="0 0 0 2">
                           <Items>
                              
                                

                               <f:DropDownList ID="DropDownList1" runat="server" Label="" ShowLabel="false" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100px">
                                    <f:ListItem Text="请选择" Value="请选择" />
                                   <f:ListItem Text="市内" Value="1" />
                                    <f:ListItem Text="市外" Value="2" />
                               </f:DropDownList>
                                  <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                                <f:DropDownList ID="DropDownList2" runat="server" Label="" ShowLabel="false" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >
                                     <f:ListItem Text="请选择" Value="请选择" />
                                    <f:ListItem Text="校长" Value="1" />
                                    <f:ListItem Text="骨干" Value="2" />
                                    <f:ListItem Text="国内高职教育专家" Value="3" />
                                    <f:ListItem Text="国外高职教育专家" Value="4" />
                                     <f:ListItem Text="专业带头人" Value="5" />
                                </f:DropDownList>
                               
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server" >
                                </f:ToolbarSeparator>
                                <f:TextBox ID="TextBox_key" Label="关键字搜索"   runat="server" ShowLabel="false" EmptyText="请输入专家姓名关键字" Width="150px" OnTextChanged="TextBox_key_TextChanged" AutoPostBack="true">
                                </f:TextBox>
                                 <f:Button ID="Button3" Text="没有您要找的专家？点击手动添加" runat="server"  OnClick="Button3_Click">
                                </f:Button>
                                 <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server" >
                                </f:ToolbarSeparator>
                               
                               
                            </Items>
                        </f:Toolbar>
                 
                    </Toolbars>
            <Items>
                   <f:Grid ID="Grid1" Title="Grid1" PageSize="10" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="True" ClearSelectedRowsAfterPaging="false"
                    DataKeyNames="Experts_ID,Experts_Name" OnPageIndexChange="Grid1_PageIndexChange" AutoScroll="true" Height="450px" OnRowCommand="Grid1_RowCommand" OnRowDataBound="Grid1_RowDataBound">
                  <Toolbars>
                       <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="账号生效日期" EmptyText="请选择日期" ID="DatePicker_ksrq" ></f:DatePicker>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="DatePicker_ksrq" CompareOperator="GreaterThan" CompareMessage="失效日期应该大于生效日期" Label="账号失效日期" EmptyText="请选择日期" ID="DatePicker_jsrq" ></f:DatePicker>
                        <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server" >
                                </f:ToolbarSeparator>
                               <f:Button ID="Button1" Text="添加勾选的评审专家到本项目" runat="server"  OnClick="Button1_Click">
                                </f:Button>
                    </Items>
                </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField  Width="30px"  ColumnID="Panel7_Grid1_ctl08"  HeaderText="" TextAlign="Left"/>
                        <f:BoundField Width="100px" DataField="Experts_Name"  HeaderText="姓名"  ColumnID="Panel7_Grid1_ctl09" />
                      
                       <f:BoundField Width="100px" DataField="Experts_Sex"  HeaderText="性别"  ColumnID="Panel7_Grid1_ctl12" />
                        <f:BoundField Width="200px" DataField="Experts_Mobil" HeaderText="手机"  ColumnID="Panel7_Grid1_ctl11" DataToolTipField="XMMC" />
                       <f:BoundField Width="130px" DataField="ZJLX_Name" HeaderText="身份"  ColumnID="Panel7_Grid1_ctl13" />
                        <%-- <f:BoundField Width="130px" DataField="jjcs" HeaderText="拒绝次数"  ColumnID="Panel7_Grid1_ctl14" />--%>
                         <f:TemplateField HeaderText="未接受次数" ColumnID="Panel7_Grid1_ctl17">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=''></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                           <f:LinkButtonField ColumnID="xq" CommandName="xq" HeaderText="查看详情" Text="查看详情" Width="120px"  />
                        
                    </Columns>
                </f:Grid>
                </Items>
                </f:Panel>
                    </Items>
                </f:Tab>
                <f:Tab ID="Tab2" Title="确认评审专家" BodyPadding="5px" runat="server">
                    <Items>
                       <f:Grid ID="Grid2" Title="Grid2" PageSize="10" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" EnableCheckBoxSelect="True" ClearSelectedRowsAfterPaging="false"
                    DataKeyNames="Experts_ID,Experts_Name,JSRQ,Experts_Mobil" OnPageIndexChange="Grid2_PageIndexChange" AutoScroll="true" Height="450px" EnableRowClickEvent="true" OnRowClick="Grid2_RowClick" OnRowCommand="Grid2_RowCommand">
                  <Toolbars>
                       <f:Toolbar ID="Toolbar3" runat="server">
                    <Items>
                        
                               <f:Button ID="Button2" Text="移除勾选的评审专家" runat="server"   OnClick="Button2_Click" ConfirmText="确定移除？">
                                </f:Button>
                         <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server" >
                                </f:ToolbarSeparator>
                          <f:Button ID="Button4" Text="短信通知" runat="server"  OnClick="Button4_Click" ConfirmText="确定此操作？">
                                </f:Button>
                    </Items>
                </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField  Width="30px"  ColumnID="Panel7_Grid2_ctl08"  HeaderText="" TextAlign="Left"/>
                        <f:BoundField Width="100px" DataField="Experts_Name"  HeaderText="姓名"  ColumnID="Panel7_Grid2_ctl09" />
                      
                       <f:BoundField Width="100px" DataField="Experts_Sex"  HeaderText="性别"  ColumnID="Panel7_Grid2_ctl12" />
                        <f:BoundField Width="200px" DataField="Experts_Mobil" HeaderText="手机"  ColumnID="Panel7_Grid2_ctl11" DataToolTipField="XMMC" />
                       <f:BoundField Width="130px" DataField="ZJLX_Name" HeaderText="身份"  ColumnID="Panel7_Grid2_ctl13" />
                           <f:LinkButtonField ColumnID="xq" CommandName="xq" HeaderText="查看详情" Text="查看详情" Width="120px"  />
                        
                    </Columns>
                </f:Grid>
                        <f:ContentPanel ID="ContentPanel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="短信内容"  Height="100px">
                            <div id="div1" runat="server" style=" text-align:center">短信内容</div>
                        </f:ContentPanel>
                    </Items>
                </f:Tab>
               
            </Tabs>
        </f:TabStrip>
          <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" 
            IsModal="true" Width="850px" Height="650px" AutoScroll="false" OnClose="Window1_Close">
          
        </f:Window>
         <f:HiddenField ID="hfSelectedIDS1" runat="server">
    </f:HiddenField>
        <f:HiddenField ID="hfSelectedIDS2" runat="server">
    </f:HiddenField>
    </form>
     <script type="text/javascript">
         var TextBox_key = '<%= TextBox_key.ClientID %>';


         F.ready(function () {

             var cache = {};



             $('#' + TextBox_key + ' input').autocomplete({
                 minLength: 1,
                 source: function (request, response) {
                     var term1 = request.term;


                     $.getJSON("search_bykey.ashx?timestamp=" + new Date().getTime(), request, function (data, status, xhr) {
                         cache[term1] = data;
                         //alert(cache[term1])
                         response(cache[term1]);


                     });
                 },
                 select: function (event, ui) {
                     var $this = $(this);
                     $this.val(ui.item.key);


                     cache = {};
                     return false;
                 }
             }).autocomplete("instance")._renderItem = function (ul, item) {

                 return $("<li>")
                     .append("<a><span class='autocomplete-item-title'>" + item.key + "</span></a>")
                     .appendTo(ul);
             };

         });

    </script>
</body>
</html>
