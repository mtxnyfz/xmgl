<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Analysis2.aspx.cs" Inherits="XMGL.Web.Highcharts.Project_Analysis2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/highcharts.js"></script>
    <script src="../js/exporting.js"></script>
    <script>
        $(function () {
            $('#container').highcharts({
                chart: {
                    type: 'column'
                },
                colors: [
                       '#1aadce',
                           '#492970',
                           '#f28f43',
                           '#77a1e5',
                           '#c42525',
                           '#a6c96a'
                ],

                title: {
                    text: '<span style="font-size:14px;font-weight:bold">来源分析</span>'
                },
                subtitle: {
                    text: '<span style="font-size:12px">项目金额</span>'
                },
                xAxis: {
                    categories: [<%= categories%>]
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: '金额 (万元)'
                    }
                },
                credits: {
                    text: '技术支持：上海行健职业学院',
                    href: 'http://www.shxj.edu.cn'
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} 万元</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [<%= seriesdata%>]
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    </form>
</body>
</html>
