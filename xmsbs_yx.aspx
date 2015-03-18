<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xmsbs_yx.aspx.cs" Inherits="XMGL.Web.admin.xmsbs_yx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="../css/main.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
a:link,a:visited{
 text-decoration:none;  /*超链接无下划线*/
}
a:hover{
 text-decoration:underline;  /*鼠标放上去有下划线*/
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" />
    <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <f:Region ID="Region1" ShowBorder="false" ShowHeader="false" Split="true" 
                 Width="200px" Position="Left" Layout="Fit"
                BodyPadding="5px 0 5px 5px"  runat="server">
                <Items>
                    <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="false" 
                         DataKeyNames="ID,XMSBSMBMC,XMSBSMBBMC"  AllowPaging="false" 
                        OnRowClick="Grid1_RowClick" EnableMultiSelect="false" EnableRowClickEvent="true">
                        <Columns>
                            <f:BoundField DataField="XMSBSMBMC" SortField="XMSBSMBMC" ExpandUnusedSpace="true" HeaderText="项目申报书模板" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Region>
            <f:Region ID="Region2" ShowBorder="false" ShowHeader="false" Position="Center" Layout="VBox"
                BoxConfigAlign="Stretch" BoxConfigPosition="Left" BodyPadding="5px 5px 5px 0"
                runat="server">
                <Items>
                   
                    <f:Grid ID="Grid2" DataKeyNames="ID,XXDM" runat="server"  BoxFlex="1" 
                 ShowBorder="true" ShowHeader="true"
                
               
               Title="当前申报书可以填报的院校" AllowPaging="True" OnRowCommand="Grid2_RowCommand" 
                        OnPreDataBound="Grid2_PreDataBound" OnPageIndexChange="Grid2_PageIndexChange" 
               >
                        <Toolbars>
                            <f:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                   
                                    <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                    </f:ToolbarFill>
                                    <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="true" OnClick="btnNew_Click"
                                        Text="添加院校到当前项目申报书模板">
                                    </f:Button>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>

                        <Columns>
                            <%--<f:BoundField DataField="UserId" Width="100px" HeaderText="教工号" />
                            <f:BoundField DataField="Name"  Width="100px" HeaderText="登录名" />--%>
                            <f:BoundField DataField="xxdm"  Width="100px" HeaderText="学校代码" />
                            <f:BoundField DataField="xxmc"  Width="300px" HeaderText="学校名称" />
                           

                       <%--  <f:WindowField ColumnID="xm_set" TextAlign="Center" Text="查看或设置用户可访问项目"  Title="查看或设置用户可访问项目"
                        WindowID="Window1" DataIFrameUrlFields="user_uid,RoleId" DataIFrameUrlFormatString="~/admin/Xmqx_add.aspx?UserId={0}&RoleId={1}"
                        Width="200"  />--%>
                            <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="从当前项目申报书模板中移除学校"
                                ConfirmText="确定此操作？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Region>
        </Regions>
    </f:RegionPanel>
    <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true"
        Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="700px" Height="500px" OnClose="Window1_Close">
    </f:Window>
    </form>
</body>
</html>

