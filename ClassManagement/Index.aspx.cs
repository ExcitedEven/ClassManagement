using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string A = RadioButtonList1.SelectedValue;
        string B = TextBox1.Text;
        System.Data.SqlClient.SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
            ConfigurationManager.ConnectionStrings["dormitorymanagementConnectionString"].ConnectionString;

        SqlCommand Cmd = new SqlCommand();
        Cmd.Connection = conn;
        switch (A)
        {
            case "电费查询":
                try
                {
                    conn.Open();
                    Cmd.CommandText = "select[rest_money]from[bedroom] where room_no=@ID";
                    Cmd.CommandType = CommandType.Text;
                    SqlParameter para = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 50);
                    para.Value = B;
                    Cmd.Parameters.Add(para);
                    SqlDataReader dr = Cmd.ExecuteReader();
                    dr.Read();
                    float a = (float)dr.GetDouble(0);
                    xianshi.Text = a.ToString();
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                break;
            case "工作安排":
                try
                {
                    Session.Add("cleaner_no",TextBox1.Text);
                    Response.Redirect("CleanTime.aspx");
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                break;
        }
        conn.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}