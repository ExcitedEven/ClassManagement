using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

/* 
 * 查询保洁人员排班
 * 传参Session["cleaner_no"]
 * 有则显示对应排班，没有显示全部排班
 **/

public partial class CleanTime : System.Web.UI.Page
{
    string cleaner_no;
    protected void Page_Load(object sender, EventArgs e)
    {
        cleaner_no = Session["cleaner_no"].ToString().Trim();
        //cleaner_no = "C009";
        DataView rows = (DataView)SqlDataSource_cleaner.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView row in rows)
        {
            for (int i = 0; i < rows.Table.Columns.Count;)
            {
                string read_cleaner_no = row.Row[i++].ToString();
                if (read_cleaner_no == cleaner_no)
                {
                    //TODO 存在
                    string SelectCommandStringOne = "SELECT on_duty.cleaner_no, cleaner.cleaner_name, on_duty.dutytime FROM on_duty INNER JOIN cleaner ON on_duty.cleaner_no = cleaner.cleaner_no WHERE　on_duty.cleaner_no = '" + cleaner_no + "'";
                    showCleaner(SelectCommandStringOne);
                    return;
                }
                //TODO 不存在
                string SelectCommandString = "SELECT on_duty.cleaner_no, cleaner.cleaner_name, on_duty.dutytime FROM on_duty INNER JOIN cleaner ON on_duty.cleaner_no = cleaner.cleaner_no";
                showCleaner(SelectCommandString);
                return;
            }
        }
    }

    private void showCleaner(string SelectCommandString)
    {
        SqlDataSource_cleaner.SelectCommand = SelectCommandString;
        DataView rows = (DataView)SqlDataSource_cleaner.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView row in rows)
        {
            for (int i = 0; i < rows.Table.Columns.Count;)
            {
                string read_cleaner_no = row.Row[i++].ToString();
                string read_cleaner_name = row.Row[i++].ToString();
                string read_dutytime = row.Row[i++].ToString();
                switch (read_dutytime)
                {
                    case "1":
                        Label1.Text = read_cleaner_name;
                        break;
                    case "2":
                        Label2.Text = read_cleaner_name;
                        break;
                    case "3":
                        Label3.Text = read_cleaner_name;
                        break;
                    case "4":
                        Label4.Text = read_cleaner_name;
                        break;
                    case "5":
                        Label5.Text = read_cleaner_name;
                        break;
                    case "6":
                        Label6.Text = read_cleaner_name;
                        break;
                    case "7":
                        Label7.Text = read_cleaner_name;
                        break;

                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}