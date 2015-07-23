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
    public partial class Origin_Analysis : System.Web.UI.Page
    {
        public string seriesdata = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = GetDataTable();
                StringBuilder sb = new StringBuilder() ;
                sb.Append("<table class=\"bordered\"><thead><tr><th>来源</th><th>独立设置</th><th>二级学院</th><th>其他机构</th><th>合计</th></tr></thead><tr>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append("<td>" + dt.Rows[0][i] + "</td>");
                }
                sb.Append("</tr></table>");
                div.InnerHtml = sb.ToString();
                //获取来源
                StringBuilder _seriesdata = new StringBuilder(); //Y轴
                StringBuilder seriesdata0 = new StringBuilder();
                seriesdata0.AppendLine("{type: 'pie',name: 'Browser share',data: [");
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    seriesdata0.Append("['");
                    seriesdata0.Append(dt.Columns[i].ColumnName);
                    seriesdata0.Append("',");
                    seriesdata0.Append(dt.Rows[0][i].ToString());
                    seriesdata0.Append("],");
                    seriesdata0.Append("");
                }
                _seriesdata = seriesdata0.Replace(",", "", seriesdata0.Length - 1, 1); //这里是去掉最后一个多余的逗号（,）
                _seriesdata.AppendLine("]}");
                seriesdata = _seriesdata.ToString();
            }
        }

        /// <summary>
        /// 获取模拟表格
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ly", typeof(String)));
            table.Columns.Add(new DataColumn("独立设置", typeof(String)));
            table.Columns.Add(new DataColumn("二级学院", typeof(String)));
            table.Columns.Add(new DataColumn("其他机构", typeof(String)));
            table.Columns.Add(new DataColumn("hj", typeof(String)));

            string sqlstr = "  select xxlb, count(xxlb) from [XXJBQK]  where xxlb is not null group by XXLB";
            DataTable  dt = DbHelperSQL.Query(sqlstr).Tables[0];
           
                DataRow row = table.NewRow();

                row[0] = "数量";
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if(dt.Rows[i][0].ToString().Trim()=="独立设置")
                    row[1] = dt.Rows[i][1].ToString().Trim();
                else if (dt.Rows[i][0].ToString().Trim() == "二级学院")
                    row[2] = dt.Rows[i][1].ToString().Trim();

                else if (dt.Rows[i][0].ToString().Trim() == "其他机构")
                    row[3] = dt.Rows[i][1].ToString().Trim();
            }
            try
            {
                row[4] = Convert.ToInt32(row[1]) + Convert.ToInt32(row[2]) + Convert.ToInt32(row[3]);
            }
            catch (Exception ex)
            {
                //NumberBox_sqzxjfhj.Text = "0";
                //Alert.Show("计费合计错误：" + ex.Message);
            }

                table.Rows.Add(row);
           

            return table;
        }
    }
}