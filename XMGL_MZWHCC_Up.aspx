<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_MZWHCC_Up.aspx.cs" Inherits="XMGL.Web.admin.XMGL_MZWHCC_Up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="DropDownList_zjz,DropDownList_ss,DropDownList_xl1,DropDownList_xw1,DropDownList_zcdj1" />
         <f:Panel ID="Panel1" runat="server" BodyPadding="5px"
            Title="添加项目" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" Height="1000px"  BoxConfigAlign="Stretch">
            <Items>
                 <f:SimpleForm  ID="Form2"  BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server">
                    <Items>
                         <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                            <Items>
                                <f:TextBox ID="TextBox_xmmc" Label="申报项目名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Enabled="False">
                                </f:TextBox>
                               <%-- <f:DropDownList ID="DropDownList_zymc" runat="server" Label="专业名称" Margin="0 5 0 0"  ColumnWidth="33%"></f:DropDownList>
                                   <f:TextBox ID="TextBox_zydm" Label="专业代码" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server" Readonly="false">
                                </f:TextBox>--%>
                            </Items>
                        </f:Panel>
                      <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="&lt;strong&gt;申报表&lt;/strong&gt;"  runat="server">
                            <Items>
                                  <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                           <f:TextBox ID="TextBox_xxmc1" runat="server" ColumnWidth="50%" Label="学校名称" Margin="0 5 2 2" Required="True" ShowRedStar="True">
                                           </f:TextBox>
                                           <f:DropDownList ID="DROP_zymc1" runat="server" AutoPostBack="True" ColumnWidth="50%" Label="专业名称"  Margin="0 5 2 2"  Required="True" ShowRedStar="True" OnSelectedIndexChanged="DROP_zymc1_SelectedIndexChanged">
                                           </f:DropDownList>
                                           <f:TextBox ID="TextBox_zydm1" runat="server" ColumnWidth="50%" Label="专业代码 " Margin="0 5 2 2" Required="True" ShowRedStar="True">
                                           </f:TextBox>
                                           <f:TextBox ID="TextBox_zyfx1" runat="server" ColumnWidth="50%" Label="专业（技能）方向" Margin="0 5 2 2" Required="True" ShowRedStar="True">
                                           </f:TextBox>
                                           <f:TextBox ID="TextBox_lxr" Label="联系人" Margin="0 5 2 2" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server">
                                           </f:TextBox>
                                           <f:TextBox ID="TextBox_lxdh1" runat="server" ColumnWidth="50%" Label="联系电话（含手机）" Margin="0 5 2 2" Required="True" ShowRedStar="True">
                                           </f:TextBox>
                                           </Items>
                                      </f:Panel>
                                
                            </Items>
                        </f:GroupPanel>
                         <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="&lt;strong&gt;专业基本情况&lt;/strong&gt;" runat="server">
                            <Items>
                                      <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                               
                                   <f:TextBox ID="TextBox_ZYMCFX1" Label="专业名称（方向）" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0">
                                </f:TextBox>
                                  <f:TextBox ID="TextBox_ZYDM2" Label="专业代码" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"   Margin="0 5 2 0">
                                       </f:TextBox>
                                             <f:TextBox ID="TextBox_XYNX1" Label="修业年限" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server"  Margin="0 5 2 0">
                                       </f:TextBox>
                                           <f:TextBox ID="TextBox_ZYSZSJ1" runat="server" ColumnWidth="50%" Label="专业设置时间" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                           </f:TextBox>
                                           <f:TextBox ID="TextBox_SJBYSSJ1" runat="server" ColumnWidth="50%" Label="首届毕业生时间" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                           </f:TextBox>
                                           <f:NumberBox ID="NUM_SNBYSZS1" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="近三年累计毕业生总数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                           </f:NumberBox>
                                           <f:NumberBox ID="NUM_ZYZSRS1" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="专业招生人数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                           </f:NumberBox>
                                           <f:NumberBox ID="NUM_ZYZXSS1" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="专业在校生数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                           </f:NumberBox>
                                           <f:DropDownList ID="DROP_WHYCXM1" runat="server" AutoPostBack="True" ColumnWidth="50%" Label="该专业所对应非物质文化遗产项目" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                           </f:DropDownList>
                                           <f:TextBox ID="TextBox_WHYCXMMC1" runat="server" ColumnWidth="50%" Label="所对应非物质文化遗产项目名称" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                           </f:TextBox>
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
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel5" Layout="Anchor" Title="专业教学团队基本情况" runat="server">
                            <Items>
                                      <f:GroupPanel ID="GroupPanel12" runat="server" Title="专业带头人基本情况">
                                          <Items>
                                              <f:Panel ID="Panel25" runat="server" CssClass="formitem" Layout="Column" ShowBorder="False" ShowHeader="False">
                                                  <Items>
                                                      <f:TextBox ID="ZYDT_XM1" runat="server" ColumnWidth="50%" Label="姓  名" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:DropDownList ID="ZYDT_XB1" runat="server" AutoPostBack="True" ColumnWidth="50%" Label="性别" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:DropDownList>
                                                      <f:TextBox ID="ZYDT_CSNY1" runat="server" ColumnWidth="50%" Label="出生年月" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:TextBox ID="ZYFZR_ZGXL1" runat="server" ColumnWidth="50%" Label="最高学历" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:TextBox ID="ZYFZR_XW1" runat="server" ColumnWidth="50%" Label="学位" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:TextBox ID="ZYDTR_ZYJSZW2" runat="server" ColumnWidth="50%" Label="专业技术职务" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:TextBox ID="ZYDTR_ZW1" runat="server" ColumnWidth="50%" Label="职务（包括社会兼职）" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:TextBox ID="ZYDTR_LXDH1" runat="server" ColumnWidth="50%" Label="联系电话(单位/手机)" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:TextBox ID="ZYDTR_YX1" runat="server" ColumnWidth="50%" Label="邮箱" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                  </Items>
                                              </f:Panel>
                                          </Items>
                                      </f:GroupPanel>
                                      <f:GroupPanel ID="GroupPanel13" runat="server" Title="教师团队基本情况">
                                          <Items>
                                              <f:Panel ID="Panel27" runat="server" CssClass="formitem" Layout="Column" ShowBorder="False" ShowHeader="False">
                                                  <Items>
                                                      <f:NumberBox ID="JS_ZRJSZS" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="专任教师总人数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                                      </f:NumberBox>
                                                      <f:NumberBox ID="JS_GJZCRS1" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="其中高级职称人数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                                      </f:NumberBox>
                                                      <f:TextBox ID="JS_GJZCBL1" runat="server" ColumnWidth="50%" Label="其中高级职称比例" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:NumberBox ID="JS_SHXRS1" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="双师型教师人数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                                      </f:NumberBox>
                                                      <f:TextBox ID="ZYFZR_ZYZGZS1" runat="server" ColumnWidth="50%" Label="双师型教师比例" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:NumberBox ID="JS_JZJSZRS1" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="兼职教师总人数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                                      </f:NumberBox>
                                                      <f:NumberBox ID="JS_GJZCRS2" runat="server" ColumnWidth="50%" DecimalPrecision="0" Label="其中高级职称人数" Margin="0 5 2 0" MinValue="0" NoNegative="True" Required="True" ShowRedStar="True">
                                                      </f:NumberBox>
                                                      <f:TextBox ID="ZYFZR_ZKSBL1" runat="server" ColumnWidth="50%" Label="承担课时占专业总课时比例" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:DropDownList ID="ZYDT_YWCCR1" runat="server" AutoPostBack="True" ColumnWidth="50%" Label="有无非物质文化遗产传承人（如有请填写以下表格）" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:DropDownList>
                                                  </Items>
                                              </f:Panel>
                                          </Items>
                                      </f:GroupPanel>
                                      <f:GroupPanel ID="GroupPanel14" runat="server" Title="非物质文化遗产传承人情况">
                                          <Items>
                                              <f:Panel ID="Panel28" runat="server" CssClass="formitem" Layout="Column" ShowBorder="False" ShowHeader="False">
                                                  <Items>
                                                      <f:TextBox ID="CCR_XM1" runat="server" ColumnWidth="50%" Label="姓名" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:DropDownList ID="CCR_XB1" runat="server" AutoPostBack="True" ColumnWidth="50%" Label="性别" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:DropDownList>
                                                      <f:TextBox ID="JS_GJZCBL2" runat="server" ColumnWidth="50%" Label="出生年月" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:TextBox ID="JS_FWZYCMC1" runat="server" ColumnWidth="50%" Label="非物质文化遗产传承项目名称" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                      <f:DropDownList ID="CCR_ZSJB1" runat="server" AutoPostBack="True" ColumnWidth="50%" Label="证书级别" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:DropDownList>
                                                      <f:TextBox ID="ZYFZR_ZSHDRQ1" runat="server" ColumnWidth="50%" Label="证书获得日期" Margin="0 5 2 0" Required="True" ShowRedStar="True">
                                                      </f:TextBox>
                                                  </Items>
                                              </f:Panel>
                                          </Items>
                                      </f:GroupPanel>
                                

                                  </Items>
                                      </f:GroupPanel>
                           <f:GroupPanel ID="GroupPanel11" Layout="Anchor" Title="&lt;strong&gt;专业点示范作用情况&lt;/strong&gt;" runat="server">
                            <Items>
                                      <f:TextArea ID="TextArea_ZYDSFZYQK1" runat="server" ColumnWidth="80%" EmptyText="&lt;近三年参加行业及省级以上专业研究组织及活动情况、承办行业及省市与专业相关的活动情况以及专业所获荣誉（不超过600字）&gt;" Height="200px" Margin="10 5 10 0" Required="True" ShowRedStar="True">
                                      </f:TextArea>
                                

                                 </Items>
                        </f:GroupPanel>
                         <f:GroupPanel ID="GroupPanel15" runat="server" Title="&lt;strong&gt;专业建设及人才培养相关情况&lt;/strong&gt;">
                             <Items>
                                 <f:TextArea ID="TextArea_ZYJJ1" runat="server" ColumnWidth="80%" EmptyText="&lt;含专业背景、人才培养特色与创新、专业优势及影响力等情况（不超过600字）&gt;" Height="200px" Label="一、专业点简介" Margin="10 5 10 0" Required="True" ShowRedStar="True">
                                 </f:TextArea>
                                 <f:TextArea ID="TextArea_ZYJSQK1" runat="server" ColumnWidth="80%" EmptyText="&lt;含人才培养模式与创新、课程建设、实践教学、校企合作、师资队伍建设、教学条件建设等情况（不超过1500字）&gt;" Height="200px" Label="二、专业建设情况" Margin="10 5 10 0" Required="True" ShowRedStar="True">
                                 </f:TextArea>
                                 <f:TextArea ID="TextArea_RCPYQK1" runat="server" ColumnWidth="80%" EmptyText="&lt;含毕业生就业情况与社会声誉、就业典型案例等（不超过600字）&gt;" Height="200px" Label="三、人才培养情况" Margin="10 5 10 0" Required="True" ShowRedStar="True">
                                 </f:TextArea>
                                 <f:TextArea ID="TextArea_ZYJSGH1" runat="server" ColumnWidth="80%" EmptyText="&lt;未来三年专业建设规划，明确建设目标与实施方案（不超过1000字）&gt;" Height="200px" Label="四、下一步专业建设规划" Margin="10 5 10 0" Required="True" ShowRedStar="True">
                                 </f:TextArea>
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
          <br />
    </form>
</body>
</html>
