<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SZPX_Add.aspx.cs" Inherits="XMGL.Web.admin.SZPX_Add"
    EnableEventValidation="false" ViewStateEncryptionMode="Always" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/theme-start/theme.css" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/layout4.css" />
    <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <style>
        .ui-autocomplete-loading
        {
            background: white url('../res/images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        .autocomplete-item-title
        {
            font-weight: bold;
        }
        .ui-autocomplete
        {
            max-height: 200px;
            overflow-y: auto; /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }
        .auto-style1
        {
            width: 100%;
        }
        
        .wz
        {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="Button_step1,Button_step2,Button_step3,Button_step4,Button_step5,Button_step6" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="5px" Title="申报项目" ShowBorder="true"
        ShowHeader="false" BoxConfigAlign="Stretch" Margin="0 10 5 0" AutoScroll="true">
        <Items>
            <f:ContentPanel ID="ContentPanel1" runat="server" BoxConfigAlign="Stretch" ShowBorder="false"
                ShowHeader="false" AutoScroll="true">
                <div id="wrapper">
                    <div class="container mt20">
                        <div id="processor">
                            <ol class="processorBox oh">
                                <li class="current" id="li1">
                                    <%--   <li  id="li1">--%>
                                    <div class="step_inner">
                                        <%--   <div class="step_inner">--%>
                                        <%--<span class="icon_step">1</span>--%>
                                        <asp:Button ID="Button_step1" runat="server" Text="1" CssClass="icon_step" BorderStyle="None"
                                            UseSubmitBehavior="false" />
                                        <h4>
                                            单位承诺及填表说明</h4>
                                    </div>
                                </li>
                                <li id="li2">
                                    <div class="step_inner">
                                        <asp:Button ID="Button_step2" runat="server" Text="2" CssClass="icon_step" BorderStyle="None"
                                            UseSubmitBehavior="false" />
                                        <%--  <span class="icon_step">2</span>--%>
                                        <h4>
                                            项目团队人员信息</h4>
                                    </div>
                                </li>
                                <li id="li3">
                                    <div class="step_inner">
                                        <asp:Button ID="Button_step3" runat="server" Text="3" CssClass="icon_step" BorderStyle="None"
                                            UseSubmitBehavior="false" />
                                        <%-- <span class="icon_step">3</span>--%>
                                        <h4>
                                            申报项目建设方案</h4>
                                    </div>
                                </li>
                                <li id="li4">
                                    <div class="step_inner">
                                        <asp:Button ID="Button_step4" runat="server" Text="4" CssClass="icon_step" BorderStyle="None"
                                            UseSubmitBehavior="false" />
                                        <h4>
                                            项目验收指标</h4>
                                    </div>
                                </li>
                                <li id="li5">
                                    <div class="step_inner">
                                        <asp:Button ID="Button_step5" runat="server" Text="5" CssClass="icon_step" BorderStyle="None"
                                            UseSubmitBehavior="false" />
                                        <h4>
                                            经费预算</h4>
                                    </div>
                                </li>
                                <li id="li6">
                                    <div class="step_inner">
                                        <asp:Button ID="Button_step6" runat="server" Text="6" CssClass="icon_step" BorderStyle="None"
                                           UseSubmitBehavior="false" />
                                        <h4>
                                            附件：项目预算明细表</h4>
                                    </div>
                                </li>
                            </ol>
                            <div class="step_line">
                            </div>
                        </div>
                        <div class="content">
                            <f:ContentPanel runat="server" ID="ContentPanel_step1" ShowBorder="false" ShowHeader="false">
                                <div class="dwcn">
                                    <h2>
                                        单 位 承 诺</h2>
                                    <p class="cn-p">
                                        我单位承诺对填写的各项内容的真实性，与网上填报内容一致性负责。如获准立项，我单位承诺以本申报书为有约束力的协议，遵守上海市教育委员会的相关规定，按计划认真开展建设工作，取得预期建设成果。本表所有数据和资料均未涉密，上海市教育委员会有权使用本表所有数据和资料。</p>
                                    <br />
                                    <br />
                                    <h2>
                                        填 表 说 明</h2>
                                    <p class="sm-p">
                                        一、本申报书为2015年上海高等职业教育质量提升计划专项经费项目申报书；</p>
                                    <p class="sm-p">
                                        二、请按本申报书格式，通过上海高职教育网“项目管理”专栏如实填报后提交；</p>
                                    <p class="sm-p">
                                        三、同一单位不同申报项目须分别填报；</p>
                                    <p class="sm-p">
                                        四、本申报书封面上方项目编号框不用填写，由系统自动生成；</p>
                                    <p class="sm-p">
                                        五、纸质版由系统生成后，请用A4纸双面打印一式两份,加盖公章后报送上海市教育委员会高等教育处；</p>
                                    <p class="sm-p">
                                        六、上海市教育委员会高等教育处通讯地址：上海市大沽路100号3303室，邮政编码：200003。</p>
                                </div>
                                <f:SimpleForm ID="SimpleForm4" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                                    runat="server">
                                    <Items>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar4" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button4" Text="下一步" runat="server" OnClick="Button_step2_Click" Margin="10 100 10 0">
                                                </f:Button>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                            </f:ContentPanel>
                            <f:SimpleForm ID="SimpleForm_step2" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px"
                                ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                <Items>
                                    <f:Panel ID="Panels2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Items>
                                            <f:TextBox ID="XMSB_XMMC" Label="申报项目名称" Margin="0 0 2 0" Required="true" ShowRedStar="true"
                                                MaxLength="500" ColumnWidth="100%" runat="server">
                                            </f:TextBox>
                                            <f:TextBox ID="XMSB_DWMC" Label="单位名称" Margin="0 0 2 0" Required="true" ShowRedStar="true"
                                                MaxLength="500" ColumnWidth="100%" runat="server" Readonly="true">
                                            </f:TextBox>
                                        </Items>
                                    </f:Panel>
                                    <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="<strong>项目团队人员信息</strong>"
                                        runat="server">
                                        <Items>
                                            <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="<strong>项目负责人信息</strong>" runat="server">
                                                <Items>
                                                    <f:Panel ID="Panel5" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="XMCY_FZR_CYXM" Label="姓  名" Required="true" ShowRedStar="true" ColumnWidth="50%"
                                                                MaxLength="10" runat="server" Margin="0 5 2 2">
                                                            </f:TextBox>
                                                            <f:TextBox ID="XMCY_FZR_BM" Label="部  门" Required="true" ShowRedStar="true" ColumnWidth="50%"
                                                                MaxLength="180" runat="server" Margin="0 5 2 0">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="XMCY_FZR_ZYJSZW" Label="专业技术职务" Required="true" ShowRedStar="true"
                                                                MaxLength="180" ColumnWidth="50%" runat="server" Margin="0 3 2 0">
                                                            </f:TextBox>
                                                            <f:TextBox ID="XMCY_FZR_XZZW" Label="行政职务" Required="true" ShowRedStar="true" ColumnWidth="50%"
                                                                MaxLength="180" runat="server" Margin="0 3 2 0">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel6" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="XMCY_FZR_BGSDH" Label="办公室电话" Required="true" ShowRedStar="true" ColumnWidth="50%"
                                                                MaxLength="30" runat="server" Margin="0 3 2 0">
                                                            </f:TextBox>
                                                            <f:TextBox ID="XMCY_FZR_CZ" Label="传  真" Required="true" ShowRedStar="true" ColumnWidth="50%"
                                                                MaxLength="30" runat="server" Margin="0 5 5 2">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="XMCY_FZR_SJ" Label="手  机" Required="true" ShowRedStar="true" ColumnWidth="50%"
                                                                Regex="^(13|14|15|16|17|18|19)\d{9}$" runat="server" Margin="0 5 5 0">
                                                            </f:TextBox>
                                                            <f:TextBox ID="XMCY_FZR_DZYX" Label="电子邮箱" Required="true" ShowRedStar="true" ColumnWidth="50%"
                                                                RegexPattern="EMAIL" runat="server" Margin="0 3 5 0">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                            </f:GroupPanel>
                                            <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="<strong>项目成员信息</strong>" runat="server">
                                                <Items>
                                                    <f:Form runat="server" Title="填写项目成员信息" ID="Form3">
                                                        <Items>
                                                            <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                                runat="server">
                                                                <Items>
                                                                    <f:Panel ID="Panel8" runat="server" Margin="5 5 2 10" ColumnWidth="50%" ShowBorder="false"
                                                                        ShowHeader="false">
                                                                        <Items>
                                                                            <f:Label runat="server" ID="Label13" Text="项目成员姓名：" ShowRedStar="true">
                                                                            </f:Label>
                                                                            <f:TextBox ID="XMCY_CY_CYXM" Label="项目成员姓名" Width="300px" ShowRedStar="true" runat="server"
                                                                                MaxLength="10" ShowLabel="false">
                                                                            </f:TextBox>
                                                                        </Items>
                                                                    </f:Panel>
                                                                    <f:Panel ID="Panel2" runat="server" Margin="5 5 2 10" ColumnWidth="50%" ShowBorder="false"
                                                                        ShowHeader="false">
                                                                        <Items>
                                                                            <f:Label ID="Label14" runat="server" Text="部门及职务：">
                                                                            </f:Label>
                                                                            <f:TextBox ID="XMCY_CY_BMJZW" Label="部门及职务" Width="300px" ShowRedStar="true" runat="server"
                                                                                MaxLength="180" ShowLabel="false">
                                                                            </f:TextBox>
                                                                        </Items>
                                                                    </f:Panel>
                                                                    <f:Panel ID="Panel64" runat="server" Margin="5 5 2 10" ColumnWidth="50%" ShowBorder="false"
                                                                        ShowHeader="false">
                                                                        <Items>
                                                                            <f:Label ID="Label15" runat="server" Text="任务分工：">
                                                                            </f:Label>
                                                                            <f:TextBox ID="XMCY_CY_RWFG" Label="任务分工" runat="server" ShowLabel="false" Width="300px"
                                                                                MaxLength="2000" Enabled="true">
                                                                            </f:TextBox>
                                                                        </Items>
                                                                    </f:Panel>
                                                                    <f:Panel ID="Panel65" runat="server" Margin="5 5 2 10" ColumnWidth="50%" ShowBorder="false"
                                                                        ShowHeader="false">
                                                                        <Items>
                                                                            <f:Label ID="Label16" runat="server" Text="手    机：">
                                                                            </f:Label>
                                                                            <f:TextBox ID="XMCY_CY_SJ" Label="手    机" runat="server" ShowLabel="false" Width="300px"
                                                                                Regex="^(13|14|15|16|17|18|19)\d{9}$" Enabled="true">
                                                                            </f:TextBox>
                                                                        </Items>
                                                                    </f:Panel>
                                                                    <f:Panel ID="Panel67" runat="server" Margin="5 5 2 10" ColumnWidth="50%" ShowBorder="false"
                                                                        ShowHeader="false">
                                                                        <Items>
                                                                            <f:Label ID="Label17" runat="server" Text="电子邮箱：">
                                                                            </f:Label>
                                                                            <f:TextBox ID="XMCY_CY_DZYX" Label="电子邮箱" runat="server" ShowLabel="false" Width="300px"
                                                                                RegexPattern="EMAIL" Enabled="true">
                                                                            </f:TextBox>
                                                                        </Items>
                                                                    </f:Panel>
                                                                </Items>
                                                            </f:Panel>
                                                        </Items>
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar14" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                                <Items>
                                                                    <f:Button ID="SZPX_XMCY_add" Text="添加新的项目成员信息" runat="server" OnClick="SZPX_XMCY_add_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                    </f:Form>
                                                    <f:Panel ID="Panel71" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的项目成员信息列表"
                                                        ShowBorder="false" ShowHeader="true" RowHeight="300px">
                                                        <Items>
                                                            <f:Grid ID="XMCY_CY_List_Grid" Title="项目成员信息列表" ShowBorder="true" BoxFlex="1" ShowHeader="false"
                                                                runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true" EnableMultiSelect="false">
                                                                <Toolbars>
                                                                    <f:Toolbar ID="Toolbar15" runat="server">
                                                                        <Items>
                                                                            <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                                                            </f:ToolbarSeparator>
                                                                            <f:Button ID="SZPX_XMCY_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="SZPX_XMCY_delete_Click">
                                                                            </f:Button>
                                                                        </Items>
                                                                    </f:Toolbar>
                                                                </Toolbars>
                                                                <Columns>
                                                                    <f:BoundField Width="100px" DataField="XMCY_CY_CYXM" HeaderText="项目成员姓名" />
                                                                    <f:BoundField Width="150px" DataField="XMCY_CY_BMJZW" HeaderText="部门及职务" />
                                                                    <f:BoundField Width="150px" DataField="XMCY_CY_RWFG" HeaderText="任务分工" />
                                                                    <f:BoundField Width="150px" DataField="XMCY_CY_SJ" HeaderText="手    机" />
                                                                    <f:BoundField Width="150px" DataField="XMCY_CY_DZYX" HeaderText="电子邮箱" />
                                                                </Columns>
                                                            </f:Grid>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                            </f:GroupPanel>
                                        </Items>
                                    </f:GroupPanel>
                                </Items>
                                <Toolbars>
                                    <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                                        <Items>
                                            <f:Button ID="Back_step2" Text="上一步" runat="server" Margin="10 10 10 0" OnClick="Back_step2_Click">
                                            </f:Button>
                                            <f:Button ID="Button9_s2" Text="下一步" ValidateForms="SimpleForm_step2" ValidateMessageBox="true"
                                                runat="server" OnClick="Button_step3_Click" Margin="10 100 10 0">
                                            </f:Button>
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                            </f:SimpleForm>
                            <f:SimpleForm ID="SimpleForm_step3" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px"
                                ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                <Items>
                                    <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="<strong>申报项目建设方案</strong>"
                                        runat="server">
                                        <Items>
                                            <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                runat="server">
                                                <Items>
                                                    <f:TextArea ID="JSFA_SBLY" runat="server" Height="200px" Label="申报理由" Text="" ColumnWidth="98%"
                                                        Margin="10 5 10 0" EmptyText="请简要说明开展项目建设的必要性和可行性。（不超过500字）" Required="true"
                                                        MaxLength="700" ShowRedStar="true">
                                                    </f:TextArea>
                                                </Items>
                                            </f:Panel>
                                            <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                runat="server">
                                                <Items>
                                                    <f:TextArea ID="JSFA_JSMB" runat="server" Height="200px" Label="建设目标" Text="" ColumnWidth="98%"
                                                        MaxLength="700" Margin="10 5 10 0" EmptyText="请简要阐述项目建设总体目标。（不超过500字）" Required="true"
                                                        ShowRedStar="true">
                                                    </f:TextArea>
                                                </Items>
                                            </f:Panel>
                                            <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                runat="server">
                                                <Items>
                                                    <f:TextArea ID="JSFA_JTJC" runat="server" Height="200px" Label="具体举措" Text="" ColumnWidth="98%"
                                                        MaxLength="1300" Margin="10 5 10 0" EmptyText="请简要阐述建设内容及举措。（不超过1000字）" Required="true"
                                                        ShowRedStar="true">
                                                    </f:TextArea>
                                                </Items>
                                            </f:Panel>
                                            <f:Panel ID="Panel12" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                runat="server">
                                                <Items>
                                                    <f:TextArea ID="JSFA_JFAP" runat="server" Height="200px" Label="经费安排" Text="" ColumnWidth="98%"
                                                        MaxLength="700" Margin="10 5 10 0" EmptyText="请阐述项目总体需要经费、来源和主要用途。（不超过500字）"
                                                        Required="true" ShowRedStar="true">
                                                    </f:TextArea>
                                                </Items>
                                            </f:Panel>
                                            <f:Panel ID="Panel13" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                runat="server">
                                                <Items>
                                                    <f:TextArea ID="JSFA_SSJH" runat="server" Height="200px" Label="实施计划" Text="" ColumnWidth="98%"
                                                        MaxLength="700" Margin="10 5 10 0" EmptyText="请简要阐述项目实施计划，执行周期为1年的项目需按季度列明实施计划，其他项目按照年度填写。（不超过500字）"
                                                        Required="true" ShowRedStar="true">
                                                    </f:TextArea>
                                                </Items>
                                            </f:Panel>
                                        </Items>
                                    </f:GroupPanel>
                                </Items>
                                <Toolbars>
                                    <f:Toolbar ID="Toolbar8" runat="server" ToolbarAlign="Right" Position="Bottom">
                                        <Items>
                                            <f:Button ID="Back_step3" Text="上一步" runat="server" Margin="10 10 10 0" OnClick="Back_step3_Click">
                                            </f:Button>
                                            <f:Button ID="Button9_s3" Text="下一步" ValidateForms="SimpleForm_step3" ValidateMessageBox="true"
                                                runat="server" OnClick="Button_step4_Click" Margin="10 100 10 0">
                                            </f:Button>
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                            </f:SimpleForm>
                            <f:SimpleForm ID="SimpleForm_step4" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px"
                                ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                <Items>
                                    <f:GroupPanel ID="GroupPanel7" Layout="Anchor" Title="<strong>项目验收指标</strong>（请分别说明各建设目标，并列出验收要点，预期完成时间从项目立项之日起计算。）"
                                        runat="server">
                                        <Items>
                                            <f:Form runat="server" Title="添加项目验收指标" ID="Form5" Margin="0 0 10 0">
                                                <Items>
                                                    <f:Panel ID="Panel30" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextArea ID="TextArea_jsmb" runat="server" Height="100px" Label="建设目标" Text=""
                                                                MaxLength="700" ColumnWidth="80%" Margin="10 5 10 5" ShowRedStar="True">
                                                            </f:TextArea>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel31" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:DatePicker runat="server" EnableEdit="false" Label="预期完成时间" EmptyText="请选择日期"
                                                                ID="DatePicker_yqwcsj" ShowRedStar="True" ColumnWidth="80%" Margin="0 5 10 5">
                                                            </f:DatePicker>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel32" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextArea ID="TextArea_ysyd" runat="server" Height="200px" Label="验收要点" Text=""
                                                                MaxLength="700" ColumnWidth="80%" Margin="0 5 10 5" ShowRedStar="True">
                                                            </f:TextArea>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar3" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="YSZB_add" Text="添加到项目验收指标列表" ValidateForms="Form5" ValidateMessageBox="false"
                                                                runat="server" OnClick="YSZB_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel21" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的项目验收指标列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 5 10 0">
                                                <Items>
                                                    <f:Grid ID="YSZB_list_Grid" Title="项目验收指标列表" ShowBorder="true" BoxFlex="1" ShowHeader="false"
                                                        runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true" EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar7" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="YSZB_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="YSZB_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="150px" DataField="YSZB_JSMB" HeaderText="建设目标" DataToolTipField="YSZB_JSMB" />
                                                            <f:BoundField Width="120px" DataField="YSZB_YQWCSJ" HeaderText="预期完成时间" DataToolTipField="YSZB_YQWCSJ" />
                                                            <f:BoundField Width="150px" DataField="YSZB_YSYD" DataToolTipField="YSZB_YSYD" HeaderText="验收要点" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>
                                        </Items>
                                    </f:GroupPanel>
                                </Items>
                                <Toolbars>
                                    <f:Toolbar ID="Toolbar9" runat="server" ToolbarAlign="Right" Position="Bottom">
                                        <Items>
                                            <f:Button ID="Back_step4" Text="上一步" runat="server" Margin="10 10 10 0" OnClick="Back_step4_Click">
                                            </f:Button>
                                            <f:Button ID="Button9" Text="下一步" ValidateForms="SimpleForm_step4" ValidateMessageBox="true"
                                                runat="server" OnClick="Button_step5_Click" Margin="10 100 10 0">
                                            </f:Button>
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                            </f:SimpleForm>
                            <f:SimpleForm ID="SimpleForm_step5" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px"
                                ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                <Items>
                                    <f:GroupPanel ID="GroupPanel6" Layout="Anchor" Title="<strong>经费预算</strong>" runat="server">
                                        <Items>
                                            <f:Panel ID="Panelsqzxjf33" Layout="Anchor" Title="<strong>申请专项经费</strong>" runat="server"
                                                ShowBorder="true" ShowHeader="true">
                                                <Items>
                                                    <f:Panel ID="Panel18" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        Margin="10 15 10 10" runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="ZXJF_JFYS" runat="server" Label="申请专项经费合计(万元)" MinValue="0" DecimalPrecision="2"
                                                                NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0"
                                                                EmptyText="系统自动汇总" Readonly="true" Enabled="false">
                                                            </f:NumberBox>
                                                            <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd"
                                                                Label="执行开始日期" EmptyText="请选择日期" ID="ZXJF_ZXKSSJ" ShowRedStar="True" ColumnWidth="30%"
                                                                Margin="0 5 5 5">
                                                            </f:DatePicker>
                                                            <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd"
                                                                CompareControl="ZXJF_ZXKSSJ" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期"
                                                                Label="执行结束日期" EmptyText="请选择日期" ID="ZXJF_ZXJSSJ" ShowRedStar="True" ColumnWidth="30%"
                                                                Margin="0 5 5 5">
                                                            </f:DatePicker>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:GroupPanel ID="GroupPanel40" Layout="Container" CssClass="formitem" runat="server"
                                                        Title="预算明细" Margin="10 5 5 0">
                                                        <Items>
                                                            <f:GroupPanel ID="GroupPanel11" Layout="Anchor" Title="<strong>课程教材及资料费</strong>"
                                                                Margin="10 15 10 10" runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="ZXJF_KCJCJZLF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="ZXJF_KCJCJZLF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0"
                                                                        DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2"
                                                                        OnTextChanged="NumberBox_SQZXJF_TextChanged" AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="ZXJF_KCJCJZLF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel12" Layout="Anchor" Title="<strong>仪器设备及耗材费</strong>"
                                                                Margin="10 15 10 10" runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="ZXJF_YQSBJHCF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="ZXJF_YQSBJHCF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0"
                                                                        DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2"
                                                                        OnTextChanged="NumberBox_SQZXJF_TextChanged" AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="ZXJF_YQSBJHCF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel13" Layout="Anchor" Title="<strong>外聘人员经费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="ZXJF_WPRYJF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="ZXJF_WPRYJF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_SQZXJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="ZXJF_WPRYJF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel14" Layout="Anchor" Title="<strong>场地费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="ZXJF_CDF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="ZXJF_CDF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_SQZXJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="ZXJF_CDF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel15" Layout="Anchor" Title="<strong>餐饮费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="ZXJF_CYF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="ZXJF_CYF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_SQZXJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="ZXJF_CYF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel16" Layout="Anchor" Title="<strong>住宿费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="ZXJF_ZSF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="ZXJF_ZSF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_SQZXJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="ZXJF_ZSF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel17" Layout="Anchor" Title="<strong>交通费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="ZXJF_JTF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="ZXJF_JTF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_SQZXJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="ZXJF_JTF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanels22" Layout="Anchor" Title="<strong>经费概算合计</strong>"
                                                                Margin="10 15 10 10" runat="server">
                                                                <Items>
                                                                    <%--<f:TextArea ID="ZXJF_JFHJ_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>--%>
                                                                    <f:NumberBox ID="ZXJF_JFHJ_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" Readonly="true"
                                                                        Enabled="false" AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <%--<f:TextArea ID="ZXJF_JFHJ_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>--%>
                                                                </Items>
                                                            </f:GroupPanel>
                                                        </Items>
                                                    </f:GroupPanel>
                                                </Items>
                                            </f:Panel>
                                            <f:Panel ID="Panelxxptjf1" Layout="Anchor" Title="<strong>学校配套经费</strong>" runat="server"
                                                ShowBorder="true" ShowHeader="true">
                                                <Items>
                                                    <f:Panel ID="Panel19" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        Margin="10 15 10 10" runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="PTJF_JFYS" runat="server" Label="学校配套经费合计(万元)" MinValue="0" DecimalPrecision="2"
                                                                NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0"
                                                                EmptyText="系统自动汇总" Readonly="true" Enabled="false">
                                                            </f:NumberBox>
                                                            <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd"
                                                                Label="执行开始日期" EmptyText="请选择日期" ID="PTJF_ZXKSSJ" ShowRedStar="True" ColumnWidth="30%"
                                                                Margin="0 5 5 5">
                                                            </f:DatePicker>
                                                            <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd"
                                                                CompareControl="PTJF_ZXKSSJ" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期"
                                                                Label="执行结束日期" EmptyText="请选择日期" ID="PTJF_ZXJSSJ" ShowRedStar="True" ColumnWidth="30%"
                                                                Margin="0 5 5 5">
                                                            </f:DatePicker>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:GroupPanel ID="GroupPanel18" Layout="Container" CssClass="formitem" runat="server"
                                                        Title="预算明细" Margin="10 5 5 0">
                                                        <Items>
                                                            <f:GroupPanel ID="GroupPanel19" Layout="Anchor" Title="<strong>课程教材及资料费</strong>"
                                                                Margin="10 15 10 10" runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="PTJF_KCJCJZLF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="PTJF_KCJCJZLF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0"
                                                                        DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2"
                                                                        OnTextChanged="NumberBox_PTJF_TextChanged" AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="PTJF_KCJCJZLF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel20" Layout="Anchor" Title="<strong>仪器设备及耗材费</strong>"
                                                                Margin="10 15 10 10" runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="PTJF_YQSBJHCF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="PTJF_YQSBJHCF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0"
                                                                        DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2"
                                                                        OnTextChanged="NumberBox_PTJF_TextChanged" AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="PTJF_YQSBJHCF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel21" Layout="Anchor" Title="<strong>外聘人员经费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="PTJF_WPRYJF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="PTJF_WPRYJF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_PTJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="PTJF_WPRYJF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel22" Layout="Anchor" Title="<strong>场地费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="PTJF_CDF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="PTJF_CDF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_PTJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="PTJF_CDF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel23" Layout="Anchor" Title="<strong>餐饮费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="PTJF_CYF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="PTJF_CYF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_PTJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="PTJF_CYF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel24" Layout="Anchor" Title="<strong>住宿费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="PTJF_ZSF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="PTJF_ZSF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_PTJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="PTJF_ZSF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel25" Layout="Anchor" Title="<strong>交通费</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <f:TextArea ID="PTJF_JTF_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>
                                                                    <f:NumberBox ID="PTJF_JTF_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" OnTextChanged="NumberBox_PTJF_TextChanged"
                                                                        AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <f:TextArea ID="PTJF_JTF_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0">
                                                                    </f:TextArea>
                                                                </Items>
                                                            </f:GroupPanel>
                                                            <f:GroupPanel ID="GroupPanel26" Layout="Anchor" Title="<strong>经费概算合计</strong>" Margin="10 15 10 10"
                                                                runat="server">
                                                                <Items>
                                                                    <%--<f:TextArea ID="PTJF_JFHJ_SYSM" runat="server" Label="具体使用说明" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>--%>
                                                                    <f:NumberBox ID="PTJF_JFHJ_JFYS" runat="server" Label="经费预算(万元)" MinValue="0" DecimalPrecision="2"
                                                                        NoNegative="True" Required="true" ShowRedStar="True" Margin="5 0 5 2" Readonly="true"
                                                                        Enabled="false" AutoPostBack="true">
                                                                    </f:NumberBox>
                                                                    <%--<f:TextArea ID="PTJF_JFHJ_BZ" runat="server" Label="备注" Text="" Margin="10 5 10 0"
                                                                        Required="true" ShowRedStar="true">
                                                                    </f:TextArea>--%>
                                                                </Items>
                                                            </f:GroupPanel>
                                                        </Items>
                                                    </f:GroupPanel>
                                                </Items>
                                            </f:Panel>
                                        </Items>
                                    </f:GroupPanel>
                                </Items>
                                <Toolbars>
                                    <f:Toolbar ID="Toolbar10" runat="server" ToolbarAlign="Right" Position="Bottom">
                                        <Items>
                                            <f:Button ID="Back_step5" Text="上一步" runat="server" Margin="10 10 10 0" OnClick="Back_step5_Click">
                                            </f:Button>
                                            <f:Button ID="Button10" Text="下一步" ValidateForms="SimpleForm_step5" ValidateMessageBox="true"
                                                runat="server" OnClick="Button_step6_Click" Margin="10 100 10 0">
                                            </f:Button>
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                            </f:SimpleForm>
                            <f:Window ID="SimpleForm_step9" runat="server" Title="上传附件" IsModal="false" EnableClose="false"
                                EnableResize="true" EnableDrag="false" Hidden="true" Layout="Fit" Width="500px">
                                <Items>
                                    <f:SimpleForm ID="SimpleForm_step22" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px"
                                        ShowBorder="false" ShowHeader="false" runat="server" AutoScroll="true">
                                        <Items>
                                            
                                                    <%-- <f:Form runat="server" Title="课程教材及资料费" ID="KCJCJZLF_Form" Margin="50 0 0 0">
                                                <Items>
                                                    <f:Panel ID="Panel14" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="KCJCJZLF_JD" runat="server" Label="季度" MinValue="1" DecimalPrecision="2"
                                                                MaxValue="4" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="KCJCJZLF_KCJCZLMC" Label="课程/教材/资料名称" ShowRedStar="true" MaxLength="500"
                                                                ColumnWidth="50%" runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel34" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="KCJCJZLF_YSJF" Label="预算经费(单位：万元)" ShowRedStar="true" ColumnWidth="50%"
                                                                MaxLength="50" runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                            <f:TextBox ID="KCJCJZLF_BZ" Label="备注" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="KCJCJZLF_add" Text="添加到课程教材及资料费列表" ValidateForms="KCJCJZLF_Form" ValidateMessageBox="false"
                                                                runat="server" OnClick="KCJCJZLF_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel17" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的课程教材及资料费列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 0 0 0">
                                                <Items>
                                                    <f:Grid ID="KCJCJZLF_List_Grid" Title="课程教材及资料费列表" ShowBorder="true" BoxFlex="1"
                                                        ShowHeader="false" runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true"
                                                        EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar5" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="KCJCJZLF_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="KCJCJZLF_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="150px" DataField="KCJCJZLF_JD" HeaderText="季度" DataToolTipField="KCJCJZLF_JD" />
                                                            <f:BoundField Width="300px" DataField="KCJCJZLF_KCJCZLMC" HeaderText="课程/教材/资料名称"
                                                                DataToolTipField="KCJCJZLF_KCJCZLMC" />
                                                            <f:BoundField Width="150px" DataField="KCJCJZLF_YSJF" DataToolTipField="KCJCJZLF_YSJF"
                                                                HeaderText="预算经费" />
                                                            <f:BoundField Width="250px" DataField="KCJCJZLF_BZ" DataToolTipField="KCJCJZLF_BZ"
                                                                HeaderText="备注" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>
                                            <f:Form runat="server" Title="仪器设备及耗材费" ID="YQSBJHCF_Form" Margin="80 0 0 0">
                                                <Items>
                                                    <f:Panel ID="Panel15" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="YQSBJHCF_JD" runat="server" Label="季度" MinValue="1" DecimalPrecision="2"
                                                                MaxValue="4" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="YQSBJHCF_CPMC" Label="产品名称" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel35" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="YQSBJHCF_GGXH" Label="规格型号" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                            <f:NumberBox ID="YQSBJHCF_SL" runat="server" Label="数量" MinValue="0" DecimalPrecision="2"
                                                                MaxLength="50" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel36" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="YQSBJHCF_DW" Label="单位" ShowRedStar="true" MaxLength="50" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                            <f:TextBox ID="YQSBJHCF_DJ" Label="单价(单位：万元)" ShowRedStar="true" MaxLength="50" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel37" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="YQSBJHCF_HJ" Label="合计(单位：万元)" ShowRedStar="true" MaxLength="50" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar6" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="YQSBJHCF_add" Text="添加到仪器设备及耗材费列表" ValidateForms="YQSBJHCF_Form" ValidateMessageBox="false"
                                                                runat="server" OnClick="YQSBJHCF_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel16" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的仪器设备及耗材费列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 0 0 0">
                                                <Items>
                                                    <f:Grid ID="YQSBJHCF_List_Grid" Title="仪器设备及耗材费列表" ShowBorder="true" BoxFlex="1"
                                                        ShowHeader="false" runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true"
                                                        EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar11" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="YQSBJHCF_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="YQSBJHCF_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="100px" DataField="YQSBJHCF_JD" HeaderText="季度" DataToolTipField="YQSBJHCF_JD" />
                                                            <f:BoundField Width="300px" DataField="YQSBJHCF_CPMC" HeaderText="产品名称" DataToolTipField="YQSBJHCF_CPMC" />
                                                            <f:BoundField Width="300px" DataField="YQSBJHCF_GGXH" HeaderText="规格型号" DataToolTipField="YQSBJHCF_GGXH" />
                                                            <f:BoundField Width="150px" DataField="YQSBJHCF_SL" HeaderText="数量" DataToolTipField="YQSBJHCF_SL" />
                                                            <f:BoundField Width="150px" DataField="YQSBJHCF_DW" HeaderText="单位" DataToolTipField="YQSBJHCF_DW" />
                                                            <f:BoundField Width="150px" DataField="YQSBJHCF_DJ" HeaderText="单价(单位：万元)" DataToolTipField="YQSBJHCF_DJ" />
                                                            <f:BoundField Width="150px" DataField="YQSBJHCF_HJ" HeaderText="合计(单位：万元)" DataToolTipField="YQSBJHCF_HJ" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>
                                            <f:Form runat="server" Title="外聘人员经费" ID="WPRYJF_Form" Margin="80 0 0 0">
                                                <Items>
                                                    <f:Panel ID="Panel20" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="WPRYJF_JD" runat="server" Label="季度" MinValue="1" DecimalPrecision="2"
                                                                MaxValue="4" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="WPRYJF_XMMC" Label="项目名称" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel38" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="WPRYJF_WPRS" runat="server" Label="外聘人数" MinValue="0" DecimalPrecision="2"
                                                                MaxLength="50" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="WPRYJF_YSJF" Label="预算经费(单位：万元)" ShowRedStar="true" MaxLength="50"
                                                                ColumnWidth="50%" runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel39" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="WPRYJF_BZ" Label="备注" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar12" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="WPRYJF_add" Text="添加到外聘人员经费列表" ValidateForms="WPRYJF_Form" ValidateMessageBox="false"
                                                                runat="server" OnClick="WPRYJF_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel22" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的外聘人员经费列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 0 0 0">
                                                <Items>
                                                    <f:Grid ID="WPRYJF_List_Grid" Title="外聘人员经费列表" ShowBorder="true" BoxFlex="1" ShowHeader="false"
                                                        runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true" EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar16" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="Button7" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="WPRYJF_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="150px" DataField="WPRYJF_JD" HeaderText="季度" DataToolTipField="WPRYJF_JD" />
                                                            <f:BoundField Width="300px" DataField="WPRYJF_XMMC" HeaderText="项目名称" DataToolTipField="WPRYJF_XMMC" />
                                                            <f:BoundField Width="150px" DataField="WPRYJF_WPRS" HeaderText="外聘人数" DataToolTipField="WPRYJF_WPRS" />
                                                            <f:BoundField Width="150px" DataField="WPRYJF_YSJF" HeaderText="预算经费" DataToolTipField="WPRYJF_YSJF" />
                                                            <f:BoundField Width="150px" DataField="WPRYJF_BZ" HeaderText="备注" DataToolTipField="WPRYJF_BZ" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>
                                            <f:Form runat="server" Title="场地费" ID="CDF_Form" Margin="80 0 0 0">
                                                <Items>
                                                    <f:Panel ID="Panel23" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="CDF_JD" runat="server" Label="季度" MinValue="1" DecimalPrecision="2"
                                                                MaxValue="4" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="CDF_CDMC" Label="场地名称" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel40" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="CDF_YSJF" Label="预算经费(单位：万元)" ShowRedStar="true" MaxLength="50" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                            <f:TextBox ID="CDF_BZ" Label="备注" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar17" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="CDF_add" Text="添加到场地费列表" ValidateForms="CDF_Form" ValidateMessageBox="false"
                                                                runat="server" OnClick="CDF_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel24" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的场地费列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 0 0 0">
                                                <Items>
                                                    <f:Grid ID="CDF_List_Grid" Title="场地费列表" ShowBorder="true" BoxFlex="1" ShowHeader="false"
                                                        runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true" EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar18" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="CDF_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="CDF_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="150px" DataField="CDF_JD" HeaderText="季度" DataToolTipField="CDF_JD" />
                                                            <f:BoundField Width="300px" DataField="CDF_CDMC" HeaderText="场地名称" DataToolTipField="CDF_CDMC" />
                                                            <f:BoundField Width="150px" DataField="CDF_YSJF" HeaderText="预算经费(单位：万元)" DataToolTipField="CDF_YSJF" />
                                                            <f:BoundField Width="150px" DataField="CDF_BZ" HeaderText="备注" DataToolTipField="CDF_BZ" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>
                                            <f:Form runat="server" Title="餐饮费" ID="CYF_Form" Margin="80 0 0 0">
                                                <Items>
                                                    <f:Panel ID="Panel25" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="CYF_JD" runat="server" Label="季度" MinValue="1" DecimalPrecision="2"
                                                                MaxValue="4" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="CYF_XMMC" Label="项目名称" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel41" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="CYF_YSJF" Label="预算经费(单位：万元)" ShowRedStar="true" MaxLength="50" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                            <f:TextBox ID="CYF_BZ" Label="备注" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar19" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="CYF_add" Text="添加到餐饮费列表" ValidateForms="CYF_Form" ValidateMessageBox="false"
                                                                runat="server" OnClick="CYF_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel26" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的餐饮费列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 0 0 0">
                                                <Items>
                                                    <f:Grid ID="CYF_List_Grid" Title="餐饮费列表" ShowBorder="true" BoxFlex="1" ShowHeader="false"
                                                        runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true" EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar20" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="CYF_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="CYF_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="150px" DataField="CYF_JD" HeaderText="季度" DataToolTipField="CYF_JD" />
                                                            <f:BoundField Width="300px" DataField="CYF_XMMC" HeaderText="项目名称" DataToolTipField="CYF_XMMC" />
                                                            <f:BoundField Width="150px" DataField="CYF_YSJF" DataToolTipField="CYF_YSJF" HeaderText="预算经费(单位：万元)" />
                                                            <f:BoundField Width="300px" DataField="CYF_BZ" DataToolTipField="CYF_BZ" HeaderText="备注" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>
                                            <f:Form runat="server" Title="住宿费" ID="ZSF_Form" Margin="80 0 0 0">
                                                <Items>
                                                    <f:Panel ID="Panel27" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="ZSF_JD" runat="server" Label="季度" MinValue="1" DecimalPrecision="2"
                                                                MaxValue="4" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="ZSF_XMMC" Label="项目名称" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel42" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="ZSF_YSJF" Label="预算经费(单位：万元)" ShowRedStar="true" MaxLength="50" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                            <f:TextBox ID="ZSF_BZ" Label="备注" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar21" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="ZSF_add" Text="添加到住宿费列表" ValidateForms="ZSF_Form" ValidateMessageBox="false"
                                                                runat="server" OnClick="ZSF_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel28" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的住宿费列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 0 0 0">
                                                <Items>
                                                    <f:Grid ID="ZSF_List_Grid" Title="住宿费列表" ShowBorder="true" BoxFlex="1" ShowHeader="false"
                                                        runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true" EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar22" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator8" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="ZSF_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="ZSF_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="150px" DataField="ZSF_JD" HeaderText="季度" DataToolTipField="ZSF_JD" />
                                                            <f:BoundField Width="300px" DataField="ZSF_XMMC" HeaderText="项目名称" DataToolTipField="ZSF_XMMC" />
                                                            <f:BoundField Width="150px" DataField="ZSF_YSJF" DataToolTipField="ZSF_YSJF" HeaderText="预算经费(单位：万元)" />
                                                            <f:BoundField Width="300px" DataField="ZSF_BZ" DataToolTipField="ZSF_BZ" HeaderText="备注" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>
                                            <f:Form runat="server" Title="交通费" ID="JTF_Form" Margin="80 0 0 0">
                                                <Items>
                                                    <f:Panel ID="Panel29" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:NumberBox ID="JTF_JD" runat="server" Label="季度" MinValue="1" DecimalPrecision="2"
                                                                MaxValue="4" NoNegative="True" ShowRedStar="True" ColumnWidth="50%" Margin="0 5 5 5">
                                                            </f:NumberBox>
                                                            <f:TextBox ID="JTF_XMMC" Label="项目名称" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                    <f:Panel ID="Panel43" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false"
                                                        runat="server">
                                                        <Items>
                                                            <f:TextBox ID="JTF_YSJF" Label="预算经费(单位：万元)" ShowRedStar="true" MaxLength="50" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                            <f:TextBox ID="JTF_BZ" Label="备注" ShowRedStar="true" MaxLength="500" ColumnWidth="50%"
                                                                runat="server" Margin="0 5 5 5">
                                                            </f:TextBox>
                                                        </Items>
                                                    </f:Panel>
                                                </Items>
                                                <Toolbars>
                                                    <f:Toolbar ID="Toolbar23" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                        <Items>
                                                            <f:Button ID="JTF_add" Text="添加到交通费列表" ValidateForms="JTF_Form" ValidateMessageBox="false"
                                                                runat="server" OnClick="JTF_add_Click">
                                                            </f:Button>
                                                        </Items>
                                                    </f:Toolbar>
                                                </Toolbars>
                                            </f:Form>
                                            <f:Panel ID="Panel33" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的交通费列表"
                                                ShowBorder="false" ShowHeader="true" Margin="0 0 0 0">
                                                <Items>
                                                    <f:Grid ID="JTF_List_Grid" Title="交通费列表" ShowBorder="true" BoxFlex="1" ShowHeader="false"
                                                        runat="server" DataKeyNames="UID" EnableCheckBoxSelect="true" EnableMultiSelect="false">
                                                        <Toolbars>
                                                            <f:Toolbar ID="Toolbar24" runat="server">
                                                                <Items>
                                                                    <f:ToolbarSeparator ID="ToolbarSeparator9" runat="server">
                                                                    </f:ToolbarSeparator>
                                                                    <f:Button ID="JTF_delete" Text="删除" runat="server" ConfirmText="确定删除？" OnClick="JTF_delete_Click">
                                                                    </f:Button>
                                                                </Items>
                                                            </f:Toolbar>
                                                        </Toolbars>
                                                        <Columns>
                                                            <f:BoundField Width="150px" DataField="JTF_JD" HeaderText="季度" DataToolTipField="JTF_JD" />
                                                            <f:BoundField Width="300px" DataField="JTF_XMMC" HeaderText="项目名称" DataToolTipField="JTF_XMMC" />
                                                            <f:BoundField Width="150px" DataField="JTF_YSJF" DataToolTipField="JTF_YSJF" HeaderText="预算经费(单位：万元)" />
                                                            <f:BoundField Width="300px" DataField="JTF_BZ" DataToolTipField="JTF_BZ" HeaderText="备注" />
                                                        </Columns>
                                                    </f:Grid>
                                                </Items>
                                            </f:Panel>--%>
                                                    <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" EnableCollapse="true"
                                                        ShowBorder="True" Title="&nbsp;" ShowHeader="false">
                                                        <Items>
                                                            <f:FileUpload runat="server" ID="FileUpload1" EmptyText="请选择上传附件" Label="附件 项目预算明细"
                                                                 ShowRedStar="true">
                                                            </f:FileUpload>
                                                            <f:HyperLink ID="HyperLink1" Text="下载  附件项目预算明细模板" Target="_blank" NavigateUrl="WordMaster/附件 项目预算明细(师资培训).docx"
                                                                runat="server">
                                                            </f:HyperLink>
                                                            <f:Button ID="btnSubmit" runat="server" OnClick="btnUpload_Click" ValidateForms="SimpleForm1"
                                                                Text="上传">
                                                            </f:Button>
                                                        </Items>
                                                    </f:SimpleForm>
                                               
                                        </Items>
                                        <Toolbars>
                                            <f:Toolbar ID="Toolbar13" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                <Items>
                                                    <f:Button ID="Back_step6" Text="上一步" runat="server" Margin="10 10 10 0" OnClick="Back_step6_Click">
                                                    </f:Button>
                                                    <f:Button ID="Button13" Text="确认申报" ValidateForms="SimpleForm_step2,SimpleForm_step3,SimpleForm_step4,SimpleForm_step5,SimpleForm_step9"
                                                        ValidateMessageBox="true" runat="server" OnClick="SMSB_add_Click" Margin="10 100 10 10">
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
    </form>
    <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
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
