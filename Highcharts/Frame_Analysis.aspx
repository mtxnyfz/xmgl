<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame_Analysis.aspx.cs" Inherits="XMGL.Web.Highcharts.Frame_Analysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panle1" />
        <f:Panel runat="server" ID="Panle1" Layout="Fit" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:TabStrip ID="TabStrip1" ShowBorder="true" ActiveTabIndex="0" runat="server">
                    <Tabs>
                        <f:Tab Title="来源分析" EnableIFrame="true" ID="tab1" runat="server">
                        </f:Tab>
                       <%-- <f:Tab Title="项目分析" EnableIFrame="true" ID="tab2" runat="server" >
                        </f:Tab>--%>
                        <f:Tab Title="项目分析" EnableIFrame="true" ID="tab3" runat="server" >
                        </f:Tab>
                    </Tabs>
                </f:TabStrip>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
