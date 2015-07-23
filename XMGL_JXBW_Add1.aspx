<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL_JXBW_Add1.aspx.cs" Inherits="XMGL.Web.admin.XMGL_JXBW_Add1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" AjaxAspnetControls="Button_step2,Button_step3,Button_step4,Button_step5,Button_step6,Button_step7,Button_step8" />

        <f:Panel ID="Panel1" runat="server" BodyPadding="5px"
            Title="添加项目" ShowBorder="true" ShowHeader="false"
            BoxConfigAlign="Stretch" Margin="0 10 5 0" AutoScroll="true">
            <Items>
                <f:ContentPanel ID="ContentPanel1" runat="server" BoxConfigAlign="Stretch" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                    <div id="wrapper">
                        <div class="container mt20">
                            <div class="content">


                                <f:SimpleForm ID="SimpleForm_step2" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="false">
                                    <Items>

                                        <f:Panel ID="Panel2" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                            <Items>
                                                <%-- <f:Form runat="server"  Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false">
                            <Items>--%>
                                                <%-- <f:FormRow runat="server" ID="fr1">
                           <Items>--%>

                                                <f:TextBox ID="TextBox_xmmc" Label="申报项目名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" runat="server" ColumnWidth="100%">
                                                </f:TextBox>
                                                <f:TextBox ID="TextBox_DWMC1" Label="学校名称" Margin="0 0 2 0" Required="true" ShowRedStar="true" runat="server" ColumnWidth="100%">
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
                                                                <f:TextBox runat="server" Required="false" ShowLabel="False" Label="姓名" ShowRedStar="True" Width="200px" ID="XM2"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel runat="server" ShowHeader="False" ShowBorder="False" ColumnWidth="25%" Margin="5 5 2 10" ID="Panel5_XM0">
                                                            <Items>
                                                                <f:Label runat="server" Text="部门及职务：" ID="Label14_XM0"></f:Label>
                                                                <f:TextBox ID="BM2" runat="server" Label="部门及职务" Required="false" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel76" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label28" runat="server" Text="手机：">
                                                                </f:Label>
                                                                <f:TextBox ID="SJ2" runat="server" Label="手机" Required="false" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel ID="Panel77" runat="server" ColumnWidth="25%" Margin="5 5 2 10" ShowBorder="False" ShowHeader="False">
                                                            <Items>
                                                                <f:Label ID="Label29" runat="server" Text="电子邮箱：">
                                                                </f:Label>
                                                                <f:TextBox ID="DZYX2" runat="server" Label="电子邮箱" Required="false" ShowLabel="False" ShowRedStar="True" Width="200px">
                                                                </f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                    </Items>

                                                </f:Panel>


                                                <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Right" Position="Bottom">
                                                    <Items>
                                                        <%--<f:Button ID="Button1" Text="确定" ValidateForms="Form4" ValidateMessageBox="false" runat="server" OnClick="Button1_Click">--%>
                                                        <f:Button ID="Button8" Text="确定" ValidateForms="Form4" ValidateMessageBox="false" runat="server" OnClick="Button8_Click">
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
                                                <%--<f:Button ID="Button9_s2" Text="下一步" ValidateForms="SimpleForm_step2" ValidateMessageBox="true" runat="server" OnClick="Button_step3_Click" Margin="10 5 10 0">--%>
                                                <f:Button ID="Button3" Text="下一步" ValidateMessageBox="false" runat="server" Margin="10 5 10 0" OnClick="Button_step9_Click">
                                                </f:Button>

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                </f:SimpleForm>

                                <f:SimpleForm ID="SimpleForm_step9" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Hidden="true">
                                    <Items>
                                        <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="<strong>上传1</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel56" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload1" EmptyText="请选择上传附件一" Label="说课提纲" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit1" runat="server" OnClick="btnSubmit1_Click" ValidateForms="SimpleForm1"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button4" runat="server" ValidateForms="SimpleForm1"
                                                                    Text="上传" OnClick="btnSubmit1_Click">
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

                                                                <f:FileUpload runat="server" ID="FileUpload2" EmptyText="请选择上传附件二" Label="教学计划" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--         <f:Button ID="btnSubmit2" runat="server" OnClick="btnSubmit2_Click" ValidateForms="SimpleForm2"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button5" runat="server" ValidateForms="SimpleForm2"
                                                                    Text="上传" OnClick="btnSubmit2_Click">
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

                                                                <f:FileUpload runat="server" ID="FileUpload3" EmptyText="请选择上传附件三" Label="人才培养方案" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button6" runat="server" ValidateForms="SimpleForm3"
                                                                    Text="上传" OnClick="btnSubmit3_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel3" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm4" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload4" EmptyText="请选择上传附件四" Label="其他附件" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button1" runat="server" ValidateForms="SimpleForm4"
                                                                    Text="上传" OnClick="btnSubmit4_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                            </Items>
                                        </f:GroupPanel>
                                        <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="<strong>上传2</strong>" runat="server">
                                            <Items>
                                                <f:Panel ID="Panel5" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm5" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload5" EmptyText="请选择上传视频一" Label="视频一上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button2" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit5_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel4" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm6" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload6" EmptyText="请选择上传视频二" Label="视频二上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button9" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit6_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel7" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm7" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload7" EmptyText="请选择上传视频三" Label="视频三上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button10" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit7_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel8" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm8" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload8" EmptyText="请选择上传视频四" Label="视频四上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button11" runat="server"
                                                                    Text="上传" OnClick="btnSubmit8_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel9" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm9" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload9" EmptyText="请选择上传视频五" Label="视频五上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button12" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit9_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel10" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm10" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload10" EmptyText="请选择上传视频六" Label="视频六上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button13" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit10_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel11" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm11" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload11" EmptyText="请选择上传视频七" Label="视频七上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button15" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit11_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel12" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm12" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload12" EmptyText="请选择上传视频八" Label="视频八上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button16" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit12_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel13" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm13" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload13" EmptyText="请选择上传视频九" Label="视频九上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button17" runat="server"
                                                                    Text="上传" OnClick="btnSubmit13_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel ID="Panel14" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                                    <Items>
                                                        <f:SimpleForm ID="SimpleForm14" BodyPadding="5px" runat="server" Width="550px" EnableCollapse="true"
                                                            ShowBorder="True" Title="&nbsp;" ShowHeader="True">
                                                            <Items>

                                                                <f:FileUpload runat="server" ID="FileUpload14" EmptyText="请选择上传视频十" Label="视频十上传" Required="true"
                                                                    ShowRedStar="true">
                                                                </f:FileUpload>
                                                                <%--    <f:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" ValidateForms="SimpleForm3"
                                                            Text="上传">--%>
                                                                <f:Button ID="Button18" runat="server" 
                                                                    Text="上传" OnClick="btnSubmit14_Click">
                                                                </f:Button>
                                                            </Items>
                                                        </f:SimpleForm>
                                                    </Items>
                                                </f:Panel>
                                            </Items>
                                        </f:GroupPanel>



                                    </Items>
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar15" runat="server" ToolbarAlign="Right" Position="Bottom">
                                            <Items>
                                                <%--<f:Button ID="Button8" Text="保存" ValidateForms="SimpleForm_step2,SimpleForm_step3,SimpleForm_step4,SimpleForm_step5,SimpleForm_step6,SimpleForm_step7,SimpleForm_step8,SimpleForm_step9" ValidateMessageBox="true" runat="server" OnClick="Button4_Click" Margin="10 5 10 0">--%>
                                                <f:Button ID="Button19" runat="server" Margin="10 5 10 0" OnClick="Button_step9II_Click" Text="上一步" ValidateMessageBox="False">
                                                </f:Button>
                                                <f:Button ID="Button7" Text="保存" ValidateForms="" ValidateMessageBox="false" runat="server" Margin="10 5 10 0" OnClick="Button7_Click">
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
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server"
            IsModal="true" Width="1050px" Height="550px" OnClose="Window1_Close">
        </f:Window>

        <script src="../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
        <script type="text/javascript">
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

    </form>

</body>
</html>
