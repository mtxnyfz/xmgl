<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XM_YLFW_Add.aspx.cs" Inherits="XMGL.Web.admin.XM_YLFW_Add" %>

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
</head>
<body>
    <form id="form1" runat="server">
   <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="DropDownList_xb" />
         <f:Panel ID="Panel1" runat="server" BodyPadding="5px"
            Title="添加项目" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" Height="1000px"  BoxConfigAlign="Stretch" Margin="0 10 5 0">
            <Items>
                  <f:SimpleForm  ID="Form2"  BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server">
                    <Items>
                        <f:GroupPanel ID="GroupPanel6" Layout="Anchor" Title="<strong>基本信息</strong>" runat="server">
                            <Items>
                         <f:Panel ID="Panel23" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                 <%--  <f:TextBox ID="TextBox_zyfx" Label="专 业 方 向" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"    Margin="0 5 2 0">  </f:TextBox>--%>
                                 <f:DropDownList ID="ZYMC" runat="server" Label="专业名称"  Required="true" ShowRedStar="true" ColumnWidth="33%" OnSelectedIndexChanged="ZYMC_SelectedIndexChanged" AutoPostBack="true" Margin="0 5 2 0"></f:DropDownList>
                                  <f:TextBox ID="TextBox_lxr" Label="联  系  人" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"    Margin="0 5 2 0">  </f:TextBox>
                                 <f:TextBox ID="TextBox_dh" Label="联系电话（含手机）" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server"    Margin="0 5 2 0">  </f:TextBox>
                            </Items>
                        </f:Panel>
                                </Items>
                                </f:GroupPanel>
                         <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="<strong>专业基本情况</strong>" runat="server">
                            <Items>
                         <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                                 <f:TextBox ID="ZYDM" Label="专业代码" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">  </f:TextBox>
                              <%--   <f:TextBox ID="TextBox_xynx1" Label="修业年限" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server"  Readonly="true"  Margin="0 5 2 0">  </f:TextBox>--%>
                                  <f:NumberBox ID="NumberBox_xynx" runat="server" Label="修业年限"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0"></f:NumberBox>
                            </Items>
                        </f:Panel>
                                 <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              <%-- <f:TextBox ID="TextBox_zyszsj" Label="专业设置时间" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="true"  Enabled="false" Margin="0 5 2 0">  </f:TextBox>

                                 <f:TextBox ID="TextBox_sjbysj" Label="首届毕业生时间" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server"  Readonly="true" Enabled="false" Margin="0 5 2 0">  </f:TextBox>--%>
                                  <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM" Label="专业设置时间"   ID="TextBox_zyszsj" ShowRedStar="True"  ColumnWidth="33%" Margin="0 5 2 0" ShowLabel="true" Readonly="true" Enabled="false">
                </f:DatePicker>
                                   <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM" Label="首届毕业生时间"   ID="TextBox_sjbysj" ShowRedStar="True"  ColumnWidth="33%" Margin="0 5 2 0" ShowLabel="true" >
                                     
                                         
                </f:DatePicker>

                                 <f:NumberBox ID="zyzxss" runat="server" Label="专业在校生数（人）"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0"></f:NumberBox>
                               
                            </Items>
                        </f:Panel>
                                 <f:Panel ID="Panel17" Layout="Fit" CssClass="formitem"  runat="server"  Title="近三年专业招生就业情况列表"  ShowBorder="false" ShowHeader="true" RowHeight="300px">
                                       <Items>
                                           <f:Grid ID="Grid1" Title="Grid1"  ShowBorder="true" BoxFlex="1" 
                    ShowHeader="false" runat="server"  DataKeyNames="id" >
 <Toolbars>
                        <f:Toolbar ID="Toolbar5" runat="server">
                           <Items>
                              
                                

                               
                                <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                </f:ToolbarSeparator>
                               
                               
                              
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                     <Columns>
                      
                        <f:BoundField Width="100px" DataField="nf"  HeaderText="年份"  ColumnID="Panel7_Grid1_ctl09" />
                      
                        <f:BoundField Width="150px" DataField="SJZSS" HeaderText="当年实际招生数(人)"  ColumnID="Panel7_Grid1_ctl10"  />
                        <f:BoundField Width="150px" DataField="DNBYSS" HeaderText="当年毕业生数(人)"  ColumnID="Panel7_Grid1_ctl11" />
                     <f:BoundField Width="200px" DataField="YCXJYL"  HeaderText="一次性就业率(%)"  ColumnID="Panel7_Grid1_ctl12" DataFormatString="{0:N2}"/>
                     
                        <f:BoundField Width="200px" DataField="JYDKL" HeaderText="就业对口率(%)"  ColumnID="Panel7_Grid1_ctl15" DataFormatString="{0:N2}"/>
                    </Columns>
                </f:Grid>
                                       </Items>
                                   
                                      </f:Panel>
                                </Items>
                                </f:GroupPanel>
                          <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="<strong>专业教学团队基本情况</strong>" runat="server">
                            <Items>
                                <f:GroupPanel runat="server" Title="专业带头人基本情况">
                                    <Items>
                                  <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                                  <f:Panel ID="Panel8" runat="server" Margin="5 5 2 10" ColumnWidth="33%" ShowBorder="false" ShowHeader="false"><Items><f:Label  runat="server" ID="Label_jsxm" Text="姓名："  ShowRedStar="true" Enabled="false"></f:Label> <f:TextBox ID="TextBox1_jsxm" Label="姓名" Width="200px" Required="true" ShowRedStar="true"  runat="server" Readonly="true" Enabled="false"     ShowLabel="false" ></f:TextBox> 
                 </Items></f:Panel>
                                  <f:Panel ID="Panel50" runat="server" Margin="5 5 2 10" ColumnWidth="33%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label5"  runat="server" Text="性  别："  Enabled="false"></f:Label>
                                                <f:ContentPanel runat="server" ShowBorder="false" ShowHeader="false"  >
                                              <Items>
                                                  <asp:DropDownList ID="DropDownList_xb" runat="server" Enabled="false">
                                                     <asp:ListItem Text="请选择" Value="请选择" />
                                                       <asp:ListItem Text="男" Value="男" />
                                                       <asp:ListItem Text="女" Value="女" />

                                                     
                                                  </asp:DropDownList>
                                              </Items>
                                          </f:ContentPanel>
                                              </Items></f:Panel>
                                 
                                                 <f:Panel ID="Panel49" runat="server" Margin="5 5 2 10" ColumnWidth="33%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label4"  runat="server" Text="出生年月："  Enabled="false"></f:Label><f:DatePicker runat="server" Required="true" EnableEdit="false" Readonly="true" Enabled="false" Label="出生年月"   ID="DatePicker_csny" ShowRedStar="True"   ShowLabel="false" DateFormatString="yyyy-MM"></f:DatePicker> <f:HiddenField ID="HiddenField_csny" runat="server" Text=""></f:HiddenField>
                                                 </Items></f:Panel>
                            </Items>
                        </f:Panel>
                                 <f:Panel ID="Panel5" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                                 <f:Panel ID="Panel52" runat="server" Margin="5 5 2 10" ColumnWidth="33%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label7"  runat="server" Text="最高学历："  Enabled="false"></f:Label>
                                           
                                                 <f:TextBox ID="DropDownList_xl" Label="最高学历"    runat="server"     ShowLabel="false" Readonly="true" Enabled="false" ></f:TextBox>  
                                     <f:HiddenField ID="HiddenField_xl" runat="server" Text=""></f:HiddenField>
                                                                                                                                                            </Items></f:Panel>
                                 <f:Panel ID="Panel53" runat="server" Margin="5 5 2 10" ColumnWidth="33%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label8"  runat="server" Text="学位："  Enabled="false"></f:Label>
                                             
                                                  <f:TextBox ID="DropDownList_xw" Label="学位"    runat="server"     ShowLabel="false" Readonly="true" Enabled="false" ></f:TextBox>  
                                     <f:HiddenField ID="HiddenField_xw" runat="server" Text=""></f:HiddenField>

                                                                                                                                                           </Items></f:Panel>
                                  <f:Panel ID="Panel9" runat="server" Margin="5 5 2 10" ColumnWidth="33%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label1"  runat="server" Text="专业技术职务："  Enabled="false"></f:Label>
                                             
                                                  <f:TextBox ID="TextBox_zyjszw" Label="专业技术职务"    runat="server"     ShowLabel="false" Readonly="true" Enabled="false" ></f:TextBox>  


                                                                                                                                                           </Items></f:Panel>
                            </Items>
                        </f:Panel>
                                                                 <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                   <f:TextBox ID="TextBox_zw" Label="职务（包括社会兼职）" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"    Margin="0 5 2 0" Readonly="true" Enabled="false">  </f:TextBox>
                                  <f:TextBox ID="TextBox_cszy" Label="从事专业" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"    Margin="0 5 2 0">  </f:TextBox>
                            </Items>
                        </f:Panel>

                                 <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                   <f:TextBox ID="TextBox_lxdh" Label="联系电话(单位/手机)" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"    Margin="0 5 2 0" Readonly="true" Enabled="false">  </f:TextBox>
                                  <f:TextBox ID="TextBox_yx" Label="邮  箱" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"    Margin="0 5 2 0" Readonly="true" Enabled="false">  </f:TextBox>
                            </Items>
                        </f:Panel>
                                        </Items>
                                    </f:GroupPanel>
                                  <f:GroupPanel ID="GroupPanel2" runat="server" Title="教师团队基本情况">
                                    <Items>
                                           <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                   <f:NumberBox ID="NumberBox_zrjszs" runat="server" Label="专任教师总人数"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0" OnTextChanged="NumberBox_zrjszs_TextChanged" AutoPostBack="true"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_gjzc" runat="server" Label="其中高级职称人数"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0" OnTextChanged="NumberBox_gjzc_TextChanged" AutoPostBack="true"></f:NumberBox>
                                 <f:NumberBox ID="NumberBox_gjzcbl" runat="server" Label="占比(%)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0" Readonly="true" Enabled="false"></f:NumberBox>
                                 <f:NumberBox ID="NumberBox_ssx" runat="server" Label="双师型教师人数"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0" OnTextChanged="NumberBox_ssx_TextChanged" AutoPostBack="true"></f:NumberBox>
                                 <f:NumberBox ID="NumberBox_ssxbl" runat="server" Label="占比(%)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0" Readonly="true" Enabled="false"></f:NumberBox>
                                 
                            </Items>
                        </f:Panel>
                                         <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                   <f:NumberBox ID="NumberBox_jzjszrs" runat="server" Label="兼职教师总人数"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_jzjsgjzc" runat="server" Label="其中高级职称人数"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0"></f:NumberBox>
                                
                                 <f:NumberBox ID="NumberBox_cdksbl" runat="server" Label="承担课时占专业总课时比例(%)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="34%" Margin="0 5 2 0"></f:NumberBox>
                                 
                            </Items>
                        </f:Panel>
                                        </Items>
                                    </f:GroupPanel>
                                </Items>
                                </f:GroupPanel>
                         <f:Panel ID="Panel12" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                  <f:TextArea ID="TextArea_zydsfzyqk" runat="server" Height="200px" Label="专业点示范作用情况" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="<近三年参加行业及省级以上专业研究组织及活动情况、承办行业及省市与专业相关的活动情况以及专业所获荣誉（不超过600字）>" MaxLength="600"  Required="true" ShowRedStar="true"></f:TextArea>
                                 
                            </Items>
                        </f:Panel>
                         <f:GroupPanel ID="GroupPanel3" runat="server" Title="<strong>专业建设及人才培养相关情况</strong>">
                                    <Items>
                                          <f:Panel ID="Panel13" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                  <f:TextArea ID="TextArea_zydjj" runat="server" Height="200px" Label="一、专业点简介" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="<含专业背景、人才培养特色与创新、专业优势及影响力等情况（不超过600字）>" MaxLength="600"  Required="true" ShowRedStar="true"></f:TextArea>
                                 
                            </Items>
                        </f:Panel>
                                         <f:Panel ID="Panel14" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                  <f:TextArea ID="TextArea_zyjsqk" runat="server" Height="200px" Label="二、专业建设情况" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="<含人才培养模式改革与创新、课程建设、实践教学、师资队伍建设、教学条件建设等情况（不超过1000字）>" MaxLength="1000"  Required="true" ShowRedStar="true"></f:TextArea>
                                 
                            </Items>
                        </f:Panel>
                                         <f:Panel ID="Panel15" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                  <f:TextArea ID="TextArea_xqhzqk" runat="server" Height="200px" Label="三、校企合作情况" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="<含校企合作思路、形式与成效等（不超过600字）>" MaxLength="600"  Required="true" ShowRedStar="true"></f:TextArea>
                                 
                            </Items>
                        </f:Panel>
                                         <f:Panel ID="Panel16" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                  <f:TextArea ID="TextArea_rcpyqk" runat="server" Height="200px" Label="四、人才培养情况" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="<含毕业生就业情况与社会声誉、就业典型案例等（不超过600字）>" MaxLength="600"  Required="true" ShowRedStar="true"></f:TextArea>
                                 
                            </Items>
                        </f:Panel>
                                         <f:Panel ID="Panel18" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                  <f:TextArea ID="TextArea_xybjsgh" runat="server" Height="200px" Label="五、下一步专业建设规划" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="<未来三年专业建设规划，明确建设目标与实施方案（不超过1000字）>" MaxLength="1000"  Required="true" ShowRedStar="true"></f:TextArea>
                                 
                            </Items>
                        </f:Panel>
                                        </Items>
                                        </f:GroupPanel>
                         <f:GroupPanel ID="GroupPanel5" runat="server" Title="<strong>养老服务实训基地基本情况</strong>">
                                    <Items>
                                          <f:Form runat="server" Title="" ID="Form4" ShowBorder="false" ShowHeader="false">
                                   <Items>
                                         <f:Panel ID="Panel19" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                                 <f:TextBox ID="TextBox_sxjdmc" Label="实训基地名称" Required="true" ShowRedStar="true" ColumnWidth="20%" runat="server"   Margin="0 5 2 0">  </f:TextBox>
                                  <%--<f:DropDownList ID="DropDownList1" runat="server" Label="主要面向专业"  Required="true" ShowRedStar="true" ColumnWidth="20%"  AutoPostBack="false" Margin="0 5 2 0"></f:DropDownList>--%>
                                <f:TextBox ID="TextBox_zymxzy" Label="主要面向专业" Required="true" ShowRedStar="true" ColumnWidth="20%" runat="server"   Margin="0 5 2 0">  </f:TextBox>
                                 <f:TextBox ID="TextBox_qymc" Label="校企共建企业名称" Required="true" ShowRedStar="true" ColumnWidth="20%" runat="server"   Margin="0 5 2 0">  </f:TextBox>
                                 <f:TextBox ID="TextBox_hzxs" Label="校企共建合作形式" Required="true" ShowRedStar="true" ColumnWidth="20%" runat="server"   Margin="0 5 2 0">  </f:TextBox>
                                  <f:NumberBox ID="NumberBox_jzmj" runat="server" Label="建筑面积(平方米)"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0"></f:NumberBox>
                            </Items>
                        </f:Panel>
                                        <f:Panel ID="Panel20" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                               
                              
                                  <f:NumberBox ID="NumberBox_sbs" runat="server" Label="设备数（台套）"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0"></f:NumberBox>
                                  <f:NumberBox ID="NumberBox_sbzz" runat="server" Label="设备总值（万元）"  MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0"></f:NumberBox>
                                   <f:NumberBox ID="NumberBox_kssxxmsl" runat="server" Label="开设实训项目数量"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0"></f:NumberBox>
                                 <f:NumberBox ID="NumberBox_nsyqkxn" runat="server" Label="年使用情况(人次)校内"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0"></f:NumberBox>
                                 <f:NumberBox ID="NumberBox_nsyqksh" runat="server" Label="年使用情况(人次)社会"  MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="20%" Margin="0 5 2 0"></f:NumberBox>
                            </Items>
                        </f:Panel>
                                       </Items>
                                                <Toolbars>
                <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button2" Text="添加到列表" ValidateForms="Form4" ValidateMessageBox="true" runat="server" OnClick="Button2_Click">
                        </f:Button>
                       <%--  <f:Button ID="Button2" Text="添加到列表"  runat="server" OnClick="Button2_Click">
                        </f:Button>--%>
                        
                    </Items>
                </f:Toolbar>
            </Toolbars>
                                       </f:Form>
                                            <f:Panel ID="Panel21" Layout="Fit" CssClass="formitem"  runat="server"  Title="已添加的养老服务实训基地基本情况列表"  ShowBorder="false" ShowHeader="true"   Margin="0 5 10 0">
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
                      <f:BoundField Width="150px" DataField="xh"  HeaderText="序号"     ColumnID="Panel7_Grid1_ctl091" />
                        <f:BoundField Width="150px" DataField="SXJDMC"  HeaderText="实训基地名称"  DataToolTipField="SXJDMC"   ColumnID="Panel7_Grid1_ctl092" />
                      
                        <f:BoundField Width="120px" DataField="ZYMXZY" HeaderText="主要面向专业" DataToolTipField="ZYMXZY"  ColumnID="Panel7_Grid1_ctl102"  />
                          <f:GroupField HeaderText="校企共建情况" TextAlign="Center">
                    <Columns>
                        <f:BoundField Width="150px" DataField="QYMC" DataToolTipField="QYMC" HeaderText="企业名称"  ColumnID="Panel7_Grid1_ctl112" />
                        <f:BoundField Width="150px" DataField="HZXS" DataToolTipField="HZXS" HeaderText="合作形式"  ColumnID="Panel7_Grid1_ctl113" />
                        </Columns>
                        </f:GroupField>
                       <f:BoundField Width="200px" DataField="JZMJ" HeaderText="建筑面积<br/>(平方米)"  ColumnID="Panel7_Grid1_ctl114" DataFormatString="{0:N2}"/>
                          <f:BoundField Width="150px" DataField="SBS" HeaderText="设备数<br/>(台套）"  ColumnID="Panel7_Grid1_ctl115" />
                          <f:BoundField Width="150px" DataField="SBZZ" HeaderText="设备总值<br/>(万元)"  ColumnID="Panel7_Grid1_ctl116" DataFormatString="{0:N2}"/>
                         <f:BoundField Width="200px" DataField="KSSXXMSL" HeaderText="开设实训项目数量"  ColumnID="Panel7_Grid1_ctl117"/>
                          <f:GroupField HeaderText="年使用情况(人次)" TextAlign="Center">
                    <Columns>
                        <f:BoundField Width="150px" DataField="NSYQKXN"  HeaderText="校内"  ColumnID="Panel7_Grid1_ctl118" />
                        <f:BoundField Width="150px" DataField="NSYQKSH"  HeaderText="社会"  ColumnID="Panel7_Grid1_ctl119" />
                        </Columns>
                        </f:GroupField>
                    </Columns>
                </f:Grid>
                                       </Items>
                                   
                                      </f:Panel>

                                         <f:Panel ID="Panel22" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                              
                               
                                  <f:TextArea ID="TextArea_SXJDJSJYXQK" runat="server" Height="200px" Label="实训基地建设及运行情况" Text=""  ColumnWidth="80%" Margin="10 5 10 0"  EmptyText="<简述实训基地建设及运行情况（不超过800字），另提供实训基地校企合作共建协议复印件、实训基地场地、设备照片等相关支撑材料>" MaxLength="800"  Required="true" ShowRedStar="true"></f:TextArea>
                                 
                            </Items>
                        </f:Panel>
                                        </Items>
                                        </f:GroupPanel>
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
    </form>
     <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TextBox1_jsxm = '<%= TextBox1_jsxm.ClientID %>';
        var DatePicker_csny = '<%= DatePicker_csny.ClientID %>';
        var hd_csny = '<%= HiddenField_csny.ClientID %>';
        var DropDownList_xl = '<%= DropDownList_xl.ClientID %>';
        var hd_xl = '<%= HiddenField_xl.ClientID %>';
        var DropDownList_xw = '<%= DropDownList_xw.ClientID %>';
        var hd_xw = '<%= HiddenField_xw.ClientID %>';
      

        F.ready(function () {

            var cache = {};



            $('#' + TextBox1_jsxm + ' input').autocomplete({
                minLength: 1,
                source: function (request, response) {
                    var term1 = request.term;



                    $('#' + DatePicker_csny + ' input').val('');
                    $('#' + hd_csny + ' input').val('');


                    $('#' + DropDownList_xl + ' input').val('');
                    $('#' + hd_xl + ' input').val('');
                    $('#' + DropDownList_xw + ' input').val('');
                    $('#' + hd_xw + ' input').val('');


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
                    $('#' + hd_csny + ' input').val(ui.item.csny);
                  
                  
                    $('#' + DropDownList_xl + ' input').val(ui.item.xl);
                    $('#' + hd_xl + ' input').val(ui.item.xl);
                    $('#' + DropDownList_xw + ' input').val(ui.item.xw);
                    $('#' + hd_xw + ' input').val(ui.item.xw);
                  
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

        function CloseWebPage() {
            if (navigator.userAgent.indexOf("MSIE") > 0) {
                if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {
                    window.opener = null;
                    window.close();
                } else {
                    window.open('', '_top');
                    window.top.close();
                }
            }
            else if (navigator.userAgent.indexOf("Firefox") > 0) {
                window.location.href = 'about:blank ';
            } else {
                window.opener = null;
                window.open('', '_self', '');
                window.close();
            }

        }

    </script>

   
</body>
</html>
