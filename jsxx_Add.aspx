<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jsxx_Add.aspx.cs" Inherits="XMGL.Web.admin.jsxx_Add" %>

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
            Title="添加教师基本信息" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" Height="1000px"  BoxConfigAlign="Stretch">
            <Items>
                 <f:SimpleForm  ID="Form2"  BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" Title="填写专业教师基本信息">
                    <Items>
                        
                                   
                               <f:Panel ID="Panel19" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                          <f:Panel ID="Panel3" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label  runat="server" ID="Label_jsxm" Text="教师姓名：" ShowRedStar="true" ></f:Label> <f:TextBox ID="TextBox1_jsxm" Label="教师姓名" Width="100px" Required="true" ShowRedStar="true"  runat="server"     ShowLabel="false" ></f:TextBox></Items></f:Panel>
                                                 <f:Panel ID="Panel49" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label4"  runat="server" Text="请选择出生年月："  ></f:Label><f:DatePicker runat="server" Required="true" EnableEdit="false" Label="出生年月" EmptyText="请选择出生年月"  ID="DatePicker_csny" ShowRedStar="True"   ShowLabel="false" DateFormatString="yyyy-MM"></f:DatePicker></Items></f:Panel>
                                           <%--  <f:DropDownList ID="DropDownList_zjz" runat="server" Label="专/兼职"  ColumnWidth="20%" Margin="0 5 2 10">
                                              <f:ListItem Text="请选择" Value="请选择" />
                                                 <f:ListItem Text="专职" Value="1" />
                                                 <f:ListItem Text="兼职" Value="2" />
                                           </f:DropDownList>--%>
                                            <f:Panel ID="Panel50" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label5"  runat="server" Text="专/兼职："  ></f:Label><f:ContentPanel ID="ContentPanel1" runat="server" ShowBorder="false" ShowHeader="false"  >
                                              <Items>
                                                  <asp:DropDownList ID="DropDownList_zjz" runat="server">
                                                     <asp:ListItem Text="请选择" Value="请选择" />
                                                       <asp:ListItem Text="专职" Value="1" />
                                                       <asp:ListItem Text="兼职" Value="2" />

                                                     
                                                  </asp:DropDownList>
                                              </Items>
                                          </f:ContentPanel></Items></f:Panel>
                                           <%-- <f:DropDownList ID="DropDownList_ssf" runat="server" Label="是否双师"  ColumnWidth="20%" Margin="0 5 2 10">
                                              <f:ListItem Text="请选择" Value="请选择" />
                                                 <f:ListItem Text="是" Value="1" />
                                                 <f:ListItem Text="否" Value="0" />
                                           </f:DropDownList>--%>
                                            <f:Panel ID="Panel51" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label6"  runat="server" Text="是否双师："  ></f:Label><f:ContentPanel ID="ContentPanel2" runat="server" ShowBorder="false" ShowHeader="false"   >
                                              <Items>
                                                  <asp:DropDownList  ID="DropDownList_ss" runat="server">
                                                     <asp:ListItem Text="请选择" Value="请选择" />
                                                       <asp:ListItem Text="是" Value="1" />
                                                       <asp:ListItem Text="否" Value="0" />

                                                     
                                                  </asp:DropDownList>
                                              </Items>
                                          </f:ContentPanel></Items></f:Panel>
                                            </Items>
                                   
                                      </f:Panel>
                                        <f:Panel ID="Panel20" Layout="Column" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server" >
                                       <Items>
                                          <%-- <f:DropDownList ID="DropDownList_xl" runat="server" Label="学历"  ColumnWidth="30%" Margin="0 5 2 10">
                                              <f:ListItem Text="请选择" Value="请选择" />
                                                 <f:ListItem Text="博士研究生" Value="博士研究生" />
                                                 <f:ListItem Text="硕士研究生" Value="硕士研究生" />
                                               <f:ListItem Text="大学" Value="大学" />
                                                 <f:ListItem Text="专科" Value="专科" />
                                                 <f:ListItem Text="专科以下" Value="专科以下" />
                                           </f:DropDownList>--%>
                                             <f:Panel ID="Panel52" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label7"  runat="server" Text="学历："  ></f:Label><f:ContentPanel ID="ContentPanel3" runat="server" ShowBorder="false" ShowHeader="false"   >
                                              <Items>
                                                  <asp:DropDownList  ID="DropDownList_xl1" runat="server">
                                                     <asp:ListItem Text="请选择" Value="请选择" />
                                                       <asp:ListItem Text="博士研究生" Value="博士研究生" />
                                                       <asp:ListItem Text="硕士研究生" Value="硕士研究生" />
                                                       <asp:ListItem Text="大学" Value="大学" />
                                                      <asp:ListItem Text="专科" Value="专科" />
                                                      <asp:ListItem Text="专科以下" Value="专科以下" />
                                                  </asp:DropDownList>
                                              </Items>
                                          </f:ContentPanel></Items></f:Panel>
                                          <%-- <f:DropDownList ID="DropDownList_xw" runat="server" Label="学位"  ColumnWidth="30%" Margin="0 5 2 10">
                                              <f:ListItem Text="请选择" Value="请选择" />
                                                 <f:ListItem Text="博士" Value="博士" />
                                                 <f:ListItem Text="硕士" Value="硕士" />
                                               <f:ListItem Text="学士" Value="学士" />
                                                 
                                           </f:DropDownList>--%>
                                            <f:Panel ID="Panel53" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label8"  runat="server" Text="学位："  ></f:Label><f:ContentPanel ID="ContentPanel4" runat="server" ShowBorder="false" ShowHeader="false"   >
                                              <Items>
                                                  <asp:DropDownList  ID="DropDownList_xw1" runat="server">
                                                     <asp:ListItem Text="请选择" Value="请选择" />
                                                       <asp:ListItem Text="博士" Value="博士" />
                                                      <asp:ListItem Text="硕士" Value="硕士" />
                                                       <asp:ListItem Text="学士" Value="学士" />
                                                        <asp:ListItem Text="无" Value="无" />
                                                     
                                                  </asp:DropDownList>
                                              </Items>
                                          </f:ContentPanel></Items></f:Panel>
                                            <%-- <f:DropDownList ID="DropDownList_zcdj" runat="server" Label="职称等级"  ColumnWidth="30%" Margin="0 5 2 10">
                                              <f:ListItem Text="请选择" Value="请选择" />
                                                 <f:ListItem Text="高级" Value="高级" />
                                                 <f:ListItem Text="中级" Value="中级" />
                                               <f:ListItem Text="初级" Value="初级" />
                                                  <f:ListItem Text="无等级" Value="无等级" />
                                           </f:DropDownList>--%>
                                            <f:Panel ID="Panel54" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:Label ID="Label9"  runat="server" Text="职称等级："  ></f:Label><f:ContentPanel ID="ContentPanel5" runat="server" ShowBorder="false" ShowHeader="false"   >
                                              <Items>
                                                  <asp:DropDownList  ID="DropDownList_zcdj1" runat="server">
                                                     <asp:ListItem Text="请选择" Value="请选择" />
                                                       <asp:ListItem Text="高级" Value="高级" />
                                                       <asp:ListItem Text="中级" Value="中级" />
                                                     <asp:ListItem Text="初级" Value="初级" />
                                                        <asp:ListItem Text="无" Value="无" />
                                                  </asp:DropDownList>
                                              </Items>
                                          </f:ContentPanel></Items></f:Panel>

                                            <f:Panel ID="Panel55" runat="server" Margin="5 5 2 10" ColumnWidth="25%" ShowBorder="false" ShowHeader="false"><Items><f:ContentPanel ID="ContentPanel6" runat="server" ShowBorder="false" ShowHeader="false"   >
                                              <Items>
                                                 
                                              </Items>
                                          </f:ContentPanel></Items></f:Panel>

                                            </Items>
                                   
                                      </f:Panel>
                                      
                                   
                                       </Items>
                                    <Toolbars>
                <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="Button2" Text="添加到专业教师基本信息列表" ValidateForms="Form2" ValidateMessageBox="true" runat="server" OnClick="Button2_Click">
                        </f:Button>
                       
                    </Items>
                </f:Toolbar>
            </Toolbars>
                                   
                                  
                      
                     </f:SimpleForm>
                </Items>
             </f:Panel>
    </form>
</body>
</html>
