<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Savant_Add.aspx.cs" Inherits="XMGL.Web.admin.Savant.Savant_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Res/css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Form ID="Form2" Width="650px" LabelAlign="Right" MessageTarget="Qtip"
            BodyPadding="1px" ShowBorder="false" ShowHeader="false" runat="server" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="Toolbar2" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveRefresh" Text="保存" runat="server" Icon="SystemSave"
                            OnClick="btnSaveRefresh_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:GroupPanel Layout="Anchor" Title="专家基本信息" runat="server">
                    <Items>
                        <f:Panel ID="SavantType" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:DropDownList runat="server" Label="专家类型" ID="Experts_ZJLX" Required="true" ShowRedStar="true" EnableEdit="true" ForceSelection="true" BoxFlex="3"></f:DropDownList>
                                <f:DropDownList runat="server" Label="专家来源" ID="Experts_ZJLY" Required="true" ShowRedStar="true" EnableEdit="true" ForceSelection="true" BoxFlex="3"></f:DropDownList>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel1" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_Name" Label="姓名" CssClass="marginr" Required="true" ShowRedStar="true" BoxFlex="2" runat="server">
                                </f:TextBox>
                                <f:RadioButtonList ID="Experts_Sex" Label="性别" runat="server" BoxFlex="1">
                                    <f:RadioItem Text="男" Value="男" />
                                    <f:RadioItem Text="女" Value="女" />
                                </f:RadioButtonList>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel2" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:DatePicker runat="server" Label="出生日期" DateFormatString="yyyyMMdd" EmptyText="请选择出生日期"
                                    ID="Experts_Birthday" BoxFlex="3">
                                </f:DatePicker>
                                <f:DropDownList runat="server" Label="民族" ID="Experts_Nation" EnableEdit="true" ForceSelection="true" BoxFlex="3"></f:DropDownList>
                            </Items>
                        </f:Panel>

                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="专家联系方式" runat="server">
                    <Items>
                        <f:Panel ID="Panel3" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_Telphone" Label="固定电话" runat="server" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_Mobil" Label="手机" Required="true" ShowRedStar="true" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel4" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_CZ" Label="传真" runat="server" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_Email" Label="电子邮箱" Required="true" ShowRedStar="true" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="专家教育信息" runat="server">
                    <Items>
                        <f:Panel ID="Panel5" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:DropDownList runat="server" Label="学历" ID="Experts_XL" EnableEdit="true" ForceSelection="true" BoxFlex="3"></f:DropDownList>
                                <f:DropDownList runat="server" Label="学位" ID="Experts_XW" EnableEdit="true" ForceSelection="true" BoxFlex="3"></f:DropDownList>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel6" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_BYYX" Label="毕业院校" runat="server" BoxFlex="1"></f:TextBox>
                                <f:DropDownList runat="server" Label="毕业专业" ID="Experts_BYZY" Required="true" ShowRedStar="true" EnableEdit="true" ForceSelection="true" BoxFlex="1"></f:DropDownList>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel7" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:DatePicker runat="server" Label="毕业时间" DateFormatString="yyyy-MM-dd" EmptyText="请选择毕业时间"
                                    ID="Experts_BYSJ">
                                </f:DatePicker>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="专家工作单位" runat="server">
                    <Items>
                        <f:Panel ID="Panel8" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_SSDW" Label="所属单位" runat="server" BoxFlex="3"></f:TextBox>

                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel9" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_SSDWDZ" Label="所属单位地址" runat="server" BoxFlex="3"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel10" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_PostCode" Label="邮编" runat="server" BoxFlex="1"></f:TextBox>
                                <f:DropDownList runat="server" Label="专业领域" ID="Experts_ZYEJDL" Required="true" ShowRedStar="true" EnableEdit="true" ForceSelection="true" BoxFlex="1"></f:DropDownList>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel16" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_GJCB" Label="关键词" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel11" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_ZW" Label="职务" runat="server" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_ZC" Label="职称" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="专家经历" runat="server" EnableCollapse="true" Collapsed="false">
                    <Items>
                        <f:Panel ID="Panel12" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_DBXCG" EmptyText="请输入代表性成果" Label="代表性成果"
                                    AutoGrowHeight="true" AutoGrowHeightMin="100" AutoGrowHeightMax="200" BoxFlex="1">
                                </f:TextArea>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel13" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_JYJXJL" EmptyText="请输入教育教学经历" Label="教育教学经历"
                                    AutoGrowHeight="true" AutoGrowHeightMin="100" AutoGrowHeightMax="200" BoxFlex="1">
                                </f:TextArea>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel14" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_ZJJL" EmptyText="请输入专家经历" Label="专家经历"
                                    AutoGrowHeight="true" AutoGrowHeightMin="100" AutoGrowHeightMax="200" BoxFlex="1">
                                </f:TextArea>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel15" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_KTJL" EmptyText="请输入课题经历" Label="课题经历"
                                    AutoGrowHeight="true" AutoGrowHeightMin="100" AutoGrowHeightMax="200" BoxFlex="1">
                                </f:TextArea>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:GroupPanel>
            </Items>
        </f:Form>

    </form>
</body>
</html>
