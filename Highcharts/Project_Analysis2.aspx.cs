using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMGL.Web.Highcharts
{
    public partial class Project_Analysis2 : System.Web.UI.Page
    {
        public string seriesdata = "";
        public string categories = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //            'Nov',
            //            'Dec'

            if (!IsPostBack)
            {
                DataTable dt = GetDataTable();
                //获取来源
                StringBuilder _categories = new StringBuilder(); //Y轴
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    _categories.Append("'");
                    _categories.Append(dt.Rows[i][0].ToString());
                    _categories.Append("',");
                }
                categories = _categories.Replace(",", "", _categories.Length - 1, 1).ToString();



                StringBuilder _seriesdata = new StringBuilder(); //Y轴
                StringBuilder seriesdata0 = new StringBuilder();
                for (int j = 2; j < dt.Columns.Count; j++)
                {
                    //拼接series，例如：{
                    //                  name: 'London',
                    //                  data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]
                    //                },
                    seriesdata0.Append("{");
                    //seriesdata0.AppendLine("");
                    seriesdata0.Append("name: '");
                    seriesdata0.Append(dt.Columns[j].ColumnName);
                    seriesdata0.Append("',");
                    //seriesdata0.AppendLine("");
                    seriesdata0.Append("data: [");
                    //获取各个项目对应的数据，凭借起来，例如：data: [83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0, 104.3, 91.2, 83.5, 106.6, 92.3]
                    StringBuilder _seriesdata0 = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        _seriesdata0.Append(dt.Rows[i][j].ToString());
                        _seriesdata0.Append(",");
                    }
                    seriesdata0.Append(_seriesdata0.Replace(",", "", _seriesdata0.Length - 1, 1)); //这里是去掉最后一个多余的逗号（,）
                    seriesdata0.Append("]");
                    //seriesdata0.AppendLine("");
                    seriesdata0.AppendLine("},");
                }
                //FineUI.Alert.Show(seriesdata0.ToString());
                seriesdata = seriesdata0.Replace(",", "", seriesdata0.Length - 1, 1).ToString();
            }
        }



        /// <summary>
        /// 获取模拟表格
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("xmlb", typeof(String)));
            table.Columns.Add(new DataColumn("sl", typeof(String)));
            table.Columns.Add(new DataColumn("sbje", typeof(String)));
            table.Columns.Add(new DataColumn("ptje", typeof(String)));



            DataRow row = table.NewRow();
            row[0] = "产教研协同基地";
            row[1] = "9";
            row[2] = "1500";
            row[3] = "750";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "双证融通";
            row[1] = "8";
            row[2] = "2000";
            row[3] = "1000";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "通用项目";
            row[1] = "1";
            row[2] = "100";
            row[3] = "50";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "一流专业建设";
            row[1] = "17";
            row[2] = "6000";
            row[3] = "3000";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "合计";
            row[1] = "35";
            row[2] = "9600";
            row[3] = "4800";
            table.Rows.Add(row);

            return table;
        }
    }
}