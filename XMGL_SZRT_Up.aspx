<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_SZRT_Up.aspx.cs" Inherits="XMGL.Web.admin.XMGL_SZRT_Up" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../res/jqueryuiautocomplete/theme-start/theme.css" />
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/layout3.css" />
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
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="Button_step1,Button_step2,Button_step3,Button_step4,Button_step5,Button_step6,Button_step7,Button_step8" />

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
                                            <h4>项目团队人员信息</h4>
                                        </div>
                                    </li>
                                    <li id="li3">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step3" runat="server" Text="3" CssClass="icon_step" OnClick="Button_step3_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <%-- <span class="icon_step">3</span>--%>
                                            <h4>所选证书信息</h4>
                                        </div>
                                    </li>
                                    <li id="li4">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step4" runat="server" Text="4" CssClass="icon_step" OnClick="Button_step4_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>融通课程设置</h4>
                                        </div>
                                    </li>
                                    <li id="li5">
                                        <div class="step_inner">

                                            <asp:Button ID="Button_step5" runat="server" Text="5" CssClass="icon_step" OnClick="Button_step5_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>专业教师信息</h4>
                                        </div>
                                    </li>
                                    <li id="li6">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step6" runat="server" Text="6" CssClass="icon_step" OnClick="Button_step6_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>实训考核条件</h4>
                                        </div>
                                    </li>
                                    <li id="li7">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step7" runat="server" Text="7" CssClass="icon_step" OnClick="Button_step7_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>报项目验收指标</h4>
                                        </div>
                                    </li>
                                    <li id="li8">
                                        <div class="step_inner">
                                            <asp:Button ID="Button_step8" runat="server" Text="8" CssClass="icon_step" OnClick="Button_step8_Click" BorderStyle="None" UseSubmitBehavior="false" />
                                            <h4>经费预算</h4>
                                        </div>
                                    </li>
                                    <li id="li9">
                                        <div class="step_inner fr">
                                            <asp:Button ID="Button_step9" runat="server" BorderStyle="None" CssClass="icon_step" OnClick="Button_step9_Click" Text="9" UseSubmitBehavior="False" />
                                            <h4>附件管理</h4>
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
                                <%--</div><!-- // step1 end -->--%>
                                <%--  <f:ContentPanel ID="ContentPanel1" runat="server">--%>
                                <%--<div id="s2"  runat="server" >--%>
                                <%--    <div id="login-buttom">
       <input type="submit" value="保存数据" class="ui-button" id="J-login-btn" tabindex="4" />
      </div>--%>

                                <f:SimpleForm ID="SimpleForm_step2" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>

                                        <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                            <Items>
                                                <%-- <f:Form runat="server"  Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false">
                            <Items>--%>
                                                <%-- <f:FormRow runat="server" ID="fr1">
                           <Items>--%>

                                                <f:TextBox ID="TextBox_xmmc" Label="申报项目名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" runat="server" ColumnWidth="100%">
                                                </f:TextBox>
                                                <f:TextBox ID="TextBox_DWMC1" Label="单位名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" runat="server" ColumnWidth="100%">
                                                </f:TextBox>

                                                <%--  <f:TextBox ID="TextBox1" Label="申报项目名称1" Margin="0 0 2 0" Required="true" ShowRedStar="true" runat="server" ColumnWidth="50%">
                                </f:TextBox>--%>

                                                <%-- </Items>
                          </f:FormRow>--%>
                                            </Items>
                                        </f:Panel>
                                        <%--  </Items>
                            </f:Form>--%>
                                        <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="<strong>项目团队人员信息</strong>" runat="server">

                                            <Items>
                                                <f:Panel ID="Panel3_XM" Layout="Column" CssClass="formitem" ShowBorder="false" runat="server" Title="项目负责人">
                                                    <Items>
                                                        <f:Panel ID="Panel4_XM" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label13_XM" runat="server" ShowRedStar="True" Text="姓名：">
                                                                </f:Label>
                                                                <f:TextBox ID="XM1" runat="server" Label="姓名" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel5_XM" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label14_XM" runat="server" Text="部门：">
                                                                </f:Label>
                                                                <f:TextBox ID="BM1" runat="server" Label="部门" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                                <f:HiddenField ID="HiddenField1_XM" runat="server">
                                                                </f:HiddenField>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel6" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label20" runat="server" Text="专业技术职务：">
                                                                </f:Label>
                                                                <f:TextBox ID="ZYJSZW1" runat="server" Label="专业技术职务" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                                <f:HiddenField ID="HiddenField7" runat="server">
                                                                </f:HiddenField>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel69" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label21" runat="server" Text="行政职务：">
                                                                </f:Label>
                                                                <f:TextBox ID="XZZW1" runat="server" Label="行政职务" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                                <f:HiddenField ID="HiddenField8" runat="server">
                                                                </f:HiddenField>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel70" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label22" runat="server" Text="办公室电话：">
                                                                </f:Label>
                                                                <f:TextBox ID="BGSDH1" runat="server" Label="办公室电话" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                                <f:HiddenField ID="HiddenField9" runat="server">
                                                                </f:HiddenField>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel71" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label23" runat="server" Text="传    真：">
                                                                </f:Label>
                                                                <f:TextBox ID="CZ1" runat="server" Label="传    真" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                                <f:HiddenField ID="HiddenField10" runat="server">
                                                                </f:HiddenField>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel72" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label24" runat="server" Text="手     机：">
                                                                </f:Label>
                                                                <f:TextBox ID="SJ1" runat="server" Label="手     机" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                                <f:HiddenField ID="HiddenField11" runat="server">
                                                                </f:HiddenField>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel73" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label25" runat="server" Text="电子邮箱：">
                                                                </f:Label>
                                                                <f:TextBox ID="DZYX1" runat="server" Label="电子邮箱" Required="True" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                                <f:HiddenField ID="HiddenField12" runat="server">
                                                                </f:HiddenField>
                                                            </Items>
                                                        </f:Panel>
                                                    </Items>
                                                </f:Panel>


                                                <f:Panel runat="server" ShowBorder="False" Layout="Column" CssClass="formitem" ID="Panel3_XM0" Title="项目成员">
                                                    <Items>
                                                        <f:Panel runat="server" ShowHeader="False" ShowBorder="False" ColumnWidth="25%" Margin="5 5 2 10" ID="Panel4_XM0">
                                                            <Items>
                                                                <f:Label runat="server" Text="项目成员姓名：" ShowRedStar="True" ID="Label13_XM0"></f:Label>
                                                                <f:TextBox runat="server" Required="False" ShowLabel="False" Label="姓名" ShowRedStar="True" Width="200px" ID="XM2"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel runat="server" ShowHeader="False" ShowBorder="False" ColumnWidth="25%" Margin="5 5 2 10" ID="Panel5_XM0">
                                                            <Items>
                                                                <f:Label runat="server" Text="部门及职务：" ID="Label14_XM0"></f:Label>
                                                                <f:TextBox ID="BM2" runat="server" Label="部门及职务" Required="False" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel runat="server" ShowHeader="False" ShowBorder="False" ColumnWidth="25%" Margin="5 5 2 10" ID="Panel75">
                                                            <Items>
                                                                <f:Label runat="server" Text="任务分工：" ID="Label27"></f:Label>
                                                                <f:TextBox runat="server" ShowLabel="False" Label="任务分工" ID="RWFG2" Required="False" ShowRedStar="True" Width="200px"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel76" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label28" runat="server" Text="手机：">
                                                                </f:Label>
                                                                <f:TextBox ID="SJ2" runat="server" Label="手机" Required="False" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel77" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label29" runat="server" Text="电子邮箱：">
                                                                </f:Label>
                                                                <f:TextBox ID="DZYX2" runat="server" Label="电子邮箱" Required="False" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                    </Items>

                                                </f:Panel>

                                                <f:Toolbar ID="Toolbar6" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                    <Items>
                                                        <f:Button ID="Button1" Text="确定" ValidateForms="Form4" ValidateMessageBox="false" runat="server" OnClick="Button1_Click">
                                                        </f:Button>
                                                    </Items>
                                                </f:Toolbar>



                                                <f:Panel runat="server" ShowBorder="False" Layout="Fit" CssClass="formitem" ID="Panel78" RowHeight="300px" Title="已添加的项目成员列表">
                                                    <Items>
                                                        <f:Grid ID="Grid4" runat="server" BoxFlex="1" DataKeyNames="id" EnableCheckBoxSelect="True" EnableMultiSelect="False" EnableRowLines="True" ShowHeader="False" Title="Grid1">
                                                            <Columns>
                                                                <f:BoundField ID="BoundField1" runat="server" ColumnID="Panel7_Grid4_ctl091" DataField="CYXM" HeaderText="项目成员姓名" Width="100px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField2" runat="server" ColumnID="Panel7_Grid4_ctl101" DataField="BMZW" HeaderText="部门及职务" Width="150px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField3" runat="server" ColumnID="Panel7_Grid4_ctl131" DataField="RWFG" HeaderText="任务分工" Width="150px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField4" runat="server" ColumnID="Panel7_Grid4_ctl141" DataField="SJ" HeaderText="手机" Width="150px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField5" runat="server" ColumnID="Panel7_Grid4_ctl151" DataField="DZYX" HeaderText="电子邮箱" Width="150px">
                                                                </f:BoundField>
                                                            </Columns>
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar14" runat="server">
                                                                    <Items>
                                                                        <f:ToolbarSeparator ID="ToolbarSeparator8" runat="server">
                                                                        </f:ToolbarSeparator>
                                                                        <f:Button ID="Button14" runat="server" ConfirmText="确定删除？" OnClick="Button14_Click" Text="删除">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                        </f:Grid>
                                                    </Items>
                                                </f:Panel>

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
                                        <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="&lt;strong&gt;所选证书信息&lt;/strong&gt;" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:TextBox ID="ZSMC1" Label="证书名称" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 2 0">
                                                        </f:TextBox>
                                                        <f:TextBox ID="ZSDJ1" Label="证书等级" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 2 0">
                                                        </f:TextBox>
                                                        <f:TextBox ID="BFBM1" Label="颁发部门" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 2 0">
                                                        </f:TextBox>
                                                        <f:TextBox ID="KZSJ1" Label="考证时间" Required="true" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 2 0" EmptyText="考证时间（如2015年1月）">
                                                        </f:TextBox>
                                                        <f:NumberBox ID="MNKKCS1" runat="server" Label="每年可考次数" MinValue="0" DecimalPrecision="0" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="10 5 10 0" Readonly="false" Text="0"></f:NumberBox>
                                                        <f:TextArea ID="XZZSYY1" runat="server" Height="200px" Label="选择该证书的原因说明" Text="" ColumnWidth="80%" Margin="10 5 10 0" EmptyText="请简要说明选择该证书的原因。（不超过500字）。" Required="true" ShowRedStar="true" MaxLength="800"></f:TextArea>

                                                    </Items>
                                                </f:Panel>
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
                                        <f:GroupPanel ID="GroupPanel11" Layout="Anchor" Title="<strong>融通课程设置（至少填报3门课程）</strong>" runat="server">
                                            <Items>
                                                <f:TextBox ID="KCMC1" Label="课程名称" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:TextBox ID="KCZYNR1" Label="课程主要内容" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:TextBox ID="KCDYZS1" Label="课程对应的证书能力模块" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:TextBox ID="KHFS1" Label="考核方式" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:Button runat="server" Text="确定" ID="Button121" OnClick="Button121_Click"></f:Button>
                                                <f:Panel runat="server" Title="已添加融通课程列表" ShowBorder="False" Layout="Fit" RowHeight="300px" CssClass="formitem" ID="Panel3">
                                                    <Items>
                                                        <f:Grid runat="server" EnableRowLines="True" EnableCheckBoxSelect="True" EnableMultiSelect="False" DataKeyNames="id" Title="Grid1" ShowHeader="False" BoxFlex="1" ID="Grid1">
                                                          <Columns>
                                                                <f:BoundField runat="server" DataField="RTKC_MC" ColumnID="Panel7_Grid1_ctl091" HeaderText="课程名称" Width="100px" ID="BoundField6"></f:BoundField>
                                                                <f:BoundField runat="server" DataField="RTKC_NR" ColumnID="Panel7_Grid1_ctl101" HeaderText="课程主要内容" Width="150px" ID="BoundField7"></f:BoundField>
                                                                <f:BoundField runat="server" DataField="RTKC_KCDYZS" ColumnID="Panel7_Grid1_ctl131" HeaderText="课程对应的证书能力模块" Width="200px" ID="BoundField8"></f:BoundField>
                                                                <f:BoundField runat="server" DataField="RTKC_KHFS" ColumnID="Panel7_Grid1_ctl141" HeaderText="考核方式" Width="150px" ID="BoundField9"></f:BoundField>
                                                            </Columns>
                                                            <Toolbars>
                                                                <f:Toolbar runat="server" ID="Toolbar2">
                                                                    <Items>
                                                                        <f:ToolbarSeparator runat="server" ID="ToolbarSeparator1"></f:ToolbarSeparator>
                                                                        <f:Button runat="server" Text="删除" ConfirmText="确定删除？" ID="Button2" OnClick="Button2_Click"></f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                        </f:Grid>
                                                    </Items>
                                                </f:Panel>
                                            </Items>




                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar9" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button9" Text="下一步" ValidateForms="SimpleForm_step4" ValidateMessageBox="true" runat="server" OnClick="Button_step5_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>

                                <f:SimpleForm ID="SimpleForm_step5" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel6" Layout="Anchor" Title="<strong>专业教师信息</strong>" runat="server">
                                            <Items>
                                                <f:TextBox ID="XM3" Label="姓名" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:TextBox ID="ZC3" Label="职称" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:TextBox ID="ZJKC3" Label="主讲课程" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:TextBox ID="ZYZG3" Label="职业资格证书" Required="False" ShowRedStar="true" ColumnWidth="25%" runat="server" Readonly="false" Margin="0 5 5 2">
                                                </f:TextBox>
                                                <f:DropDownList ID="ZJZ3" runat="server" Label="专/兼职" Required="False" ShowRedStar="true" ColumnWidth="25%" Margin="0 5 2 0"></f:DropDownList>
                                                <f:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="确定">
                                                </f:Button>
                                                <f:Panel runat="server" ShowBorder="False" Layout="Fit" CssClass="formitem" ID="Panel4" RowHeight="300px" Title="已添加专业教师信息列表">
                                                    <Items>
                                                        <f:Grid ID="Grid2" runat="server" BoxFlex="1" DataKeyNames="id" EnableCheckBoxSelect="True" EnableMultiSelect="False" EnableRowLines="True" ShowHeader="False" Title="Grid1">
                                                            <Columns>
                                                                <f:BoundField ID="BoundField10" runat="server" ColumnID="Panel7_Grid2_ctl091" DataField="XM" HeaderText="姓名" Width="100px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField11" runat="server" ColumnID="Panel7_Grid2_ctl101" DataField="ZC" HeaderText="职称" Width="150px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField12" runat="server" ColumnID="Panel7_Grid2_ctl131" DataField="ZJKC" HeaderText="主讲课程" Width="180px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField13" runat="server" ColumnID="Panel7_Grid2_ctl141" DataField="ZYZGZS" HeaderText="职业资格证书" Width="260px">
                                                                </f:BoundField>
                                                                <f:BoundField ID="BoundField14" runat="server" ColumnID="Panel7_Grid2_ctl142" DataField="ZJZ" HeaderText="专/兼职" Width="100px">
                                                                </f:BoundField>
                                                            </Columns>
                                                            <Toolbars>
                                                                <f:Toolbar ID="Toolbar5" runat="server">
                                                                    <Items>
                                                                        <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                                                        </f:ToolbarSeparator>
                                                                        <f:Button ID="Button5" runat="server" ConfirmText="确定删除？" OnClick="Button5_Click" Text="删除">
                                                                        </f:Button>
                                                                    </Items>
                                                                </f:Toolbar>
                                                            </Toolbars>
                                                        </f:Grid>
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
                                        <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="<strong>实训考核条件</strong>" runat="server">
                                            <Items>
                                                <f:TextArea ID="SXKHTJ1" runat="server" Height="200px" Label="选择理由" Text="" ColumnWidth="80%" Margin="10 5 10 0" EmptyText="请说明本专业融通证书考证所需的场地、仪器设备等情况，以及现有条件。（不超过500字）" Required="true" ShowRedStar="true" MaxLength="800"></f:TextArea>

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
                                        <f:GroupPanel ID="GroupPanel8" Layout="Anchor" Title="<strong>申报项目验收指标</strong>" runat="server">
                                            <Items>
                                                <f:Form runat="server" Title="添加项目验收指标" ID="Form5" Margin="0 0 10 0">
                                                    <Items>
                                                        <f:Panel ID="Panel30" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:TextArea ID="jsmb1" runat="server" Height="100px" Label="建设目标" Text="" ColumnWidth="80%" Margin="10 5 10 5" Required="False" ShowRedStar="True"></f:TextArea>
                                                            </Items>

                                                        </f:Panel>
                                                        <f:Panel ID="Panel31" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:DatePicker runat="server" Required="False" EnableEdit="false" Label="计划验收日期" EmptyText="请选择日期" ID="jhysrq1" ShowRedStar="True" ColumnWidth="80%" Margin="0 5 10 5"></f:DatePicker>
                                                            </Items>

                                                        </f:Panel>
                                                        <f:Panel ID="Panel32" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                            <Items>
                                                                <f:TextArea ID="ysyd1" runat="server" Height="200px" Label="验收要点" Text="" ColumnWidth="80%" Margin="0 5 10 5" Required="False" ShowRedStar="True"></f:TextArea>
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
                                                <f:Panel ID="Panel21" Layout="Fit" CssClass="formitem" runat="server" Title="已添加的项目验收指标列表" ShowBorder="false" ShowHeader="true" Margin="0 5 10 0">
                                                    <Items>
                                                        <f:Grid ID="Grid3" Title="Grid1" ShowBorder="true" BoxFlex="1"
                                                            ShowHeader="false" runat="server" DataKeyNames="id" EnableCheckBoxSelect="true" EnableMultiSelect="false">
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

                                                                <f:BoundField Width="200px" DataField="JSMB" HeaderText="建设目标" DataToolTipField="JSMB" ColumnID="Panel7_Grid3_ctl092" />

                                                                <f:BoundField Width="120px" DataField="JHYSRQ" HeaderText="计划验收日期" DataToolTipField="JHYSRQ" ColumnID="Panel7_Grid3_ctl102" />
                                                                <f:BoundField Width="230px" DataField="YSYD" DataToolTipField="YSYD" HeaderText="验收要点" ColumnID="Panel7_Grid3_ctl112" />

                                                            </Columns>
                                                        </f:Grid>
                                                    </Items>

                                                </f:Panel>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar12" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button12" Text="下一步" ValidateForms="SimpleForm_step7" ValidateMessageBox="true" runat="server" OnClick="Button_step8_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>

                                <f:SimpleForm ID="SimpleForm_step8" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel10" Layout="Anchor" Title="<strong>经费预算</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel41" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:NumberBox ID="SQZXJF1" runat="server" Label="申请专项经费(万元)" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="true" Text="0" Enabled="False"></f:NumberBox>
                                                        <f:HiddenField ID="Hidden1" runat="server">
                                                         </f:HiddenField>
                                                        <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" Label="执行开始日期" EmptyText="请选择日期" ID="ZXKSRQ1" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>
                                                        <f:DatePicker runat="server" Required="true" EnableEdit="false" DateFormatString="yyyy-MM-dd" CompareControl="DatePicker_xxptjfzxksrq" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" EmptyText="请选择日期" ID="ZXJSRQ1" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5"></f:DatePicker>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel5" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:NumberBox ID="KCJCJFJE1" runat="server" Label="课程教材经费金额" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="100%" Margin="0 5 5 0" Readonly="false" Text="0" OnTextChanged="KCJCJFJE1_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea ID="KCJCJFGSYJ1" runat="server" Height="100px" Label="课程教材经费概算依据" Text="" ColumnWidth="50%" Margin="10 5 10 0" Required="true" ShowRedStar="true"></f:TextArea>
                                                        <f:TextArea ID="KCJCJFBZ1" runat="server" Height="100px" Label="课程教材经费备注" Text="" ColumnWidth="50%" Margin="10 5 10 0" ></f:TextArea>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:NumberBox ID="YQSBJE1" runat="server" Label="仪器设备经费金额" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="100%" Margin="0 5 5 0" Readonly="false" Text="0" OnTextChanged="YQSBJE1_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea ID="YQSBJFGSYJ1" runat="server" Height="100px" Label="仪器设备经费概算依据" Text="" ColumnWidth="50%" Margin="10 5 10 0" Required="true" ShowRedStar="true"></f:TextArea>
                                                        <f:TextArea ID="YQSBJFBZ1" runat="server" Height="100px" Label="仪器设备经费备注" Text="" ColumnWidth="50%" Margin="10 5 10 0" ></f:TextArea>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:NumberBox ID="WPRYFYJE1" runat="server" Label="外聘人员费用金额" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="100%" Margin="0 5 5 0" Readonly="false" Text="0" OnTextChanged="WPRYFYJE1_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea ID="WPRYJFGSYJ1" runat="server" Height="100px" Label="外聘人员费用概算依据" Text="" ColumnWidth="50%" Margin="10 5 10 0" Required="true" ShowRedStar="true"></f:TextArea>
                                                        <f:TextArea ID="WPRYFYBZ1" runat="server" Height="100px" Label="外聘人员费用备注" Text="" ColumnWidth="50%" Margin="10 5 10 0"></f:TextArea>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:NumberBox ID="YWFJE1" runat="server" Label="业务费（包括差旅、印刷、交通等）金额" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="100%" Margin="0 5 5 0" Readonly="false" Text="0" OnTextChanged="YWFJE1_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea ID="YWFGSYJ1" runat="server" Height="100px" Label="业务费（包括差旅、印刷、交通等）概算依据" Text="" ColumnWidth="50%" Margin="10 5 10 0" Required="true" ShowRedStar="true"></f:TextArea>
                                                        <f:TextArea ID="YWFBZ1" runat="server" Height="100px" Label="业务费（包括差旅、印刷、交通等）备注" Text="" ColumnWidth="50%" Margin="10 5 10 0" ></f:TextArea>

                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:NumberBox ID="JFHJ1" runat="server" Label="经费概算合计" MinValue="0" DecimalPrecision="2" NoNegative="True" Required="true" ShowRedStar="True" ColumnWidth="100%" Margin="0 5 5 0" EmptyText="系统自动汇总" Readonly="false"  Enabled="False" Text="0"></f:NumberBox>
                                                        <f:HiddenField ID="Hidden2" runat="server">
                                                         </f:HiddenField>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel runat="server" ShowHeader="False" ShowBorder="False" Layout="Column" CssClass="formitem" ID="Panel12">
                                                    <Items>
                                                        <f:NumberBox runat="server" NoNegative="True" MinValue="0" EmptyText="系统自动汇总" Text="0" Required="True" Label="学校配套经费(万元)" ShowRedStar="True" Readonly="false" ColumnWidth="30%" Margin="0 5 5 0"  Enabled="False" ID="SQZXJF2"></f:NumberBox>
                                                         <f:HiddenField ID="Hidden3" runat="server">
                                                         </f:HiddenField>
                                                        <f:DatePicker runat="server" EnableEdit="False" EmptyText="请选择日期" Required="True" Label="执行开始日期" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5" ID="ZXKSRQ2"></f:DatePicker>
                                                        <f:DatePicker runat="server" EnableEdit="False" EmptyText="请选择日期" Required="True" CompareControl="DatePicker_xxptjfzxksrq" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="执行结束日期" ShowRedStar="True" ColumnWidth="30%" Margin="0 5 5 5" ID="ZXJSRQ2"></f:DatePicker>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel runat="server" ShowHeader="False" ShowBorder="False" Layout="Column" CssClass="formitem" ID="Panel13">
                                                    <Items>
                                                        <f:NumberBox runat="server" NoNegative="True" MinValue="0" Text="0" Required="True" Label="课程教材经费金额" ShowRedStar="True" Readonly="false" ColumnWidth="100%" Margin="0 5 5 0" ID="KCJCJFJE2" OnTextChanged="KCJCJFJE2_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea runat="server" Required="True" Label="课程教材经费概算依据" ShowRedStar="True" Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="KCJCJFGSYJ2"></f:TextArea>
                                                        <f:TextArea runat="server"  Label="课程教材经费备注"  Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="KCJCJFBZ2"></f:TextArea>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel runat="server" ShowHeader="False" ShowBorder="False" Layout="Column" CssClass="formitem" ID="Panel14">
                                                    <Items>
                                                        <f:NumberBox runat="server" NoNegative="True" MinValue="0" Text="0" Required="True" Label="仪器设备经费金额" ShowRedStar="True" Readonly="false" ColumnWidth="100%" Margin="0 5 5 0" ID="YQSBJE2" OnTextChanged="YQSBJE2_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea runat="server" Required="True" Label="仪器设备经费概算依据" ShowRedStar="True" Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="YQSBJFGSYJ2"></f:TextArea>
                                                        <f:TextArea runat="server"  Label="仪器设备经费备注"  Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="YQSBJFBZ2"></f:TextArea>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel runat="server" ShowHeader="False" ShowBorder="False" Layout="Column" CssClass="formitem" ID="Panel15">
                                                    <Items>
                                                        <f:NumberBox runat="server" NoNegative="True" MinValue="0" Text="0" Required="True" Label="外聘人员费用金额" ShowRedStar="True" Readonly="false" ColumnWidth="100%" Margin="0 5 5 0" ID="WPRYFYJE2" OnTextChanged="WPRYFYJE2_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea runat="server" Required="True" Label="外聘人员费用概算依据" ShowRedStar="True" Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="WPRYJFGSYJ2"></f:TextArea>
                                                        <f:TextArea runat="server"  Label="外聘人员费用备注"  Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="WPRYFYBZ2"></f:TextArea>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel runat="server" ShowHeader="False" ShowBorder="False" Layout="Column" CssClass="formitem" ID="Panel16">
                                                    <Items>
                                                        <f:NumberBox runat="server" NoNegative="True" MinValue="0" Text="0" Required="True" Label="业务费（包括差旅、印刷、交通等）金额" ShowRedStar="True" Readonly="false" ColumnWidth="100%" Margin="0 5 5 0" ID="YWFJE2" OnTextChanged="YWFJE2_TextChanged" AutoPostBack="True"></f:NumberBox>
                                                        <f:TextArea runat="server" Required="True" Label="业务费（包括差旅、印刷、交通等）概算依据" ShowRedStar="True" Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="YWFGSYJ2"></f:TextArea>
                                                        <f:TextArea runat="server"  Label="业务费（包括差旅、印刷、交通等）备注"  Height="100px" ColumnWidth="50%" Margin="10 5 10 0" ID="YWFBZ2"></f:TextArea>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel runat="server" ShowHeader="False" ShowBorder="False" Layout="Column" CssClass="formitem" ID="Panel17">
                                                    <Items>
                                                        <f:HiddenField ID="Hidden4" runat="server">
                                                         </f:HiddenField>
                                                        <f:NumberBox runat="server" NoNegative="True" MinValue="0" EmptyText="系统自动汇总" Text="0" Required="True" Label="经费概算合计" ShowRedStar="True" Readonly="false" ColumnWidth="100%" Margin="0 5 5 0"  Enabled="False" ID="JFHJ2"></f:NumberBox>
                                                    </Items>
                                                </f:Panel>
                                            </Items>

                                        </f:GroupPanel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar13" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button16" Text="下一步" ValidateForms="SimpleForm_step8" ValidateMessageBox="true" runat="server" OnClick="Button_step9_Click" Margin="10 5 10 0">
                                                </f:Button>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <f:SimpleForm ID="SimpleForm_step9" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:Panel ID="Panel56" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                            <Items>
                                                <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                    ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                    <Items>

                                                        <f:FileUpload runat="server" ID="FileUpload1" EmptyText="请选择上传附件一" Label="“双证融通”培养模式人才改革方案" Required="false"
                                                            ShowRedStar="true">
                                                        </f:FileUpload>
                                                        <f:HyperLink ID="HyperLink1" Text="下载“双证融通”培养模式人才改革方案模板" Target="_blank" NavigateUrl="WordMaster/SZRT/附件一“双证融通”培养模式人才改革方案.doc" runat="server">
                                                        </f:HyperLink>
                                                        <f:Button ID="btnSubmit1" runat="server" OnClick="btnSubmit1_Click" ValidateForms="SimpleForm1"
                                                            Text="上传">
                                                        </f:Button>
                                                    </Items>
                                                </f:SimpleForm>
                                            </Items>
                                        </f:Panel>

                                        <f:Panel ID="Panel57" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                            <Items>
                                                <f:SimpleForm ID="SimpleForm2" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                    ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                    <Items>

                                                        <f:FileUpload runat="server" ID="FileUpload2" EmptyText="请选择上传附件二" Label="本专业现行人才培养方案" Required="false"
                                                            ShowRedStar="true">
                                                        </f:FileUpload>
                                                        <f:HyperLink ID="HyperLink2" Text="下载优秀学生案例模板" Target="_blank" NavigateUrl="WordMaster/SZRT/附件二本专业现行人才培养方案.doc" runat="server">
                                                        </f:HyperLink>
                                                        <f:Button ID="btnSubmit2" runat="server" OnClick="btnSubmit2_Click" ValidateForms="SimpleForm2"
                                                            Text="上传">
                                                        </f:Button>
                                                    </Items>
                                                </f:SimpleForm>
                                            </Items>
                                        </f:Panel>

                                        <f:Panel ID="Panel62" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                            <Items>
                                                <f:SimpleForm ID="SimpleForm3" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                    ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                    <Items>

                                                        <f:FileUpload runat="server" ID="FileUpload3" EmptyText="请选择上传附件三" Label="项目预算明细表" Required="false"
                                                            ShowRedStar="true">
                                                        </f:FileUpload>
                                                        <f:HyperLink ID="HyperLink3" Text="下载项目预算明细表模板" Target="_blank" NavigateUrl="WordMaster/SZRT/附件三 项目预算明细表.doc" runat="server">
                                                        </f:HyperLink>
                                                        <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">
                                                        </f:Button>
                                                    </Items>
                                                </f:SimpleForm>
                                            </Items>
                                        </f:Panel>
                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar15" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <f:Button ID="Button8" Text="保存" ValidateForms="SimpleForm_step2,SimpleForm_step3,SimpleForm_step4,SimpleForm_step5,SimpleForm_step6,SimpleForm_step7,SimpleForm_step8,SimpleForm_step9" ValidateMessageBox="true" runat="server" OnClick="Button4_Click" Margin="10 5 10 0">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>
                                <%--</div><!-- // step2 end -->--%>
                                <%--<div id="s3"  runat="server">
                3
				</div><!-- // step3 end -->
				<div id="s4"  runat="server">
                4
				</div><!-- // step4 end -->
				<div id="s5"  runat="server">
                5
				</div><!-- // step5 end -->
				<div id="s6"  runat="server">
                6
				</div><!-- // step6 end -->
				<div id="s7"  runat="server">
                7
				</div><!-- // step7 end -->
				<div id="s8"  runat="server">
                8
				</div><!-- // step8 end -->--%>
                            </div>
                        </div>
                    </div>
                    <!-- // container end -->
                </f:ContentPanel>
                <%--  <f:SimpleForm  ID="Form2"  BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server">
                    <Items>
                        
                       
                         
                       

                       

                     
                      
                    </Items>
                      <Toolbars>
                <f:Toolbar ID="Toolbar4" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button4" Text="保存数据" ValidateForms="Form2" ValidateMessageBox="true" runat="server" OnClick="Button4_Click"  Margin="10 5 10 0">
                        </f:Button>
                      
                    </Items>
                </f:Toolbar>
            </Toolbars>
                </f:SimpleForm>--%>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="导出结果" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="600px" Height="450px">
        </f:Window>
    </form>

    <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
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
    </script>
</body>
</html>

