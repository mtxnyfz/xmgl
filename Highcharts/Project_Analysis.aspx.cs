using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;

namespace XMGL.Web.Highcharts
{
    public partial class Project_Analysis : System.Web.UI.Page
    {
        public string seriesdata = "",seriesdata1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = GetDataTable();


                StringBuilder sb = new StringBuilder();
                sb.Append("<table class=\"bordered\"><thead><tr><th>项目类别</th><th>数量</th><th>申报金额（万元）</th><th>配套金额（万元）</th></tr></thead>");
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    sb.Append("<tr><td>" + dt.Rows[i][0] + "</td>");
                    sb.Append("<td>" + dt.Rows[i][1] + "</td>");
                    sb.Append("<td>" + dt.Rows[i][2] + "</td>");
                    sb.Append("<td>" + dt.Rows[i][3] + "</td></tr>");
                }
                sb.Append("</table>");
                div.InnerHtml = sb.ToString();


                //获取来源
                StringBuilder _seriesdata = new StringBuilder(); //Y轴
                StringBuilder seriesdata0 = new StringBuilder();
                seriesdata0.AppendLine("{type: 'pie',name: 'Browser share',data: [");
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    seriesdata0.Append("['");
                    seriesdata0.Append(dt.Rows[i][0].ToString());
                    seriesdata0.Append("',");
                    seriesdata0.Append(dt.Rows[i][2].ToString());
                    seriesdata0.Append("],");
                    seriesdata0.Append("");
                }
                _seriesdata = seriesdata0.Replace(",", "", seriesdata0.Length - 1, 1); //这里是去掉最后一个多余的逗号（,）
                _seriesdata.AppendLine("]}");
                seriesdata = _seriesdata.ToString();




                 _seriesdata = new StringBuilder(); //Y轴
                 seriesdata0 = new StringBuilder();
                seriesdata0.AppendLine("{type: 'pie',name: 'Browser share',data: [");
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    seriesdata0.Append("['");
                    seriesdata0.Append(dt.Rows[i][0].ToString());
                    seriesdata0.Append("',");
                    seriesdata0.Append(dt.Rows[i][3].ToString());
                    seriesdata0.Append("],");
                    seriesdata0.Append("");
                }
                _seriesdata = seriesdata0.Replace(",", "", seriesdata0.Length - 1, 1); //这里是去掉最后一个多余的逗号（,）
                _seriesdata.AppendLine("]}");
                seriesdata1 = _seriesdata.ToString();
            }
        }
        /// <summary>
        /// 获取模拟表格
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            DataTable dt_t = null;
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("xmlb", typeof(String)));
            table.Columns.Add(new DataColumn("sl", typeof(String)));
            table.Columns.Add(new DataColumn("sbje", typeof(String)));
            table.Columns.Add(new DataColumn("ptje", typeof(String)));

            			

            //DataRow row = table.NewRow();
            //row[0] = "产教研协同基地";
            //row[1] = "9";
            //row[2] = "1500";
            //row[3] = "750";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "双证融通";
            //row[1] = "8";
            //row[2] = "2000";
            //row[3] = "1000";
            //table.Rows.Add(row);		

            //row = table.NewRow();
            //row[0] = "通用项目";
            //row[1] = "1";
            //row[2] = "100";
            //row[3] = "50";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "一流专业建设";
            //row[1] = "17";
            //row[2] = "6000";
            //row[3] = "3000";
            //table.Rows.Add(row);

            //row = table.NewRow();
            //row[0] = "合计";
            //row[1] = "35";
            //row[2] = "9600";
            //row[3] = "4800";
            //table.Rows.Add(row);
            try
            {
                DataRow row = null;
                string sqlstr = "select cc.XMDLMC,count(cc.XMDLMC),sum(ISNULL(cc.SQZXJF,0)),sum(ISNULL(cc.XXPTJF,0)) from (select  '一流专业建设' as XMDLMC, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,a.SQZXJF+a.XXPTJF as XMZJF from (select XMBH, XXDM,XMMC,ZYFZR_XM, SQZXJF as SQZXJF,XXPTJF as XXPTJF from YLZY where  SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6   ) as a,XXJBQKB as b where a.XXDM=b.XXDM) as cc group by cc.XMDLMC";
                DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
                int hj = 0;
                double hj1 = 0, hj2 = 0, hj3 = 0;
                if (dt.Rows.Count > 0)
                {
                    row = table.NewRow();
                    row[0] = dt.Rows[0][0];
                    row[1] = dt.Rows[0][1];
                    row[2] = dt.Rows[0][2];
                    row[3] = dt.Rows[0][3];
                    table.Rows.Add(row);
                    hj1 = hj1 + Convert.ToDouble(row[1]);
                    hj2 = hj2 + Convert.ToDouble(row[2]);
                    hj3 = hj3 + Convert.ToDouble(row[3]);
                }

                sqlstr = "select cc.XMDLMC,count(cc.XMDLMC),sum(ISNULL(cc.SQZXJF,0)),sum(ISNULL(cc.XXPTJF,0)) from (select a.XMBH as XMBH,  b.XXMC AS XXMC, '双证融通' as XMDLMC,a.XMMC as XMMC,a.XMFZR_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,XMMC,XMFZR_XM, JFYS_SQJF as SQZXJF,JFYS_XXPTJF as XXPTJF from SZRT where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM) as cc group by cc.XMDLMC";
                dt = DbHelperSQL.Query(sqlstr).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    row = table.NewRow();
                    row[0] = dt.Rows[0][0];
                    row[1] = dt.Rows[0][1];
                    row[2] = dt.Rows[0][2];
                    row[3] = dt.Rows[0][3];
                    table.Rows.Add(row);
                    hj1 = hj1 + Convert.ToDouble(row[1]);
                    hj2 = hj2 + Convert.ToDouble(row[2]);
                    hj3 = hj3 + Convert.ToDouble(row[3]);
                }


                sqlstr = "select cc.XMDLMC,count(cc.XMDLMC),sum(ISNULL(cc.SQZXJF,0)),sum(ISNULL(cc.XXPTJF,0)) from (select  a.XMBH as XMBH, b.XXMC AS XXMC, '产教研协同基地' as XMDLMC,a.JDMC as XMMC,a.JDFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, XXDM,JDMC,JDFZRXX_XM, ZXJF_SQZXJF as SQZXJF,XXPTJF_XXPTJF as XXPTJF from CJYXTJD_XM where  SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b  where a.XXDM=b.XXDM) as cc group by cc.XMDLMC";
                dt = DbHelperSQL.Query(sqlstr).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    row = table.NewRow();
                    row[0] = dt.Rows[0][0];
                    row[1] = dt.Rows[0][1];
                    row[2] = dt.Rows[0][2];
                    row[3] = dt.Rows[0][3];
                    table.Rows.Add(row);
                    hj1 = hj1 + Convert.ToDouble(row[1]);
                    hj2 = hj2 + Convert.ToDouble(row[2]);
                    hj3 = hj3 + Convert.ToDouble(row[3]);
                }


                sqlstr = "select cc.XMDLMC,count(cc.XMDLMC),sum(ISNULL(cc.SQZXJF,0)),sum(ISNULL(cc.XXPTJF,0)) from (select a.XMBH,a.DWMC AS XXMC,a.XMDLMC,a.XMMC,'' as ZYFZR_XM,a.SQZXJF,a.XXPTJF,a.XMZJF from (select SZPX_XMSB.XMBH,SZPX_XMSB.DWMC,'师资培训' as XMDLMC ,SZPX_XMSB.XMMC, cast(SZPX_JFYS.JFYS as float) as SQZXJF ,0.0 as XXPTJF,SZPX_JFYS.JFYS as XMZJF from SZPX_XMSB,SZPX_JFYS where SZPX_XMSB.XMBH=SZPX_JFYS.XMBH and SZPX_JFYS.JFLX='ZXJF' and SZPX_XMSB.SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC) as cc group by cc.XMDLMC";
                dt = DbHelperSQL.Query(sqlstr).Tables[0];

                sqlstr = "select cc.XMDLMC,sum(ISNULL(cc.XXPTJF,0))  from (select a.XMBH,a.DWMC AS XXMC,a.XMDLMC,a.XMMC,'' as ZYFZR_XM,a.XXPTJF,a.XMZJF from (select SZPX_XMSB.XMBH,SZPX_XMSB.DWMC,'师资培训' as XMDLMC ,SZPX_XMSB.XMMC, cast(SZPX_JFYS.JFYS as float) as XXPTJF ,SZPX_JFYS.JFYS as XMZJF from SZPX_XMSB,SZPX_JFYS where SZPX_XMSB.XMBH=SZPX_JFYS.XMBH and SZPX_JFYS.JFLX='PTJF' and SZPX_XMSB.SFSC!=1 and  ZT>=3 and ZT!=4 and ZT!=6) as a,XXJBQKB as b where a.DWMC=b.XXMC) as cc group by cc.XMDLMC";
                dt_t = DbHelperSQL.Query(sqlstr).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt_t.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["XMDLMC"].ToString().Trim() == dt_t.Rows[i]["XMDLMC"].ToString().Trim())
                            dt.Rows[i][3] = dt.Rows[i][1];
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    row = table.NewRow();
                    row[0] = dt.Rows[0][0];
                    row[1] = dt.Rows[0][1];
                    row[2] = dt.Rows[0][2];
                    row[3] = dt.Rows[0][3];
                    table.Rows.Add(row);
                    hj1 = hj1 + Convert.ToDouble(row[1]);
                    hj2 = hj2 + Convert.ToDouble(row[2]);
                    hj3 = hj3 + Convert.ToDouble(row[3]);
                }

                sqlstr = "select cc.XMDLMC,count(cc.XMDLMC),sum(ISNULL(cc.SQZXJF,0)),sum(ISNULL(cc.XXPTJF,0)) from (select a.XMBH as XMBH,  b.XXMC AS XXMC, '技术技能竞赛' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from JSJNJS_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.DWMC=b.XXMC) as cc group by cc.XMDLMC";
                dt = DbHelperSQL.Query(sqlstr).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    row = table.NewRow();
                    row[0] = dt.Rows[0][0];
                    row[1] = dt.Rows[0][1];
                    row[2] = dt.Rows[0][2];
                    row[3] = dt.Rows[0][3];
                    table.Rows.Add(row);
                    hj1 = hj1 + Convert.ToDouble(row[1]);
                    hj2 = hj2 + Convert.ToDouble(row[2]);
                    hj3 = hj3 + Convert.ToDouble(row[3]);
                }


                sqlstr = "select cc.XMDLMC,count(cc.XMDLMC),sum(ISNULL(cc.SQZXJF,0)),sum(ISNULL(cc.XXPTJF,0)) from (select a.XMBH as XMBH,  b.XXMC AS XXMC, '信息管理平台' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from XXGLPT_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.DWMC=b.XXMC) as cc group by cc.XMDLMC";
                dt = DbHelperSQL.Query(sqlstr).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    row = table.NewRow();
                    row[0] = dt.Rows[0][0];
                    row[1] = dt.Rows[0][1];
                    row[2] = dt.Rows[0][2];
                    row[3] = dt.Rows[0][3];
                    table.Rows.Add(row);
                    hj1 = hj1 + Convert.ToDouble(row[1]);
                    hj2 = hj2 + Convert.ToDouble(row[2]);
                    hj3 = hj3 + Convert.ToDouble(row[3]);
                }

                sqlstr = "select cc.XMDLMC,count(cc.XMDLMC),sum(ISNULL(cc.SQZXJF,0)),sum(ISNULL(cc.XXPTJF,0)) from (select a.XMBH as XMBH,  b.XXMC AS XXMC, '通用类' as XMDLMC,a.XMMC as XMMC,a.XMFZRXX_XM as ZYFZR_XM, a.SQZXJF as SQZXJF,a.XXPTJF as XXPTJF,(a.SQZXJF+a.XXPTJF) as XMZJF from (select XMBH, DWMC,XMMC,XMFZRXX_XM, JFYS_ZXJF as SQZXJF,JFYS_XXPTJF as XXPTJF from TYL_XM where   SFSC!=1  and  ZT>=3 and ZT!=4 and ZT!=6 ) as a,XXJBQKB as b where a.DWMC=b.XXMC) as cc group by cc.XMDLMC";
                dt = DbHelperSQL.Query(sqlstr).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    row = table.NewRow();
                    row[0] = dt.Rows[0][0];
                    row[1] = dt.Rows[0][1];
                    row[2] = dt.Rows[0][2];
                    row[3] = dt.Rows[0][3];
                    table.Rows.Add(row);
                    hj1 = hj1 + Convert.ToDouble(row[1]);
                    hj2 = hj2 + Convert.ToDouble(row[2]);
                    hj3 = hj3 + Convert.ToDouble(row[3]);
                }

                row = table.NewRow();
                row[0] = "合计";
                row[1] = hj1;
                row[2] = hj2;
                row[3] = hj3;
                table.Rows.Add(row);
            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
                //Alert.Show("计费合计错误：" + ex.Message);
            }
            return table;
        }
    }
}