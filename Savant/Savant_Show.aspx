<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Savant_Show.aspx.cs" Inherits="XMGL.Web.admin.Savant.Savant_Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Form ID="Form2" Width="650px" LabelAlign="Right" MessageTarget="Qtip"
            BodyPadding="1px" ShowBorder="false" ShowHeader="false" runat="server" AutoScroll="true">
            <Items>
                <f:GroupPanel Layout="Anchor" Title="专家基本信息" runat="server">
                    <Items>
                        <f:Panel ID="SavantType" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_ZJLX" Label="专家类型" CssClass="marginr" Enabled="false" BoxFlex="1" runat="server">
                                </f:TextBox>
                                <f:TextBox ID="Experts_ZJLY" Label="专家来源" CssClass="marginr" Enabled="false" BoxFlex="1" runat="server">
                                </f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel1" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_Name" Label="姓名" CssClass="marginr" Enabled="false" BoxFlex="1" runat="server"></f:TextBox>
                                <f:TextBox ID="Experts_Sex" Label="性别" CssClass="marginr" Enabled="false" BoxFlex="1" runat="server"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel2" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_Birthday" Label="出生日期" CssClass="marginr" Enabled="false" BoxFlex="1" runat="server"></f:TextBox>
                                <f:TextBox ID="Experts_Nation" Label="民族" CssClass="marginr" Enabled="false" BoxFlex="1" runat="server"></f:TextBox>
                            </Items>
                        </f:Panel>

                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="专家联系方式" runat="server">
                    <Items>
                        <f:Panel ID="Panel3" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_Telphone" Label="固定电话" runat="server" Enabled="false" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_Mobil" Label="手机" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel4" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_CZ" Label="传真" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_Email" Label="电子邮箱" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="专家教育信息" runat="server">
                    <Items>
                        <f:Panel ID="Panel5" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_XL" Label="学历" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_XW" Label="学位" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel6" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_BYYX" Label="毕业院校" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_BYZY" Label="毕业专业" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel7" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_BYSJ" Label="毕业时间" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel3" Layout="Anchor" Title="专家工作单位" runat="server">
                    <Items>
                        <f:Panel ID="Panel8" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_SSDW" Label="所属单位" Enabled="false" runat="server" BoxFlex="3"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel9" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_SSDWDZ" Label="所属单位地址" Enabled="false" runat="server" BoxFlex="3"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel10" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_PostCode" Label="邮编" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                               <f:TextBox ID="Experts_ZYDL" Label="专业大类" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel16" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>  
                                <f:TextBox ID="Experts_ZYEJDL" Label="专业二级大类" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                                 <f:TextBox ID="Experts_GJCB" Label="关键词" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel11" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextBox ID="Experts_ZW" Label="职务" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                                <f:TextBox ID="Experts_ZC" Label="职称" Enabled="false" runat="server" BoxFlex="1"></f:TextBox>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel4" Layout="Anchor" Title="专家经历" runat="server" EnableCollapse="true" Collapsed="false">
                    <Items>
                        <f:Panel ID="Panel12" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_DBXCG" Enabled="false" Label="代表性成果"
                                    AutoGrowHeight="true" AutoGrowHeightMin="100" AutoGrowHeightMax="200" BoxFlex="1">
                                </f:TextArea>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel13" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_JYJXJL" Enabled="false" Label="教育教学经历"
                                    AutoGrowHeight="true" AutoGrowHeightMin="100" AutoGrowHeightMax="200" BoxFlex="1">
                                </f:TextArea>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel14" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_ZJJL" Enabled="false" Label="专家经历"
                                    AutoGrowHeight="true" AutoGrowHeightMin="100" AutoGrowHeightMax="200" BoxFlex="1">
                                </f:TextArea>
                            </Items>
                        </f:Panel>
                        <f:Panel ID="Panel15" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:TextArea runat="server" ID="Experts_KTJL" Enabled="false" Label="课题经历"
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
