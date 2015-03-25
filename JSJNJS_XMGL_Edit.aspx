<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSJNJS_XMGL_Edit.aspx.cs" Inherits="XMGL.Web.admin.JSJNJS_XMGL_Edit" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/theme-start/theme.css" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/layout4.css" />
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
                                        <div class="step_inner fl">
                                            <asp:Button ID="Button_step1" runat="server" Text="1" CssClass="icon_step" OnClick="Button_step1_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>单位承诺及填表说明</h4>
                                        </div>
                                    </li>
                                    <li id="li2">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step2" runat="server" Text="2" CssClass="icon_step" OnClick="Button_step2_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>项目团队人员信息</h4>
                                        </div>
                                    </li>
                                    <li id="li3">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step3" runat="server" Text="3" CssClass="icon_step" OnClick="Button_step3_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>申报项目建设方案</h4>
                                        </div>
                                    </li>
                                    <li id="li4">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step7" runat="server" Text="4" CssClass="icon_step" OnClick="Button_step7_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>项目验收指标</h4>
                                        </div>
                                    </li>
                                    <li id="li5">
                                        <div class="step_inner fr">
                                            <asp:Button ID="Button_step8" runat="server" Text="5" CssClass="icon_step" OnClick="Button_step8_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>经费预算</h4>
                                        </div>
                                    </li>
                                    <li id="li6">
                                        <div class="step_inner fr">
                                            <asp:Button ID="Button_step9" runat="server" Text="6" CssClass="icon_step" OnClick="Button_step9_Click" BorderStyle="None" UseSubmitBehavior="false" />
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
                                                    <f:Button ID="Button4" Text="下一步" runat="server" OnClick="Button_step2_Click" Margin="10 25 10 0"></f:Button>

                                                </Items>
                                            </f:Toolbar>
                                        </Toolbars>
                                    </f:SimpleForm>
                                </f:ContentPanel>

                                <f:SimpleForm ID="SimpleForm_step2" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>

                                        <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                            <Items>
                                                <f:TextBox ID="txtXMMC" Label="项目名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" runat="server" ColumnWidth="100%">
                                                </f:TextBox>
                                            </Items>
                                        </f:Panel>

                                        <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="<strong>项目团队人员信息</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txtDWMC" Label="单位名称" Margin="0 5 2 2" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Readonly="true" Enabled="false">
                                                        </f:TextBox>

                                                        <f:TextBox ID="txtDWDM" Label="单位代码" Required="true" ShowRedStar="true" ColumnWidth="30%" runat="server" Readonly="true" Enabled="false" Margin="0 5 2 0" Hidden="true">
                                                        </f:TextBox>
                                                    </Items>
                                                </f:Panel>

                                                <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="<strong>项目负责人信息</strong>" runat="server">
                                                    <Items>
                                                        <f:Panel ID="Panel5" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:TextBox ID="txtXMFZRXX_XM" Label="姓名" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 2">
                                                                </f:TextBox>
                                                                <f:TextBox ID="txtXMFZRXX_BM" Label="部门" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0">
                                                                </f:TextBox>
                                                                <f:TextBox ID="txtXMFZRXX_ZYJSZW" Label="专业技术职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 3 2 0">
                                                                </f:TextBox>
                                                                <f:TextBox ID="txtXMFZRXX_XZZW" Label="行政职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 3 2 0">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:TextBox ID="txtXMFZRXX_BGSDH" Label="办公室电话" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 2">
                                                                </f:TextBox>
                                                                <f:TextBox ID="txtXMFZRXX_CZ" Label="传真" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0">
                                                                </f:TextBox>
                                                                <f:TextBox ID="txtXMFZRXX_SJ" Label="手机" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 3 2 0" Regex="^1[3|4|5|8][0-9]\d{8}$" RegexMessage="请填写正确的手机号码">
                                                                </f:TextBox>
                                                                <f:TextBox ID="txtXMFZRXX_DZYX" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 3 2 0" RegexPattern="EMAIL"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                    </Items>
                                                </f:GroupPanel>

                                                <f:GroupPanel ID="GroupPanel31" Layout="Anchor" Title="<strong>项目成员信息</strong>" runat="server">
                                                    <Items>
                                                        <f:Form ID="FormXMCYXX" runat="server" LabelAlign="Top" ShowHeader="false" ShowBorder="false">
                                                            <Rows>
                                                                <f:FormRow>
                                                                    <Items>
                                                                        <f:TextBox ID="txtXM" Label="姓名" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0">
                                                                        </f:TextBox>
                                                                        <f:TextBox ID="txtBMJZW" Label="部门及职务" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0">
                                                                        </f:TextBox>
                                                                        <f:TextBox ID="txtSJ" Label="手机" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" Regex="^1[3|4|5|8][0-9]\d{8}$" RegexMessage="请填写正确的手机号码">
                                                                        </f:TextBox>
                                                                        <f:TextBox ID="txtDZYX" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Margin="0 5 2 0" RegexPattern="EMAIL">
                                                                        </f:TextBox>
                                                                    </Items>
                                                                </f:FormRow>
                                                                <f:FormRow>
                                                                    <Items>
                                                                        <f:TextArea ID="txtRWFG" Label="任务分工" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" RowHeight="50">
                                                                        </f:TextArea>
                                                                    </Items>
                                                                </f:FormRow>
                                                            </Rows>
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar18" runat="server" ToolbarAlign="Right" Position="Bottom" Margin="0 5 5 0">
                                                                    <Items>
                                                                        <f:Button ID="btnXMCYXXSave" Text="确定" ValidateForms="FormXMCYXX" ValidateMessageBox="false" runat="server" Icon="PageSave" OnClick="btnXMCYXXSave_Click">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                        </f:Form>
                                                        <f:Grid ID="GridXMCY" runat="server" Title="已添加项目成员信息" Height="300px" Margin="0 5 5 0" EnableMultiSelect="false" EnableCheckBoxSelect="true" DataKeyNames="ID" AllowPaging="true" PageSize="20">
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar19" runat="server">
                                                                    <Items>
                                                                        <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                                                        </f:ToolbarSeparator>
                                                                        <f:Button ID="btnXMCYXXDel" Text="删除" runat="server" ConfirmText="确定删除？" Icon="Delete" OnClick="btnXMCYXXDel_Click">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                            <Columns>
                                                                <f:RowNumberField HeaderText="序号" Width="50px" />
                                                                <f:BoundField Width="100px" DataField="XM" HeaderText="姓名" />
                                                                <f:BoundField DataField="BMJZW" HeaderText="部门及职务" Width="200px" />
                                                                <f:BoundField HeaderText="手机" DataField="SJ" Width="150px" />
                                                                <f:BoundField HeaderText="电子邮箱" DataField="DZYX" Width="150px" />
                                                                <f:BoundField DataField="RWFG" HeaderText="任务分工" ExpandUnusedSpace="true" />
                                                            </Columns>
                                                        </f:Grid>
                                                    </Items>
                                                </f:GroupPanel>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button9_s2" Text="下一步" ValidateForms="Panel2,Panel6,Panel5,Panel3" ValidateMessageBox="true" runat="server" OnClick="Button_step3_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>

                                <f:SimpleForm ID="SimpleForm_step3" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="<strong>申报项目建设方案</strong>" runat="server">
                                            <Items>
                                                <f:GroupPanel ID="GroupPanel32" Layout="Anchor" Title="<strong>申报理由</strong>" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txtSBXMJSFA_SBLY" Label="申报理由" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" Height="200px" EmptyText="请说明开展本赛项的必要性和可行性。（不超过500字）" MaxLength="500">
                                                        </f:TextArea>
                                                    </Items>
                                                </f:GroupPanel>
                                                <f:GroupPanel ID="GroupPanel33" Layout="Anchor" Title="<strong>建设目标</strong>" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txtSBXMJSFA_JSMB" Label="建设目标" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" Height="200px" EmptyText="请阐述本赛项要达到的总体目标。（不超过500字）" MaxLength="500">
                                                        </f:TextArea>
                                                    </Items>
                                                </f:GroupPanel>
                                                <f:GroupPanel ID="GroupPanel34" Layout="Anchor" Title="<strong>具体举措</strong>" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txtSBXMJSFA_JTJC" Label="具体举措" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" Height="200px" EmptyText="请阐述赛项举办内容及具体举措。（不超过1000字）" MaxLength="1000">
                                                        </f:TextArea>
                                                    </Items>
                                                </f:GroupPanel>
                                                <f:GroupPanel ID="GroupPanel35" Layout="Anchor" Title="<strong>经费安排</strong>" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txtSBXMJSFA_JFAP" Label="经费安排" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" Height="200px" EmptyText="请阐述本赛项总体需要经费、来源和主要用途。（不超过500字）" MaxLength="500">
                                                        </f:TextArea>
                                                    </Items>
                                                </f:GroupPanel>
                                                <f:GroupPanel ID="GroupPanel36" Layout="Anchor" Title="<strong>实施计划</strong>" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txtSBXMJSFA_SSJH" Label="实施计划" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" Height="200px" EmptyText="请阐述赛项组织实施计划，按照筹备、实施、总结等流程分别填写。（不超过500字）" MaxLength="500">
                                                        </f:TextArea>
                                                    </Items>
                                                </f:GroupPanel>
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
                                <f:SimpleForm ID="SimpleForm_step7" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel28" Layout="Anchor" Title="<strong>项目验收指标</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel29" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="txtJSMB" Label="建设目标" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                        <f:DatePicker ID="dpYQWCSJ" Label="计划验收日期" Required="true" ShowRedStar="true" ColumnWidth="50%" runat="server" Margin="0 5 2 0"></f:DatePicker>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel30" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextArea ID="txtYSYD" Label="验收要点" Required="true" ShowRedStar="true" ColumnWidth="100%" runat="server" Margin="0 5 2 0" EmptyText="1. 2. 3. ……"></f:TextArea>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel32" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Toolbars>
                                                        <f:Toolbar ID="Toolbar7" runat="server" ToolbarAlign="Right" Position="Bottom" Margin="0 5 5 0">
                                                            <Items>
                                                                <f:Button ID="btnYSZBSave" Text="确定" ValidateMessageBox="false" runat="server" Icon="PageSave" ValidateForms="GroupPanel28" OnClick="btnYSZBSave_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:Toolbar>
                                                    </Toolbars>
                                                </f:Panel>
                                                <f:Panel ID="Panel31" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:Grid ID="GridYSZB" runat="server" Title="已添加项目验收指标" Height="300px" Margin="0 5 5 0" EnableMultiSelect="false" EnableCheckBoxSelect="true" DataKeyNames="ID" ColumnWidth="100%">
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar5" runat="server">
                                                                    <Items>
                                                                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                                                        </f:ToolbarSeparator>
                                                                        <f:Button ID="btnYSZBDel" Text="删除" runat="server" ConfirmText="确定删除？" Icon="Delete" OnClick="btnYSZBDel_Click">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                            <Columns>
                                                                <f:RowNumberField HeaderText="序号" Width="50px" />
                                                                <f:BoundField Width="200px" DataField="JSMB" HeaderText="建设目标" />
                                                                <f:BoundField Width="100px" DataField="YQWCSJ" HeaderText="计划验收日期" />
                                                                <f:BoundField DataField="YSYD" HeaderText="验收要点" ExpandUnusedSpace="true" />
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
                                                                <f:NumberBox ID="txtJFYS_ZXJF" runat="server" Label="申请专项经费合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false" Text="0"></f:NumberBox>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期" ID="dpJFYS_ZXJF_ZXKSSJ" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="dpJFYS_ZXJF_ZXKSSJ" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期" ID="dpJFYS_ZXJF_ZXJSSJ" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>

                                                            </Items>

                                                        </f:Panel>
                                                        <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="<strong>1、竞赛方案研制经费</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel37" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_JSFA_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_ZXJF_JSFA_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="ZXJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_JSFA_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>

                                                        <f:GroupPanel ID="GroupPanel5" Layout="Anchor" Title="<strong>2、业务培训经费</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_YWPX_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_ZXJF_YWPX_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="ZXJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_YWPX_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel6" Layout="Anchor" Title="<strong>3、仪器设备及耗材经费</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_YQSB_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_ZXJF_YQSB_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="ZXJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_YQSB_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel7" Layout="Anchor" Title="<strong>4、外聘人员费用</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_WPRY_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_ZXJF_WPRY_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="ZXJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_WPRY_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel11" Layout="Anchor" Title="<strong>5、业务费（包括差旅、印刷、交通、宣传等）</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_YWF_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_ZXJF_YWF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="ZXJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_YWF_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel12" Layout="Anchor" Title="<strong>经费概算合计</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_JFGSHJ_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_ZXJF_JFGSHJ_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" Enabled="false" Text="0" EmptyText="自动合计"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_ZXJF_JFGSHJ_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                    </Items>
                                                </f:GroupPanel>

                                                <f:GroupPanel ID="GroupPanel10" Layout="Anchor" Title="<strong>学校配套经费</strong>" runat="server">
                                                    <Items>
                                                        <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:NumberBox ID="txtJFYS_XXPTJF" runat="server" Label="申请专项经费合计(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Enabled="false" Text="0"></f:NumberBox>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期" ID="dpJFYS_XXPTJF_ZXKSSJ" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>
                                                                <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="dpJFYS_XXPTJF_ZXKSSJ" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期" ID="dpJFYS_XXPTJF_ZXJSSJ" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>

                                                            </Items>

                                                        </f:Panel>
                                                        <f:GroupPanel ID="GroupPanel13" Layout="Anchor" Title="<strong>1、竞赛方案研制经费</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel12" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_JSFA_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_XXPTJF_JSFA_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="XXPTJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_JSFA_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>

                                                        <f:GroupPanel ID="GroupPanel14" Layout="Anchor" Title="<strong>2、业务培训经费</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel13" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_YWPX_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_XXPTJF_YWPX_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="XXPTJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_YWPX_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel15" Layout="Anchor" Title="<strong>3、仪器设备及耗材经费</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel14" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_YQSB_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_XXPTJF_YQSB_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="XXPTJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_YQSB_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel16" Layout="Anchor" Title="<strong>4、外聘人员费用</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel15" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_WPRY_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_XXPTJF_WPRY_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="XXPTJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_WPRY_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel17" Layout="Anchor" Title="<strong>5、业务费（包括差旅、印刷、交通、宣传等）</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel16" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_YWF_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_XXPTJF_YWF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" OnTextChanged="XXPTJFSum_TextChanged"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_YWF_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                        <f:GroupPanel ID="GroupPanel18" Layout="Anchor" Title="<strong>经费概算合计</strong>" runat="server" EnableCollapse="true">
                                                            <Items>
                                                                <f:Panel ID="Panel17" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                                    <Items>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_JFGSHJ_SM" Label="具体使用说明" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                        <f:NumberBox ID="txtJFYS_XXPTJF_JFGSHJ_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="33%" Margin="0 5 2 0" AutoPostBack="true" Enabled="false" Text="0" EmptyText="自动合计"></f:NumberBox>
                                                                        <f:TextBox ID="txtJFYS_XXPTJF_JFGSHJ_BZ" Label="备注" Required="true" ShowRedStar="true" ColumnWidth="33%" runat="server" Margin="0 5 2 0"></f:TextBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:GroupPanel>
                                                    </Items>
                                                </f:GroupPanel>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar12" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button12" Text="下一步" ValidateForms="GroupPanel8" ValidateMessageBox="true" runat="server" OnClick="Button_step9_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <f:Window ID="SimpleForm_step9" runat="server" Title="上传附件" IsModal="false" EnableClose="false" EnableResize="true" EnableDrag="false" Hidden="true" Layout="Fit" Width="500px">
                                    <Items>
                                        <f:SimpleForm ID="SimpleForm_step22" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" AutoScroll="true">
                                            <Items>

                                                <f:SimpleForm ID="SimpleForm3" BodyPadding="5px" runat="server" EnableCollapse="true"
                                                    ShowBorder="True" Title="&nbsp;" ShowHeader="false">
                                                    <Items>

                                                        <f:FileUpload runat="server" ID="FileUpload3" EmptyText="请选择上传附件" Label="项目预算明细表" OnFileSelected="FileUpload3_FileSelected" AutoPostBack="true">
                                                        </f:FileUpload>
                                                        <f:HyperLink ID="HyperLink3" Text="下载项目预算明细表模板" Target="_blank" NavigateUrl="WordMaster/模板下载/技术技能竞赛/附件：项目预算明细表.docx" runat="server">
                                                        </f:HyperLink>
                                                        <%--   <f:Button ID="btnUploadAtta" runat="server" ValidateForms="SimpleForm3"
                                                            Text="上传" Icon="DiskUpload" OnClick="btnUploadAtta_Click">
                                                        </f:Button>--%>
                                                    </Items>
                                                </f:SimpleForm>

                                            </Items>
                                            <Toolbars>
                                                <f:Toolbar ID="Toolbar13" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                    <Items>
                                                        <f:Button ID="btnSaveEnd" Text="保存" Icon="SystemSaveClose" ValidateForms="SimpleForm_step2,SimpleForm_step3,SimpleForm_step8,SimpleForm_step9" ValidateMessageBox="true" runat="server" Margin="10 5 10 0" OnClick="btnSaveEnd_Click">
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
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server"
            IsModal="true" Width="600px" Height="450px">
        </f:Window>
    </form>

    <script type="text/javascript">
        function a(index) {

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

