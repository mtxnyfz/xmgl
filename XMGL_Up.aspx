﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_Up.aspx.cs" Inherits="XMGL.Web.admin.XMGL_Up" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/theme-start/theme.css" />
     <style>
        .ui-autocomplete-loading {
            background: white url('../res/images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        .autocomplete-item-title
    {
        font-weight: bold;
    }
   .ui-autocomplete {
        max-height: 200px;
        overflow-y: auto; 
        /* prevent horizontal scrollbar */
        overflow-x: hidden;
    }
         .auto-style1
         {
             width: 100%;
         }
    </style>

    
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
  <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="DropDownList_zjz,DropDownList_ss,DropDownList_xl1,DropDownList_xw1,DropDownList_zcdj1" />
         <f:Panel ID="Panel1" runat="server" BodyPadding="15px"
            Title="添加项目" ShowBorder="true" ShowHeader="false"
            AutoScroll="true"   BoxConfigAlign="Stretch" Margin="0 10 0 0">
            <Items>
                 <f:SimpleForm  ID="Form2"  BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server">
                    <Items>
                         <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                <f:TextBox ID="TextBox_xmmc" Label="申报项目名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server">
                                </f:TextBox>
                               <%-- <f:DropDownList ID="DropDownList_zymc" runat="server" Label="专业名称" Margin="0 5 0 0"  ColumnWidth="33%"></f:DropDownList>
                                   <f:TextBox ID="TextBox_zydm" Label="专业代码" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server" Readonly="false">
                                </f:TextBox>--%>
                            </Items>
                        </f:Panel>
                      <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="<strong>申报学校基本情况</strong>"  runat="server">
                            <Items>
                                  <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                <f:TextBox ID="TextBox_xxmc" Label="学校名称" Margin="0 5 2 2" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"  Readonly="true" Enabled="false">
                                </f:TextBox>
                               
                                   <f:TextBox ID="TextBox_jbf" Label="举办方" Required="true" ShowRedStar="true" ColumnWidth="30%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_xxzx" Label="学校性质" Required="true" ShowRedStar="true" ColumnWidth="20%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">
                                       </f:TextBox>
                                           </Items>
                                      </f:Panel>
                                
                                  <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                
                               
                                  <f:TextBox ID="TextBox_txdz" Label="通信地址" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 2">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_yb" Label="邮  编" Required="true" ShowRedStar="true" ColumnWidth="20%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_xxwz" Label="学校网址" Required="true" ShowRedStar="true" ColumnWidth="30%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">
                                </f:TextBox>
                                            </Items>
                                      </f:Panel>
                               
                                   <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="<strong>法人代表信息</strong>" runat="server">
                            <Items>
                                  <f:Panel ID="Panel5" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  >
                                       <Items>
                                 <f:TextBox ID="TextBox_frdbxm" Label="姓  名" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 2">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_frdbzw" Label="职  务" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_frdbbgsdh" Label="办公室电话" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server"  Readonly="true" Enabled="false" Margin="0 3 2 0">
                                </f:TextBox>
                                            </Items>
                                      </f:Panel>
                                  <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  >
                                       <Items>
                                 <f:TextBox ID="TextBox_frdbcz" Label="传  真" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 5 2">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_frdbsj" Label="手  机" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"  Readonly="false" Margin="0 5 5 0">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_frdbdzyx" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server"  Readonly="true" Enabled="false" Margin="0 3 5 0">
                                </f:TextBox>
                                            </Items>
                                      </f:Panel>
                                  </Items>
                                      </f:GroupPanel>
                                  <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="<strong>联系人信息</strong>" runat="server" Hidden="true">
                            <Items>
                                  <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  >
                                       <Items>
                                 <f:TextBox ID="TextBox_LXRXM" Label="姓  名"  ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 2">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_LXRZW" Label="职  务"  ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_LXRBGSDH" Label="办公室电话"  ColumnWidth="34%" runat="server"  Readonly="true" Enabled="false" Margin="0 3 2 0">
                                </f:TextBox>
                                            </Items>
                                      </f:Panel>
                                  <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  >
                                       <Items>
                                 <f:TextBox ID="TextBox_LXRCZ" Label="传  真"  ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 5 2">
                                </f:TextBox>
                                  <f:TextBox ID="LXRSJ" Label="手  机"  ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 5 0">
                                </f:TextBox>
                                  <f:TextBox ID="LXRDZYX" Label="电子邮箱"  ColumnWidth="34%" runat="server"  Readonly="true" Enabled="false" Margin="0 3 5 0">
                                </f:TextBox>
                                            </Items>
                                      </f:Panel>
                                  </Items>
                                      </f:GroupPanel>
                            </Items>
                        </f:GroupPanel>
                         <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="<strong>申报专业基本情况</strong>" runat="server">
                            <Items>
                                      <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:DropDownList ID="ZYMC" runat="server" Label="专业名称"  Required="true" ShowRedStar="true" ColumnWidth="25%" OnSelectedIndexChanged="ZYMC_SelectedIndexChanged" AutoPostBack="true"></f:DropDownList>
                               
                                   <f:TextBox ID="ZYDM" Label="专业代码" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">
                                </f:TextBox>
                                  <f:TextBox ID="ZYSSDL" Label="专业所属大类" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="true" Enabled="false"   Margin="0 5 2 0">
                                       </f:TextBox>
                                             <f:TextBox ID="ZYSSEJL" Label="专业所属二级类" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="true" Enabled="false"  Margin="0 5 2 0">
                                       </f:TextBox>
                                           </Items>
                                      </f:Panel>
                                <f:GroupPanel ID="GroupPanel5" Layout="Anchor" Title="专业负责人信息" runat="server">
                            <Items>
                                      <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                            <f:TextBox ID="ZYFZR_XM" Label="姓  名" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"   Readonly="true" Enabled="false"  Margin="0 5 2 0"></f:TextBox>
                                            <f:TextBox ID="ZYFZR_ZYZGZS" Label="部门" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="false" Margin="0 5 2 0"></f:TextBox>
                                             <f:TextBox ID="ZYFZR_ZYJSZW" Label="专业技术职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="false" Margin="0 5 2 0"></f:TextBox>
                                            <f:TextBox ID="ZYFZR_XZZW" Label="行政职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="false" Margin="0 5 2 0"></f:TextBox>
                                          
                                           
                                       </Items>
                                      </f:Panel>
                                <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                            <f:TextBox ID="ZYFZR_BGSDH" Label="办公室电话" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="false" Margin="0 5 5 0"></f:TextBox>
                                            <f:TextBox ID="ZYFZR_CZ" Label="传   真" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="false" Margin="0 5 2 0"></f:TextBox>
                                            <f:TextBox ID="ZYFZR_SJ" Label="手      机" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="false" Margin="0 5 2 0"></f:TextBox>
                                            <f:TextBox ID="ZYFZR_DZYX" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="false" Margin="0 5 2 0"></f:TextBox>
                                       </Items>
                                      </f:Panel>
                                

                                  </Items>
                                      </f:GroupPanel>
                            <f:Panel ID="Panel12" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:Label ID="Label1" runat="server" Label="专业建设定位类型" Text="专业建设定位类型:"  ShowLabel="false" ShowRedStar="true"></f:Label>
                                            <f:RadioButtonList ID="RadioButtonList_zytd" runat="server"  ColumnWidth="50%" Margin="0 5 2 10" Required="true"  Label="专业特点" ShowLabel="false">
                                              <f:RadioItem Text="对接国际标准" Value="对接国际标准"  />
                                               <f:RadioItem Text="聚焦民生需求"  Value="聚焦民生需求" />
                                                 <f:RadioItem Text="服务产业升级"  Value="服务产业升级" />
                                           </f:RadioButtonList>
                                         <%--  <f:CheckBox ID="CheckBox1" runat="server" Label="Label" Text="国际领先型"   ShowLabel="false"  Margin="0 5 2 10"></f:CheckBox>
                                            <f:CheckBox ID="CheckBox2" runat="server" Label="Label" Text="民生需求型"  ShowLabel="false" Margin="0 5 2 0"></f:CheckBox>
                                            <f:CheckBox ID="CheckBox3" runat="server" Label="Label" Text="行业特色型"  ShowLabel="false" Margin="0 5 2 0"></f:CheckBox>--%>
                                       </Items>
                                      </f:Panel>
                                 <f:Panel ID="Panel13" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                             <f:Label ID="Label3" runat="server" Label="专业开办时间" Text="专业开办时间:"  ShowLabel="false"></f:Label>
                                         <%--  <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM" Label="专业开办时间"   ID="ZYKBSJ" ShowRedStar="True"  ColumnWidth="20%" Margin="0 20 2 10" ShowLabel="false" Readonly="true" Enabled="false">
                </f:DatePicker>--%>
                                            <f:TextBox ID="ZYKBSJ" Label="专业开办时间" Required="true" ShowRedStar="true" ColumnWidth="20%" runat="server"  Readonly="true" Enabled="false" Margin="0 20 2 10"></f:TextBox>
                                             <f:Label ID="Label2" runat="server" Label="专业特点" Text="是否跨省招生:"  ShowLabel="false" ShowRedStar="true"></f:Label>
                                           <f:RadioButtonList ID="SFKSZS" runat="server"  ColumnWidth="20%" Margin="0 5 2 20" Required="true"  Label="是否跨省招生" ShowLabel="false">
                                               <f:RadioItem Text="是" Value="是"  />
                                               <f:RadioItem Text="否"  Value="否" />
                                           </f:RadioButtonList>
                                       </Items>
                                    
                                      </f:Panel>
                            <%--   <f:Form runat="server" Title="填写近三年专业招生就业情况" ID="Form3">
                                   <Items>
                               <f:Panel ID="Panel14" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:DropDownList ID="DropDownList_nf" runat="server" Label="选择年份"  ColumnWidth="30%" Margin="0 5 2 10" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_nf_SelectedIndexChanged">
                                                <f:ListItem Text="请选择" Value="请选择" />
                                              <f:ListItem Text="2012" Value="2012" />
                                                 <f:ListItem Text="2013" Value="2013" />
                                                 <f:ListItem Text="2014" Value="2014" />
                                           </f:DropDownList>
                                            </Items>
                                   
                                      </f:Panel>
                                        <f:Panel ID="Panel15" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="NumberBox_sjzss" runat="server" Label="实际招生数(人)"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 2 10"></f:NumberBox>
                                            <f:NumberBox ID="NumberBox_xsbdl" runat="server" Label="新生报到率(%)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 2 0"></f:NumberBox>
                                            <f:NumberBox ID="NumberBox_qrzzxss" runat="server" Label="全日制在校生人数(人)"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 2 0"></f:NumberBox>
                                            </Items>
                                   
                                      </f:Panel>
                                        <f:Panel ID="Panel16" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                            <f:NumberBox ID="NumberBox_ddpyrs" runat="server" Label="“订单”培养人数(人)"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 2 10"></f:NumberBox>
                                            <f:NumberBox ID="NumberBox_byss" runat="server" Label="毕业生人数(人)"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 2 0"></f:NumberBox>
                                            <f:NumberBox ID="NumberBox_ccjyl" runat="server" Label="初次就业率(%)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 2 0"></f:NumberBox>
                                         </Items>
                                   
                                      </f:Panel>
                                   
                                       </Items>
                                    <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button1" Text="添加" ValidateForms="Form3" ValidateMessageBox="false" runat="server" OnClick="Button1_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
                                   
                                   </f:Form>--%>
                                   <f:Panel ID="Panel17" Layout="Fit" CssClass="formitem"  runat="server"  Title="近三年专业招生就业情况列表"  ShowBorder="false" ShowHeader="true" RowHeight="300px">
                                       <Items>
                                           <f:Grid ID="Grid1" Title="Grid1"  ShowBorder="true" BoxFlex="1" 
                    ShowHeader="false" runat="server"  DataKeyNames="id" EnableCheckBoxSelect="true" EnableMultiSelect="false">
 <Toolbars>
                        <f:Toolbar ID="Toolbar5" runat="server">
                           <Items>
                              
                                

                               
                                <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button7" Text="删除" Hidden="true" runat="server" OnClick="Button7_Click" ConfirmText="确定删除？">
                                </f:Button>
                               
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                     <Columns>
                      
                        <f:BoundField Width="100px" DataField="nf"  HeaderText="年份"  ColumnID="Panel7_Grid1_ctl09" />
                      
                        <f:BoundField Width="150px" DataField="NumberBox_sjzss" HeaderText="实际招生数"  ColumnID="Panel7_Grid1_ctl10"  />
                        <f:BoundField Width="150px" DataField="NumberBox_xsbdl" HeaderText="新生报到率(%)"  ColumnID="Panel7_Grid1_ctl11" DataFormatString="{0:N2}"/>
                     <f:BoundField Width="200px" DataField="NumberBox_qrzzxss"  HeaderText="全日制在校生人数"  ColumnID="Panel7_Grid1_ctl12" />
                      
                        <f:BoundField Width="150px" DataField="NumberBox_ddpyrs" HeaderText="“订单”培养人数"  ColumnID="Panel7_Grid1_ctl13"  />
                        <f:BoundField Width="150px" DataField="NumberBox_byss" HeaderText="毕业生人数"  ColumnID="Panel7_Grid1_ctl14" />
                        <f:BoundField Width="150px" DataField="NumberBox_ccjyl" HeaderText="初次就业率(%)"  ColumnID="Panel7_Grid1_ctl15" DataFormatString="{0:N2}"/>
                    </Columns>
                </f:Grid>
                                       </Items>
                                   
                                      </f:Panel>
                                    <f:Panel ID="Panel18" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="ZRJSS" runat="server" Label="专任教师数（人）"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="10 5 10 2" Readonly="true" Enabled="false"  Text="0"></f:NumberBox>
                                         
                                            <f:NumberBox ID="JZJSS" runat="server" Label="兼职教师数（人）"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="10 5 10 0" Readonly="true" Enabled="false"  Text="0"></f:NumberBox>
                                            </Items>
                                   
                                      </f:Panel>
                                   <f:Form runat="server" Title="填写专业教师基本信息" ID="Form4">
                                   <Items>
                               <f:Panel ID="Panel19" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                          <f:Panel ID="Panel20" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label  runat="server" ID="Label_jsxm" Text="教师姓名："  ShowRedStar="true"></f:Label> <f:TextBox ID="TextBox1_jsxm" Label="教师姓名" Width="200px"   runat="server"     ShowLabel="false" ></f:TextBox> 
                 </Items></f:Panel>
                                                 <f:Panel ID="Panel49" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label4"  runat="server" Text="出生年月："  ></f:Label>
                                                   <%--  <f:DatePicker runat="server"  EnableEdit="false"  Readonly="true" Enabled="false"  Label="出生年月"   ID="DatePicker_csny" ShowRedStar="True"   ShowLabel="false" DateFormatString="yyyy-MM"></f:DatePicker>--%>
                                                       <f:TextBox runat="server"   Readonly="true" Enabled="false" Label="出生年月"   ID="DatePicker_csny" ShowRedStar="True"   ShowLabel="false" ></f:TextBox>
                                                     <f:HiddenField ID="HiddenField_csny" runat="server" Text=""></f:HiddenField></Items></f:Panel>
                                        
                                            <f:Panel ID="Panel50" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label5"  runat="server" Text="专/兼职："  ></f:Label>
                                                <f:TextBox ID="DropDownList_zjz1" Label="专/兼职"    runat="server"     ShowLabel="false"  Readonly="true" Enabled="false" ></f:TextBox> <f:HiddenField ID="HiddenField_zjz" runat="server" Text=""></f:HiddenField>
                                            </Items></f:Panel>
                                           
                                            <f:Panel ID="Panel51" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label6"  runat="server" Text="是否双师："  ></f:Label>
                                            

                                                   <f:TextBox ID="DropDownList_ss1" Label="是否双师"    runat="server"     ShowLabel="false"  Readonly="true" Enabled="false" ></f:TextBox> <f:HiddenField ID="HiddenField_ss" runat="server" Text=""></f:HiddenField>                                                                                                        </Items></f:Panel>
                                            </Items>
                                   
                                      </f:Panel>
                                        <f:Panel ID="Panel52" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                       
                                             <f:Panel ID="Panel53" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label7"  runat="server" Text="学历："  ></f:Label>
                                             
                                                 <f:TextBox ID="DropDownList_xl11" Label="学历"    runat="server"     ShowLabel="false"  Readonly="true" Enabled="false" ></f:TextBox><f:HiddenField ID="HiddenField_xl" runat="server" Text=""></f:HiddenField>  

                                                                                                                                                            </Items></f:Panel>
                                        
                                            <f:Panel ID="Panel54" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label8"  runat="server" Text="学位："  ></f:Label>
                                           
                                                  <f:TextBox ID="DropDownList_xw11" Label="学位"    runat="server"     ShowLabel="false"  Readonly="true" Enabled="false"  ></f:TextBox> <f:HiddenField ID="HiddenField_xw" runat="server" Text=""></f:HiddenField> 


                                                                                                                                                           </Items></f:Panel>
                                          
                                            <f:Panel ID="Panel55" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label9"  runat="server" Text="职称等级："  ></f:Label>
                                            

                                                  <f:TextBox ID="DropDownList_zcdj11" Label="职称等级"    runat="server"     ShowLabel="false"  Readonly="true" Enabled="false"  ></f:TextBox> <f:HiddenField ID="HiddenField_zcdj" runat="server" Text=""></f:HiddenField>
                                                                                                                                                           </Items></f:Panel>

                                            <f:Panel ID="Panel63" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:ContentPanel ID="ContentPanel5" runat="server" ShowBorder="false" ShowHeader="false"   >
                                              <Items>
                                                 
                                              </Items>
                                          </f:ContentPanel></Items></f:Panel>

                                            </Items>
                                   
                                      </f:Panel>
                                      
                                   
                                       </Items>
                                    <Toolbars>
                <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button2" Text="确定"  runat="server" OnClick="Button2_Click">
                        </f:Button>
                         <f:Button ID="Button2_add" Text="添加新的专业教师基本信息"  runat="server" OnClick="Button2_add_Click" >
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
                                   
                                   </f:Form>
                                  <f:Panel ID="Panel22" Layout="Fit" CssClass="formitem"  runat="server"  Title="已添加的专业教师基本信息列表"  ShowBorder="false" ShowHeader="true" RowHeight="300px">
                                       <Items>
                                           <f:Grid ID="Grid2" Title="Grid1"  ShowBorder="true" BoxFlex="1" 
                    ShowHeader="false" runat="server" DataKeyNames="id" EnableCheckBoxSelect="true" EnableMultiSelect="false" OnRowDataBound="Grid2_RowDataBound">
 <Toolbars>
                        <f:Toolbar ID="Toolbar6" runat="server">
                           <Items>
                              
                                

                               
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button5" Text="删除" runat="server" OnClick="Button5_Click" ConfirmText="确定删除？">
                                </f:Button>
                               
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                     <Columns>
                      
                        <f:BoundField Width="100px" DataField="jsxm"  HeaderText="教师姓名"  ColumnID="Panel7_Grid1_ctl091" />
                      
                        <f:BoundField Width="150px" DataField="csny" HeaderText="出生年月"  ColumnID="Panel7_Grid1_ctl101"  />
                      <%--  <f:BoundField Width="150px" DataField="zjz" HeaderText="专/兼职"  ColumnID="Panel7_Grid1_ctl111" />--%>
                           <f:TemplateField HeaderText="专/兼职">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("zjz")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                   <%--  <f:BoundField Width="200px" DataField="sfss"  HeaderText="是否双师"  ColumnID="Panel7_Grid1_ctl121" />--%>
                       <f:TemplateField HeaderText="是否双师">
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("sfss")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                        <f:BoundField Width="150px" DataField="xl" HeaderText="学历"  ColumnID="Panel7_Grid1_ctl131"  />
                        <f:BoundField Width="150px" DataField="xw" HeaderText="学位"  ColumnID="Panel7_Grid1_ctl141" />
                        <f:BoundField Width="150px" DataField="zcdj" HeaderText="职称等级"  ColumnID="Panel7_Grid1_ctl151" />
                    </Columns>
                </f:Grid>
                                       </Items>
                                   
                                      </f:Panel>
                                 <f:Panel ID="Panel23" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="XYZSSXSMJ" runat="server" Label="现有专属实训室面积（平方米）"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="40%" Margin="10 5 10 2"></f:NumberBox>
                                         
                                            <f:NumberBox ID="XYTYSXSMJ" runat="server" Label="现有通用实训室面积（平方米）"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="40%" Margin="10 5 10 0"></f:NumberBox>
                                            </Items>
                                   
                                      </f:Panel>
                                <f:Panel ID="Panel24" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="XYSXSBZZ" runat="server" Label="现有实训设备总值（万元）"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="40%" Margin="10 5 10 2"></f:NumberBox>
                                         
                                            <f:NumberBox ID="XYSXYQSB" runat="server" Label="现有实训仪器设备（台套）"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="40%" Margin="10 5 10 0"></f:NumberBox>
                                            </Items>
                                   
                                      </f:Panel>
                            </Items>
                        </f:GroupPanel>
                           <f:GroupPanel ID="GroupPanel11" Layout="Anchor" Title="<strong>申报专业与标杆专业对比分析</strong>" runat="server">
                            <Items>
                                      <f:Panel ID="Panel14" Layout="Column" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server"  Title="标杆专业情况">
                                       <Items>
                                         <%-- <f:Panel ID="Panel60" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  Title="标杆专业情况">
                                       <Items>--%>
                                           <f:Label ID="Label12" runat="server" Label="Label" Text="为体现 “一流”建设目标，需在国内外选择一所高校的标杆专业，并进行对比分析。" ShowLabel="false" ColumnWidth="100%" Margin="10 5 0 2"></f:Label>
                                          <%-- </Items>
                                              </f:Panel>
                                             <f:Panel ID="Panel61" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  Title="院校名称">
                                       <Items>--%>
                                           <f:TextBox ID="TextBox1_yxmc" runat="server" Label="院校名称" Text=""  Required="true" ShowRedStar="true" ColumnWidth="50%"  Margin="2 5 10 2"></f:TextBox>
                                           <%--</Items>
                                              </f:Panel>
                                             <f:Panel ID="Panel62" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  Title="专业名称">
                                       <Items>--%>
                                           <f:TextBox ID="TextBox2_zymc" runat="server" Label="专业名称" Text="" Required="true" ShowRedStar="true" ColumnWidth="50%"  Margin="2 5 10 2"></f:TextBox>
                                         <%--  </Items>
                                              </f:Panel>--%>
                                       </Items>
                                   
                                      </f:Panel>
                                 <f:Panel ID="Panel15" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="TextArea_xzly" runat="server" Height="200px" Label="选择理由" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="请简要阐述选择标杆专业的理由，包括该专业现状及优势分析。" Required="true" ShowRedStar="true"></f:TextArea>
                                       </Items>
                                   
                                     
                                      </f:Panel>
                                 <f:Panel ID="Panel16" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="TextArea_dbfx" runat="server" Height="200px" Label="对比分析" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="请简要阐述本校申报专业与标杆专业的差距。" Required="true" ShowRedStar="true"></f:TextArea>
                                       </Items>
                                   
                                      </f:Panel>
                                

                                 </Items>
                        </f:GroupPanel>
                         <f:GroupPanel ID="GroupPanel6" Layout="Anchor" Title="<strong>申报项目建设方案</strong>" runat="server">
                            <Items>
                                      <f:Panel ID="Panel25" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="SBLY" runat="server" Height="200px" Label="申报理由" Text=""  ColumnWidth="80%" Margin="10 5 10 0" EmptyText="请简要说明开展项目建设的必要性和可行性。（不超过500字）"  Required="true" ShowRedStar="true" MaxLength="800"></f:TextArea>
                                       </Items>
                                   
                                      </f:Panel>
                                 <f:Panel ID="Panel26" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="JSMB" runat="server" Height="200px" Label="建设目标" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="请简要阐述项目建设总体目标。（不超过500字）" Required="true" ShowRedStar="true" MaxLength="800"></f:TextArea>
                                       </Items>
                                   
                                     
                                      </f:Panel>
                                 <f:Panel ID="Panel27" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="JTJC" runat="server" Height="200px" Label="具体举措" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="请简要阐述建设内容及举措。（不超过1000字）" Required="true" ShowRedStar="true" MaxLength="1500"></f:TextArea>
                                       </Items>
                                   
                                      </f:Panel>
                                 <f:Panel ID="Panel28" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="JFAP" runat="server" Height="200px" Label="经费安排" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="请阐述项目总体需要经费、来源和主要用途。（不超过500字）" Required="true" ShowRedStar="true" MaxLength="800"></f:TextArea>
                                       </Items>
                                   
                                      </f:Panel>

                                 <f:Panel ID="Panel29" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="SSJH" runat="server" Height="200px" Label="实施计划" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="请简要阐述项目实施计划，执行周期为1年的项目需按季度列明实施计划，其他项目按照年度填写。（不超过500字）" Required="true" ShowRedStar="true" MaxLength="800"></f:TextArea>
                                       </Items>
                                   
                                      </f:Panel>
                                 </Items>
                        </f:GroupPanel>

                          <f:GroupPanel ID="GroupPanel7" Layout="Anchor" Title="<strong>项目验收指标</strong>（请分别说明各建设目标，并列出验收要点，预期完成时间从项目立项之日起计算。）" runat="server">
                            <Items>
                                  <f:Form runat="server" Title="添加项目验收指标" ID="Form5" Margin="0 0 10 0">
                                   <Items>
                                      <f:Panel ID="Panel30" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="TextArea_jsmb" runat="server" Height="100px" Label="建设目标" Text=""  ColumnWidth="80%" Margin="10 5 10 5"   ShowRedStar="True"></f:TextArea>
                                       </Items>
                                   
                                      </f:Panel>
                              <f:Panel ID="Panel31" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                          <f:DatePicker runat="server"  EnableEdit="false" Label="预期完成时间" EmptyText="请选择日期"  ID="DatePicker_yqwcsj" ShowRedStar="True"  ColumnWidth="80%" Margin="0 5 10 5" ></f:DatePicker>
                                       </Items>
                                   
                                      </f:Panel>
                                  <f:Panel ID="Panel32" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextArea ID="TextArea_ysyd" runat="server" Height="200px" Label="验收要点" Text=""  ColumnWidth="80%" Margin="0 5 10 5"    ShowRedStar="True" ></f:TextArea>
                                       </Items>
                                   
                                      </f:Panel>
                                       </Items>
                                       <Toolbars>
                <f:Toolbar ID="Toolbar3" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button3" Text="添加到项目验收指标列表" ValidateForms="Form5" ValidateMessageBox="false" runat="server" OnClick="Button3_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
                                       </f:Form>
                                    <f:Panel ID="Panel21" Layout="Fit" CssClass="formitem"  runat="server"  Title="已添加的项目验收指标列表"  ShowBorder="false" ShowHeader="true"   Margin="0 5 10 0">
                                       <Items>
                                           <f:Grid ID="Grid3" Title="Grid1"  ShowBorder="true" BoxFlex="1" 
                    ShowHeader="false" runat="server" DataKeyNames="id" EnableCheckBoxSelect="true" EnableMultiSelect="false"  >
 <Toolbars>
                        <f:Toolbar ID="Toolbar7" runat="server">
                           <Items>
                              
                                

                               
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button6" Text="删除" runat="server" OnClick="Button6_Click" ConfirmText="确定删除？">
                                </f:Button>
                               
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                     <Columns>
                      
                        <f:BoundField Width="150px" DataField="jsmb"  HeaderText="建设目标"  DataToolTipField="jsmb"   ColumnID="Panel7_Grid1_ctl092" />
                      
                        <f:BoundField Width="120px" DataField="yqwcsj" HeaderText="预期完成时间" DataToolTipField="yqwcsj"  ColumnID="Panel7_Grid1_ctl102"  />
                        <f:BoundField Width="150px" DataField="ysyd" DataToolTipField="ysyd" HeaderText="验收要点"  ColumnID="Panel7_Grid1_ctl112" />
                     
                    </Columns>
                </f:Grid>
                                       </Items>
                                   
                                      </f:Panel>
                                 </Items>
                        </f:GroupPanel>

                         <f:GroupPanel ID="GroupPanel8" Layout="Anchor" Title="<strong>经费预算</strong>" runat="server">
                            <Items>
                             <f:GroupPanel ID="GroupPanel9" Layout="Anchor" Title="<strong>申请专项经费</strong>" runat="server">
                            <Items>
                                  <f:Panel ID="Panel33" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="NumberBox_sqzxjfhj" runat="server" Label="申请专项经费合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false"></f:NumberBox>
                                             <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期"  ID="DatePicker_sqzxjfzxksrq" ShowRedStar="True"  ColumnWidth="30%" Margin="0 5 5 5" ></f:DatePicker>
                                          <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="DatePicker_sqzxjfzxksrq" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期"  ID="DatePicker_sqzxjfzxjsrq" ShowRedStar="True"  ColumnWidth="30%" Margin="0 5 5 5" ></f:DatePicker>
                                          
                                            </Items>
                                   
                                      </f:Panel>
                                 <f:Panel ID="Panel34" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server"  Title="预算明细(2015年)" Margin="0 5 5 0">
                                       <Items>
                                            <f:Panel ID="Panel37" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>

                                           <f:NumberBox ID="NumberBox_sqzxjfkcjcjf_2015" runat="server" Label="课程教材经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_sqzxjfszpxjf_2015" runat="server" Label="师资培训经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfszpxjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                           
                                                  <f:NumberBox ID="NumberBox_sqzxjfyqsbjf_2015" runat="server" Label="仪器设备经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                          
                                           </Items>
                                                </f:Panel>
                                            <f:Panel ID="Panel35" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                              <f:NumberBox ID="NumberBox_sqzxjfwpryfy_2015" runat="server" Label="外聘人员费用(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                              <f:NumberBox ID="NumberBox_sqzxjfywf_2015" runat="server" Label="业务费（包括差旅、印刷、交通等）(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfywf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                             <f:NumberBox ID="NumberBox_sqzxjfgshj_2015" runat="server" Label="经费概算合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                             </Items>
                                                </f:Panel>
                                         
                                            </Items>
                                      </f:Panel>
                                 <f:Panel ID="Panel36" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server"  Title="预算明细(2016年)" Margin="0 5 5 0">
                                       <Items>
                                            <f:Panel ID="Panel38" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>

                                           <f:NumberBox ID="NumberBox_sqzxjfkcjcjf_2016" runat="server" Label="课程教材经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_sqzxjfszpxjf_2016" runat="server" Label="师资培训经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfszpxjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                           
                                                  <f:NumberBox ID="NumberBox_sqzxjfyqsbjf_2016" runat="server" Label="仪器设备经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                          
                                           </Items>
                                                </f:Panel>
                                            <f:Panel ID="Panel39" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                              <f:NumberBox ID="NumberBox_sqzxjfwpryfy_2016" runat="server" Label="外聘人员费用(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                              <f:NumberBox ID="NumberBox_sqzxjfywf_2016" runat="server" Label="业务费（包括差旅、印刷、交通等）(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfywf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                             <f:NumberBox ID="NumberBox_sqzxjfgshj_2016" runat="server" Label="经费概算合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                             </Items>
                                                </f:Panel>
                                         
                                            </Items>
                                      </f:Panel>

                                 <f:Panel ID="Panel40" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server"  Title="预算明细(2017年)" Margin="0 5 5 0">
                                       <Items>
                                            <f:Panel ID="Panel58" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>

                                           <f:NumberBox ID="NumberBox_sqzxjfkcjcjf_2017" runat="server" Label="课程教材经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_sqzxjfszpxjf_2017" runat="server" Label="师资培训经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfszpxjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                           
                                                  <f:NumberBox ID="NumberBox_sqzxjfyqsbjf_2017" runat="server" Label="仪器设备经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                          
                                           </Items>
                                                </f:Panel>
                                            <f:Panel ID="Panel59" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                              <f:NumberBox ID="NumberBox_sqzxjfwpryfy_2017" runat="server" Label="外聘人员费用(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                              <f:NumberBox ID="NumberBox_sqzxjfywf_2017" runat="server" Label="业务费（包括差旅、印刷、交通等）(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfywf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                             <f:NumberBox ID="NumberBox_sqzxjfgshj_2017" runat="server" Label="经费概算合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                             </Items>
                                                </f:Panel>
                                         
                                            </Items>
                                      </f:Panel>
                            </Items>
                        </f:GroupPanel> 
                                 <f:GroupPanel ID="GroupPanel10" Layout="Anchor" Title="<strong>学校配套经费</strong>" runat="server">
                            <Items>
                                  <f:Panel ID="Panel41" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="NumberBox_xxptjfhj" runat="server" Label="学校配套经费合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false"></f:NumberBox>
                                             <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期"  ID="DatePicker_xxptjfzxksrq" ShowRedStar="True"  ColumnWidth="30%" Margin="0 5 5 5" ></f:DatePicker>
                                          <f:DatePicker runat="server" Required="true" EnableEdit="false"  DateFormatString="yyyy-MM-dd" CompareControl="DatePicker_xxptjfzxksrq" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期"  ID="DatePicker_xxptjfzxjsrq" ShowRedStar="True"  ColumnWidth="30%" Margin="0 5 5 5" ></f:DatePicker>
                                          
                                            </Items>
                                   
                                      </f:Panel>
                                 <f:Panel ID="Panel42" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server"  Title="预算明细(2015年)" Margin="0 5 5 0">
                                       <Items>
                                            <f:Panel ID="Panel43" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="NumberBox_xxptkcjcjf_2015" runat="server" Label="课程教材经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                          <f:NumberBox ID="NumberBox_xxptszpxf_2015" runat="server" Label="师资培训经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptszpxf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_xxptyqsbjf_2015" runat="server" Label="仪器设备经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             </Items>
                                   
                                      </f:Panel>
                                          
                                           <f:Panel ID="Panel44" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  >
                                       <Items>
                                            <f:NumberBox ID="NumberBox_xxptwpryfy_2015" runat="server" Label="外聘人员费用(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                           <f:NumberBox ID="NumberBox_xxptywf_2015" runat="server" Label="业务费（包括差旅、印刷、交通等）(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptywf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_xxptgshj_2015" runat="server" Label="经费概算合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                          
                                            </Items>
                                   
                                      </f:Panel> 
                                   
                                     
                                 
                                

                                            </Items>
                                      </f:Panel>
                                    <f:Panel ID="Panel45" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server"  Title="预算明细(2016年)" Margin="0 5 5 0">
                                       <Items>
                                            <f:Panel ID="Panel46" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="NumberBox_xxptkcjcjf_2016" runat="server" Label="课程教材经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                          <f:NumberBox ID="NumberBox_xxptszpxf_2016" runat="server" Label="师资培训经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptszpxf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_xxptyqsbjf_2016" runat="server" Label="仪器设备经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             </Items>
                                   
                                      </f:Panel>
                                          
                                           <f:Panel ID="Panel47" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  >
                                       <Items>
                                            <f:NumberBox ID="NumberBox_xxptwpryfy_2016" runat="server" Label="外聘人员费用(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                           <f:NumberBox ID="NumberBox_xxptywf_2016" runat="server" Label="业务费（包括差旅、印刷、交通等）(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptywf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_xxptgshj_2016" runat="server" Label="经费概算合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                          
                                            </Items>
                                   
                                      </f:Panel> 
                                   
                                     
                                 
                                

                                            </Items>
                                      </f:Panel>

                                 <f:Panel ID="Panel48" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server"  Title="预算明细(2017年)" Margin="0 5 5 0">
                                       <Items>
                                            <f:Panel ID="Panel60" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:NumberBox ID="NumberBox_xxptkcjcjf_2017" runat="server" Label="课程教材经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                          <f:NumberBox ID="NumberBox_xxptszpxf_2017" runat="server" Label="师资培训经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptszpxf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_xxptyqsbjf_2017" runat="server" Label="仪器设备经费(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             </Items>
                                   
                                      </f:Panel>
                                          
                                           <f:Panel ID="Panel61" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server"  >
                                       <Items>
                                            <f:NumberBox ID="NumberBox_xxptwpryfy_2017" runat="server" Label="外聘人员费用(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                           <f:NumberBox ID="NumberBox_xxptywf_2017" runat="server" Label="业务费（包括差旅、印刷、交通等）(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptywf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                             <f:NumberBox ID="NumberBox_xxptgshj_2017" runat="server" Label="经费概算合计(万元)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                          
                                            </Items>
                                   
                                      </f:Panel> 
                                   
                                     
                                 
                                

                                            </Items>
                                      </f:Panel>
                            </Items>
                        </f:GroupPanel> 
                            </Items>
                        </f:GroupPanel>
                         <f:Panel ID="Panel56" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="550px"  EnableCollapse="true"
            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
            <Items>
               
                <f:FileUpload runat="server" ID="FileUpload1" EmptyText="请选择上传附件一" Label="项目可行性分析报告" 
                     >
                </f:FileUpload>
                   <f:HyperLink ID="HyperLink1" Text="下载项目可行性分析报告模板" Target="_blank" NavigateUrl="WordMaster/附件一项目可行性分析报告.doc" runat="server">
                                </f:HyperLink>
                <f:Button ID="btnSubmit" runat="server" OnClick="btnSubmit1_Click" ValidateForms="SimpleForm1"
                    Text="上传">
                </f:Button>
            </Items>
        </f:SimpleForm>
                            </Items>
                        </f:Panel>

                         <f:Panel ID="Panel57" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               <f:SimpleForm ID="SimpleForm2" BodyPadding="5px" runat="server" Width="550px"  EnableCollapse="true"
            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
            <Items>
               
                <f:FileUpload runat="server" ID="FileUpload2" EmptyText="请选择上传附件二" Label="优秀学生案例" 
                    >
                </f:FileUpload>
                  <f:HyperLink ID="HyperLink2" Text="下载优秀学生案例模板" Target="_blank" NavigateUrl="WordMaster/附件二优秀学生案例.doc" runat="server">
                                </f:HyperLink>
                <f:Button ID="Button8" runat="server" OnClick="btnSubmit2_Click" ValidateForms="SimpleForm2"
                    Text="上传">
                </f:Button>
            </Items>
        </f:SimpleForm>
                            </Items>
                        </f:Panel>

                        <f:Panel ID="Panel62" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               <f:SimpleForm ID="SimpleForm3" BodyPadding="5px" runat="server" Width="550px"  EnableCollapse="true"
            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
            <Items>
               
                <f:FileUpload runat="server" ID="FileUpload3" EmptyText="请选择上传附件三" Label="项目预算明细表"  >
                </f:FileUpload>
                 <f:HyperLink ID="HyperLink3" Text="下载项目预算明细表模板" Target="_blank" NavigateUrl="WordMaster/附件三 项目预算明细表.doc" runat="server">
                                </f:HyperLink>
                <f:Button ID="Button1" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                    Text="上传">
                </f:Button>
            </Items>
        </f:SimpleForm>
                            </Items>
                        </f:Panel>
                    </Items>
                      <Toolbars>
                <f:Toolbar ID="Toolbar4" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button4" Text="保存数据" ValidateForms="Form2" ValidateMessageBox="true" runat="server" OnClick="Button4_Click"  Margin="10 5 10 0">
                        </f:Button>
                        <%--  <f:Button ID="Button5" Text="test" runat="server" OnClick="Button5_Click">
                        </f:Button>--%>
                    </Items>
                </f:Toolbar>
            </Toolbars>
                </f:SimpleForm>
            </Items>
          </f:Panel>
          <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="600px" Height="450px">
          
        </f:Window>
    </form>
      <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TextBox1_jsxm = '<%= TextBox1_jsxm.ClientID %>';
        var DatePicker_csny = '<%= DatePicker_csny.ClientID %>';
        var hid_csny = '<%= HiddenField_csny.ClientID %>';
        var DropDownList_zjz = '<%= DropDownList_zjz1.ClientID %>';
        var hid_zjz = '<%= HiddenField_zjz.ClientID %>';
        var DropDownList_ssf = '<%= DropDownList_ss1.ClientID %>';
        var hid_ss = '<%= HiddenField_ss.ClientID %>';
        var DropDownList_xl = '<%= DropDownList_xl11.ClientID %>';
        var hid_xl = '<%= HiddenField_xl.ClientID %>';
        var DropDownList_xw = '<%= DropDownList_xw11.ClientID %>';
        var hid_xw = '<%= HiddenField_xw.ClientID %>';
        var DropDownList_zcdj = '<%= DropDownList_zcdj11.ClientID %>';
        var hid_zcdj = '<%= HiddenField_zcdj.ClientID %>';

        F.ready(function () {



            //function showTips(txt, time, status) {
            //    var htmlCon = '';
            //    if (txt != '') {
            //        if (status != 0 && status != undefined) {
            //            htmlCon = '<div class="tipsBox" style="width:220px;padding:10px;background-color:#4AAF33;border-radius:4px;-webkit-border-radius: 4px;-moz-border-radius: 4px;color:#fff;box-shadow:0 0 3px #ddd inset;-webkit-box-shadow: 0 0 3px #ddd inset;text-align:center;position:fixed;top:25%;left:50%;z-index:999999;margin-left:-120px;"><img src="images/ok.png" style="vertical-align: middle;margin-right:5px;" alt="OK，"/>' + txt + '</div>';
            //        } else {
            //            htmlCon = '<div class="tipsBox" style="width:220px;padding:10px;background-color:#D84C31;border-radius:4px;-webkit-border-radius: 4px;-moz-border-radius: 4px;color:#fff;box-shadow:0 0 3px #ddd inset;-webkit-box-shadow: 0 0 3px #ddd inset;text-align:center;position:fixed;top:25%;left:50%;z-index:999999;margin-left:-120px;"><img src="images/err.png" style="vertical-align: middle;margin-right:5px;" alt="Error，"/>' + txt + '</div>';
            //        }
            //        $('body').prepend(htmlCon);
            //        if (time == '' || time == undefined) {
            //            time = 1500;
            //        }
            //        setTimeout(function () { $('.tipsBox').remove(); }, time);
            //    }
            //}

            //$(function () {
            //    //AJAX提交以及验证表单
            //    $('#nextBtn').click(function () {
            //        var email = $('.email').val();
            //        var passwd = $('.passwd').val();
            //        var passwd2 = $('.passwd2').val();
            //        var verifyCode = $('.verifyCode').val();
            //        var EmailReg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/; //邮件正则
            //        if (email == '') {
            //            showTips('请填写您的邮箱~');
            //        } else if (!EmailReg.test(email)) {
            //            showTips('您的邮箱格式错咯~');
            //        } else if (passwd == '') {
            //            showTips('请填写您的密码~');
            //        } else if (passwd2 == '') {
            //            showTips('请再次输入您的密码~');
            //        } else if (passwd != passwd2 || passwd2 != passwd) {
            //            showTips('两次密码输入不一致呢~');
            //        } else if (verifyCode == '') {
            //            showTips('请输入验证码~');
            //        } else {
            //            showTips('提交成功~ 即将进入下一步', 2500, 1);
            //            //此处省略 ajax 提交表单 代码...
            //        }
            //    });

            //    //切换步骤（目前只用来演示）
            //    //$('.processorBox li').click(function () {
            //    //    var i = $(this).index();
            //    //    //alert(i)
            //    //    $('.processorBox li').removeClass('current').eq(i).addClass('current');
            //    //    $('.step').fadeOut(300).eq(i).fadeIn(500);
            //    //});
            //});





            var cache = {};



            $('#' + TextBox1_jsxm + ' input').autocomplete({
                minLength: 1,
                source: function (request, response) {
                    var term1 = request.term;


                    $('#' + DatePicker_csny + ' input').val('');
                    $('#' + hid_csny + ' input').val('');
                    $('#' + DropDownList_zjz + ' input').val('');
                    $('#' + hid_zjz + ' input').val('');
                    //alert($('#' + hid_zjz + ' input').val());
                    $('#' + DropDownList_ssf + ' input').val('');
                    $('#' + hid_ss + ' input').val('');
                    $('#' + DropDownList_xl + ' input').val('');
                    $('#' + hid_xl + ' input').val('');
                    $('#' + DropDownList_xw + ' input').val('');
                    $('#' + hid_xw + ' input').val('');
                    $('#' + DropDownList_zcdj + ' input').val('');
                    $('#' + hid_zcdj + ' input').val('');

                    $.getJSON("search_jsxx.ashx?timestamp=" + new Date().getTime(), request, function (data, status, xhr) {
                        cache[term1] = data;
                        //alert(cache[term1])
                        response(cache[term1]);


                    });
                },
                select: function (event, ui) {
                    var $this = $(this);
                    $this.val(ui.item.jsxm);

                    //$('#' + DatePicker_csny + ' input').val("");
                    //$('#' + DropDownList_zjz + ' input').val("");
                    //$('#' + DropDownList_ssf + ' input').val("");
                    //$('#' + DropDownList_xl + ' input').val("");
                    //$('#' + DropDownList_xw + ' input').val("");
                    //$('#' + DropDownList_zcdj + ' input').val("");

                    $('#' + DatePicker_csny + ' input').val(ui.item.csny);
                    $('#' + hid_csny + ' input').val(ui.item.csny);
                    $('#' + DropDownList_zjz + ' input').val(ui.item.zzjz);
                    $('#' + hid_zjz + ' input').val(ui.item.zzjz);
                    //alert($('#' + hid_zjz + ' input').val());
                    $('#' + DropDownList_ssf + ' input').val(ui.item.sfss);
                    $('#' + hid_ss + ' input').val(ui.item.sfss);
                    $('#' + DropDownList_xl + ' input').val(ui.item.xl);
                    $('#' + hid_xl + ' input').val(ui.item.xl);
                    $('#' + DropDownList_xw + ' input').val(ui.item.xw);
                    $('#' + hid_xw + ' input').val(ui.item.xw);
                    $('#' + DropDownList_zcdj + ' input').val(ui.item.zcdj);
                    $('#' + hid_zcdj + ' input').val(ui.item.zcdj);
                    //jsSelectItemByValue(document.getElementById(DropDownList_zjz), ui.item.zzjz);
                    //jsSelectItemByValue(document.getElementById(DropDownList_ssf), ui.item.sfss);
                    //jsSelectItemByValue(document.getElementById(DropDownList_xl), ui.item.xl);
                    //jsSelectItemByValue(document.getElementById(DropDownList_xw), ui.item.xw);

                    cache = {};
                    return false;
                }
            }).autocomplete("instance")._renderItem = function (ul, item) {

                return $("<li>")
                    .append("<a><span class='autocomplete-item-title'>姓名：" + item.jsxm + "</span><br/>出生年月：" + item.csny + "</a>")
                    .appendTo(ul);
            };

        });

        function jsSelectItemByValue(objSelect, objItemText) {
            flag = 0;
            for (var i = 0; i < objSelect.options.length; i++) {
                if (objSelect.options[i].text == objItemText) {
                    objSelect.options[i].selected = true;
                    flag = 1
                    break;
                }
            }
            if (flag == 0)
                objSelect.options[0].selected = true;
        }




        function a(index) {

            //for (var i = 1; i <= 8; i++) {
            //    if (index != i) {
            //        $('#s' + i).removeClass('step block');
            //        $('#s' + i).addClass('step hide');
            //    }
            //    else {
            //        $('#s' + i).removeClass('step hide');
            //        $('#s' + i).addClass('step block');
            //    }
            //}

            $('.processorBox li').removeClass('current').eq(index - 1).addClass('current');
            $('.step').fadeOut(300).eq(index - 1).fadeIn(500);

        }



        //显示提示框，目前三个参数(txt：要显示的文本；time：自动关闭的时间（不设置的话默认1500毫秒）；status：默认0为错误提示，1为正确提示；)

        //function CloseWebPage() {
        //    if (navigator.userAgent.indexOf("MSIE") > 0) {
        //        if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {
        //            window.opener = null;
        //            window.close();
        //        } else {
        //            window.open('', '_top');
        //            window.top.close();
        //        }
        //    }
        //    else if (navigator.userAgent.indexOf("Firefox") > 0) {
        //        window.location.href = 'about:blank ';
        //    } else {
        //        window.opener = null;
        //        window.open('', '_self', '');
        //        window.close();
        //    }

        //}
    </script>
</body>
</html>

