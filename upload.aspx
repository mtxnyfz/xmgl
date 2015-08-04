<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="XMGL.Web.admin.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .STYLE2
        {
          text-align:center;
	
	
        }
    </style>
    <link href="js/webuploader/webuploader.css" rel="stylesheet" />
    <script src="../res/js/jquery.min.js" type="text/javascript"></script>
    <script src="js/webuploader/webuploader.js"></script>
    <script src="js/powerWebUpload1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="ContentPanel_step1" />
        <f:ContentPanel runat="server" ID="ContentPanel_step1" ShowBorder="false" ShowHeader="false">

          
            <div class="dwcn" style="margin-left:200px;margin-top:30px">
                 <table><tr><td style="vertical-align:bottom"> <select id="select_id">  
  
</select>  </td><td>&nbsp;&nbsp;
                <div id="uploader">
                </div></td>
                     </tr>
               </table>

                <input type="hidden" name="uploadhidden" id="uploadhidden" />
                  <input type="hidden" name="uploadhidden" id="Hidden1" />
                  <input type="hidden" name="uploadhidden" id="Hidden2" />
                  <input type="hidden" name="uploadhidden" id="Hidden3" />
                 <input type="hidden" name="uploadhidden" id="Hidden4" />
                <input type="hidden" name="uploadhidden" id="Hidden5" />
                <input type="hidden" name="uploadhidden" id="Hidden6" />
                <input type="hidden" name="uploadhidden" id="Hidden7" />
                 <input type="hidden" name="uploadhidden" id="Hidden8" />
            </div>
            <f:Panel ID="Panel1" ShowBorder="false" BodyPadding="5px" Title="面板" EnableCollapse="true"
                runat="server" AutoScroll="true" ShowHeader="false">
                <Toolbars>
                    <f:Toolbar ID="Toolbar5" runat="server" Position="Bottom" ToolbarAlign="Right">
                        <Items>

                            <f:Button ID="Button1" runat="server" Text="保存并关闭" OnClick="Button1_Click"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:Panel>
        </f:ContentPanel>


    </form>
    <script charset="gb2312">
        var up_type = '<%=lx %>';
        var up_type_zm = "";
        var hiddenid = "";
        var extensions = '<%=extensions %>';
        var webuploaderoptions = null;
        var uploader = null;
        var pickerid = "";
        var applicationPath = window.applicationPath === "" ? "" : window.applicationPath || "../..";
        var uploaderStrdiv = "";
        var flag = 0;
        if (extensions == "wmv") {
            $("#select_id").append("<option value='xz'>请选择视频分类</option>");
            $("#select_id").append("<option value='dcsj'>顶层设计</option>");
            $("#select_id").append("<option value='wngh'>五年规划</option>");
            $("#select_id").append("<option value='gzkcmc'>高职教师课程</option>");
            $("#select_id").append("<option value='zzkcmc'>中职教师课程</option>");
        }
        else {
            $("#select_id").append("<option value='xz'>请选择资料分类</option>");
            $("#select_id").append("<option value='smtg'>书面提交材料</option>");
            $("#select_id").append("<option value='zyrcpyfa'>专业人才培养方案</option>");
            //$("#select_id").append("<option value='jxjhb'>教学计划表</option>");
            //$("#select_id").append("<option value='qt'>其它</option>");
          
        }
        var jsonDatahid1 = {
            fileList: []
        };
        var jsonDatahid2 = {
            fileList: []
        };
        var jsonDatahid3 = {
            fileList: []
        };
        var jsonDatahid4 = {
            fileList: []
        };
        var jsonDatahid5 = {
            fileList: []
        };
        var jsonDatahid6 = {
            fileList: []
        };
        var jsonDatahid7 = {
            fileList: []
        };
        var jsonDatahid8 = {
            fileList: []
        };
        $("#select_id").change(function () {
            //alert($("#select_id").find("option:selected").text());
            $("#select_id option").each(function () { //遍历全部option
                var txt = $(this).text(); //获取option的内容
                if (txt == "请选择视频分类" || txt == "请选择资料分类") //如果不是“全部”
                    $(this).attr("disabled", "disabled");
            });
            //if ($("#select_id").val() != 'xz')
            //    $("#select_id").find("option:selected").attr("disabled", "disabled")
            up_type = encodeURI(encodeURI($("#select_id").find("option:selected").text()));//防止中文乱码
            up_type_zm = $("#select_id").val();
            if ($("#select_id").val() == 'dcsj') {
                flag++;
                hiddenid = "Hidden1";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                   
                    document.getElementById("thelist").innerHTML = "";
                   var $list = $(document.getElementById("thelist"));

                    var hdFileData1 = $("#" + hiddenid);
                    var fileDataStr1 = hdFileData1.val();
                  
                    if (fileDataStr1) {
                        jsonDatahid1 = JSON.parse(fileDataStr1);
                        $.each(jsonDatahid1.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
                
                $("#uploader").powerWebUpload({
                    hiddenInputId: "uploadhidden"
                });
            }
            else if ($("#select_id").val() == 'wngh') {
                flag++;
                hiddenid = "Hidden2";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                   
                    document.getElementById("thelist").innerHTML = "";
                    var $list = $(document.getElementById("thelist"));

                    var hdFileData2 = $("#" + hiddenid);
                    var fileDataStr2 = hdFileData2.val();
                  
                    if (fileDataStr2) {
                        jsonDatahid2 = JSON.parse(fileDataStr2);
                        $.each(jsonDatahid2.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div id="' + newid + '" class="item">' +
                            '<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
                $("#uploader").powerWebUpload({
                    hiddenInputId: "uploadhidden"
                });
            }
            else if ($("#select_id").val() == 'gzkcmc') {
                flag++;
                hiddenid = "Hidden3";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                    document.getElementById("thelist").innerHTML = "";
                    var $list = $(document.getElementById("thelist"));

                    var hdFileData3 = $("#" + hiddenid);
                    var fileDataStr3 = hdFileData3.val();
                    if (fileDataStr3) {
                        jsonDatahid3 = JSON.parse(fileDataStr3);
                        $.each(jsonDatahid3.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div id="' + newid + '" class="item">' +
                            '<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
                $("#uploader").powerWebUpload({
                    hiddenInputId: "uploadhidden"
                });
            }
            else if ($("#select_id").val() == 'zzkcmc') {
                flag++;
                hiddenid = "Hidden4";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                    document.getElementById("thelist").innerHTML = "";
                    var $list = $(document.getElementById("thelist"));

                    var hdFileData4 = $("#" + hiddenid);
                    var fileDataStr4 = hdFileData4.val();
                    if (fileDataStr4) {
                        jsonDatahid4 = JSON.parse(fileDataStr4);
                        $.each(jsonDatahid4.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div id="' + newid + '" class="item">' +
                            '<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
                $("#uploader").powerWebUpload({
                    hiddenInputId: "uploadhidden"
                });
            }

            else if ($("#select_id").val() == 'smtg') {
                flag++;
                hiddenid = "Hidden5";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                    document.getElementById("thelist").innerHTML = "";
                    var $list = $(document.getElementById("thelist"));

                    var hdFileData5 = $("#" + hiddenid);
                    var fileDataStr5 = hdFileData5.val();
                    if (fileDataStr5) {
                        jsonDatahid5 = JSON.parse(fileDataStr5);
                        $.each(jsonDatahid5.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div id="' + newid + '" class="item">' +
                            '<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
                $("#uploader").powerWebUpload({
                    hiddenInputId: "uploadhidden"
                });
            }

            else if ($("#select_id").val() == 'zyrcpyfa') {
                flag++;
                hiddenid = "Hidden6";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                    document.getElementById("thelist").innerHTML = "";
                    var $list = $(document.getElementById("thelist"));

                    var hdFileData6 = $("#" + hiddenid);
                    var fileDataStr6 = hdFileData6.val();
                    if (fileDataStr6) {
                        jsonDatahid6 = JSON.parse(fileDataStr6);
                        $.each(jsonDatahid6.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div id="' + newid + '" class="item">' +
                            '<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
                $("#uploader").powerWebUpload({
                    hiddenInputId: "uploadhidden"
                });
            }
            else if ($("#select_id").val() == 'jxjhb') {
                flag++;
               
                hiddenid = "Hidden7";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                    document.getElementById("thelist").innerHTML = "";
                    var $list = $(document.getElementById("thelist"));

                    var hdFileData7 = $("#" + hiddenid);
                    var fileDataStr7 = hdFileData7.val();
                    if (fileDataStr7) {
                        jsonDatahid7 = JSON.parse(fileDataStr7);
                        $.each(jsonDatahid7.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div id="' + newid + '" class="item">' +
                            '<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
               
                    $("#uploader").powerWebUpload({
                        hiddenInputId: "uploadhidden"
                    });
            }
            else if ($("#select_id").val() == 'qt') {
                flag++;
                
                hiddenid = "Hidden8";
                if (document.getElementById("thelist")) {
                    //$("#thelist").val('')
                    document.getElementById("thelist").innerHTML = "";
                    var $list = $(document.getElementById("thelist"));

                    var hdFileData8 = $("#" + hiddenid);
                    var fileDataStr8 = hdFileData8.val();
                    if (fileDataStr8) {
                        jsonDatahid8 = JSON.parse(fileDataStr8);
                        $.each(jsonDatahid8.fileList, function (index, fileData) {

                            var newid = S4();
                            fileData.queueId = newid;
                            $list.append('<div id="' + newid + '" class="item">' +
                            '<div class="info">' + fileData.name + '</div>' +
                            '<div class="state">已上传</div>'
                          );
                        });


                    }
                }
                $("#uploader").powerWebUpload({
                    hiddenInputId: "uploadhidden"
                });
            }
            else if ($("#select_id").val() == 'xz') {
              alert('此选项无效')
            }
        });


        function S4() {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        }
        //$(function () {
        //    $("#uploader").powerWebUpload({
        //        hiddenInputId: "uploadhidden"
        //    });

        //})
    </script>
</body>
</html>
