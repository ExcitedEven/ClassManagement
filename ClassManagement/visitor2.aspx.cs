using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class visitor2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        System.Data.SqlClient.SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["dormitorymanagementConnectionString"].ConnectionString;
        conn.Open();

        string str = "select[visitor_date],[visitor_name],[visitor_phone] from[visitor]";
        SqlCommand Cmd = new SqlCommand(str,conn);
       // Cmd.Connection = conn;
        SqlDataReader rd = Cmd.ExecuteReader();
      while (rd.Read()){
            TextBox1.Text += rd["visitor_date"].ToString().Trim()+" ";
            TextBox2.Text += rd["visitor_name"].ToString().Trim()+" ";
            TextBox3.Text += rd["visitor_phone"].ToString().Trim()+" ";
        }
        rd.Close();
        conn.Close();
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("visitors.aspx");
    }
}