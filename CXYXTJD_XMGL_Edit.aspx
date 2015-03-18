<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CXYXTJD_XMGL_Edit.aspx.cs" Inherits="XMGL.Web.admin.CXYXTJD_XMGL_Edit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/theme-start/theme.css" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/layout3.css" />
    <script src="../res/js/jquery.min.js" type="text/javascript"></script>
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
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="Button_step1,Button_step2,Button_step3,Button_step4,Button_step5,Button_step6,Button_step7,Button_step8,Button_step9" />

        <f:Panel ID="Panel1" runat="server" BodyPadding="5px"
            Title="添加项目" ShowBorder="true" ShowHeader="false"
            BoxConfigAlign="Stretch" Margin="0 10 5 0" AutoScroll="true">
            <Items>
                <f:ContentPanel ID="ContentPanel1" runat="server" BoxConfigAlign="Stretch" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                    <div id="wrapper">
                        <div class="container mt20">
                            <div id="processor">
                                <ol class="processorBox oh">
                                    <li class="current" id="li1">
                                        <%--   <li  id="li1">--%>
                                        <div class="step_inner fl">
                                            <%--   <div class="step_inner">--%>
                                            <%--<span class="icon_step">1</span>--%>
                                            <%-- <f:Button ID="Button9" runat="server" Text="1" CssClass="icon_step" OnClick="Button_step1_Click"></f:Button>--%>
                                            <asp:Button ID="Button_step1" runat="server" Text="1" CssClass="icon_step" OnClick="Button_step1_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>单位承诺及填表说明</h4>
                                        </div>
                                    </li>
                                    <li id="li2">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step2" runat="server" Text="2" CssClass="icon_step" OnClick="Button_step2_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <%--  <span class="icon_step">2</span>--%>
                                            <h4>实习实训情况</h4>
                                        </div>
                                    </li>
                                    <li id="li3">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step3" runat="server" Text="3" CssClass="icon_step" OnClick="Button_step3_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <%-- <span class="icon_step">3</span>--%>
                                            <h4>基地负责人信息</h4>
                                        </div>
                                    </li>
                                    <li id="li4">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step4" runat="server" Text="4" CssClass="icon_step" OnClick="Button_step4_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>基地依托专业情况</h4>
                                        </div>
                                    </li>
                                    <li id="li5">
                                        <div class="step_inner">

                                            <asp:Button ID="Button_step5" runat="server" Text="5" CssClass="icon_step" OnClick="Button_step5_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>基地组织构架设想</h4>
                                        </div>
                                    </li>
                                    <li id="li6">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step6" runat="server" Text="6" CssClass="icon_step" OnClick="Button_step6_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>基地建设方案</h4>
                                        </div>
                                    </li>
                                    <li id="li7">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step7" runat="server" Text="7" CssClass="icon_step" OnClick="Button_step7_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>项目验收指标</h4>
                                        </div>
                                    </li>
                                    <li id="li8">
                                        <div class="step_inner fr">
                                            <asp:Button ID="Button_step8" runat="server" Text="8" CssClass="icon_step" OnClick="Button_step8_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>经费预算</h4>
                                        </div>
                                    </li>
                                    <li id="li9">
                                        <div class="step_inner fr">
                                            <asp:Button ID="Button_step9" runat="server" Text="9" CssClass="icon_step" OnClick="Button_step9_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>附件上传</h4>
                                        </div>
                                    </li>
                                </ol>
                                <div class="step_line"></div>
                            </div>
                            <div class="content">
                                <%--<div id="s1"  runat="server" visible="true">--%>
                                <f:ContentPanel runat="server" ID="ContentPanel_step1" ShowBorder="false" ShowHeader="false">
                                    <div class="dwcn">
                                        <h2>单　位　承　诺</h2>
                                        <p class="cn-p">我单位承诺对本申报书各项填写内容的真实性及与网上填报内容的一致性负责。如获准立项，我单位承诺以本申报书为有约束力的协议，遵守上海市教育委员会的相关规定，按计划认真开展建设工作，取得预期建设成果。本表所有数据和资料均未涉密，上海市教育委员会有权使用本表所有数据和资料。</p>
                                        <br />
                                        <br />
                                        <h2>填　表　说　明</h2>
                                        <p class="sm-p">一、本申报书为2015年上海高等职业教育质量提升计划专项经费项目申报书；</p>
                                        <p class="sm-p">二、请按本申报书格式，通过上海高职教育网“项目管理”专栏如实填报后提交；</p>
                                        <p class="sm-p">三、同一单位不同申报项目须分别填报；</p>
                                        <p class="sm-p">四、本申报书封面上方项目编号框不用填写，由系统自动生成；</p>
                                        <p class="sm-p">五、纸质版由系统生成后，请用A4纸双面打印一式两份,加盖公章后报送上海市教育委员会高等教育处；</p>
                                        <p class="sm-p">六、上海市教育委员会高等教育处通讯地址：上海市大沽路100号3303室，邮政编码：200003。</p>
                                    </div>
                                    <f:SimpleForm ID="SimpleForm4" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server">
                                        <Items>
                                        </Items>
                                        <Toolbars>
                                            <f:Toolbar ID="Toolbar4" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                <Items>
                                                    <f:Button ID="Button4" Text="下一步" runat="server" OnClick="Button_step2_Click" Margin="10 10 10 0">
                                                    </f:Button>

                                                </Items>
                                            </f:Toolbar>
                                        </Toolbars>
                                    </f:SimpleForm>
                                </f:ContentPanel>

                                <f:SimpleForm ID="SimpleForm_step2" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>

                                        <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                            <Items>
                                                <f:TextBox ID="TextBox_jdmc" Label="基地名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" runat="server" ColumnWidth="100%">
                                                </f:TextBox>
                                            </Items>
                                        </f:Panel>

                                        <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="<strong>实习实训情况</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_xxmc" Label="学校名称" Margin="0 5 2 2" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Readonly="true" Enabled="false">
                                                        </f:TextBox>

                                                        <f:TextBox ID="txt_xxdm" Label="学校代码" Required="true" ShowRedStar="true" ColumnWidth="30%" runat="server" Readonly="true" Enabled="false" Margin="0 5 2 0">
                                                        </f:TextBox>
                                                    </Items>
                                                </f:Panel>

                                                <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="<strong>全校实习实训情况</strong>" runat="server">
                                                    <Items>
                                                        <f:Panel ID="Panel5" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:NumberBox ID="txt_SXSXQK_SXSXCSSZMJ" Label="实习实训场所占地面积（平方米）" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 2">
                                                                </f:NumberBox>
                                                                <f:NumberBox ID="txt_SXSXQK_SXSXCSJZMJ" Label="实习实训场所建筑面积（平方米）" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0">
                                                                </f:NumberBox>
                                                                <f:NumberBox ID="txt_SXSXQK_XYSXSBZZ" Label="现有实训设备总值（万元）" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server" Margin="0 3 2 0">
                                                                </f:NumberBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:NumberBox ID="txt_SXSXQK_XYSXYQSB" Label="现有实训仪器设备（台套）" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 5 2" RegexPattern="NUMBER">
                                                                </f:NumberBox>
                                                                <f:NumberBox ID="txt_SXSXQK_SBSJ" Label="设备生均（元）" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 5 0">
                                                                </f:NumberBox>
                                                                <f:NumberBox ID="txt_SXSXQK_SXSXKCMS" Label="实习实训课程门数" Required="true" ShowRedStar="true" ColumnWidth="34%" runat="server" Margin="0 3 5 0" RegexPattern="NUMBER">
                                                                </f:NumberBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:NumberBox ID="txt_SXSXQK_JSNNJPXRS" Label="近三年年均为社会培训人次数" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 5 2" RegexPattern="NUMBER"></f:NumberBox>

                                                    </Items>
                                                </f:GroupPanel>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button9_s2" Text="下一步" ValidateForms="SimpleForm_step2" ValidateMessageBox="true" runat="server" OnClick="Button_step3_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>

                                <f:SimpleForm ID="SimpleForm_step3" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="<strong>基地负责人信息</strong>" runat="server">
                                            <Items>

                                                <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_JDFZRXX_XM" Label="姓  名" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:TextBox ID="txt_JDFZRXX_BMJZF" Label="部门及职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:TextBox ID="txt_JDFZRXX_ZYJSZW" Label="专业技术职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:TextBox ID="txt_JDFZRXX_ZYZGZS" Label="职业资格证书" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_JDFZRXX_BGDH" Label="办公电话" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:TextBox ID="txt_JDFZRXX_CZ" Label="传  真" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:TextBox ID="txt_JDFZRXX_SJ" Label="手  机" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" Regex="^1[3|4|5|8][0-9]\d{8}$" RegexMessage="请填写正确的手机号码"></f:TextBox>
                                                        <f:TextBox ID="txt_JDFZRXX_DZYX" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" RegexPattern="EMAIL"></f:TextBox>
                                                    </Items>
                                                </f:Panel>
                                                <f:TextArea ID="txt_JDFZRXX_JSYFYFW" Label="本人开展应用技术研发与服务情况" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextArea>
                                                <f:TextArea ID="txt_JDFZRXX_BRZHYQYJZ" Label="本人在行业企业兼职情况" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextArea>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar8" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button9_s3" Text="下一步" ValidateForms="SimpleForm_step3" ValidateMessageBox="true" runat="server" OnClick="Button_step4_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <f:SimpleForm ID="SimpleForm_step4" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel11" Layout="Anchor" Title="<strong>基地依托专业情况</strong>" runat="server">
                                            <Items>
                                                <f:Form ID="form_ytzy" runat="server" LabelAlign="Top" ShowHeader="false" ShowBorder="false">
                                                    <Rows>
                                                        <f:FormRow>
                                                            <Items>
                                                                <f:DropDownList ID="ddlZYMC" runat="server" Label="专业名称" Required="true" ShowRedStar="true" ColumnWidth="25%" OnSelectedIndexChanged="ddlZYMC_SelectedIndexChanged" AutoPostBack="true" Margin="0 5 2 0"></f:DropDownList>
                                                                <f:TextBox ID="txt_ZYDM" Label="专业代码" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="true" Margin="0 5 2 0">
                                                                </f:TextBox>
                                                                <f:TextBox ID="txt_ZYKSNF" Label="开设年份" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="true" Margin="0 5 2 0">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:FormRow>
                                                        <f:FormRow>
                                                            <Items>
                                                                <f:NumberBox ID="txt_NZSJHRS2015" Label="2015年招生计划人数" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" RegexPattern="NUMBER"></f:NumberBox>
                                                                <f:NumberBox ID="txt_ZXSRS" Label="在校生人数" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" RegexPattern="NUMBER"></f:NumberBox>
                                                                <f:NumberBox ID="txt_JSNPJJYL" Label="近三年平均就业率（%）" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" MaxValue="100"></f:NumberBox>
                                                            </Items>
                                                        </f:FormRow>
                                                        <f:FormRow>
                                                            <Items>
                                                                <f:NumberBox ID="txt_JSNZXSHDZGZSBL" Label="近三年在校生获得中级及以上职业资格证书比例（%）" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" MaxValue="100"></f:NumberBox>
                                                                <f:CheckBox ID="cbx_SFW085GCZDZY" Label="是否为“085”工程重点专业" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:CheckBox>
                                                            </Items>
                                                        </f:FormRow>
                                                    </Rows>
                                                    <Toolbars>
                                                        <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Right" Position="Bottom" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Button ID="btnSaveYTZY" Text="确定" ValidateForms="form_ytzy" ValidateMessageBox="false" runat="server" OnClick="btnSaveYTZY_Click" Icon="PageSave">
                                                                </f:Button>
                                                            </Items>
                                                        </f:Toolbar>
                                                    </Toolbars>
                                                </f:Form>
                                                <f:Grid ID="grid_YTZY" runat="server" Title="已添加基地依托专业情况" Height="300px" Margin="0 5 5 0" EnableMultiSelect="false" EnableCheckBoxSelect="true" DataKeyNames="ID">
                                                    <Toolbars>
                                                        <f:Toolbar ID="Toolbar6" runat="server">
                                                            <Items>
                                                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                                                </f:ToolbarSeparator>
                                                                <f:Button ID="btnDelWTZY" Text="删除" runat="server" OnClick="btnDelWTZY_Click" ConfirmText="确定删除？" Icon="Delete">
                                                                </f:Button>
                                                            </Items>
                                                        </f:Toolbar>
                                                    </Toolbars>
                                                    <Columns>
                                                        <f:RowNumberField HeaderText="序号" Width="50px" />
                                                        <f:BoundField Width="100px" DataField="ZYMC" HeaderText="专业名称" />

                                                        <f:BoundField DataField="ZYKBSJ" HeaderText="开设年份" Width="100px" />
                                                        <f:BoundField HeaderText="2015年招生计划人数" DataField="NZSJHRS2015" ExpandUnusedSpace="true" />
                                                        <f:BoundField HeaderText="在校生人数" DataField="ZXSRS" ExpandUnusedSpace="true" />
                                                        <f:BoundField DataField="JSNPJJYL" HeaderText="近三年平均就业率" ExpandUnusedSpace="true" />
                                                        <f:BoundField DataField="JSNZXSHDZGZSBL" HeaderText="近三年在校生获得中级及以上<br/>职业资格证书比例" ExpandUnusedSpace="true" TextAlign="Center" />
                                                        <f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="SFW085GCZDZY" HeaderText="是否为“085”工程重点专业" ExpandUnusedSpace="true" />
                                                    </Columns>
                                                </f:Grid>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar9" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button9" Text="下一步" ValidateMessageBox="true" runat="server" OnClick="Button_step5_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>

                                <f:SimpleForm ID="SimpleForm_step5" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel6" Layout="Anchor" Title="<strong>基地组织构架设想</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel25" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txt_JDZZGJSX" runat="server" Height="500px" Label="基地组织构架设想" Margin="10 5 10 0" EmptyText="请通过文字或图表方式阐述本申报基地的组织构架及相关管理人员情况（不超过500字）" Required="true" ShowRedStar="true" MaxLength="800" ColumnWidth="98%"></f:TextArea>
                                                    </Items>
                                                </f:Panel>
                                                  <f:Panel ID="Panel57" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                          <f:SimpleForm ID="SimpleForm5" BodyPadding="5px" runat="server"   EnableCollapse="true"
            ShowBorder="True" Title="&nbsp;" ShowHeader="false"   ColumnWidth="50%">
            <Items>
               
                 <f:FileUpload runat="server" ID="FileUpload4" EmptyText="如果需要图表方式阐述本申报基地的组织构架及相关管理人员情况，请选择图片上传" Label="上传图片"  AcceptFileTypes="image/*" >
                </f:FileUpload>
                
                <f:Button ID="Button5" runat="server" OnClick="Button5_Click"  
                    Text="上传">
                </f:Button>
            </Items>
        </f:SimpleForm>
                                                      
                                                        
                                                    </Items>
                                                </f:Panel>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar10" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button10" Text="下一步" ValidateForms="SimpleForm_step5" ValidateMessageBox="true" runat="server" OnClick="Button_step6_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <f:SimpleForm ID="SimpleForm_step6" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel7" Layout="Anchor" Title="<strong>申报理由</strong>" runat="server">
                                            <Items>
                                                <f:TextArea ID="txt_JDJSFA_SBLY" runat="server" Height="200px" Label="申报理由" Margin="10 5 10 0" EmptyText="请说明开展项目建设的必要性、可行性，以及现有基础与优势。（不超过500字）" Required="true" ShowRedStar="true" MaxLength="800"></f:TextArea>
                                            </Items>
                                        </f:GroupPanel>
                                        <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="<strong>平台建设目标</strong>" runat="server">
                                            <Items>
                                                <f:GroupPanel ID="GroupPanel5" Layout="Anchor" Title="<strong>技术工艺和产品开发平台</strong>" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_JSGYHCPKF_PTMC" Label="平台名称" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:GroupPanel ID="GroupPanel12" Layout="Anchor" Title="<strong>平台负责人</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_XM" Label="姓名" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_BMJXZZF" Label="部门及行政职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_ZYJSZW" Label="专业技术职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_ZYZGZS" Label="职业资格证书" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_BGDH" Label="办公电话" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_CZ" Label="传真" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_SJ" Label="手机" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" Regex="^1[3|4|5|8][0-9]\d{8}$" RegexMessage="请填写正确的手机号码"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_DZYX" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" RegexPattern="EMAIL"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>

                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel13" Layout="Anchor" Title="<strong>主要参与企业及联系人（不超过三家）</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_QYMC1" Label="企业名称" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_LXRXMJZW1" Label="联系人姓名及职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_LXFS1" Label="联系方式" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_QYMC2" Label="企业名称"  ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_LXRXMJZW2" Label="联系人姓名及职务"  ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_LXFS2" Label="联系方式" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel12" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_QYMC3" Label="企业名称"  ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_LXRXMJZW3" Label="联系人姓名及职务"  ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_LXFS3" Label="联系方式"  ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>

                                                        <f:GroupPanel ID="GroupPanel14" Layout="Anchor" Title="<strong>研发领域</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel13" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:CheckBoxList ID="cbl_JSGYHCPKF_YFLY_XX" Required="true" ShowRedStar="true" ColumnNumber="4" runat="server" ColumnWidth="98%">
                                                                            <f:CheckItem Text="先进装备制造业" Value="先进装备制造业" />
                                                                            <f:CheckItem Text="现代服务业" Value="现代服务业" />
                                                                            <f:CheckItem Text="现代农业" Value="现代农业" />
                                                                            <f:CheckItem Text="生物医药" Value="生物医药" />
                                                                            <f:CheckItem Text="公共安全" Value="公共安全" />
                                                                            <f:CheckItem Text="医疗卫生" Value="医疗卫生" />
                                                                            <f:CheckItem Text="新能源新材料" Value="新能源新材料" />
                                                                            <f:CheckItem Text="建筑工程" Value="建筑工程" />
                                                                            <f:CheckItem Text="文化创意" Value="文化创意" />
                                                                            <f:CheckItem Text="社会管理" Value="社会管理" />
                                                                            <f:CheckItem Text="交通运输" Value="交通运输" />
                                                                            <f:CheckItem Text="工艺美术" Value="工艺美术" />
                                                                        </f:CheckBoxList>

                                                                    </Items>
                                                                </f:Panel>

                                                                <f:Panel ID="Panel15" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JSGYHCPKF_YFLY_QT" Label="其他" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel15" Layout="Anchor" Title="<strong>平台功能简介</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel14" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_JSGYHCPKF_PTGNJJ" Label="平台功能简介" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="200字以内" MaxLength="300"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel16" Layout="Anchor" Title="<strong>平台未来三年预期完成的技术工艺和产品开发经济指标</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel16" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_JSGYHCPKF_PTWLGYHJJZB" Label="平台未来三年预期完成的技术工艺和产品开发经济指标" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="200字以内" MaxLength="300"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                    </Items>
                                                </f:GroupPanel>

                                                <f:GroupPanel ID="GroupPanel17" Layout="Anchor" Title="<strong>实习实训平台</strong>" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_SXSXPT_PTMC" Label="平台名称" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:GroupPanel ID="GroupPanel18" Layout="Anchor" Title="<strong>平台负责人</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel17" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_SXSXPT_XM" Label="姓名" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_SXSXPT_BMJXZZW" Label="部门及行政职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_SXSXPT_ZYJSZW" Label="专业技术职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_SXSXPT_ZYZGZS" Label="职业资格证书" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel18" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_SXSXPT_BGDH" Label="办公电话" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_SXSXPT_CZ" Label="传真" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_SXSXPT_SJ" Label="手机" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_SXSXPT_DZYX" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>

                                                            </Items>
                                                        </f:GroupPanel>

                                                        <f:GroupPanel ID="GroupPanel21" Layout="Anchor" Title="<strong>平台功能简介</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel24" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_SXSXPT_PTGNJJ" Label="平台功能简介" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="200字以内" MaxLength="300"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel22" Layout="Anchor" Title="<strong>平台未来三年建设目标</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel26" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_SXSXPT_PTWLSNJSMB" Label="平台未来三年建设目标" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="请阐述该平台建设目标及是否符合行业发展趋势及最新技术标准。（200字以内）" MaxLength="300"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                    </Items>
                                                </f:GroupPanel>

                                                <f:GroupPanel ID="GroupPanel19" Layout="Anchor" Title="<strong>技能大师工作室</strong>" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_JNDSGZS_GZSMC" Label="工作室名称" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:GroupPanel ID="GroupPanel20" Layout="Anchor" Title="<strong>拟引进的技能大师信息</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel19" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JNDSGZS_XM" Label="姓名" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:RadioButtonList ID="rbtn_JNDSGZS_XB" Label="性别" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0">
                                                                            <f:RadioItem Text="男" Value="男" />
                                                                            <f:RadioItem Text="女" Value="女" />
                                                                        </f:RadioButtonList>
                                                                        <f:TextBox ID="txt_JNDSGZS_MZ" Label="民族" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0">
                                                                        </f:TextBox>
                                                                        <f:DatePicker ID="dp_JNDSGZS_CSNY" Label="出生年月" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:DatePicker>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel20" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:DatePicker ID="dp_JNDSGZS_CJGZSJ" Label="参加工作时间" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:DatePicker>
                                                                        <f:TextBox ID="txt_JNDSGZS_ZZMM" Label="政治面貌" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JNDSGZS_CSSY" Label="从事职业（工种）" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JNDSGZS_ZYJNDJ" Label="职业技能等级" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel23" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txt_JNDSGZS_SJ" Label="手机" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JNDSGZS_YX" Label="邮箱" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:TextBox ID="txt_JNDSGZS_GZDWJZW" Label="工作单位及职务" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>

                                                                    </Items>
                                                                </f:Panel>

                                                                <f:Panel ID="Panel27" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_JNDSGZS_GEJL" Label="个人简历" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel28" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_JNDSGZS_HSBJYSJLHGJZL" Label="获省部级以上奖励或国家专利等情况" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0" EmptyText="限填3项"></f:TextArea>
                                                                        <f:TextArea ID="txt_JNDSGZS_ZYCXFMCG" Label="主要创新发明等成果" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0" EmptyText="限填3项"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>

                                                        <f:GroupPanel ID="GroupPanel23" Layout="Anchor" Title="<strong>工作室简介</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel21" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_JNDSGZS_GZSJJ" Label="工作室简介" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="200字以内" MaxLength="300"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel24" Layout="Anchor" Title="<strong>工作室未来三年建设任务</strong>" runat="server">
                                                            <Items>
                                                                <f:Panel ID="Panel22" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextArea ID="txt_JNDSGZS_GZSWLSNJSRW" Label="工作室未来三年建设任务" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="请从以下五方面阐述大师工作室三年内的建设任务：（从教学团队、青年教师、学生奖项、校企合作、现代学徒等方面进行说明。）。（500字以内）" MaxLength="800"></f:TextArea>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                    </Items>
                                                </f:GroupPanel>

                                            </Items>
                                        </f:GroupPanel>
                                        <f:GroupPanel ID="GroupPanel25" Layout="Anchor" Title="<strong>具体举措</strong>" runat="server">
                                            <Items>
                                                <f:TextArea ID="txt_JTCS" Label="具体举措" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="请结合上述三个平台建设目标，阐述如何实现产教研协同发展、协同育人的具体举措。（不超过1000字）" MaxLength="1500"></f:TextArea>
                                            </Items>
                                        </f:GroupPanel>
                                        <f:GroupPanel ID="GroupPanel26" Layout="Anchor" Title="<strong>经费安排</strong>" runat="server">
                                            <Items>
                                                <f:TextArea ID="txt_JFAP" Label="经费安排" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="请阐述项目总体需要经费、来源和主要用途。（不超过500字）" MaxLength="1000"></f:TextArea>
                                            </Items>
                                        </f:GroupPanel>
                                        <f:GroupPanel ID="GroupPanel27" Layout="Anchor" Title="<strong>实施计划</strong>" runat="server">
                                            <Items>
                                                <f:TextArea ID="txt_SSJH" Label="实施计划" Required="true" ShowRedStar="true" ColumnWidth="98%" runat="server" Margin="0 5 2 0" EmptyText="请针对上述三个平台建设目标，按照2015、2016、2017三年度分别填写实施计划。（不超过500字）" MaxLength="800"></f:TextArea>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar11" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button11" Text="下一步" ValidateForms="SimpleForm_step6" ValidateMessageBox="true" runat="server" OnClick="Button_step7_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <f:SimpleForm ID="SimpleForm_step7" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel28" Layout="Anchor" Title="<strong>技术工艺和产品开发平台</strong>（填写说明：请分别说明各建设目标，并列出验收要点。）" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel29" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_JSHCP_JSMB" Label="建设目标" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:DatePicker ID="dp_JSHCP_YQWCSJ" Label="计划验收日期" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:DatePicker>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel30" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txt_JSHCP_YSYD" Label="验收要点" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" EmptyText="1. 2. 3. ……"></f:TextArea>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel32" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Toolbars>
                                                        <f:Toolbar ID="Toolbar7" runat="server" ToolbarAlign="Right" Position="Bottom" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Button ID="btnSaveJSHCP" Text="确定" ValidateMessageBox="false" runat="server" OnClick="btnSaveJSHCP_Click" Icon="PageSave" ValidateForms="GroupPanel28">
                                                                </f:Button>
                                                            </Items>
                                                        </f:Toolbar>
                                                    </Toolbars>
                                                </f:Panel>
                                                <f:Panel ID="Panel31" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">

                                                    <Items>
                                                        <f:Grid ID="grid_JSHCP" runat="server" Title="已添加技术工艺和产品开发平台验收指标" Height="300px" Margin="0 5 5 0" EnableMultiSelect="false" EnableCheckBoxSelect="true" DataKeyNames="ID" ColumnWidth="100%">
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar5" runat="server">
                                                                    <Items>
                                                                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                                                        </f:ToolbarSeparator>
                                                                        <f:Button ID="btnDelJSGYHCPKFZB" Text="删除" runat="server" OnClick="btnDelJSGYHCPKFZB_Click" ConfirmText="确定删除？" Icon="Delete">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                            <Columns>
                                                                <f:RowNumberField HeaderText="序号" Width="50px" />
                                                                <f:BoundField ExpandUnusedSpace="true" DataField="JSMB" HeaderText="建设目标" />

                                                                <f:BoundField DataField="YQWCSJ" HeaderText="计划验收日期" ExpandUnusedSpace="true" />
                                                            </Columns>
                                                        </f:Grid>
                                                    </Items>
                                                </f:Panel>
                                            </Items>
                                        </f:GroupPanel>

                                        <f:GroupPanel ID="GroupPanel29" Layout="Anchor" Title="<strong>实习实训平台</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel49" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_SXSXPT_JSMB" Label="建设目标" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:DatePicker ID="dp_SXSXPT_YQWCSJ" Label="计划验收日期" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:DatePicker>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel50" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txt_SXSXPT_YSYD" Label="验收要点" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" EmptyText="1. 2. 3. ……"></f:TextArea>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel51" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Toolbars>
                                                        <f:Toolbar ID="Toolbar14" runat="server" ToolbarAlign="Right" Position="Bottom" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Button ID="btnSaveSXSXPT" Text="确定" ValidateMessageBox="false" runat="server" OnClick="btnSaveSXSXPT_Click" Icon="PageSave" ValidateForms="GroupPanel29">
                                                                </f:Button>
                                                            </Items>
                                                        </f:Toolbar>
                                                    </Toolbars>
                                                </f:Panel>
                                                <f:Panel ID="Panel52" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">

                                                    <Items>
                                                        <f:Grid ID="grid_SXSXPT" runat="server" Title="已添加实习实训平台验收指标" Height="300px" Margin="0 5 5 0" EnableMultiSelect="false" EnableCheckBoxSelect="true" DataKeyNames="ID" ColumnWidth="100%">
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar15" runat="server">
                                                                    <Items>
                                                                        <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                                                        </f:ToolbarSeparator>
                                                                        <f:Button ID="btnDelSXSXPT" Text="删除" runat="server" OnClick="btnDelSXSXPT_Click" ConfirmText="确定删除？" Icon="Delete">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                            <Columns>
                                                                <f:RowNumberField HeaderText="序号" Width="50px" />
                                                                <f:BoundField ExpandUnusedSpace="true" DataField="JSMB" HeaderText="建设目标" />

                                                                <f:BoundField DataField="YQWCSJ" HeaderText="计划验收日期" ExpandUnusedSpace="true" />
                                                            </Columns>
                                                        </f:Grid>
                                                    </Items>
                                                </f:Panel>
                                            </Items>
                                        </f:GroupPanel>

                                        <f:GroupPanel ID="GroupPanel30" Layout="Anchor" Title="<strong>技能大师工作室</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel53" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txt_JNDS_JSMB" Label="建设目标" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:DatePicker ID="dp_JNDS_YQWCSJ" Label="计划验收日期" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:DatePicker>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel54" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txt_JNDS_YSYD" Label="验收要点" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" EmptyText="1. 2. 3. ……"></f:TextArea>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel55" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Toolbars>
                                                        <f:Toolbar ID="Toolbar16" runat="server" ToolbarAlign="Right" Position="Bottom" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Button ID="btnSaveJNDS" Text="确定" ValidateMessageBox="false" runat="server" OnClick="btnSaveJNDS_Click" Icon="PageSave" ValidateForms="GroupPanel30">
                                                                </f:Button>
                                                            </Items>
                                                        </f:Toolbar>
                                                    </Toolbars>
                                                </f:Panel>
                                                <f:Panel ID="Panel56" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">

                                                    <Items>
                                                        <f:Grid ID="grid_JNDS" runat="server" Title="已添加技能大师工作室验收指标" Height="300px" Margin="0 5 5 0" EnableMultiSelect="false" EnableCheckBoxSelect="true" DataKeyNames="ID" ColumnWidth="100%">
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar17" runat="server">
                                                                    <Items>
                                                                        <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                                                        </f:ToolbarSeparator>
                                                                        <f:Button ID="btnDelJNDS" Text="删除" runat="server" OnClick="btnDelJNDS_Click" ConfirmText="确定删除？" Icon="Delete">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                            <Columns>
                                                                <f:RowNumberField HeaderText="序号" Width="50px" />
                                                                <f:BoundField ExpandUnusedSpace="true" DataField="JSMB" HeaderText="建设目标" />

                                                                <f:BoundField DataField="YQWCSJ" HeaderText="计划验收日期" ExpandUnusedSpace="true" />
                                                            </Columns>
                                                        </f:Grid>
                                                    </Items>
                                                </f:Panel>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar3" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button2" Text="下一步" ValidateMessageBox="true" runat="server" OnClick="Button_step8_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <f:SimpleForm ID="SimpleForm_step8" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel8" Layout="Anchor" Title="<strong>经费预算</strong>" runat="server">
                                            <Items>
                                                <f:GroupPanel ID="GroupPanel9" Layout="Anchor" Title="<strong>申请专项经费</strong>" runat="server">
                                                    <Items>
                                                        <f:Panel ID="Panel33" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:NumberBox ID="NumberBox_sqzxjfhj" runat="server" Label="申请专项经费合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false" Text="0"></f:NumberBox>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期" ID="DatePicker_sqzxjfzxksrq" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="DatePicker_sqzxjfzxksrq" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期" ID="DatePicker_sqzxjfzxjsrq" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>

                                                            </Items>

                                                        </f:Panel>
                                                        <f:Panel ID="Panel34" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server" Title="预算明细(2015年)" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Panel ID="Panel37" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfkcjcjf_2015" runat="server" Label="课程教材经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfszpxjf_2015" runat="server" Label="师资建设经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfszpxjf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfyqsbjf_2015" runat="server" Label="仪器设备经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel35" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfwpryfy_2015" runat="server" Label="外聘人员费用(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfywf_2015" runat="server" Label="业务费（包括会议、差旅、印刷、交通等）(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfywf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfgshj_2015" runat="server" Label="经费概算合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                                                    </Items>
                                                                </f:Panel>

                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel36" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server" Title="预算明细(2016年)" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Panel ID="Panel38" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfkcjcjf_2016" runat="server" Label="课程教材经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfszpxjf_2016" runat="server" Label="师资建设经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfszpxjf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfyqsbjf_2016" runat="server" Label="仪器设备经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel39" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfwpryfy_2016" runat="server" Label="外聘人员费用(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfywf_2016" runat="server" Label="业务费（包括会议、差旅、印刷、交通等）(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfywf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfgshj_2016" runat="server" Label="经费概算合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                                                    </Items>
                                                                </f:Panel>

                                                            </Items>
                                                        </f:Panel>

                                                        <f:Panel ID="Panel40" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server" Title="预算明细(2017年)" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Panel ID="Panel58" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfkcjcjf_2017" runat="server" Label="课程教材经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfszpxjf_2017" runat="server" Label="师资建设经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfszpxjf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfyqsbjf_2017" runat="server" Label="仪器设备经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                    </Items>
                                                                </f:Panel>
                                                                <f:Panel ID="Panel59" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfwpryfy_2017" runat="server" Label="外聘人员费用(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_sqzxjfywf_2017" runat="server" Label="业务费（包括会议、差旅、印刷、交通等）(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_sqzxjfywf_TextChanged" AutoPostBack="true"></f:NumberBox>

                                                                        <f:NumberBox ID="NumberBox_sqzxjfgshj_2017" runat="server" Label="经费概算合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>
                                                                    </Items>
                                                                </f:Panel>

                                                            </Items>
                                                        </f:Panel>
                                                    </Items>
                                                </f:GroupPanel>
                                                <f:GroupPanel ID="GroupPanel10" Layout="Anchor" Title="<strong>学校配套经费</strong>" runat="server">
                                                    <Items>
                                                        <f:Panel ID="Panel41" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:NumberBox ID="NumberBox_xxptjfhj" runat="server" Label="学校配套经费合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false" Text="0"></f:NumberBox>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期" ID="DatePicker_xxptjfzxksrq" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="DatePicker_xxptjfzxksrq" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期" ID="DatePicker_xxptjfzxjsrq" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>

                                                            </Items>

                                                        </f:Panel>
                                                        <f:Panel ID="Panel42" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server" Title="预算明细(2015年)" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Panel ID="Panel43" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_xxptkcjcjf_2015" runat="server" Label="课程教材经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptszpxf_2015" runat="server" Label="师资建设经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptszpxf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptyqsbjf_2015" runat="server" Label="仪器设备经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                    </Items>

                                                                </f:Panel>

                                                                <f:Panel ID="Panel44" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_xxptwpryfy_2015" runat="server" Label="外聘人员费用(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptywf_2015" runat="server" Label="业务费（包括会议、差旅、印刷、交通等）(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptywf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptgshj_2015" runat="server" Label="经费概算合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>

                                                                    </Items>

                                                                </f:Panel>


                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel45" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server" Title="预算明细(2016年)" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Panel ID="Panel46" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_xxptkcjcjf_2016" runat="server" Label="课程教材经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptszpxf_2016" runat="server" Label="师资建设经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptszpxf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptyqsbjf_2016" runat="server" Label="仪器设备经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                    </Items>

                                                                </f:Panel>

                                                                <f:Panel ID="Panel47" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_xxptwpryfy_2016" runat="server" Label="外聘人员费用(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptywf_2016" runat="server" Label="业务费（包括会议、差旅、印刷、交通等）(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptywf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptgshj_2016" runat="server" Label="经费概算合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>

                                                                    </Items>

                                                                </f:Panel>
                                                            </Items>
                                                        </f:Panel>

                                                        <f:Panel ID="Panel48" Layout="Container" CssClass="formitem" ShowHeader="true" ShowBorder="true" runat="server" Title="预算明细(2017年)" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Panel ID="Panel60" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_xxptkcjcjf_2017" runat="server" Label="课程教材经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptkcjcjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptszpxf_2017" runat="server" Label="师资建设经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptszpxf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptyqsbjf_2017" runat="server" Label="仪器设备经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptyqsbjf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                    </Items>

                                                                </f:Panel>

                                                                <f:Panel ID="Panel61" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:NumberBox ID="NumberBox_xxptwpryfy_2017" runat="server" Label="外聘人员费用(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptwpryfy_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptywf_2017" runat="server" Label="业务费（包括会议、差旅、印刷、交通等）(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" OnTextChanged="NumberBox_xxptywf_TextChanged" AutoPostBack="true"></f:NumberBox>
                                                                        <f:NumberBox ID="NumberBox_xxptgshj_2017" runat="server" Label="经费概算合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="5 0 5 2" Readonly="true" Enabled="false" EmptyText="系统自动汇总"></f:NumberBox>

                                                                    </Items>

                                                                </f:Panel>

                                                            </Items>
                                                        </f:Panel>
                                                    </Items>
                                                </f:GroupPanel>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar12" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button12" Text="下一步" ValidateForms="SimpleForm_step7" ValidateMessageBox="true" runat="server" OnClick="Button_step9_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <f:Window ID="SimpleForm_step9" runat="server" Title="上传附件" IsModal="false" EnableClose="false" EnableResize="true" EnableDrag="false" Hidden="true" Layout="Fit" Width="500px">
                                    <Items>
                                        <f:SimpleForm ID="SimpleForm_step22" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" AutoScroll="true">
                                            <Items>
                                                <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" EnableCollapse="true"
                                                    ShowBorder="True" Title="&nbsp;" ShowHeader="false">
                                                    <Items>

                                                        <f:FileUpload runat="server" ID="FileUpload1" EmptyText="请选择上传附件一" Label="项目可行性分析报告">
                                                        </f:FileUpload>
                                                         <f:HyperLink ID="HyperLink1" Text="下载项目可行性分析报告模板" Target="_blank" NavigateUrl="WordMaster/模板下载/产教研协同基地/附件一：项目可行性分析报告.docx" runat="server">
                                                        </f:HyperLink>
                                                        <f:Button ID="btnSubmit" runat="server" OnClick="btnSubmit1_Click" ValidateForms="SimpleForm1"
                                                            Text="上传">
                                                        </f:Button>
                                                    </Items>
                                                </f:SimpleForm>

                                                <f:SimpleForm ID="SimpleForm2" BodyPadding="5px" runat="server" EnableCollapse="true"
                                                    ShowBorder="True" Title="&nbsp;" ShowHeader="false">
                                                    <Items>

                                                        <f:FileUpload runat="server" ID="FileUpload2" EmptyText="请选择上传附件二" Label="校企合作优秀案例">
                                                        </f:FileUpload>
                                                       <f:HyperLink ID="HyperLink2" Text="下载校企合作优秀案例模板" Target="_blank" NavigateUrl="WordMaster/模板下载/产教研协同基地/附件二：校企合作优秀案例.docx" runat="server">
                                                        </f:HyperLink>
                                                        <f:Button ID="Button8" runat="server" OnClick="btnSubmit2_Click" ValidateForms="SimpleForm2"
                                                            Text="上传">
                                                        </f:Button>
                                                    </Items>
                                                </f:SimpleForm>

                                                <f:SimpleForm ID="SimpleForm3" BodyPadding="5px" runat="server" EnableCollapse="true"
                                                    ShowBorder="True" Title="&nbsp;" ShowHeader="false">
                                                    <Items>

                                                        <f:FileUpload runat="server" ID="FileUpload3" EmptyText="请选择上传附件三" Label="项目预算明细表">
                                                        </f:FileUpload>
                                                       <f:HyperLink ID="HyperLink3" Text="下载项目预算明细表模板" Target="_blank" NavigateUrl="WordMaster/模板下载/产教研协同基地/附件三：项目预算明细表.docx" runat="server">
                                                        </f:HyperLink>
                                                        <f:Button ID="Button1" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">
                                                        </f:Button>
                                                    </Items>
                                                </f:SimpleForm>

                                            </Items>
                                            <Toolbars>
                                                <f:Toolbar ID="Toolbar13" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                    <Items>
                                                        <f:Button ID="Button13" Text="保存" ValidateForms="SimpleForm_step2,SimpleForm_step3,SimpleForm_step4,SimpleForm_step5,SimpleForm_step6,SimpleForm_step7,SimpleForm_step22" ValidateMessageBox="true" runat="server" OnClick="Button13_Click" Margin="10 5 10 0">
                                                        </f:Button>

                                                    </Items>
                                                </f:Toolbar>
                                            </Toolbars>

                                        </f:SimpleForm>
                                    </Items>
                                </f:Window>

                            </div>
                        </div>
                    </div>

                </f:ContentPanel>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="600px" Height="450px">
        </f:Window>
    </form>

    <script type="text/javascript">
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

